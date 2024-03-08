---
uid: DOM_DomInstanceValueFieldDescriptor
---

# DomInstanceValueFieldDescriptor

- **FieldValue type**: `GUID` of a `DomInstanceValue`
- **Multiple values supported**: :heavy_multiplication_x:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| DomInstanceValue | Guid | Guid |

Available from DataMiner 10.2.3/10.3.0 onwards. Can be used to define that a field should contain the `GUID` of a `DomInstance`. However, compared to the `DomInstanceFieldDescriptor`, this one also references a specific value of that `DomInstance`. The configuration is the same as the other descriptor, but it adds the `FieldDescriptorId` property that references a specific `FieldValue`. The selected `DomInstanceValue` is saved as their `GUID`.

```csharp
var descriptor = new DomInstanceValueFieldDescriptor(domManagerModuleId, fieldDescriptorId)
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "DomInstanceValueFieldDescriptor",
    DomDefinitionIds = { domDefinitionGUID },
    FieldType = typeof(Guid)
};
```