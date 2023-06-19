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

> [!IMPORTANT]
> To be able to use [DataMiner Maps](xref:DashboardGenericMap) and [video thumbnails embedded using a Web component](xref:DashboardWeb), a [reverse proxy](#reverse-proxy) must be configured. This is also needed in case any modules or apps other than the Dashboards app, Low-Code Apps, Monitoring app, Jobs app, and Ticketing app are embedded.

## Dashboard Gateway configuration

1. On the Dashboard Gateway web server(s), install IIS and the [URL Rewrite](https://www.iis.net/downloads/microsoft/url-rewrite) module.

   For IIS, make sure to install Classic ASP, ASP.NET 4.6+, and the WebSocket protocol.

1. In IIS Manager, import the certificate, and update the site binding to use HTTPS with this certificate.

1. Configure URL Rewrite to forward all HTTP traffic to HTTPS

1. From a DataMiner Agent, copy the folder *C:\\Skyline DataMiner\\Webpages\\API* to the web root folder of the Dashboard Gateway web server (default: *C:\\inetpub\\wwwroot*) and, in IIS Manager, convert the API into an application.

1. From a DataMiner Agent, copy the following folders to the web root folder of the Dashboard Gateway web server:

   - The web application folder(s), e.g. *C:\\Skyline DataMiner\\Webpages\\Dashboard*, *C:\\Skyline DataMiner\\Webpages\\App*, *C:\\Skyline DataMiner\\Webpages\\Monitoring*, *C:\\Skyline DataMiner\\Webpages\\Jobs*, *C:\\Skyline DataMiner\\Webpages\\Ticketing*, etc.
   - *C:\\Skyline DataMiner\\Webpages\\SharedComponents*
   - The Authentication app folder, i.e. *C:\\Skyline DataMiner\\Webpages\\Auth* (from DataMiner 10.3.5 onwards)

1. On the Dashboard Gateway web server, edit the *web.config* in the API folder, and specify the following settings:

   - *connectionString*: The hostname or IP address of the DataMiner Agent to which the Dashboard Gateway has to connect.
   - *connectionUser* and *connectionPassword*: The DataMiner user account that the Dashboard Gateway has to use to connect to the DataMiner Agent (username and password).

1. If [external authentication via SAML](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML) is used, also configure the URL of the API of the Dashboard Gateway (`https://gateway.mycompany.com/API/`) as an *AssertionConsumerService* in the metadata XML file and on the identity provider.

## Reverse proxy

Opening a dashboard or low-code app via the Gateway server will cause embedded [DataMiner Maps](xref:DashboardGenericMap) or [video thumbnails](xref:DashboardWeb) to fail to load.

A reverse proxy should be used to give access to these web pages on the DMA via the Gateway server. The reverse proxy will forward any web requests for these web pages to the DMA.

> [!NOTE]
>
> - When embedding the URLs in dashboards, make use of relative URLs such as `/maps/maps.aspx?config=yourmapconfig`. This way, the content will both be shown on a dashboard accessed via the Gateway server and a dashboard accessed locally via the DMA.
> - No reverse proxy is needed for DataMiner Maps that are displayed using the new Maps component available with the [soft-launch option](xref:SoftLaunchOptions) *ReportsAndDashboardsGQIMaps*.

### Reverse proxy requirements

- IIS 7 or higher with ASP.NET role service enabled

- [URL Rewrite](https://www.iis.net/downloads/microsoft/url-rewrite)

- [Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing)

### Configuration

#### Enabling reverse proxy functionality

As the reverse proxy functionality is disabled by default, first enable it:

1. Open IIS Manager on the Gateway server.

1. In the tree view on the left, choose a server node and select the *Application Request Routing* feature.

1. Select the *Enable Proxy* checkbox.

   There is no need to change any other default settings.

#### Creating rewrite rules for the Maps module

To add a rewrite rule that will proxy any request to the DataMiner Maps module at `https://mydma/maps/`, as long as the requested URL path starts with "maps":

1. Open IIS Manager on the Gateway server.

1. In the tree view on the left, choose a website node (usually *Default Web Site*) and select the *URL Rewrite* feature.

1. Click *Add Rule(s)*, select *Blank rule*, and specify the following options:

   - **Name**: e.g. "Maps module"

   - **Pattern**: `^maps/(.*)`

   - **Rewrite URL**: `https://mydma/maps/{R:1}`

   - ***Stop processing of subsequent rules***: enabled

1. Click *apply*.

To add a rewrite rule that will proxy any request to the Maps API at `https://mydma/API/v0/maps.asmx`, as long as the requested URL path starts with "API/v0/maps.asmx":

1. Open IIS Manager on the Gateway server.

1. In the tree view on the left, choose a website node (usually *Default Web Site*) and select the *URL Rewrite* feature.

1. Click *Add Rule(s)*, select *Blank rule*, and specify the following options:

   - **Name**: e.g. "Maps API"

   - **Pattern**: `^API/v0/maps.asmx/(.*)`

   - **Rewrite URL**: `https://mydma/API/v0/maps.asmx/{R:1}`

   - ***Stop processing of subsequent rules***: enabled

1. Click *apply*.

#### Creating rewrite rules for the VideoThumbnails web page

To add a rewrite rule that will proxy any request to the VideoThumbnails web page at `https://mydma/videothumbnails/`, as long as the requested URL path starts with "videothumbnails":

1. Open IIS Manager on the Gateway server.

1. In the tree view on the left, choose a website node (usually *Default Web Site*) and select the *URL Rewrite* feature.

1. Click *Add Rule(s)*, select *Blank rule*, and specify the following options:

   - **Name**: e.g. "VideoThumbnails"

   - **Pattern**: `^videothumbnails/(.*)`

   - **Rewrite URL**: `https://mydma/videothumbnails/{R:1}`

   - ***Stop processing of subsequent rules***: enabled

1. Click *apply*.

### Testing the reverse proxy functionality

To test whether the reverse proxy is working properly, enter `https://gateway/maps/maps.aspx?config=yourmapconfig` or `https://gateway/videothumbnails/video.htm` in your browser's address bar.

If the reverse proxy was configured correctly, you should see the login screen of the DataMiner Maps module or the VideoThumbnails web page. It should be possible to log in.
