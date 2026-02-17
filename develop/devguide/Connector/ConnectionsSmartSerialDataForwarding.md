---
uid: ConnectionsSmartSerialDataForwarding
---

# Data forwarding

The SLPort process creates a socket to communicate with the data source. Incoming data via this socket is forwarded from SLPort to the SLProtocol process. The SLProtocol process will then try to match the incoming data with a response defined in the protocol.

There are multiple configuration options for a smart-serial connection that influence how/when SLPort forwards incoming data to the SLProtocol process:

1. Using [stuffing](xref:Protocol.Advanced-stuffing)
1. Using the [packetInfo](xref:Protocol.Type-communicationOptions#packetinfo) option
1. Using a header/trailer without the [headerTrailerLink](xref:Protocol.Params.Param.Type-options#headertrailerlink) option. Note that this is not recommended.
1. Using headers/trailers with the headerTrailerLink option
1. Using none of the above options

SLPort only considers the first applicable option when processing incoming data, in the order mentioned above. For example, if stuffing is configured, then SLPort will just perform unstuffing and then forward the data to SLProtocol. If no stuffing is configured, but the packetInfo option is used, SLPort will only consider this information.

> [!NOTE]
> Only in case none of the options above is used, prior to forwarding the data to SLProtocol, SLport will check if the smartIpHeader was used. In case it is used, it will prefix the data with the smart IP header information. This means that the smartIpHeader option cannot be used together with the packetInfo option, with stuffing or with headers and trailers.

## Length Identifier

Some communication protocols do not make use of headers/trailers to demarcate the start and end of a message. Instead, the size of the packet is indicated in the message.

To leverage this information, it is possible to use the packetInfo option. Using this option, the length identifier is read out from the response.

```xml
<Type communicationOptions="packetInfo:4,4">smart-serial</Type>
```

When multiple packets are received in the SLPort process, these are now transferred to the SLProtocol process one by one.

## Headers and trailers

When SLProtocol wants to connect to a smart-serial port in SLPort, it will first gather some information (among other things) about header and trailer parameters found in the protocol for that smart-serial connection. It does this by iterating over all protocol parameters and verifying whether these are of type "header" or "trailer". While iterating over the protocol parameters, it verifies the following:

- Whether the connection option was used (see [connection=[x]](xref:Protocol.Params.Param.Type-options#connectionx)). If the connection option is used, and it refers to another connection than this smart-serial connection, this header or trailer parameter is disregarded. If the connection option is not used, this header/trailer is assumed to relate to all connections, and it will therefore be taken into account for this smart-serial connection.

    > [!NOTE]
    >
    > - If you use a smart-serial connection in combination with other connections that make use of headers/trailers (e.g., serial), make sure to always use the connection attribute to denote to which connection this header/trailer belongs.
    > - For a smart-serial connection, SLPort only knows about the relevant headers and trailers (and which header and trailer belong together) but it has no information about which/if any command/response it is used in. Therefore, for a smart-serial connection, a header/trailer that is not used in any command or response in a protocol can still influence the behavior in SLPort. Therefore, do not define header or trailer parameters that are not used in the protocol.

    ```xml
    <Param id="10" trending="false">
      <Name>.</Name>
      <Description>.</Description>
      <Type options="headerTrailerLink=1;connection=1">trailer</Type>
      <Interprete>
         <RawType>other</RawType>
         <LengthType>fixed</LengthType>
         <Length>1</Length>
         <Type>string</Type>
         <Value>.</Value>
      </Interprete>
      <Measurement>
         <Type>string</Type>
      </Measurement>
    </Param>
    ```

- Whether the [headerTrailerLink](xref:Protocol.Params.Param.Type-options#headertrailerlink) option was used.<!-- RN 6115 --> If this is not the case, then SLPort will only use this header/trailer in SLPort. This means that if you want to use multiple headers/trailers in a smart-serial connection, you must use the headerTrailerLink option on each header/trailer parameter for the smart-serial connection.

    > [!NOTE]
    >
    > - We strongly recommend that you always use the headerTrailerLink option when using headers/trailers with smart-serial communication (even when only one header/trailer is used for the smart-serial connection).
    > - It is possible to specify only a trailer, but specifying a header only is not supported.

The headerTrailerLink option allows you to use multiple headers/trailers. This option links a trailer with the corresponding header (if present). This allows the SLPort process to know which header and trailer belong together.

```xml
<Param id="10" trending="false">
  <Name>.</Name>
  <Description>.</Description>
  <Type options="headerTrailerLink=1">trailer</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>fixed</LengthType>
     <Length>1</Length>
     <Type>string</Type>
     <Value>.</Value>
  </Interprete>
  <Measurement>
     <Type>string</Type>
  </Measurement>
</Param>
 
<Param id="11" trending="false">
  <Name>?</Name>
  <Description>?</Description>
  <Type options="headerTrailerLink=1">header</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>fixed</LengthType>
     <Length>1</Length>
     <Type>string</Type>
     <Value>?</Value>
  </Interprete>
  <Measurement>
     <Type>string</Type>
  </Measurement>
</Param>
 
<Param id="13" trending="false">
  <Name>-</Name>
  <Description>-</Description>
  <Type options="headerTrailerLink=2">header</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>fixed</LengthType>
     <Length>1</Length>
     <Type>string</Type>
     <Value>-</Value>
  </Interprete>
  <Measurement>
     <Type>string</Type>
  </Measurement>
</Param>
 
<Param id="12" trending="false">
  <Name>+</Name>
  <Description>+</Description>
  <Type options="headerTrailerLink=2">trailer</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>fixed</LengthType>
     <Length>1</Length>
     <Type>string</Type>
     <Value>+</Value>
  </Interprete>
  <Measurement>
     <Type>string</Type>
  </Measurement>
</Param>
```
