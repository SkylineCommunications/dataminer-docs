---
uid: Dashboard_Gateway_installation
---

# Dashboard Gateway installation

From DataMiner 10.1.0/10.0.12 onwards, a new Dashboard Gateway can be used to give users access both to the Dashboards app and to other DataMiner web applications (Monitoring, Ticketing, Jobs, etc.) even if those users do not have access to DataMiner.

There are two main reasons to consider a Dashboard Gateway setup:

- Security

  Users are allowed to connect to the Dashboard Gateway, but not to the DataMiner Agents directly. Also, it is possible to install only the web applications on the Dashboard Gateway web server(s) to which you want users to have access. If you only install the Dashboards and the Monitoring app, users will not be able to access the Jobs app, the Ticketing or any other app.

- Performance

  Allowing multiple users to connect to the web applications increases the overall load on the DataMiner Agents. When a Dashboard Gateway is used, the direct load of the web applications and the HTTP requests shifts to a separate web server, leaving more resources available on the DataMiner Agents. Also, if more performance is needed, multiple Dashboard Gateway web servers can be used in combination with a load balancer.

## Requirements

- At least one web server (running Windows Server)

- A valid SSL certificate signed by a public certificate authority for the FQDN of the Dashboard Gateway (e.g. “gateway.mycompany.com”)

- A DataMiner user account with:

  - Access to all views, elements and alarms.

  - Permission to access the Alarm Console and Data Display.

  - Permission to create, edit and delete dashboards.

- The Dashboard Gateway web server(s) should be able to communicate with a DMA using both a .NET Remoting connection and an HTTP(S) connection (using port 80 or 443, depending on the HTTP(S) configuration of the DataMiner Agent)

> [!IMPORTANT]
> Always make sure your Dashboard Gateway's web application folders are in sync with the DataMiner server. This means that when you upgrade your DataMiner software, you must make sure the folders for the web apps are also up to date.

## Limitations

- The URL folder structure of the web applications should remain the same as on a DataMiner Agent. The applications have to be accessed using URLs similar to the following examples:

  - ``https://gateway.mycompany.com/app``

  - ``https://gateway.mycompany.com/dashboard``

  - ``https://gateway.mycompany.com/monitoring``

  - ``https://gateway.mycompany.com/ticketing``

  - ``https://gateway.mycompany.com/jobs``

- The DataMiner user account used by the Dashboard Gateway web server should not have multifactor authentication enabled.

- Only the following web applications are supported: Dashboards app, Low-code apps, Monitoring app, Jobs app, and the Ticketing app. For other web apps, a [reverse proxy](#reverse-proxy) can be configured.

## Dashboard Gateway configuration

1. On the Dashboard Gateway web server(s), install IIS and the [URL Rewrite](https://www.iis.net/downloads/microsoft/url-rewrite) module.

   For IIS, make sure to install Classic ASP, ASP.NET 4.6+, and the WebSocket protocol.

1. In IIS Manager, import the certificate, and update the site binding to use HTTPS with this certificate.

1. Configure URL Rewrite to forward all HTTP traffic to HTTPS

1. From a DataMiner Agent, copy the folder *C:\\Skyline DataMiner\\Webpages\\API* to the web root folder of the Dashboard Gateway web server (default: *C:\\inetpub\\wwwroot*) and, in IIS Manager, convert the API into an application.

1. From a DataMiner Agent, copy the web application(s) (e.g. *C:\\Skyline DataMiner\\Webpages\\Dashboard*, *C:\\Skyline DataMiner\\Webpages\\Monitoring*, *C:\\Skyline DataMiner\\Webpages\\Jobs*, *C:\\Skyline DataMiner\\Webpages\\SharedComponents*, *C:\\Skyline DataMiner\\Webpages\\Ticketing*, etc.) to the web root folder of the Dashboard Gateway web server.

1. On the Dashboard Gateway web server, edit the *web.config* in the API folder, and specify the following settings:

   - *connectionString*: The hostname or IP address of the DataMiner Agent to which the Dashboard Gateway has to connect.
   - *connectionUser* and *connectionPassword*: The DataMiner user account that the Dashboard Gateway has to use to connect to the DataMiner Agent (username and password).

## Reverse proxy

When a dashboard (or Low-code app) contains a web component displaying the [Maps app](xref:maps) or VideoThumbnails web page, then this won't work out of the box when the dashboard (or app) is opened via the Gateway server.

A reverse proxy can be used to give access to these web pages on the DMA via the Gateway server. The reverse proxy will forward any web requests for these web pages to the DMA.

### Requirements

* IIS 7 or above with ASP.NET role service enabled and [URL Rewrite](https://www.iis.net/downloads/microsoft/url-rewrite) module installed.
* [Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing) module installed.

### Configuration

#### Enabling reverse proxy functionality

Reverse proxy functionality is disabled by default, so you must begin by enabling it:

1. Open IIS Manager on the Gateway server.
1. Select a server node in the tree view on the left hand side and then click on the "Application Request Routing" feature.
1. Check the "Enable Proxy" check box. Leave the default values for all the other settings on this page.

### Creating rules for the Maps app

The following rewrite rules will be created:

* A rewrite rule that will proxy any request to the Maps app at https://mydma/maps/ as long as the requested URL path starts with "maps".
* A rewrite rule that will proxy any request to the Maps API at https://mydma/API/v0/maps.asmx as long as the requested URL path starts with "API/v0/maps.asmx".

To add the reverse proxy rewrite rules:

1. Open IIS Manager
1. Select a web site node in the tree view on the left hand side and then click on the "URL Rewrite" feature
1. Click on "Add Rule(s)..." and select "Blank rule"
1. Give the rule a name, for example "Maps application"
1. Enter the pattern: `^maps/(.*)`
1. Enter the rewrite url: `https://mydma/maps/{R:1}`
1. Enable "Stop processing of subsequent rules"
1. Click apply
1. Click again on "Add Rule(s)..." and select "Blank rule"
1. Give the rule a name, for example "Maps API"
1. Enter the pattern: `^API/v0/maps.asmx/(.*)`
1. Enter the rewrite url: `https://mydma/API/v0/maps.asmx/{R:1}`
1. Enable "Stop processing of subsequent rules"
1. Click apply

### Creating rules for the VideoThumbnails web page

The following rewrite rule will be created:

* A rewrite rule that will proxy any request to the VideoThumbnails web page at https://mydma/videothumbnails/ as long as the requested URL path starts with "videothumbnails".

To add the reverse proxy rewrite rule:

1. Open IIS Manager
1. Select a web site node in the tree view on the left hand side and then click on the "URL Rewrite" feature
1. Click on "Add Rule(s)..." and select "Blank rule"
1. Give the rule a name, for example "VideoThumbnails"
1. Enter the pattern: `^videothumbnails/(.*)`
1. Enter the rewrite url: `https://mydma/videothumbnails/{R:1}`
1. Enable "Stop processing of subsequent rules"
1. Click apply

### Testing the reverse proxy functionality

Open a web browser and make a request to https://gateway/maps/maps.aspx?config=yourmapconfig or https://gateway/videothumbnails/video.htm. You should see the login screen of the Maps app or VideoThumbnails web page. It should be possible to login.

> [!TIP]
> When embedding the URLs in Dashboards, make use of relative URLs, for example: ``/maps/maps.aspx?config=yourmapconfig``. This way the content will be shown on the dashboard opened via the Gateway server and also locally via the DMA.
