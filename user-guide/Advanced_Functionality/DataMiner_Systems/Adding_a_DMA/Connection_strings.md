---
uid: Connection_strings
---

# Connection strings

## What are connection strings?

In most cases, when you add a DataMiner Agent to a DataMiner System, all other DataMiner Agents in the DataMiner System connect to it using its primary IP address. When that happens, the SLNet process of one DMA connects to the SLNet process of a different DataMiner agent to transfer messages.

However, in certain specific cases, the aforementioned SLNet-to-SLNet connection cannot be established using the defaults supplied by DataMiner.
That is where *connection strings* come in.
They can clarify what SLNet needs to do in order to be able to connect to an SLNet process on a different DMA.

> [!WARNING]
> It is always preferable to use the default connection over the use of connection strings as connection strings come with certain limitations.

## When should you use connection strings?

When agents have been configured to listen on non-standard ports.

- The standard ports are 8004 for .NET Remoting or 443 for gRPC. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

When you want to use a non-default communication type.

- E.g. You want to use gRPC, yet still keep .NET remoting enabled.

> [!TIP]
> Configuring connection strings for gRPC allows the system to still use .NET remoting outside of the configured connection. If the former is not necessary, instead of configuring connection strings for gRPC, consider disabling .NET remoting in case you want your DataMiner server to fully rely on gRPC.
> See [Secure server-server communication - gRPC](xref:DataMiner_hardening_guide#grpc)

When agents cannot be reached directly on their primary IP address.

- E.g. they have *Network Address Translation, a proxy, a gateway, ...* blocking access to the primary IP address.

> [!IMPORTANT]
> Configuring the connection strings to translate an unreachable internal IP address to a reachable external one prevents the DataMiner upgrade client from upgrading the entire DMS at once.
> Any DMA on which this is configured will need to be upgraded separately.
> Therefore, we recommend ensuring that the primary IP address of each DMA is reachable (e.g. by setting up a virtual network).

When the DataMiner agents are unable to authenticate with each other and you wish to specify the credentials of a Windows user with Administrator privileges to work around this.

- It will typically become clear from the C:\Skyline DataMiner\Logging\SLNet.txt log if DataMiner agents are unable to authenticate between each other. May occur in setups where the DMAs are in different domains.

## Where can you configure connection strings?

As of now, there are two places where connection strings can be configured:

1. Via *SLNetClientTest tool*.
1. Via *Redirects* in *DMS.xml*

In practice, connection strings are read and consumed by the software directly from DMS.xml.
As such, configuring these in SLNetClientTest tool have exactly the same effect as if they were configured in DMS.xml.

The advantage of using SLNetClientTest tool is that the entire DMS can be configured from one single client, whereas for a configuration in DMS.xml, each DMA needs to be configured separately. Additionally, configurations done using SLNetClientTest tool usually do not require a DataMiner restart, whereas a configuration done in DMS.xml can only be done whilst the DataMiner agent is down and thus requires a DataMiner restart for each distinct DataMiner.
An advantage of configuring redirects in DMS.xml, however, is that DMS.xml represents the configuration as seen by DataMiner directly, whereas the UI of SLNetClientTest tool provides another layer of abstraction that may obfuscate things.

## How can you configure connection strings?

### Syntax of the connection strings

For more information on when you could use these connection strings, please see [Where can you configure connection strings?](#where-can-you-configure-connection-strings).

Please see the following example.

**Local DMA primary IP:** 148.0.10.68

### By configuring redirects in DMS.xml

For the relevant xml elements of the connection strings: see [DMS.xml](xref:DMS_xml#redirects-subtag).
In the tables below you can match these elements/attributes to the table headers.

#### Typical use cases

| Purpose of the connection string | Redirect to | Via |  User | Password |
|--|--|--|--|--|
| To use gRPC, yet still keep .NET remoting enabled. | 148.0.10.68 | `http://148.0.10.68/APIGateway` | / | / |
| To specify the credentials of a Windows user with Administrator privileges to work around authentication issues | `148.0.10.68` or `*`for all DMAs simultaneously | / | Username of local user with Admin rights | password of said user |

#### Legacy use cases

> [!IMPORTANT]
> The legacy use cases before are only to be used as reference for existing setups.
> Changing ports or IP addresses may require other changes to be made in the DMS, such as NATS tweaks or may require tweaks in other configuration files.

| Purpose of the connection string | Redirect to | Via |  User | Password |
|--|--|--|--|--|
| To ensure agents listen on non-standard port. | 148.0.10.68 | Define port using following syntax, replacing the custom port by the one you set up earlier. e.g. `http://148.0.10.68:8004/SLNetService` | / | / |

> [!WARNING]
> This only works for .NET remoting connections and should not be done on newer systems.
> This example is only illustrative for older systems.

| Purpose of the connection string | Redirect to | Via |  User | Password |
|--|--|--|--|--|
| To reach DMAs which cannot be reached directly on their primary IP address | 148.0.10.68 | IP address of proxy/NAT/... via http e.g. `http://172.10.10.56`|/|/|

> [!WARNING]
> This should not be configured on newer systems.
> Configuring the connection strings to translate an unreachable internal IP address to a reachable external one prevents the DataMiner upgrade client from upgrading the entire DMS at once.
> Any DMA on which this is configured will need to be upgraded separately.
> Therefore, we recommend ensuring that the primary IP address of each DMA is reachable (e.g. by setting up a virtual network).
> Furthermore, additional tweaks to the default NATS configuration are needed.

### By editing the connection strings in SLNetClientTest tool

See [By configuring redirects in DMS.xml](#by-configuring-redirects-in-dmsxml), and filling in the fields:

- *To* with the value found in column *Redirect To*
- *New Connection String* with the value found in column *Via*
- *Username (optional)* with the value found in column *User*
- *Password:* with the value found in column *Password*

Also see [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string).
