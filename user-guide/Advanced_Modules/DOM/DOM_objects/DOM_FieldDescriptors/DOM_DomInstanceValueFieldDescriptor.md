---
uid: DOM_DomInstanceValueFieldDescriptor
---

# DomInstanceValueFieldDescriptor

- **FieldValue type**: `Guid`
- **Multiple values supported**: :heavy_multiplication_x:
- **Available since**: DataMiner 10.2.3/10.3.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single `DomInstanceValue` | Guid | Guid |

Can be used to define that a field should contain the `Guid` of a `DomInstance`. However, compared to the [`DomInstanceFieldDescriptor`](xref:DOM_DomInstanceFieldDescriptor), this one also references a specific value of that `DomInstance`. The configuration is the same as the [`DomInstanceFieldDescriptor`](xref:DOM_DomInstanceFieldDescriptor), but it adds the `FieldDescriptorId` property that references a specific `FieldValue`.

```csharp
var descriptor = new DomInstanceValueFieldDescriptor(domManagerModuleId, fieldDescriptorId)
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "DomInstanceValueFieldDescriptor",
    DomDefinitionIds = { domDefinitionId },
    FieldType = typeof(Guid)
};
```

Assigning a `FieldValue` to the `FieldDescriptor` of a new `DomInstance`:

```csharp
var instance = new DomInstance 
{        
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

var instanceValueId = Guid.Parse("8000971e-982a-2151-10a2-1803aa100359");

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, instanceValueId);
```