---
uid: Installing_the_DataMiner_Cube_desktop_application
description: Log on to dataminer.services, select 'Desktop installation' and run the downloaded file. Adjust the options if necessary, and click 'Install'.
---

# Installing DataMiner Cube

> [!TIP]
> Before you install DataMiner Cube, make sure the client machine meets the minimum requirements detailed in the [DataMiner Client Requirements](xref:DataMiner_Client_Requirements).

You can follow the installation steps below or watch this short video, which walks you through the installation process and provides a quick overview of the Cube [user interface](xref:Cube_UI_components):

<div style="width: 100%; max-width: 800px;">
  <video style="width: 100%; aspect-ratio: 16 / 9; height: auto;" controls>
    <source src="~/dataminer/images/Getting_Started_With_Cube.mp4" type="video/mp4">
  </video>
</div>

## Standard installation

1. Log on to [dataminer.services](xref:Logging_on_to_dataminer_services).

   > [!NOTE]
   > Alternatively, you can also browse to the IP or hostname of your DMA or to `https://[Your DMA]/root` and log in there, depending on your [configuration](xref:Configuring_the_landing_page).

1. Select *Desktop installation* and run the downloaded file.

1. In the installation window, open the *Options* section and adjust the options depending on whether you want a shortcut to be added to the desktop and/or start menu and on whether you want DataMiner Cube to start with Windows.

1. Click *Install*.

> [!NOTE]
>
> - Once the desktop app has been installed, it will be updated automatically when you connect to other DataMiner versions.
> - Administrators can [enforce the use of a specific Cube version](xref:DMA_configuration_related_to_client_applications#managing-client-versions) when you connect to a DMA.

## DataMiner Taskbar Utility

From DataMiner 10.5.2/10.6.0 onwards<!--RN 41308-->, it is also possible to install DataMiner Cube using [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility).

1. Right-click the *DataMiner Taskbar Utility* icon in the system tray.

1. Select *Launch* > *Download DataMiner Cube*.

1. Open your downloads folder and locate the *DataMinerCube.exe* file.

1. Double-click the file to start the installation process.

1. Follow the prompts to confirm that you want to install the application.

Once installed, DataMiner Cube will launch automatically and open a session connected to the local DMA.

> [!NOTE]
> If you attempt to install the *DataMinerCube.exe* file while DataMiner Cube is already installed, the existing Cube desktop app will open. Additionally, if a tile representing the local DMA does not already exist, it will be added automatically.

## MSI installation

From DataMiner 10.2.0/10.2.2 onwards, it is also possible to install DataMiner Cube using an **MSI installer**, but this is **not recommended as this requires manual updating** when a new version is available. Typically, this is used by a system administrator to deploy DataMiner Cube in bulk on many client machines at the same time using some form of automation. The MSI installer can be found in the folder `C:\Skyline DataMiner\Webpages\Tools\Installs` on each DMA.

> [!NOTE]
>
> - If you install DataMiner Cube with the MSI installer, you will also have to manually install the corresponding CefSharp version using the separate CefSharp MSI installation package. See [CefSharp MSI](xef:DataMiner_Cube_deployment_methods#cefsharp-msi).
> - The upgrade packages for the Main Release track contain the MSI installer for the latest Feature Release version of DataMiner Cube.
