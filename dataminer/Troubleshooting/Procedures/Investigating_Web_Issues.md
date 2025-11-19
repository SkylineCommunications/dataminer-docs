---
uid: Investigating_Web_Issues
---

# Troubleshooting – web

> [!TIP]
> For a flowchart for troubleshooting web apps based on a recording, see [Troubleshooting - web apps](xref:Troubleshooting_Webapps).

## Client web app

Is something not working as expected? Then do the following:

1. Open the F12 development tools of the browser.
1. Refresh the web page. Long-click the refresh button and select *Empty cache and hard refresh*.
1. Reproduce the issue.
1. Check the F12 window:

   - Does the webpage not load? Does it show a *Service Unavailable* error?

     This could mean that the [IIS web server](#iis-web-server-w3wp) is not running or that the cloud connection has been lost.

   - Are there any network calls failing (e.g. `GetVisioForElement`)?

     This could indicate an issue in the [web APIs](#web-apis) or in the DMA core software.

   - Are there any console errors?

     This could indicate an issue in the client web app.

## Web APIs

- Does a web API method return an incorrect result? Then do the following:

  1. Open the *SLNet Client Test* tool, connect to the DMA, and follow the HTML5 connection of the WebAPI.
  1. Reproduce the issue.
  1. In the *Client Test* tool, investigate whether the unexpected result comes from the DMA core software.

     - When you ask for support by email, include the *SLNet Client Test* tool dump and, if the issue is caused by the DMA core software, a [Log Collector](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages) package.

     - If you cannot determine whether it is a DMA core issue or a web API issue, then collect the requests/responses of the web API by saving them as a HAR file (in the F12 developer tools of Google Chrome) or by capturing them using Wireshark.

- The web API process runs inside IIS w3wp. Does this w3wp process crash, request a timeout or return an error page?

  Investigate the events in Windows Event Viewer (included in a [Log Collector](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages) package).

- The web API has [separate logging](xref:Dashboards_and_Low_Code_Apps_Logging#web-api-logging) that can give more information about certain errors that occur.

## Web DcM

Logging for the [Web DcM](xref:DataMinerExtensionModules#web) is available in `C:\ProgramData\Skyline Communications\DataMiner Web\Logs`.

## IIS web server (w3wp)

### Error page

1. In Server Manager, check whether the IIS web server is installed.
1. In Server Manager, check whether ASP.NET 4.8 is installed.
1. Check whether all Windows updates are installed.
1. Check whether the [URL Rewrite](https://www.iis.net/downloads/microsoft/url-rewrite) module is installed.
1. Check whether the [Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing) module is installed.
1. Run `C:\Skyline DataMiner\Tools\ConfigureIIS.bat` as Administrator.
1. Check whether the *w3wp* process is running.

### Crash

Check the logging in Windows Event Viewer (included in a [Log Collector](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages) package), or create a memory dump (`procdump -ma -g -e 1 w3wp.exe`).

If the process crashes several times (i.e. more than the configured maximum within the configured interval (*Rapid-Fail Protection*)), then IIS will shut it down and a manual action will be needed to start it again.

### High CPU/memory

This is often due to the protocol cache not working properly, resulting in protocols being requested from the DMA in rapid succession. A lot of resources are then wasted on deserializing protocol objects and performing garbage collection.

Check if the w3wp process has read+write access to the cache (`%appdata%\Skyline\DataMiner\Cache\`).

### No WebSocket connection

1. In Server Manager, check whether the WebSocket protocol is installed?
1. In `C:\Skyline DataMiner\Webpages\API\web.config`, check whether the `targetFramework` attribute of the `<httpRuntime>` element is set to version 4.6.2 (or higher)?
1. Is everything working locally on the DMA, but not externally? Then a firewall in the network might block WebSocket communication.

## Features

### Trending

The *SLNet Client Test* tool contains a *Trend Data Inspector* (*Advanced > Tests*). Verify whether the data corresponds with the data drawn in the web apps.

- The DMA should return the last point (note that there might be a gap) that is still valid on the requested start time.
- The DMA should determine which type of trend data is available for the requested timespan (5, 60 or 120 points).
- The web app should draw the last value until the current time (unless the specified end time is before the current time or the intervals are fixed).

### GQI

GQI runs as an extension module ([GQI DxM](xref:GQI_DxM)) or inside the [SLHelper](xref:Troubleshooting_SLHelper_exe) process.

- Are data sources missing? Check whether the DMA has the necessary licenses and soft-launch options.
- Are there no errors, but invalid data? Check the origin of the invalid data.
- Are ad-hoc data sources or operators failing? Contact the person who created the data source or the operator (check [GitHub](https://github.com/orgs/SkylineCommunications/repositories?q=gqi&type=all)).
- Error messages, no data, no response, or slow performance? Then [record the GQI session](#record-gqi-session) and include the ad hoc data scripts (if any) when asking support.
- GQI DxM not working? Try to [repair the service](#gqi-dxm-repair).

> [!NOTE]
> The troubleshooting procedures below require access to the DataMiner server. If you are using a DaaS system, this is not possible, and you will need to contact <daas@dataminer.services> instead.

#### Record GQI session

> [!NOTE]
> Recording is not supported with the [GQI DxM](xref:GQI_DxM).

GQI recording is a debugging feature that allows you to save GQI communication and replay it in a lab environment. GQI recording is disabled by default. To create a recording, do the following:

1. Create the `C:\Skyline DataMiner\logging\genif` folder.
1. Perform the operation that needs to be recorded.
1. Save the files that were written to `C:\Skyline DataMiner\logging\genif`.
1. Stop the recording by deleting the folder.

> [!NOTE]
> Recording might impact performance as data is written to the disk. Once the recording has been made, stop the recording by deleting the folder.

#### GQI DxM repair

If you encounter issues with GQI DxM, for example, if you have [enabled the GQI DxM](xref:GQI_DxM#enabling-or-disabling-the-use-of-the-gqi-dxm) but are unable to see GQI DxM version on the *About* page, try repairing the service by running the GQI DxM installer:

1. Using Task Manager, stop the DataMiner GQI service.

   > [!NOTE]
   > Make sure the associated DataMiner GQI process is stopped as well.

1. Navigate to `C:\Skyline DataMiner\Tools\ModuleInstallers\Web`.

1. Run the *DataMiner GQI* DxM installer in Repair mode.

   ![GQI installer repair mode](~/dataminer/images/repair_gqi_installer.png)

1. Restart the web server using IIS Manager to reconnect the web apps with the GQI DxM.

   > [!TIP]
   > For more detailed information, refer to [How to restart Internet Information Services (IIS) for a Website in Windows Server](https://www.ipserverone.info/knowledge-base/how-to-restart-internet-information-services-iis-for-a-website-in-windows-server/).

### PDF

From DataMiner web 10.5.0 [CU8]/10.5.11 onwards, PDFs are generated by the [Web DcM](xref:DataMinerExtensionModules#web). If it fails to generate a PDF, check the logging in `C:\ProgramData\Skyline Communications\DataMiner Web\Logs`.<!-- RN 43439 -->

In earlier DataMiner versions, PDFs are generated by [SLHelper](xref:Troubleshooting_SLHelper_exe). If it fails to generate a PDF, check the following log files:

- `SLPdfBuilder.txt`
- `SLHelperWrapper.txt`
- `SLNet.txt`

### Email

If there are issues related to the sending of emails, check the following log file: `SLASPConnection.txt`.

Also check the [email configuration](xref:Configuring_outgoing_email) in `DataMiner.xml`.

### Sharing

#### Failed saving WAF rules

From DataMiner web 10.5.0 [CU8]/10.5.11 onwards, WAF rule books are generated by the [Web DcM](xref:DataMinerExtensionModules#web). In earlier DataMiner versions, they are generated by [SLHelper](xref:Troubleshooting_SLHelper_exe).

- Does the DMA use HTTPS? Is the certificate not expired and trusted?
- Is the HTTPS configuration correct in the `MaintenanceSettings.xml` file?

  On the DMA, open a browser and navigate to the Dashboards app using the FQDN configured in the `MaintenanceSettings.xml` file. Does the app open? If not, you might have to configure the FQDN in the Windows hosts file so that the FQDN resolves to the server.

- Go to `http(s)://dma/dashboard/#/whitelist` and select the dashboard you want to share. Does this show a rulebook or an error message?

#### Opening a shared dashboard from an email

Do you keep getting *"We're getting things ready... This won't take long."*? This should not take longer than a few minutes. If you keep getting this message, the WAF rules might not get saved.

- Is it still possible to share a dashboard (as this will generate a WAF rulebook)?
- Does IIS have permission to write in `C:\Skyline DataMiner\Webpages\Dashboard`?
- If DataMiner web 10.5.0 [CU8]/10.5.11 or higher is used, are there any errors in the logging of the Web DcM (`C:\ProgramData\Skyline Communications\DataMiner Web\Logs`)?
- If an earlier DataMiner web version is used, in the *SLNet Client Test* tool, follow the newly created HTML5 connection. Does it return any errors?

### Visual Overview (in web apps)

Visual Overview in web apps has limited functionality:

- Visual Overview pages are rendered as images containing clickable regions. As a result, some features (e.g. embedding) and some session variable controls are not fully supported.

- To render a Visual Overview page, [SLHelper](xref:Troubleshooting_SLHelper_exe) loads a virtual instance of DataMiner Cube in its memory. Initial loading of a page can take a long time because SLHelper needs to start Cube, connect to a DMA, and then generate an image.

- SLHelper may use a significant amount of memory to display Visual Overview pages, especially when multiple users are connected. When Visual Overview pages are not viewed by any user, the virtual DataMiner Cube instance is terminated after a timeout of 5 minutes and the memory is released.

- When multiple users with different security contexts are logged in to the same DataMiner Agent, performance can be impacted as all updates for visual overviews shown in the web apps are handled by that one Agent. From DataMiner 10.5.0 [CU1]/10.5.2 onwards<!--RN 41434-->, you can implement [load balancing](#load-balancing) to distribute these updates across multiple Agents in the DMS. This reduces the load on any single Agent, but updates for each user will still be handled by the same Agent based on their security context.

- Visual Overview pages are displayed only after all images have loaded, or after a one-minute timeout. If some shapes on the page fail to load and have inherited the *EnableLoading=True* setting from a parent shape or the page itself (from DataMiner 10.4.0 [CU12]/10.5.0/10.5.3 onwards<!--RN 41517-->), the page may not appear until the one-minute timeout is reached. For more information on how to disable this setting, see [Disabling the indication that a page or shape is loading](xref:Disabling_the_Loading_message_for_a_page_or_shape).

- Prior to DataMiner 10.5.4/10.6.0, if no user-specific information (i.e. user context) is required in a visual overview, the system tries to reuse server-side cards across different users. This may cause incorrect user information to be shown, especially when displaying pop-up windows or embedded visual overviews. From DataMiner 10.5.4/10.6.0 onwards<!--RN 42061-->, a separate card is created for each user. When a user opens a new visual overview in a web app, a new card is generated specifically for them, so that the correct user information is always shown.

If you encounter any issues or if you notice any behavior that is different from that in Cube, then check the `SLUIProvider.txt` and `SLHelperWrapper.txt` log files. Always include the Visio file when you ask for support by email.

On mobile devices, Visual Overview pages automatically subscribe to all alarms. From DataMiner 10.4.0 [CU10]/10.5.0/10.5.1 onwards<!--RN 41327-->, if no alarm information is needed when a visual overview is shown, you can configure alarm subscriptions to be skipped by setting the `helper:load-alarms` option to "false" in `C:\Skyline DataMiner\Files\SLHelper.exe.config`.

For example:

```xml
<configuration>
    ...
    <appSettings>
        ...
        <add key="helper:load-alarms" value="false"/>
        ...
      </appSettings>
    ...
</configuration>
```

> [!NOTE]
> When `helper:load-alarms` is set to "false", no alarms will be loaded, even when a visual overview needs alarm information to render correctly.

#### Load balancing

From DataMiner 10.5.2/10.6.0 onwards<!--RN 41434-->, you can implement load balancing for visual overviews shown in web apps among DataMiner Agents in a DMS. Prior to this, the DataMiner Agent to which you were connected would handle all requests and updates with regard to web visual overviews.

To configure load balancing, in the `C:\Skyline DataMiner\Webpages\API\Web.config` file of a particular DataMiner Agent, add the following keys in the `<appSettings>` section:

- `<add key="visualOverviewLoadBalancer" value="true" />`

  Enables or disables load balancing on the DataMiner Agent in question.

  - When this key is set to "true", for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will by default be handled in a balanced manner by all the DataMiner Agents in the cluster.

    However, if you also add the `dmasForLoadBalancer` key (see below), these requests and updates will only be handled by the DataMiner Agents specified in that `dmasForLoadBalancer` key.

  - When this key is set to "false" or is removed, for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will be handled by the local SLHelper process.

- `<add key="dmasForLoadBalancer" value="1;2;15" />`

  If you enabled load balancing by setting the `visualOverviewLoadBalancer` key to "true", you can use this key to restrict the number of DataMiner Agents that will be used for visual overview load balancing.

  The key's value must be set to a semicolon-separated list of DMA IDs. For example, if the value is set to "1;2;15", the DataMiner Agents with ID 1, 2, and 15 will be used to handle all requests and updates with regard to visual overviews shown in web apps.

  If you only specify one ID (without trailing semicolon), only that specific DataMiner Agent will be used to handle all requests and updates with regard to web visual overviews.

> [!NOTE]
> These settings are not synchronized among the Agents in the cluster.

### Maps

Check the `C:\Skyline DataMiner\Maps\ServerConfig.xml` file:

- Is the app version correct?
- Is a maps provider configured?
- Are the API keys valid for the FQDN the map is opened with?
