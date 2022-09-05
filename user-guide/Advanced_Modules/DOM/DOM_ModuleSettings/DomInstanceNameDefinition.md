---
uid: DomInstanceNameDefinition
---

# DomInstanceNameDefinition

With this setting, you can define how the *Name* property of a [DomInstance](xref:DomInstance) should be filled in automatically every time the instance is saved to DataMiner (with a create or update action).

> [!NOTE]
> This setting is available from DataMiner 10.1.9/10.2.0 onwards.

## Defining a concatenation

The `DomInstanceNameDefinition` class currently contains a simple list of `IDomInstanceConcatenationItems`. With this, you can add concatenation items of different types in a specific order to define your name.

These are the available types:

- **StaticValueConcatenationItem**: Can be used to define a string that should be put into the concatenation. The string value should be assigned to the *Value* property.

- **FieldValueConcatenationItem**: Can be used to add a `FieldValue` (defined in a `DomInstance`) to the concatenation. The `FieldDescriptorID` of the `FieldValue` should be assigned to the *FieldDescriptorId* property. If no `FieldValue` can be found with the given `FieldDescriptorID`, an empty string will be used instead.

  A `FieldValue` can contain various non-string types of data. Keep in mind the following string conversions:

  | FieldValue type | String representation |
  |--|--|
  | GUID | "bc77dcb5-b523-4722-aaaa-7d99a5c82304" |
  | Double | "124.65" |
  | Long/int | "15254876" |
  | DateTime | "1997-04-10T14:40:14.0000000Z" (ISO8601) |
  | TimeSpan | "13:28:18.9187335" |
  | bool | "True" |
  | GenericEnumEntry | "SomeDisplayValue" (the display value will be used) |
  | List\<T> | "SomeValue;SomeValue" (Values separated with semicolons ";") |

## Example

The example below handles information about switches in a network. There are field descriptors for the following data:

- Switch brand
- Switch model
- Management IP
- Year of installation

We want the name of the `DomInstances` representing a switch to contain all this info, for example: "Cisco C9500-24Y4C - 10.11.5.87 (2021)".

The configuration of the `ModuleSettings` would be the following (assuming that the `FieldDescriptorIDs` are already defined somewhere in this script):

```csharp
var settings = new ModuleSettings()
{
    ModuleId = "moduleid",
    DomManagerSettings = new DomManagerSettings()
    {
        DomInstanceNameDefinition = new DomInstanceNameDefinition()
        {
            ConcatenationItems = new List<IDomInstanceConcatenationItem>()
            {
                new FieldValueConcatenationItem(switchBrandDescriptorId),
                new StaticValueConcatenationItem(" "),
                new FieldValueConcatenationItem(switchModelDescriptorId),
                new StaticValueConcatenationItem(" - "),
                new FieldValueConcatenationItem(managementIpDescriptorId),
                new StaticValueConcatenationItem(" ("),
                new FieldValueConcatenationItem(yearDescriptorId),
                new StaticValueConcatenationItem(")")
            }
        }
    }
};
```

## Notes

- When no concatenation is defined (`DomInstanceNameDefinition` is empty or null), the ID of the `DomInstance` will be used as its name.

- When multiple values are defined for the same `FieldDescriptor` (with multiple `Sections` for the same `SectionDefinition`), the first value will be used for the concatenation.

- It is possible to override this setting in a `DomDefinition` with the *ModuleSettingsOverrides* property.
