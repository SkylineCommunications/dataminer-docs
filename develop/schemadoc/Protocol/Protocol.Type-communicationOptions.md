---
uid: Protocol.Type-communicationOptions
---

# communicationOptions attribute

Specifies a number of communication options.

## Content Type

string

## Parent

[Type](xref:Protocol.Type)

## Remarks

The following options are available:

### asyncWMI

Use this option if you want WMI queries to be performed asynchronously.

In the Microsoft Platform protocol, for instance, this option can prevent hanging calls.

### chunkedHTML

Obsolete. This option is not needed if connection type "HTTP" is used.

Specify this option if the device uses chunked transfer encoding. Only applicable for connections of type "serial" or "serial single".

### closeConnectionOnResponse

Obsolete. This option is not needed if connection type "HTTP" is used.

This option is useful for HTTP 1.0 communication that is implemented using a serial connection. As the HTTP 1.0 specification makes use of short-lived connections, this option makes it possible to automatically close the connection after each response, alleviating the need to implement a "close" action in the protocol.

This option is only applicable for connections of type "serial" or "serial single".

> [!NOTE]
> Implementing HTTP communication should no longer be done using serial connections. Instead, use the dedicated HTTP connection type to implement HTTP communication.

### customRedirect

Indicates that custom redirection is applied in the protocol. Only applicable for connections of type "HTTP".

By default, DataMiner will perform redirection automatically. In case this is not desired, this can be disabled by specifying this communication option.

> [!CAUTION]
> The HTTP 1.1 specification states the following ([RFC 7231](https://tools.ietf.org/html/rfc7231#section-6.4)):
>
> *A client SHOULD detect and intervene in cyclical redirections (i.e., "infinite" redirection loops).*
>
> Keep this in mind when implementing custom redirection logic in a protocol.

See also: [Response](xref:ConnectionsHttpImplementing#response)

### makeCommandByProtocol

This option is needed when the same group, with variable parameters in the command, can occur multiple times in the queue (multiple set via Cube, Automation or groups triggered via loop in QActions).

If you specify this option:

- There will not be any automatic "make" actions.
- The "before command" triggers will be executed before the command is added to the queue.
- A "before command" will be executed prior to a "before group"

This option is only applicable for connections of type "serial (single)" or "smart-serial (single)".

> [!NOTE]
> As the make action is not executed automatically on execution of the group, the action needs to be executed when adding the group to the queue. This will copy the "current" value of the parameter(s) used in the command and these copied values will be used when the group is being executed.

### maxConcurrentConnections

<!-- RN 6342 -->

Use this option to define a limit of clients that can connect when the DataMiner acts as a server.

This option is only applicable for connections of type "smart-serial (single)" acting as a server that use TCP as the underlying communication protocol.

Example:

```xml
<Type communicationOptions= "maxConcurrentConnections:3">smart-serial</Type>
```

> [!TIP]
> See also: [Configuring a smart-serial connection as a server](xref:ConnectionsSmartSerialServer)

### maxReceiveBuffer:X

For connections of type "smart-serial", data is passed from the SLPort process to the SLProtocol process every 15 ms.<!-- RN 24282 -->

If the *maxReceiveBuffer* option is used, each time the specified number of bytes is received, these are transferred from the SLPort process to the SLProtocol process. This option is only applicable for connections of type "smart-serial".

```xml
<Type relativeTimers="true" advanced="" communicationOptions="maxReceiveBuffer:8120">smart-serial</Type>
```

### notifyConnectionPIDs:x,y

Specify this option if you want a protocol of type "smart-serial" acting as server to detect (and log) when a client connects or disconnects on a local smart IP port.

Example:

```xml
<Type communicationOptions="notifyConnectionPIDs:x,y">smart-serial</Type>
```

- x = ID of the parameter in which the connects have to be logged
- y = ID of the parameter in which the disconnects have to be logged

Both parameters have to be of type String.

Entry format: IP:IP port (example: 10.12.200.242:65871)

See also [Configuring a smart-serial connection as a server](xref:ConnectionsSmartSerialServer)

### packetInfo

<!-- RN 5659 -->

Use this option to define the packet length identifier of the response in a smart-serial protocol. Applies to all the smart-serial connections defined in the protocol.

Syntax: packetinfo:a,b,c,d

- a: Number of bytes before the length identifier.
- b: Length of the length identifier. Supported values are: 1, 2, 4.
  Number of bytes the length field. E.g. a value of 2 indicates that the length field is 2 bytes.
- c: [optional] "true" (default): The value denoted by the length field comprises the preamble field, length field and data field. "false": The length field only specifies the number of bytes that follow the preamble field and length field.
- d: [optional] "littleEndian": If the bytes enter in littleEndian format. Default: Big endian.

In the following example, the length identifier starts at position 4, it is 2 bytes long and the first 6 bytes are not included in the length indicated by the length identifier:

```xml
<Type communicationOptions="packetInfo:4,2">smart-serial</Type>
```

> [!TIP]
> See also:
>
> - [Smart serial](xref:ConnectionsSmartSerial)
> - [Data forwarding from SLPort to SLProtocol](xref:ConnectionsSmartSerialDataForwarding)

### postPonePortInitialisation

At DMA restart, the initialization of the ports is postponed until all elements are started. The restart of an element will then start with the port initialization (first action of the protocolThread).

Example:

```xml
<Type relativeTimers="true" communicationOptions="postPonePortInitialisation">virtual</Type>
```

### progid=class

The specified class will be created (only in case of OPC).

Example:

```xml
<Type communicationOptions="progid=National Instruments.OPCFieldPoint">opc</Type>
```

### redundantPolling

If you specify this option in a two-port serial, SNMP, or HTTP protocol, the element will automatically switch to the second port when it goes in timeout.

Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 (RN 39114), the second connection must be of the same type as the main connection. However, starting from these versions, DataMiner will automatically choose the second connection with the same type as the main connection in the event of a timeout.

### smartIpHeader

On TCP, every packet will have the following extra header bytes:

- 0-1: IP port (big Endian)
- 2-5: IP address (big Endian)
- 6-13: sequence number (little Endian)

On UDP, every packet will have the following extra header bytes:

- 0-3: IP address (big Endian)
- 4-5: IP port (big Endian)

> [!NOTE]
>
> - This option is only applicable for connections of type smart-serial.
> - *smartIpHeader* cannot be used together with the *packetInfo* communication option or with headers and trailers.

> [!TIP]
> See also: [Configuring a smart-serial connection as a server](xref:ConnectionsSmartSerialServer)

### useAgentBinding

SNMP traps will be assigned to elements based on the trap’s agentaddress binding (1.3.6.1.3.1057.1).

> [!IMPORTANT]
> To activate this feature on system level, set the [useAgentBinding](xref:DataMiner-useAgentBinding) to `true` in *DataMiner.xml*.

## Examples

```xml
<Type relativeTimers="true" advanced="" communicationOptions="maxReceiveBuffer:8120">smart-serial</Type>
```
