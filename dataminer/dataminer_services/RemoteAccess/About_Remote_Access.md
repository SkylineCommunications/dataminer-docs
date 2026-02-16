---
uid: About_Remote_Access
keywords: remote access to the cloud, cloud connection
reviewer: Alexander Verkest
---

# About remote access

When a DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), administrators can [enable remote access](xref:Controlling_remote_access) so that users can access the DataMiner System from anywhere.

With this feature, users can:

- Use the [remote access URL](xref:Cloud_Remote_Access_URL) (e.g., `https://ziine-skyline.on.dataminer.services/`) to [access the DataMiner web apps](xref:Accessing_web_apps_remotely).

- Use the remote access URL to [access the DMS via DataMiner Cube](xref:Accessing_DMS_remotely_with_Cube).

- [Call a user-defined API](xref:UD_APIs_Triggering_an_API#url) through dataminer.services.

- Access files on the DMA that have been made available for remote access.<!-- RN 38426 -->

  The files that are available for public access are located in the following folders on the DMA:

  - `C:\Skyline DataMiner\Webpages\public\`

    To access these files, use the remote access URL followed by `/public/` (e.g., the file *image.png* via `https://ziine-skyline.on.dataminer.services/public/image.png`).

    > [!NOTE]
    > Files in the folder `C:\Skyline DataMiner\Webpages\public\` will be hosted without authentication on the internal network of a DMA. However, only authenticated members of the DMS will be able to access them via remote access.

  - `C:\Skyline DataMiner\Documents\`

    This is the folder containing the [documents](xref:About_the_Documents_module) available within DataMiner Cube.

    To access these files, use the remote access URL followed by `/Documents/`<!-- RN 39182 + 39881-->
