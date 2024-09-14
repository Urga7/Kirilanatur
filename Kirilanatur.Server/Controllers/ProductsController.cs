using Kirilanatur.Server.Database;
using Kirilanatur.Server.Database.Models;
using Kirilanatur.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Kirilanatur.Server.Helpers.ExceptionHelper;

namespace Kirilanatur.Server.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {
        
        private readonly KirilanaturDbContext _dbContext;

        public ProductsController(KirilanaturDbContext dbContext) {
            _dbContext = dbContext;
        }
        
        [HttpPost("GetProducts")]
        public async Task<ServerResponse> GetProducts([FromBody] LanguageChangeRequestDto languageChangeRequestDto) {
            try {
                string language = languageChangeRequestDto.Language;
                List<ProductDto> products = await _dbContext.Products
                    .Include(p => p.Images)
                    .Include(p => p.Translations)
                    .Include(p => p.Category)
                        .ThenInclude(c => c!.Translations)
                    .Include(p => p.Category)
                        .ThenInclude(c => c!.Variations)
                        .ThenInclude(v => v.Translations)
                    .Include(p => p.Category)
                        .ThenInclude(c => c!.Variations)
                        .ThenInclude(v => v.Options)
                        .ThenInclude(vo => vo.Translations)
                    .Select(p => new ProductDto {
                        Id = p.Id,
                        Name = p.Translations.FirstOrDefault(t => t.LanguageCode == language)!.Name,
                        Description = p.Translations.FirstOrDefault(t => t.LanguageCode == language)!.Description,
                        Price = p.Price,
                        Discount = p.Discount,
                        Available = p.Available,
                        Images = p.Images.Select(img => new ProductImageDto {
                            Id = img.Id,
                            ImageUrl = img.ImageUrl,
                            ImageDescription = img.Translations.FirstOrDefault(t => t.LanguageCode == language)!.Description,
                        }).ToList(),
                        Category = new ProductCategoryDto {
                            Id = p.Category!.Id,
                            Name = p.Category.Translations.FirstOrDefault(ct => ct.LanguageCode == language)!.Name,
                            Variations = p.Category.Variations.Select(v => new VariationDto {
                                Id = v.Id,
                                Name = v.Translations.FirstOrDefault(vt => vt.LanguageCode == language)!.Name,
                                Options = v.Options.Select(vo => new VariationOptionDto {
                                    Id = vo.Id,
                                    Value = vo.Translations.FirstOrDefault(vot => vot.LanguageCode == language)!.Value
                                }).ToList()
                            }).ToList()
                        }
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
