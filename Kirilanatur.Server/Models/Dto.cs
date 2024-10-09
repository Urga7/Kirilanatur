namespace Kirilanatur.Server.Models {
    
    public class ProductDto {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Price { get; set; }
        public int Discount { get; set; }
        public bool Available { get; set; }
        public List<ProductImageDto> Images { get; set; } = [];
        public ProductCategoryDto? Category { get; set; }
    }

    public class ProductImageDto {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = "";
        public string ImageDescription { get; set; } = "";
    }

    public class ProductCategoryDto {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<VariationDto> Variations { get; set; } = [];
    }

    public class VariationDto {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<VariationOptionDto> Options { get; set; } = [];
    }

    public class VariationOptionDto {
        public int Id { get; set; }
        public string Value { get; set; } = "";
    }
    
    public class LanguageChangeRequestDto {
        public string Language { get; set; } = "sl";
    }

    public class RegisterRequestDto {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class LoginRequestDto {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }

}
