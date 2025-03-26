---
uid: DOM_DomInstanceFieldDescriptor
---

# DomInstanceFieldDescriptor

- **FieldValue type**: Guid
- **FieldValue example**: 9ba9aa93-8208-4404-9778-6a9343ba8483 (ID of a `DomInstance`)
- **Multiple values supported**: :heavy_check_mark:
- **Available since**: DataMiner 10.1.10/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single `DomInstance` | Guid | Guid |
| References one or more `DomInstances` | List\<Guid\> | Guid (ListValueWrapper) |

Defines a DOM field that references a `DomInstance` by storing the ID of that instance in the form of a `Guid`. This `DomInstance` can exist in a different DOM module if you set the `ModuleID` property to the ID of that module. If no `ModuleID` is set, only DOM instances in the same module as the `DomInstanceFieldDescriptor` can be referenced. There is also a `DomDefinitionIds` list property that can be used to define whether `DomInstances` should be linked to the defined definitions. Both properties are intended for UIs, and their validity and existence is not checked server-side. The configuration is similar to the [`DomInstanceValueFieldDescriptor`](xref:DOM_DomInstanceValueFieldDescriptor).

## Defining the FieldDescriptor

To enable multiple values, set the `FieldType` to `List<Guid>`.

```csharp
var descriptor = new DomInstanceFieldDescriptor("my_referenced_module")
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My DOM reference field",
    FieldType = typeof(Guid), 
    DomDefinitionIds = { domDefinitionId } // Optional
};
```

## Adding a value for the FieldDescriptor

```csharp
var instance = new DomInstance
{
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

// Single value
var instanceId = Guid.Parse("8000971e-982a-2151-10a2-1803aa100359");
instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, instanceId);

// Multiple values
var firstInstanceId = Guid.Parse("755a424e-783f-466d-981e-8359fd0ca426");
var secondInstanceId = Guid.Parse("16da2b5d-6b43-4267-96ba-4abd5c16ee2b");
instance.AddOrUpdateListFieldValue(sectionDefinitionId, fieldDescriptorId, new List<Guid> { firstInstanceId, secondInstanceId });
```
