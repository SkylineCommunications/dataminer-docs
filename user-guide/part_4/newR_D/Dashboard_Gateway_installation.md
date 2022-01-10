# Dashboard Gateway installation

From DataMiner 10.1.0/10.0.12 onwards, a new Dashboard Gateway can be used to give users access both to the Dashboards app and to other DataMiner web applications (Monitoring, Ticketing, Jobs, etc.) even if those users do not have access to DataMiner.

There are two main reasons to consider a Dashboard Gateway setup:

- Security

    Users are allowed to connect to the Dashboard Gateway, but not to the DataMiner Agents directly. Also, it is possible to install only the web applications on the Dashboard Gateway web server(s) to which you want users to have access. If you only install the Dashboards and the Monitoring app, users will not be able to access the Jobs app, the Ticketing or any other app.

- Performance

    Allowing multiple users to connect to the web applications increases the overall load on the DataMiner Agents. When a Dashboard Gateway is used, the direct load of the web applications and the HTTP requests shifts to a separate web server, leaving more resources available on the DataMiner Agents. Also, if more performance is needed, multiple Dashboard Gateway web servers can be used in combination with a load balancer.

### Requirements

- At least one web server (running Windows Server)

- A valid SSL certificate signed by a public certificate authority for the FQDN of the Dashboard Gateway (e.g. “gateway.mycompany.com”)

- A DataMiner user account with:

    - Access to all views, elements and alarms.

    - Permission to access the Alarm Console and Data Display.

    - Permission to create, edit and delete dashboards.

- The Dashboard Gateway web server(s) should be able to communicate with a DMA using both a .NET Remoting connection and an HTTP(S) connection (using port 80 or 443, depending on the HTTP(S) configuration of the DataMiner Agent)

### Dashboard Gateway configuration

1. On the Dashboard Gateway web server(s), install IIS and the URL Rewrite module.

    For IIS, make sure to install Classic ASP, ASP.NET 4.6+, and the WebSocket protocol.

2. In IIS Manager, import the certificate, and update the site binding to use HTTPS with this certificate.

3. Configure URL Rewrite to forward all HTTP traffic to HTTPS

4. From a DataMiner Agent, copy the folder *C:\\Skyline DataMiner\\Webpages\\API* to the web root folder of the Dashboard Gateway web server (default: *C:\\inetpub\\wwwroot*) and, in IIS Manager, convert the API into an application.

5. From a DataMiner Agent, copy the web application(s) (e.g. *C:\\Skyline DataMiner\\Webpages\\Dashboard*, *C:\\Skyline DataMiner\\Webpages\\Monitoring*, *C:\\Skyline DataMiner\\Webpages\\Jobs*, *C:\\Skyline DataMiner\\Webpages\\SharedComponents*, *C:\\Skyline DataMiner\\Webpages\\Ticketing*, etc.) to the web root folder of the Dashboard Gateway web server.

6. On the Dashboard Gateway web server, edit the *web.config* in the API folder, and specify the following settings:

    | Setting          | Description                                                                                                                  |
    |--------------------|------------------------------------------------------------------------------------------------------------------------------|
    | connectionString   | The hostname or IP address of the DataMiner Agent to which the Dashboard Gateway has to connect.                             |
    | connectionUser     | The DataMiner user account that the Dashboard Gateway has to use to connect to the DataMiner Agent (user name and password). |
    | connectionPassword |                                                                                                                              |

> [!NOTE]
> Keep the following limitations in mind:
> - The URL folder structure of the web applications should remain the same as on a DataMiner Agent. The applications have to be accessed using URLs similar to the following examples:
>     - https://gateway.mycompany.com/dashboard
>     - https://gateway.mycompany.com/monitoring
>     - https://gateway.mycompany.com/ticketing
>     - https://gateway.mycompany.com/jobs
> - The DataMiner user account used by the Dashboard Gateway web server should not have multi-factor authentication enabled.
