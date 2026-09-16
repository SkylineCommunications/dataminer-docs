---
uid: SDM_Abstractions_1.0.2
---

# SDM Abstractions 1.0.2

## New features

### Filtering on nullable properties [ID 45746]

Support has been added for filtering on nullable properties in the SDM Abstractions filter extension API. Developers who work with optional (nullable) data model fields can now build strongly typed filters that check whether a field is present or absent, and they can compare nullable fields against specific values.

Two new filter methods are available on exposers typed to nullable value types and nullable strings:

- `HasValue()`: Matches objects where the nullable field is not null.
- `HasNoValue()`: Matches objects where the nullable field is null.

Existing comparison methods `LessThan`, `LessThanOrEqual`, `GreaterThan`, and `GreaterThanOrEqual` now also have overloads for nullable value types. When comparing a nullable field, null entries are naturally excluded from results, consistent with standard .NET and SQL behavior. Because related APIs (e.g., repositories) already required the `where TFilter : class` constraint, this change has no practical impact on existing consumer code.

## Fixes

### Incorrect comparers in LessThan and GreaterThan filters [ID 45747]

The `LessThan`, `LessThanOrEqual`, and `GreaterThan` filter extension methods in SDM Abstractions internally used the wrong comparer value (GTE in all three cases). This meant that while in-memory evaluation of these filters was correct, the stored comparer metadata on the resulting `ManagedFilter` did not accurately describe the operation.

The comparers are now correctly set to LT, LTE, and GT respectively, ensuring consistent behavior when the filter is serialized, inspected, or passed to a backend that uses the comparer field.
