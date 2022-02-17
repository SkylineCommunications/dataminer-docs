---
uid: ConnectionsWebSocketsDynamicIp
---

# Dynamically changing the IP address and port number

It is possible to dynamically change the WebSocket IP (and port). To this end, define a parameter that uses the Type option "dynamic ip".

```xml
<Param id="1" trending="false" save="true">
   <Name>URL</Name>
   <Description>URL</Description>
   <Type options="dynamic ip">read</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
</Param>
```

On startup of the element, DataMiner will try to connect to the WebSocket, if the parameter is filled in, it will use its value as URL. On every change of the parameter, the previous connection will be gracefully closed and the new one will be set up.
