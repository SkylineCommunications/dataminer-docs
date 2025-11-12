---
uid: MO_Installation
---

# Installing MediaOps

To install dataminer.MediaOps:

1. Look up the [MediaOps package](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) in the DataMiner Catalog.

1. Find the **prerequisites** (matching the version of the package) in the MediaOps [Release Notes](https://docs.dataminer.services/release-notes/MediaOps_RNs_index.html), and make sure your system meets these prerequisites.

1. When all prerequisites are met, click the *Deploy* button.

   > [!TIP]
   > For more details on deploying items from the Catalog, see [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).

During the installation, the following steps will automatically be executed:

1. Prerequisite check.
1. Install/Update Automation scripts.
1. Install/Update applications.
1. Install/Update DOM definitions.
1. Initialize the system (fresh install).
1. Migration actions (if any).
1. Cleanup actions (if any).

Migration and cleanup actions are defined in the install package and will depend on the version you install. To make sure that these actions do not keep growing indefinitely over the different versions, the **migration and cleanup actions are cleaned in every major version** (e.g. from 1.x.x to 2.x.x).

> [!IMPORTANT]
> When upgrading MediaOps, to make sure all migration and cleanup actions take place, **first upgrade to the latest version of your current major version** before moving to the next major version, without skipping a major version.
