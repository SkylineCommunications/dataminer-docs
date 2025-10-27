---
uid: DOM_StaticTextFieldDescriptor
---

# StaticTextFieldDescriptor

- **FieldValue type**: string
- **FieldValue example**: N/A
- **Multiple values supported**: :heavy_multiplication_x:
- **Available since**: DataMiner 10.1.2/10.2.0

Defines a DOM field that should always have a static value, defined by the `StaticText` property. This field is read-only and cannot be edited using the form component. Changing the text can only be done by changing the value of the `StaticText` property on the descriptor. No value will be stored on the `DomInstance`.

## Defining the FieldDescriptor

```csharp
var descriptor = new StaticTextFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My static text field",
    FieldType = typeof(string),
    StaticText = "Some Static Text"
};
```

## Adding a value for the FieldDescriptor

No value needs to be provided. None is stored for this descriptor type.
