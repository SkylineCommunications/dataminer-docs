---
uid: Automation-InteractivityOptions
---

# InteractivityOptions simple type

Defines the interactivity options for an Automation script.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|Auto|Default option. In the background, the script will be read to try to find out if interactivity is needed, it's advised to set an explicit value Never, Optional, Always, see [How Auto-detection determines interactivity](#how-auto-detection-determines-interactivity) for more details. This behavior is the same as in DataMiner versions prior to 10.5.9/10.6.0, where the [Interactivity](xref:DMSScript.Interactivity) tag is not yet supported. |
|&nbsp;&nbsp;Enumeration|Never|The script will never be interactive. It will not show any UI elements.|
|&nbsp;&nbsp;Enumeration|Optional|The script will be interactive if it needs to be. It will show UI elements if needed.|
|&nbsp;&nbsp;Enumeration|Always|The script will always be interactive. It will always show UI elements.|

## Remarks

Available from DataMiner 10.5.9/10.6.0 onwards.<!-- RN 42954 -->

Setting a value different from "Auto" will replace the [options](xref:DMSScript-options) auto-detection mechanism for options "RequireInteractive" and "HasFindInteractiveClient":

- Setting "Optional" will enable the option flag "HasFindInteractiveClient".

- Setting "Always" will enable the option flag "RequireInteractive". This is the preferred option when Automation scripts are used in an [IAS component](xref:InteractiveAutomationScript) in low-code apps.

## How Auto-detection determines interactivity

> [!IMPORTANT]
> - Because the mechanism needs to read the entire script code, it should be avoided and an explicit interactivity value should be set.

When Interactivity is set to Auto, DataMiner inspects the script and automatically sets or unsets the following options:

- **HasFindInteractiveClient**: Set when any c# code block contains the string ".FindInteractiveClient(" or contains a block of type "Find interactive client".

- **RequireInteractive**: Set when any c# code block contains the strings: ".ShowUI(", ".RunClientProgram(" or ".ShowProgress(" or contains a block of type "User interaction" and does not contain the strings ".FindInteractiveClient(" and "engine.IsInteractive".

If these conditions are not met, the corresponding option flag is automatically cleared.

> [!NOTE]
> - The detection is based on simple string matching within the C# code, not semantic code analysis; i.e., if code is commented out, it will still be detected.
> - If the conditions are not met, the corresponding option flags will be automatically **cleared** (removed) if they were previously set.
> - The string searches are case-sensitive and look for exact matches.
> - Setting an explicit value helps to ensure that the desired interactivity behavior is enforced without reliance on string detection.
> - Prior to DataMiner version 10.5.9/10.6.0, the [Interactivity](xref:DMSScript.Interactivity) tag is not yet supported, so this behavior always applies. 