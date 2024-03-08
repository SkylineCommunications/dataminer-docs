---
uid: DOM_ResourceFieldDescriptor
---

# ResourceFieldDescriptor

- **FieldValue type**: `GUID` of an SRM Resource
- **Multiple values supported**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| Resource | Guid | Guid |
| Resource with multiple values enabled| List\<Guid\> | Guid (ListValueWrapper) |

Defines a field that has the `GUID` of an SRM `Resource`.

The `ResourceFieldDescriptor` lists all `Resources` in the defined `ResourcePools`, the selected `Resource` is saved as their `GUID`.

```csharp
var descriptor = new ResourceFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "ResourceFieldDescriptor",
    ResourcePoolIds = { poolGuid1, poolGuid2 },
    FieldType = typeof(Guid)
};
```

To enable multiple values, set the `FieldType` to `List<Guid>`.