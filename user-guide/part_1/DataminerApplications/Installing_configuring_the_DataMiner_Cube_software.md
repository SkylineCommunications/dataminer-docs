## Installing & configuring the DataMiner Cube software

DataMiner Cube can either be used as a desktop application (recommended) or as a browser application in Internet Explorer or Edge. If you browse to the IP or name of your DMA using Google Chrome, Microsoft Edge (without IE compatibility mode), Mozilla Firefox or Safari, by default a landing page is displayed where you can download the desktop application. See [Installing the DataMiner Cube desktop application](#installing-the-dataminer-cube-desktop-application).

If you want to use DataMiner Cube as a browser application instead, you need to use either Internet Explorer or Microsoft Edge in IE compatibility mode. If you use Internet Explorer, we highly recommend not to use this browser for any other purpose than to access DataMiner Cube. To access the browser application, browse to the IP or name of your DMA in a compatible browser. For more information on how to configure your browser, see [Prerequisites](#prerequisites).

Once the application has been installed, each time you reopen its user interface and connect to a DataMiner Agent, the software version will be checked. If you connect to a DMA with a higher DataMiner version than your current version of Cube, Cube will automatically be updated. If the software version of a DMA changes while you are connected with Cube, a message will appear asking you to either restart (if you use the desktop app) or start a new session (if you use the browser app).

> [!NOTE]
> From DataMiner 10.0.0/10.0.2 onwards, the desktop version of DataMiner Cube runs as a 64-bit process on 64-bit systems and as a 32-bit process on 32-bit systems. If DataMiner Cube is used as a XAML browser application, it always runs as a 32-bit process.

### Prerequisites

- Make sure the client machine meets the minimum requirements detailed in the [DataMiner Client Requirements](https://community.dataminer.services/dataminer-client-requirements/).

- To run DataMiner Cube in Internet Explorer, you must correctly configure the browser so that it is both able to and allowed to run XAML browser applications. See [Configuring Internet Explorer to run DataMiner Cube](#configuring-internet-explorer-to-run-dataminer-cube).

- To run DataMiner Cube in Microsoft Edge, configure Edge to open the URL of the DMA in Internet Explorer compatibility mode. For more information, see
<https://community.dataminer.services/documentation/internet-explorer-support/>.

- If you intend to run DataMiner Cube in a browser, you are using Windows 8.1, Windows Server 2012 R2 or an earlier Windows version, and no internet connectivity is available, it is recommended to install the Skyline certificates. See [Installing the Skyline certificates](#installing-the-skyline-certificates).

> [!NOTE]
> When you connect to DataMiner using HTTPS, TLS 1.0 is required to install Cube. It is also possible to use TLS 1.1 or TLS 1.2, but in that case Microsoft .NET Framework 4.6.2 is required.

### Installing the DataMiner Cube desktop application

There are several ways to install the DataMiner Cube desktop application, depending on your DataMiner version.

##### From DataMiner 10.0.0/10.0.4 onwards:

1. Browse to your DMA using a different browser than Internet Explorer.

2. Enter your username and password to log in.

3. Install DataMiner Cube in one of the following ways:

    - Prior to DataMiner 10.0.9: To install DataMiner Cube using the ClickOnce web installer, on the landing page, click the button *Install DataMiner Cube* and select *Click-once installation*.

    - From DataMiner 10.0.9 onwards:

        1. Select *Desktop installation* and run the downloaded file.

        2. In the installation window, open the *Options* section and adjust the options depending on whether you want a shortcut to be added to the desktop and/or start menu and on whether you want DataMiner Cube to start with Windows.

        3. Click *Install*.

        > [!NOTE]
        > - Once the desktop app has been installed, it will be updated automatically when you connect to other DataMiner versions.
        > - To install the app, you need Modify access to the folders *%AppData%\\Skyline* and *%LocalAppData%\\Skyline*, as well as write access to the key *HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\<br>Uninstall*. To be able to run the app, you need Execute access for the files *%LocalAppData%\\Skyline\\DataMiner\\DataMinerCube\\DataMinerCube.exe* and *%LocalAppData%\\Skyline\\DataMiner\\DataMinerCube\\CefSharp\\version\\<br>architecture\\CefSharp.BrowserSubprocess.exe*. To create a desktop shortcut, you need Modify access to the folder *%UserProfile%\\Desktop*. To create a start menu shortcut, you need Modify access to the folder *%AppData%\\Microsoft\\Windows\\Start Menu\\Programs*.
        > - The *Start with Windows* feature requires write access to the key *HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run*.
        > - The eventing communication mode will only be available if the firewall allows the application *%LocalAppData%\\Skyline\\DataMiner\\DataMinerCube\\<br>DataMinerCube.exe* to accept incoming connections.

    - It is also possible to install DataMiner Cube using an MSI installer, but this is not recommended as this requires manual updating when a new version is available:

        1. On the landing page, click the button *Install DataMiner Cube* and select *Other install options*.

        2. In the *Standalone applications* section, click the *MSI installer* option for DataMiner Cube.

##### From DataMiner 10.0.2 onwards:

If you browse to your DMA using a browser that does not support DataMiner Cube, depending on your configuration, a landing page will be displayed.

On the landing page, click the user icon in the top-right corner and select the DataMiner Cube installation option you prefer under *Standalone applications*.

##### Prior to DataMiner 10.0.0/10.0.2:

On the landing page, click *Install DataMiner Cube*.

Alternatively, go to *http://\[DMA name\]/DataminerCubeStandalone/publish.htm* and click *Install*.

> [!TIP]
> See also:
> [Configuring the default landing page](../../part_3/DataminerAgents/DMA_configuration_related_to_client_applications.md#configuring-the-default-landing-page)

> [!NOTE]
> Once you have installed the application, it will automatically be updated whenever a new version is available.

### Cleaning up the DataMiner Cube desktop app cache

From DataMiner 10.1.9/10.2.0 onwards, you can remove cached Cube versions and empty the Visio or protocol cache in the start window of the DataMiner Cube desktop application.

To do so:

1. Click the cogwheel button in the lower right corner of the start window and select *Cleanup*.

2. In the list of cached Cube versions, select the versions you want to remove from the cache.

3. To empty the Visio cache and/or protocol cache, select the relevant checkbox(es).

4. Click *Clean*.

### Uninstalling the DataMiner Cube desktop application

If you have installed the DataMiner Cube desktop application using the installer available from DataMiner 10.0.9 onwards, you can uninstall the application as follows:

1. Open the *Programs and Features* control panel.

2. Select DataMiner Cube in the list.

3. Click the *Uninstall* button.

Alternatively, you can uninstall the DataMiner Cube desktop application by running the following command:

```txt
"%LocalAppData%\Skyline\DataMiner\DataMinerCube\DataMinerCube.exe" /Uninstall
```

### Changing the default browser engine used in DataMiner Cube

From DataMiner 9.6.3 onwards, you can change the default browser engine used in DataMiner Cube.

To do so:

1. In the *System Center* module, go to *System settings* > *plugins*.

2. Select a specific default engine, or select the option to let Cube determine the default engine.

    - Prior to DataMiner 10.0.10, the default browser engine is Internet Explorer. From DataMiner 10.0.10 onwards, if Chromium is installed, the default browser engine changes to Chromium. In addition, DataMiner apps displayed within an embedded web browser in DataMiner Cube (e.g. Ticketing, Dashboards, etc.) will always use the Chromium browser engine, regardless of which default browser engine is configured.

    - From DataMiner 10.1.11/10.2.0 onwards, you can select to use *Edge* (WebView2). This browser engine has the advantage that web content is rendered directly to the graphics card and proprietary codecs such as H.264 and AAC are supported. In addition, the browser engine automatically receives updates via Windows Update, regardless of the DataMiner or Cube version.

        > [!NOTE]
        > The WebView2 Runtime is automatically installed with Office 365 Apps and/or Windows 11. It is not included in DataMiner upgrade packages.

3. Optionally, if you want a different browser to be used for a specific protocol or (prior to DataMiner 10.0.10) app:

    1. Below *Exclusions*, click *Add exclusion* and select either *Protocol* or the name of the app.

    2. For a protocol, click *\<protocol>* and select the name of the protocol.

    3. Next to *Engine*, select the engine that should be used for this protocol or app.

    > [!NOTE]
    > From DataMiner 10.0.10 onwards, it is no longer possible to specify a different browser for apps.

4. Click the *Apply* button in the lower right corner to save your changes.

### Configuring Internet Explorer to run DataMiner Cube

Before you can run the DataMiner Cube browser application in Microsoft Internet Explorer, a number of settings must be configured.

#### Adding the DataMiner Cube URL to the “Local intranet” zone

1. In Microsoft Internet Explorer, select *Tools \> Internet Options*.

2. In the *Security* tab, select the *Local intranet* zone and click *Sites*.

3. In the *Local intranet* dialog box, click *Advanced*.

4. Enter the URL in the *Add this website to the zone* box, click *Add* and then click *Close*.

#### Configuring the XBAP settings in Microsoft Internet Explorer

If you want to run the DataMiner Cube client application in Microsoft Internet Explorer, the latter should be allowed to run XAML browser applications.

1. In Microsoft Internet Explorer, select *Tools \> Internet Options*.

2. In the *Security* tab, select the appropriate zone and click *Custom level...*

3. In the *Security Settings* dialog box, go to *.NET Framework*.

4. Set *XAML browser applications* to “Enable”.

#### If you plan to use Microsoft Internet Explorer 64-bit edition

If you intend to run DataMiner Cube in the 64-bit version of Microsoft Internet Explorer, do the following.

1. Open the 64-bit version of Microsoft Internet Explorer.

2. Go to the following address: *http://\[DMA\]/DataminerCubeStandAlone/Publish.htm,* replacing “\[DMA\]” by the IP address or the hostname of the DataMiner Agent you want to connect to.

### Installing the Skyline certificates

Installing the Skyline certificates is only required if you intend to run DataMiner Cube in a browser, you are using Windows 8.1, Windows Server 2012 R2 or an earlier Windows version, and no internet connectivity is available.

1. Open your internet browser, and go to the following address: *http://\[DMA\]/tools*.

2. Click *Register Skyline Certificates*.

3. In the *File Download* dialog box, click *Run*.

> [!NOTE]
> - In the above-mentioned address, replace “\[DMA\]” by the IP address or the hostname of the DataMiner Agent you want to connect to.
> - If you do not install the Skyline certificates, you will get a “Trust not granted” error. See [Trust not granted](../../part_6/ErrorMessages/Trust_not_granted.md).
>
