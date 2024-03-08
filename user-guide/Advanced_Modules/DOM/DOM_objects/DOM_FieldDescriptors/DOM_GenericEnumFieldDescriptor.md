---
uid: DOM_GenericEnumFieldDescriptor
---

# GenericEnumFieldDescriptor

- **FieldValue type**: int / string
- **Multiple values optional**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| Int Enum | GenericEnum\<int\> | int |
| Int Enum with multiple values enabled| List<GenericEnum\<int\>> | int (ListValueWrapper) |
| String Enum | GenericEnum\<string\> | string |
| String Enum with multiple values enabled | List<GenericEnum\<string\>> | string (ListValueWrapper) |

Defines a field that has a list of possible pre-determined values.

The `GenericEnumFieldDescriptor` is defined by the `GenericEnum` and its entries. The `GenericEnum` can be of the int or string type. This type decides what underlying value the display values has. The selected `GenericEnumEntry` is saved as their value.

```csharp
var genericEnum = new GenericEnum<int>();
genericEnum.AddEntry("Option1", 1);
genericEnum.AddEntry("Option2", 2);
genericEnum.AddEntry("Option3", 3, true);    // true = entry is set to hidden

var descriptor = new GenericEnumFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "IntGenericEnumFieldDescriptor",
    GenericEnumInstance = genericEnum,
    FieldType = typeof(GenericEnum<int>)
};
```

To enable multiple values, set the `FieldType` to `List<GenericEnum<int>>`.