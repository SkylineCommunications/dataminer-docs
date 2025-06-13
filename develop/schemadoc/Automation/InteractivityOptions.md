---
uid: Automation-InteractivityOptions
---

# InteractivityOptions simple type

Defines the interactivity options for an Automation script.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|Auto|Default option and old behavior. In the background the script will be read to try to find out if interactivity is needed.|
|&nbsp;&nbsp;Enumeration|Never|The script will never be interactive. This means that the script will not show any UI elements.|
|&nbsp;&nbsp;Enumeration|Optional|The script will be interactive if it needs to be. This means that the script will show UI elements if needed.|
|&nbsp;&nbsp;Enumeration|Always|The script will always be interactive. This means that the script will always show UI elements.|

## Remarks

Setting a value different from "Auto" will replace the [options](xref:DMSScript-options) auto detection mechanism for options "RequireInteractive" and "HasFindInteractiveClient".

Setting "Optional" will make the option flag "HasFindInteractiveClient" to be enabled.

Setting "Always" will make the option flag "RequireInteractive" to be enabled. This is the preferred option when automation scripts are used in an [IAS component](xref:InteractiveAutomationScript) in low code apps.

> [!NOTE]
>
> - This is available from DataMiner version 10.5.8/10.6.0 onwards.