---
uid: DMSScript.Interactivity
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
