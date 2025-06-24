---
uid: Automation-InteractivityOptions
---

# InteractivityOptions simple type

Defines the interactivity options for an Automation script.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|Auto|Default option. In the background, the script will be read to try to find out if interactivity is needed. This behavior is the same as in DataMiner versions prior to 10.5.9/10.6.0, where the [Interactivity](xref:DMSScript.Interactivity) tag is not yet supported. |
|&nbsp;&nbsp;Enumeration|Never|The script will never be interactive. It will not show any UI elements.|
|&nbsp;&nbsp;Enumeration|Optional|The script will be interactive if it needs to be. It will show UI elements if needed.|
|&nbsp;&nbsp;Enumeration|Always|The script will always be interactive. It will always show UI elements.|

## Remarks

Available from DataMiner 10.5.9/10.6.0 onwards.<!-- RN 42954 -->

Setting a value different from "Auto" will replace the [options](xref:DMSScript-options) auto-detection mechanism for options "RequireInteractive" and "HasFindInteractiveClient":

- Setting "Optional" will enable the option flag "HasFindInteractiveClient".

- Setting "Always" will enable the option flag "RequireInteractive". This is the preferred option when Automation scripts are used in an [IAS component](xref:InteractiveAutomationScript) in low-code apps.
