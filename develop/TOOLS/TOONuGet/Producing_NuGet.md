---
uid: Producing_NuGet
---

# Producing NuGet packages

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

Automatic creation and publishing of NuGets from the community class library or from [custom solutions](xref:Pipeline_stages_for_custom_solutions) is supported through the Skyline CI/CD pipelines.

On the [custom solutions tab](xref:Repository_types#custom-solutions) of the SLC SE RepoManager tool, you can enable the NuGet-related stages by clicking the NuGet button. This will add a *JenkinsNuGetConfiguration.xml* file that allows configuration of these stages (enable/disable creation, signing, publishing of NuGet packages). For more information on the expected content of this file, refer to the [NuGet stages XML schema](xref:SchemaNuGetStagesConfig) documentation.

The pipeline will automatically create pre-release packages, which can be used during development. Every build will have its own pre-release package.
Every release build will have a signed released package.

> [!TIP]
> To create a new solution or project that produces a NuGet package, make use of the Visual Studio templates available at [https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates).

## General

The rules below mainly focus on NuGet packages that are published to nuget.org. We highly recommend that you use the same rules for internal NuGet packages as well, as that will make it easy to transfer them to nuget.org when necessary.

### Mandatory rules for nuget.org

- NuGet needs to include a license file

- NuGet needs to be signed, as only signed packages can be published on nuget.org

  > [!NOTE]
  > If the NuGet is created via [SLC SE Repository Manager](xref:TOOSLCSERepositoryManager), the pipeline will take care of signing and publishing.

### Project type

Make use of the SDK project style. This gives the advantage of using dotnet tools in the pipeline and has the latest features. It also cleans up the .csproj file, which reduces potential merge conflicts.

Using SDK-style projects, you can still target .NET Framework:

```xml
<PropertyGroup>
    ...
    <TargetFramework>netstandard2.0</TargetFramework> => <TargetFramework>net462</TargetFramework>
    ...
</PropertyGroup>
```

> [!NOTE]
> If you use SDK project style, open your repository jenkins file with a text editor and make sure the master file being used is the "MasterFiles\Custom Solution\JenkinsSDK".

### Dependencies

If there is a dependency on a DataMiner DLL (from the Skyline DataMiner/Files folder), use the corresponding NuGet ([Skyline.DataMiner.Files.XXX](https://www.nuget.org/packages?q=Skyline.DataMiner.Files.)).

If no corresponding NuGet is available there, contact the [Data-Acquisition](mailto:support.data-acquisition@skyline.be) domain. They can then include this DLL in the automatic NuGet creation from DataMiner versions.

If there is a dependency on multiple DataMiner DLLs that are by default included in a QAction/EXE, then make use of the DevPacks ([Skyline.DataMiner.Dev.XXX](https://www.nuget.org/packages?q=Skyline.DataMiner.Dev.)).

### Target Framework

If possible, try to target .NET Standard 2.0, as this will give the most flexibility for use somewhere else. For more information and guidelines, refer to [Cross-platform targeting](https://learn.microsoft.com/en-us/dotnet/standard/library-guidance/cross-platform-targeting).

If you have a dependency on .NET Framework (e.g. Skyline.DataMiner.Dev.*), you will need to target .NET Framework as well.

> [!IMPORTANT]
> Prior to DataMiner 10.1.11 (RN 30755), when a .NET Standard 2.0 NuGet is used in a QAction or EXE, you need to manually add a reference to .NET Standard.
>
> ```xml
> <ItemGroup>
>   <Reference Include="netstandard" />
> </ItemGroup>
> ```
>
> When .NET Framework 4.6.2 is targeted, you will get a warning icon, but this can be ignored.

## Naming conventions

### Mandatory rules

- NuGet must have a name that starts with `Skyline.DataMiner.`.

- NuGet must have a name that is unique.

- NuGet must have a name that is limited to 100 characters in total.

  > [!NOTE]
  > The name depends on the branch name, so the pipeline will check this.

- Use the syntax `Skyline.DataMiner.<Categories>.<Name>`.

  Optionally, at the end you could have '.Protocol', '.Automation', '.Common', etc. to specify where it can be used (usage of SLManagedScripting, SLManagedAutomation, etc.):

  - `Skyline.DataMiner.<Categories>.<Name>.Common`: Shared code that can run either in an Automation script or in a protocol. Communicates with DataMiner via SLNet or [DataMinerSystem](https://www.nuget.org/packages?q=Skyline.DataMiner.Core.DataMinerSystem).

  - `Skyline.DataMiner.<Categories>.<Name>.Automation`: Acts as entry point for Automation (methods for IEngine) or has a dependency on classes from *SLManagedAutomation*.

  - `Skyline.DataMiner.<Categories>.<Name>.Protocol`: Acts as entry point for protocol (methods for SLProtocol) or has a dependency on classes from *SLManagedScripting*.

  Another situation is the module that it has to do with. An example of this are the CI/CD packages:

  - *Skyline.DataMiner.CICD.DMApp.Common*: Common code for creating a package.

  - *Skyline.DataMiner.CICD.DMApp.Automation*: Specific code to convert an Automation solution to a .dmapp package.

  - *Skyline.DataMiner.CICD.DMApp.XXX*: Specific code to convert XXX solution/repository to .dmapp package)

### Reserved names

- *Skyline.DataMiner.Files.XXX*: DataMiner DLLs. Autogenerated by tool from Data Acquisition domain.
- *Skyline.DataMiner.Dev.XXX*: DevPacks. Autogenerated by tool from Data Acquisition domain.
- *Skyline.DataMiner.CICD.XXX*: Managed by Data Acquisition domain.

### Existing names

- *Skyline.DataMiner.Core.XXX*

  - Holds the packages dealing with direct (usually very generic) DataMiner features (AppPackage creation/installation, DataMinerSystem, InterAppCalls, etc.).

  - This also applies for DxMs, except for packages that can communicate with external data sources.

- *Skyline.DataMiner.Utils.XXX*

  - Holds all the utilities like helpers, parsers, etc.

    E.g. SNMP trap parsing, rate calculations, table context menu, etc.

- *Skyline.DataMiner.ConnectorAPI.XXX*

  - Holds InterAppCall messages that are specific to a connector, giving a given DataMiner connector some functions that can be called/triggered/consumed by other DataMiner components (other connectors, Automation scripts, etc.).

- *Skyline.DataMiner.DataSources.XXX*

  - Holds the packages that can communicate with external data sources. This also includes packages like OpenConfig.Gnmi that rely on the CommunicationGateway DxM.

## Versioning conventions

We want to adhere to the [Semantic Versioning for NuGet packages](https://learn.microsoft.com/en-us/nuget/concepts/package-versioning).

A specific version number is in the form *Major.Minor.Patch[-Suffix]*, where the components have the following meanings:

- *Major*: Breaking changes (API breaking changes, DataMiner minimum dependency changes, etc.)
- *Minor*: New features, but backwards compatible
- *Patch*: Backwards compatible bug fixes only
- *-Suffix* (optional): A hyphen followed by a string denoting a pre-release version.

## Package Metadata Conventions

### Mandatory metadata

```xml
<PropertyGroup>
    ...
    <!-- Make the XML documentation available in IntelliSense -->
    <GenerateDocumentationFile>True</GenerateDocumentationFile>
    <GeneratePackageOnBuild>True</GeneratePackageOnBuild>
    <PackageRequireLicenseAcceptance>True</PackageRequireLicenseAcceptance>
    ...
    <Authors>SkylineCommunications</Authors>
    <Company>Skyline Communications</Company>
    <Description>{Short description about the NuGet}</Description>
    ...
    <PackageTags>Skyline;DataMiner</PackageTags>
    <PackageProjectUrl>https://skyline.be</PackageProjectUrl>
    <PackageReadmeFile>README.md</PackageReadmeFile>
    <PackageLicenseFile>LICENSE.txt</PackageLicenseFile>
    <PackageIcon>Icon.png</PackageIcon>
    ...
</PropertyGroup>
```

#### Authors

This has to be without whitespace.

#### Description

If there is a dependency on a minimum DataMiner version, include this in the description.

To improve ease of use, you can add an entry point or refer to the readme.

```
<Short description describing the NuGet>
[Minimum Required DataMiner: 10.1.11]
Code Entry Point: var dms = protocol.GetDms();
Refer to the readme for more information.
```

#### PackageTags

*Skyline* and *DataMiner* are mandatory. Extra tags can be added if desired.

#### PackageReadmeFile

Always include a readme file to explain the purpose of the NuGet and how to use it.

For an example, refer to [DataMinerSystem.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Common#readme-body-tab)

### PackageLicenseFile and PackageIcon

When NuGet packages are created via the [SLC SE Repository Manager](xref:TOOSLCSERepositoryManager), the manager will automatically add the default license and icon file.
