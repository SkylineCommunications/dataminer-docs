---
uid: DOM_ElementFieldDescriptor
---

# ElementFieldDescriptor

- **FieldValue type**: `GUID` of an `Element`
- **Multiple values supported**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| Element | string | string |
| Element with multiple values enabled| List\<string\> | string (ListValueWrapper) |

Available from DataMiner 10.1.10/10.2.0 onwards. Can be used to define that a field should contain the `ID` of an `Element`. The `ID` must be saved as a string according to the common [DMA ID]/[ELEMENT ID] format (e.g. "868/65874"). There is a `ViewIds` list property that can be used to define whether the `Elements` should be in any of these `Views`. The selected `Element` is saved as a string.

```csharp
var descriptor = new ElementFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "ElementFieldDescriptor",
    ViewIds = { viewId1, viewId2 },
    FieldType = typeof(string)
};
```
To enable multiple values, set the `FieldType` to `List<string>`.