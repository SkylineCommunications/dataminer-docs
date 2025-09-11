---
uid: DataMiner_hardening_guide
description: This guide will give you a comprehensive overview to help you make the necessary changes to secure your DataMiner System as much as possible.
keywords: hardening, hardening guide, security
---

# DataMiner hardening guide

In today’s digital landscape, properly securing your data and systems is of the utmost importance. You should therefore go beyond the out-of-the-box DataMiner configuration and take the necessary steps to make sure your DataMiner configuration is as secure as possible.

This guide will give you a comprehensive overview to help you make the necessary changes to secure your DataMiner System as much as possible.

> [!TIP]
> See also: [Kata #29: DataMiner Hardening](https://community.dataminer.services/courses/kata-29/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Keep your system up to date

Your first step should be to make sure your system is always up to date. This includes the operating system and all installed software. This way, you have access to the latest security fixes and features.

To obtain the most recent version of DataMiner and related software, go to the [Downloads page on DataMiner Dojo](https://community.dataminer.services/downloads/).

## Use BPA tests

A good start for hardening your DataMiner System is to make use of the available BPA tests. These scan your DataMiner System for all sorts of issues and will help you resolve any detected issues.

For information on how to run these tests, refer to [Running BPA tests](xref:Running_BPA_tests).

From DataMiner 10.4.5/10.4.0 [CU3] onwards, you can run the [Security Advisory BPA test](xref:BPA_Security_Advisory) to run all security-related checks at the same time. In earlier DataMiner versions (starting from DataMiner 10.2.12/10.3.0), the security checks are available in the following dedicated BPA tests:

- [Database Security](xref:BPA_Database_Security)
- [Firewall Configuration](xref:BPA_Firewall_Configuration)
- [HTTPS Configuration](xref:BPA_Https_Configuration)

After you have run a BPA test, it will provide an overview of the detected issues and point you to the right documentation to resolve them.

## DataMiner Agent hardening

> [!NOTE]
> If you have deployed DataMiner using the [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk), your system will be hardened out of the box, so you do not need to do anything to harden DataMiner. For an overview of the implemented measures, refer to [DataMiner Dojo](https://community.dataminer.services/download/overview-hardening-pre-installed-dataminer-vhdx/). However, note that if you have selected the data storage type *Self-hosted - External Storage*, you are responsible for the management of the external Cassandra and OpenSearch database clusters. See [Secure self-managed DataMiner storage](#secure-self-managed-dataminer-storage).

### Secure Cube-server communication

From DataMiner 10.5.10/10.6.0 onwards<!-- RN 43506 -->, Cube uses gRPC by default to communicate with DataMiner, which means no further action is needed to secure this communication.

However, prior to this, Cube uses .NET Remoting to communicate with DataMiner. This communication is encrypted using the Rijndael algorithm using a 256-bit key, which is negotiated over a 1024-bit RSA encrypted communication channel. However, .NET Remoting is a legacy technology and is widely considered insecure. Therefore, starting from DataMiner 10.3.2/10.3.0, we recommend that you manually enable gRPC for the client-server connection.

To manually enable gRPC for the client-server connection, edit the *ConnectionSettings.txt* file on each DataMiner Agent. For detailed information, refer to [ConnectionSettings.txt](xref:ConnectionSettings_txt).

> [!IMPORTANT]
> To use gRPC, your DMAs must use HTTPS connections. If this is not the case yet, make sure to [set up HTTPS](xref:Setting_up_HTTPS_on_a_DMA) first.

> [!NOTE]
> Prior to DataMiner 10.5.10/10.6.0, the gRPC connection feature is still a beta feature, which means you may still encounter issues and the connection might still be less stable than with .NET Remoting.

### Secure server-server communication

#### gRPC

From DataMiner 10.5.10/10.6.0 onwards<!-- RN 43506 -->, gRPC is used by default for communication between DataMiner Agents, which means no further action is needed to secure this communication.

In earlier DataMiner versions, like for the communication with DataMiner Cube, you can also use gRPC for the inter-DMA communication instead of .NET Remoting from DataMiner 10.3.2/10.3.0 onwards.

To enable gRPC for the communication between DataMiner Agents in a cluster, add [redirects in DMS.xml](xref:DMS_xml#redirects-subtag) or, from **10.3.6/10.3.0 [CU3] onwards**, disable .NET Remoting completely in [MaintenanceSettings.xml](xref:Configuration_of_DataMiner_processes#disabling-net-remoting).

> [!NOTE]
> Prior to DataMiner 10.5.10/10.6.0, the gRPC connection feature is still a beta feature, which means you may still encounter issues and the connection might still be less stable than with .NET Remoting.

#### NATS

By default, NATS does not employ TLS encryption, leaving communication susceptible to eavesdropping. Consequently, we strongly recommend [enabling TLS encryption for enhanced security within your NATS cluster](xref:Security_NATS).

### Disable legacy components

DataMiner has some components that are considered legacy. They are still around to support existing setups that depend on them, but if you have a new setup or you want to secure your existing setup, we recommend disabling them. Currently we recommend disabling the *Annotations* component, the legacy *Reports and Dashboards* component, and the v0 api.

#### Annotations and legacy Reports and Dashboards

To disable both the *Annotations* component and the legacy *Reports and Dashboards* component:

1. Add the following code in the `C:\Skyline DataMiner\SoftLaunchOptions.xml` file:

   ```xml
   <SLNet>
      <LegacyAnnotations>false</LegacyAnnotations>
      <LegacyReportsAndDashboards>false</LegacyReportsAndDashboards>
   </SLNet>
   ```

1. To make the changes take effect, run the *ConfigureIIS.bat* script, located in the `C:\Skyline DataMiner\Tools` folder, as Administrator.

> [!NOTE]
> The legacy *Annotations* and *Reports and Dashboards* modules are disabled by default as from DataMiner versions 10.4.0/10.4.1.

#### v0 API

To disable the v0 API:

1. Open the file `C:\Skyline DataMiner\Webpages\API\Web.config`.

1. Add the tag `<add key="enableLegacyV0Interface" value="false"/>` tag under `<appSettings>`, and save the file.

1. Restart IIS.

> [!NOTE]
> The v0 API is disabled by default as from DataMiner versions 10.2.0/10.1.6. It is not possible to enable the v0 API when your DMS is connected to dataminer.services.

## DataMiner Webpages hardening

### HTTPS

By default, DataMiner uses HTTP to serve the web applications. HTTP is unencrypted and vulnerable to man-in-the-middle attacks, so we highly recommend [setting up HTTPS](xref:Setting_up_HTTPS_on_a_DMA) instead.

### HTTP headers

By default, DataMiner does not configure some HTTP headers that improve the security of the webpages. Additionally, depending on the DataMiner version, some HTTP headers may be present by default that leak information about the underlying technologies. For this reason, we recommend having a look at the [HTTP header configuration](xref:HTTP_Headers).

## Operating system hardening

### TLS versions

In addition to enabling HTTPS, we also recommend that you configure your operating system to **block deprecated SSL/TLS versions**. HTTPS uses SSL/TLS for encrypting communication, but the older versions of this protocol are no longer considered secure. At present, all major browsers support the latest TLS version (TLS 1.3), but TLS 1.2 is also still regarded as secure.

| Protocol | Published | Status |
|--|--|--|
| SSL 1.0 | Unpublished | N/A |
| SSL 2.0 | 1995 | Deprecated since 2011 |
| SSL 3.0 | 1996 | Deprecated since 2015 |
| TLS 1.0 | 1999 | Deprecated since 2020 |
| TLS 1.1 | 2006 | Deprecated since 2020 |
| TLS 1.2 | 2008 | Supported |
| TLS 1.3 | 2018 | Supported (most secure) |

For more information about disabling legacy SSL/TLS versions, refer to [TLS, DTLS, and SSL protocol version settings](https://learn.microsoft.com/en-us/windows-server/security/tls/tls-registry-settings?tabs=diffie-hellman#tls-dtls-and-ssl-protocol-version-settings) in the Microsoft documentation. We have also made tools and scripts available for this [on GitHub](https://github.com/SkylineCommunications/windows-hardening), or you can use third-party tools such as [IIS Crypto](https://www.nartac.com/Products/IISCrypto).

### Configure the firewall

Depending on which version of the DataMiner Installer is used, different firewall ports are opened by default. You can find more information about this below.

#### [Installer v10.4](#tab/tabid-1)

If DataMiner is installed with the **DataMiner Installer v10.4**, the following (inbound) ports and rules are opened in the Windows firewall:

- TCP 80: HTTP

- TCP 8004: Remoting (client-server & inter-DMS communication)

- TCP 5100: CloudGateway (dataminer.services endpoint)

- TCP 4222 and 6222: NATS (inter-process communication)

- TCP 9090: NATS Account Server

- UDP 162: SNMP

- Allow ICMP: Ping

Some of the ports that are opened by default can potentially be closed depending on the configuration of your DataMiner System:

- TCP port **80** can be closed if IIS is configured to require HTTPS connections and if IIS is not configured to redirect HTTP to HTTPS. We highly recommended enabling HTTPS on your DataMiner System. Note that TCP port 443 needs to be open for HTTPS connections. For more information, see [Setting up https on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

- TCP port **8004** can be closed if the DMA is configured to use gRPC for both Cube-to-DMA and inter-DMA communication.

- The ports for NATS communication, i.e. **4222, 6222, and 9090**, can be closed when the DMA is not part of a cluster.

- TCP port **5100** can be closed when the DMA is not part of a cluster and no DxMs are hosted on external machines.

#### [Installer v10.2](#tab/tabid-2)

On DataMiner versions installed using the **DataMiner Installer v10.2**, the DataMiner installation opens the following (inbound) ports and rules in the Windows firewall:

- TCP 80: HTTP

- TCP 8004: Remoting (client-server & inter-DMS communication)

- TCP 7000: Cassandra (inter-node communication)

- TCP 9042: Cassandra (client-server communication)

  > [!NOTE]
  > This rule and the one above for TCP 7000 only apply when the DataMiner System uses a Cassandra database that is installed on the same machine as DataMiner. If Cassandra is configured to use TLS, port 7001 and 9142 are used instead. For detailed information on securing Cassandra, refer to [secure self-managed storage](#secure-self-managed-dataminer-storage).

- TCP 9200: Elasticsearch (client-server communication)

- TCP 9300: Elasticsearch (inter-node communication)

  > [!NOTE]
  > This rule and the one above for TCP 9200 only apply when the DataMiner System uses an Elasticsearch database that is installed on the same machine as DataMiner.

- TCP 4222 and 6222: NATS (inter-process communication)

- TCP 9090: NATS Account Server

- UDP 162: SNMP

- Allow ICMP: Ping

Some of the ports that are opened by default can potentially be closed depending on the configuration of your DataMiner System:

- TCP port **80** can be closed if IIS is configured to require HTTPS connections and if IIS is not configured to redirect HTTP to HTTPS. We highly recommended enabling HTTPS on your DataMiner System. Note that TCP port 443 needs to be open for HTTPS connections. For more information, see [Setting up https on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

- TCP port **8004** can be closed if the DMA is configured to use gRPC for both Cube-to-DMA and inter-DMA communication.

- The ports for NATS communication, i.e. **4222, 6222, and 9090**, can be closed when the DMA is not part of a cluster.

- If DataMiner is not installed on the same machine as Cassandra/Elasticsearch, the respective ports can be closed.

> [!NOTE]
> From DataMiner 10.3.6/10.4.0 onwards (or in earlier versions used with DataMiner CloudGateway 2.10.0 or higher), inbound **TCP port 5100** communication should also be enabled, because this is required for communication with dataminer.services via the endpoint hosted in DataMiner CloudGateway. When you upgrade, the [Firewall Configuration](xref:BPA_Firewall_Configuration) BPA will run to check wether this port is correctly configured.

#### [Installer v10.0 (or older)](#tab/tabid-3)

On DataMiner versions installed using the **DataMiner Installer v10.0 (or older)**, the DataMiner installation opens the following (inbound) ports and rules in the Windows firewall:

- TCP 23: Telnet

- TCP 80: HTTP

- TCP 8004: Remoting (client-server & inter-DMS communication)

- TCP 9004: Web Services (end of life)

- TCP 7000: Cassandra (inter-node communication)

- TCP 9042: Cassandra (client-server communication)

  > [!NOTE]
  > This rule and the one above for TCP 7000 only apply when the DataMiner System uses a Cassandra database that is installed on the same machine as DataMiner. If Cassandra is configured to use TLS, port 7001 and 9142 are used instead. For detailed information on securing Cassandra, refer to [secure self-managed storage](#secure-self-managed-dataminer-storage).

- TCP 9200: Elasticsearch (client-server communication)

- TCP 9300: Elasticsearch (inter-node communication)

  > [!NOTE]
  > This rule and the one above for TCP 9200 only apply when the DataMiner System uses an Elasticsearch database that is installed on the same machine as DataMiner.

- TCP 4222, 6222, 8222: NATS (inter-process communication)

- TCP 9090: NATS Account Server

- UDP 161, 162, 362: SNMP (disabled by default)

- Allow Remote Administration

- Allow ICMP: Ping

Some of the ports that are opened by default can potentially be closed depending on the configuration of your DataMiner System:

- TCP port **80** can be closed if IIS is configured to require HTTPS connections and if IIS is not configured to redirect HTTP to HTTPS. We highly recommended enabling HTTPS on your DataMiner System. Note that TCP port 443 needs to be open for HTTPS connections. For more information, see [Setting up https on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

- TCP port **8004** can be closed if the DMA is configured to use gRPC for both Cube-to-DMA and inter-DMA communication.

- The ports for NATS communication, i.e. **4222, 6222, and 9090**, can be closed when the DMA is not part of a cluster.

- If DataMiner is not installed on the same machine as Cassandra/Elasticsearch, the respective ports can be closed.

Some ports that are displayed above are no longer opened by default during DataMiner installation with newer versions of the installer. However, to avoid breaking changes, these ports are **not closed when you upgrade an existing DataMiner System** that was installed with an installer prior to version 10.1. We therefore recommend that you verify if any of the following ports can be closed manually:

- TCP port **23** can be closed if the DataMiner Telnet feature is disabled. For more information, see [DataMiner.Telnet](xref:DataMiner.Telnet).

- TCP port **9004** can always be closed in the currently supported DataMiner versions.

- TCP port **8222** can always be closed. The port is closed by default from 10.1.12 CU0 and 10.2.0 CU0 onwards.

- UDP ports **161 and 362** can be closed if the DataMiner SNMP Agent feature is disabled, which is by default the case in the currently supported DataMiner versions. For more information, see [Enabling DataMiner SNMP agent functionality](xref:Enabling_DataMiner_SNMP_agent_functionality).

- The **Remote Administration** is only required when the DataMiner server is monitored by a remote element using the Microsoft Platform protocol. This is for example the case when two DataMiner Agents are used in a Failover setup, and both servers are monitored through the Microsoft Platform protocol.

- **ICMP** is only required when Failover heartbeats are active or the *pingCount* attribute in the *DMS* tag in *DMS.xml* is set to a value greater than 0. For more information, see [Attributes of the DMS tag](xref:DMS_xml#attributes-of-the-dms-tag). Allowing ICMP is also useful to debug connectivity issues.

> [!NOTE]
> From DataMiner 10.3.6/10.4.0 onwards (or in earlier versions used with DataMiner CloudGateway 2.10.0 or higher), inbound **TCP port 5100** communication should also be enabled, because this is required for communication with dataminer.services via the endpoint hosted in DataMiner CloudGateway. When you upgrade, the [Firewall Configuration](xref:BPA_Firewall_Configuration) BPA will run to check wether this port is correctly configured.

***

> [!TIP]
> See also: [Configuring the IP network ports](xref:Configuring_the_IP_network_ports)

### Disable the local Administrator account

DataMiner has one built-in user, named "Administrator". This user is the local administrator on the Windows server hosting DataMiner and intended for recovery and initial configuration purposes. Once Operator users have been created, we recommend disabling the local Administrator user on the DataMiner server.

## Secure self-managed DataMiner storage

If you do not make use of [Storage as a Service (STaaS)](xref:STaaS) but manage DataMiner storage yourself, you need to make sure that the databases used for DataMiner storage are fully secure.

If you use on-premises databases, we recommend using a [Cassandra cluster and OpenSearch cluster](xref:Dedicated_clustered_storage). It is important that you spend some time making sure the configuration of these databases is as secure as possible. For detailed information, refer to [Securing Cassandra](xref:Cassandra_authentication), [Securing OpenSearch](xref:Security_OpenSearch), or [Securing Elasticsearch](xref:Security_Elasticsearch).

> [!NOTE]
>
> - If you do use Storage as a Service, Skyline will take care of protecting your data, making use of existing and secure storage solutions provided by [Microsoft Azure](https://learn.microsoft.com/en-us/azure/storage/common/storage-introduction).
> - Previously, Elasticsearch was recommended as the on-premises indexing database instead of OpenSearch. For more information on why OpenSearch is now recommended instead, see [From Elasticsearch to OpenSearch to StaaS](https://community.dataminer.services/from-elasticsearch-to-opensearch-to-staas/).
