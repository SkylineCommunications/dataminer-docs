---
uid: DIS_3.1
---

# DIS 3.1

## DIS 3.1.5

### New features

#### IDE

##### Secure Coding Analyzers NuGet installed by default [ID 41904]

When creating a new QAction project in a protocol solution, or a project for a C# exe block in an Automation script, the created project now will already contain a reference to the ]Skyline.DataMiner.Utils.SecureCoding.Analyzers](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SecureCoding.Analyzers) NuGet package.

Also, a new info bar has been introduces that will show up when a solution is opened which contains projects that do not have the Skyline.DataMiner.Utils.SecureCoding.Analyzers package installed or it has an outdated version. When pressing the fix button on the info bar, it will ensure the NuGet package is installed on all applicable projects.

If a project als has the [Skyline.DataMiner.Utils.SecureCoding](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SecureCoding) NuGet package installed, during executing the fix, it will also update that NuGet package to the latest version.

#### Validator

DIS now uses

- [Validator version 1.1.12](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.12)
- [Skyline.DataMiner.XmlSchemas.Protocol version 1.0.8](https://github.com/SkylineCommunications/Skyline.DataMiner.XmlSchemas/releases/tag/1.0.8)

### Changes

#### Enhancements

##### Unicode option now by default set in the protocol snippet [ID 41837]

The protocol snippet now has the [unicode](xref:Protocol.Type-options) option set by default.

```xml
<Type relativeTimers="true" options=";unicode">protocolType</Type>
```

#### Fixes

##### Satellite assemblies are now excluded in packages  [ID 41997]

DIS now uses a new version of the [Skyline.DataMiner.CICD.Assemblers](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Assemblers.Common) NuGet package (1.0.18) which will now exclude satellite assemblies that are part of NuGet packages when assembling a protocol or Automation script.

Prior to this release note, it could occur that a satellite assembly would get added to the package while the primary assembly (with the same name) would already have been added to as a reference. This would result in an message in DIS stating that the protocol or script could not be created as a reference with the same name was already added.

##### Info bar checks only triggered after 30s and no longer throws an exception [ID 41840]

When opening a solution, the info bar checks will now only execute after a delay of 30s instead of the previous delay of 3s.
This gives the solution more time to load (e.g. when switching branches).

If the solution is not yet loaded while the info bar checks execute, this could result in an exception being thrown.
DIS has now been updated to no longer throw an exception but silently skip the check (until it is retriggered if the solution changes).

##### Public plugins are now available to external users [ID 41927]

When logged in as an external user in DIS, from now on the public [plugins](xref:DisPlugins) will be available under the Plugins menu item of DIS. 

> [!NOTE]
> After logging in, a restart of Visual Studio is needed for the menu items to become available under the Plugins menu item.

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
