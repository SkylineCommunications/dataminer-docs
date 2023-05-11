---
uid: Contents_of_an_upgrade_package
---

# Contents of an upgrade package

A DataMiner upgrade package contains the following files:

- Description.txt

- Update.zip

- SLUpgrade.dll

#### Description.txt

A text file containing the description of the package.

Examples of descriptions:

```txt
DataMiner Upgrade (Full)
```

```txt
Rollback for upgrade which was executed on 2012-09-24 15:15:38.
This upgrade contains all files that were replaced during the upgrade.
```

#### Update.zip

A zip file containing:

- A number of folders containing data to be placed in *C:\\Skyline DataMiner* or one of its subfolders.

- Three text files:

    | File name       | Contents                                                  |
    |-------------------|-----------------------------------------------------------|
    | FilesToDelete.txt | The list of files to delete.                          |
    | FilesToLeave.txt  | The list of files to keep.                             |
    | UpdateContent.txt | The actions to perform during the upgrade operation. |

In both *FilesToDelete.txt* and *FilesToLeave.txt*, each line has to refer to a file (or a collection of files) by means of an absolute path.

Example:

```txt
...
c:\skyline dataminer\logging\*.txt
c:\skyline dataminer\tools\TableDef.txt
...
```

For more information on *UpdateContent.txt*, see [Actions that can be performed during an upgrade operation](xref:Actions_that_can_be_performed_during_an_upgrade_operation).

> [!NOTE]
> It is possible that a file named *StartUpActions.txt* is placed in the folder *Upgrades/StartUpActions* in *Update.zip*. This file can contain commands similar to those in the *UpdateContent.txt* file.

#### SLUpgrade.dll

The DLL file that executes the upgrade operation.

Loads *Update.zip*.
