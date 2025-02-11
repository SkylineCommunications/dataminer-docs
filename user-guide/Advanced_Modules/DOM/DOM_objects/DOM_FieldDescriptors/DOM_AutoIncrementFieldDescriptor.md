---
uid: DOM_AutoIncrementFieldDescriptor
---

# AutoIncrementFieldDescriptor

- **FieldValue type**: string
- **FieldValue example**: "MY_ID_154687"
- **Multiple values supported**: :heavy_multiplication_x:
- **Available since**: DataMiner 10.1.2/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| Generates a unique incrementing integer with formatting options | string | string |

Defines a DOM field that will automatically get an incremented value assigned. When a `DomInstance` does not have a value for this field yet, one will be assigned the next time the instance is updated. The `IDFormat` property is used to define a string format for the number value. In this string, "{0}" gets replaced by that number value. If the `IDFormat` property is empty, its value will not be formatted. When the field is marked as soft-deleted, no values will get assigned when a `DomInstance` gets saved.

Some examples, assuming the next value is 10:

| Description | Format | Result |
|---|---|---|
| Add a prefix and postfix | Pre-{0}-Post | Pre-10-Post |
| Prefix with "REF-" and [format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings) the value | REF-{0:000000} | REF-000010 |
| When no format is set, the value is stored | | 10 |

This descriptor type uses the `IncrementManager` to generate the next number. This manager ensures that there are no duplicate numbers across the DMS. As shown in the example below, you have the option to manually create a new incrementer, allowing you to customize the current number via the "Value" property. Manually creating the incrementer is not mandatory. When you assign a random `Guid` value to the `AutoIncrementerID` property, a new incrementer will be created when a value needs to be generated.

> [!IMPORTANT]
>
> - Using the `AutoIncrementFieldDescriptor` may affect performance when creating `DomInstances` because the incrementing system needs to synchronize with other Agents in the cluster. When high-performance create actions are required, we advise against using this `FieldDescriptor` type.
> - Because of the inherent challenges of distributed computing, incrementing numbers are calculated on a "best effort" basis across multiple systems. While the system is designed to minimize the possibility of duplicates, complete uniqueness cannot be guaranteed in all scenarios. Under conditions such as significant database issues or frequent disconnections of DataMiner Agents, there is a very small chance that duplicate numbers could occur. For critical applications where uniqueness is essential, we recommend using and storing a non-incrementing identifier, such as a GUID. The ID of the `DomInstance` could serve this purpose.

## Defining the FieldDescriptor

```csharp
var incrementHelper = new IncrementManagerHelper(_engine.SendSLNetMessages);
var incrementer = incrementHelper.AutoIncrementers.Create(new AutoIncrementer());

var descriptor = new AutoIncrementFieldDescriptor()
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My ID field",
    FieldType = typeof(string),
    AutoIncrementerID = incrementer.ID,
    IDFormat = "Prefix_{0}_Suffix", // Optional
};
```

## Adding a value for the FieldDescriptor

No value needs to be provided. A value will automatically be added to each section.
