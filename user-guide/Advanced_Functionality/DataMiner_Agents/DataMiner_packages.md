---
uid: DataMiner_packages
---

# DataMiner packages

A DataMiner package is an archive file that contains all the files necessary to make a modification to a DataMiner System, for example to upgrade, downgrade or restore a DataMiner Agent, or to install a DataMiner app or DataMiner protocol.

It is possible to modify a DataMiner package by changing the packet extension to .zip. You can then access the files within the package as you would with a regular zip file. However, be careful when modifying the files within a DataMiner package, as this may cause it to function incorrectly.

The following types of DataMiner packages are available:

- [Upgrade package (.dmupgrade)](#upgrade-package-dmupgrade)

- [Update package (.dmupdate)](#update-package-dmupdate)

- [Backup package (.dmbackup)](#backup-package-dmbackup)

- [Application package (.dmapp)](#application-package-dmapp)

- [Protocol package (.dmprotocol)](#protocol-package-dmprotocol)

- [Import package (.dmimport)](#import-package-dmimport)

## Upgrade package (.dmupgrade)

Package containing all files necessary to upgrade a DataMiner Agent to a newer version.

- This type of file is published on dataminer.services by Skyline’s Quality Assurance Department.

- File extension: *.dmupgrade*

> [!NOTE]
> The maximum upload size of upgrade packages is limited depending on the DataMiner version, but it is possible to increase this limit. See [Increasing the maximum upload size for upgrade packages in a DMS](xref:SLNetClientTest_increasing_max_upload).

> [!TIP]
> See also: [Upgrade packages](xref:TOOUpgradePackageContent)

## Update package (.dmupdate)

Package containing minor updates for an existing release. Update packages contain mostly bug fixes, but can also contain new features. The packages are very similar to upgrade packages, but they only contain the files that have changed compared to the base version for which they are an update.

- This type of file is published on dataminer.services by Skyline’s Quality Assurance Department.

- File extension: *.dmupdate*

## Backup package (.dmbackup)

Package containing all files necessary to restore a particular DataMiner Agent installation.

- This type of file is created each time you select the *Maintenance \> Backup* menu command in the SLTaskBarUtility program.

- File extension: *.dmbackup*

## Application package (.dmapp)

Package containing all files necessary to install a particular DataMiner app on an existing DataMiner System.

- This type of file is created by Skyline’s System Engineering department.

- File extension: *.dmapp*

> [!NOTE]
>
> - These packages can be installed in the same way as a .dmupgrade package. See [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility).
> - .dmapp packages can also contain report templates, dashboards and aggregation rules.

> [!TIP]
> See also: [Application packages](xref:TOOApplicationPackages)

## Protocol package (.dmprotocol)

Package containing all files necessary to install a particular DataMiner protocol on an existing DataMiner System.

- This type of file is created by Skyline’s System Engineering department.

- File extension: *.dmprotocol*

The actual content of a protocol package differs from that of the other packages mentioned above. It contains the following items:

- Protocol.xml

- Default Microsoft Visio drawing (.vdx or .vsdx format)

- Default alarm and/or trend templates

- Additional assemblies (if needed)

- Protocol-specific help

## Import package (.dmimport)

Depending on what was exported into the package, this package may contain elements, services, views, properties, protocols, Automation scripts, etc.

- This file is created through an export from the Surveyor in DataMiner Cube.

- File extension: *.dmimport*

> [!TIP]
> See also: [Exporting and importing packages on a DMA](xref:Exporting_and_importing_packages_on_a_DMA)
