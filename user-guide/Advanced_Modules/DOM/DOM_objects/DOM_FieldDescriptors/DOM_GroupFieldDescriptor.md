---
uid: DOM_GroupFieldDescriptor
---

# GroupFieldDescriptor

- **FieldValue type**: string
- **Multiple values supported**: :heavy_multiplication_x:
- **Available since**: DataMiner 10.3.3/10.4.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single `Group` | string | string |

Can be used to define that a field should contain the name of a DataMiner user group.

```csharp
var descriptor = new GroupFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "GroupFieldDescriptor",
    FieldType = typeof(string)
};
```

Assigning a `FieldValue` to the `FieldDescriptor` of a new `DomInstance`:

```csharp
var instance = new DomInstance 
{        
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

var nameOfGroup = "Administrators";

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, nameOfGroup);
```