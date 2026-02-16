---
uid: Connection_strings
---

# Connection strings

## About connection strings between DataMiner Agents

In most cases, when you add a DataMiner Agent to a DataMiner System, all other DataMiner Agents in the DataMiner System connect to it using its primary IP address. When that happens, the SLNet process of one DMA connects to the SLNet process of a different DMA to transfer messages.

However, in certain specific cases, the SLNet-to-SLNet connection cannot be established using the defaults supplied by DataMiner. This is where connection strings come in. These will clarify what SLNet needs to do in order to be able to connect to an SLNet process on a different DMA.

> [!IMPORTANT]
> It is always preferable to use the default connection instead of connection strings, as connection strings come with certain limitations (see below).

## When should you use connection strings?

Typically, this is used in the following cases:

- When you want to use a non-default communication type. For example, when you want to use gRPC but still keep .NET remoting enabled (supported from DataMiner 10.3.0/10.3.2 onwards<!-- RN 34983 -->).

  > [!NOTE]
  > Configuring connection strings for gRPC allows the system to still use .NET remoting outside of the configured connection. If the former is not necessary, instead of configuring connection strings for gRPC, consider [disabling .NET remoting in *MaintenanceSettings.xml*](xref:Configuration_of_DataMiner_processes#disabling-net-remoting) to make your DataMiner server fully rely on gRPC. See [Secure server-server communication — gRPC](xref:DataMiner_hardening_guide#grpc)

- When the DataMiner Agents are unable to authenticate with each other and you wish to specify the credentials of a Windows user with Administrator privileges to work around this.

  It will typically become clear from the `C:\Skyline DataMiner\Logging\SLNet.txt` log if DataMiner Agents are unable to authenticate between each other. This may occur in setups where the DMAs are in different domains.

In some existing setups, connection strings are also used in the cases below. However, these configurations should not be used on newer systems. Changing ports or IP addresses may also require other changes in the DMS, such as NATS tweaks or tweaks in other configuration files.

- When Agents have been configured to listen on non-standard ports.

  The standard ports are 8004 for .NET Remoting or 443 for gRPC. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

- When Agents cannot be reached directly on their primary IP address.

  For example: Network Address Translation, a proxy, a gateway, etc. blocks access to the primary IP address.

  > [!IMPORTANT]
  > Configuring the connection strings to translate an unreachable internal IP address to a reachable external one prevents the DataMiner upgrade client from upgrading the entire DMS at once. Any DMA on which this is configured will need to be upgraded separately. Tweaks to the default NATS configuration will also be needed. We therefore recommend ensuring that the primary IP address of each DMA is reachable instead (e.g., by setting up a virtual network).

## How can you configure connection strings?

At present, there are two places where connection strings can be configured:

- Via **SLNetClientTest tool**: see [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string).
- Via redirects in **DMS.xml**: see [Redirects subtag](xref:DMS_xml#redirects-subtag).

In practice, connection strings are read and consumed by the software directly from *DMS.xml*. As such, configuring these in SLNetClientTest tool have exactly the same effect as if they were configured in *DMS.xml*.

The advantage of using **SLNetClientTest** tool is that the entire DMS can be configured from **one single client**, while for a configuration directly in *DMS.xml*, each DMA needs to be configured separately (including Failover Agents, which need a redirect to each other's IP address). In addition, **no DataMiner restart** will be needed, while direct changes to *DMS.xml* always require a DataMiner restart.

However, one advantage of configuring redirects directly in **DMS.xml** is that this file represents the configuration as seen by DataMiner directly, while the UI of SLNetClientTest tool provides another layer of abstraction that may obfuscate things.

### Use cases

The use cases below show the configuration for an **example local DMA with primary IP 148.0.10.68**.

The table headers in the table below match the elements/attributes you should specify in [DMS.xml](xref:DMS_xml#redirects-subtag). If you use [SLNetClientTest](xref:SLNetClientTest_editing_connection_string) tool, the *Redirect To* column matches the *To* field, the *Via* column matches the *New Connection String* field, and the *User* column matches the *Username (optional)* field.

#### Current use cases

| <div style="width:250px">Purpose of the connection string</div> | Redirect to | Via |  User | Password |
|--|--|--|--|--|
| To use gRPC but still keep .NET remoting enabled. | 148.0.10.68 | `http://148.0.10.68/APIGateway` | / | / |
| To specify the credentials of a Windows user with Administrator privileges to work around authentication issues | `148.0.10.68` or `*` for all DMAs simultaneously | / | Username of local user with admin rights | Password of that local user |

#### Legacy use cases

The legacy use cases below are only to be used as a reference for existing setups. Changing ports or IP addresses may require other changes in the DMS, such as NATS tweaks or tweaks in other configuration files. **Do not use these configurations in recent DataMiner Systems**.

| <div style="width:250px">Purpose of the connection string</div> | Redirect to | Via |  User | Password |
|--|--|--|--|--|
| To ensure Agents listen on non-standard port. Only applicable for .NET remoting connections. | 148.0.10.68 | In the following syntax, replace the custom port with the one you set up: `http://148.0.10.68:8004/SLNetService` | / | / |
| To reach DMAs that cannot be reached directly on their primary IP address.<br>**Not recommended** (see [When should you use connection strings?](#when-should-you-use-connection-strings)) | 148.0.10.68 | IP address of proxy/NAT/etc. via HTTP, e.g., `http://172.10.10.56`|/|/|
