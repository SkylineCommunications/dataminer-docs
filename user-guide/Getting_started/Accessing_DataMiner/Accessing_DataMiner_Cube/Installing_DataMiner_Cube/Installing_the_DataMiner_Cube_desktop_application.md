---
uid: Installing_the_DataMiner_Cube_desktop_application
description: Log on to dataminer.services, select 'Desktop installation' and run the downloaded file. Adjust the options if necessary, and click 'Install'.
---

# Installing the DataMiner Cube desktop application

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>Before you install DataMiner Cube, make sure the client machine meets the minimum requirements detailed in the <a href="xref:DataMiner_Client_Requirements" style="color: #657AB7;">DataMiner Client Requirements</a>.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

## Standard installation

1. Log on to [dataminer.services](xref:Logging_on_to_the_DataMiner_Cloud_Platform).

   > [!NOTE]
   > Alternatively, you can also browse to the IP or hostname of your DMA or to `https://[Your DMA]/root` and log in there, depending on your [configuration](xref:Configuring_the_landing_page).

1. Select *Desktop installation* and run the downloaded file.

1. In the installation window, open the *Options* section and adjust the options depending on whether you want a shortcut to be added to the desktop and/or start menu and on whether you want DataMiner Cube to start with Windows.

1. Click *Install*.

> [!NOTE]
>
> - Once the desktop app has been installed, it will be updated automatically when you connect to other DataMiner versions.
> - Administrators can [enforce the use of a specific Cube version](xref:DMA_configuration_related_to_client_applications#managing-client-versions) when you connect to a DMA.

## MSI installation

From DataMiner 10.2.0/10.2.2 onwards, it is also possible to install DataMiner Cube using an **MSI installer**, but this is **not recommended as this requires manual updating** when a new version is available. Typically, this is used by a system administrator to deploy DataMiner Cube in bulk on many client machines at the same time using some form of automation. The MSI installer can be found in the folder `C:\Skyline DataMiner\Webpages\Tools\Installs` on each DMA.

> [!NOTE]
>
> - If you install DataMiner Cube with the MSI installer, you will also have to manually install the corresponding CefSharp version using the separate CefSharp MSI installation package, which is available on demand.
> - The upgrade packages for the Main Release track contain the MSI installer for the latest Feature Release version of DataMiner Cube.
