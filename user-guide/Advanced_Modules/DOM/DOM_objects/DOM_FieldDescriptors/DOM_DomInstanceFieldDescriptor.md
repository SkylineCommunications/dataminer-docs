---
uid: DOM_DomInstanceFieldDescriptor
---

# DomInstanceFieldDescriptor

- **FieldValue type**: `Guid` of a `DOMInstance`
- **Multiple values supported**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| DOMInstance | Guid | Guid |
| DOMInstance with multiple values enabled| List\<Guid\> | Guid (ListValueWrapper) |

Available from DataMiner 10.1.10/10.2.0 onwards. Can be used to define that a field should contain the `Guid` of a `DomInstance`. This `DomInstance` can exist in a different DOM manager. This is why the descriptor has a `ModuleId` property that defines where the instances can be found. There is also a `DomDefinitionIds` list property that can be used to define whether `DomInstances` should be linked to the defined definitions. Both properties are intended for UIs, and their validity and existence is not checked server-side. The `Guid` of the selected `DomInstance` is saved.

To enable multiple values, set the `FieldType` to `List<Guid>`.

```csharp
var descriptor = new DomInstanceFieldDescriptor(domManagerModuleId)
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "DomInstanceFieldDescriptor",
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

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, GuidOfDomInstance); // type should be Guid

// example with multiple values enabled 
instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, new ListValueWrapper<Guid>(Guid1, Guid2));
```