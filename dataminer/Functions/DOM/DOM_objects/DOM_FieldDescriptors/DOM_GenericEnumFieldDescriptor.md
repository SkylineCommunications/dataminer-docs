---
uid: DOM_GenericEnumFieldDescriptor
---

# GenericEnumFieldDescriptor

- **FieldValue type**: int / string
- **FieldValue example**: 5 / "very_high"
- **Multiple values supported**: :heavy_check_mark: (since DataMiner 10.4.0/10.4.1)<!-- RN 37482 -->
- **Available since**: DataMiner 10.1.2/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single int enum entry | GenericEnum\<int\> | int |
| References one or more int enum entries | List<GenericEnum\<int\>> | int (ListValueWrapper) |
| References a single string enum entry | GenericEnum\<string\> | string |
| References one or more string enum entries | List<GenericEnum\<string\>> | string (ListValueWrapper) |

Defines a DOM field that stores one or more options from a list of pre-determined discrete values. These possible values are defined by the `GenericEnum` object that is defined on the descriptor. The `GenericEnum` contains `GenericEnumEntry` objects that map a display value to a value, which is either of type `int` or `string`.

It is possible to add additional discrete options after the descriptor was created, but it is not possible to remove or update options that are already in use. If a situation like this would occur, see [Removing an enum entry from a GenericEnumFieldDescriptor](xref:DOM_Remove_Enum_Entry).

However, from DataMiner 10.5.9/10.6.0 onwards<!--RN 43452-->, you can update the display value of an existing enum entry, even if it is already in use by DOM instances. Changing the display value does not affect the underlying enum value or the behavior of existing DOM instances.

## Defining the FieldDescriptor

To enable multiple values, set the `FieldType` to `List<GenericEnum<int>>`.

### Int enum

```csharp
var genericEnum = new GenericEnum<int>();
genericEnum.AddEntry("High", 1);
genericEnum.AddEntry("Medium", 2);
genericEnum.AddEntry("Low", 3, true); // true = entry is set to hidden

var descriptor = new GenericEnumFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My int enum field",
    FieldType = typeof(GenericEnum<int>),
    GenericEnumInstance = genericEnum
};
```

### String enum

```csharp
var genericEnum = new GenericEnum<string>();
genericEnum.AddEntry("High", "sv_h");
genericEnum.AddEntry("Medium", "sv_m");
genericEnum.AddEntry("Low", "sv_l", true); // true = entry is set to hidden

var descriptor = new GenericEnumFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My string enum field",
    FieldType = typeof(GenericEnum<string>),
    GenericEnumInstance = genericEnum
};
```

> [!NOTE]
> Requires the `using Skyline.DataMiner.Net.GenericEnums;` using directive.

## Adding a value for the FieldDescriptor

### Int enum

```csharp
var instance = new DomInstance
{
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

// Single value
instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, 2); // 2 is the value of the entry with displayValue "Medium"

// Multiple values
var firstEnumValue = 1;
var secondEnumValue = 2;
instance.AddOrUpdateListFieldValue(sectionDefinitionId, fieldDescriptorId, new List<int> { firstEnumValue, secondEnumValue });
```

### String enum

```csharp
var instance = new DomInstance
{
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

// Single value
instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, "sv_h"); // "sv_m" is the value of entry with displayValue "High"

// Multiple values
var firstEnumValue = "sv_m";
var secondEnumValue = "sv_l";
instance.AddOrUpdateListFieldValue(sectionDefinitionId, fieldDescriptorId, new List<string> { firstEnumValue, secondEnumValue });
```
