---
uid: Cloud_Remote_Access
---

# Remote access

When a DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), administrators can [enable remote access](xref:Controlling_remote_access) so that users can access the DataMiner System from anywhere.

With this feature, users can:

- Use the [remote access URL](xref:Cloud_Remote_Access_URL) (e.g. `https://ziine-skyline.on.dataminer.services/`) to [access the DataMiner web apps](xref:Accessing_web_apps_remotely).

- Use the remote access URL to [access the DMS via DataMiner Cube](xref:Accessing_DMS_remotely_with_Cube).

- Access files or webpages on the DMA that have been made available for remote access.<!-- RN 38426 -->

  To access such files, use the remote access URL followed by `/public/` (e.g. the file *image.png* via `https://ziine-skyline.on.dataminer.services/public/image.png`).

  To make files or webpages available for remote access, add them in the folder `C:\Skyline DataMiner\Webpages\public\` on the DMA.
  
  > [!NOTE]
  > Files in the folder `C:\Skyline DataMiner\Webpages\public\` will be hosted without authentication on the internal network of a DMA. However, only authenticated members of the DMS will be able to access them via remote access.
