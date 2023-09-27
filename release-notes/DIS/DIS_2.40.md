---
uid: DIS_2.40
---

# DIS 2.40

## New features

### IDE

#### Plugins [ID_34190] [ID_34381] [ID_34391] [ID_34428] [ID_34459]

In the *DIS menu*, you can now find the following plugins. These will allow you to easily add functionality to the *protocol.xml* file you are editing.

| Plugin | Description |
|--------|-------------|
| Plugins \> Add After Startup | Adds the after startup logic to the protocol. DIS will check whether the *protocol.xml* file contains an after startup trigger, and will add one if none was found. Apart from the trigger, it will also add all remaining items of the after startup flow.<br>See also [Executing a QAction after startup](xref:LogicExamples#executing-a-qaction-after-startup) |
| Plugins \> Add matrix... | Adds a matrix and/or Inputs and Outputs tables to the protocol. |
| Plugins \> Add SNMP System Info... | Adds the following SNMP System Info parameters to the protocol:<br>- System Description (1.3.6.1.2.1.1.1)<br>- System Object ID (1.3.6.1.2.1.1.2)<br>- System Uptime (1.3.6.1.2.1.1.3)<br>- System Name (1.3.6.1.2.1.1.5)<br>- System Contact (1.3.6.1.2.1.1.4)<br>- System Location (1.3.6.1.2.1.1.6) |
| Plugins \> Add SNMP Trap Receiver... | Adds an SNMP trap receiver and a QAction with boilerplate code to process received traps. |
| Plugins \> Add Table Context Menu... | Adds a custom context menu to a table in the protocol. You can choose between the following:<br>- Rows Manager (User-definable Keys): A default context menu that provides add, duplicate, edit and delete functionality.<br>- Rows Manager (Auto-incremented Keys): An extension of the previous type that allows developers to work with an auto-increment key parameter.<br>- Custom: Opens a wizard that allows you to specify the options. |

#### XML editor: Specifying a project reference as DLL import [ID_34565]

When, in the XML editor, you clicked the small *Down* arrow in front of a `<QAction>` tag and select *DLL Imports*, up to now, the submenu would list all QActions of which the `options` attribute contained the "precompile" option, as well as all commonly used system DLL files. From now on, it will also list QActions of which the C# project has a reference to another C# project in the solution that is not QAction_Helper, QAction_ClassLibrary or another QAction.

Also, it is now possible to override the path associated with a DLL import. To do so, proceed as follows:

1. Right-click the reference (which can be either a reference to a DLL or a reference to a project).
1. Open its properties.
1. Locate the *DLL Path* property, and enter in the value that should override the default path.

#### DIS diagram: Third direction option "Both" [ID_34584]

In the *DIS diagram* window, up to now, after selecting the required depth (i.e. the number of items you want to have displayed starting from or ending with the item you selected), you could select *Forward* or *Reverse* as direction. From now on, you can also select a third option: *Both*.

| Direction | Description |
|-----------|-------------|
| Forward   | Shows the specified\* number of linked items starting from the item you selected. |
| Reverse   | Shows the specified\* number of linked items ending with the item you selected.   |
| Both      | Shows the specified\* number of linked items starting from the item you selected, as well as the specified\* number of linked items ending with the item you selected. |

*\* The value entered in the Depth box.*

#### XML editor: QAction\@dllImport attribute will now include subfolder [ID_34598]

In the *QAction\@dllImport* attribute, you can now reference a DLL file that is stored in

- a subfolder of the `Dlls` folder of the repository, or
- a subfolder of the following `C:\Skyline DataMiner` folders: `Files`, `ProtocolScripts` or `ProtocolScripts\DllImport`

Up to now, the *QAction\@dllImport* attribute would only contain the name of the DLL file. From now on, it will include the subfolders as well.

#### Snippets, plugins and macros: References to former Class Library updated [ID_35769]

The Class Library has been split up in smaller NuGet packages. For more information, see [Unlimited DevOps power at your fingertips – Code Library NuGet packages are living on the cloud!](https://community.dataminer.services/unlimited-devops-power-at-your-fingertips-code-library-nuget-packages-are-living-on-the-cloud).

Every snippet, plugin and macro has been updated with the new namespaces and the correct references.

#### Support for connecting to DataMiner Agents via gRPC [ID_36035]

Before connecting to a DataMiner Agent, DIS will now first check the connection settings of that Agent and connect to it via either .NET Remoting or gRPC. This will enable DIS to also connect to cloud-connected Agents.

#### Minimum supported DataMiner version is now 10.1.0 [ID_36036]

The minimum supported DataMiner version has now been incremented to version 10.1.0.

### Validator

#### New feature check: Usage of NuGet packages [ID_34527]

A new feature check now verifies whether the QAction projects in the protocol are using NuGet packages.

This check can return the following error messages:

| Check ID | Error message name | Error message |
|--|--|--|
| 1.25.1 | MinVersionTooLow | Minimum required version '{currentMinDmVersion}' too low. Expected value '{expectedMinDmVersion}'. |
| 1.25.2 | MinVersionTooLow_Sub | '{requiredDmVersion}' : '{usedFeature}' |
| 1.25.3 | MinVersionFeatureUsedInItemWithId_Sub | Feature used in '{itemKind}' with '{identifierType}' '{itemId}'. |

## Changes

### Enhancements

#### DIS diagram: Enhancements with regard to re-arranging items and zooming in and out [ID_34586]

A number of enhancements have been made to the DIS diagram, especially with regard to re-arranging items and zooming in and out.

#### Remove regions from QAction_1 in template [ID_35007]

In the DataMiner protocol template, the region preprocessor directives have been removed from QAction_1.

#### Executables in VSIX extension package are now signed [ID_35879]

The executables included in the DIS VSIX extension package are now signed.

#### Automation script template: Namespace added and input argument updated [ID_36033]

The Automation script template will now put a namespace around the `Script` class.

Also, the `Engine` argument in the *Run* methods has been changed to `IEngine`.

### Fixes

#### Protocol Schema: Casing of calculateAlarmState attribute was incorrect [ID_34430]

In the `Protocol.xsd` file, the casing of the `calculateAlarmState` attribute has been changed from "calculateALarmState" to "calculateAlarmState".

#### Package manifest Schema: Files and Folders elements removed from packageManifest.xsd file [ID_35006]

The `<Files>` and `<Folders>` elements have been removed from the `packageManifest.xsd` file.
