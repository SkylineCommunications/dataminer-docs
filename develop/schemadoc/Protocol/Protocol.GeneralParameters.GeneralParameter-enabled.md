---
uid: Protocol.GeneralParameters.GeneralParameter-enabled
description: "Use the GeneralParameter enabled attribute in a DataMiner protocol to control whether a general parameter group is loaded."
---

# enabled attribute

When set to false, the specified general parameter group will not be loaded.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[GeneralParameter](xref:Protocol.GeneralParameters.GeneralParameter)

## Remarks

> [!NOTE]
> For protocols that export other protocols (DVEs), the protocols are handled separately. Therefore, you should include the `<GeneralParameters>` tag in the export rules in case you want these to be applied to the DVEs too.
