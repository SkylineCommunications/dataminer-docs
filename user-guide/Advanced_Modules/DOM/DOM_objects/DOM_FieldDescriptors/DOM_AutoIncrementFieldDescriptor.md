---
uid: DOM_AutoIncrementFieldDescriptor
---

# AutoIncrementFieldDescriptor

- **FieldValue type**: string
- **Multiple values supported**: :heavy_multiplication_x:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| AutoIncrement | string | string |

Defines a field that will automatically get an incremented value assigned. When a DomInstance does not have a value for this field yet, it will get assigned the next time the instance is updated.

The `IDFormat` property is used to define a string format for the number value. In this string, "{0}" gets replaced by that number value. If the `IDFormat` property is empty, its value will not be formatted.

When the field is marked as soft-deleted, no values will get assigned when a `DomInstance` gets saved.

Some examples, assuming the next value is 10:

| Description | Format | Result |
|---|---|---|
| Add a prefix and postfix | Pre-{0}-Post | Pre-10-Post |
| Prefix with "REF-" and [format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings) the value | REF-{0:000000} | REF-000010 |
| When no format is set, the value is stored | | 10 |

```csharp
var incrementHelper = new IncrementManagerHelper(_engine.SendSLNetMessages);
var incrementer = incrementHelper.AutoIncrementers.Create(new AutoIncrementer());

return new AutoIncrementFieldDescriptor()
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "AutoIncrementFieldDescriptor",
    AutoIncrementerID = incrementer.ID,
    IDFormat = "Prefix_{0}_Suffix",
    FieldType = typeof(string)
};
```