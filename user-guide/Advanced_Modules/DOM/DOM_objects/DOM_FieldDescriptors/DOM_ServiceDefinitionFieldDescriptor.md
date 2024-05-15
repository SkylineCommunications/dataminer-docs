---
uid: DOM_ServiceDefinitionFieldDescriptor
---

# ServiceDefinitionFieldDescriptor

- **FieldValue type**: Guid
- **FieldValue example**: 1bf36345-89df-4ba2-906c-e82bb9ba01cd (ID of an [SRM service definition](xref:srm_definitions#service-definition))
- **Multiple values supported**: :heavy_check_mark: (since DataMiner 10.2.3/10.3.0)
- **Available since**: DataMiner 10.1.2/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single SRM service definition | Guid | Guid |
| References one or more SRM service definitions | List\<Guid\> | Guid (ListValueWrapper) |

Defines a DOM field that references an SRM service definition by storing the ID of that definition in the form of a `Guid`. Using the `ServiceDefinitionFilter` property, it is possible to define which definitions are allowed. If this filter is left empty, the dropdown of a DOM low-code app form will display and accept any definition in the DMS. The validity and existence of the service definition is not checked server-side. However, when a value is displayed in the DOM low-code app form, it will be marked invalid when the definition does not exist in the DMS or is not part of the filtered set of definitions.

## Defining the FieldDescriptor

To enable multiple values, set the `FieldType` to `List<Guid>`.

```csharp
var descriptor = new ServiceDefinitionFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My service definition reference field",
    FieldType = typeof(Guid),
    ServiceDefinitionFilter = ServiceDefinitionExposers.Name.Contains("example") // Optional
};
```

> [!NOTE]
> Requires the `using Skyline.DataMiner.Net.Messages.SLDataGateway;` using directive.

## Adding a value for the FieldDescriptor

```csharp
var instance = new DomInstance
{
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

// Single value
var serviceDefinitionId = Guid.Parse("8000971e-982a-2151-10a2-1803aa100359");
instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, serviceDefinitionId);

// Multiple values
var firstDefinitionId = Guid.Parse("755a424e-783f-466d-981e-8359fd0ca426");
var secondDefinitionId = Guid.Parse("16da2b5d-6b43-4267-96ba-4abd5c16ee2b");
instance.AddOrUpdateListFieldValue(sectionDefinitionId, fieldDescriptorId, new List<Guid> { firstDefinitionId, secondDefinitionId });
```
