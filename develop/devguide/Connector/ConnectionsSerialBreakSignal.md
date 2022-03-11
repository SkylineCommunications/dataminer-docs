---
uid: ConnectionsSerialBreakSignal
---

# Break signal

A device might require a "break" signal in order to know when a command is sent to it. For example, the Harmonic CPS4200 uses a break signal.

- Normal commands will be sent to connection 0
- Break signals will be sent to connection 1

Before a break signal is sent, the action "open protocol connection 0" (the other connection) must be sent to open the port of the connection where normal commands will be sent.

```xml
<Action id="40001">
   <On>protocol</On>
   <Type nr="0">open</Type>
</Action>
```

This action is generally called by a trigger before command 40001 (set comm break).

```xml
<Trigger id="6">
   <On id="40001">Command</On><!-- SetCommBreak -->
   <Time>before</Time>
<Type>action</Type>
   <Content>
      <Id>40001</Id><!-- Action 40001: open protocol -->
   </Content>
</Trigger>
```

The flow for sending commands using break signals is:

1. Open connection 0 (trigger before command setcommbreak, with the action described above).
1. Send Set Comm Break (in general this is command/pair/group 40001).
1. Send Clear Comm Break (in general this is command/pair/group 40002).

When using multiple elements for the same device, lock and unlock protocol actions will need to be used. In that case, you have to add a trigger before group "set commbreak" to execute actions to lock port 0 and port 1. After the group(s) of the normal command, unlock actions will be required.

- Set Commbreak command: 0x21 0x00
- Response: 0x21 OK
- Clear Commbreak command: 0x22 0x00
- Response: 0x22 OK

On the pairs of the normal commands, an option “commbreak” needs to be specified to indicate that they need to wait for the commbreak, as illustrated in the following example.

```xml
<Pair id="1000" options="commbreak:7"><!--General Module Info-->
  <Name>General Module Info</Name>
   <Description></Description>
   <Content>
      <Command>1000</Command><!-- General Module Info -->
      <Response>1000</Response>
   </Content>
</Pair>
```
