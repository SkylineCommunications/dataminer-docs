---
uid: Setting_up_HTTPS_on_a_DMA
---

# Setting up HTTPS on a DMA

To set up your own HTTPS web server, you must first install an SSL certificate and set up an HTTPS binding. In addition, the auto-detection settings for DataMiner must be correctly configured to avoid connection issues.

## Installing the HTTPS connection in IIS

1. Open IIS manager. It can be found under the Administrative Tools in the Control Panel of your computer.

1. Select the Computer name in the *Connections* pane on the left, and double-click *Server Certificates* in the pane on the right.

1. Right-click in the *Server Certificates* list and select *Import*.

1. Browse to your certificate, and click *OK*.

1. In the *Connections* pane on the left, right-click the website and select *Edit Bindings*.

1. In the *Add Site Binding* window, add an HTTPS binding with the selected certificate.

## Setting up redirection of all HTTP traffic to HTTPS

1. Install URL Rewrite 2.0 from the website <http://www.iis.net/downloads/microsoft/url-rewrite>.

   > [!NOTE]
   > This step is no longer required from DataMiner 10.0.0/10.0.2 onwards, as this module is automatically included in DataMiner upgrades from this version onwards.

1. Update the default website bindings in IIS to have both HTTP and HTTPS bindings:

   1. In IIS manager, click *Sites* in the *Connections* pane on the left.

   1. Right-click *Default Web Site* and select *Bindings*.

   1. Click *Add* to add the HTTPS binding.

1. Configure URL rewriting rules at global level:

   1. In IIS manager, select the *Default Web Site* in the *Connections* pane on the left, and double-click *URL Rewrite* in the pane on the right.

   1. Right-click in the list of rules on the right and select *Add Rule(s)*.

   1. Under *Inbound rules*, select *Blank rule*, and click *OK*.

   1. Under *Pattern*, fill in the following pattern: *(.\*)*

   1. Under *Conditions*, click *Add*, and add the following condition:

      - **Input**: {HTTPS}

      - **Type**: Matches the Pattern

      - **Pattern**: off

   1. Under *Action*, set the *Action type* to *Redirect*.

   1. Under *Redirect URL*, fill in the full HTTPS URL for your web server.

      > [!NOTE]
      > - The redirection URL should contain a placeholder {R:1} to make the redirection work properly, e.g. ``https://www.myhost.com/{R:1}``.
      > - The HTTPS URL must match the one defined in the SSL certificate. Otherwise, users will receive warnings about an invalid certificate. TLS/SSL certificates are issued either for a specific hostname (e.g. www.skyline.be) or for all subdomains of a certain domain (e.g. \*.skyline.be).
      > - The redirect rule should skip the redirect on 'localhost'.

   1. Set *Redirect type* to *Found (302)*.

> [!NOTE]
> - Instead of redirecting HTTP traffic to HTTPS, we recommend disabling HTTP completely by removing the HTTP binding, meaning that only HTTPS traffic will be accepted. Once the binding is removed, you can close port 80 in the Windows Firewall.
> - When Failover is active and HTTPS traffic is required, the virtual IP (or the shared hostname) must be added in the *Subject Alternative Name* field of the TLS/SSL certificate on both DataMiner Agents.
> - To connect to your DMA **using the IP address**, make sure the *Subject Alternative Name* field of the TLS/SSL certificate contains the IP address.

## Specifying auto-detection information for an inter-DMA HTTPS connection

If the default web server on the server has been modified to only allow HTTPS traffic, there could be problems with the auto-detection of connection settings.

To avoid this, it is possible to specify alternative auto-detection information via the *Edit Connection Uris* functionality in the SLNetClientTest tool. However, note that this is an advanced system administration tool that should be used with extreme care. See [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_tool_advanced_procedures#editing-the-connection-string-between-two-dataminer-agents).

The following auto-detect methods can be specified:

| Auto-detect method              | Description                           |
|---------------------------------|---------------------------------------|
| auto://full.host.name           | Tries both HTTP and HTTPS             |
| auto://full.host.name/https     | Tries HTTPS only                      |
| auto://full.host.name/http      | Tries HTTP only                       |
| auto://full.host.name/123       | Tries both HTTP and HTTPS on port 123 |
| auto://full.host.name/123-http  | Tries HTTP on port 123                |
| auto://full.host.name/123-https | Tries HTTPS on port 123               |

> [!NOTE]
> It depends on the HTTP/HTTPS configuration in IIS whether the above configuration is required. For a server accepting both HTTP and HTTPS, it is normally not necessary.

## Configuring HTTPS settings in MaintenanceSettings.xml

To configure a server to use HTTPS, a line needs to be added to the file *MaintenanceSettings.xml*. To do so:

1. Stop the DataMiner software.

1. On a DataMiner Agent, open the file *C:\\Skyline DataMiner\\MaintenanceSettings.xml*.

1. Add an HTTPS tag with the necessary attributes. For example:

    ```xml
    <MaintenanceSettings>
      ...
      <HTTPS enabled="true" name="foo.skyline.local"/>
      ...
    </MaintenanceSettings>
    ```

    The HTTPS tag has to contain the following attributes:

    - **enabled**: Enables HTTPS when set to “true”.

    - **name**: Must be set to the name matching the Common Name (CN) or one of the Subject Alternative Names (SAN) of the certificate. If it is a wildcard certificate, the name must match the mask defined in the certificate (e.g. “\*.skyline.local”). For example, “dma01.skyline.be” matches the wildcard certificate for “*.skyline.be”.

      This name should also be configured in the DNS server pointing to the IP address of the DMA, so that the DMA can be reached using the configured name.|

1. Save the file and restart the DMA.
