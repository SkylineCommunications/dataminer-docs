---
uid: SDM_Abstractions_1.0.3
---

# SDM Abstractions 1.0.3

## New features

### Equal and NotEqual filters for nullable fields [ID 45943]

You can now use `Equal` and `NotEqual` filters directly on nullable value-type exposed fields, in addition to the existing `HasValue` filter.

These filters compare against a concrete, non-null value. Null comparisons remain the responsibility of the `HasValue` filter. Fields without a value are therefore correctly treated as not matching the specified comparison value, which avoids false positives when filtering collections containing `null` entries.

## Fixes

### Dynamic filters on nullable fields no longer fail [ID 45942]

Previously, dynamic filters could not be built correctly for nullable value-type fields such as `int?`, `bool?`, or `enum?`. As a result, comparisons against a value could throw errors or produce incorrect results.

Dynamic filter creation now correctly resolves the comparison logic for nullable fields instead of falling back to non-nullable handling.
