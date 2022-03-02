---
uid: DMAAutomationScript
---

# DMAAutomationScript

| Item                               | Format                                  | Description                                                                             |
|------------------------------------|-----------------------------------------|-----------------------------------------------------------------------------------------|
| Name                               | String                                  | The name of the Automation script.                                                      |
| Folder                             | String                                  | The folder containing the Automation script.                                            |
| Description                        | String                                  | The description of the Automation script.                                               |
| Settings.RequireInterac­tive       | Boolean                                 | Determines whether the script will require interaction from the user.                   |
| Settings.HasFindInterac­tiveClient | Boolean                                 | Determines if a pop-up window will be displayed asking clients to attach to the script. |
| Parameters                         | Array of DMAAutoma­tionScriptParameter  | See [DMAAutomationScriptParameter](xref:DMAAutomationScriptParameter).                    |
| Dummies                            | Array of DMAAutoma­tionScriptDummy      | See [DMAAutomationScriptDummy](xref:DMAAutomationScriptDummy).                            |
| MemoryFiles                        | Array of DMAAutoma­tionScriptMemoryFile | See [DMAAutomationScriptMemoryFile](xref:DMAAutomationScriptMemoryFile).                  |
