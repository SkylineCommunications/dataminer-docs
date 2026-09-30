---
uid: SDM_Abstractions_1.0.5
description: "Learn about the SDM Abstractions 1.0.5 enhancements for filtering System.Type fields with Equal and NotEqual filters."
---

# SDM Abstractions 1.0.5

## New features

### Equal and NotEqual filters for System.Type fields [ID 46541]

You can now use `Equal` and `NotEqual` filters on fields of type `System.Type`.

`FilterElementFactory` now supports `System.Type` fields, including correct handling of null values. You can also apply collection filters to fields containing type values.
