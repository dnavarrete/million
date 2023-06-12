using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Million.Core;
using Million.Infrastructure;
using Million.Services.Mappings;
using Million.Services.UseCases.PropertyImagesUseCases;
using Million.Services.UseCases.PropertyUseCases;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<MillionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(PropertyMappingProfile).Assembly);
builder.Services.AddControllers();

builder.Services.AddScoped<GetPropertiesUseCase>();
builder.Services.AddScoped<CreatePropertyUseCase>();
builder.Services.AddScoped<AddPropertyImageUseCase>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Million Property Building API",
        Version = "v1",
        Contact = new OpenApiContact 
        {
            Name = "Diego Navarrete",
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
