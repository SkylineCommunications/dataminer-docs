---
uid: ExecuteAutomationScriptWithOutput
---

# ExecuteAutomationScriptWithOutput

Use this method to execute an interactive Automation script and receive its output. Available from DataMiner 10.0.5 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| script.Name | String | The name of the Automation script. |
| script.Folder | String | The folder containing the Automation script. |
| script.Description | String | The description of the Automation script. |
| script.Settings.RequireInteractive | Boolean | Determines whether the script will require interaction from the user. |
| script.Settings.HasFindInteractiveClient | Boolean | Determines if a pop-up window will be displayed asking clients to attach to the script. |
| script.Parameters | Array of [DMAAutomationScriptParameter](xref:DMAAutomationScriptParameter) | The parameters used in the script. |
| script.Dummies | Array of [DMAAutomationScriptDummy](xref:DMAAutomationScriptDummy) | The dummies used in the script. |
| script.MemoryFiles | Array of [DMAAutomationScriptMemoryFile](xref:DMAAutomationScriptMemoryFile) | The memory files used in the script. |
| scriptOptions.WaitForScript | Boolean | Determines whether you will need to wait for the script to finish before you can continue. |
| scriptOptions.CheckSets | Boolean | Determines whether the script will wait for a return value indicating whether the update was successful every time it performs a parameter update. |
| scriptOptions.LockElements | Boolean | Determines whether the script will lock elements. |
| scriptOptions.ForceLockElements | Boolean | If *LockElements* is true, this option determines whether the script will also lock elements when they are locked by another process (e.g. another Automation script). |
| scriptOptions.WaitWhenLocked | Boolean | Determines whether the script will wait for an element to become unlocked in case the element is locked by another process (e.g. another Automation script). |
| scriptOptions.IsInUse | Boolean | Determines whether dummy elements are marked as “In Use” for active scheduled tasks. |
| scriptOptions.AskForConfirmation | Boolean | Determines whether the user will need to provide confirmation before the script starts running. |

## Output

| Item | Format | Description |
|--|--|--|
| ExecuteAutomationScriptWithOutputResult | Integer and array of DMAAutomationOutputValue | \- An integer representing the ID of the instance of the running script. This ID will be used to go to the next step in case it is an interactive script.<br> - An array of DMAAutomationOutputValue objects, each consisting of the key of the output item and its value. |
