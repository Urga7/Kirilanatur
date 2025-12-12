using System.Runtime.Serialization;

namespace Kirilanatur.Core.Domain.External.Stripe;

[DataContract]
public class StripeKeys
{
    [DataMember]
    public string SecretKey { get; init; } = "";

    [DataMember]
    public string PublishableKey { get; init; } = "";
}
