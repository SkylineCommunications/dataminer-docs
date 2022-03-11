---
uid: ConnectionsWebSocketsConnectionStatus
---

# Connection Status

The connection status can be retrieved by specifying a parameter in the NotifyConnectionPID.Connections tag. This parameter can be implemented as follows:

```xml
<Param id="7" trending="false">
   <Name>WebSocket Status</Name>
   <Description>WebSocket Status</Description>
   <Type>read</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
   </Interprete>
   <Display>
      <RTDisplay>true</RTDisplay>
      <Positions>
         <Position>
            <Page>Echo</Page>
            <Row>1</Row>
            <Column>0</Column>
         </Position>
      </Positions>
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

This parameter will contain 0 when the WebSocket is closed and 1 when the WebSocket is open.
