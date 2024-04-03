---
uid: DOM_UserFieldDescriptor
---

# UserFieldDescriptor

- **FieldValue type**: string
- **FieldValue example**: "COMPANY\JohnDO" ('Name' of a DataMiner user)
- **Multiple values supported**: :heavy_multiplication_x:
- **Available since**: DataMiner 10.3.3/10.4.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single DataMiner user | string | string |

Defines a DOM field that stores the name of a DataMiner user in the form of a `string`. The 'Name' field of a DataMiner is saved, while the 'Full Name' field is used as the display value in an LCA form. The `GroupNames` property can be used to define which groups the user should be part of. The validity and existence of the user is not checked server-side. However, when displayed in the DOM LCA form, a value will be marked invalid when the user does not exist in the DMS or is not part of the defined groups.

## Defining the FieldDescriptor

```csharp
var descriptor = new UserFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My user reference field",
    FieldType = typeof(string),
    GroupNames = { "NOC Operators" } // Optional
};
```

## Adding a value for the FieldDescriptor

```csharp
var instance = new DomInstance
{
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

var userName = @"COMPANY\JohnDO";
instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, userName);
```
