---
uid: DOM_StaticTextFieldDescriptor
---

# StaticTextFieldDescriptor

- **FieldValue type**: string
- **Multiple values supported**: :heavy_multiplication_x:
- **Available since**: DataMiner 10.1.2/10.2.0

Defines a field that should always have the same static value, defined by the `StaticText` property. This field is read-only and can not be edited using the form component, changing the text can only be done by changing the value of the `StaticText` property on the FieldDescriptor.

```csharp
var descriptor = new StaticTextFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    StaticText = "Some Static Text",
    Name = "StaticTextFieldDescriptor"
};
```
