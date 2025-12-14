using JetBrains.Annotations;

namespace Kirilanatur.Infrastructure.Attributes;

[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class DtoAttribute : Attribute;
