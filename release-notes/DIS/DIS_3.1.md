---
uid: DIS_3.1
---

# DIS 3.1

## New features

### IDE

#### Synchronization of solution folders [ID_39976]

When you are using the Skyline templates for Visual Studio, certain folders can be found both in the Windows file explorer and the Visual Studio solution explorer. However, in a Visual Studio solution, the folders are so-called solution folders, virtual folders that do not have a physical counterpart in the Windows file explorer.

When, in Visual Studio, you add a file to a solution folder, only a reference to that file will be added to the solution folder. The actual file will be added in the root directory of the solution. As a result, you may end up in a situation where everything seems correct in the solution explorer of Visual Studio while the physical solution folders in Windows file explorer are out of sync.

In the *Interface* tab of the *DIS Settings* windows, you can now enable the *Automatically sync solution folders* setting. If you do so, the physical solution folders will automatically be synchronized whenever you add, move or delete a file in the solution explorer.

Also, a button has now been added to the solution explorer that will allow you to manually trigger a folder synchronization.

#### DIS now also supports Arm64 [ID_40139]

DIS can now also be installed and run on 64-bit ARM platforms.

### Validator

DIS now uses [Validator version 1.1.7](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.7).
