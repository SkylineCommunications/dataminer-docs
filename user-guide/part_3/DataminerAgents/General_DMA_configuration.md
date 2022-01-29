---
uid: General_DMA_configuration
---

# General DMA configuration

## Changing the DataMiner ID of a DMA

In the *DataMiner.xml* file of a DMA, you can change its DataMiner ID.

> [!WARNING]
> Changing the DataMiner ID in *DataMiner.xml* is only allowed on new DMAs that have not yet been put into use.

To do so:

1. Stop the DataMiner software.

2. Open the file *C:\\Skyline Dataminer\\DataMiner.xml*.

3. In the *id* attribute of the *\<DataMiner>* tag, specify the new DataMiner ID of the DMA.

4. Save the file.

5. Restart the DataMiner software.

For example, in the tag below, the DataMiner ID has been set to 7:

```xml
<DataMiner id="7">...</DataMiner>
```

## Changing the name of a DMA

By default, a DataMiner Agent always takes the name of its host server. However, it is possible to configure a custom name.

### Setting the DMA name in Cube

To set a custom DMA name in Cube:

1. Go to *Apps* > *System Center*.

2. In System Center, select the *Agents* page.

3. In the *Manage* tab, select the DMA of which you wish to set the name.

4. Fill in the new name in the *Name* field and click *Apply*.

5. In case you also want to change the hostname of the server, in the confirmation box, select the checkbox next to the name, and then click *Apply*. Keep in mind that if you do so, a server reboot will be required.

    If you only want to change the alias used in DataMiner instead of changing the actual server name, simply click *Apply* without selecting the checkbox.

### Setting the DMA name in DataMiner.xml

Though it is advisable to change a DMA name in Cube, it is also possible to set the DMA name directly in the file *C:\\Skyline DataMiner\\DataMiner.xml*.

To do so:

1. Stop the DataMiner software.

2. Open the file *C:\\Skyline DataMiner\\DataMiner.xml*.

3. In the *\<DMAName>* start tag, add a *mode* attribute, and set its value to “manual”.

4. Between the *\<DMAName>* start tag and the *\</DMAName>* end tag, specify the name of the DataMiner Agent. For example:

    ```xml
    <DataMiner ...>
      <DMA>
        <DMAName mode="manual">MyCustomName</DMAName>
        ...
      </DMA>
    </DataMiner>
    ```

5. Save the file.

6. Restart the DataMiner software.

## Specifying your company data

In your DataMiner System, you can store general information about your company: the name, address, telephone numbers, email address, logo, and website. The company information you provide will be used throughout the DataMiner System:

- The company name will be the name of the root view of the Surveyor.

- The email address will be used as default “From” address in all email messages sent by DataMiner.

- Report headers will include name, address and logo.

    > [!TIP]
    > See also:
    > [Creating report templates](xref:Creating_report_templates)

You can also specify up to three DataMiner users who can be contacted in case of problems. Often, these will be DataMiner Administrators.

To specify these data in DataMiner Cube:

1. Go to *Apps* > *System Center*.

2. In System Center, select the *Agents* page.

3. Go to the *System* tab.

4. Make the necessary changes:

    - Select a contact in the *System contact* drop-down lists for up to three contact persons.

        > [!NOTE]
        > Next to each of the system contacts, the envelope icon allows you to immediately send the contact in question an email message.

    - Add or replace details in the boxes *Name*, *Address*, etc.

    - If you want to change the company logo, do the following:

        1. Click *Change Logo*.

        2. In the *Choose new logo* dialog box, select the logo image (in *.png*, *.jpg*, *.jpeg* or *.gif* format), and click *Open*.

        > [!NOTE]
        > To remove the company logo, right-click the image in Cube and select *Delete*.

5. Click *Save* to apply your changes.

## Configuring the IP network ports

A DataMiner System makes extensive use of TCP/IP communication. Below, you find an overview of the TCP and UDP ports being used, as well as instruction on how to change port configurations. This information will especially prove useful when you have to configure firewalls in your network.

> [!NOTE]
> In new DataMiner installations from DataMiner 10.1.11/10.2.0 onwards, only the essential ports are opened by default (80, 8004, as well as 162 from DataMiner 10.1.12 onwards). To make use of DataMiner functionality that requires additional ports, you will need to manually create a firewall rule for those ports.

### Overview of IP ports used in a DMS

| Protocol           | Ports used                                                                                                                                                                            | Application                                                                                                                                   |
|--------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| SNMP               | 161/udp<br> 162/udp                                                                                                                                                                   | SNMP                                                                                                                                          |
| .Net Remoting      | Configurable port<br> Default port: 8004/tcp                                                                                                                                          | Inter-DMA communication<br> DataMiner Cube<br> System Display, Element Display (deprecated)<br> DMS Alerter                                   |
| HTTP(S)            | 80/tcp<br> 443/tcp                                                                                                                                                                    | DataMiner Cube<br> System Display, Element Display (deprecated)<br> DMS Alerter<br> Web apps (e.g. Monitoring, Jobs)<br> Dashboards, Reporter |
|                    | 9200/tcp                                                                                                                                                                              | Indexing Engine (server listening for client requests)                                                                                        |
| N/A                | 7000/tcp                                                                                                                                                                              | Cassandra: non-TLS setup (inter-node communication in Failover setups)                                                                        |
|                    | 7001/tcp                                                                                                                                                                              | Cassandra: TLS setup (available from DataMiner 10.1.3 onwards)                                                                                |
|                    | 7199/tcp                                                                                                                                                                              | Cassandra cluster backups                                                                                                                     |
|                    | 9042/tcp                                                                                                                                                                              | Cassandra (server listening for client requests)                                                                                              |
|                    | 9200/tcp                                                                                                                                                                              | Elasticsearch                                                                                                                                 |
|                    | 9300/tcp                                                                                                                                                                              | Elasticsearch (inter-node communication)                                                                                                      |
| Multiple protocols | 4222/tcp<br> 6222/tcp                                                                                                                                                                 | NATS (required from DataMiner 10.1.1 onwards)                                                                                                 |
| NAS                | 9090/tcp                                                                                                                                                                              | NATS Account Server (required from DataMiner 10.1.1 onwards)                                                                                  |
| Telnet             | 23/tcp                                                                                                                                                                                | Stream |


> [!NOTE]
> - When viewing Stream via DataMiner Cube, access to port 23/tcp is not required. Access is only required when using a Telnet client. However, note that Telnet is by default disabled from DataMiner 9.6.5 onwards. For more information on how to enable this, see [DataMiner.xml](xref:DataMiner_xml#dataminerxml)
> - Prior to DataMiner 10.0.8, ports 7001, 7199, 9142 and 9160 are also opened during Cassandra installation. However, from DataMiner 10.0.8 onwards, only the essential ports 7000 and 9042 are opened.
> - Prior to DataMiner 10.1.0 CU10 and 10.2.1, port 8222 is also opened for NATS monitoring. However, this port is no longer used from those versions onwards and is no longer opened during new installations.
> - The System Display and Element Display client applications are no longer available from DataMiner 9.6.0 onwards.

### Graphical representation of IP communication within a DMS

The diagram below shows how communication within a DMS could be set up.

![DMS communication overview](~/user-guide/images/dms_ip_communication_1021.jpg)



> [!NOTE]
> It is not recommended to let a DMA connect to another DMA via Web Services. From DataMiner 10.0.11, connecting via Web Services is no longer supported.

> [!TIP]
> See also:
> - [Configuring DMA communication settings in SLNet.exe.config](xref:Configuration_of_DataMiner_processes#configuring-dma-communication-settings-in-slnetexeconfig)
> - [Configuring client communication settings](xref:DMA_configuration_related_to_client_applications#configuring-client-communication-settings)

## Configuring the polling request timeout

By default, the DMA polling request timeout is set to 60 seconds. If necessary, it can be changed both server-side and client-side.

DMA polling should not be confused with device polling. It enables DMAs to send notifications to other DMAs in the DataMiner System or to client applications.

### Server-side

In the *MaintenanceSettings.xml* file of a DMA, you can add a *\<DefaultPollingRequestTimeout>* tag in the *\<SLNet>* section.

This setting will apply to all new inter-DMA connections set up from that DMA.

> [!TIP]
> See also:
> [Configuring SLNet settings in MaintenanceSettings.xml](xref:Configuration_of_DataMiner_processes#configuring-slnet-settings-in-maintenancesettingsxml)

### Client-side

On a DataMiner client machine, you can set the client’s polling request timeout by creating an environment variable named *SLNETTYPES* and setting its value to “pollingTimeout=xxx” (xxx being an amount of seconds).

## Configuring outgoing email

A DMS can be configured to send out email notifications and reports via an SMTP server.

> [!NOTE]
> For this feature, this product includes software developed by the OpenSSL Project for use in the OpenSSL Toolkit (http://www.openssl.org/).
> - From DataMiner 8.5.5 up to DataMiner 9.5.12, OpenSSL library version v1.0.2a is used.
> - From DataMiner 9.5.13 onwards, OpenSSL library version v1.0.2m is used.
> - From DataMiner 9.6.1 onwards, OpenSSL library version v1.1.0h is used.
> - From DataMiner 9.6.8 onwards, OpenSSL library version v1.1.0j is used.
> - From DataMiner 9.6.11 onwards, OpenSSL library version v1.1.1c is used.

> [!TIP]
> See also:
> <https://community.dataminer.services/video/agents-configuring-an-email-server/>

### Prerequisite

In order to send out email notifications or email reports, a DataMiner Agent has to be able to connect to an outgoing email server (SMTP Server).

### Default “From” address

To specify the default “From” address to be used in outgoing email messages, do the following:

1. Go to *Apps* > *System Center*.

2. In System Center, go to *Agents* > *system*.

3. In the *Email* box, specify the default “From” address.

4. Click *Save*.

5. Restart the DataMiner Agent.

### DataMiner.xml configuration

If a DataMiner Agent has to be able to send out email messages, then the *DataMiner.xml* file located in the *C:\\Skyline DataMiner* directory of that DataMiner Agent has to have an *\<SMTP>* section containing the necessary email settings.

1. Log on to the DataMiner Agent, either locally or through a remote desktop session.

2. Stop the DataMiner software.

3. Open the file *C:\\Skyline DataMiner\\DataMiner.xml*.

4. Go to the *\<SMTP>* section. If this section does not yet exist, add it.

5. In this section, enter the correct SMTP server settings. See below for more information.

6. Restart the DataMiner Agent in order to apply the new settings.

> [!NOTE]
> If there are several DataMiner Agents in your DataMiner System, execute the above-mentioned procedure on every DataMiner Agent that has to be able to send email messages.

#### Basic SMTP server settings

- **Host**: The name or IP address of the SMTP server.

- **HostPort**: Default port is 25.

    - If the server supports or requires SSL communication, use port 465 instead of port 25.

    - If SSL has to be used on a non-standard port (e.g. 123), specify “*123-ssl*”.

    - If you explicitly do not want to use SSL, specify “*465-nossl*”.

    - If you want to use STARTTLS, specify e.g. “*123-starttls*”.

- **LoginMethod**: The method that will be used to authenticate the DataMiner Agent when it logs on to the SMTP server.

    | Method         | Description                                                                                                                                                                                                                                                                                                   |
    |------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | NoLoginMethod    | The user will not be authenticated by the server.                                                                                                                                                                                                                                                             |
    | LoginPlainMethod | Username and password will be sent to the server unencrypted.                                                                                                                                                                                                                                                 |
    | CramMD5Method    | The user will be authenticated using CRAM MD5 (Challenge-Response Authentication Mechanism, see RFC 2195). The server generates a challenge, to which the user has to respond with a username and the MD5 HMAC (Hash-based Message Authentication Code) of the challenge (with the user password as the key). |
    | AuthLoginMethod  | Username and password will be sent to the server using simple base64 encoding.                                                                                                                                                                                                                                |
    | NTLM             | The user will be authenticated using the MS NTLM (NT LAN Manager) protocol (as from DataMiner v4.2).                                                                                                                                                                                                          |
    | Auto             | The authentication protocol to be used will be auto-negotiated (as from DataMiner 5.0).                                                                                                                                                                                                                       |

- **User**: The username with which the DataMiner Agent will log on to the SMTP server.

    If LoginMethod is set to “NoLoginMethod”, then no username has to be specified.

- **Password**: The password with which the DataMiner Agent will log on to the SMTP server.

    If LoginMethod is set to “NoLoginMethod”, then no password has to be specified.

#### Advanced SMTP server settings

You can specify the following advanced settings. However, these are not mandatory.

- **Helo**: The fully qualified domain name of the client, which will be sent to the SMTP server in the HELO command.

    Example: *\<Helo>pc.company.local\</Helo>*

- **MaxSubjectLength**: The maximum length of the message subject.

    Example: *\<MaxSubjectLength>78\</MaxSubjectLength>*

- **From**: A custom “From” address that will override the default “From” address specified in the DataMiner Agent interface.

    Example: *\<From>address@example.com\</From>*

#### Example of how to use GMail as SMTP server

```xml
<SMTP>
  <Host>smtp.gmail.com</Host>
  <HostPort>587-starttls</HostPort>
  <LoginMethod>AuthLoginMethod</LoginMethod>
  <User>MyGmailName@gmail.com</User>
  <Password>MyGmailPassword</Password>
</SMTP>
```

## Forcing a DataMiner Agent to work without virtual IP addresses

In the file *DataMiner.xml*, you can order a DataMiner Agent not to use virtual IP addresses.

### Disabling all virtual IP addresses

To force a DataMiner Agent not to use virtual IP addresses, do the following.

1. Stop DataMiner.

2. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

3. Add a *disableElementIP* attribute to the *\<DataMiner>* tag, and set it to “true”.

    By default, the *disableElementIP* attribute is set to “false”.

4. Save the file and restart DataMiner.

> [!NOTE]
> If the *disableElementIP* attribute is set to “true”, after a restart of the DataMiner Agent, it will no longer be possible to assign a virtual IP address to an element. Moreover, the virtual IP addresses of all existing elements will be disabled.

Example:

```xml
<DataMiner disableElementIP="true" >...</DataMiner>
```

## Setting the indexing options for the server-side search

In the file *MaintenanceSettings.xml*, you can prevent certain items from being indexed by the DataMiner Cube server-side search engine.

To do so:

1. Stop DataMiner.

2. Open the file *C:\\Skyline Dataminer\\MaintenanceSettings.xml.*

3. In the SLNet.SearchOptions tag, specify one or more of the following options. To specify multiple options, separate them by semicolons (“;”).

    Available options:

    | Option                                               | Description                                                                                                                                                                                                                                                                                                                                                       |
    |--------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | disable                                                | Search will not return anything. Indexing will be disabled on the DMA.                                                                                                                                                                                                                                                                                            |
    | excludeParams                                          | Search will not return any parameters.                                                                                                                                                                                                                                                                                                                            |
    | excludeElements                                        | Search will not return any elements.                                                                                                                                                                                                                                                                                                                              |
    | excludeServices                                        | Search will not return any services.                                                                                                                                                                                                                                                                                                                              |
    | excludeServiceTemplates                                | Search will not return any service templates.                                                                                                                                                                                                                                                                                                                     |
    | excludeRedundancy                                      | Search will not return any redundancy groups.                                                                                                                                                                                                                                                                                                                     |
    | excludeDocuments                                       | Search will not return any documents.                                                                                                                                                                                                                                                                                                                             |
    | redirectTo:*\[DMA ID\]* | Indexing will be disabled on the local DMA, and all search requests will be redirected to the DMA with the specified ID. For example, to redirect to the DMA with ID 123, specify *redirectTo:123*. <br> This option allows you to reduce load on your DMAs by redirecting all search requests to one dedicated “search-handling DMA”. |
    | trendedParamsOnly                                      | Search will only return trended parameters.                                                                                                                                                                                                                                                                                                                       |

    For example, in the following excerpt from *MaintenanceSettings.xml*, indexing has been set to “trendedParamsOnly”:

    ```xml
    <SLNet>
      <SearchOptions>trendedParamsOnly</SearchOptions>
    </SLNet>
    ```

4. Save the file and restart DataMiner.

> [!NOTE]
> - If the *\<SearchOptions>* tag is empty, then there will be no indexing restrictions. In other words, all items will be indexed.
> - If no *\<SearchOptions>* tag can be found in *MaintenanceSettings.xml*, indexing will be restricted to “trendedParamsOnly” by default.

## Setting up HTTPS on a DMA

To set up your own HTTPS web server, you must first install an SSL certificate and set up an HTTPS binding. In addition, the auto-detection settings for DataMiner must be correctly configured to avoid connection issues.

In this section:

- [Installing the HTTPS connection in IIS](#installing-the-https-connection-in-iis)

- [Setting up redirection of all HTTP traffic to HTTPS](#setting-up-redirection-of-all-http-traffic-to-https)

- [Specifying auto-detection information for an inter-DMA HTTPS connection](#specifying-auto-detection-information-for-an-inter-dma-https-connection)

- [Configuring HTTPS settings in MaintenanceSettings.xml](#configuring-https-settings-in-maintenancesettingsxml)

### Installing the HTTPS connection in IIS

1. Open IIS manager. It can be found under the Administrative Tools in the Control Panel of your computer.

2. Select the Computer name in the *Connections* pane on the left, and double-click *Server Certificates* in the pane on the right.

3. Right-click in the *Server Certificates* list and select *Import*.

4. Browse to your certificate, and click *OK*.

5. In the *Connections* pane on the left, right-click the website and select *Edit Bindings*.

6. In the *Add Site Binding* window, add an HTTPS binding with the selected certificate.

### Setting up redirection of all HTTP traffic to HTTPS

1. Install URL Rewrite 2.0 from the website <http://www.iis.net/downloads/microsoft/url-rewrite>.

    > [!NOTE]
    > This step is no longer required from DataMiner 10.0.0/10.0.2 onwards, as this module is automatically included in DataMiner upgrades from this version onwards.

2. Update the default website bindings in IIS to have both HTTP and HTTPS bindings:

    1. In IIS manager, click *Sites* in the *Connections* pane on the left.

    2. Right-click *Default Web Site* and select *Bindings*.

    3. Click *Add* to add the HTTPS binding.

3. Configure URL rewriting rules at global level:

    1. In IIS manager, select the *Default Web Site* in the *Connections* pane on the left, and double-click *URL Rewrite* in the pane on the right.

    2. Right-click in the list of rules on the right and select *Add Rule(s)*.

    3. Under *Inbound rules*, select *Blank rule*, and click *OK*.

    4. Under *Pattern*, fill in the following pattern: *(.\*)*

    5. Under *Conditions*, click *Add*, and add the following condition:

        - **Input**: {HTTPS}

        - **Type**: Matches the Pattern

        - **Pattern**: off

    6. Under *Action*, set the *Action type* to *Redirect*.

    7. Under *Redirect URL*, fill in the full HTTPS URL for your web server.

        > [!NOTE]
        > - The redirection URL should contain a placeholder {R:1} to make the redirection work properly, e.g. https://www.myhost.com/{R:1}.
        > - The HTTPS URL must match the one defined in the SSL certificate. Otherwise, users will receive warnings about an invalid certificate. SSL certificates are issued either for a specific hostname (e.g. www.skyline.be) or for all subdomains of a certain domain (e.g. \*.skyline.be).

    8. Set *Redirect type* to *Found (302)*.

> [!NOTE]
> Instead of redirecting HTTP traffic to HTTPS, it is also possible to close down HTTP completely by removing the HTTP binding, so that only HTTPS traffic is accepted.

### Specifying auto-detection information for an inter-DMA HTTPS connection

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

### Configuring HTTPS settings in MaintenanceSettings.xml

To configure a server to use HTTPS, a line needs to be added to the file *MaintenanceSettings.xml*. To do so:

1. Stop the DataMiner software.

2. On a DataMiner Agent, open the file *C:\\Skyline DataMiner\\MaintenanceSettings.xml*.

3. Add an HTTPS tag with the necessary attributes. For example:

    ```xml
    <MaintenanceSettings>
      ...
      <HTTPS enabled="true" name="foo.skyline.local"/>
      ...
    </MaintenanceSettings>
    ```

    The HTTPS tag has to contain the following attributes:

    | Attribute | Description                                                                                                                                                                                                                                                                                                                                                                                            |
    |-------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | enabled     | Enables HTTPS when set to “true”.                                                                                                                                                                                                                                                                                                                                                                      |
    | name        | Must be set to the name matching the Common Name (CN) or one of the Subject Alternative Names (SAN) of the certificate. If it is a wildcard certificate, the name must match the mask defined in the certificate (e.g. “\*.skyline.local”). For example, “dma01.skyline.be” matches the wildcard certificate for “*.skyline.be”.<br> This name should also be configured in the DNS server pointing to the IP address of the DMA, so that the DMA can be reached using the configured name.|

4. Save the file and restart the DMA.

## Changing the IP of a DMA

The way you can change the IP of a DMA depends on how your DataMiner System is set up.

### Standalone DMA

For a standalone DMA, i.e. a DMA that is not combined with other DMAs in a cluster:

1. Stop the DataMiner software on the DMA.

2. Change the IP address of the DMA server in Windows.

3. Go to the folder *C:\\Skyline DataMiner* and open the file *DB.xml*.

4. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

5. If the server hosts a Cassandra database:

    1. Open the cassandra.yaml file (typically located in the folder *C:\\Program Files\\Cassandra\\conf\\*).

    2. Replace any references to the old IP address with the new IP address, and save the file.

    3. Restart the cassandra service.

6. If the server hosts an Elasticsearch database:

    1. Open the elasticsearch.yml file (typically located in the folder *C:\\Program Files\\Elasticsearch\\config\\*).

    2. Replace any references to the old IP address with the new IP address, and save the file.

    3. Restart the elasticsearch-service-x64 service.

7. Restart DataMiner.

### Single DMA in a DMS

For a single DMA within a cluster that does not use the Cassandra cluster feature (i.e. one Cassandra cluster for the entire DMS):

1. Stop the DataMiner software on the DMA for which you want to change the IP.

2. Change the IP address of the DMA server in Windows.

3. Go to the folder *C:\\Skyline DataMiner* and open the file *DMS.xml*.

4. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

5. Go to the folder *C:\\Skyline DataMiner* and open the file *DB.xml*.

6. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

7. If the server hosts a Cassandra database:

    1. Open the cassandra.yaml file (typically located in the folder *C:\\Program Files\\Cassandra\\conf\\*).

    2. Replace any references to the old IP address with the new IP address, and save the file.

    3. Restart the cassandra service.

8. If the server hosts an Elasticsearch database:

    1. Open the elasticsearch.yml file (typically located in the folder *C:\\Program Files\\Elasticsearch\\config\\*).

    2. Replace any references to the old IP address with the new IP address, and save the file.

    3. Restart the elasticsearch-service-x64 service.

9. Restart DataMiner.

10. In System Center, go to the Agents page and remove the old IP address from the list of DMAs in the cluster.

11. From DataMiner 10.1.1 onwards, the following additional step is required in order to reset NATS:

    1. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

        > [!WARNING]
        > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

    2. Connect to the DMA with the changed IP address. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

    3. Go to the *Build Message* tab of the main window of the SLNetClientTest tool.

    4. In the *Message Type* drop-down list, select *Skyline.DataMiner.Net.Apps.NATSCustodian.NATSCustodianResetNatsRequest* and click *Send Message*.

    5. Close the SLNetClientTest tool.

### Failover DMA in a DMS

For a Failover DMA within a cluster that does not use the Cassandra cluster feature (i.e. one Cassandra cluster for the entire DMS):

1. Stop the DataMiner software on **both** Failover DMAs.

2. Change the IP address of the DMA server in Windows.

3. On the DMA of which you have changed the IP, go to the folder *C:\\Skyline DataMiner* and open the file *DB.xml*.

4. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

5. On the DMA of which you have changed the IP, go to the folder *C:\\Skyline DataMiner* and open the file *DMS.xml*.

6. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

7. On the other DMA of the Failover pair, go to the folder *C:\\Skyline DataMiner* and open the file *DMS.xml*.

8. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

9. If the DMAs hosts a Cassandra database, do the following on both DMAs:

    1. Open the cassandra.yaml file (typically located in the folder *C:\\Program Files\\Cassandra\\conf\\*).

    2. Replace any references to the old IP address with the new IP address, and save the file.

    3. Restart the cassandra service.

10. If the DMAs hosts an Elasticsearch database, do the following on both DMAs:

    1. Open the elasticsearch.yml file (typically located in the folder *C:\\Program Files\\Elasticsearch\\config\\*).

    2. Replace any references to the old IP address with the new IP address, and save the file.

    3. Restart the elasticsearch-service-x64 service.

11. Restart DataMiner on the DMA with the changed IP address.

12. Restart DataMiner on the other Failover DMA. It should start up in offline mode.

13. On the online DMA, go to System Center \> Agents, and remove the old IP address from the list of DMAs in the cluster.

14. Still on the Agents page in System Center, make sure the online Failover DMA is selected in the list on the left, and click the *Failover* button in the lower right corner to check the Failover status. For more information, see [Viewing the current Failover DMA status](xref:Viewing_the_current_Failover_DMA_status).

15. In case the Failover status is not green and there are heartbeat errors, stop DataMiner, and double-check the DMS.xml files of both DMAs to make sure all references to the old IP address have been correctly replaced.

16. From DataMiner 10.1.1 onwards, the following additional step is required in order to reset NATS:

    1. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

        > [!WARNING]
        > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

    2. Connect to the DMA with the changed IP address. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

    3. Go to the *Build Message* tab of the main window of the SLNetClientTest tool.

    4. In the *Message Type* drop-down list, select *Skyline.DataMiner.Net.Apps.NATSCustodian.NATSCustodianResetNatsRequest* and click *Send Message*.

    5. Close the SLNetClientTest tool.

### DMA in a DMS using a Cassandra cluster

If your DataMiner System uses the Cassandra cluster feature for its general database (i.e. one Cassandra cluster for the entire DMS), follow the procedure below to change the IP of one of the DMAs in the DMS:

1. Stop the DMA of which you want to change the IP.

2. Stop the Cassandra and Elasticsearch services on the DMA server.

3. Change the IP address of the DMA server in Windows.

4. Locate the file *cassandra.yaml* on the DMA. By default, it is located in the folder *C:\\Program Files\\Cassandra\\conf*.

5. Open *cassandra.yaml* in a text editor (as Administrator) and replace the IP address in the following lines with the IP of the server:

    ```txt
    listen_address: new IP
    - seeds: "new IP (, IP Cassandra node 2, IP Cassandra node 3, ...)"
    broadcast_rpc_address: new IP
    ```

6. Restart the Cassandra service.

7. In a command window, execute *nodetool status* (from the directory *C:\\Program Files\\Cassandra\\bin*), in order to check the status of the cluster. this should result in a list with your new IP, your old IP and all other Cassandra nodes on the server. For example:

    ![](~/user-guide/images/nodetoolstatus.png)

8. In the same command window, execute *nodetool removenode \[host ID of the old IP\]*, e.g. *nodetool removenode 35506039-0f03-4a1e-8642-94484d440116*.

9. Locate the *cassandra.yaml* files on the other DMAs in the DMS, as described above, and replace any occurrences of the old IP address in the seeds list in these files with the new IP address.

10. Locate the file *Elasticsearch.yml* on the DMA of which you have changed the IP. By default, it is located in the folder *C:\\Program Files\\Elasticsearch\\conf*.

11. Open *Elasticsearch.yml* in a text editor (as Administrator) and replace the IP address in the following lines with the IP of the server:

    ```txt
    discovery.zen.ping.unicast.hosts: ["new IP (, IP Cassandra node 2, IP Cassandra node 3, ...)"]
    network.publish_host: new IP
    ```

12. Restart the Elasticsearch service.

13. Locate the *Elasticsearch.yml* files on the other DMAs in the DMS, as described above, and replace any occurrences of the old IP address in the *discovery.zen.ping.unicast.hosts* field of these files with the new IP address.

14. Open the file *DB.xml* from the Skyline DataMiner folder of the DMA with the new IP, and replace the old IP in the DB tags for the Cassandra and Elasticsearch databases with the new IP address.

    > [!TIP]
    > See also:
    > [DB.xml](xref:DB_xml#dbxml)

15. Open the file DB.xml for all other DMAs in the DMS, and replace the old IP address with the new IP address for both Cassandra and Elasticsearch.

16. Restart DataMiner.

17. Reset NATS:

    1. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

        > [!WARNING]
        > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

    2. Connect to the DMA with the changed IP address. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

    3. Go to the *Build Message* tab of the main window of the SLNetClientTest tool.

    4. In the *Message Type* drop-down list, select *Skyline.DataMiner.Net.Apps.NATSCustodian.NATSCustodianResetNatsRequest* and click *Send Message*.

    5. Close the SLNetClientTest tool.

> [!TIP]
> See also:
> [Migrating the general database to a DMS Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster)

## Switching between DataMiner configurations on a DMA

For staging, demo and testing purposes, you can maintain different DataMiner configurations on one DataMiner Agent and switch between them in a matter of seconds. If necessary, each of these configurations can use a different DataMiner software version. Note that only one of the configurations can be active at any given time.

When adding a DataMiner configuration to a DMA, you can select

- an upgrade package to add a new, blank installation, or

- a backup package to restore a backup of an existing configuration.

> [!WARNING]
> DataMiner configuration switching should never be enabled on an operational system. Only enable this feature on systems used for staging, demo or testing purposes.

> [!TIP]
> See also:
> [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility)

### Enabling DataMiner configuration switching on a DMA

1. Take a backup of the *C:\\Skyline DataMiner* folder, and make sure it is not shared.

2. Stop DataMiner Taskbar Utility.

    > [!NOTE]
    > If this tool has never been run on the current DMA, then start it and immediately stop it.

3. Start Notepad.exe as Administrator, and open the following file:

    *C:\\Program Files (x86)\\Skyline Communications\\Skyline Taskbar Utility\\ApplicationSettings.xml*

4. Locate the *\<AdvancedOptions>* tag, and set it to “true”:

    ```xml
    <AdvancedOptions>true</AdvancedOptions>
    ```

5. Locate the *\<ConfigFolderPath>* tag, and set it to the folder that should contain the DataMiner configurations for the DMA. This can for instance be a folder on the D drive. By default, it is set to *C:\\Skyline DataMiner Configs\\*.

    The folder *C:\\Skyline DataMiner* will be linked to the configuration that is currently running, but will not actually contain any data. All configurations will be stored at the configured path.

6. Save the *ApplicationSettings.xml* file.

7. Start DataMiner Taskbar Utility as an Administrator who has full control over the C drive.

8. Right-click DataMiner Taskbar Utility in the notification area, select *Start Using Configs*, and confirm.

    The current contents of the *C:\\Skyline DataMiner* folder and all its subfolders will now be copied to the specified configurations folder.

    > [!NOTE]
    > DataMiner Taskbar Utility will stop the running DataMiner software to make sure that none of the files in *C:\\Skyline DataMiner* are locked. In certain rare cases, however, files can be locked by third-party processes. If this is the case, then you will have to kill those processes manually and retry step 7.

### Adding DataMiner configurations to a DMA

1. Right-click DataMiner Taskbar Utility in the notification area, select *Use Config \> Manage Configs ...*

2. In the *Manage Configs* dialog box, click *Add*.

3. In the *Add Config* dialog box, enter the name of the configuration and click either *Blank config* or *Existing config*.

    - If you clicked *Blank config*, then select an upgrade package, and click *Open*.

    - If you clicked *Existing config*, then select a backup package, and click *Open*.

4. Click *Create* to install the package you selected.

> [!NOTE]
> - For a new configuration, it is possible that the files “ConnectionSettings.txt” and “EndPoints.txt” are missing in the *Webpages* folder of a particular configuration. In that case, copy them to this folder from the folder *C:\\Skyline DataMiner Configs\\Skyline DataMiner\\Webpages*.
> - After you have created a new configuration, it is possible that the DMA has problems restarting, so a manual restart is advisable.

### Switching to another DataMiner configuration

- Right-click DataMiner Taskbar Utility in the notification area, click *Use Config*, and select one of the listed DataMiner configurations.
