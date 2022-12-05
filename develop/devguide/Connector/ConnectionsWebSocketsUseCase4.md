---
uid: ConnectionsWebSocketsUseCase4
---

# WebSocket Connection with Custom Handshake and Dynamic IP

The WebSocket connection with Custom Handshake and Dynamic IP is used when some headers need to initialize the connection. This should be configured in the **Connections.Connection.CommunicationOptions.WebSocketHandshake** tag. The id in this tag is the HTTP Session of the handshake. With a custom handshake, you need to add a new HTTP session to establish the handshake.
It is also possible to reconnect the WebSocket connection.

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

## HTTP Session

```xml
<Session id="25" name="WebSocket Handshake">
    <Connection id="1">
        <Request verb="GET" url="50">
            <Headers>
                <Header key="Sec-WebSocket-Extensions" pid="15"></Header>
            </Headers>
        </Request>
        <Response statusCode="220">
            <Content pid="270" />
        </Response>
    </Connection>
</Session>
```

- Parameter 50 contains the default value **x-nmos/events/ws**. It is possible to make a write parameter on this value and save parameter 50. After a restart it will use the saved value to connect to the WebSocket Connection.

    ```xml
    <Param id="50" trending="false" save="true">
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

- For this handshake, we need an extra header, add the correct header key and place its value in an parameter. Parameter 15 is used for the header. It has a default value.

    ```xml
    <Param id="15" trending="false">
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

- The response status code and content are not necessary in the **Connection** tag. Those can be removed if they are not used.

## Dynamic IP

- <xref:ConnectionsWebSocketsDynamicIp>
- <xref:ConnectionsSerialDynamicPolling>

On every change of the parameter, the previous connection will be gracefully closed and the new one will be set up. This can be done with a button to re-establish the connection.

> [!NOTE]
> This use case gives you already some more functionality on generating a customizable handshake.
>
> After a disconnection of the WebSocket, it is possible to reconnect with the WebSocket without an element restart.
