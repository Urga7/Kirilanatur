using System.Runtime.Serialization;
using JetBrains.Annotations;
using Kirilanatur.Infrastructure.Attributes;
using Kirilanatur.Infrastructure.Endpoints;
using Microsoft.Extensions.Caching.Memory;
using Stripe;

namespace Kirilanatur.Features;

public static class GetProducts
{
    [Dto]
    private sealed record ProductDto(
    string Id,
    string Name,
    string DefaultPriceId,
    string MainImage,
    string[] Images, 
    string ExampleUsageImage
    );
    
    [Dto] private sealed record GetProductsResponse([property: DataMember] ProductDto[] Products);
    
    [UsedImplicitly]
    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("products", Handler);
        }
    }

    private const string CacheKey = "GetProducts:All";
    private static readonly MemoryCacheEntryOptions CacheOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
    };

    public static async Task<IResult> Handler(IMemoryCache cache)
    {
        if (!cache.TryGetValue(CacheKey, out ProductDto[]? products))
        {
            products = await GetProductsAsync();
            cache.Set(CacheKey, products, CacheOptions);
        }

        return Results.Ok(new GetProductsResponse(products!));
    }

    private static async Task<ProductDto[]> GetProductsAsync()
    {
        var productsService = new ProductService();
        var stripeResponse = await productsService.ListAsync();
        return stripeResponse.Data.Select(ToProductDto).ToArray();
    }

    private static ProductDto ToProductDto(this Product stripeProduct)
    {
        stripeProduct.Metadata.TryGetValue("mainImage", out var mainImage);
        stripeProduct.Metadata.TryGetValue("exampleUsageImage", out var exampleUsageImage);
        stripeProduct.Metadata.TryGetValue("images", out var imagesRaw);

        return new ProductDto(
        Id: stripeProduct.Id,
        Name: stripeProduct.Name,
        DefaultPriceId: stripeProduct.DefaultPriceId,
        MainImage: mainImage ?? string.Empty,
        Images: imagesRaw?.Split(';') ?? [], 
        ExampleUsageImage: exampleUsageImage ?? string.Empty
        );
    }
}
