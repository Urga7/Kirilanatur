using System.Runtime.Serialization;
using JetBrains.Annotations;
using Kirilanatur.Infrastructure.Endpoints;
using Stripe;

namespace Kirilanatur.Features;

public static class GetProducts
{
    [DataContract]
    private sealed record ProductDto(
    string Id,
    string Name,
    string DefaultPriceId,
    string MainImage,
    string[] Images, 
    string ExampleUsageImage);
    
    [DataContract]
    private sealed record GetProductsResponse(ProductDto[] Products);
    
    [UsedImplicitly]
    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("products", Handler);
        }
    }

    public static async Task<IResult> Handler()
    {
        var productsService = new ProductService();
        var stripeResponse = await productsService.ListAsync();
        var products = stripeResponse.Data.Select(ToProductDto).ToArray();
        return Results.Ok(new GetProductsResponse(products));
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
