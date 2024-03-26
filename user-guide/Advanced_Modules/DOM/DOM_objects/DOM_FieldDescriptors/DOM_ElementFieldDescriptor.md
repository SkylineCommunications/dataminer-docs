---
uid: DOM_ElementFieldDescriptor
---

# ElementFieldDescriptor

- **FieldValue type**: string (Example: "686/1245")
- **Multiple values supported**: :heavy_check_mark:
- **Available since**: DataMiner 10.1.10/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single `Element` | string | string |
| References one or more `Elements` | List\<string\> | string (ListValueWrapper) |

Can be used to define that a field should contain the `ID` of an `Element`. The `ID` must be saved as a string according to the common [DMA ID]/[ELEMENT ID] format (e.g. "868/65874"). There is a `ViewIds` list property that can be used to define whether the `Elements` should be in any of these `Views`.

To enable multiple values, set the `FieldType` to `List<string>`.

```csharp
var viewId1 = 5405;
var viewId2 = 6401;

var descriptor = new ElementFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "ElementFieldDescriptor",
    ViewIds = { viewId1, viewId2 },
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

var elementId = "686/1245"

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, elementId); 

var firstElementId = "686/7891";
var secondElementId = "686/3214";

// Example with multiple values enabled 
instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, new ListValueWrapper<string>(firstElementId, secondElementId));
```