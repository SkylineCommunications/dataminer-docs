---
uid: DataMiner_hardening_guide
---

# DataMiner hardening guide

In today’s digital landscape, properly securing your data and systems is of the utmost importance. You should therefore go beyond the out-of-the-box DataMiner configuration and take the necessary steps to make sure your DataMiner configuration is as secure as possible.

This guide will give you a comprehensive overview to help you make the necessary changes to secure your DataMiner System as much as possible.

## Keep your system up to date

Your first step should be to make sure your system is always up to date. This includes the operating system and all installed software. This way, you have access to the latest security fixes and features.

To obtain the most recent version of DataMiner and related software, go to the [Downloads page on DataMiner Dojo](https://community.dataminer.services/downloads/).

## Use BPA tests

The next step to start hardening DataMiner is to make use of the available BPA tests. These scan your DataMiner System for all sorts of issues and will help you resolve any detected issues.

For information on how to run these tests, refer to [Running BPA tests](xref:Running_BPA_tests).

There are many BPA tests available, but these are the most important ones in relation to this guide:

- [Database Security](xref:BPA_Database_Security)
- [Firewall Configuration](xref:BPA_Firewall_Configuration)
- [HTTPS Configuration](xref:BPA_Https_Configuration)

All three of these are available by default from DataMiner 10.2.12/10.3.0 onwards.

After you have run these BPA tests, they will provide an overview of the detected issues and point you to the right documentation to resolve them.

## Secure client-server communication

### Web apps

By default, DataMiner uses HTTP to serve the web applications. HTTP is unencrypted and vulnerable to man-in-the-middle attacks, so we highly recommend [setting up HTTPS instead](xref:Setting_up_HTTPS_on_a_DMA).

In addition, we also recommend that you configure your operating system to **block deprecated SSL/TLS versions**. HTTPS uses SSL/TLS for encrypting communication, but the older versions of this protocol are no longer considered secure. At present, all major browsers support the latest TLS version (TLS 1.3), but TLS 1.2 is also still regarded as secure.

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

### DataMiner Cube

By default, Cube currently uses .NET Remoting to communicate with DataMiner. From DataMiner 10.1.7 onwards, this communication is encrypted using the Rijndael algorithm using a 256-bit key, which is negotiated over a 1024-bit RSA encrypted communication channel. However, .NET Remoting is a legacy technology and is widely considered insecure. For this reason, DataMiner 10.3.2/10.3.0 introduces the possibility to use gRPC instead as a secure alternative.

> [!IMPORTANT]
> The gRPC connection feature is still a beta feature in DataMiner 10.3.2/10.3.0 CU0, which means you may still encounter issues and the connection might still be less stable than with .NET Remoting.

To enable gRPC for the client-server connection, edit the *ConnectionSettings.txt* file on each DataMiner Agent. For detailed information, refer to [ConnectionSettings.txt](xref:ConnectionSettings_txt).

## Secure server-server communication

Like for the communication with DataMiner Cube, for the inter-DMA communication, you can also use gRPC instead of .NET Remoting from DataMiner 10.3.2/10.3.0 onwards.

> [!IMPORTANT]
> The gRPC connection feature is still a beta feature in DataMiner 10.3.2/10.3.0 CU0, which means you may still encounter issues and the connection might still be less stable than with .NET Remoting.

To enable gRPC for the communication between DataMiner Agents in a cluster, add [redirects in DMS.xml](xref:DMS_xml#redirects-subtag).

## Disable legacy components

DataMiner has some components that are considered legacy. They are still around to support existing setups that depend on them, but if you have a new setup or you want to secure your existing setup, we recommend disabling them. Currently we recommend disabling the *Annotations* component and the legacy *Reports and Dashboards* component. You can do so by adding the following code in the `C:\Skyline DataMiner\SoftLaunchOptions.xml` file:

```xml
<SLNet>
   <LegacyAnnotations>false</LegacyAnnotations>
   <LegacyReportsAndDashboards>true</LegacyReportsAndDashboards>
</SLNet>
```

To make the changes take effect, you then need to run the *ConfigureIIS.bat* script located in the `C:\Skyline DataMiner\Tools` folder.

## Configure the firewall

On DataMiner versions installed using the **10.0 installer** (or older), the DataMiner installation opens the following (inbound) ports and rules in the Windows firewall:

- TCP **23**: Telnet (disabled by default)

- TCP 80: HTTP

- TCP 8004: Remoting (client-server & inter-DMS communication)

- TCP **9004**: Web Services (end of life)

- TCP 7000: Cassandra (inter-node communication)

- TCP 9042: Cassandra (client-server communication)

  > [!NOTE]
  > This rule and the one above for TCP 7000 only apply when the DataMiner System uses a Cassandra database locally.

- TCP 9200: Elasticsearch (client-server communication)

- TCP 9300: Elasticsearch (inter-node communication)

  > [!NOTE]
  > This rule and the one above for TCP 9200 only apply when the DataMiner System uses an Elasticsearch database locally.

- TCP 4222, 6222, **8222**: NATS (inter-process communication)

- TCP 9090: NATS Account Server

- UDP **161**, 162, **362**: SNMP (disabled by default)

- Allow **Remote Administration**

- Allow ICMP: Ping

If you use the **DataMiner 10.1 installer or a more recent installer**, the ports that are displayed in bold above are no longer opened by default during DataMiner installation. However, to avoid breaking changes, these ports are **not closed when you upgrade an existing DataMiner System** that was installed with an installer prior to version 10.1. We therefore recommend that you verify if any of the following ports can be closed manually:

- TCP port **23** can be closed if the DataMiner Telnet feature is disabled. For more information, see [DataMiner.Telnet](xref:DataMiner_xml#dataminertelnet).

- TCP port **80** can be closed if IIS is configured to require HTTPS connections. We highly recommended enabling HTTPS on your DataMiner System. Note that TCP port 443 needs to be open for HTTPS connections. For more information, see [Setting up https on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

- TCP port **9004** can always be closed from DataMiner 10.0.11 CU0 and 10.0.0 CU6 onwards.

- TCP port **8222** can always be closed. This will be the default from 10.1.12 CU0 and 10.2.0 CU0 onwards.

- The ports for NATS communication (**4222, 6222, and 9090**) can be closed when the DMA is not part of a cluster.

- UDP ports **161 and 362** can be closed if the DataMiner SNMP Agent feature is disabled, which is the case by default from DataMiner 9.6.11 onwards. However, if a DMA was installed prior to DataMiner 9.6.11 and is upgraded to DataMiner 9.6.11 or higher, this functionality will remain enabled until it is manually disabled. For more information, see [Enabling DataMiner SNMP agent functionality](xref:Enabling_DataMiner_SNMP_agent_functionality).

> [!NOTE]
> From DataMiner 10.3.6/10.4.0 onwards (or in earlier versions used with DataMiner CloudGateway 2.10.0 or higher), inbound **TCP port 5100** communication should also be enabled, because this is required for communication to the cloud via the endpoint hosted in DataMiner CloudGateway. When you upgrade, the [Firewall Configuration](xref:BPA_Firewall_Configuration) BPA will run to check wether this port is correctly configured.

The **Remote Administration** rule must be enabled when the DataMiner server is monitored by a remote element using the Microsoft Platform protocol. This is for example the case when two DataMiner Agents are used in a Failover setup, and both servers are monitored through the Microsoft Platform protocol.

**ICMP** is only required when Failover heartbeats are active or the *pingCount* attribute in the *DMS* tag in *DMS.xml* is set to a value greater than 0. For more information, see [Attributes of the DMS tag](xref:DMS_xml#attributes-of-the-dms-tag). Allowing ICMP is also useful to debug connectivity issues.

> [!TIP]
> See also: [Configuring the IP network ports](xref:Configuring_the_IP_network_ports)

## Secure the databases

Cassandra and Elasticsearch form a crucial part of recent DataMiner Systems. For this reason, it is important that you spend some time making sure their configuration is as secure as possible. For detailed information, refer to [Securing the DataMiner databases](xref:Database_security).
