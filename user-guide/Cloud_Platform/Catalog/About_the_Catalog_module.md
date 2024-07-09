---
uid: About_the_Catalog_module
---

# About the Catalog module

As part of dataminer.services, the Catalog module allows Skyline customers and DataMiner Strategic Partners to browse and deploy available DataMiner connectors, packages, Visio drawings, Automation scripts, dashboards, and more.

![Catalog](~/user-guide/images/DataMiner_Catalog.png)<br>*DataMiner Catalog in DataMiner 10.4.6*

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

To make sure that the versioning of items is easy to understand for everyone, [Semver](https://semver.org/) versioning is enforced.
Extra labels can be assigned to versions to indicate that a certain version is not an official release (e.g. 1.2.3-alpha).

Catalog items can have multiple versions which are grouped by range.
Ranges will be defined by the first 3 indicators of a version (e.g. **7.1.2**.33).

The Catalog Module will recommend certain versions based on the following conditions:

- The latest version of a range that is tagged as the Main version. (visualized visualized in green)
- The latest version of a range that is tagged with a custom tag. (visualized in gray)

If the above conditions did not find any recommendations, the latest version of the highest active range will be recommended.

> [!NOTE]
> For items of type Connector, the version must have the format mentioned under [Protocol version semantics](xref:ProtocolVersionSemantics).

### Supported Catalog item types

At present, the following types of Catalog items are supported:

- Automation script
- Application package
- ChatOps Extension
- Connector
- Data API
- Data Grabber
- GQI Ad-hoc Data Source
- GQI Operator
- Life-cycle Service Orchestration
- Process Activitie
- Profile-Load Script
- Solution
- User-defined API
- Visio
