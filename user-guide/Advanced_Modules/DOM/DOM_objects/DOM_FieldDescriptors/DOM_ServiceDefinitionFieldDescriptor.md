---
uid: DOM_ServiceDefinitionFieldDescriptor
---

# ServiceDefinitionFieldDescriptor

- **FieldValue type**: `Guid` of an SRM Resource
- **Multiple values supported**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| ServiceDefinition | Guid | Guid |
| ServiceDefinition with multiple values enabled| List\<Guid\> | Guid (ListValueWrapper) |

Defines a field that has the `Guid` of an SRM `ServiceDefinition`. It contains a `ServiceDefinitionFilter` property that has a `FilterElement` that can be used to determine which `ServiceDefinitions` will be presented to the user.

The `ServiceDefinitionFieldDescriptor` lists all `ServiceDefinitions` that match the defined `ServiceDefinitionFilter`, the `Guid` of the selected `ServiceDefinition` is saved.

To enable multiple values, set the `FieldType` to `List<Guid>`.

```csharp
var descriptor = new ServiceDefinitionFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "ServiceDefinitionFieldDescriptor",
    ServiceDefinitionFilter = ServiceDefinitionExposers.Name.Contains("example"),
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

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, GuidOfServiceDefinition); // type should be Guid

// example with multiple values enabled 
instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, new ListValueWrapper<Guid>(Guid1, Guid2));
```