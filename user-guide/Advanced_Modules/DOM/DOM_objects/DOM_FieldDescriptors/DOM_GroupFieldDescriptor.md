---
uid: DOM_GroupFieldDescriptor
---

# GroupFieldDescriptor

- **FieldValue type**: string
- **Multiple values supported**: :heavy_multiplication_x:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| Group | string | string |

Available from DataMiner 10.3.3/10.4.0 onwards. Can be used to define that a field should contain the name of a DataMiner user group. The selected group is saved as a string.

```csharp
var descriptor = new GroupFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "GroupFieldDescriptor",
    FieldType = typeof(string)
};
```