---
uid: ConnectionsSerialSeriallyPollingDevices
---

# Serially polling different devices from a single element

To serially poll different devices using a single element, the element should contain a table with information about the devices it needs to poll. In case of a controller, this could be a list of all the attached modules. But it could also be a provisioned list of devices and their identifying information.

Information that is needed will be the polling IP/DNS name (required), and optionally the device type (when multiple types of devices are polled).

![Example table used to serially poll different devices](~/develop/images/Connection_types_-_serial_polling.png)

In case the element already polls a device (e.g., in the case of a controller), a second connection should be defined for the serial polling functionality. This additional connection will be used to dynamically change the polling IP at runtime to be able to poll different devices that have different addresses.

In case the element does not need to poll a device to find out which devices to poll (e.g., when importing a CSV file into a table), this second connection is not needed, and the first connection can be used.

```xml
<Type advanced="serial:modules">serial</Type>
   <PortSettings name="Modules" visibleInUi="false">
   <IPport>
      <DefaultValue>65535</DefaultValue>
      <Value>*</Value>
   </IPport>
</PortSettings>
```

> [!NOTE]
> The [visibleiInUI](xref:Protocol.Ports.PortSettings-visibleInUi) attribute should be set to "false" for the dynamic connection as the user does not need to see or be able to change the settings related to this connection.

When the second connection is created, it takes the IP and port settings from the first connection. Because of the way connections are handled in SLPort, when dynamically changing the second connection, the first connection will then also be changed. Therefore, a default value for the IP port has to be specified. This value has to be different from the port that is used on the first connection of the element. The port will be changed at runtime, together with the IP address. It is not possible to specify a default IP address for the second connection.

In addition, the protocol must define a parameter that will be used to change the polling IP at runtime.

```xml
<Param id="39999" trending="false" save="true">
  <Name>Dynamic Polling IP Conn1</Name>
  <Description>Connection 1 Dynamic Polling IP</Description>
  <Type options="dynamic ip 1">read</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>string</Type>
  </Interprete>
</Param>
```

Use the options attribute to specify for which connection the value of this parameter should be used as the polling IP. "dynamic ip 0" will change the first connection, "dynamic ip 1" will change the second connection, etc.

Polling different devices involves changing the dynamic polling IP at runtime. To make sure that one polling sequence does not interfere with another one, it is advised to only use one timer to handle all polling and potentially different "timers". In the device table, extra information should be kept about those "timers". For example, when polling different types of data at 24 h, 15 min and 5 min, specify 3 extra columns in the device table (t1-24h-timestamp, t2-15min-timestamp, t3-5min-timestamp).

## Sets

When setting parameters, it is not possible to simply initiate a group that performs the set. Two things should be taken into account:

- The polling IP needs to be changed before it is possible to perform a set.
- Writes should take into account ongoing read cycles.

All writes should be added to a buffer. This buffer then needs to be processed. This buffer can only be processed if no polling is currently active. If polling (read cycle) were active, writing would be handled by the polling cycle.

Two parameters can be used for this buffer. A parameter to hold all sets that need to be executed (the actual buffer), and a parameter that holds the next set to execute.

```xml
<Param id="40000">
   <Name>SetBuffer</Name>
   <Description>SetBuffer</Description>
   <Type>read</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>string</Type>
  </Interprete>
</Param>
<Param id="40001">
   <Name>ExecuteBuffer</Name>
   <Description>ExecuteBuffer</Description>
   <Type>read</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>string</Type>
  </Interprete>
</Param>
```

## Polling flow

A timer executes a group, which contains two actions:

```xml
<Timer id="4">
   <Name>Module Polling</Name>
   <Time>60000</Time>
   <Interval>75</Interval>
   <Content>
     <!--start of module information retrieval-->
      <Group>39000</Group>
   </Content>
</Timer>
<Group id="39000">
   <Name>start polling parameters</Name>
   <Description>start polling parameters</Description>
   <Type>poll action</Type>
   <Content>
      <Action>39000</Action>
      <Action>39001</Action>
   </Content>
</Group>
```

The first action sets a parameter used as a flag (referred to as the "poll_flag" parameter later), indicating that polling has started. A second action initializes a parameter that holds the row number (of the device table) of the device that should be polled (referred to as the "poll_row" parameter later).

```xml
<Action id="39000">
   <Name>Copy 'true' to poll_flag</Name>
   <On id="39000">parameter</On>
   <Type id="39001">copy</Type>
</Action>
<Action id="39001">
   <Name>Copy '0' to poll_row</Name>
   <On id="39003">parameter</On>
   <Type id="39004">copy</Type>
</Action>
```

A trigger is triggered on a change of the "poll_row" parameter, on the condition that the "poll_flag" has the value "true". This in turn fires an action.

```xml
<Trigger id="39000">
   <Name>Triggers on poll_row change</Name>
   <On id="39003">parameter</On>
   <Time>change</Time>
   <Condition><![CDATA[(id:39000 == "true")]]></Condition>
   <Type>action</Type>
   <Content>
      <Id>39002</Id>
   </Content>
</Trigger>
```

The action is a "run actions" on a parameter, to initiate a QAction.

```xml
<Action id="39002">
   <Name>Start poll for ip</Name>
   <On id="39005">parameter</On>
   <Type>run actions</Type>
</Action>
```

In this QAction, if "poll_flag" is "true", a check is done on the "poll_row" value. If this value falls within the number of devices in the table, it will take the information from the "poll_row" row to set the dynamic polling IP.

A check is also done on the timestamps to determine which data should be polled.

Optionally, an additional check could be done on the type of device (in case different types are polled).

```csharp
// Set dynamic polling IP.
protocol.SetParameter(39999, ip + ":" + portnr);

// Trigger group to get data.
if (type.Contains("type1"))
{
    if (timerl)
    {
        protocol.CheckTrigger(39103);
    }
    else if (timer2)
    {
        protocol.CheckTrigger(39203);
    }
    else if (timer3)
    {
        protocol.CheckTrigger(39303);
    }
}
else if (type.Contains("type2"))
{
    if (timerl)
    {
        protocol.CheckTrigger(39104);
    }
    else if (timer2)
    {
        protocol.CheckTrigger(39204);
    }
    else if (timer3)
    {
        protocol.CheckTrigger(39304);
    }
}
```

The trigger, triggered from the QAction, starts an action, which executes the group that does the actual data retrieval.

```xml
<Trigger id="39103">
   <Name>Trigger the 24h timer typel parameters Group</Name>
   <On id="39103">parameter</On>
   <Time>change</Time>
   <Type>action</Type>
   <Content>
      <Id>39103</Id>
   </Content>
</Trigger>
<Action id="39103">
   <Name>Get the 24h timer typel parameters Group</Name>
   <On id="31001">group</On>
   <Type>execute</Type>
</Action>
```

This group contains the pairs which in turn contain the commands and responses to retrieve data from the device.

Note the connection="1" in the group and options="connection:1" in the pair to indicate that the second connection should be used. When using only a single connection, this is not needed.

```xml
<Group id="31001" connection="1">
   <Name>HD0902 parameters Group 24h</Name>
   <Description>HD0902 parameters Group 24h</Description>
   <Content>
      <Pair>30000</Pair>
     ...
   </Content>
</Group>
<Pair id="30000" options="connection:1">
   <Name>Tl Hardware Version and SN Pair</Name>
   <Description>T1 Hardware Version and SN Pair</Description>
   <Content>
      <Command>30000</Command>
      <Response>30000</Response>
   </Content>
</Pair>
```

A trigger goes off after the group which starts actions to process the retrieved data, clear temporary parameters and responses and increment the "poll_row".

```xml
<Trigger id="30001">
   <Name>Trigger after getting the 24h timer params</Name>
   <On id="31001">group</On>
   <Time>after</Time>
   <Type>action</Type>
   <Content>
      <!--process received values-->
      <Id>30101</Id>
      <!--clear values/responses-->
      <Id>30004</Id>
      <Id>30006</Id>
      <!--increment-->
      <Id>30003</Id>
   </Content>
</Trigger>
```

This action starts a "run actions" action on a parameter to initiate a QAction. In this QAction, the retrieved data is copied to the tables holding the data for the different devices. These tables are the ones that export the DVE elements.

```xml
<Action id="30101">
   <Name>execute QAction to process 24h values</Name>
   <On id="30101">parameter</On>
   <Type>run actions</Type>
</Action>
```

This action clears all temporary parameters, to make sure certain data is not reused for e.g., a device that is not responding.

```xml
<Action id="30004">
   <Name>Clear parameters</Name>
   <On id="30000;30001;30002;30003;...">parameter</On>
   <Type>clear</Type>
</Action>
```

This action clears all responses.

```xml
<Action id="30006">
   <Name>Clear responses</Name>
   <On id="30000;...">response</On>
   <Type>clear</Type>
</Action>
```

- The following action starts a “run actions” on a parameter, to initiate a QAction to increment the "poll_row".
- In this QAction, a check should be done on the write buffer. If the write buffer is empty, the "poll_row" is simply incremented. If the buffer contains writes, these should be handled first.
- When performing writes, make sure that the group that does the writing triggers a group that again retrieves the data. This group should be an existing group or a specific group with limited data, but it should have a trigger like trigger 30001 in the example. This way, after a write, the initial polling can be resumed.

```xml
<Action id="30003">
   <Name>increment poll_row</Name>
   <On id="39010">parameter</On>
   <Type>run actions</Type>
</Action>
```

## Write flow

A first QAction triggers on all write parameters from the tables. The necessary information (e.g., row primary key, parameter to write, value to write, IP address) should be added to a buffer parameter.

A second QAction triggers on a change of the buffer parameter. If the buffer is not empty, the execute parameter is empty, and polling is not active ('poll_flag' is "false"), the next setting from the buffer is set in the ExecuteBuffer parameter. If polling should be active ('poll_flag' is "true"), the writes will be handled by the previously discussed QAction incrementing the 'poll_row'.

```xml
<Param id="40000">
  <Name>setBuffer</Name>
  <Description>setBuffer</Description>
  <Type>read</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>string</Type>
  </Interprete>
</Param>
```

The previous QAction also triggers on a change of the execute buffer parameter. The set will be performed by, for example, copying the necessary values to parameters that trigger a group to perform the set.

```xml
<Param id="40001">
  <Name>ExecuteBuffer</Name>
  <Description>ExecuteBuffer</Description>
  <Type>read</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>string</Type>
  </Interprete>
</Param>
```
