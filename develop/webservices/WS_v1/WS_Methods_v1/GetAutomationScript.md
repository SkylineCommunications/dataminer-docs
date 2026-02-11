---
uid: GetAutomationScript
---

# GetAutomationScript

Use this method to retrieve an automation script.

> [!NOTE]
> From DataMiner 10.5.0 [CU11]/10.6.2 onwards<!--RN 44232-->, this method requires either the user permission [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute) or the user permission [Modules > Automation > UI Available](xref:DataMiner_user_permissions#modules--automation--ui-available). In earlier DataMiner versions, both permissions are required.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| scriptName | String | The name of the automation script.                   |

## Output

| Item | Format | Description |
|--|--|--|
| GetAutomationScriptResult | [DMAAutomationScript](xref:DMAAutomationScript) | The information of the requested Automation script. |
