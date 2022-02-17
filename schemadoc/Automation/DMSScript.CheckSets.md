---
uid: DMSScript.CheckSets
---

# CheckSets element

Specifies whether to check sets.

## Type

[EnumTrueFalse](xref:Automation-EnumTrueFalse)

## Parent

[DMSScript](xref:DMSScript)

## Remarks

Determines whether, when a script performs a parameter update, it will wait for a return value indicating whether or not the update was successful. This corresponds with the DataMiner Cube script execution option After executing a SET command, check if the read parameter or property has been set to the new value. By default, this is set to true.

This also applies for property value updates from DataMiner 10.0.5 onwards (RN 25025).

> [!NOTE]
> Note that this check causes an average delay of 50 ms. In case many property sets have to be executed and they are not immediately retrieved, we therefore recommend to disable this option.
