---
uid: Setting_up_HTTPS_on_a_DMA
---

# Setting up HTTPS on a DMA

To securely host your DataMiner Agent, we recommend that you make sure HTTPS connections are required. To do so, you first have to install an SSL/TLS certificate and set up an HTTPS binding. Using certificates issued by a trusted Certificate Authority (CA) is recommended. Optionally, specify the auto-detection settings for DataMiner to avoid connection issues when traffic between the DataMiner nodes is filtered (e.g. by a firewall).

> [!TIP]
> See also: [DataMiner hardening guide](xref:DataMiner_hardening_guide)

## Configuring the HTTPS binding in IIS

1. Open IIS manager. It can be found under *Administrative Tools* in the *Control Panel* of your computer.
1. In the *Connections* pane on the left, select the computer name, and double-click *Server Certificates* in the pane on the right.
1. Right-click in the *Server Certificates* list, and select *Import*.
1. Browse to your certificate, and click *OK*.
1. In the *Connections* pane on the left, right-click the website, and select *Edit Bindings*.
1. In the *Add Site Binding* window, add an HTTPS binding with the selected certificate.
1. Allow *inbound* TCP port **443** through the Windows Firewall.
1. Optionally (though **recommended**), enable *HTTP Strict Transport Security* (*HSTS*) in IIS to prevent SSL stripping attacks:

   1. Open *IIS Manager*.
   1. In the *Connections* pane on the left, expand the top node and *Sites* node until you see *Default Web Site*.
   1. Right click *Default Web Site* and select *Manage Website* > *Advanced settings*.
   1. Under *Behavior*, expand *HSTS*.
   1. Set *Enabled* to *True*.
   1. Set *IncludeSubDomains* to *True*.
   1. Set *Max-Age* to *31536000* seconds (i.e. 1 year).
   1. Optionally, set *Preload* to *True*.
   1. Optionally, set *Redirect Http to Https* to *True*
   1. Click *OK*.

> [!TIP]
> It is good practice to completely disable **HTTP** by removing the HTTP binding, meaning that only HTTPS traffic will be accepted. Once the binding is removed, you can close port 80 in the Windows Firewall.

## Configuring HTTPS in DataMiner

To configure a DataMiner Agent to use HTTPS, you need to add a line to the *MaintenanceSettings.xml* file (on every DataMiner Agent in the DMS).

To do so:

1. Stop the DataMiner software.

1. On a DataMiner Agent, open *C:\\Skyline DataMiner\\MaintenanceSettings.xml*.

1. At the top level of the \<MaintenanceSettings> XML tree, add an HTTPS tag with the necessary attributes. For example:

    ```xml
    <MaintenanceSettings>
      ...
      <HTTPS enabled="true" name="foo.skyline.local"/>
      ...
    </MaintenanceSettings>
    ```

    The HTTPS tag has to contain the following attributes:

    - **enabled**: Enables HTTPS when set to "true".
    - **name**: Must be set to the name matching the *Common Name* (CN) or one of the *Subject Alternative Names* (SAN) of the certificate. If it is a wildcard certificate, the name must match the mask defined in the certificate (e.g. "\*.skyline.local"). For example, "dma01.skyline.be" matches the wildcard certificate for "*.skyline.be".

      This name **should also be configured in the DNS server** pointing to the IP address of the DMA, so that the DMA can be reached using the configured name.

      > [!WARNING]
      > Do not use wildcard configurations if you want to use your DataMiner Agent to connect your system to dataminer.services, as this is not supported. In that case, use the FQDN (e.g. "dma01.skyline.be") instead.

1. Save the file and restart the DMA.

> [!TIP]
> See also:
>
> - [Securing the DataMiner web server](xref:Webserver_security)
> - [Disabling legacy SSL/TLS protocols](xref:Disabling_legacy_protocols)
> - [TLS encryption in Cassandra](xref:Security_Cassandra_TLS)
> - [Securing the Elasticsearch database](xref:Security_Elasticsearch)

## Configuring HTTP to HTTPS redirection

This is **optional**.

Redirecting HTTP traffic to HTTPS is recommended when external systems (or clients) are still connecting to DataMiner over HTTP and cannot be updated easily. A redirect enables a smooth transition to HTTPS without breaking external systems or compromising on security.

1. Install URL Rewrite 2.0 from the following website: <http://www.iis.net/downloads/microsoft/url-rewrite>

   > [!NOTE]
   > From DataMiner 10.0.0/10.0.2 onwards, this step is no longer required. This module is included all DataMiner upgrades as from DataMiner 10.0.0/10.0.2.

1. Update the default website bindings in IIS to have both HTTP and HTTPS bindings:

   1. In IIS manager, click *Sites* in the *Connections* pane on the left.
   1. Right-click *Default Web Site*, and select *Bindings*.
   1. Click *Add* to add the HTTPS binding.

1. Configure URL rewriting rules at global level:

   1. In IIS manager, select the *Default Web Site* in the *Connections* pane on the left, and double-click *URL Rewrite* in the pane on the right.

   1. Right-click in the list of rules on the right, and select *Add Rule(s)*.

   1. Under *Inbound rules*, select *Blank rule*, and click *OK*.

   1. Under *Pattern*, fill in the following pattern: *(.\*)*

      > [!NOTE]
      > Make sure to include the parentheses.

   1. Under *Conditions*, click *Add*, and add the following condition:

      - **Input**: {HTTPS}
      - **Type**: Matches the Pattern
      - **Pattern**: off

   1. Under *Action*, set the *Action type* to "Redirect".

   1. Under *Redirect URL*, fill in the full HTTPS URL for your web server.

      > [!NOTE]
      >
      > - The redirection URL should contain a placeholder {R:1} to make the redirection work properly, e.g. `https://www.myhost.com/{R:1}`.
      > - The HTTPS URL must match the one defined in the SSL certificate. Otherwise, users will receive warnings about an invalid certificate. TLS/SSL certificates are issued either for a specific hostname (e.g. www.skyline.be) or for all subdomains of a certain domain (e.g. \*.skyline.be).
      > - The redirect rule should skip the redirect on `localhost`.

   1. Set *Redirect type* to "Found (302)".

> [!NOTE]
>
> - When Failover is active and HTTPS traffic is required, the virtual IP (or the shared hostname) must be added in the *Subject Alternative Name* field of the TLS/SSL certificate on both DataMiner Agents.
> - To connect to your DMA **using the IP address**, make sure the *Subject Alternative Name* field of the TLS/SSL certificate contains the IP address.

## Specifying auto-detection information for an inter-DMA HTTPS connection

This is **optional**.

If the default web server on the server has been modified to **only allow HTTPS traffic**, there could be problems with the auto-detection of connection settings.

To avoid this, it is possible to specify alternative auto-detection information via the *Edit Connection Uris* functionality in the SLNetClientTest tool. However, note that this is an advanced system administration tool that should be used with extreme care. See [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string).

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

## Common issues after configuring HTTPS

- **ERR_CERT_COMMON_NAME_INVALID error is shown**

   Most likely, your URL does not match the *Subject Alternative Names (SAN)* field of your certificate. Most browsers will reject certificates when the URL matches the *Common Name (CN)* but not the *Subject Alternative Names (SAN)*. The *Common Name (CN)* field of an x.509 certificate is considered deprecated since RFC 2818 because it is ambiguous and untyped.

   To fix this, either create a new certificate that includes your URL in the *Subject Alternative Names (SAN)* field, or change your URL to match the *Subject Alternative Names (SAN)* field of the certificate.

- **My connection times out or the site cannot be reached**

    Most likely, the **inbound** TCP port for HTTPS connections (default 443) is not allowed through the Windows firewall.

    This can also happen when you are still connecting over *HTTP* while the server only accepts *HTTPS* connections. Make sure your URL starts with `https://`.

- **My browser displays a "This site is not secure" warning when I connect to my DataMiner System**

    Most likely, the URL does not match the *Common Name (CN)* or *Subject Alternative Name (SAN)* field of the TLS certificate. For example, `https://localhost` or `https://10.10.10.10` does not match *dataminer.skyline.be*. To fix this, update the certificate so the *Subject Alternative Name (SAN)* matches the URL, or use a URL that matches the *Common Name (CN)* or *Subject Alternative Name (SAN)* field.

    If the URL matches the certificate, your machine likely does not trust the certificate or the certificate is self-signed. Ensure the certificate is added to the *Trusted Root Certification Authorities* of your certificate store. For more information, see [trusting a certificate in Windows](https://techcommunity.microsoft.com/t5/windows-server-essentials-and/installing-a-self-signed-certificate-as-a-trusted-root-ca-in/ba-p/396105).

- **I cannot log in to the DataMiner Web Applications (e.g. Monitoring, Dashboards, Ticketing, etc.)**

    Make sure that HTTPS is configured in the *MaintenanceSettings.xml* file and that the *name* attribute matches the *Common Name (CN)* of the TLS certificate.

- **My Visual Overview page no longer works**

    Make sure to convert all URLs in your Visio drawing from `http://` to `https://`.

- **I can no longer launch DataMiner Cube from the DataMiner Cube start window**

    If you added the DMS based on the IP address, this may no longer work if HTTPS is required. Add a new DataMiner System and **use the FQDN** instead of the IP address. See [Opening DataMiner Cube](xref:Opening_the_desktop_app).

- **The webpage could not be found (HTTP 404 error)**

   Most likely the IIS binding has set a *Host Name* that does not match the URL. Remove the *Host Name* from the binding or make sure the URL matches the binding.

- **Cannot reach this page**

   Make sure the DNS server has a *DNS record* for the hostname of the URL. For example, *dataminer.skyline.be* will need to resolve to a reachable IP address.

- **My browser shows the error "ERR_HTTP2_INADEQUATE_TRANSPORT_SECURITY"**

   This can have several reasons. Most commonly it is caused by the use of weak, outdated TLS cipher suites. You can fix this by disabling the weak cipher suites using a tool like [IISCrypto](https://www.nartac.com/Products/IISCrypto).

   To disable the weak cipher suites:

   1. Download [IISCrypto](https://www.nartac.com/Products/IISCrypto).
   1. Execute it on the DataMiner server.
   1. Navigate to the *Cipher Suites* tab.
   1. Click *Best Practices*.
   1. Click *Apply*.
   1. Reboot the server
