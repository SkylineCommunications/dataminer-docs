---
uid: DOM_ElementFieldDescriptor
---

# ElementFieldDescriptor

- **FieldValue type**: string
- **FieldValue example**: "21569/987" (\<DMA ID\>/\<Element ID\>)
- **Multiple values supported**: :heavy_check_mark: (since DataMiner 10.2.3/10.3.0)
- **Available since**: DataMiner 10.1.10/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single DataMiner element | string | string |
| References one or more DataMiner elements | List\<string\> | string (ListValueWrapper) |

Defines a DOM field that references a DataMiner element by storing the ID of that element in the form of a `string`. The ID must be saved in the `<DMA ID>/<Element ID>` format (e.g. "21569/987"). The `ViewIds` property can be used to define whether the elements should be in any of the defined views. The validity and existence of these views are not checked server-side. These will only be used in the DOM low-code app form to determine the elements that will be shown in the dropdown.

## Defining the FieldDescriptor

To enable multiple values, set the `FieldType` to `List<string>`.

```csharp
var descriptor = new ElementFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My element reference field",
    FieldType = typeof(string),
    ViewIds = { 5405, 6401 } // Optional
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
var elementId = "21569/987";
instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, elementId);

// Multiple values
var firstElementId = "21569/1205";
var secondElementId = "21569/1680";
instance.AddOrUpdateListFieldValue(sectionDefinitionId, fieldDescriptorId, new List<string> { firstElementId, secondElementId });
```
