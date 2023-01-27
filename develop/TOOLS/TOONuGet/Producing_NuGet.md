---
uid: Producing_NuGet
---

# Producing NuGet packages

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

Automatic creation and publishing of NuGets from the community class library or from [custom solutions](xref:Custom_solution_development_with_CI_CD_Pipeline) is supported through the Skyline CI/CD pipelines.

On the [custom solutions tab](xref:Repository_types#custom-solutions) of the SLC SE RepoManager tool, you can enable the NuGet-related stages by clicking the NuGet button. This will add a *JenkinsNuGetConfiguration.xml* file that allows configuration of these stages (enable/disable creation, signing, publishing of NuGet packages). For more information on the expected content of this file, refer to the [NuGet stages XML schema](xref:SchemaNuGetStagesConfig) documentation.

The pipeline will automatically create pre-release packages, which can be used during development. Every build will have its own pre-release package.
Every release build will have a signed released package.

## General

Below rules are mainly focused for NuGet packages that are published to nuget.org. It is highly advised to use the same rules for internal NuGets as well as that would make it easy transferable to nuget.org when necessary.

### Mandatory rules for nuget.org

- NuGet needs to include a license file
- NuGet needs to be signed as only signed packages can be published on nuget.org
  - When creating the NuGet via [SLC SE Repository Manager](xref:TOOSLCSERepositoryManager), the pipeline will take care of signing and publishing.

### Project type

Make use of the SDK project style. This gives the advantage of using dotnet tools in the pipeline and has the latest features. It also cleans up the csproj file which reduces potential merge conflicts.

Using SDK-style projects, you can still target .NET Framework:
```xml
<PropertyGroup>
    ...
    <TargetFramework>netstandard2.0</TargetFramework> => <TargetFramework>net462</TargetFramework>
    ...
</PropertyGroup>
```

> [!NOTE]
> When using SDK project style, open your repository jenkins file with a text editor and make sure the master file being used is the 'MasterFiles\Custom Solution\JenkinsSDK'.

### Dependencies

If there is a dependency on a DataMiner DLL (from the Skyline DataMiner/Files folder), use the corresponding NuGet ([Skyline.DataMiner.Files.XXX](https://www.nuget.org/packages?q=Skyline.DataMiner.Files.)).  
If it is not there, contact the [Data-Acquisition](mailto:support.data-acquisition@skyline.be) domain. They can then include this DLL in the automatic NuGet creation from DataMiner versions.  

If there is a dependency on multiple DataMiner DLLs that are by default included in a QAction/Exe, then make use of the DevPacks ([Skyline.DataMiner.Dev.XXX](https://www.nuget.org/packages?q=Skyline.DataMiner.Dev.))

### Target Framework

If possible, try to target .NET Standard 2.0 as that gives the most flexibility to be used somewhere else.

If you have a dependency to .NET Framework (e.g.: Skyline.DataMiner.Dev.*) then you need to target .NET Framework as well.

> [!IMPORTANT]
> Prior to DataMiner 10.1.11 (RN 30755) when using a .NET Standard 2.0 NuGet in a QAction or Exe, you need to manually add a reference to .NET Standard.
>
> ```xml
> <ItemGroup>
>   <Reference Include="netstandard" />
> </ItemGroup>
> ```
>
> When targeting .NET Framework 4.6.2 you'll get a warning icon, but this can be ignored.

## Naming conventions

### Mandatory rules

- NuGet must have a name that starts with `Skyline.DataMiner.`.
- NuGet must have a name that is unique.
- NuGet must have a name that is limited to 100 characters in total.
  - The name is dependant on the branch name, so the pipeline will check this.
- Use the syntax: 'Skyline.DataMiner.\<Categories\>.\<Name\>'. Optionally at the end you could have '.Protocol', '.Automation', '.Common', ... to specify where it can be used (usage of SLManagedScripting, SLManagedAutomation, ...)
    - Skyline.DataMiner.\<Categories\>.\<Name\>.Common (Shared code that can run either in Script or Protocol. Communicates with DataMiner via SLNet or [DataMinerSystem](https://www.nuget.org/packages?q=Skyline.DataMiner.Core.DataMinerSystem))
    - Skyline.DataMiner.\<Categories\>.\<Name\>.Automation (Acts as entrypoint for Automation (methods for IEngine) or has a dependency on classes from SLManagedAutomation)
    - Skyline.DataMiner.\<Categories\>.\<Name\>.Protocol (Acts as entrypoint for Protocol (methods for SLProtocol) or has a dependency on classes from SLManagedScripting)

    - Another situation is the module that it has to do with. An example of this is the CI/CD packages:
        - Skyline.DataMiner.CICD.DMApp.Common (common code for creating a package)
        - Skyline.DataMiner.CICD.DMApp.Automation (specific code to convert an Automation solution to dmapp package)
        - Skyline.DataMiner.CICD.DMApp.XXX (specific code to convert a XXX solution/repository to dmapp package)

### Reserved names

- Skyline.DataMiner.Files.XXX (DataMiner DLLs - Autogenerated by tool from Data-Acquisition domain)
- Skyline.DataMiner.Dev.XXX (DevPacks - Autogenerated by tool from Data-Acquisition domain)
- Skyline.DataMiner.CICD.XXX (Managed by Data-Acquisition domain)

### Existing names

- Skyline.DataMiner.Core.XXX
  - Holds the packages that have a direct link to DataMiner (AppPackage creation/installation, DataMinerSystem, InterAppCalls, ...)
  - DxM also fall under this.
- Skyline.DataMiner.Utils.XXX
  - Holds all the utilities like helpers, parsers, ...
    - E.g.: SNMP trap parsing, rate calculations, table context menu, ...

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

'Skyline' and 'DataMiner' are mandatory. Extra tags can be added if desired.

#### PackageReadmeFile

Always include a readme file to explain the NuGet and how to use it.
An example can be seen for [DataMinerSystem.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Common#readme-body-tab)

### Optional metadata

When creating NuGets via the [SLC SE Repository Manager](xref:TOOSLCSERepositoryManager), the pipeline will automatically add the default license and icon file. If a different license or icon needs to be used then this can be specified in the metadata.

```xml
<PropertyGroup>
    ...
    <PackageLicenseFile>LICENSE.txt</PackageLicenseFile>
    <PackageIcon>Icon.png</PackageIcon>
    ...
</PropertyGroup>
```
