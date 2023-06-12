namespace Million.Core.Models
{
    public sealed class PropertyImageRequest
    {
        public string Id { get; set; } = string.Empty;

        public string IdProperty { get; set; } = string.Empty;

        public string File { get; set; } = string.Empty;

        public bool Enabled { get; set; }
    }
}
