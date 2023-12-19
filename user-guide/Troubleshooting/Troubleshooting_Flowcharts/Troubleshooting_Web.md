---
uid: Troubleshooting_Web
---

# Troubleshooting - Web

## Client Web App

Is something not working as expected? Open the F12 development tools of the browser, refresh the web page (long click the refresh button and choose "empty cache and hard refresh"), and reproduce it. Then look in the F12 window:

* Does the webpage not load, or show a "Service Unavailable" error? This could mean the [IIS web server](#iis-web-server-w3wp) is not running, or the cloud connection has been lost.
* Are there any network calls failing (for example `GetVisioForElement`)? This could indicate an issue in the [WebAPIs](#webapis) or in the DMA core software.
* Are there console errors? This could indicate an issue in the client web app.

## WebAPIs

* Returns a WebAPI method an incorrect result? Open the *SLNet Client Test* tool, connect to the DMA, and follow the HTML5 connection of the WebAPI. Reproduce the issue, investigate in the *Client Test* tool if the unexpected result comes from the DMA core software.

  * Include this *Client Test* tool dump and if the issue comes from the DMA core software, also include a [Log Collector](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages) package when asking support.
  * If it can't be determined whether it is a DMA core issue or WebAPI issue, then it's interesting to have the request/responses of the WebAPI, this can be saved as a HAR file in the F112 developer tools of Google Chrome or can be captured using Wireshark.

* The WebAPI process runs inside IIS w3wp. Does this w3wp process crash, requests timeout, or return an error page? Investigate the events in Windows event Viewer (included in a [Log Collector](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages) package).

## IIS web server (w3wp)

### Error page

* In Server Manager, is the IIS web server installed?
* In Server Manager, is ASP.NET 4.8 installed?
* Are Windows Updates installed?
* Is the [URL Rewrite](https://www.iis.net/downloads/microsoft/url-rewrite) module installed?
* Is the [Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing) module installed?
* Run `C:\Skyline DataMiner\Tools\ConfigureIIS.bat` as Administrator.
* Does the *w3wp* process run?

### Crash

Check the logging in Windows Event Viewer (included in a [Log Collector](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages) package). Another option is to create a memory dump (`procdump -ma -g -e 1 w3wp.exe`).

If the process crashes several times, more than the configured maximum within the configured interval ("Rapid-Fail Protection"), then IIS will shut it down and a manual action is needed to start it again.

### High CPU/memory

This is often caused because the protocol cache isn't working properly, resulting in protocols being requested from the DMA in high frequency, wasting a lot of resources on deserializing protocol objects and performing garbage collection.

Check if the w3wp process has read+write access to `%appdata%\Skyline\DataMiner\Cache\`.

### No WebSocket connection

* In Server Manager, has the WebSocket protocol been installed?
* In `C:\Skyline DataMiner\Webpages\API\web.config`, is the `<httpRuntime` `targetFramework` set on version 4.6.2 (or higher)?
* Is it working locally on the DMA, but not externally? Then a firewall on the network might block WebSocket communication.

## Features

### Trending

The *SLNet Client Test* tool contains a *Trend Data Inspector* (Advanced > Tests). Verify if the data corresponds with the data drawn in the web apps.

* The DMA should return the last point (could be a gap) that is still valid on the requested start time.
* The DMA should determine which type of trend data is available for the requested timespan (5, 60 or 120 points).
* The web app should draw the last value till the current time (unless the specified end time is before the current time, or if fixed intervals are used).

### GQI

* GQI runs inside [SLHelper](xref:Troubleshooting_SLHelper_exe).
* Data sources missing? Check if the DMA has the needed licenses and soft-launch options.
* No errors, but invalid data? Check the origin of the invalid data.
* Ad-hoc data source or operator failing? Check with who created the data source or operator (could be on [GitHub](https://github.com/orgs/SkylineCommunications/repositories?q=gqi&type=all)).
* Error message, no data, no response, or slow performance? Record the GQI session and include the ad-hoc data scripts (if any) when asking support.

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

* WAF rulebooks are generated by [SLHelper](xref:Troubleshooting_SLHelper_exe).
* Does the DMA use HTTPS? Is the certificate not expired and trusted? Is the HTTPS configuration correct in the `MaintenanceSettings.xml` file? On the DMA, open a browser and surf to the Dashboards app using the FQDN configured in the `MaintenanceSettings.xml` file, does the app open?
* Go to `http(s)://dma/dashboard/#/whitelist` and select the dashboard you want to share. Does this show a rulebook or an error message?

#### Opening the shared dashboard from the email

Does it keep saying *"We're getting things ready... This won't take long."*? This shouldn't take longer than a few minutes. If it keeps showing, it could be failing to save the WAF rules:

* Does it still work to share a dashboard (as this will generate a WAF rulebook)?
* Does IIS have write permissions in `C:\Skyline DataMiner\Webpages\Dashboard`?
* In the *SLNet Client Test* tool, follow the newly created HTML5 connection, does it return any error?

### Visual Overview (Mobile Visio)

Visual Overview in web has limited functionality:

* Visual Overview pages are rendered as images with clickable regions in them. Because of this, some features like embedding and some session variable controls are not fully supported.
* To render a Visual Overview page, [SLHelper](xref:Troubleshooting_SLHelper_exe) loads a virtual instance of DataMiner Cube in its memory. Initial loading of a page can take a long time because SLHelper needs to start Cube, connect to a DMA, and then generate an image.
* SLHelper may use a significant amount of memory to display Visual Overview pages, especially when multiple users are connected. When Visual Overview pages are not viewed by any user, the virtual DataMiner Cube instance is terminated after a timeout of 5 minutes and the memory is released.

Issue in web? Is the behavior different than Cube? Check the `SLUIProvider.txt` and `SLHelperWrapper.txt` log files. Always include the Visio file when asking support.

### Maps

Verify `C:\Skyline DataMiner\Maps\ServerConfig.xml`:

* Is the used app version correct?
* Is a maps provider configured?
* Are the API keys valid for the FQDN the map is opened with?
