---
uid: TOODataMinerDevPackages
---

# DataMiner Development Packages

## About

### About DataMiner Development Packages

DataMiner Development Packages are NuGets available in the public [nuget store](https://www.nuget.org/) that contain the necessary DLLs for the development of DataMiner protocols or Automation scripts.

They allow access to the SLProtocol interface and IEngine interface respectively within your Visual Studio projects.

The following packages are available:

- Skyline.DataMiner.Dev.Automation
- Skyline.DataMiner.Dev.Protocol
- Skyline.DataMiner.Dev.Common

There are also several dependency packages, each containing a single assembly from the "Skyline DataMiner/Files" folder of the DMA. Most of these are not intended to be installed individually:

- Skyline.DataMiner.Files.*

For developments requiring IMediator or unit conversion such as those used working with the SRM Profile Parameters, installation of the following package is required:
- Skyline.DataMiner.Files.SLMediationSnippets

### About DataMiner

DataMiner is a transformational platform that provides vendor-independent control and monitoring of devices and services. Out of the box and by design, it addresses key challenges such as security, complexity, multi-cloud, and much more. It has a pronounced open architecture and powerful capabilities enabling users to evolve easily and continuously.

The foundation of DataMiner is its powerful and versatile data acquisition and control layer. With DataMiner, there are no restrictions to what data users can access. Data sources may reside on premises, in the cloud, or in a hybrid setup.

A unique catalog of 7000+ connectors already exist. In addition, you can leverage DataMiner Development Packages to build you own connectors (also known as "protocols" or "drivers").

> [!TIP]
> See also: [About DataMiner](https://aka.dataminer.services/about-dataminer)

### About Skyline Communications

At Skyline Communications, we deal in world-class solutions that are deployed by leading companies around the globe. Check out [our proven track record](https://aka.dataminer.services/about-skyline) and see how we make our customers' lives easier by empowering them to take their operations to the next level.

## Requirements

The "DataMiner Integration Studio" Visual Studio extension is required for development of connectors and Automation scripts using DataMiner Development Packages.

See [Installing DataMiner Integration Studio](https://aka.dataminer.services/DisInstallation)

> [!IMPORTANT]
> DevPacks are suggested to be installed with PackageReferences. DIS was redesigned to work with PackageReferences and be future-proof. 
>
> Using packages.config, you may see incorrect DLLImports (protocols) or references (Automation scripts) when asking DIS to compile the results.
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
