---
uid: DOM_DomInstanceValueFieldDescriptor
---

# DomInstanceValueFieldDescriptor

- **FieldValue type**: `Guid` of a `DomInstanceValue`
- **Multiple values supported**: :heavy_multiplication_x:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| DomInstanceValue | Guid | Guid |

Available from DataMiner 10.2.3/10.3.0 onwards. Can be used to define that a field should contain the `Guid` of a `DomInstance`. However, compared to the `DomInstanceFieldDescriptor`, this one also references a specific value of that `DomInstance`. The configuration is the same as the `DomInstanceFieldDescriptor`, but it adds the `FieldDescriptorId` property that references a specific `FieldValue`. The `Guid` of the selected `DomInstanceValue` is saved.

```csharp
var descriptor = new DomInstanceValueFieldDescriptor(domManagerModuleId, fieldDescriptorId)
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "DomInstanceValueFieldDescriptor",
    DomDefinitionIds = { domDefinitionGuid },
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

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, GuidOfDomInstanceValue); // type should be Guid
```