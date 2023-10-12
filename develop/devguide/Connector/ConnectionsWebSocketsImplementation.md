---
uid: ConnectionsWebSocketsImplementation
---

# Implementing a WebSocket

DataMiner supports WebSockets since version 8.5.7 (RN 9962). To create a WebSocket, define a new WebSocket connection in the protocol. The Connection tag needs to be included in the Protocol.Connections tag.

```xml
<Connection id="1" name="WebSocket Connection Panel">
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
            <DefaultValue>bypassProxy</DefaultValue>
         </BusAddress>
         <IPport>
            <DefaultValue>80</DefaultValue>
         </IPport>
         <TimeoutTime>
            <DefaultValue>1500</DefaultValue>
         </TimeoutTime>
      </UserSettings>
  </Http>
</Connection>
```

By default, DataMiner will construct a default opening handshake. However, it is possible to define a custom WebSocket opening handshake, by defining an HTTP request in the protocol. This must be a Session with only one Connection and every value must be a configured parameter where the value is a parameter ID that contains the value. The custom WebSocket opening handshake is then referred to through the WebSocketHandshake tag.

For example:

```xml
<HTTP>
   <Session id="1">
      <Connection id="1">
         <Request verb="GET" url="/">
            <Headers>
               <Header key="Use-Cookie" pid="80" />
            </Headers>
         </Request>
      </Connection>
   </Session>
</HTTP>
```

This results in the following opening handshake:

```xml
GET /chat HTTP/1.1
Host: server.example.com
Use-Cookie: [value of parameter 80]
Upgrade: websocket
Connection: Upgrade
Sec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==
Sec-WebSocket-Protocol: chat
Sec-WebSocket-Version: 13
```

If the URL used to set up the connection comes from a parameter value, e.g. from parameter 10, then specify url="10" (hard-coded values are not supported for the url attribute).

For example, suppose you need to connect to ws://10.4.2.8:4601/x-nmos/events, then there are two possibilities:

- If the IP address/host and port are known by the operator and the last part of the URL is fixed:
  - Set “ws://10.4.2.8” as the IP address/host of the element in DataMiner Cube.
  - Set “4601” as the IP port of the element in DataMiner Cube.
  - Set `<Request verb="GET" url="10">`.
  - Set parameter 10 to the value “/x-nmos/events”.
- If the URL first needs to be polled, use a parameter with `<Type options="dynamic ip">read</Type>` and set as value the complete URL: ws://10.4.2.8:4601/x-nmos/events

## Behavior

When the WebSocket server closes the connection for some reason, the element goes into timeout. Sent commands will still appear in the Stream Viewer, but no outgoing communication will be displayed. To have communication again, the element needs to be restarted or you need to use a "dynamic ip" parameter and fill in the value again.

## Timeout

When the WebSocket connection is terminated, the element will enter into timeout according to the timeout time configured in the element editor.

These are possible reasons why the connection might be terminated:

- Normal closure: The WebSocket connection is closed gracefully and as expected by both the client and server.

- Abnormal closure: The WebSocket connection is closed unexpectedly, because of an error or exception. This can be caused by issues such as network connectivity problems, server crashes, or protocol violations.

- Endpoint shutdown: The endpoint (client or server) that initiated the WebSocket connection has shut down, which may be due to a process termination or system reboot.

- Ping timeout: The WebSocket connection has timed out because of a lack of activity. This can occur if the client or server does not receive a ping or pong message within a specified time frame.

- Policy violation: The WebSocket connection is closed by the server because of a violation of security policies, such as a cross-site scripting attack or unauthorized access attempt.

- Network error: The WebSocket connection is closed because of a network error, such as a dropped packet or a network partition. Note that if the TCP retransmission time exceeds the WebSocket timeout time, depending on the implementation, the WebSocket might be closed, since there is no activity for a period greater than the configured WebSocket timeout time.

> [!NOTE]
> The timeout behavior of the element may vary depending on other connections configured on protocol level.

## Binary vs. Text Data Frames

By default, DataMiner sends the WebSocket messages as binary data (i.e. a frame with Opcode 0x2, [RFC 6455](https://datatracker.ietf.org/doc/html/rfc6455#section-11.8)). Some WebSocket servers will reply with an \[ACK\] packet but ignore the message as the server does not support binary formatted messages.

If the message you want to send only contains text and the server does not seem to support binary formatted messages, try to add `<WebSocketMessageType>text</WebSocketMessageType>` to the `<Command>`. This will result in the command being sent as UTF-8 encoded text (Opcode 0x1, [RFC 6455](https://datatracker.ietf.org/doc/html/rfc6455#section-11.8)). 

In case the server supports text frames, it should now respond to this command. Note that the WebSocketMessageType tag is only supported from DataMiner 9.5.1 (RN 14177) onwards.

## Unicode protocols

If the protocol is set to use Unicode and the response for the WebSocket is saved in a parameter of type "string", this behavior can cause issues in case [GetParameter()](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameter(System.Int32)) is used to fetch the WebSocket response from within a QAction. If the Unicode tag is set, string parameters will be saved as UTF-16. The WebSocket, however, will try to store its response as UTF-8. When [GetParameter()](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameter(System.Int32)) is used, the received value will therefore not be encoded correctly, which will cause special characters to not be shown correctly. To solve this, add the following tags to the QAction that parses the data:

```xml
inputParameters="[ID of the websocket response parameter]" options="binary"
```

That way, the response can be encoded manually:

```cs
object[] bytestream = websocketResponse as object[];
byte[] response = new byte[bytestream.Length];
for (int i = 0; i < response.Length; i++)
{
   response[i] = (byte)bytestream[i];
}

string data = System.Text.Encoding.UTF8.GetString(response);
processData(data);
```
