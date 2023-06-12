namespace Million.Services.Filters
{
    public sealed class PropertyFilter
    {
        public int? Year { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }
    }
}
