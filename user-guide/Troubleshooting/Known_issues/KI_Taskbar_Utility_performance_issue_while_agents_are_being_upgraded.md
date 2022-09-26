---
uid: KI_Taskbar_Utility_performance_issue_while_agents_are_being_upgraded
---

# Taskbar Utility performance issue while Agents are being upgraded

## Affected versions

- Main release versions 10.1.0 [CU19] and 10.2.0 [CU7]
- Feature release version 10.2.10

## Cause

The DataMiner Taskbar Utility was using too much memory when Agents were being upgraded.

## Fix

Stay on the upgrade summary tab until the upgrade has finished. Then close DataMiner Taskbar Utility to have the memory cleared.

## Issue description

After you have launched an upgrade, the upgrade process shown in DataMiner Taskbar Utility seems to lag behind. Also, DataMiner Taskbar Utility is using a considerable amount of memory.

> [!IMPORTANT]
> The upgrade process itself is not affected.
