---
uid: Automation-InteractivityOptions
---

# InteractivityOptions simple type

Defines the interactivity options for an automation script.

## Content Type

|Item|Facet value|Description|
|---|---|---|
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|Auto|Default option. In the background, the script will be read to try to find out if interactivity is needed. This behavior is the same as in DataMiner versions prior to 10.5.9/10.6.0, where the [Interactivity](xref:DMSScript.Interactivity) tag is not yet supported. See [How auto-detection determines interactivity](#how-auto-detection-determines-interactivity).|
|&nbsp;&nbsp;Enumeration|Never|The script will never be interactive. It will not show any UI elements.|
|&nbsp;&nbsp;Enumeration|Optional|The script will be interactive if it needs to be. It will show UI elements if needed.|
|&nbsp;&nbsp;Enumeration|Always|The script will always be interactive. It will always show UI elements.|

> [!NOTE]
> Because *Auto* requires reading the entire script, we recommend setting an explicit interactivity value instead (*Never*, *Optional*, or *Always*).

## Remarks

Available from DataMiner 10.5.9/10.6.0 onwards.<!-- RN 42954 -->

Setting a value different from "Auto" will replace the [options](xref:DMSScript-options) auto-detection mechanism for options "RequireInteractive" and "HasFindInteractiveClient":

- Setting "Optional" will enable the option flag "HasFindInteractiveClient".

- Setting "Always" will enable the option flag "RequireInteractive". This is the preferred option when automation scripts are used in an [IAS component](xref:InteractiveAutomationScript) in low-code apps.

## How auto-detection determines interactivity

> [!IMPORTANT]
> Auto-detection requires the entire script code to be read. For this reason, we recommend avoiding this mechanism and setting an explicit interactivity value instead.

When Interactivity is set to *Auto*, DataMiner inspects the script and automatically sets or clears the following options:

- **HasFindInteractiveClient**: Set when any C# code block:

  - Contains the string `.FindInteractiveClient(`, or

  - Contains a block of type *Find interactive client*.

- **RequireInteractive**: Set when any C# code block:

  - Contains any of the strings `.ShowUI(`, `.RunClientProgram(`, or `.ShowProgress(`, or

  - Contains a block of type *User interaction*,

  - And does not contain `.FindInteractiveClient(` or `engine.IsInteractive`.

If these conditions are not met, the corresponding option flag is automatically cleared.

> [!NOTE]
>
> - Detection is based on simple string matching within the C# code, not semantic code analysis. Commented-out code is therefore still detected.
> - String matching is case-sensitive and requires exact matches.
> - Setting an explicit value ensures the desired interactivity behavior without relying on string detection.
> - Prior to DataMiner 10.5.9/10.6.0, the [Interactivity](xref:DMSScript.Interactivity) tag is not supported, so auto-detection always applies.
