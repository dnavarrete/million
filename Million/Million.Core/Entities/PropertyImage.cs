namespace Million.Core.Entities
{
    public class PropertyImage
    {
        public Guid Id { get; set; }

        public Guid IdProperty { get; set; }

        public string File { get; set; } = string.Empty;

        public bool Enabled { get; set; }
    }
}
