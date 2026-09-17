---
metadata_version: 1
uid: ConnectionsWebSocketsDynamicIp
description: "Describe the DataMiner connector development topic Dynamically changing the IP address and port number, including its purpose, behavior, implementation gu."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
