---
uid: DIS_3.1
---

# DIS 3.1

## New features

### IDE

#### Solution Items Syncing [ID_39976]

In our Visual Studio templates, there are certain folders (DLLs, CompanionFiles, SetupContent, ...) that are located in the file explorer and the solution explorer. In Visual Studio it is not possible to, outside a project, link a solution folder with the directory in the file explorer.

When adding files from within Visual Studio those files would end up in the root directory of the solution and the solution explorer having a reference to that file. This can cause confusion for the user as in Visual Studio it looks correct, but on the file explorer it is not.

DIS will now trigger on items being added/removed and run the Solution Items Syncing logic. This will try to match up the file explorer and solution explorer by moving files, adding items in the solution explorer, ....

In addition a button has been added to the solution explorer to trigger this manually. A new setting has been added in the Interfaces tab to automatically run this logic when needed. If disabled, a popup will show with the changes that would be done and asks the user to confirm.

#### Arm64 support [ID_40139]

Support for ARM platforms has been introduced in DIS.

### Validator

DIS now uses [Validator version 1.1.7](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.7).
