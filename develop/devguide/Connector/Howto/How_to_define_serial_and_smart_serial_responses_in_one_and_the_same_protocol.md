---
uid: How_to_define_serial_and_smart_serial_responses_in_one_and_the_same_protocol
---

# How to define serial and smart-serial responses in one and the same protocol

Below, you can learn how to deal with incoming data when a protocol has serial as well as smart-serial connections.

## User skills required

- Basic knowledge of protocols (serial and smart serial)
- Basic knowledge of the inner flow of protocols

## About serial and smart-serial connections

In case of a serial connection, a DataMiner Agent will send commands to the serial data source, which will then reply with a response to each of those commands. A smart-serial data source will behave in the same way as a serial data source. When it receives a command from a DataMiner Agent, it will reply with a response. However, a smart-serial data source is also able to send unsolicited messages.

For more information, see [Connections](xref:Connections).

## Defining serial and smart-serial responses in one protocol

In a protocol that has serial as well as smart-serial connections, we must define different responses for these two types of connections. When a DataMiner Agent receives data from a data source, it will try to match that data to the responses defined in the protocol. To allow DataMiner to determine via which connection the data was received, we must specify the connection in the options attribute in the protocol response. If the connection is not explicitly specified in the response, DataMiner will assume the data was received via the main connection (i.e. the connection with ID 0).

## Use case

If a protocol has a main connection of type "serial" and a secondary connection of type "smart serial", in most cases, the responses will be defined as follows.

### Serial response

By default, the serial connection will be defined as the main connection (ID 0). When the DataMiner Agent receives data via the main connection, it will try to match it to this response (in which the connection is not explicitly specified).

Example:

```xml
<Response id="100">
   <Name>versionNegotiation</Name>
   <Description>Version Negotiation</Description>
   <Content>
      <Param>200</Param>
      <Param>50</Param>
   </Content>
</Response>
```

### Smart serial response

When the DataMiner Agent receives data via the secondary connection, it will try to match it to this response (in which the connection is explicitly specified).

Example:

```xml
<Response id="101" options="Connection:1">
   <Name>mediaPlayerStatusSubscription</Name>
   <Description>Media Player Status Subscription</Description>
   <Content>
      <Param>201</Param>
      <Param>51</Param>
   </Content>
</Response>
```

> [!NOTE]
>
> - In some cases, data received via a smart-serial connection is not delimited by a specific header and trailer. The data source can send all data as one package, without specific delimiters. In that case, we must define a response with a parameter of type "next param" to capture all data (and process it later on in e.g. a QAction).
> - If a serial response does not have a connection ID specified, different issues can occur. When a DataMiner Agent receives smart-serial data, in some cases, it could find a match in the serial response (in case there is a serial response with header/trailer information in the smart serial data). Also, data received via the serial connection could be captured by a smart-serial response since a response with only one "next param" parameter can match any kind of incoming data. When that happens, users checking the stream viewer or the element log will notice that, although data is being received from the data source, the parameters are not updated.

## How to

To prevent any issue with protocols that have serial as well as smart-serial connections, you should always explicitly specify the connection ID in each of the responses (including those of the main connection). See the following example.

```xml
<Responses>
   <Response id="100" options="Connection:0">
      <Name>versionNegotiation</Name>
      <Description>Version Negotiation</Description>
      <Content>
         <Param>200</Param>
         <Param>50</Param>
      </Content>
   </Response>
   <Response id="105" options="Connection:0">
      <Name>askConfigSubscription</Name>
      <Description>Ask Config Subscription</Description>
      <Content>
         <Param>205</Param>
        <Param>53</Param>
      </Content>
   </Response>
   <Response id="106" options="Connection:1">
      <Name>asynchronousFeedback</Name>
      <Description>Asynchronous Feedback</Description>
      <Content>
         <Param>206</Param>
      </Content>
   </Response>
</Responses>
```
