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
> DevPacks can have unstable behavior when installed with PackageReferences because of an open bug for NuGet (https://github.com/NuGet/Home/issues/3830).
> To avoid problems, you must make sure all your NuGets are installed using packages.config. You can verify this by searching your solution *.csproj files for PackageReference. If you find zero hits, the NuGets are installed correctly.
>
> ![PackageReference search](https://docs.dataminer.services/develop/images/DevPack_PackageReferenceMistake.png)
>
> If you do find hits, you will have to migrate the solution to packages.config:
>
> 1. In the NuGet Package Manager, check which packages are currently installed, and note down the packages and their versions.
> 1. Uninstall every NuGet.
> 1. Go to Visual Studio Options > *NuGet Package Manager* > *General*, and make sure that *Default package management format* is set to *Packages.config*.
> 1. Close Visual Studio.
> 1. Open Visual Studio and install all NuGets again, as Packages.Config.

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
