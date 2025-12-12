using Kirilanatur.Core.Domain.External.Stripe;
using Stripe;

namespace Kirilanatur.Setup;

public static class StripeSetup
{
    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder SetupStripe()
        {
            var stripeKeys = new StripeKeys();
            builder.Configuration.GetSection("StripeKeys").Bind(stripeKeys);
            builder.Services.AddSingleton(stripeKeys);
            
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<ChargeService>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<ProductService>();
            return builder;
        }
    }
}
