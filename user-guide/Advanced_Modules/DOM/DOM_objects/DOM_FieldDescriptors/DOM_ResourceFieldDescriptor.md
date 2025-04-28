---
uid: DOM_ResourceFieldDescriptor
---

# ResourceFieldDescriptor

- **FieldValue type**: Guid
- **FieldValue example**: a0623201-c157-478c-a880-d40422c40f1c (ID of an [SRM resource](xref:srm_instantiations#virtual-function-resource))
- **Multiple values supported**: :heavy_check_mark: (since DataMiner 10.2.3/10.3.0)
- **Available since**: DataMiner 10.1.2/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single SRM resource | Guid | Guid |
| References one or more SRM resources | List\<Guid\> | Guid (ListValueWrapper) |

Defines a DOM field that references an SRM resource by storing the ID of that resource in the form of a `Guid`. Using the `ResourcePoolIds` property, it is possible to define to which resource pools the resource should belong. If this list is left empty, the dropdown of a DOM low-code app form will display and accept any resource in the DMS. The validity and existence of the resource is not checked server-side. However, when a value is displayed in the DOM low-code app form, it will be marked invalid when the resource does not exist in the DMS or when it is not part of the defined pools.

## Defining the FieldDescriptor

To enable multiple values, set the `FieldType` to `List<Guid>`.

```csharp
var poolIdOne = Guid.Parse("755a424e-783f-466d-981e-8359fd0ca426");
var poolIdTwo = Guid.Parse("16da2b5d-6b43-4267-96ba-4abd5c16ee2b");

var descriptor = new ResourceFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My resource reference field",
    FieldType = typeof(Guid),
    ResourcePoolIds = { poolIdOne, poolIdTwo } // Optional
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
var resourceId = Guid.Parse("8000971e-982a-2151-10a2-1803aa100359");
instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, resourceId);

// Multiple values
var firstResourceId = Guid.Parse("755a424e-783f-466d-981e-8359fd0ca426");
var secondResourceId = Guid.Parse("16da2b5d-6b43-4267-96ba-4abd5c16ee2b");
instance.AddOrUpdateListFieldValue(sectionDefinitionId, fieldDescriptorId, new List<Guid> { firstResourceId, secondResourceId });
```
