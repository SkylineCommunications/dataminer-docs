---
uid: Protocol.Params.Param.Display.Units
---

# Units element

Specifies a unit for a parameter value displayed in the user interface (e.g., in a report, in the Alarm Console, etc.).

## Type

Contains a unit of measurement.

In the table below, you can find a list of the suggested units to use. These are the units of measurement recognized by the validator in DIS. However, you can also use units that are not mentioned in this list if necessary. For example, a string like "Batteries" can be used to show the number of batteries attached to a backup power supply.

For an overview of all the available units, refer to [Units overview](https://skylinecommunications.github.io/Skyline.DataMiner.XmlSchemas/uom.html).

In case you have a suggestion for a unit to be added to the list below, create a pull request on the [XML Schemas](https://github.com/SkylineCommunications/Skyline.DataMiner.XmlSchemas/) repository. For more information on how to add units, refer to [How to add units](https://github.com/SkylineCommunications/Skyline.DataMiner.XmlSchemas/tree/main/Protocol#how-to-add-units).

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Examples

```xml
<Units>dBm</Units>
```
