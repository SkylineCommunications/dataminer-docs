---
metadata_version: 1
uid: DMSScript.Interactivity
description: "Declare whether an automation script is interactive so DataMiner can use deterministic interactivity handling at runtime."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
applies_to:
  - DataMiner
version: 10.5.9
owner: unknown
---

# Interactivity element

Specifies if the script requires user interaction.

## Type

[InteractivityOptions](xref:Automation-InteractivityOptions)

## Parent

[DMSScript](xref:DMSScript)

## Remarks

Available from DataMiner 10.5.9/10.6.0 onwards.<!-- RN 42954 -->

When this element is omitted, or when it is set to "Auto", DataMiner uses automatic detection. Setting an explicit value is recommended when the script's interactive behavior must be deterministic.

## Example

```xml
<DMSScript xmlns="http://www.skyline.be/automation" options="1">
   <Interactivity>Always</Interactivity>
</DMSScript>
```

## Failure and edge cases

This element is available from DataMiner 10.5.9/10.6.0 onwards. On older versions, keep the script compatible with the behavior available in that version. Use `Auto` only when automatic detection is acceptable for the script.

## Related concepts

- [InteractivityOptions](xref:Automation-InteractivityOptions)
- [Getting started with automation script development](xref:GettingStartedWithAutomationScriptDevelopment)
- [Interactive Automation Script Toolkit](xref:Interactive_Automation_Script_Toolkit)

## Authoritative references

- [DMSScript element](xref:DMSScript)
- [Automation scripts: New Interactivity tag](xref:General_Main_Release_10.6.0_new_features#automation-scripts-new-interactivity-tag-id-42954)
