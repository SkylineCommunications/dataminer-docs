---
uid: ExecuteAutomationScript
---

# ExecuteAutomationScript

Use this method to execute an interactive Automation script.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| Script.Name | String | The name of the Automation script. |
| Script.Folder | String | The folder containing the Automation script. |
| Script.Description | String | The description of the Automation script. |
| Script.Settings.Require­Interactive | Boolean | Determines whether the script will require interaction from the user. |
| Script.Settings.HasFind­InteractiveClient | Boolean | Determines if a pop-up window will be displayed asking clients to attach to the script. |
| Script.Parameters | Array of [DMAAutomationScriptParameter](xref:DMAAutomationScriptParameter) | The parameters used in the script. |
| Script.Dummies | Array of [DMAAutomationScriptDummy](xref:DMAAutomationScriptDummy) | The dummies used in the script. |
| Script.MemoryFiles | Array of [DMAAutomationScriptMemoryFile](xref:DMAAutomationScriptMemoryFile) | The memory files used in the script. |
| Script.ScriptOptions.WaitForScript | Boolean | Determines whether you will need to wait for the script to finish before you can continue. |
| Script.ScriptOptions.CheckSets | Boolean | Determines whether the script will wait for a return value indicating whether the update was successful every time it performs a parameter update. |
| Script.ScriptOptions.LockElements | Boolean | Determines whether the script will lock elements. |
| Script.ScriptOptions.ForceLockElements | Boolean | If *LockElements* is true, this option determines whether the script will also lock elements when they are locked by another process (e.g. another Automation script). |
| Script.ScriptOptions.WaitWhenLocked | Boolean | Determines whether the script will wait for an element to become unlocked in case the element is locked by another process (e.g. another Automation script). |
| Script.ScriptOptions.IsInUse | Boolean | Determines whether dummy elements are marked as “In Use” for active scheduled tasks. |
| Script.ScriptOptions.AskForConfirmation | Boolean | Determines whether the user will need to provide confirmation before the script starts running. |

## Output

| Item | Format | Description |
|--|--|--|
| ExecuteAutomation­ScriptResult | Integer | The ID of the instance of the running script. This ID will be used to go to the next step in case it is an interactive script. |
