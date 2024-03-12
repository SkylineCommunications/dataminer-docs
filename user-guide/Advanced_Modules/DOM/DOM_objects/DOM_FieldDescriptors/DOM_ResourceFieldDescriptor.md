---
uid: DOM_ResourceFieldDescriptor
---

# ResourceFieldDescriptor

- **FieldValue type**: `Guid` of an SRM Resource
- **Multiple values supported**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| Resource | Guid | Guid |
| Resource with multiple values enabled| List\<Guid\> | Guid (ListValueWrapper) |

Defines a field that has the `Guid` of an SRM `Resource`.

The `ResourceFieldDescriptor` lists all `Resources` in the defined `ResourcePools`, leaving the `ResourcePoolIds` property empty will result in showing all resources on the system. The `Guid` of the selected `Resource` is saved.

To enable multiple values, set the `FieldType` to `List<Guid>`.

```csharp
var descriptor = new ResourceFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "ResourceFieldDescriptor",
    ResourcePoolIds = { poolGuid1, poolGuid2 },
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

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, GuidOfResource); // type should be Guid

// example with multiple values enabled 
instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, new ListValueWrapper<Guid>(Guid1, Guid2));
```