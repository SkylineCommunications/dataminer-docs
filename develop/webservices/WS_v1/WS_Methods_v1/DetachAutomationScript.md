---
uid: DetachAutomationScript
---

# DetachAutomationScript

Use this method to abort an interactive Automation script.

> [!NOTE]
> From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards, to abort an interactive Automation script, you need the user permission [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute)<!--RN 38529-->. Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4, to abort an interactive Automation script, you need the user permissions [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute) and [Modules > Automation > UI Available](xref:DataMiner_user_permissions#modules--automation--ui-available).

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| scriptID   | Integer | The ID of the automation script.                     |

## Output

None.
