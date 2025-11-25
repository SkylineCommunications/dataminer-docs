---
uid: DIS_3.1
---

# DIS 3.1

## DIS 3.1.15

### New features

#### IDE

##### Updated manifest for VS2026 support [ID 44142]

The manifest file of the DataMiner Integration Studio extension has been updated to formally indicate support for Visual Studio 2026.

##### Updated copyright snippets [ID 44053]

The snippets to include the copyright message have been updated to a more concise copyright message.

##### Updated IAS [ID 44072]

The IAS snippet has been updated so it now corresponds with the example code in the README of the [IAS Toolkit repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.InteractiveAutomationScriptToolkit).

##### Updated Directory.Build.props file to exclude TargetPlatform x84 entry [ID 44224]

If the "Automatically update solution files" checkbox is enabled, DIS will automatically update some solution files such as the Directory.Build.props file which has the following entry:

`<PlatformTarget>x86</PlatformTarget>`

However, when creating e.g. a NuGet package that could be used in e.g. connectors, Automation scripts and GQI queries then you do not want the Directory.Build.props file to be fixed on x86, (since e.g. ad-hoc data sources run in a 64-bit process). This entry has now been removed.

> [!NOTE]
> As a consequence, developers should take care to set this entry on the csproj file when needed. For example, when creating unit tests for a regular Automation script, it might be required to configure the target platform to x86 as otherwise a BadImageFormatException could be thrown when executing the test.

##### Updated DIS dependencies

DIS now uses:

- [Skyline.DataMiner.CICD.Parsers.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Parsers.Common) version 1.3.0
- [Skyline.DataMiner.CICD.Models.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Models.Protocol) version 1.1.0
- [Skyline.DataMiner.Dev.Common](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Common) version 10.5.12.1
- [Skyline.DataMiner.Dev.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Automation) version 10.5.12.1
- [Skyline.DataMiner.Dev.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Protocol) version 10.5.12.1
- [Skyline.DataMiner.XmlSchemas](https://www.nuget.org/packages/Skyline.DataMiner.XmlSchemas) version 1.1.5

## DIS 3.1.14

### New features

#### IDE

##### no-restore option will now be passed to the process that will create an Automation script application package [ID 44007]

From now on, the `no-restore` option will be added as an additional argument when spawning the process that will create an Automation script application package (dmapp) via the dotnet build operation.

## DIS 3.1.13

### Fixes

#### IDE

##### Problem when publishing an Automation script [ID 43997]

In some cases, a `MissingMethodException` could be thrown while publishing an Automation script that uses the DataMiner SDK.

From now on, the application package (dmapp) creation will be performed in a dedicated process to avoid any interference with NuGet packages already loaded in by Visual Studio.

## DIS 3.1.12

### New features

#### IDE

##### New XML snippet 'Functions Root' [ID 43396]

A new *Functions Root* snippet has been introduced. It will insert the following XML code.

```xml
<Functions xmlns="http://www.skyline.be/config/functions">
    <Version>1.0.0.1</Version>
    <Protocol>
        <Name>ProtocolX</Name>
    </Protocol>
</Functions>
```

##### 'Parameter Update Locations' tool window is now able to detect update locations in HTTP sessions [ID 43646]

The *Parameter Update Locations* tool window is now able to detect update locations in [HTTP sessions](xref:Protocol.HTTP.Session) defined in a protocol.

For example, in the following session, the tool window is now able to detect that parameters 1000, 1001, and 1002 are updated through this session:

```xml
<HTTP>
    <Session id="1">
        <Connection id="1">
            <Request verb="GET" pid="900">
            </Request>
            <Response statusCode="1001">
                <Headers>
                    <Header key="Content-Type" pid="1002"></Header>
                </Headers>
                <Content pid="1000"></Content>
            </Response>
        </Connection>
    </Session>
</HTTP>
```

##### Generate Driver Help plugin will now use the updated Technical and Marketing templates [ID 43420]

The [Generate Driver Help](xref:DisPlugins#generate-driver-help) plugin will now use the updated Technical and Marketing templates.

##### Updated DIS dependencies [ID 43959]

DIS now uses:

- [Skyline.DataMiner.CICD.DMApp.Automation](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Automation) version 3.0.3
- [Skyline.DataMiner.CICD.DMProtocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMProtocol) version 3.0.3
- [Skyline.DataMiner.CICD.Parsers.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Parsers.Common) version 1.2.1
- [Skyline.DataMiner.CICD.Validators.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Validators.Protocol) version 2.0.0
- [Skyline.DataMiner.CICD.Validators.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Validators.Common) version 2.0.0
- [Skyline.DataMiner.CICD.Models.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Models.Protocol) version 1.0.16
- [Skyline.DataMiner.Core.ArtifactDownloader](https://www.nuget.org/packages/Skyline.DataMiner.Core.ArtifactDownloader) version 3.1.1
- [Skyline.DataMiner.Dev.Common](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Common) version 10.5.10
- [Skyline.DataMiner.Dev.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Automation) version 10.5.10
- [Skyline.DataMiner.Dev.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Protocol) version 10.5.10
- [Skyline.DataMiner.XmlSchemas](https://www.nuget.org/packages/Skyline.DataMiner.XmlSchemas) version 1.1.4

### Fixes

#### IDE

##### Problem when an operation failed because of insufficient permissions [ID 43538]

Up to now, a fatal error would occur when an operation was performed for which insufficient permissions were granted on the destination DMA. From now on, a message will appear, indicating that the operation failed because of insufficient permissions.

Also, error popups will now reliably appear in front of Visual Studio. They will no longer appear behind the main window. In addition, the appearance and consistency of error popups have been aligned.

##### Problem when selecting NuGet references in Solution Explorer [ID 43544]

Up to now, selecting a NuGet reference in Visual Studio's Solution Explorer (within a package solution) could cause an infinite loop of error popups, eventually leading to a fatal error in Visual Studio.

##### Skyline.DataMiner.Sdk projects would incorrectly not allow multiple Exe blocks regardless of their type [ID 43784]

With the introduction of the Skyline.DataMiner.Sdk projects, Script style projects would incorrectly not allow multiple [Exe](xref:DMSScript.Script.Exe) blocks, regardless of their [type](xref:DMSScript.Script.Exe-type).

From now on, Skyline.DataMiner.Sdk Script projects will not allow multiple Exe blocks of type 'csharp'. This will allow users to have e.g. an Exe block of type 'csharp' and an Exe block of type 'report'.

##### ProcessAutomation.dll would be referenced incorrectly after building a dmapp [ID 43899]

Up to now, when you had created or deployed an Automation script that referenced the *ProcessAutomation.dll* file, that assembly would be resolved incorrectly. The system would attempt to locate it in the `ProtocolScripts/DllImport` folder, whereas the correct location was `ProtocolScripts`.

From now on, when the *ProcessAutomation.dll* file is referenced, the resulting path in the XML file will point to the `ProtocolScripts` folder.

##### Problem with Automation script interactivity check [ID 42881]

In DIS, when you published an Automation script, an attempt would be made to detect whether the script used any interactive methods (e.g. ShowUI). If that was the case, flags would be set in the script options to mark the script as interactive.

As DIS now checks the placeholder instead of the C# code, this mechanism no longer worked. As a result, it was also no longer possible to manually set the flags in the XML file of an Automation script project.

The above-mentioned mechanism has now been removed. Whether a script requires interactivity should now be specified using the [Interactivity](xref:DMSScript.Interactivity) tag. Also, it is now possible again to manually set the flags in the XML file of an Automation script project.

## DIS 3.1.11

### New features

#### IDE

##### Updated DIS dependencies [ID 43233]

DIS now uses:

- [Skyline.DataMiner.CICD.DMApp.Automation](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Automation) version 2.1.1
- [Skyline.DataMiner.CICD.DMProtocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMProtocol) version 2.1.1
- [Skyline.DataMiner.CICD.Parsers.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Parsers.Common/1.2.0-bravo) version 1.1.2
- [Skyline.DataMiner.CICD.Validators.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Validators.Protocol) version 1.3.3
- [Skyline.DataMiner.XmlSchemas](https://www.nuget.org/packages/Skyline.DataMiner.XmlSchemas) version 1.1.3
- [Skyline.DataMiner.Core.ArtifactDownloader](https://www.nuget.org/packages/Skyline.DataMiner.Core.ArtifactDownloader) version 2.2.0
- [Skyline.DataMiner.Dev.Common](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Common) version 10.5.7.2
- [Skyline.DataMiner.CICD.Models.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Models.Protocol/1.1.0-bravo) version 1.0.15
- [Skyline.DataMiner.Utils.Protocol.Extension](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Protocol.Extension) version 1.0.0.4

### Fixes

#### IDE

##### Text editor window would open empty when an XML file was closed [ID 43217]

When an XML file was being closed while a *.cs* file was still open, DIS would try to re-open the XML file, causing the text editor of the XML file to open empty.

Also, the check that determines whether the opened file belongs to a DataMiner-specific solution (e.g. an Automation script solution, a connector solution, etc.) has been updated. From now on, as soon as DIS detects that the project is using the `Skyline.DataMiner.Sdk` SDK, it will consider this a DataMiner-specific solution.

##### Problem when switching branches [ID 43234]

Up to now, when DIS switched branches in a repository that contains a large DataMiner solution, an exception could be thrown when an attempt was made to determine the type of project.

From now on, when the project type could not be determined because the project was not fully loaded yet after a branch switch, the method that determines the project type will no longer throw an exception. Instead, it will return false.

## DIS 3.1.10

### New features

#### IDE

##### Updated XMLSchemas and Validators dependencies [ID 42906]

DIS now uses:

- [Validator version 1.3.2](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.3.2)
- [Skyline.DataMiner.XmlSchemas version 1.1.2](https://github.com/SkylineCommunications/Skyline.DataMiner.XmlSchemas/releases/tag/1.1.2)

## DIS 3.1.9

### New features

#### IDE

##### Redesigned version history editor [ID 42674]

The version history editor has been redesigned:

- The *Current Version* page has been replaced by the *All Versions* page. Adding a new minor and major version will now be more intuitive.

- The *Current Range* page has been renamed to *Changes Overview*. It shows the full history of the connector, created by checking the *Based On* parameter of each connector version. Note that the newest version is on top.

  - If you enter a search string in the search box, that search string will be highlighted and the rows will be filtered to only show the ones containing that string.
  - The width of the last column will be adjusted dynamically to better accommodate its contents.

Also, a number of changes have been made as to layout in order to enhance overall readability.

![Version editor](~/develop/images/DIS_VersionHistoryEditor.png)

## DIS 3.1.8

### New features

#### IDE

##### Support for nested SAML [ID 42690]

DIS has now support for nested SAML operations.

## DIS 3.1.7

### New features

#### IDE

##### New info bar will suggest using the Protocol.Extension NuGet [ID 42021]

A new info bar has been added to suggest using the [Protocol.Extension](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Protocol.Extension) NuGet package.

##### Updated XMLSchemas and Validators dependencies [ID 42511]

DIS now uses:

- [Validator version 1.2.0](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.2.0)
- [Skyline.DataMiner.XmlSchemas.Protocol version 1.1.1](https://github.com/SkylineCommunications/Skyline.DataMiner.XmlSchemas/releases/tag/1.1.1)

### Changes

#### Enhancements

##### Context menu of QAction edit icon no longer lists the SLDatabase.dll and System.Xml.dll assemblies [ID 42509]

The icon you can click to edit a QAction opens a context menu that allows you to easily add references to some predefined assemblies.

From now on, the list of predefined assemblies will no longer include *SLDatabase.dll* and *System.Xml.dll*.

#### Fixes

##### Problem when importing low-code apps of which the name contained illegal characters [ID 42475]

Up to now, an error could occur when, in DIS, you tried to import a low-code app with a name that contained characters that are not allowed in file names.

From now on, when you import a low-code app of which the name contains illegal characters, DIS will generate a new file name in which all illegal characters are replaced by an underscore character ('_').

##### An exception would be thrown when DIS was not able to connect to the Web API of the DataMiner Agent [ID 42484]

When DIS connects to a DataMiner Agent, since DataMiner 3.1.6, it would also connect to the Web API. If it was not able to connect to the Web API, up to now, an exception would be thrown, which would prevent actions such as publishing a protocol from being performed.

From now on, when DIS is not able to connect to the Web API, the error message will now be logged in the output window (together with a message that states that importing dashboards and low-code apps will not be possible because no Web API connection could not be set up).

All other functionality that relies on the SLNet connection, such as publishing a protocol, should no longer be affected.

##### Parameter Update Locations tool window: Parameter selection box would not get populated again when you had switched to another solution [ID 42500]

In the *Parameter Update Locations* tool window, the parameter selection box would not get populated again when you had switched to another solution.

Also, in some rare cases, the *Confirmed Update Locations* and *Possible Update Locations* panes could contain duplicate entries.

##### Skyline.DataMiner.Sdk: Use of OutDir property [ID 42497]

Version 1.1.0 of the *Skyline.DataMiner.Sdk* will now use the `OutDir` property instead of dynamically making the output path (which was error prone).

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

- For example, if a QAction contains a `protocol.SetParameter()` call, but it could not be determined which parameter gets updated (e.g. because the parameter ID is calculated at runtime), then that QAction will be listed in the *Possible Update Locations* pane.

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
