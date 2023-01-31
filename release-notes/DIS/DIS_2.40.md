---
uid: DIS_2.40
---

# DIS 2.40

## New features

### IDE

#### XML editor: Specifying a project reference as DLL import [ID_34565]

When, in the XML editor, you clicked the small *Down* arrow in front of a `<QAction>` tag and select *DLL Imports*, up to now, the submenu would list all QActions of which the `options` attribute contained the "precompile" option, as well as all commonly used system DLL files. From now on, it will also list QActions of which the C# project has a reference to another C# project in the solution that is not QAction_Helper, QAction_ClassLibrary or another QAction.

Also, it is now possible to override the path associated with a DLL import. To do so, proceed as follows:

1. Right-click the reference (which can be either a reference to a DLL or a reference to a project).
1. Open its properties.
1. Locate the *DLL Path* property, and enter in the value that should override the default path.

#### XML editor: QAction\@dllImport attribute will now contain the full path to the DLL file [ID_34598]

In the *QAction\@dllImport* attribute, you can now reference a DLL file that is stored in

- a subfolder of the `Dlls` folder of the repository, or
- a subfolder of the following `C:\Skyline DataMiner` folders: `Files`, `ProtocolScripts` or `ProtocolScripts\DllImport`

Up to now, the *QAction\@dllImport* attribute would only contain the name of the DLL file. From now on, it will contain the full path to that file.

### Validator

#### New feature check: Usage of NuGet packages [ID_34527]

A new feature check now verifies whether the QAction projects in the protocol are using NuGet packages.

This check can return the following error messages:

| Check ID | Error message name | Error message |
|--|--|--|
| 1.25.1 | MinVersionTooLow | Minimum required version '{currentMinDmVersion}' too low. Expected value '{expectedMinDmVersion}'. |
| 1.25.2 | MinVersionTooLow_Sub | '{requiredDmVersion}' : '{usedFeature}' |
| 1.25.3 | MinVersionFeatureUsedInItemWithId_Sub | Feature used in '{itemKind}' with '{identifierType}' '{itemId}'. |

### XML Schema

## Changes

### Enhancements

### Fixes

#### Protocol Schema: Casing of calculateAlarmState attribute was incorrect [ID_34430]

In the `Protocol.xsd` file, the casing of the `calculateAlarmState` attribute has been changed from "calculateALarmState" to "calculateAlarmState".

#### Package manifest Schema: Files and Folders elements removed from packageManifest.xsd file [ID_35006]

The `<Files>` and `<Folders>` elements have been removed from the `packageManifest.xsd` file.
