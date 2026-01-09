---
uid: ConnectionsSerialCreatingCommandsAndResponses
description: A serial communication protocol specification implemented by a device typically defines a number of commands and responses.
---

# Creating commands and responses

A serial communication protocol specification implemented by a device typically defines a number of commands and responses. A DataMiner protocol will implement these commands and responses according to the specification.

The first step is to implement all the needed parameters that will be used in the command and response definitions. Some of the parameters will have a fixed length (i.e. LengthType is set to "fixed"), while others will hold data of variable length (LengthType is set to "next param"). In case a command has a variable length field, this is typically surrounded by fixed length parameters.

For example, consider the following implementation of a GET request as defined in the Hypertext Transfer Protocol (HTTP).

![Example command](~/develop/images/Example_command.jpg)

> [!NOTE]
>
> - For HTTP communication DataMiner supports HTTP connections. The use of this connection is recommended for HTTP communication. The HTTP protocol is used just as an example as HTTP is a widely known protocol.
> - Command and response parameters are typically not displayed or monitored.
> - An example protocol "SLC SDF Serial - Creating commands and responses" is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).

## Header and trailer

A parameter of type "header" or "trailer" is used to notify DataMiner of the beginning (and end) of a frame. The Interprete.Value will then contain the fixed length string with a given fixed value (this value cannot be changed). For example, the string "GET" can be used as a header of length 3.

## Fixed fields

A fixed field is defined using a parameter of type "fixed". The content of fixed fields can be defined using hexadecimal notation. For example, for (2) in the example command, the fixed field representing the space character could be defined as follows:

```xml
<Param id="100">
   <Name>Fixed_Space</Name>
   <Description>Fixed Space</Description>
   <Type>fixed</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>fixed</LengthType>
      <Length>1</Length>
      <Type>string</Type>
      <Value>0x20</Value>
   </Interprete>
</Param>
```

For (4), (5), (7) and (8) in the example command, the hex value 0x0D0x0A is a fixed string with Length 2 and value 0x0D0x0A.

> [!NOTE]
>
> - The value must either be provided as a hex string or as plain text.
> - Typically, the content of this parameter is fixed. However, it is possible to change the content of this parameter. In case the length of the value also changes, an action of type "change length" is required before setting the new value.

## Read or write parameters

Read or write parameters in a command or a response are typically parameters that are read from or written to a device or that are specific to a device, like an IP address, a host name, a parameter value, etc.

A read or write parameter can be filled in via the UI, can be set by a QAction or can enter by a response of the device. E.g. (3) and (6) in the example command.

## Composing commands

Once all parameters are defined, the actual commands and/or responses can be created. This is done by defining commands and/or responses that define which parameters make up the command/response and in which order.

The following example defines a command implementing an HTTP GET request:

```xml
<Command id="2">
   <Name>HTTP_getSysConfig</Name>
   <Description>HTTP - Get System Config</Description>
   <Content>
      <Param>10000</Param><!-- GET-->
      <Param>10001</Param><!-- 0x20 -->
      <Param>10211</Param><!-- header_text -->
      <Param>10002</Param><!-- 0X0D0X0A -->
      <Param>10002</Param><!-- 0x0D0A-->
      <Param>10212</Param><!-- content_text -->
      <Param>10002</Param><!-- 0X0D0A-->
      <Param>10002</Param><!-- 0X0D0A-->
   </Content>
</Command>
```

### makeCommandByProtocol

By default, the following behavior is applicable in serial connectors:

- For "execute group" actions (i.e., actions of type "execute" on group(s)), a "make" action is automatically performed for the command in the pair(s) referred to by the group(s).
- "before command" triggers are executed just before the command is sent to SLPort.

For example, consider the following logic being implemented in a protocol. In this case, the command is composed of 2 parameters: one fixed ("Get") and one with dynamic content.

![Executing a command via a timer](~/develop/images/Connection_Types_-_makeCommandByProtocol_Building_Blocks.png)

When the timer goes off, group 1 will be added to the group execution queue. Now suppose parameter 2 holds value "A" at this time.

![Insertion of a timer group in the group execution queue](~/develop/images/Protocol_Explained_-_Insertion_of_a_timer_group.svg)

The group travels through the queue until it reaches the front and is processed. At this point, the command that will be sent to the SLPort process is composed based on the current values of the parameters that make up the command. At this point in time, it is possible that the value of parameter 2 has changed already (e.g. the content of parameter 2 is now 'B'). In this case, the command "Get B" will be sent to SLPort instead of "Get A". This could be undesired.

![Default command construction](~/develop/images/Protocol_Explained_-_Default_command_construction.svg)

When the [makeCommandByProtocol](xref:Protocol.Type-communicationOptions#makecommandbyprotocol) communication option is used, commands will be composed the moment the corresponding group is added to the group execution queue. In the example, this means the command that will be sent is "Get A".

If this option is enabled, the following behavior is applicable:

- No automatic "make" commands are executed.
- "before command" triggers are executed before the group is added to the queue. This means a "before command" trigger is now executed prior to a "before group" trigger, while this was previously the other way around.

![Command construction when using makeCommandByProtocol](~/develop/images/Protocol_Explained_-_Default_command_construction_with_makeCommandByProtocol.svg)

As in this case no automatic "make" action is performed, the protocol should define a "make command" action which triggers before each command.

```xml
<Trigger id="11">
   <Name>Before Command Each</Name>
   <On id="each">command</On>
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <Id>10</Id>
   </Content>
</Trigger>

<Action id="10">
   <Name>Make Command</Name>
   <On>command</On>
   <Type>make</Type>
</Action>
```

#### See also

DataMiner Protocol Markup Language:

- [Protocol.Triggers](xref:Protocol.Triggers)
- [Protocol.Actions](xref:Protocol.Actions)

## Composing responses

Defining a response is very similar to defining a command: specify which parameters make up the response and in which order.

```xml
<Response id="2">
   <Name>setSysConfig</Name>
   <Description>Set System Configuration</Description>
   <Content>
      <Param>10030</Param>
      <Param>10002</Param>
      <Param>10031</Param>
      <Param>10002</Param>
      <Param>10032</Param>
      <Param>10041</Param>
   </Content>
</Response>
```

### Responses with variable length parameters

In case a response contains parameters that have LengthType set to "next param", an additional action is needed to fill in its data. This is done using a "before response" trigger and a "read response" action.

```xml
<Trigger id="12">
   <Name>Before Response Each</Name>
   <On id="each">response</On>
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <Id>12</Id>
   </Content>
</Trigger>

<Action id="12">
   <Name>Read Response</Name>
   <On>response</On>
   <Type>read</Type>
</Action>
```

### Response matching

A response will wait until the timeout time (defined in the element wizard) has passed before taking in the data, unless one of the following applies:

- A header and trailer are defined.
- Every parameter has a fixed length defined.
- The response contains a length indication at an identifiable position, i.e. the length parameter is located after e.g. a parameter of type fixed and consists of a fixed set of bytes.

#### Practical example

The following example is also applicable for SSH connections.
Imagine we have defined the following response:

```xml
<Response id="300">
  <Name>VariableLengthResponse</Name>
  <Description>Variable Length response with 2 variable length parameters</Description>
  <Content>
     <Param>301</Param><!-- Response Next Param 1 -->
     <Param>302</Param><!-- Response Fixed Colon (:) -->
     <Param>303</Param><!-- Response Fixed Question Mark (?) -->
     <Param>304</Param><!-- Response Next Param Data 2 -->
     <Param>305</Param><!-- Response Fixed Semicolon (;) -->
     <Param>306</Param><!-- Response Fixed Exclamation Mark (!) -->
  </Content>
</Response>
```

The following incoming responses would be completely valid and will be matched `MyVariableData1:?MyVariableData2;!`, `:?;!`, `data1:?;!`, `:?data2;!`, ... Note that parameters of a variable length are allowed to be empty!

DataMiner's matching behavior is more complicated if the response does not match.
Depending on where the mismatch occurs, some variables will be populated.

##### Mismatch for non-fixed parameter
If the matching fails for a non-fixed parameter, **all** non-fixed parameters in the response **will be empty**, regardless if the mismatch is in the beginning or the end of the response.
In our response, a mismatch for a non-fixed parameter can occur if param 301 or 304 cannot be populated, which happens if the parameter directly after the non-fixed parameter cannot be found.
Param 301 will fail to be populated if no `:` can be found in the remaining data and parameter 304 will fail to be populated if no `;` can be found in the remaining data.
Example responses causing such a matching failure are `?MyData;!` (failure for param 301), `MyData:?!` (failure for param 303).
**Parameter 301 and 304 will both be empty. Even if parameter 301 was first successfully matched, and the match only fails when trying to populate parameter 304.**

##### Mismatch for fixed parameter
When the matching fails at a fixed parameter, all non-fixed parameters that have already been populated during the matching process **will remain filled in**.
Example of such wrong responses are `data1:data2;!`, `:data2;!` (param 303 not found after a fixed param 302 was found), `data1:?data2;`, `data1:?;` (param 306 not found after a fixed param 305 was found).
**In the first 2 examples, parameter 301 will remain filled in as it was already successfully matched, parameter 304 will remain empty.
In the third and fourth example, both parameter 301 and 304 will remain filled in, as both were already successfully matched.**

**How do you know that the response did not match fully, even when my non-fixed parameters have been populated?**
This is where [triggers](xref:Protocol.Triggers.Trigger.Time) come into play.
The following 2 triggers will only be executed if the response is actually completely matched:

```xml
<!-- This trigger will go off when response 300 was completely matched -->
<Trigger id="300">
   <Name>AfterMatchedResponse300</Name>
   <On id="300">response</On>
   <Time>after</Time>
   <Type><!--Fill in as necessary--></Type>
   <Content>
      <!--Fill in as necessary-->
   </Content>
</Trigger>

<!-- This trigger will go off when parameter 300 has changed, and that the response of which it is a part has been completely matched -->
<Trigger id="301">
   <Name>AfterMatchedResponseForParam300</Name>
   <On id="300">parameter</On>
   <Time>change after response</Time>
   <Type><!--Fill in as necessary--></Type>
   <Content>
      <!--Fill in as necessary-->
   </Content>
</Trigger>
```

### Responses with length field

A length field in a response can be used to:

- Read in the response before timeout time.
- Validate the size of the "variable length data bytes" in your response in order to make sure you will not continue working with invalid data (less or more bytes received than expected).

A requirement is that the length field needs to be in an identifiable position (e.g. after a parameter of type fixed or a header) and that the size of the length field is fixed.

Fixed Length | Next Param | **Fixed** | **Length** | data

**Header** | **Length** | Data | Trailer

For example:

```xml
<Response id="300">
  <Name>responseCWithLengthAndDataAtEndWithoutTrailer</Name>
  <Description>Response C With Length And Data at End Without Trailer</Description>
  <Content>
     <Param>300</Param><!-- ResponseC Key Field -->
     <Param>301</Param><!-- ResponseC Variable Data -->
     <Param>302</Param><!-- ResponseC Fixed Colon (:) -->
     <Param>303</Param><!-- ResponseC Length Field -->
     <Param>304</Param><!-- ResponseC Variable Length Data Field -->
  </Content>
</Response>
```

The length parameter (ID 303) contains a definition as shown below.

```xml
<Param id="303">
  <Name>ResponseCLengthField</Name>
  <Description>Response C Length Field</Description>
  <Type>length</Type>
  <Interprete>
     <RawType>numeric text</RawType>
     <LengthType>fixed</LengthType>
     <Length>2</Length>
     <Type>double</Type>
  </Interprete>
  <Length>
     <Content>
        <Param>4</Param>
     </Content>
  </Length>
</Param>
```

The parameter type is set to "length".

The Interprete.Length has a fixed number of bytes (2).

The Length.Content tag is used to link the length with the parameter that will be used to store the variable amount of data. The content of the Length.Content.Param tag is the zero-based idx of the parameter location in the response definition. In this example, parameter 303 defines the length of parameter 304, which is in position 4 in response 300.

In order to validate if the received number of bytes corresponds with the length value, an action "length response" needs to be executed using a trigger before response. Note that the length action needs to be after "read response".

When the number of bytes is larger or smaller than defined, the response processing will fail and the data parameter will not be updated with received content; only the length field will be updated with its corresponding new value. As a result, a timeout will also be generated.

```xml
<Trigger id="13">
   <Name>beforeResponse300</Name>
   <On id="300">response</On> <!-- ResponseC With Length and Data at End Without Trailer -->
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <Id>3</Id> <!-- Response Read --> 
      <Id>4</Id> <!-- Response Length --> 
   </Content>
</Trigger>

<Action id="3">
   <Name>Response Read</Name>
   <On>response</On>
   <Type>read</Type>
</Action>
<Action id="4">
   <Name>Response Length</Name>
   <On>response</On>
   <Type>length</Type>
</Action>
```

The processing of a response containing a length parameter will not always hold the response when the length does not match.

The trigger to read the response will fail but the parameters of the response will be filled in. See logging below:

```
2012/07/20 11:00:03.168|SLProtocol - 1516 - LNA1|6496|CTrigger::Perform|DBG|1|Trigger id: 2 action 4 failed with Invalid length.. (hr = 0x80040297)

2012/07/20 11:00:03.168|SLElement.exe|5952|CElement::SetParameterValue|DBG|1|** Parameter 65007 changed to VT_R8 : 0.000000

2012/07/20 11:00:03.168|SLElement.exe|5952|CElement::SetParameterValue|DBG|1|** Parameter 256 changed to VT_R8 : 24.000000

2012/07/20 11:00:03.184|SLElement.exe|6836|CElement::SetParameterValueFunc|DBG|5|Set for PID 305 Value = VT_R8 : 98.000000

2012/07/20 11:00:03.184|SLElement.exe|10120|CElement::SendParameters|DBG|1|--> Retrieving all parameter values took 0 ms

2012/07/20 11:00:03.184|SLElement.exe|6836|CElement::SetParameterValueFunc|DBG|5|Set for PID 256 Value = VT_R8 : 24.000000

2012/07/20 11:00:03.184|SLProtocol - 1516 - LNA1|6496|CParameter::MatchParameter|DBG|2|-> LNA/LNB Currents new data (144,135,210,207)000000 3134342C31 33352C3231 302C323037 144,135,210,207

2012/07/20 11:00:03.184|SLElement.exe|10120|CElement::SetParameterValueFunc|DBG|5|Set for PID 1001 Value = VT_BSTR : 144,135,210,207

2012/07/20 11:00:03.184|SLElement.exe|6836|CParameter::BuildRealArray|DBG|1|Retrieved table 65010 in 0 ms
```

The reason is that only the last action in a trigger can cause a definitive cancel of the response. When the length action is not the last action, SLProtocol will try to parse the response up to the length parameter and this causes parameters before the length to be processed.

> [!TIP]
> See also:
>
> - [Protocol.Actions.Action.Type](xref:Protocol.Actions.Action.Type)
> - [Protocol.Params.Param.Type](xref:Protocol.Params.Param.Type)

### Responses with dynamically defined length

While a parameter using Interprete.LengthType "next param" will read out a variable amount of data located in between two identifiable parameters (= fixed length, fixed, header/trailer), a parameter using Interprete.LengthType "other param" will read out data for the size defined in another parameter.

> [!NOTE]
>
> - If this is used in combination with a length parameter, validation to see if more data is received or not will not be possible, since it is not possible to receive more data in the parameter. It is therefore recommended to only use this feature when there is no risk of working with invalid data.
> - The usage of "other param" does not influence whether a response will be read out before timeout or not. Typically, if you want to obtain this, the parameter containing the size needs to be configured as a length parameter (taking the information above into account)

In the example below, the Interprete.Length will be defined at runtime by the content of parameter 503. The response will wait on timeout time, since parameter 503 is not configured as type length.

```xml
<Response id="500">
  <Name>ResponseEWithOtherParam</Name>
  <Description>Response E With Other Param</Description>
  <Content>
     <Param>500</Param><!-- ResponseE Key Field -->
     <Param>501</Param><!-- ResponseE Variable Data -->
     <Param>502</Param><!-- ResponseE Fixed Colon (:) -->
     <Param>503</Param><!-- ResponseE Length Field -->
     <Param>504</Param><!-- ResponseE Variable Length Data Field -->
  </Content>
</Response>

<Param id="503">
  <Name>ResponseELengthField</Name>
  <Description>Response E Length Field</Description>
  <Type>read</Type>
  <Interprete>
     <RawType>numeric text</RawType>
     <LengthType>fixed</LengthType>
     <Length>2</Length>
     <Type>double</Type>
  </Interprete>
</Param>
<Param id="504">
  <Name>responseEVariableLengthDataField</Name>
  <Description>Response E Variable Length Data Field</Description>
  <Type>read</Type>
  <Information>...</Information>
  <Interprete>
     <RawType>other</RawType>
     <LengthType id="503">other param</LengthType>
     <Type>string</Type>
  </Interprete>
  <Display>...</Display>
   <Measurement>
      <Type>string</Type>
   </Measurement>
</Param>
```

The field that specifies the length can have a variable length.<!-- RN 24442 --> The following restrictions apply:

- The response must contain a trailer that is set before the data parameter. (It does not have to contain a header.)
- The length parameter should be located before the data parameter. It should be of length type "next param" and raw type "numeric text".
- The length parameter must be located between two fixed parameters.

![Responses with dynamically defined length](~/develop/images/RN24442.svg)

> [!NOTE]
> An example protocol "Skyline Example Serial Response Matching" is available in the [SkylineCommunications/SLC-C-Example_Serial-Response-Matching](https://github.com/SkylineCommunications/SLC-C-Example_Serial-Response-Matching) GitHub repository.

## Cyclic Redundancy Check (CRC)

Some serial protocols use a cyclic redundancy check (CRC) error detection mechanism and therefore require the command/response to include a CRC value, which is typically based on the remainder of a polynomial division of the command/response content. This can be implemented via a parameter of type "crc".

This parameter has a CRC child tag, where CRC.Type defines how the CRC is calculated. The CRC.Content refers to the parameters in a command or response.

```xml
<Param id="3000">
  <Name>CRC</Name>
  <Description>CRC</Description>
  <Type>crc</Type>
  <Interprete>
     <RawType>unsigned number</RawType>
     <LengthType>fixed</LengthType>
     <Length>1</Length>
     <Type>double</Type>
  </Interprete>
  <CRC>
     <Type mod="95" off="-32" totaloffset="32">sum</Type>
     <Content>
        <Param>0</Param>
        <Param>1</Param>
        <Param>2</Param>
        <Param>3</Param>
        <Param>4</Param>
     </Content>
  </CRC>
</Param>
```

In the example below, the CRC calculation is done with parameter 0, 2, 6, 5, and 1.

```xml
<Command id="1">
  <Name>Get Helix Current</Name>
  <Description>Get Helix Current</Description>
  <Content>
     <Param>0</Param>
     <Param>2</Param>
     <Param>6</Param>
     <Param>5</Param>
     <Param>1</Param>
     <Param>3000</Param>
  </Content>
</Command>
```

In addition to defining the CRC parameter, you also need to execute an action "crc response", "crc command" in order to execute the calculation and the verification.

The following protocol fragment triggers a "crc response" action:

```xml
<Trigger id="4">
  <Name>BeforeResponse_410</Name>
  <On id="410">response</On>
  <Time>before</Time>
  <Type>action</Type>
  <Content>
     <Id>410</Id>
  </Content>
</Trigger>

<Action id="410">
  <Name>Response CRC</Name>
  <On>response</On>
  <Type>crc</Type>
</Action>
```

In case the CRC value is required as hex instead of decimal, the Base tag can be used as in the example below:

```xml
<Param id ="91">
  <Name>CRC 5</Name>
  <Description>CRC 5</Description>
  <Type>crc</Type>
  <Interprete>
     <RawType>numeric text</RawType>
     <LengthType>fixed</LengthType>
     <Length>2</Length>
     <Type>double</Type>
     <Base>16</Base>
  </Interprete>
  <CRC>
     <Type>exor</Type>
     <Content>
        <Param>0</Param>
        <Param>1</Param>
        <Param>2</Param>
        <Param>3</Param>
        <Param>4</Param>
     </Content>
  </CRC>
</Param>
```

```
Result: calculated crc = 6D

 

<< 11:22:02 - Poll Alarms

000000 7B30355241 36447D0D {05RA6D}
```

### See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.CRC.Type](xref:Protocol.Params.Param.CRC.Type)

## Read bit

It is possible that a device returns a byte (or multiple bytes) where certain bits represent a certain variable (e.g. a device can return a byte where each bit represents a flag). Therefore, a protocol needs to be able to read out certain bits or a group of bits from a byte. This can be achieved using parameters of type "read bit".

The byte or bytes in question need to be stored in a parameter of type "group" where the length is set to the number of bytes. (This parameter has a fixed length).

```xml
<Param id="1000">
  <Name>statusBytes</Name>
  <Description>Status Bytes</Description>
  <Type>group</Type>
  <Interprete>
     <RawType>unsigned number</RawType>
     <LengthType>fixed</LengthType>
     <Length>2</Length>
     <Type>double</Type>
     <Endian>big</Endian>
   </Interprete>
</Param>
```

Note that the parameter specifies big endian. This way, the bytes in the group parameter are ordered the same way as you would see when capturing the response (See [Protocol.Params.Param.Interprete.StartPosition](xref:Protocol.Params.Param.Interprete.StartPosition)).

Parameters of type "read bit" can then be defined to read out the value at certain bit positions and will refer to the parameter of type "group" and define which bit(s) must be read out using the StartPosition and NbrOfBits child tags.

```xml
<Type id="1000">read bit</Type>
<Interprete>
  <RawType>unsigned number</RawType>
  <LengthType>fixed</LengthType>
  <StartPosition>0</StartPosition>
  <NbrOfBits>1</NbrOfBits>
  <Type>double</Type>
</Interprete>
```

> [!NOTE]
> The bit positions used in DataMiner are from left to right instead of right to left. So bit 0 is the most significant bit.

Example: The device sends 2 bytes; 0x31 0x02.

```
0 0 1 1 0 0 0 1     0 0 0 0 0 0 1 0

8             15    0             7
```

## Write bit

A parameter of type "write bit" can be used to change a bit from a byte that is stored in a parameter of type 'group'. A parameter of type "write bit" needs to refer to a parameter of type "group" (via the id attribute of the Type tag).

```xml
<Param id="147">
  <Name>logTxPowerMask</Name>
  <Description>Log Tx Power Mask</Description>
  <Type id="179">write bit</Type>
  <Interprete>
     <RawType>unsigned number</RawType>
     <LengthType>fixed</LengthType>
     <Type>double</Type>
     <StartPosition>7</StartPosition>
     <NbrOfBits>1</NbrOfBits>
  </Interprete>
  <Display>
     <RTDisplay>true</RTDisplay>
     <Range></Range>
     <Units></Units>
     <Positions>
        <Position>
           <Page>Fault history Mask</Page>
           <Row>0</Row>
           <Column>0</Column>
        </Position>
     </Positions>
  </Display>
  <Measurement>
     <Type>togglebutton</Type>
     <Discreets>
        <Discreet>
           <Value>0</Value>
           <Display>Disabled</Display>
        </Discreet>
        <Discreet>
           <Value>1</Value>
           <Display>Enabled</Display>
        </Discreet>
     </Discreets>
  </Measurement>
</Param>
```

Note that a protocol will typically define 2 parameters of type "group"; one used to hold the value that is read from the device and one that will hold the value that will be written to the device. For example, the following protocol fragment defines two parameters of type "group": the parameter with ID 113 is used for reading out the byte(s) and the parameter with ID 179 is used for writing the byte(s).

```xml
<Param id="113">
  <Name>faultHistoryMaskBinary</Name>
  <Description>Fault history Mask Binary</Description>
  <Type>group</Type>
  <Interprete>
     <RawType>unsigned number</RawType>
     <LengthType>fixed</LengthType>
     <Length>4</Length>
     <Type>double</Type>
  </Interprete>
</Param>
<Param id="179">
  <Name>faultHistoryMaskBinaryWrite</Name>
  <Description>Fault history Mask Binary Write</Description>
  <Type>group</Type>
  <Interprete>
     <RawType>unsigned number</RawType>
     <LengthType>fixed</LengthType>
     <Length>4</Length>
     <Type>double</Type>
  </Interprete>
</Param>
```

When the value of the parameter of type "group" that is used to read the data is changed, the parameter of type "group" used for writing the data should be cleared and set to this updated value.

This is done using a trigger that triggers on a change of the parameter of type "group" used for reading, which will perform a "clear" action followed by an "append data" action on the parameter of type "group" used for writing.

```xml
<Trigger id="135">
   <Name>OnChangeFaultHistoryMaskBinary</Name>
   <On id="113">parameter</On>
   <Time>change</Time>
   <Type>action</Type>
   <Content>
      <Id>135</Id>
      <Id>45</Id>
   </Content>
</Trigger>

<Action id="135">
  <Name>clear fault history mask binary write</Name>
  <On id="179">parameter</On>
  <Type>clear</Type>
</Action>
<Action id="45">
  <Name>append data fault history mask binary</Name>
  <On id="179">parameter</On>
  <Type id="113">append data</Type>
</Action>
```

When the write bit is then changed by the user, the specified bit will be changed in the parameter of type "group" used for writing. The parameter of type "group" used for writing can then be used to send a command to the device.

> [!NOTE]
> Read and write bits are typically used when implementing a serial protocol. However, usage of parameters of type "read bit" and "write bit" is not restricted to serial connections.

## Parameters of type response

In case a response parameter contains data that can be considered to consist of multiple fields, this can be modeled in a response linked to a parameter of type "response".

For example, consider a response from a device (i.e. a response that is used in a pair) that looks like this:

```xml
<Response id="50">
   <Name>get audio gain</Name>
   <Description>get audio gain</Description>
   <Content>
      <Param>1999</Param>
      <Param>1002</Param>
      <Param>1040</Param>
      <Param>100</Param>
      <Param>2</Param>
   </Content>
</Response>
```

Parameter 100 is now defined as follows:

```xml
<Param id="100">
   <Name>audioGain_ResponseParameter</Name>
   <Description>Audio Gain - Response Parameter</Description>
   <Type id="3000">response</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
</Param>
```

This parameter is of type "response" and the id attribute refers to another response (in this case response 3000).

This is a response that is not used in a pair, but is used to define the structure of the content of parameter 100.

```xml
<Response id="3000">
   <Name>Audio gain</Name>
   <Description>Audio gain</Description>
   <Content optional="0+++;4">
      <Param>67</Param>
      <Param>62</Param>
      <Param>1001</Param>
      <Param>2002</Param>
      <Param>74</Param>
   </Content>
</Response>
```

This allows the content of the different fields to be read without the use of a QAction.

> [!NOTE]
> For more information about the optional attribute, see [optional attribute](xref:Protocol.Responses.Response.Content-optional).

A "read response" action is needed that must be triggered on this response.

```xml
<Trigger id="58">
   <Name>BeforeResponse_3000</Name>
   <On id="3000">response</On>
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <Id>1</Id>
   </Content>
</Trigger>

<Action id="1">
   <On>response</On>
   <Type>read</Type>
</Action>
```
