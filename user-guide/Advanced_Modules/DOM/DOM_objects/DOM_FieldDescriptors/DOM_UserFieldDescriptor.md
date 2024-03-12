---
uid: DOM_UserFieldDescriptor
---

# UserFieldDescriptor

- **FieldValue type**: string
- **Multiple values supported**: :heavy_multiplication_x:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| User | string | string |

Available from DataMiner 10.3.3/10.4.0 onwards. Can be used to define that a field should contain the name of a DataMiner user. There is a `GroupNames` property that can be used to define which groups the user can be a part of. The selected user is saved as a string.

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

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, nameOfUser); // type should be string
```