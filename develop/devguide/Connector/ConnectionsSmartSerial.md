---
uid: ConnectionsSmartSerial
description: Smart-serial devices reply with a response upon receiving a command, just like serial devices, but they can also send unsolicited messages.
---

# Smart Serial

A so-called "smart serial" device behaves much like a serial device: when it receives a command (e.g. from a DataMiner Agent) it will reply with a response. The difference between a "smart serial" and a serial protocol, however, is that a "smart serial" device is also able to send unsolicited messages (e.g. to a DataMiner Agent) without having received a command requesting a response.

Therefore, it can be that the DMA acts as a server or as a client. When it acts as a server, it will open a port on the DMA on which it will listen for data. As client, it will connect to a remote IP and port in order to listen for data.

The device sends data to a specified port and DataMiner reads this data while trying to match it with existing responses.

DataMiner supports smart serial communication allowing protocols to define one or more connections of type smart serial. DataMiner runs a process called "SLPort" which takes care of all communication to and from devices connected to either a serial port or an IP port.

In contrast to a serial protocol, a pure smart serial protocol typically only contains responses, i.e. no pairs or commands are defined. It is still possible to send commands though.

It is important to define the responses in such a way that data meant for a certain response is not stored in another response. When you define a response consisting of only one "next param" parameter, this response will always be used even if another response exists that could match.

> [!NOTE]
>
> - Devices supporting smart serial communication typically implement a proprietary, vendor-specific smart serial communication protocol.
> - Smart-serial works on TCP and UDP. For UDP, the client address is saved in order to know where the answer on a smart serial command should be sent. This means that only 1 client/socket should be used. If multiple clients use the same socket, it is possible that the last client will receive several of the responses, depending on how quickly they are processed by the DMA.

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
