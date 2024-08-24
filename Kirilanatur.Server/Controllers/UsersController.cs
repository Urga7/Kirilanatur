using Kirilanatur.Server.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase {
    
        private readonly KirilanaturDbContext _dbContext;

        public UsersController(KirilanaturDbContext dbDbContext) {
            _dbContext = dbDbContext;
        }
        
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto) {
            
            Product product = new Product {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = 100,
                Discount = 0,
                Availability = true,
                Images = []
            };
            
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            
            // TODO: Return in unified form
            return Ok(new { message = "Product added successfully." });
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts() {

            var products = await _dbContext.Products.Include(p => p.Images).ToListAsync();
            return Ok(products);

        }
        
    }

    public class ProductDto {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
    
}
