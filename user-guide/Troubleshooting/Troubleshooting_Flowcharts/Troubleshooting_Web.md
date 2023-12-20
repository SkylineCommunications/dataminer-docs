---
uid: Troubleshooting_Web
---

# Troubleshooting - web

## Client web app

Is something not working as expected? Then do the following:

1. Open the F12 development tools of the browser.
1. Refresh the web page. Long-click the refresh button and select *Empty cache and hard refresh*.
1. Reproduce the issue.
1. Check the F12 window:

   - Does the webpage not load? Does it show a *Service Unavailable* error?

     This could mean that the [IIS web server](#iis-web-server-w3wp) is not running or that the cloud connection has been lost.

   - Are there any network calls failing (e.g. `GetVisioForElement`)?

     This could indicate an issue in the [web APIs](#webapis) or in the DMA core software.

   - Are there any console errors?

     This could indicate an issue in the client web app.

## Web APIs

- Does a web API method return an incorrect result? Then do the following:

  1. Open the *SLNet Client Test* tool, connect to the DMA, and follow the HTML5 connection of the WebAPI.
  1. Reproduce the issue.
  1. In the *Client Test* tool, investigate whether the unexpected result comes from the DMA core software.

     - Include the *SLNet Client Test* tool dump, and if the issue is caused by the DMA core software, also include a [Log Collector](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages) package when asking support.
  
     - If you cannot determine whether it is a DMA core issue or a web API issue, then collect the requests/responses of the web API by saving them as a HAR file (in the F12 developer tools of Google Chrome) or by capturing them using Wireshark.

- The web API process runs inside IIS w3wp. Does this w3wp process crash, request a timeout or return an error page?

  Investigate the events in Windows Event Viewer (included in a [Log Collector](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages) package).

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
1. Is it working locally on the DMA, but not externally? Then a firewall in the network might block WebSocket communication.

## Features

### Trending

The *SLNet Client Test* tool contains a *Trend Data Inspector* (*Advanced > Tests*). Verify whether the data corresponds with the data drawn in the web apps.

- The DMA should return the last point (note that there might be a gap) that is still valid on the requested start time.
- The DMA should determine which type of trend data is available for the requested timespan (5, 60 or 120 points).
- The web app should draw the last value until the current time (unless the specified end time is before the current time or the intervals are fixed).

### GQI

- GQI runs inside [SLHelper](xref:Troubleshooting_SLHelper_exe).
- Data sources missing? Check if the DMA has the needed licenses and soft-launch options.
- No errors, but invalid data? Check the origin of the invalid data.
- Ad-hoc data source or operator failing? Check with who created the data source or operator (could be on [GitHub](https://github.com/orgs/SkylineCommunications/repositories?q=gqi&type=all)).
- Error message, no data, no response, or slow performance? Record the GQI session and include the ad-hoc data scripts (if any) when asking support.

#### Record GQI session

GQI recording is a debugging feature that allows you to save GQI communication and replay it in a lab environment. GQI recording is disabled by default. To create a recording:

1. Create the folder `C:\Skyline DataMiner\logging\genif`.
1. Perform the operation that needs to be recorded.
1. Save the files written to `C:\Skyline DataMiner\logging\genif`.
1. Delete the folder to disable recording.

> [!NOTE]
> Recording has an impact on the performance as it has to write data to the disk. After the wanted recording has been created, disable it again by deleting the folder.

### PDF

PDFs are generated by [SLHelper](xref:Troubleshooting_SLHelper_exe). If it fails generating a PDF, check the following log files: `SLPdfBuilder.txt`, `SLHelperWrapper.txt` and `SLNet.txt`.

### Email

If there are issues with sending out emails, check the following log file: `SLASPConnection.txt`. Verify the [email configuration](xref:Configuring_outgoing_email) in `DataMiner.xml`.

### Sharing

#### Failed saving WAF rules

- WAF rulebooks are generated by [SLHelper](xref:Troubleshooting_SLHelper_exe).
- Does the DMA use HTTPS? Is the certificate not expired and trusted? Is the HTTPS configuration correct in the `MaintenanceSettings.xml` file? On the DMA, open a browser and surf to the Dashboards app using the FQDN configured in the `MaintenanceSettings.xml` file, does the app open?
- Go to `http(s)://dma/dashboard/#/whitelist` and select the dashboard you want to share. Does this show a rulebook or an error message?

#### Opening the shared dashboard from the email

Does it keep saying *"We're getting things ready... This won't take long."*? This shouldn't take longer than a few minutes. If it keeps showing, it could be failing to save the WAF rules:

- Does it still work to share a dashboard (as this will generate a WAF rulebook)?
- Does IIS have write permissions in `C:\Skyline DataMiner\Webpages\Dashboard`?
- In the *SLNet Client Test* tool, follow the newly created HTML5 connection, does it return any error?

### Visual Overview (Mobile Visio)

Visual Overview in web has limited functionality:

- Visual Overview pages are rendered as images with clickable regions in them. Because of this, some features like embedding and some session variable controls are not fully supported.
- To render a Visual Overview page, [SLHelper](xref:Troubleshooting_SLHelper_exe) loads a virtual instance of DataMiner Cube in its memory. Initial loading of a page can take a long time because SLHelper needs to start Cube, connect to a DMA, and then generate an image.
- SLHelper may use a significant amount of memory to display Visual Overview pages, especially when multiple users are connected. When Visual Overview pages are not viewed by any user, the virtual DataMiner Cube instance is terminated after a timeout of 5 minutes and the memory is released.

Issue in web? Is the behavior different than Cube? Check the `SLUIProvider.txt` and `SLHelperWrapper.txt` log files. Always include the Visio file when asking support.

### Maps

Verify `C:\Skyline DataMiner\Maps\ServerConfig.xml`:

- Is the used app version correct?
- Is a maps provider configured?
- Are the API keys valid for the FQDN the map is opened with?
