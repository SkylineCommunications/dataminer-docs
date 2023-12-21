---
uid: Investigating_Web_Issues
---

# Investigating web issues

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

GQI runs inside [SLHelper](xref:Troubleshooting_SLHelper_exe).

- Are data sources missing? Check whether the DMA has the necessary licenses and soft-launch options.
- Are there no errors, but invalid data? Check the origin of the invalid data.
- Are ad-hoc data sources or operators failing? Contact the person who created the data source or the operator (check [GitHub](https://github.com/orgs/SkylineCommunications/repositories?q=gqi&type=all)).
- Error messages, no data, no response, or slow performance? Then record the GQI session and include the ad-hoc data scripts (if any) when asking support.

#### Record GQI session

GQI recording is a debugging feature that allows you to save GQI communication and replay it in a lab environment. GQI recording is disabled by default. To create a recording, do the following:

1. Create the `C:\Skyline DataMiner\logging\genif` folder.
1. Perform the operation that needs to be recorded.
1. Save the files that were written to `C:\Skyline DataMiner\logging\genif`.
1. Stop the recording by deleting the folder.

> [!NOTE]
> Recording might impact performance as data is written to the disk. Once the recording has been made, stop the recording by deleting the folder.

### PDF

PDFs are generated by [SLHelper](xref:Troubleshooting_SLHelper_exe). If it fails to generate a PDF, check the following log files:

- `SLPdfBuilder.txt`
- `SLHelperWrapper.txt`
- `SLNet.txt`

### Email

If there are issues related to the sending of emails, check the following log file: `SLASPConnection.txt`.

Also check the [email configuration](xref:Configuring_outgoing_email) in `DataMiner.xml`.

### Sharing

#### Failed saving WAF rules

WAF rulebooks are generated by [SLHelper](xref:Troubleshooting_SLHelper_exe).

- Does the DMA use HTTPS? Is the certificate not expired and trusted?
- Is the HTTPS configuration correct in the `MaintenanceSettings.xml` file?

  On the DMA, open a browser and navigate to the Dashboards app using the FQDN configured in the `MaintenanceSettings.xml` file. Does the app open? If not, you might have to configure the FQDN in the Windows hosts file so that the FQDN resolves to the server.

- Go to `http(s)://dma/dashboard/#/whitelist` and select the dashboard you want to share. Does this show a rulebook or an error message?

#### Opening a shared dashboard from an email

Do you keep getting *"We're getting things ready... This won't take long."*? This shouldn't take longer than a few minutes. If you keep getting this message, the WAF rules might not get saved.

- Is it still possible to share a dashboard (as this will generate a WAF rulebook)?
- Does IIS have permission to write in `C:\Skyline DataMiner\Webpages\Dashboard`?
- In the *SLNet Client Test* tool, follow the newly created HTML5 connection. Does it return any errors?

### Visual Overview (Mobile Visio)

Visual Overview in web apps has limited functionality:

- Visual Overview pages are rendered as images containing clickable regions. As a result, some features (e.g. embedding) and some session variable controls are not fully supported.
- To render a Visual Overview page, [SLHelper](xref:Troubleshooting_SLHelper_exe) loads a virtual instance of DataMiner Cube in its memory. Initial loading of a page can take a long time because SLHelper needs to start Cube, connect to a DMA, and then generate an image.
- SLHelper may use a significant amount of memory to display Visual Overview pages, especially when multiple users are connected. When Visual Overview pages are not viewed by any user, the virtual DataMiner Cube instance is terminated after a timeout of 5 minutes and the memory is released.

If you encounter any issues or if you notice any behavior that is different from that in Cube, then check the `SLUIProvider.txt` and `SLHelperWrapper.txt` log files. Always include the Visio file when you ask for support by email.

### Maps

Check the `C:\Skyline DataMiner\Maps\ServerConfig.xml` file:

- Is the app version correct?
- Is a maps provider configured?
- Are the API keys valid for the FQDN the map is opened with?
