---
uid: Accessing_DMS_remotely_with_Cube
keywords: cloud connection
reviewer: Alexander Verkest
---

# Accessing your DMS remotely with DataMiner Cube

From DataMiner 10.3.0/10.3.2 onwards, you can use DataMiner Cube to access your DMS via the remote access URL, if the necessary requirements are met.<!-- RN 37841 -->

## Requirements

- The DataMiner System uses DataMiner 10.3.0/10.3.2 or higher and is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- The DataMiner System has been [configured to use HTTPS](xref:Setting_up_HTTPS_on_a_DMA).
- Prior to DataMiner 10.3.0 [CU2] and 10.3.5<!-- RN 35779 -->, the DataMiner Cube connection settings must be configured to use gRPC (see [ConnectionSettings.txt](xref:ConnectionSettings_txt)). This is no longer required in later DataMiner versions.
- The [APIGateway DxM](xref:DataMinerExtensionModules#apigateway) is installed and running on the DMA you are connecting to.
- [Remote access to Cube is enabled](xref:Controlling_remote_access) for the DMS.
- You have been [granted access to dataminer.services features](xref:Giving_users_access_to_cloud_features).
- You [have the DataMiner Cube desktop application installed](xref:Installing_the_DataMiner_Cube_desktop_application) and all [client requirements](xref:DataMiner_Client_Requirements) are met.
- Your user account has been granted access to the DataMiner System.

## Starting a remote access session with DataMiner Cube

To access the DMS remotely via Cube, use the [remote access URL](xref:Cloud_Remote_Access_URL) without the protocol prefix `https://`.

You can start the Cube session in different ways:

- **Via the desktop app on a client PC**: [Open the Cube desktop app](xref:Connecting_to_a_DMA_with_Cube) and add a new DMS. In the *host* field, fill in the remote access URL of your system, without the protocol prefix, e.g., `ziine-skyline.on.dataminer.services`. In the *alias* field, you can fill in a more user-friendly name to make it easy to identify the system.

  ![Remote Cube in the launcher](~/dataminer/images/RemoteCubeLauncher.png)

- **With the button on dataminer.services**: On a device where the Cube desktop app is installed, open a browser and navigate to [dataminer.services](https://dataminer.services). Find your DMS in the list and click the *Open in desktop app* button. This will open Cube with the correct remote access URL filled in in the host field. Then click *Connect* to connect to your DMS.

  ![Remote Cube in the home app](~/dataminer/images/CcaHomeApp.png)

  > [!NOTE]
  > If your DMS is not listed, check if the correct organization is selected in the top-right corner.

- **With the button on admin.dataminer.services**: Open a browser, navigate to [admin.dataminer.services](https://admin.dataminer.services), and go to the overview of your system. Here you will find the button *Open in desktop app*. This works in the same way as the button on dataminer.services.

  ![Remote Cube in the admin app](~/dataminer/images/RemoteCubeAdminApp.png)
