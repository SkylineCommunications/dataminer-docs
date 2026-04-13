---
uid: ConnectionsSerial
---

# Serial

When communicating with a serial device, a DataMiner Agent will send commands to the device and the latter will reply with a response for each command.

> [!NOTE]
>
> - Devices supporting serial communication often implement a proprietary, vendor-specific serial communication protocol. However, public standardized protocols are also possible (e.g., Modbus).
> - Serial devices cannot send unsolicited messages to a DataMiner Agent; devices only send responses to commands sent by DataMiner.

The communication will occur over TCP/IP, UDP, or, less commonly, over a serial cable.

> [!NOTE]
> It is possible to create a serial simulation using an element stream or DataMiner simulation file as input for our [*Skyline Serial Simulator* protocol](https://catalog.dataminer.services/details/b5130a4e-b05b-449b-9c5a-2cc65ab62948).

DataMiner supports serial communication, allowing protocols to define one or more connections of type "serial". DataMiner runs a process called "SLPort", which takes care of all communication to and from devices connected to either a serial port or an IP port.

## See also

- [Slow poll mode ping group](xref:ConnectionsPingGroup)

DataMiner Protocol Markup Language:

- [Protocol.Commands](xref:Protocol.Commands)
- [Protocol.Responses](xref:Protocol.Responses)
- [Protocol.Pairs](xref:Protocol.Pairs)
- [Protocol.Pairs.Pair@options](xref:Protocol.Pairs.Pair-options):
  - [ignoreTimeout](xref:Protocol.Pairs.Pair-options#ignoretimeout)
  - [receiveInterval](xref:Protocol.Pairs.Pair-options#receiveinterval)
- [Protocol.Type](xref:Protocol.Type): serial and serial single
- [Protocol.Type@communicationOptions](xref:Protocol.Type-communicationOptions):
  - [chunkedHTML](xref:Protocol.Type-communicationOptions#chunkedhtml) (obsolete)
  - [closeConnectionOnResponse](xref:Protocol.Type-communicationOptions#closeconnectiononresponse) (obsolete)
  - [makeCommandByProtocol](xref:Protocol.Type-communicationOptions#makecommandbyprotocol)
  - [redundantPolling](xref:Protocol.Type-communicationOptions#redundantpolling)
- [Protocol.Triggers.Trigger.On](xref:Protocol.Triggers.Trigger.On)
- [Protocol.Actions.Action.Type](xref:Protocol.Actions.Action.Type):
  - [clear](xref:LogicActionClear)
  - [close](xref:LogicActionClose)
  - [open](xref:LogicActionOpen)
  - [stuffing](xref:LogicActionStuffing)
- [Protocol.Actions.Action.On: response](xref:Protocol.Actions.Action.On)
- [Protocol.Params.Param.Type](xref:Protocol.Params.Param.Type):
  - [crc](xref:Protocol.Params.Param.Type#type)
  - [group](xref:Protocol.Params.Param.Type#group)
  - [header](xref:Protocol.Params.Param.Type#headertrailer)/[trailer](xref:Protocol.Params.Param.Type#headertrailer)
  - [length](xref:Protocol.Params.Param.Type#length)
  - [read bit](xref:Protocol.Params.Param.Type#read-bit)
  - [write bit](xref:Protocol.Params.Param.Type#write-bit)
- [Protocol.Params.Param.Type@times](xref:Protocol.Params.Param.Type-times)
- [Protocol.Params.Param.Type@options](xref:Protocol.Params.Param.Type-options):
  - [dynamic ip](xref:Protocol.Params.Param.Type-options#dynamic-ip)
  - [ssh pwd](xref:Protocol.Params.Param.Type-options#ssh-pwd)
  - [ssh username](xref:Protocol.Params.Param.Type-options#ssh-username)
