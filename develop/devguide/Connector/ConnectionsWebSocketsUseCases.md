---
uid: ConnectionsWebSocketsUseCases
---

# Use Cases

## Code Implementation

Before we go into the four different use cases you need to implement the code below to make sure WebSockets work correctly in DataMiner. The IDs can be changed as desired.

### Connection

To create a WebSocket, define a new WebSocket connection in the protocol. The Connection tag needs to be included in the **Protocol.Connections** tag.

```xml
<Connection id="1" name="WebSocket Connection">
    <Http>
    <CommunicationOptions>
        <WebSocket>true</WebSocket>
        <NotifyConnectionPIDs>
            <Connections>7</Connections>
        </NotifyConnectionPIDs>
        <MakeCommandByProtocol>true</MakeCommandByProtocol>
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

### Triggers

Each implementation of a WebSocket should have the following triggers.

- Before Each Command
  
    ```xml
    <Trigger id="30">
        <Name>Before Each Command</Name>
        <On id="each">command</On>
        <Time>before</Time>
        <Type>action</Type>
        <Content>
            <Id>30</Id>
        </Content>
    </Trigger>
    ```

- Before Each Response

    ```xml
    <Trigger id="31">
        <Name>Before Each Response</Name>
        <On id="each">response</On>
        <Time>before</Time>
        <Type>action</Type>
        <Content>
            <Id>31</Id>
        </Content>
    </Trigger>
    ```

### Actions

For each trigger you will need an action.

- Make Command

    ```xml
    <Action id="30">
        <Name>Make Command Action</Name>
        <On>command</On>
        <Type>make</Type>
    </Action>
    ```

- Read Response

    ```xml
    <Action id="31">
        <Name>Read Response Action</Name>
        <On>response</On>
        <Type>read</Type>
    </Action>   
    ```

### Commands

- WebSocket works with commands to subscribe/unsubscribe. In the **Protocol.Commands** tag, add a command.

    ```xml
    <Command id="1">
        <Name>WebsocketHeartbeat</Name>
        <Description>Websocket Heartbeat</Description>
        <WebSocketMessageType>text</WebSocketMessageType>
        <Content>
            <Param>10</Param>
        </Content>
    </Command>
    ```

- This command uses the command data from parameter 10. In this example, we have a heartbeat.

    ```xml
    <Param id="10" trending="false">
        <Name>WebsocketHeartbeatRequest</Name>
        <Description>Websocket Heartbeat Request</Description>
        <Type>read</Type>
        <Interprete>
            <RawType>other</RawType>
            <Type>string</Type>
            <LengthType>next param</LengthType>
        </Interprete>
    </Param>
    ```

### Responses

- The responses will come back in the **Protocol.Responses** tag.

    ```xml
    <Response id="1">
        <Name>Generic Response</Name>
        <Description>Generic Response</Description>
        <Content>
            <Param>11</Param>
        </Content>
    </Response>
    ```

- Each response will be set to parameter 11.

    ```xml
    <Param id="11" trending="false">
        <Name>GenericResponse</Name>
        <Description>Generic Response</Description>
        <Type>read</Type>
        <Interprete>
            <RawType>other</RawType>
            <Type>string</Type>
            <LengthType>next param</LengthType>
        </Interprete>
    </Param>
    ```

- It is necessary to clear the response after processing the data. You can do this with "**protocol.CheckTrigger(32);**" in the QAction. Add a trigger which will execute an action.

    ```xml
    <Trigger id="32">
        <Name>On Check Trigger Clear Generic Response</Name>
        <Type>action</Type>
        <Content>
            <Id>32</Id>
        </Content>
    </Trigger>
    ```

- Add the action to clear parameter 11.

    ```xml
    <Action id="32">
        <Name>Clear Generic Response</Name>
        <On id="11">parameter</On>
        <Type>clear</Type>
    </Action>
    ```

### Pairs

- Each command and response should be paired together. In the **Protocol.Pairs** tag, add a pair for each command. It is possible that the same response is used for different commands.

    ```xml
    <Pair id="1">
        <Name>WebsocketHeartbeat</Name>
        <Description>Websocket Heartbeat</Description>
        <Content>
            <Command>1</Command>
            <Response>1</Response>
        </Content>
    </Pair>
    ```

### Params

- This parameter should be added and displayed to show the status of the WebSocket:

    ```xml
    <Param id="7" trending="true">
        <Name>WebsocketStatus</Name>
        <Description>Websocket Status</Description>
        <Type>read</Type>
        <Information>
            <Subtext>
                <![CDATA[Status of the Websocket.
    0: Closed
    1: Open]]>
            </Subtext>
        </Information>
        <Interprete>
            <RawType>numeric text</RawType>
            <LengthType>next param</LengthType>
            <Type>double</Type>
        </Interprete>
        <Alarm>
            <Monitored>true</Monitored>
            <Normal>1</Normal>
            <CH>0</CH>
        </Alarm>
        <Display>
            <RTDisplay>true</RTDisplay>
        </Display>
        <Measurement>
            <Type>discreet</Type>
            <Discreets>
                <Discreet>
                    <Display>Closed</Display>
                    <Value>0</Value>
                </Discreet>
                <Discreet>
                    <Display>Open</Display>
                    <Value>1</Value>
                </Discreet>
            </Discreets>
        </Measurement>
    </Param>
    ```

## Use cases

There are four different use cases:
For each use case, the WebSocket connection is **ws://127.0.0.1:8050/x-nmos/events/ws**

When the handshake is done and parameter 7 is *Open*, it is possible to send commands.

- <xref:ConnectionsWebSocketsUseCase1>
- <xref:ConnectionsWebSocketsUseCase2>
- <xref:ConnectionsWebSocketsUseCase3>
- <xref:ConnectionsWebSocketsUseCase4>

### Handshake Details Postman

```text
    Request URL: http://10.110.1.52:8050/x-nmos/events/ws
    Request Method: GET
    Status Code: 101 Switching Protocols
    Request Headers
        Sec-WebSocket-Version: 13
        Sec-WebSocket-Key: LJSbyasLGZ8sgQ65iUicBg==
        Connection: Upgrade
        Upgrade: websocket
        Sec-WebSocket-Extensions: permessage-deflate; client_max_window_bits
        Host: 10.110.1.52:8050
    Response Headers
        Connection: Upgrade
        Date: Mon, 05 Dec 2022 14:00:33 GMT
        Server: Kestrel
        Upgrade: websocket
        Sec-WebSocket-Accept: kQimL57sB/A/lK8k1BOmU2c09WM=
```
