using Stripe;

namespace Kirilanatur.Setup;

public static class StripeSetup
{
    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder SetupStripe()
        {
            var stripeSecretKey = builder.Configuration.GetValue<string>("stripe-secret-key");
            StripeConfiguration.ApiKey = stripeSecretKey;
            
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<ChargeService>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<ProductService>();
            return builder;
        }
    }
}
