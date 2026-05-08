---
uid: DH_Installation
---

# Installing dataminer.DocumentHub

To install dataminer.DocumentHub:

1. Look up the [Document Hub package](https://catalog.dataminer.services/details/f9720b2e-fdaa-4956-9788-877328b587ca) in the DataMiner Catalog.

1. Check the prerequisites mentioned in the Document Hub [release notes](xref:Document_Hub_RNs_index) matching the package version, and make sure your system meets these prerequisites.

   > [!NOTE]
   > Minimum platform requirement: DataMiner 10.6.3 and above.

1. When all prerequisites are met, click the *Deploy* button.

   > [!TIP]
   > For more details on deploying items from the Catalog, see [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).

During the installation, the following steps will automatically be executed:

1. Prerequisite check.
1. Install/Update automation scripts.
1. Install/Update applications.
1. Install/Update DOM definitions.
1. Install/update DevPack (SDM API Helpers).
1. Initialize the system (fresh install).
1. Migration actions (if any).
1. Cleanup actions (if any).

Migration and cleanup actions are defined in the install package and will depend on the version you install. To make sure that these actions do not keep growing indefinitely over the different versions, the **migration and cleanup actions are cleaned in every major version** (e.g. from 1.x.x to 2.x.x).

> [!IMPORTANT]
> When upgrading Document Hub, to make sure all migration and cleanup actions take place, **first upgrade to the latest version of your current major version** before moving to the next major version, without skipping a major version.

## Post-installation configuration

After the installation completes, you will need to configure the Document Hub app for your environment:

1. Open the Document Hub app from the DataMiner Web interface.

1. Navigate to the **Settings** section.

1. Configure your storage backend:
   - Connect to your SharePoint repository, configure your DOM attachments or use the standard DataMiner Webfiles.
   - Provide the necessary credentials and access information (if applicable).

1. Define document **Buckets** to organize file types:
   - Specify the target storage backend for each bucket.
   - Define allowed file extensions.
   - Set bucket rules to keep files organized.

> [!TIP]
> Refer to the [Document Hub app](xref:DH_Application) documentation for detailed configuration instructions.
