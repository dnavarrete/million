namespace Million.Core.Entities
{
    public sealed class Property
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string CodeInternal { get; set; } = string.Empty;

        public int Year { get; set; }

        public Guid IdOwner { get; set; }
    }
}
