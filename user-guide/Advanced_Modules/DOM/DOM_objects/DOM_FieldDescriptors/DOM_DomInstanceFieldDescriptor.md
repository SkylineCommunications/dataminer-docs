---
uid: DOM_DomInstanceFieldDescriptor
---

# DomInstanceFieldDescriptor

- **FieldValue type**: `GUID` of a `DOMInstance`
- **Multiple values supported**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| DOMInstance | Guid | Guid |
| DOMInstance with multiple values enabled| List\<Guid\> | Guid (ListValueWrapper) |

Available from DataMiner 10.1.10/10.2.0 onwards. Can be used to define that a field should contain the `GUID` of a `DomInstance`. This `DomInstance` can exist in a different DOM manager. This is why the descriptor has a `ModuleId` property that defines where the instances can be found. There is also a `DomDefinitionIds` list property that can be used to define whether `DomInstances` should be linked to the defined definitions. Both properties are intended for UIs, and their validity and existence is not checked server-side. The selected `DomInstance` is saved as their `GUID`.

```csharp
var descriptor = new DomInstanceFieldDescriptor(domManagerModuleId)
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "DomInstanceFieldDescriptor",
    DomDefinitionIds = { domDefinitionGUID },
    FieldType = typeof(Guid)
};
```
To enable multiple values, set the `FieldType` to `List<Guid>`.