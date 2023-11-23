namespace RiceLinkAPI.Models.Products
{
    public class UpsertProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string PackageSize { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public bool? InStock { get; set; } // Nullable for PATCH requests
        public string Description { get; set; }
    }
}
