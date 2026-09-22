---
metadata_version: 1
uid: ConnectionsSmartSerial
description: "Smart-serial devices reply with a response upon receiving a command, just like serial devices, but they can also send unsolicited messages."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Smart-serial connections

A so-called "smart serial" device behaves much like a serial device: when it receives a command (e.g., from a DataMiner Agent) it will reply with a response. The difference between a "smart serial" and a serial protocol, however, is that a "smart serial" device is also able to send unsolicited messages (e.g., to a DataMiner Agent) without having received a command requesting a response.

Therefore, it can be that the DMA acts as a server or as a client. When it acts as a server, it will open a port on the DMA on which it will listen for data. As client, it will connect to a remote IP and port in order to listen for data.

The device sends data to a specified port and DataMiner reads this data while trying to match it with existing responses.

DataMiner supports smart serial communication allowing protocols to define one or more connections of type smart serial. DataMiner runs a process called "SLPort" which takes care of all communication to and from devices connected to either a serial port or an IP port.

**Schema requirement:** Use the exact protocol type value `smart-serial` or `smart-serial single` in the [Protocol.Type](xref:Protocol.Type) element. The `single` variant gives the connection a dedicated socket instead of sharing a socket with other elements.

In contrast to a serial protocol, a pure smart-serial protocol typically only contains responses, i.e., no pairs or commands are defined. It is still possible to send commands though.

It is important to define the responses in such a way that data meant for a certain response is not stored in another response. When you define a response consisting of only one "next param" parameter, this response will always be used even if another response exists that could match.

> [!NOTE]
>
> - Devices supporting smart serial communication typically implement a proprietary, vendor-specific smart serial communication protocol.
> - Smart-serial works on TCP and UDP. For UDP, the client address is saved in order to know where the answer on a smart-serial command should be sent. **Recommendation:** Use only one client/socket for UDP; if multiple clients share a socket, the last client processed by the DMA can receive several responses.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Type@communicationOptions](xref:Protocol.Type-communicationOptions):
  - [maxConcurrentConnections](xref:Protocol.Type-communicationOptions#maxconcurrentconnections)
  - [maxReceiveBuffer=X](xref:Protocol.Type-communicationOptions#maxreceivebufferx)
  - [notifyConnectionPIDs:x,y](xref:Protocol.Type-communicationOptions#notifyconnectionpidsxy)
  - [packetInfo](xref:Protocol.Type-communicationOptions#packetinfo)
  - [smartIpHeader](xref:Protocol.Type-communicationOptions#smartipheader)
- [Protocol.Params.Param.Type@options](xref:Protocol.Params.Param.Type-options):
  - [headerTrailerLink](xref:Protocol.Params.Param.Type-options#headertrailerlink)
- [Protocol.PortSettings.FlushPerDatagram](xref:Protocol.PortSettings.FlushPerDatagram)
