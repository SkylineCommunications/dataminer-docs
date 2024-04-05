---
uid: DOM_GroupFieldDescriptor
---

# GroupFieldDescriptor

- **FieldValue type**: string
- **FieldValue example**: "NOC Administrators"
- **Multiple values supported**: :heavy_multiplication_x:
- **Available since**: DataMiner 10.3.3/10.4.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single DataMiner group | string | string |

Defines a DOM field that stores the name of a DataMiner user group in the form of a `string`. The validity and existence of the group is not checked server-side. However, when a value is displayed in the DOM low-code app form, it will be marked invalid when the group does not exist in the DMS.

## Defining the FieldDescriptor

```csharp
var descriptor = new GroupFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My group reference field",
    FieldType = typeof(string)
};
```

## Adding a value for the FieldDescriptor

```csharp
var instance = new DomInstance
{
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, "NOC Operators");
```
