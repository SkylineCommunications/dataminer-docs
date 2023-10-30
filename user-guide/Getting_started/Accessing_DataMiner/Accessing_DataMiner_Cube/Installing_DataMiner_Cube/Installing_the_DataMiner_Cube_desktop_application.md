---
uid: Installing_the_DataMiner_Cube_desktop_application
---

# Installing the DataMiner Cube desktop application

## Standard installation

### [From DataMiner 10.0.9 onwards](#tab/tabid-1)

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

### [Prior to DataMiner 10.0.9](#tab/tabid-2)

1. Browse to the IP or hostname of your DMA or to `https://[Your DMA]/root`, depending on your configuration.

   > [!TIP]
   > See also: [Configuring the landing page of a DMA](xref:Configuring_the_landing_page)

1. Install Cube in one of the following ways, depending on your DataMiner version:

   - From DataMiner 10.0.4 onwards, on the landing page, click the button *Install DataMiner Cube* and select *Click-once installation*.

   - Prior to DataMiner 10.0.4, on the landing page, click the user icon in the top-right corner and select the DataMiner Cube installation option you prefer under *Standalone applications*.

***

## MSI installation

From DataMiner 10.2.0/10.2.2 onwards, it is also possible to install DataMiner Cube using an **MSI installer**, but this is **not recommended as this requires manual updating** when a new version is available. Typically, this is used by a system administrator to deploy DataMiner Cube in bulk on many client machines at the same time using some form of automation. The MSI installer can be found in the folder `C:\Skyline DataMiner\Webpages\Tools\Installs` on each DMA.

> [!NOTE]
>
> - If you install DataMiner Cube with the MSI installer, you will also have to manually install the corresponding CefSharp version using the separate CefSharp MSI installation package, which is available on demand.
> - Prior to DataMiner 10.0.9, the MSI installer is available via the DataMiner landing page, via *Install DataMiner Cube* > *Other install options* > *MSI installer*.
> - The upgrade packages for the Main Release track contain the MSI installer for the latest Feature Release version of DataMiner Cube.
