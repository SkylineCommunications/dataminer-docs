---
uid: GetAutomationScript
---

# GetAutomationScript

Use this method to retrieve an Automation script.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| scriptName | String | The name of the Automation script.                   |

## Output

| Item | Format | Description |
|--|--|--|
| GetAutomationScriptResult | [DMAAutomationScript](xref:DMAAutomationScript) | The information of the requested Automation script. |
