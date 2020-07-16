namespace Domain
{
    public class File : Entity<short>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public Product ProductImage { get; set; }
        public short?  ProductImageId { get; set; }
    }
}