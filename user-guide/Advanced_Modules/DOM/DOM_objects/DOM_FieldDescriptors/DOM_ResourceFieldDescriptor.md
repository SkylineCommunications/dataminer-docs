---
uid: DOM_ResourceFieldDescriptor
---

# ResourceFieldDescriptor

- **FieldValue type**: `Guid`
- **Multiple values supported**: :heavy_check_mark:
- **Available since**: DataMiner 10.1.2/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single `Resource` | Guid | Guid |
| References one or more `Resources` | List\<Guid\> | Guid (ListValueWrapper) |

Defines a field that has the `Guid` of an SRM `Resource`.

The `ResourceFieldDescriptor` lists all `Resources` in the defined `ResourcePools`, leaving the `ResourcePoolIds` property empty will result in showing all resources on the system.

To enable multiple values, set the `FieldType` to `List<Guid>`.

```csharp
var poolGuid1 = Guid.Parse("755a424e-783f-466d-981e-8359fd0ca426");
var poolGuid2 = Guid.Parse("16da2b5d-6b43-4267-96ba-4abd5c16ee2b");

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

var resourceId = Guid.Parse("8000971e-982a-2151-10a2-1803aa100359");

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, resourceId);

var firstResourceId = Guid.Parse("755a424e-783f-466d-981e-8359fd0ca426");
var secondResourceId = Guid.Parse("16da2b5d-6b43-4267-96ba-4abd5c16ee2b");

// Example with multiple values enabled 
instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, new ListValueWrapper<Guid>(firstResourceId, secondResourceId));
```