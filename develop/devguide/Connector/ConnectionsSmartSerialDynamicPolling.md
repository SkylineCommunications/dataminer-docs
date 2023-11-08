---
uid: ConnectionsSmartSerialDynamicPolling
---

# Dynamic polling

From DataMiner 10.3.11/10.4.0 onwards<!--RN 37404-->, smart-serial connections support dynamic polling, allowing you to change the IP address and IP port while the element remains active.

> [!IMPORTANT]
>
> - Dynamic polling is only supported when the smart-serial connection acts as a client, not as a server. Assigning IP addresses like "127.0.0.1" or "any" makes the element act as a server, and it cannot switch to client mode without stopping first. Also, trying to assign a value like "127.0.0.1" to the dynamic IP parameter at runtime will cause an error.
> - We highly recommend configuring the connection type as *smart-serial single*. This ensures that each connection is assigned a dedicated socket in SLPort. If multiple smart-serial or serial elements hosted on the same DMA are configured to share the same IP address and port, they will all use the new IP address if one of them changes the IP address dynamically.

It is possible to dynamically change the used polling IP and port.

Create a parameter that has the [dynamic ip](xref:Protocol.Params.Param.Type-options#dynamic-ip) option defined.

```xml
<Param id="400" trending="false" save="true">
   <Name>Dynamic polling IP</Name>
  ...
   <Type options="dynamic ip 1">read</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
  ...
</Param>
```

In the example above, advanced port 1 is overruled by the value specified in this parameter. In case you want to overrule the first connection, you can specify "dynamic ip" or "dynamic ip 0". In case you want to overrule connection 100, specify "dynamic ip 100".

The content of this parameter is: "IP:PORT".

For example, if you specify "10.12.0.63:4000", then all communication will be done on IP 10.12.0.63 port 4000. If you do not specify a port, then the last port set will be used (if no port is set yet, the port configured during element creation will be used).
