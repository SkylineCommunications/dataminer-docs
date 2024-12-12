---
uid: Protocol.Params.Param-save
---

# save attribute

Specifies whether the parameter has to be saved each time its value changes.

> [!IMPORTANT]
> To make sure your on-premises databases remain in good shape and do not get cluttered with unnecessary data, or to ensure a cost-efficient solution in case you make use of Storage as a Service, it is important to avoid storing unnecessary data. As a consequence, parameters must only be saved when this is really necessary. See [saving parameters](xref:Saving_parameters).

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Default value: false.

> [!NOTE]
> Only applicable for standalone parameters. For column parameters, refer to the "save" option in the [options](xref:ColumnOptionOptionsOverview#save) attribute.

## Examples

```xml
<Param id="1" save="true">
```
