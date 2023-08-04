---
uid: Protocol.Params.Param.Type
---

# Type element

Specifies the parameter type.

## Type

[EnumParamType](xref:Protocol-EnumParamType)

## Parent

[Param](xref:Protocol.Params.Param)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[alarmRegistration](xref:Protocol.Params.Param.Type-alarmRegistration)|string||Allows to trigger a QAction when specific parameters go into alarm.|
|[distribution](xref:Protocol.Params.Param.Type-distribution)|string||Used in situations in which elements of a certain type are linked to each other as parent and child.|
|[dynamicSnmpGet](xref:Protocol.Params.Param.Type-dynamicSnmpGet)|string||Specifies what to retrieve (cell, row, etc.) and the way this request is added to the group execution queue.|
|[id](xref:Protocol.Params.Param.Type-id)|string||If Type is “read bit” or “response”, this attribute specifies the ID of the parameter or response to which to refer, respectively.|
|[options](xref:Protocol.Params.Param.Type-options)|string||Specifies a number of options.|
|[relativeTimers](xref:Protocol.Params.Param.Type-relativeTimers)|[EnumProtocolTypeRelativeTimers](xref:Protocol-EnumProtocolTypeRelativeTimers)|||
|[times](xref:Protocol.Params.Param.Type-times)|unsignedInt||If Type is “trailer”, this attribute indicates how many times the trailer is allowed to occur before it is considered to be the trailer.|
|[virtual](xref:Protocol.Params.Param.Type-virtual)|string||Configures which virtual element connections are allowed to and from elements based on the protocol you are creating.|

## Remarks

Contains one of the following predefined values, detailed in the sections below:

### array

A parameter of type ARRAY identifies a (dynamic) table parameter. These are used to retrieve SNMP or WMI tables. The different columns have to be specified in the id attribute.

Example:

```xml
<Type id="110;111;115;116">array</Type>
```

See also:

- [Table](xref:UIComponentsTable)

### bus

When a bus address is used in the course of a communication, a BUS parameter has to be defined. It will not be assigned a fixed value as the address can vary from device to device. When the type of a parameter is set to “BUS”, it receives the value entered while adding or editing the element.

### crc

CRC parameters are used when a device supports error detection by means of a Cyclic Redundancy Check (CRC).

A CRC parameter is defined by two essential elements:

- Type of the CRC: e.g. EXOR, module 256 checksum, etc.
- Number of parameters on which the CRC has to be calculated

### dataminer info

A parameter of type DATAMINER INFO will contain the following data separated by semicolons (”;”):

- DMA ID
- DMA name
- Primary IP address
- Secondary IP address

Parameters of type ELEMENTID, ELEMENTNAME, ELEMENTDMAID and DATAMINER INFO are the first parameters that are loaded by a protocol. Although they hold information, they cannot, as such, be displayed in the user interface. Therefore, for these types of parameters, always set the Protocol.Params.Param.Display.RTDisplay tag to FALSE.

If you do want to display the information in one of these parameters in the user interface, there is a workaround: create another parameter of type READ, and copy the value from its invisible parameter to this new parameter after protocol startup. You can then display the READ parameter in the user interface.

### discreet info

A parameter of type DISCREET INFO will receive the changed data (locking, labeling, pages, follow mode, etc.) each time a change was made on the matrix.

Format: "a;b;c;d;" or "b;a;c;d"

- a = Parameter ID of the matrix
- b = type of change
- c = discreet ID (input/output)
- d = new values for the specified type

The type of change (b) will contain one of the following integer values:

- 0 : label
- 1 : state
- 2 : current settings (only via Element Display)
- 3 : page info
- 4 : not allowed
- 5 : allowed
- 6 : lock info
- 7 : follow info
- 8 : master info
- 9 : logical size (for a matrix this can be 256x256, but a DMA can only handle 128x128)

This parameter type is typically used to store Element Display information, and synchronize it with the device. Use a QAction to trigger each change on that parameter. Keep in mind that the contents of the parameter can be formatted in two ways.

See also:

- [Discreet info](xref:UIComponentsMatrixDiscreetInfo)

### dummy

Dummy parameters can be used to catch non-significant symbols during the course of a communication session.

### elementdmaid

A parameter of type ELEMENTDMAID will contain the DMA ID, followed by the element ID (separated by a slash (“/”).

The following can result in “111/128” (DMA ID 111, element ID 128):

```xml
<Type>elementdmaid</Type>
```

### elementid

A parameter of type ELEMENTID will contain the ID of the DMS element.

### elementname

A parameter of type ELEMENTNAME will contain the name of the DMS element.

### fixed

FIXED parameters can be used to define values that will never change during the course of a communication session.

This type of parameter has a fixed length as well as a fixed value.

See also:

- [Title](xref:UIComponentsTitle)
- [Group box](xref:UIComponentsGroupBox)

### group

Parameter length can be defined in terms of bytes (e.g. READ and WRITE parameters), but also in terms of bits. To do so, you have to define a GROUP to which you have to assign READ and WRITE BITS.

A GROUP parameter contains one or more bytes from which one or more bits will be taken.

### header/trailer

Header and trailer parameters can be defined to allow DataMiner to easily detect beginning and end of a frame. If, for example, the first byte of every frame is the hexadecimal symbol 0x02, you can create a header parameter and define it as “0x02”.

### ip

A parameter of type IP will contain the IP address and IP port, separated by ”:”.

Multiple address/port combination will be separated by semicolons (”;”).

`<Type>IP</Type>` can result in “10.12.230.326:80” or “localhost:80”

### length

Length parameters are used to hold the length of a frame used in a communication session. While often calculated based on the total frame, this length is sometimes also calculated based on a part of the frame.

To hold the correct length, the number of parameters on which the length will be calculated must be defined in the LENGTH parameter.

### matrix

With this parameter, matrix mappings are configured for each table. This is done in the *Param.Matrix* element.

See also:

- [Table-based matrix](xref:UIComponentsTableMatrix)
- [Matrix element](xref:Protocol.Params.Param.Matrix)

### pollingip

A parameter of type POLLINGIP will contain the IP address that is being polled by the DMA (without having to specify a read action).

Multiple IP addresses will be separated by semicolons (”;”).

`<Type>POLLINGIP</Type>` can result in “10.12.230.326” or “localhost”.

To see both the IP address and port, use the type "ip"

### read

Read parameters retrieve information from the element. They allow you to display measured values on the screen.

### read bit

Read bit parameters retrieve data from the group.

### response

A parameter that contains multiple bytes can be split up into smaller pieces when it refers to another response. A response parameter will automatically fill its coupled response whenever the parameter receives a new value.

### write

Write parameters change the status of the element. They allow you to alter parameter values.

### write bit

Write bit parameters change data in the group.
