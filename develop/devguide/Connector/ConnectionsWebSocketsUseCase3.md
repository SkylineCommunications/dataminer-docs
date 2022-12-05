---
uid: ConnectionsWebSocketsUseCase3
---

# WebSocket Connection with Custom Handshake

The WebSocket connection with Custom Handshake is used when some headers need to initialize the connection. This should be configured in the **Connections.Connection.CommunicationOptions.WebSocketHandshake** tag. The id in this tag is the HTTP Session of the handshake. With a custom handshake, you need to add a new HTTP session to establish the handshake.

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
        <Request verb="GET" url="8">
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

- Parameter 8 contains the default value **x-nmos/events/ws**. It is possible to make a write parameter on this value and save parameter 8. After a restart it will use the saved value to connect to the WebSocket Connection.

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

- For this handshake, we need an extra header, add the correct header key and place its value in an parameter. Parameter 9 is used for the header. It has a default value.

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

- The response status code and content are not necessary in the **Connection** tag. Those can be removed if they are not used.

> [!NOTE]
> This use case gives you already some more functionality on generating a customizable handshake.
>
> It is not possible to reconnect the WebSocket Connection.
