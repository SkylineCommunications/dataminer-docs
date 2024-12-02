---
uid: Steps_taken_during_an_upgrade_operation
---

# Steps taken during an upgrade operation

When you start an upgrade operation, the following will happen:

1. The package is extracted in *C:\\Skyline DataMiner\\Upgrades\\Packages\\[name of the upgrade]*.

1. A log file *progress.log* is created in the folder *C:\\Skyline DataMiner\\Upgrades\\Packages\\\[name of the upgrade\]*.

1. The existence of the following required components is checked:

   - Microsoft Visual C++ redistributable packages 2010 SP1 *(up until 10.2.0 CU18 / 10.3.0 CU6 / 10.3.9)*

   - Microsoft .NET Framework 4.6.2

   - Microsoft MSXML 6.0

   - Microsoft IIS

1. All actions defined in *UpdateContent.txt* are performed one by one. See [Actions that can be performed during an upgrade operation](xref:Actions_that_can_be_performed_during_an_upgrade_operation).
