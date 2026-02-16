---
uid: Protocol.PortSettings.LocalIPport
---

# LocalIPport element

Specifies the local IP port configuration.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.LocalIPport.DefaultValue)|[0, 1]|Specifies the default local port number.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.LocalIPport.Disabled)|[0, 1]|Specifies whether the local port number can be configured via the DataMiner user interface.|

## Remarks

> [!NOTE]
> This is only applicable for serial (or serial single) connections over TCP/IP or UDP/IP.

The local IP port refers to the port of the client socket used by DataMiner to set up a connection with the server. The server (e.g., Data Source) listens on a specific port, which is configured in the element edit wizard (and for which a default value can be provided using the IpPort tag).

![Local IP port](~/develop/schemadoc/Protocol/images/LocalIpPort.svg)

By default, an available port number is automatically selected for the client socket. This setting is therefore by default not configurable when you create or edit an element. However, in case you do need to specify a specific client port number to be used, you can use the *LocalIpPort.DefaultValue* tag to provide a default local port to be used and enable the setting by setting *LocalIpPort.Disabled* to false. Now, when you create or edit an element, you will see an additional configuration setting "Local IP port" (under "more TCP/IP settings" or "more UDP/IP settings").

> [!NOTE]
>
> - You cannot have multiple client sockets that use the same local port for a specific communication protocol (e.g., TCP) connecting to a different IP:port destination.
>
>   For example, in case you try to create another element with a connection with the same local port specified but another destination IP:port, you will notice the following error in Stream Viewer: SOCKET ERROR : 10048
>
>   This indicates that the address is already in use. (For more information, refer to <https://docs.microsoft.com/en-us/windows/win32/winsock/windows-sockets-error-codes-2>)
>
> - For connections where DataMiner acts as a client, the SLPort process creates a client socket for each (destination IP, destination port, local port) tuple. This means that e.g., in case you have two elements with a serial connection that specify the same destination IP and destination port but do not specify a local port, those elements will use the same socket in SLPort.
