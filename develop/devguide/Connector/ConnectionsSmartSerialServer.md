---
uid: ConnectionsSmartSerialServer
---

# Configuring a smart-serial connection as a server

It is possible to configure a smart-serial connection so that it acts as a server.

This is achieved by specifying "any" for the IP address and specifying a port on which you want DataMiner to listen locally.

When a regular IP address is specified, the connection will act as a client and will make a connection with the specified port on the specified IP address.

> [!NOTE]
> In case you want two smart-serial elements to communicate with each other on the same DMA, one element, which will act as a server, should have as IP address "any", whereas the other element should have as IP address "127.0.0.2". This will be interpreted by DataMiner as a remote IP address and this element will act as client.

## Obtaining information about the connected clients

See [notifyConnectionPIDs:x,y](xref:Protocol.Type-communicationOptions#notifyconnectionpidsxy).

## Specifying the maximum number of clients that can be connected simultaneously

See [maxConcurrentConnections](xref:Protocol.Type-communicationOptions#maxconcurrentconnections).

## Prefix packet data with originating IP and port

See [smartIpHeader](xref:Protocol.Type-communicationOptions#smartipheader).

## Specifying the allowed IP addresses

For each smart-serial server port of type TCP, elements can have a list of IP addresses configured from which they will accept incoming messages and to which they will forward messages.<!-- RN 23592, RN 23673, RN 23694, RN 23739 -->

- When, for a particular smart-serial server port, an element has a list of allowed IP addresses configured, it will
  - accept messages only from those IP addresses, and
  - forward messages only to those IP addresses.
- When, for a particular smart-serial server port, an element does not have a list of allowed IP addresses configured, it will
  - accept messages from all IP addresses that have not been added to an "allowed IP addresses" list linked to that port, and
  - forward messages only to IP addresses that have not been added to an "allowed IP addresses" list linked to that port.
- If none of the elements that use a particular smart-serial server port have allowed IP addresses configured for that port, they will receive all messages from all elements using that port and forward all messages to all elements using that port.

By default, this "allowed IP addresses" functionality is disabled.

In the Protocol.xml file of a smart-serial element, you can enable or disable the AllowedIPAddresses functionality by setting AllowedIPAddresses.Disabled to "false" in the user settings of the smart-serial connection. In the following example, the functionality has been enabled.

```xml
<Connections>
  <Connection name="Smart-Serial Server" id="0">
     <SmartSerial>
        <UserSettings>
           <AllowedIPAddresses>
              <Disabled>false</Disabled>
           </AllowedIPAddresses>
        </UserSettings>
     </SmartSerial>
  </Connection>
</Connections>
```

## Replying to a single client

<!-- RN 5955 -->

When using smart serial over IP, multiple clients can connect to the port. When DataMiner takes the initiative to send data, this data is broadcast to all connected clients.

When a specific client sends data, the response should only be sent back to that specific client. This can be obtained by using a trigger "after response".

All groups executed as a result of a trigger 'after response' are sent to the client that sent the command.

## Message queue limitation

From DataMiner 10.6.6/10.7.0 onwards<!--RN 45273-->, the total size of incoming smart-serial messages per element that still needs to be processed is limited to prevent an ever-growing queue.

If more than 200 MB of messages are waiting in the queue, a notice alarm is generated to warn that the maximum limit is being approached.

When more than 300 MB of messages are waiting in queue, an error alarm is generated and no additional incoming messages are accepted until the queue drops below 200 MB again. At that point, the error alarm becomes a notice alarm that remains active, even when the queue is empty, indicating that part of the communication was lost.

Log entries are added to the *SLErrorsInProtocol.txt* file when the warning threshold or maximum limit is exceeded.

> [!IMPORTANT]
> If the maximum limit of 300 MB has been reached, we strongly recommend restarting the element. When messages within a data stream are dropped, incomplete data streams may be processed, which can lead to unexpected results.
> If these kind of notices are constantly generated, it is an indication that the element is not able to process the incoming messages fast enough. This could have different causes and solutions. The source that is sending the messages could be configured to send less messages if possible, or the connector could be revised to see if there could be any improvement made to allow faster processing of the messages. Another cause could be that the element is not getting enough CPU because at that moment an other element is taking most of the CPU. It could also be possible that the QAction that processes the incoming messages in the connector is stuck and not able to process new messages. In such case, the advice would be to take memory dumps with the LogCollector and contact support to have it further investigated.
