---
uid: Accessing_DMS_remotely_with_Cube
---

# Accessing your DMS remotely with DataMiner Cube

From DataMiner 10.3.0/10.3.2 onwards, you can use DataMiner Cube to access your DMS via the remote access URL, if the necessary requirements are met.<!-- RN 37841 -->

## Requirements

- The DataMiner System uses DataMiner 10.3.0/10.3.2 or higher and is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- The DataMiner System has been [configured to use HTTPS](xref:Setting_up_HTTPS_on_a_DMA).
- The DataMiner Cube connection settings have been configured to use gRPC (see [ConnectionSettings.txt](xref:ConnectionSettings_txt)).
- [Remote access is enabled](xref:Controlling_remote_access) for the DMS.
- You have been [granted access to dataminer.services features](xref:Giving_users_access_to_cloud_features).
- You [have the DataMiner Cube desktop application installed](xref:Installing_configuring_the_DataMiner_Cube_software).
- Your user account has been granted access to the DataMiner System.

> [!IMPORTANT]
> At present, the following **limitation** applies: If a DMS has **SAML** authentication configured, you will not be able to access the DMS remotely with Cube.

## Starting a remote access session with DataMiner Cube

To access the DMS remotely via Cube, use the [remote access URL](xref:Cloud_Remote_Access_URL) without the protocol prefix `https://`.

You can start the Cube session in different ways:

- **Via the desktop app on a client PC**: [Open the Cube desktop app](xref:Opening_the_desktop_app) and add a new DMS. In the *host* field, fill in the remote access URL of your system, without the protocol prefix, e.g. `ziine-skyline.on.dataminer.services`. In the *alias* field, you can fill in a more user-friendly name to make it easy to identify the system.

  ![Remote Cube in the launcher](~/user-guide/images/RemoteCubeLauncher.png)

- **With the button on dataminer.services**: On a device where the Cube desktop app is installed, open a browser and navigate to [dataminer.services](https://dataminer.services). Find your DMS in the list and click the *Open in desktop app* button. This will open Cube with the correct remote access URL filled in in the host field. Then click *Connect* to connect to your DMS.

  ![Remote Cube in the home app](~/user-guide/images/RemoteCubeHomeApp.png)

  > [!NOTE]
  > If your DMS is not listed, check if the correct organization is selected in the top-right corner.

- **With the button on admin.dataminer.services**: Open a browser, navigate to [admin.dataminer.services](https://admin.dataminer.services), and go to the overview of your system. Here you will find the button *Open Desktop Application*. This works in the same way as the button on dataminer.services.

  ![Remote Cube in the admin app](~/user-guide/images/RemoteCubeAdminApp.png)
