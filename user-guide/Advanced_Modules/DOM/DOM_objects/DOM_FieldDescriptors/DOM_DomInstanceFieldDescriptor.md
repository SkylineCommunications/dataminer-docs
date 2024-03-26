---
uid: DOM_DomInstanceFieldDescriptor
---

# DomInstanceFieldDescriptor

- **FieldValue type**: `Guid`
- **Multiple values supported**: :heavy_check_mark:
- **Available since**: DataMiner 10.1.10/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single `DomInstance` | Guid | Guid |
| References one or more `DomInstances` | List\<Guid\> | Guid (ListValueWrapper) |

Can be used to define that a field should contain the ID of a `DomInstance` in the form of a `Guid`. This `DomInstance` can exist in a different DOM manager. This is why the descriptor has a `ModuleId` property that defines where the instances can be found. There is also a `DomDefinitionIds` list property that can be used to define whether `DomInstances` should be linked to the defined definitions. Both properties are intended for UIs, and their validity and existence is not checked server-side. The configuration is similar to the [`DomInstanceValueFieldDescriptor`](xref:DOM_DomInstanceValueFieldDescriptor).

To enable multiple values, set the `FieldType` to `List<Guid>`.

```csharp
var descriptor = new DomInstanceFieldDescriptor(domManagerModuleId)
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "DomInstanceFieldDescriptor",
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

var instanceId = Guid.Parse("8000971e-982a-2151-10a2-1803aa100359");

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, instanceId); // type should be Guid

var firstInstanceId = Guid.Parse("755a424e-783f-466d-981e-8359fd0ca426");
var secondInstanceId = Guid.Parse("16da2b5d-6b43-4267-96ba-4abd5c16ee2b");

// Example with multiple values enabled 
instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, new ListValueWrapper<Guid>(firstInstanceId, secondInstanceId));
```