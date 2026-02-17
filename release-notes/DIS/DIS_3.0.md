---
uid: DIS_3.0
---

# DIS 3.0

## New features

### Validator

DIS now uses [Validator version 1.1.6](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.6).

## Changes

### Enhancements

#### Support for Visual Studio 2019 has been dropped [ID 39719]

Support for Microsoft Visual Studio 2019 has been dropped. The last DIS version supporting Visual Studio 2019 is DIS v2.48.

#### DIS is now available on Visual Studio Marketplace [ID 39747]

DIS is now available on [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=skyline-communications.DataMinerIntegrationStudio).

> [!NOTE]
> As Visual Studio contains functionality to automatically notify and/or update extensions, the *Updates* tab has been removed from the *DIS Settings* window.

#### Incorrect target framework banner will only be displayed when applicable [ID 39818]

When you are working on a connector solution that has a *Compliancies.MinimumRequiredVersion* tag containing a DataMiner version older than 10.2.0, the banner asking to make the projects use .NET Framework 4.8 will no longer be displayed. As from DataMiner version 10.2.0, Microsoft .NET Framework 4.8 has become the standard.

### Fixes

#### Visual Studio would incorrectly throw warnings when DIS created a QAction_Helper project [ID 39643]

When DIS generated a `QAction_Helper` project (e.g., while converting a *protocol.xml* file to a protocol solution), Visual Studio would incorrectly throw a large number of warnings.
