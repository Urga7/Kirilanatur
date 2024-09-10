namespace Kirilanatur.Server.Models {
    
    public class ProductDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public bool Available { get; set; }
        public List<ProductImageDto> Images { get; set; }
    }

    public class ProductImageDto {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ImageDescription { get; set; }
    }

}
