namespace Million.Core.Models
{
    public sealed class PropertyResponse
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Year { get; set; }
    }
}
