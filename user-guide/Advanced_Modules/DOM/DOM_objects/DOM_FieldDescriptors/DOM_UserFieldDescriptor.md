---
uid: DOM_UserFieldDescriptor
---

# UserFieldDescriptor

- **FieldValue type**: string
- **Multiple values supported**: :heavy_multiplication_x:
- **Available since**: DataMiner 10.3.3/10.4.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single `User` | string | string |

Can be used to define that a field should contain the name of a DataMiner user. There is a `GroupNames` property that can be used to define which groups the user can be a part of.

```csharp
var descriptor = new UserFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "UserFieldDescriptor",
    FieldType = typeof(string),
};
```

Assigning a `FieldValue` to the `FieldDescriptor` of a new `DomInstance`:

```csharp
var instance = new DomInstance 
{        
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

var nameOfUser = "User1";

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, nameOfUser);
```