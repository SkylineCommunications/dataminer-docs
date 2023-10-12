---
uid: ConnectionsSerial
---

# Serial

In this section:

- <xref:ConnectionsSerialIntroduction>
- <xref:ConnectionsSerialCreatingCommandsAndResponses>
- <xref:ConnectionsSerialPairs>
- <xref:ConnectionsSerialBreakSignal>
- <xref:ConnectionsSerialDisplayingBytesAsNumbers>
- <xref:ConnectionsSerialSeriallyPollingDevices>
- <xref:ConnectionsSerialSerialSingle>
- <xref:ConnectionsSerialDynamicPolling>
- <xref:ConnectionsSerialSecureShell>
- <xref:ConnectionsSerialSslTls>
- <xref:ConnectionsSerialSocketBuffer>
- <xref:ConnectionsSerialExercise>

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
  - [chunkedHTML](xref:Protocol.Type-communicationOptions#chunkedhtml) (obsolete with the new HTTP driver functionality)
  - [closeConnectionOnResponse](xref:Protocol.Type-communicationOptions#closeconnectiononresponse) (obsolete with the new HTTP driver functionality)
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
