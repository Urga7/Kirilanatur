using Kirilanatur.Server.DbModels;
using Kirilanatur.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Kirilanatur.Server.Helpers.ExceptionHelper;

namespace Kirilanatur.Server.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller {
        
        private readonly KirilanaturDbContext _dbContext;

        public ProductsController(KirilanaturDbContext dbContext) {
            _dbContext = dbContext;
        }
        
        [HttpGet("GetProducts")]
        public async Task<ServerResponse> GetProducts() {
            try {
                List<Product> products = await _dbContext.Products.ToListAsync();
                return new ServerResponse {
                    Data = products
                };
            } catch (Exception ex) {
                return ErrorResponse(ex);
            }
        }

        [HttpPost("AddProduct")]
        public async Task<ServerResponse> AddProduct([FromBody] Product product) {
            try
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return new ServerResponse {
                    Messages = ["Product added."]
                };
            }
            catch (Exception ex) {
                return ErrorResponse(ex);
            }
        }

    }
    
}
