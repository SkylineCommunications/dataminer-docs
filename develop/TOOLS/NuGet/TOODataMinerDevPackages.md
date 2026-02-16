---
uid: TOODataMinerDevPackages
---

# Dev Packs

Dev Packs are very similar to standard NuGet package except that they will not be added to the output, the compiled deliverable. When a standard NuGet is consumed within a solution, the assemblies contained in the NuGet package will be installed when the solution is installed. When a Dev Pack is consumed within a solution, the assemblies contained in the Dev Pack can be used to develop, but those assemblies will not be installed when the solution is installed. Instead, the solution will assume those assemblies are already pre-installed.

## DataMiner Dev Packs

DataMiner Dev Packs (or DataMiner Development Packages) are NuGet packages available in the [official NuGet store](https://www.nuget.org/) that contain the necessary assemblies for the development of DataMiner connectors or automation scripts.

They allow access to the SLProtocol interface and IEngine interface respectively within your Visual Studio projects without the need to have DataMiner installed. This also makes it possible to let e.g., the CI/CD pipeline build the solution, as the required DataMiner dependencies are provided in the NuGet package.

The following packages are available:

- [Skyline.DataMiner.Dev.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Automation)
- [Skyline.DataMiner.Dev.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Protocol)
- [Skyline.DataMiner.Dev.Common](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Common)

The Automation and Protocol NuGet packages both have a dependency on the Common NuGet package. When an automation script is developed, a reference is needed to the Skyline.DataMiner.Dev.Automation NuGet package. When a connector is developed, a reference is needed to the Skyline.DataMiner.Dev.Protocol NuGet package.

The Automation, Protocol, and Common NuGet packages are so-called meta-packages. This means that they only contain references to other NuGet packages. These packages reference NuGet packages with IDs starting with "Skyline DataMiner.Files.". Every *Skyline DataMiner.Files.\** NuGet package contains a single assembly from the "Skyline DataMiner/Files" folder of DataMiner.

Typically, you will only need to install the meta-package. However, in some cases, it is possible you will need to also install a *Skyline DataMiner.Files.\** Nuget package. For example, in a development requiring IMediator or unit conversion, e.g., to work with SRM profile parameters, you need to install the following package: [Skyline.DataMiner.Files.SLMediationSnippets](https://www.nuget.org/packages/Skyline.DataMiner.Files.SLMediationSnippets).

### Requirements

The [DataMiner Integration Studio](xref:Overall_concept_of_the_DataMiner_Integration_Studio) Visual Studio extension is required for development of connectors and automation scripts using DataMiner Development Packages.

See [Installing DataMiner Integration Studio](xref:Installing_and_configuring_the_software)

> [!IMPORTANT]
> Dev Packs are suggested to be installed with PackageReferences. DIS was redesigned to work with PackageReferences and be future-proof.
>
> If packages.config is used, you may see incorrect dllImports (protocols) or references (automation scripts) when asking DIS to compile the results.
>
> For more information on how to migrate from packages.config to PackageReferences, see [docs.microsoft.com](https://docs.microsoft.com/en-us/nuget/consume-packages/migrate-packages-config-to-package-reference).

### Versioning

Versioning scheme:

A.B.C.D

- "A.B.C" matches the DataMiner version (e.g., 10.2.0).
- "D" is a revision number.

Revisions can be released to:

- Support different build numbers of a specific DataMiner System version.
- Support content changes to the NuGet package itself.

> [!NOTE]
> We recommend that you always use the latest revision of a version.

## Custom Dev Packs

In addition to the fully generic DataMiner Dev Packs, it is also possible to make **Custom Dev Packs**.

For example, imagine you are working on a standard solution like MediaOps, and multiple optional modules consume assemblies exposed by this standard solution. If such an optional module were to consume a normal NuGet from the standard solution, it would lead to related assemblies being installed when the optional module is installed, which in turn could lead to mismatching versions between the assemblies installed by the optional module and the ones installed by the actual standard solution. This could then lead to assembly loading issues.

If the optional module consumes Custom Dev Packs instead, the assembly will not be installed by the optional module. Instead, the optional module will have a dependency on the standard solution and rely on the already **pre-installed standard solution**, which includes those assemblies.

> [!IMPORTANT]
> When relevant and generic, Custom Dev Packs should be added to the list in **[Skyline NuGet packages](xref:SkylineNuGetPackages)** to ensure proper documentation and discoverability. This is especially important for Solution Dev Packs that are intended for broader reuse.

### Naming conventions

For optimal organization and maintainability, it is recommended that the NuGet package name matches the repository name.

For the optional module to consider a NuGet package as a **Custom Dev Pack**, the package name needs to start with "`Skyline.DataMiner.Dev.Utils.`". The following naming conventions should be applied consistently across all components (where square brackets indicate optional segments):

- **Repository name**: `Skyline.DataMiner.Dev.Utils.[Category.]Name`
- **NuGet package name**: Must match the repository name
- **Namespace (Usings)**: `Skyline.DataMiner.[Category.]Name`

> [!NOTE]
> The namespace intentionally omits the "Dev.Utils" segment to provide cleaner, more readable code references in consuming projects.

### Solution Dev Packs

**Solution Dev Packs** are a specific flavor of Custom Dev Packs introduced for all **Standard Solutions** delivered and provided by Skyline Communications.

This showcases the power and flexibility of Standard Solutions: any solution can consume these Dev Packs and leverage the backbone of the Standard Solution without duplicating assemblies. This promotes reusability and ensures that custom implementations can build upon the solid foundation provided by Standard Solutions.

All Solution Dev Packs follow the naming convention `Skyline.DataMiner.Dev.Utils.Solutions.*`, making them easily identifiable as packages originating from Standard Solutions. 

For Solution Dev Packs, apply the following naming conventions:

- **Repository name**: `Skyline.DataMiner.Dev.Utils.Solutions.[Name]`
- **NuGet package name**: Must match the repository name
- **Namespace (Usings)**: `Skyline.DataMiner.Solutions.[Name]`