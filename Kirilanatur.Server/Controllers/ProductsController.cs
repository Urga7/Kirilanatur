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
                var products = await _dbContext.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .ThenInclude(c => c!.Variations)
                .ThenInclude(v => v.Options)
                .Select(p => new ProductDto {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Discount = p.Discount,
                    Available = p.Available,
                    Images = p.Images.Select(img => new ProductImageDto {
                        Id = img.Id,
                        ImageUrl = img.ImageUrl,
                        ImageDescription = img.ImageDescription
                    }).ToList(),
                    Category = p.Category != null ? new ProductCategoryDto {
                        Id = p.Category.Id,
                        Name = p.Category.CategoryName,
                        Variations = p.Category.Variations.Select(v => new VariationDto {
                            Id = v.Id,
                            Name = v.Name,
                            Options = v.Options.Select(vo => new VariationOptionDto {
                                Id = vo.Id,
                                Value = vo.Value
                            }).ToList()
                        }).ToList()
                    } : null
                })
                .ToListAsync();

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
