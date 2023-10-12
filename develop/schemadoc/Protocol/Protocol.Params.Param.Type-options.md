---
uid: Protocol.Params.Param.Type-options
---

# options attribute

Specifies a number of options separated by semicolons (”;”).

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.Type)

## Remarks

In the options attribute, you can specify a combination of the following options, separated by semicolons (”;”).

### columnTypes

Column type definitions. Only for parameters of type array or write and measurement type matrix.

Each column type has the following format: Parameterid:column indexes

- First part: ID of the parameter containing the column type
- Second part: columns identified by their 0-based column index

If you specify multiple column types, separate them by means of pipe characters (“|”).

If you specify multiple column indexes, separate them by commas.

You can also specify ranges of column indexes. In the example below, columns 0 to 20 and 35 have a column
type as defined in parameter 2, and columns 21 to 34 and 36 have a column type as defined in parameter 3:

```xml
options="columnTypes=2:0-20,35|3:21-34,36"
```

### connection=[x]

If there are several connections, then you can use this option to specify the connection to use.

Expected value: a number within the range [0, 32 767] or -1.

Default: value: -1 (meaning it applies to all relevant connections)

Example:

```xml
<Param id="1">
    <Name>STX</Name>
    <Type options="connection=0">header</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>fixed</LengthType>
        <Length>3</Length>
        <Type>string</Type>
        <Value>0x000x000x00</Value>
    </Interprete>
</Param>
```

### dimensions=[rows,columns]

The dimensions of the parameter. Only for parameters of type array or write.

In the following example, the parameter has 128 rows and 1 column:

```xml
options="dimensions=128,1"
```

### dynamic ip

In a protocol, you can dynamically assign an IP address and an IP port to an advanced port of a serial device.

In the example below, the IP address/port combination specified in parameter 400 is assigned to advanced port 1. To overrule the default connection, specify “dynamic ip” or “dynamic ip 0”. To overrule a specific connection, you can for example specify “dynamic ip 2”.

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

Parameter syntax: IP:PORT

If, in the parameter, you specify the value “10.12.0.63:4000”, all communication will go via port 4000 of address 10.12.0.63.

If you do not specify a port, then the last port set will be used. If no port has been set yet, the port configured in the Element wizard will be used.

Only applicable for parameters of type read.

### dynamic snmp get

With this option, an SNMP Get can be triggered dynamically when a parameter value changes.

Concept: A certain parameter contains an OID. When it changes, DataMiner looks for the closest match to determine the parameter to get. If a match is found, a get is executed on that parameter. If the parameter is an instance of a table, then the entire table is retrieved.

Protocol logic: When the value of the parameter has changed, a dynamic group containing a Get is added to the queue behind all other QActions and triggers associated with that same parameter.

Example:

In an SNMP protocol, you define the following two parameters:

- Parameter 1, identified with OID 1.3.6.2
- Parameter 2, defined as “dynamic snmp get”

When the value of parameter 2 changes to “1.3.6.2”, a group like the following one is created in memory:

```xml
<Group id="1">
    <Type>poll</Type>
    <Content>
        <Param>1</Param>
    </Content>
</Group>
```

When, later on, the value of parameter 2 changes to “1.3.6.”, that same group is triggered again.

In the communication stream, you will notice the following entry:

```
Dynamic group for parameter 1 [triggered by 1.3.6.]
```

*Feature introduced in DataMiner 7.5.2.0 (RN 4734).*

> [!NOTE]
> - Only applicable for parameters of type read.
> - This option is rendered obsolete by the dedicated dynamicSnmpGet attribute.

### headerTrailerLink

This option is only applicable for smart-serial connections. It defines a link between a header and a trailer
parameter (See [Data forwarding from SLPort to SLProtocol](xref:ConnectionsSmartSerialDataForwarding).

With this option, it is also possible to only specify a trailer (i.e. where no corresponding header has the same value specified for the headerTrailerLink option).

The value specified must be an unsigned integer number.

Example:

```xml
<Type options="headerTrailerLink=1">header</Type>
<Type options="headerTrailerLink=1">trailer</Type>
```

*Feature introduced in DataMiner 8.0.3 (RN 6115).*

### linkAlarmValue=TRUE

With this option you can link externally generated alarms based on the alarm value. When there is an exact value match the alarms are linked, whether or not a root key has been specified.

Example:

```xml
options="LinkAlarmValue=TRUE"
```

### linkAlarmValue=[xx]

With this option you can link alarms based on the value between the two specified characters.

Examples:

If you want alarms to be linked if the values between two brackets match:

```xml
options="LinkAlarmValue=()"
```

If you want alarms to be linked if the values between two dots match:

```xml
options="LinkAlarmValue=.."
```

### loadOID

Used with multi-threaded timers to perform SNMP polling.

For more information, refer to [Multi-threaded timers SNMP](xref:AdvancedMultiThreadedTimersSnmp).

### ssh pwd

This option specifies that this parameter holds the password used for setting up SSH communication based on user credentials. When using this option, there should also be another parameter that uses the "ssh username" option. The SSH connection is established by DataMiner itself, if the parameters are filled in correctly.

Only applicable for parameters of type read.

### ssh username

This option specifies that this parameter holds the username used for setting up SSH communication based on user credentials. When using this option, there should also be another parameter that uses the "ssh pwd" option. The SSH connection is established by DataMiner itself, if the parameters are filled in correctly.

Only applicable for parameters of type read.

### ssh options

This option specifies that this parameter holds the required data for setting up SSH communication based on an identity file. This is an alternative way to set up an SSH connection (instead of user credentials). The content of the "ssh options" parameter is as follows:

```none
Key=path to the identity file;pass=passphrase
```

Only applicable for parameters of type read.
