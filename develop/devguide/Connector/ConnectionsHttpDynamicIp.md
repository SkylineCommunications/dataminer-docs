---
uid: ConnectionsHttpDynamicIp
---

# Dynamically changing the IP address and port number

It is possible to dynamically change the used polling IP and port of an HTTP connection.<!-- RN 13369 -->

Create a parameter that has the "dynamic ip" option defined.

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

For example, if you specify "10.12.0.63:4000", then all communication will be done on IP 10.12.0.63 port 4000. If you do not specify a port, the port configured in the element editor will be used.

> [!NOTE]
>
> - To dynamically poll using the HTTPS protocol, make sure the IP is prefixed with "https://". For example, specifying `https://10.12.0.63` will poll using HTTPS, while `10.12.0.63` will poll using HTTP. This happens regardless of the IP and the port configured in the element editor.
> - "bypassProxy" will be taken from the connection settings from the element wizard.
