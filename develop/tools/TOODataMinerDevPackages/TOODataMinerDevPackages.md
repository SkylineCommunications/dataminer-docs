---
uid: TOODataMinerDevPackages
---

# DataMiner Development Packages

## About

### Dev Packs

Development packages contain the necessary DLLs for development of protocols or Automation scripts to be used on a DataMiner system.
They allow access to the SLProtocol interface and IEngine interface respectively within your Visual Studio projects.

### DataMiner

DataMiner is a transformational platform beginning with vendor independent control and monitoring of devices and services.
Out of the box and by design, it addresses key challenges such as security, complexity, multi-cloud, and much more.

At the same time, it also provides a pronounced open architecture with powerful enabling capabilities that enables users to evolve easily and continuously.

The foundation of DataMiner is its powerful and versatile data acquisition and control layer. With DataMiner, there are no restrictions to what data users can access. Data sources may reside on premises, in the cloud, or in a hybrid setup.

A unique catalog of 7000+ connectors already exist.

DataMiner Development Packages can be leveraged to build you own connectors (aka protocols).

[About DataMiner](https://docs.dataminer.services/dataminer-overview/General%20Introduction/About_DataMiner/Overview_About_DataMiner.html)

### Skyline Communications

At Skyline Communications, we deal in world-class solutions that are deployed by leading companies around the globe. But don't just take our word for it. Check out our proven track record and see how we make our customers lives easier by empowering them to take their operations to the next level.

[About Skyline](https://skyline.be/skyline/about)

## Requirements

The Visual Studio extension: DataMiner Integration Studio is required for development of connectors and Automation scripts using DataMiner Development Packages.

[Installing DataMiner Integration Studio](https://docs.dataminer.services/user-guide/Advanced_Functionality/DIS/Installing_and_configuring/Installing_and_configuring_DataMiner_Integration_Studio.html)

## Versioning

Versioning Scheme:

A.B.C.D

* A.B.C matches the DataMiner version. (e.g. 10.2.0).
* D is a revision number.

Revisions can be released to:

* Support different build numbers of a specific DataMiner System version.
* Support content changes to the NuGet package itself.

> [!NOTE]
> It's recommended to always use the latest revision of a version.
