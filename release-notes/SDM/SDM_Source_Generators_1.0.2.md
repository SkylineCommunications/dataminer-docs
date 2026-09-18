---
uid: SDM_Source_Generators_1.0.2
---

# SDM Source Generators 1.0.2

## New features

### Nullable properties [ID 45753]

The SDM source generator now recognizes nullable value-type properties (including `int?`, `decimal?`, `DateTime?`, `Guid?`, and any `enum?`) when generating type-safe exposer classes via `[GenerateExposers]`. Previously, properties declared with a nullable type produced no exposer. Now, each nullable property generates a correctly typed `Exposer<TModel, TField?>`, ensuring the full model surface is covered without any manual workarounds.

Take for example this class:

```csharp
[GenerateExposers]
public class Shipment : SdmObject<Shipment>
{
    public DateTime?       DeliveredAt { get; set; }
    public ShipmentStatus? Status      { get; set; }
}
```

This will now result in the following:

```csharp
// Auto-generated
public static class ShipmentExposers
{
    public static readonly Exposer<Shipment, string>          Identifier  = ...;
    public static readonly Exposer<Shipment, DateTime?>       DeliveredAt = ...;
    public static readonly Exposer<Shipment, ShipmentStatus?> Status      = ...;
}
```

All nullable scalar types supported by their non-nullable counterparts are covered, including `bool?`, all numeric types, `DateTime?`, `TimeSpan?`, `Guid?`, and any `enum?`. The DOM repository generator (`[SdmDomStorage]`) has likewise been updated so that nullable properties are correctly wired into the generated CRUD operations and filter mappings.

No changes to existing model classes are required. Rebuilding the consuming project is sufficient for the updated generator to generate the additional exposers.

### Per-project MSBuild opt-out properties for source generators [ID 45863]

Consuming projects can now selectively disable individual SDM source generators through standard MSBuild properties, without removing the NuGet reference entirely. The following opt-out properties are now available in `.csproj` and `Directory.Build.props` files:

- `SdmDisableExposers`: Skips generation of the exposers filter class.
- `SdmDisableMiddleware`: Skips generation of the middleware wrapper.
- `SdmDisableDomStorage`: Skips generation of the DOM repository.

### Exposers now inherit model class access modifier [ID 45890]

Generated exposer classes now inherit the access modifier (`public` or `internal`) of the annotated model class. This prevents generated filter classes from exposing wider visibility than the model they describe.

For example:

```csharp
[GenerateExposers]
public class MyPublicClass {}

[GenerateExposers]
internal class MyInternalClass {}
```

This now results in:

```csharp
public static partial class MyPublicClassExposers {}
internal static partial class MyInternalClassExposers {}
```

## Fixes

### NOT filter stack overflow [ID 45754]

When a `NOTFilterElement` filter was applied through a generated DOM repository, a stack overflow could occur at runtime. The generated `TranslateFullFilter` method incorrectly passed the `NOTFilterElement` wrapper back into itself instead of unwrapping the inner filter first, causing infinite recursion. This has now been fixed, ensuring that the inner filter (`not.original`) is correctly forwarded and NOT-based filter expressions now translate and execute as expected.

This applies to any model using `[SdmDomStorage]` where `NOTFilterElement<T>` was used in a read or query operation. No changes to model or consumer code are required. Rebuilding against the updated generator is sufficient.
