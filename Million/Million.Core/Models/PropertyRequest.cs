namespace Million.Core.Models
{
    public class PropertyRequest
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string CodeInternal { get; set; } = string.Empty;

        public int Year { get; set; }
    }
}
