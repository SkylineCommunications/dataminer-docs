---
uid: DOM_DomInstanceValueFieldDescriptor
---

# DomInstanceValueFieldDescriptor

- **FieldValue type**: Guid
- **FieldValue example**: 9ba9aa93-8208-4404-9778-6a9343ba8483 (ID of a `DomInstance`)
- **Multiple values supported**: :heavy_check_mark: (since DataMiner 10.2.5/10.3.0 - server only)<!-- RN 32904 -->
- **Available since**: DataMiner 10.2.3/10.3.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single `DomInstance` value | Guid | Guid |

Defines a DOM field that references a `DomInstance` by storing the ID of that instance in the form of a `Guid`. Compared to the [`DomInstanceFieldDescriptor`](xref:DOM_DomInstanceFieldDescriptor), this descriptor also references a specific value of that `DomInstance`. The configuration is the same as that of the [`DomInstanceFieldDescriptor`](xref:DOM_DomInstanceFieldDescriptor), but it adds the `FieldDescriptorId` property that references a specific `FieldValue`. This way, the DOM low-code app form will show the specified value of the `DomInstance` alongside the name in the dropdown.

## Defining the FieldDescriptor

```csharp
var descriptor = new DomInstanceValueFieldDescriptor("my_referenced_module", fieldDescriptorId)
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My DOM value reference field",
    FieldType = typeof(Guid),
    DomDefinitionIds = { domDefinitionId } // Optional
};
```

## Adding a value for the FieldDescriptor

```csharp
var instance = new DomInstance 
{        
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

var instanceId = Guid.Parse("8000971e-982a-2151-10a2-1803aa100359");
instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, instanceId);
```
