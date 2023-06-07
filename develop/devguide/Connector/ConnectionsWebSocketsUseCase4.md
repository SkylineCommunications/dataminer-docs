---
uid: ConnectionsWebSocketsUseCase4
---

# WebSocket Connection with custom handshake and dynamic IP

The WebSocket connection with custom handshake and dynamic IP is used when some headers need to initialize the connection and when it should be possible to reconnect the WebSocket connection.

On every change of the parameter, the previous connection will be gracefully closed and the new one will be set up. This can be done with a button to re-establish the connection.

> [!NOTE]
> This use case provides more functionality to generate a customizable handshake, and after a disconnection of the WebSocket, it is possible to reconnect without an element restart.

> [!TIP]
> See also: [WebSocket use cases](xref:ConnectionsWebSocketsUseCases)

## WebSocketHandshake configuration

This should be configured in the *Connections.Connection.CommunicationOptions.WebSocketHandshake* tag. The ID in this tag is the HTTP session of the handshake. With a custom handshake, you need to add a new HTTP session to establish the handshake.

```xml
<Connection id="1" name="WebSocket Connection">
   <Http>
   <CommunicationOptions>
      <WebSocket>true</WebSocket>
      <NotifyConnectionPIDs>
         <Connections>7</Connections>
      </NotifyConnectionPIDs>
      <MakeCommandByProtocol>true</MakeCommandByProtocol>
      <WebSocketHandshake>25</WebSocketHandshake>
   </CommunicationOptions>
   <UserSettings>
      <BusAddress>
         <DefaultValue>byPassProxy</DefaultValue>
      </BusAddress>
      <IPport>
         <DefaultValue>8050</DefaultValue>
      </IPport>
      <TimeoutTime>
         <DefaultValue>5000</DefaultValue>
      </TimeoutTime>
   </UserSettings>
   </Http>
</Connection>
```

## HTTP.Session configuration

```xml
<Session id="25" name="WebSocket Handshake">
   <Connection id="1">
      <Request verb="GET" pid="8">
         <Headers>
            <Header key="Sec-WebSocket-Extensions" pid="9"></Header>
         </Headers>
      </Request>
      <Response statusCode="220">
         <Content pid="270" />
      </Response>
   </Connection>
</Session>
```

Parameter 8 contains the default value *x-nmos/events/ws*. It is possible to make a write parameter on this value and save parameter 8. After a restart, the saved value will be used to establish the WebSocket connection.

```xml
<Param id="8" trending="false" save="true">
   <Name>WebsocketUrl</Name>
   <Description>Websocket URL</Description>
   <Type>read</Type>
   <Information>
      <Subtext>This is the last part of the WebSocket connection URL.</Subtext>
   </Information>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
      <DefaultValue>x-nmos/events/ws</DefaultValue>
   </Interprete>
   <Display>
      <RTDisplay>true</RTDisplay>
   </Display>
   <Measurement>
      <Type>string</Type>
   </Measurement>
</Param>
```

For this handshake, an extra header is needed. Add the correct header key and place its value in a parameter. Parameter 9 is used for the header. It has a default value.

```xml
<Param id="9" trending="false">
   <Name>Header</Name>
   <Description>Header</Description>
   <Type>read</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
      <DefaultValue>permessage-deflate; client_max_window_bits</DefaultValue>
   </Interprete>
</Param>
```

The response status code and content are not necessary in the *Connection* tag. Those can be removed if they are not used.

## Dynamic IP configuration

For information about the dynamic IP configuration, see:

- [Dynamically changing the IP address and port number](xref:ConnectionsWebSocketsDynamicIp)
- [Dynamic polling](xref:ConnectionsSerialDynamicPolling)
