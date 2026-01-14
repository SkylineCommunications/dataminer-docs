---
uid: TOODataMinerDevPackages
---

# Dev Packs

Dev Packs are very similar to standard NuGet package except that they won't be added to the output, the compiled deliverable. When consuming a standard NuGet within a solution, the assemblies contained in the NuGet package will be installed when installing the solution. When consuming a dev pack within a solution, they can be used to develop using the assemblies contained in the dev pack but those assemblies won't be installed when installing the solution. Instead, the solution will assume those assemblies are already pre-installed.

## DataMiner Dev Packs

DataMiner Dev Packs (or DataMiner Development Packages) are NuGet packages available in the [official NuGet store](https://www.nuget.org/) that contain the necessary assemblies for the development of DataMiner connectors or Automation scripts.

They allow access to the SLProtocol interface and IEngine interface respectively within your Visual Studio projects without the need to have DataMiner installed. This also makes it possible to let e.g. the CI/CD pipeline build the solution, as the required DataMiner dependencies are provided in the NuGet package.

The following packages are available:

- [Skyline.DataMiner.Dev.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Automation)
- [Skyline.DataMiner.Dev.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Protocol)
- [Skyline.DataMiner.Dev.Common](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Common)

The Automation and Protocol NuGet packages both have a dependency on the Common NuGet package. When an Automation script is developed, a reference is needed to the Skyline.DataMiner.Dev.Automation NuGet package. When a connector is developed, a reference is needed to the Skyline.DataMiner.Dev.Protocol NuGet package.

The Automation, Protocol, and Common NuGet packages are so-called meta-packages. This means that they only contain references to other NuGet packages. These packages reference NuGet packages with IDs starting with "Skyline DataMiner.Files.". Every *Skyline DataMiner.Files.\** NuGet package contains a single assembly from the "Skyline DataMiner/Files" folder of DataMiner.

Typically, you will only need to install the meta-package. However, in some cases, it is possible you will need to also install a *Skyline DataMiner.Files.\** Nuget package. For example, in a development requiring IMediator or unit conversion, e.g. to work with SRM profile parameters, you need to install the following package: [Skyline.DataMiner.Files.SLMediationSnippets](https://www.nuget.org/packages/Skyline.DataMiner.Files.SLMediationSnippets).

### Requirements

The [DataMiner Integration Studio](xref:Overall_concept_of_the_DataMiner_Integration_Studio) Visual Studio extension is required for development of connectors and Automation scripts using DataMiner Development Packages.

See [Installing DataMiner Integration Studio](xref:Installing_and_configuring_the_software)

> [!IMPORTANT]
> Dev Packs are suggested to be installed with PackageReferences. DIS was redesigned to work with PackageReferences and be future-proof.
>
> If packages.config is used, you may see incorrect dllImports (protocols) or references (Automation scripts) when asking DIS to compile the results.
>
> For more information on how to migrate from packages.config to PackageReferences, see [docs.microsoft.com](https://docs.microsoft.com/en-us/nuget/consume-packages/migrate-packages-config-to-package-reference).

### Versioning

Versioning scheme:

A.B.C.D

- "A.B.C" matches the DataMiner version (e.g. 10.2.0).
- "D" is a revision number.

Revisions can be released to:

- Support different build numbers of a specific DataMiner System version.
- Support content changes to the NuGet package itself.

> [!NOTE]
> We recommend that you always use the latest revision of a version.

## Solution Dev Packs

Next to the above mentioned fully generic DataMiner Dev Packs, we also have the possibility to make some Solution Dev Packs. Let's say you work on a standard solution (e.g. MediaOps) and multiple optional modules consume assemblies exposed by such standard solution. If the optional module would consume a normal NuGet from the standard solution, it would lead to related assemblies to be installed when installing the optional module, and this could lead to mismatching versions between the assemblies installed by the optional module and the ones installed by the actual standard solution. This could then lead to assembly loading issues. Instead of that, the optional module will consume standard solution dev packs, meaning the assembly won't be installed by the optional module. Instead, the optional module will have a dependency to the standard solution and rely on the already pre-installed standard solution including those assemblies.

### Naming conventions

For the optional module to consider a NuGet package as a Dev Pack, the package name needs to start with **Skyline.DataMiner.Dev.Utils.**. This will make sure the compiled deliverable will not include the assemblies themself but instead will include the proper reference to the location where those can be found assuming the standard solution was installed.
