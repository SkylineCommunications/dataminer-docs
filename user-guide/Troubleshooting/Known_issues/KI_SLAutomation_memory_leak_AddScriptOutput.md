---
uid: KI_SLAutomation_memory_leak_AddScriptOutput
---

# SLAutomation memory leak when Engine.AddScriptOutput is used

## Affected versions

- DataMiner 10.1.0 and 10.2.0 (up to [CU10])
- From DataMiner 10.0.2 up to 10.3.1

## Cause

When the script output feature is used in an Automation script or subscript, the data that is placed in the dictionary stays in memory, causing a memory leak in SLAutomation.

## Fix

Install DataMiner 10.2.0 [CU11], 10.3.0, or 10.3.2.

## Issue description

When the script output feature ([RN 23936](xref:General_Main_Release_10.1.0_new_features_5#possibility-to-add-update-or-clear-the-script-output-id_23936)) is used in an Automation script or subscript ([RN 33306](xref:General_Feature_Release_10.2.7#new-subscript-option-extendederrorinfo-id_33306)), the memory usage of the SLAutomation process keeps increasing.
