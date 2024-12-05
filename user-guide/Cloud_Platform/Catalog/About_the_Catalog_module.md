---
uid: About_the_Catalog_module
---

# About the Catalog module

As part of dataminer.services, the Catalog module allows Skyline customers and DataMiner Strategic Partners to browse and deploy available DataMiner connectors, packages, Visio drawings, Automation scripts, dashboards, and more.

![Catalog](~/user-guide/images/DataMiner_Catalog.png)<br>*DataMiner Catalog in DataMiner 10.4.6*

## Accessing the Catalog module

There are several ways to access the Catalog module:

- Go directly to <https://catalog.dataminer.services/>.

- Go to <https://dataminer.services>, [sign in](xref:Logging_on_to_the_DataMiner_Cloud_Platform), and click *Catalog* on the landing page.

- In DataMiner Cube, go to *Apps* > *Catalog* (from DataMiner 10.2.9/10.3.0 onwards).

> [!NOTE]
> While you do not have to sign in to view Catalog items, not all functionality will be available if you are not signed in. To sign in, click the button in the top-right corner of the Catalog UI.

## About Catalog items

A Catalog item is a small package that contains one or more artifacts that can be deployed on a DataMiner System. Different types of Catalog items are supported. For example, an item could be a single connector, or it could be an application package containing multiple dashboards, Automation scripts, and connectors.

### Public and private Catalog items

**Public** Catalog items are items that are available for anyone within the community to use.

**Private** Catalog items are items that are only available within your own organization. This gives users the possibility to develop app packages, Automation scripts, or any type of Catalog item and redeploy them within their organization on various systems.

### Versioning of Catalog items

Catalog items can have multiple versions. To make sure that the versioning of items is easy to understand for everyone, [semantic versioning](https://semver.org/) is recommended. Extra labels can be assigned to versions to indicate that a certain version is not an official release (e.g. 1.2.3-alpha).

For Catalog items that follow semantic versioning, versions are grouped by **range**. A range is defined by the first three indicators of a version (e.g. **7.1.2**.33).

Tags can be assigned to specific versions and ranges, for instance to indicate the main range of a connector. If you are a member of the organization that published an item, you can manage these tags via the ![Context menu button](~/user-guide/images/Catalog_context_menu.png) button for each item.<!-- RN 40030 -->

The Catalog will recommend certain versions based on the following conditions:

- The latest version of a range that is tagged as the "Main" version (visualized in green).
- The latest version of a range that is tagged with a custom tag (visualized in gray).
- If neither of the above apply, the latest version of the highest active range will be recommended.

> [!NOTE]
> Versions and ranges that are not supported (i.e. deprecated ranges and versions marked as pre-release or unlisted) are not shown by default. To view these, use the *Unsupported versions* toggle button.<!-- RN 39903 -->
