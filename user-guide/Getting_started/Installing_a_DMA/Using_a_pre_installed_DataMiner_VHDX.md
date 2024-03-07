---
uid: Using_a_pre_installed_DataMiner_VHDX
---

# Using a pre-installed DataMiner Virtual Hard Disk

You can download a Virtual Hard Disk (VHDX) with DataMiner pre-installed to immediately get started.
This VHDX comes out-of-the box with a [locally hosted Cassandra Cluster and OpenSearch, running on Windows Subsystem for Linux (WSL)](xref:Local_database_on_WSL).

> [!NOTE]
> Running an out-of-the box deployment with the [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_VHDX) should only be used for test and staging environments when sufficient resources have been given to the Virtual Machine. Consider migrating to [Storage as a Service (STaaS)](xref:STaaS) or [configure dedicated clustered storage](xref:Configuring_dedicated_clustered_storage) if you intend to use it in production.

## Configure the DataMiner system

Once you deployed your DataMiner system in your chosen virtualization environment, you will need to follow the steps outlined below.

> [!NOTE]
> All steps require access to the Windows environment. The default credentials are: **Administrator** / **DataMiner123!**

> [!IMPORTANT]
> For security reasons, it is strongly advised to change the default credentials.

### Request and set the DataMiner ID

The DataMiner ID uniquely identifies your DataMiner Agent.
To get a DataMiner ID, contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be).
Once you received your unique ID, do the following:

1. Open the *C:\Skyline DataMiner\\* folder.
1. Open the *DataMiner.xml* file.
1. Find the *&lt;DataMiner&gt;* tag and locate the *id* attribute.
1. In the *id* attribute, fill in the DataMiner ID you received.
1. Save and close the file.

### Request and configure a DataMiner license

To start DataMiner, a license is required.
To request a license:

1. Open the *C:\Skyline DataMiner\\* folder.
1. Remove all *\*.lic* files, if any.
1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).
1. After a short while, a *Request.lic* file should appear in the *C:\Skyline DataMiner\* folder.
1. [Obtain your DataMiner license](xref:DataminerLicenses).
1. Once you received the *dataminer.lic* and *clientapps.lic* files from Skyline, copy them to the *C:\Skyline DataMiner\\* folder.
1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

### Login to your DataMiner agent

At this point you should be able to login with the credentials you used to login on the Virtual Machine that was created from the Virtual Hard Disk.

For more information, see: [Logging on to DataMiner Cube](xref:Logging_on_to_DataMiner_Cube).
