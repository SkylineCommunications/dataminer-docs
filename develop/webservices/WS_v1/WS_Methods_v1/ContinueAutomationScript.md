---
uid: ContinueAutomationScript
---

# ContinueAutomationScript

Use this method to continue an interactive automation script.

> [!NOTE]
> From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards, to continue an interactive automation script, you need the user permission [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute)<!--RN 38529-->. Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4, to continue an interactive automation script, you need the user permissions [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute) and [Modules > Automation > UI Available](xref:DataMiner_user_permissions#modules--automation--ui-available).

## Input

| Item       | Format          | Description                                           |
|------------|-----------------|-------------------------------------------------------|
| connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| scriptId   | Integer         | The ID of the automation script.                      |
| values     | Array of string | The values to be specified in the input fields of the interactive automation script. |
| info       | Array of [DMAAutomationVariableInfo](xref:DMAAutomationVariableInfo) | Information about the variables sent with *values*. |

## Output

None.
