using System.Runtime.Serialization;
using JetBrains.Annotations;
using Kirilanatur.Core.Domain.External.Stripe;
using Kirilanatur.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace Kirilanatur.Features;

public static class PurchaseSandal
{
    [DataContract] private record PurchaseSandalRequest(string PriceId, long Quantity);
    [DataContract] private record PurchaseSandalResponse(string Url);
    
    [UsedImplicitly]
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/sandals/purchase", Handler);
        }
    }

    private static async Task<IResult> Handler(PurchaseSandalRequest request, StripeKeys stripeKeys)
    {
        StripeConfiguration.ApiKey = stripeKeys.SecretKey;
        var options = new SessionCreateOptions
        {
            LineItems = [
                new SessionLineItemOptions
                {
                    Price = request.PriceId,
                    Quantity = request.Quantity
                }
            ],
            Mode = "payment",
            SuccessUrl = "http://localhost:4200/success",
            CancelUrl = "http://localhost:4200/home"
        };
        
        options.AddExtraParam("branding_settings[display_name]", "Kirilanatur");
        options.AddExtraParam("branding_settings[font_family]", "lato");
        options.AddExtraParam("branding_settings[border_style]", "rectangular");
        options.AddExtraParam("branding_settings[background_color]", "#FDFEFF");
        options.AddExtraParam("branding_settings[button_color]", "#2C2E36");
        
        var service = new SessionService();
        var session = await service.CreateAsync(options);
        return Results.Ok(new PurchaseSandalResponse(session.Url));
    }
}
