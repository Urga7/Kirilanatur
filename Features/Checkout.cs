using JetBrains.Annotations;
using Kirilanatur.Infrastructure.Attributes;
using Kirilanatur.Infrastructure.Endpoints;
using Stripe.Checkout;

namespace Kirilanatur.Features;

public static class Checkout
{
    [Dto] private record CheckoutRequest(CheckoutItem[] Items);
    
    [Dto] private record CheckoutItem(string PriceId, long Quantity);
    
    [Dto] private record CheckoutResponse(string ClientSecret);
    
    [UsedImplicitly]
    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("checkout", Handler);
        }
    }
    
    private static async Task<IResult> Handler(CheckoutRequest request)
    {
        var options = new SessionCreateOptions
        {
            LineItems = request.Items
            .Select(r => new SessionLineItemOptions
            {
                Price = r.PriceId,
                Quantity = r.Quantity
            })
            .ToList(),
            Mode = "payment",
            UiMode = "embedded", 
            ReturnUrl = "http://localhost:4200/return?session_id={CHECKOUT_SESSION_ID}"
        };

        // Note: Embedded checkout relies more on Stripe Dashboard settings 
        // or JS 'appearance' API for styling rather than extra params, 
        // but you can leave them if supported by your API version.
        
        options.AddExtraParam("branding_settings[display_name]", "Kirilanatur");
        options.AddExtraParam("branding_settings[font_family]", "lato");
        options.AddExtraParam("branding_settings[border_style]", "rectangular");
        options.AddExtraParam("branding_settings[background_color]", "#FDFEFF");
        options.AddExtraParam("branding_settings[button_color]", "#2C2E36");
    
        var sessionService = new SessionService();
        var session = await sessionService.CreateAsync(options);
        return Results.Ok(new CheckoutResponse(session.ClientSecret));
    }
}
