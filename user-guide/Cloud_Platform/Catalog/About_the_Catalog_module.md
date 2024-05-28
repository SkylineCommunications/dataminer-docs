---
uid: About_the_Catalog_module
---

# About the Catalog module

## Accessing the Catalog module

As part of dataminer.services, the Catalog module allows Skyline customers and DataMiner Strategic Partners to browse and deploy available DataMiner connectors, packages, Visio drawings, Automation scripts, dashboards, and more.

To access the Catalog module:

1. Go to <https://dataminer.services>, and [sign in](xref:Logging_on_to_the_DataMiner_Cloud_Platform).

1. On the dataminer.services landing page, click *Catalog*.

> [!TIP]
> From DataMiner 10.2.9/10.3.0 onwards, you can navigate directly to the catalog from DataMiner Cube by selecting *Catalog* in the *Apps* pane.

## About Catalog items

A Catalog item is a small package that contains one or more artifacts that can be deployed on a DataMiner system. For example an item could be a single connector or it could be an Application Package containing multiple dashboards, automation scripts and connectors.

You can find the different types of Catalog items we support [here](xref:About_the_Catalog_module#supported-catalog-item-types).

### Public and private Catalog items

Public Catalog items are items that are available for anyone within the community to use.

Private Catalog items are items that are only available within your own organization. This gives users the possibility to develop app packages, Automation scripts or any type of Catalog item and redeploy them within their organization on various systems.

### Versioning of Catalog items

Catalog items can hold multiple versions. To make sure that the versioning of items is easy to understand for everyone, [Semver](https://semver.org/) versioning is enforced. Users can assign extra labels to versions if they want to indicate that a certain version is not an official release (e.g. 1.2.3-alpha).

> [!WARNING]
> If the item is of type Connector, you will need to adhere to the [existing connector versioning](xref:ProtocolVersionSemantics).

### Supported Catalog item types

- Automation script
- Application package
- Connector
- Visio file
