---
uid: TOODataMinerDevPackages
---

# DataMiner Dev Packs

DataMiner Dev Packs (or DataMiner Development Packages) are NuGet packages available in the [official NuGet store](https://www.nuget.org/) that contain the necessary assemblies for the development of DataMiner connectors or Automation scripts.

They allow access to the SLProtocol interface and IEngine interface respectively within your Visual Studio projects without the need to have DataMiner installed. This also makes it possible to let e.g. the CI/CD pipeline build the solution, as the required DataMiner dependencies are provided in the NuGet package.

The following packages are available:

- [Skyline.DataMiner.Dev.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Automation)
- [Skyline.DataMiner.Dev.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Protocol)
- [Skyline.DataMiner.Dev.Common](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Common)

The Automation and Protocol NuGet packages both have a dependency on the Common NuGet package. When an Automation script is developed, a reference is needed to the Skyline.DataMiner.Dev.Automation NuGet package. When a connector is developed, a reference is needed to the Skyline.DataMiner.Dev.Protocol NuGet package.

The Automation, Protocol, and Common NuGet packages are so-called meta-packages. This means that they only contain references to other NuGet packages. These packages reference NuGet packages with IDs starting with "Skyline DataMiner.Files.". Every *Skyline DataMiner.Files.\** NuGet package contains a single assembly from the "Skyline DataMiner/Files" folder of DataMiner.

Typically, you will only need to install the meta-package. However, in some cases, it is possible you will need to also install a *Skyline DataMiner.Files.\** Nuget package. For example, in a development requiring IMediator or unit conversion, e.g. to work with SRM profile parameters, you need to install the following package: [Skyline.DataMiner.Files.SLMediationSnippets](https://www.nuget.org/packages/Skyline.DataMiner.Files.SLMediationSnippets).

## Requirements

The [DataMiner Integration Studio](xref:DIS) Visual Studio extension is required for development of connectors and Automation scripts using DataMiner Development Packages.

See [Installing DataMiner Integration Studio](xref:Installing_and_configuring_the_software)

> [!IMPORTANT]
> Dev Packs are suggested to be installed with PackageReferences. DIS was redesigned to work with PackageReferences and be future-proof.
>
> If packages.config is used, you may see incorrect dLLImports (protocols) or references (Automation scripts) when asking DIS to compile the results.
>
> For more information on how to migrate from packages.config to PackageReferences, see [docs.microsoft.com](https://docs.microsoft.com/en-us/nuget/consume-packages/migrate-packages-config-to-package-reference).

## Versioning

Versioning scheme:

A.B.C.D

- "A.B.C" matches the DataMiner version (e.g. 10.2.0).
- "D" is a revision number.

Revisions can be released to:

- Support different build numbers of a specific DataMiner System version.
- Support content changes to the NuGet package itself.

> [!NOTE]
> We recommend that you always use the latest revision of a version.
