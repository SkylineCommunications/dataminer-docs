---
uid: ConnectionsSmartSerialBehaviorAfterDisconnect
---

# Smart-Serial behavior after a physical device disconnect

This section describes the behavior of a smart-serial TCP connection when a device becomes unreachable. Suppose a protocol is implemented to send a command to the device every 5 s and at some point, the device become unreachable (e.g., due to a disconnection of a cable).

Suppose at time X the device becomes unreachable and at time X + 1 s DataMiner will send a command. As prior to time X, the TCP connection was OK, DataMiner will send the command. As there is no response defined in the pair, DataMiner will consider this group finished at this point.

However, the underlying TCP connection will try to send this command to the device. As TCP provides reliable data transfer, the data to be sent will be buffered until it is sure the data was received by the receiver. Consequently, DataMiner could send the same command every 5 s and this would then get buffered at the send buffer of the underlying TCP connection. This means that whenever the device becomes available again, all data that has been buffered will be sent to the device, which can result in a burst of multiple commands that will be processed by the device.

Note that there is retransmission timeout on a TCP, so the above-described behavior is only applicable as long as this retransmission timeout has not been reached. For more information about the retransmission timeout, refer to https://support.microsoft.com/en-us/help/170359/how-to-modify-the-tcp-ip-maximum-retransmission-time-out.

In some cases, this behavior could be undesirable. For example, suppose you perform a booking of a device via smart-serial TCP: the booking command is sent, but at that point in time the device is unreachable, the booking would fail, which is OK. But if the device comes back online after some time,  it will still configure itself to the settings sent by the booking command.

In order to avoid this, the following approach can be taken, which involves implementing a mechanism to detect a disconnect. This can be done through sending heartbeat messages if the device supports this. This heartbeat message is then sent frequently (e.g., every second) and as soon as there is no response for a number of heartbeat messages (e.g., 3), it is assumed that the device is disconnected. At this point, a close connection action is performed, which is immediately followed by an open connection command. This will ensure that the current TCP connection will be closed (preventing any data that was in the send buffer from being sent). This will cause the [Connection State] parameter (parameter ID 65045) in the [Connection Info] table on the GENERAL PARAMETERS page of the element to go into the "Disconnected" state for this connection.

The info of this parameter is then copied to a parameter in the protocol, which in turn is used in a condition on all groups that use this smart-serial connection. If this parameter equals "Responding"(0) or "Connected" (3), the group is executed. After a "Connected" (pid:65045 == 3), an action is triggered putting all the initial polling back on the queue.

```xml
<Measurement>
   <Type>discreet</Type>
   <Discreets>
      <Discreet>
         <Display>Responding</Display>
         <Value>0</Value>
      </Discreet>
      <Discreet>
         <Display>Not Responding</Display>
         <Value>1</Value>
      </Discreet>
      <Discreet>
         <Display>Undefined</Display>
         <Value>2</Value>
      </Discreet>
      <Discreet>
         <Display>Connected</Display>
         <Value>3</Value>
      </Discreet>
      <Discreet>
         <Display>Disconnected</Display>
         <Value>4</Value>
      </Discreet>
   </Discreets>
</Measurement>
```

![Smart-serial behavior after a physical device disconnect](~/develop/images/SmartSerialTCP.svg)
