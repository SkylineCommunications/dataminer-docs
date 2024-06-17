---
uid: Protocol.Params.Param-saveInterval
---

# saveInterval attribute

Specifies that only one save operation must be executed per interval.

> [!CAUTION]
> Be careful with the use of this feature, as it is still undergoing improvements. The specified interval is not yet functional, and save operations are currently only executed when the element is restarted.

## Content Type

duration

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Specifies that only one save operation must be executed per interval.

For this attribute to have any effect, the parameter must be saved. For standalone parameters, this is configurable through the save attribute. For column parameters, this is configured by specifying the save option for this column on the table parameter.

If you specify a saveInterval attribute, the database will only allow one save operation per interval. Intermediate value updates will not be saved.

When the DMA or the element is stopped, a save operation will be executed to save the value to the database.

The specified value must be a positive duration expressed in the format defined by ISO 8601, for example:

P0Y0M1DT1H20M0S = P1DT1H20M = 1 day, 1 hour and 20 minutes.

For more information about this format, refer to [https://www.w3.org/TR/xmlschema11-2/#duration](https://www.w3.org/TR/xmlschema11-2/#duration).

*Feature introduced in DataMiner 9.5.7 (RN 16708).*

## Examples

The following example parameter is configured to save its value every 20 seconds.

```xml
<Param id="1" trending="true" save="true" saveInterval="PT20S ">
```
