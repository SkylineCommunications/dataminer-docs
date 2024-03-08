---
uid: DOM_ServiceDefinitionFieldDescriptor
---

# ServiceDefinitionFieldDescriptor

- **FieldValue type**: `GUID` of an SRM Resource
- **Multiple values supported**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| ServiceDefinition | Guid | Guid |
| ServiceDefinition with multiple values enabled| List\<Guid\> | Guid (ListValueWrapper) |

Defines a field that has the `GUID` of an SRM `ServiceDefinition`. It contains a `ServiceDefinitionFilter` property that has a `FilterElement` that can be used to determine which service definitions will be presented to the user.

The `ServiceDefinitionFieldDescriptor` lists all `ServiceDefinitions` in the defined `ServiceDefinitionFilter`, the selected `ServiceDefinition` is saved as their `GUID`.

```csharp
var descriptor = new ServiceDefinitionFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "ServiceDefinitionFieldDescriptor",
    ServiceDefinitionFilter = ServiceDefinitionExposers.Name.Contains("example"),
    FieldType = typeof(Guid)
};
```

To enable multiple values, set the `FieldType` to `List<Guid>`.