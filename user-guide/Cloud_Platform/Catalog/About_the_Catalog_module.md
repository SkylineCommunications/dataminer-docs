---
uid: About_the_Catalog_module
---

# About the Catalog module

As part of dataminer.services, the Catalog module allows Skyline customers and DataMiner Strategic Partners to browse and deploy available DataMiner connectors, packages, Visio drawings, Automation scripts, dashboards, and more.

## Accessing the Catalog module

1. Go to <https://dataminer.services>, and [sign in](xref:Logging_on_to_the_DataMiner_Cloud_Platform).

1. On the dataminer.services landing page, click *Catalog*.

> [!TIP]
> From DataMiner 10.2.9/10.3.0 onwards, you can navigate directly to the catalog from DataMiner Cube by selecting *Catalog* in the *Apps* pane.

## About Catalog items

A Catalog item is a small package that contains one or more artifacts that can be deployed on a DataMiner System. [Different types of Catalog items](#supported-catalog-item-types) are supported. For example, an item could be a single connector, or it could be an application package containing multiple dashboards, Automation scripts, and connectors.

### Public and private Catalog items

**Public** Catalog items are items that are available for anyone within the community to use.

**Private** Catalog items are items that are only available within your own organization. This gives users the possibility to develop app packages, Automation scripts, or any type of Catalog item and redeploy them within their organization on various systems.

### Versioning of Catalog items

Catalog items can have multiple versions. To make sure that the versioning of items is easy to understand for everyone, [Semver](https://semver.org/) versioning is enforced. Extra labels can be assigned to versions to indicate that a certain version is not an official release (e.g. 1.2.3-alpha).

> [!NOTE]
> For items of type Connector, the version must have the format mentioned under [Protocol version semantics](xref:ProtocolVersionSemantics).

### Supported Catalog item types

At present, the following types of Catalog items are supported:

- Automation script
- Application package
- Connector
- Visio file
