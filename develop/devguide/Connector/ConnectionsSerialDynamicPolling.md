---
uid: ConnectionsSerialDynamicPolling
---

# Dynamic polling

It is possible to dynamically change the used polling IP and port.

Create a parameter that has the “dynamic ip” option defined.

```xml
<Param id="400" trending="false" save="true">
   <Name>DynamicPollingIP</Name>
  ...
   <Type options="dynamic ip 1">read</Type>
   <Interprete>
      <RawType>other</RawType>
      <Type>string</Type>
      <LengthType>next param</LengthType>
   </Interprete>
  ...
</Param>
```

In the example above, advanced port 1 is overruled by the value specified in this parameter. In case you want to overrule the first connection, you can specify "dynamic ip" or "dynamic ip 0". In case you want to overrule connection 100, specify "dynamic ip 100".

The content of this parameter is: "IP:PORT".

For example, if you specify "10.12.0.63:4000", then all communication will be done on IP 10.12.0.63 port 4000. If you do not specify a port, then the last port set will be used (if no port is set yet, the port configured in the element wizard will be used).
