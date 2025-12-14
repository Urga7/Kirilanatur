using System.Runtime.Serialization;
using JetBrains.Annotations;
using Kirilanatur.Infrastructure.Endpoints;
using Stripe;

namespace Kirilanatur.Features;

public static class GetPrices
{
    [DataContract]
    private sealed record PriceDto(string Id, string ProductId, long Amount, int Size);
    
    [DataContract]
    private sealed record GetPricesResponse(PriceDto[] Prices);
    
    [UsedImplicitly]
    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("prices", Handler);
        }
    }
    
    private static readonly PriceListOptions PriceListOptions = new() { Limit = 100 };
    
    public static async Task<IResult> Handler()
    {
        var priceService = new PriceService();
        var stripeResponse = await priceService.ListAsync(PriceListOptions);
        var prices = stripeResponse.Data.Select(ToProductDto).ToArray();
        return Results.Ok(new GetPricesResponse(prices));
    }
    
    private static PriceDto ToProductDto(this Price stripePrice)
    {
        var obtainedSizeString = stripePrice.Metadata.TryGetValue("size", out var sizeString);
        if (!obtainedSizeString) throw new Exception("Size not found");
        var size = int.Parse(sizeString!);

        return new PriceDto(
        Id: stripePrice.Id,
        ProductId: stripePrice.ProductId,
        Amount: stripePrice.UnitAmount!.Value / 100,
        Size: size
        );
    }
}
