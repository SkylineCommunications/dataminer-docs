---
uid: DIS_3.1
---

# DIS 3.1

## DIS 3.1.6

### New features

#### IDE

##### New tool window: DIS Parameter Update Locations [ID 41277]

The new *DIS Parameter Update Locations* tool window allows you to select a parameter and check where it is (possibly) updated. It can be opened either via the DIS menu (*Tool Windows > DIS Parameter Update Locations*) or via a parameter in the *protocol.xml* file you are editing.

After you select one of the parameters of the connector, the *Confirmed Update Locations* pane will list the locations where that parameter is updated.

For example:

- If the pane lists an Action, this means that the Action will perform a set on the parameter when executed.
- If the pane lists a QAction, this means that the QAction invokes e.g. a method that will cause the parameter to get updated. The line on which you will find that invocation within the QAction will be mentioned in the result window.

In the *Possible Update Locations* pane, you will find an overview of possible locations where this parameter might get updated.

- For example, if a QAction contains a `protocol.SetParameter()` call, but it could not be determined which parameter gets updated (e.g. because the parameter ID is calculated at run-time), then that QAction will be listed in the *Possible Update Locations* pane.

- Also, the *Confirmed Update Locations* will mark incorrect update locations in red. For example, if the connector calls a method that should be executed on a table parameter is incorrectly executed on a standalone parameter.

To trigger a recalculation of the update locations, click the *Refresh* button at the top of the tool window.

##### DIS now supports Skyline.DataMiner.Sdk projects [ID 42072]

DIS now supports the newly introduced *Skyline.DataMiner.Sdk* projects.

New context menu options to import dashboards and low-code apps from DataMiner Agents are available on the project as well as on the *PackageContent* > *Dashboards* and *PackageContent* > *Low Code Apps* folders.

Also, the *Import Protocol* and *Import Automation script* menu items under *DIS* > *DMA* are now only visible when they can be used. Previously, when you clicked those options when it was not possible to use them, an error would be thrown.

##### DIS Validator tool window now links to documentation [ID 42396]

In the *DIS Validator* tool window, the results pane will now allow you to open online documentation about the checks that were performed.

This will replace the custom window that was opened when you clicked the information icon of a particular check.

### Changes

#### Enhancements

##### DIS will now indicate that DataMiner 10.3 is the minimum supported version [ID 42399]

DIS will now indicate that DataMiner version 10.3 is the minimum supported version.

## DIS 3.1.5

### New features

#### IDE

##### Secure Coding Analyzers NuGet will now be installed by default [ID 41904]

When a new QAction project is created in a protocol solution, or when a project for a C# exe block is created in an Automation script, from now on, the newly-created project will by default contain a reference to the [Skyline.DataMiner.Utils.SecureCoding.Analyzers](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SecureCoding.Analyzers) NuGet package.

Also, a new info bar has been introduced, which will show up when you open a solution that contains projects that either do not have the *Skyline.DataMiner.Utils.SecureCoding.Analyzers* package installed or have an outdated version installed. Pressing the fix button on the info bar will then ensure that the NuGet package is installed on all applicable projects.

If a project also has the [Skyline.DataMiner.Utils.SecureCoding](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SecureCoding) NuGet package installed, during the execution of the fix, that NuGet package will also be updated to the latest version.

#### Validator

DIS now uses

- [Validator version 1.1.12](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.12)
- [Skyline.DataMiner.XmlSchemas.Protocol version 1.0.8](https://github.com/SkylineCommunications/Skyline.DataMiner.XmlSchemas/releases/tag/1.0.8)

### Changes

#### Enhancements

##### Unicode option will now by default be set in the protocol snippet [ID 41837]

The protocol snippet now has the [unicode](xref:Protocol.Type-options) option set by default.

```xml
<Type relativeTimers="true" options=";unicode">protocolType</Type>
```

#### Fixes

##### Satellite assemblies are now excluded in packages [ID 41997]

When assembling a protocol or an Automation script, DIS will now use a new version of the [Skyline.DataMiner.CICD.Assemblers](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Assemblers.Common) NuGet package (1.0.18), which will now exclude satellite assemblies that are part of NuGet packages.

Up to now, in some cases, a satellite assembly would get added to the package while the primary assembly (with the same name) would already have been added to it as a reference. In DIS, this would then result in a message stating that the protocol or script could not be created as a reference with the same name was already added.

##### Info bar checks will only be triggered after 30 seconds and will no longer throw an exception [ID 41840]

When you open a solution, the info bar checks will now only execute after a delay of 30 seconds instead of 3 seconds. This will give the solution more time to load (e.g. when switching branches).

Up to now, if the solution was not yet loaded when the info bar checks were started, in some cases, an exception would be thrown. From now on, DIS will no longer throw an exception. Instead, it will silently skip the check (until it is retriggered when the solution changes).

##### Public plugins are now available to external users [ID 41927]

When an external user logs in to DIS, from now on, the public [plugins](xref:DisPlugins) will be available under the *DIS > Plugins* menu item.

> [!NOTE]
> After you have logged in to DIS, the plugins will only become visible after a restart of Visual Studio.

## DIS 3.1.4

### New features

#### Validator

DIS now uses

- [Validator version 1.1.11](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.11)
- [Skyline.DataMiner.XmlSchemas.Protocol version 1.0.7](https://github.com/SkylineCommunications/Skyline.DataMiner.XmlSchemas/releases/tag/1.0.7)

### Changes

#### Enhancements

##### Unobserved task exception event in SLDisDmaComm will no longer cause the exception to be thrown [ID 41198]

Up to now, when an unobserved task exception event occurred in SLDisDmaComm, the event handler code would log the event and throw an exception so the process would end. As this event could occur when e.g. publishing to a DaaS system, from now on, the unobserved exception will be logged, but no exception will be thrown anymore.

#### Fixes

##### Column widths would not be consistent across cultures [ID 40737]

In DIS, the table editor automatically detects and suggests a width for a column based on its description and the values it will contain.

Up to now, the column width calculation was incorrectly based on the current culture. From now on, it will use invariant culture instead. As a result, column widths will be more consistent across cultures.

##### Generating parameters from MIB files: Inconsistent column parameter descriptions [ID 41190]

When parameters were generated from MIB files, up to now, the description of the table would not be consistent with the descriptions of its column parameters. From now on, table and column parameter descriptions will be consistent.

## DIS 3.1.3

### New features

#### IDE

##### Synchronization of solution folders [ID 39976]

When you are using the Skyline templates for Visual Studio, certain folders can be found both in the Windows file explorer and the Visual Studio solution explorer. However, in a Visual Studio solution, the folders are so-called solution folders, virtual folders that do not have a physical counterpart in the Windows file explorer.

When, in Visual Studio, you add a file to a solution folder, only a reference to that file will be added to the solution folder. The actual file will be added in the root directory of the solution. As a result, you may end up in a situation where everything seems correct in the solution explorer of Visual Studio while the physical solution folders in Windows file explorer are out of sync.

In the *Interface* tab of the *DIS Settings* windows, you can now enable the *Automatically sync solution folders* setting. If you do so, the physical solution folders will automatically be synchronized whenever you add, move or delete a file in the solution explorer.

Also, a button has now been added to the solution explorer that will allow you to manually trigger a folder synchronization.

##### DIS now also supports Arm64 [ID 40139]

DIS can now also be installed and run on 64-bit ARM platforms.

##### DIS macros now support the use of ValueTuples [ID 40297]

From now on, it will be possible to execute DIS macros using ValueTuples.

#### Validator

DIS now uses [Validator version 1.1.10](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.10).

### Changes

#### Enhancements

##### QAction log entries will now be interpolated strings [ID 40178]

All snippets and all templates in the DIS plugins have been updated so that all QAction log entries will now be interpolated strings.

##### Evertz plugin now supports additional types [ID 40689]

To Evertz plugin has now been extended to also support the *JSONTree*, *JSONTest*, and *ExpandedHiTable* widgets.

#### Fixes

##### Macros: References to PresentationFramework and PresentationCore would no longer be added correctly [ID 40297]

When you edited a macro, references to PresentationFramework and PresentationCore would no longer be added correctly. This has now been fixed.

##### Incorrect indentation in code and files generated by DIS [ID 40179]

In code and files generated by DIS, in some cases, the indentation would not be correct.

From now on, in all code and files it generates, DIS will use tab indentation, which is the default indentation that is set in the editor settings of all connector and Automation script solutions.
