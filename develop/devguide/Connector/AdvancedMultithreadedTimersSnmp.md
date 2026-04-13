---
uid: AdvancedMultiThreadedTimersSnmp
---

# SNMP

To implement a multithreaded timer that performs SNMP polling, perform the following steps:

1. Building the parameters and group
1. Processing the responses

## Step 1: Building the parameters and group

Assume the following multithreaded timer is defined:

```xml
<Timer id="1" options="ip:2000,1;each:60000;pollingrate:30,10,10;threadPool:100,5,201,202,203,204,205,15000;dynamicthreadpool:200">
  <Name>Poll timer SNMP</Name>
  <Time>1000</Time>
  <Interval>0</Interval>
  <Content>
    <Group>2000</Group>
  </Content>
</Timer>
```

This multithreaded timer has 2000 as content group.

With multithreaded timers, the Param children of this Group’s content can have one of the following suffixes (after a colon (“:”)):

- **single**: If ":single" is appended after the parameter ID, this parameter will be retrieved via a separate SNMP Get request. See [single](#single).
- **instance**: Indicates that this parameter holds the instance value. The following parameters in the group will use the value retrieved by this parameter as the instance. See [instance](#instance).
- **table**: (Deprecated) Indicates that the requested parameter represents a table. Use tablev2 instead. See [table](#table).
- **tablev2**: Indicates that the requested parameter represents a table. See [tablev2](#tablev2).
- **getnext**: Performs a GetNext request.

### single

Suppose group 2000 has the following content:

```xml
<Group id="2000" connection="0">
   <Name>SNMP Poll Group</Name>
   <Content multipleGet="true">
      <Param>1000</Param>
      <Param>1001</Param>
      <Param>1002</Param>
      <Param>1003:single</Param>
   </Content>
</Group>
```

Note that the multipleGet option is set to "true". This means that this will result in a SNMP Get request with multiple variable bindings.

However, since Param 1003 has the suffix ":single", this parameter will be requested in a separate SNMP Get request.

Param 1003 is then defined as follows:

```xml
<Param id="1003" trending="false">
   <Name>STB Svc. 1 Name</Name>
   <Description>STB Svc. 1 Name</Description>
   <Type options="loadOID">read</Type>
   <Display>
      <RTDisplay>true</RTDisplay>
   </Display>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
   <SNMP>
      <Enabled>true</Enabled>
      <Type>OctetStringASCII</Type>
      <OID type="complete">1.3.6.1.4.1.23423.3.2.1.1.1.0</OID>
   </SNMP>
   <Measurement>
      <Type>string</Type>
   </Measurement>
</Param>
```

Note the "loadOID" option in the Param.Type@options attribute. This option is required with multithreaded SNMP polling.

> [!NOTE]
> It is advised to always put the parameters with the ":single" suffix at the end of the group so the other parameters get grouped into one request.

### instance

When this suffix is used, this indicates that the value obtained in this parameter will be used as the instance for the next parameters mentioned in the group.

For example, suppose group 2000 has the following content:

```xml
<Group id="2000" connection="1">
  <Name>BSR group</Name>
  <Description>BSR group</Description>
  <Content multipleGet="true">
    <Param>1023:instance</Param><!-- This means the parameters below should use the obtained value of this parameter as the instance -->
    <Param>33</Param>
    <Param>34</Param>
    <Param>35</Param>
    <Param>36</Param>
    <Param>40</Param>
    <Param>41:instance</Param><!-- This means the parameters below should use the obtained value of this parameter as the instance. -->
    <Param>37</Param>
  </Content>
</Group>
```

Suppose parameters 1023 and 33 are defined as follows:

```xml
<Param id="1023" save="true">
  <Name>CM Instance</Name>
  <Description>CM Instance</Description>
  <Type options="loadOID">read</Type>
  <Interprete>
    <RawType>other</RawType>
    <LengthType>next param</LengthType>
    <Type>string</Type>
  </Interprete>
  <SNMP>
    <Enabled>true</Enabled>
    <OID type="complete">1.3.6.1.2.1.10.127.1.3.7.1.2</OID>
  </SNMP>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>string</Type>
  </Measurement>
</Param>
<Param id="33" trending="false">
  <Name>docsIfCmtsCmStatusUnerroreds</Name>
  <Description>docsIfCmtsCmStatusUnerroreds</Description>
  <Type options="loadOID">read</Type>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <SNMP>
    <Enabled>true</Enabled>
    <OID type="complete">1.3.6.1.2.1.10.127.1.3.3.1.10</OID>
  </SNMP>
  <Interprete>
    <RawType>unsigned number</RawType>
    <LengthType>fixed</LengthType>
    <Length>2</Length>
    <Type>double</Type>
  </Interprete>
  <Measurement>
    <Type>number</Type>
  </Measurement>
</Param>
```

Suppose when requesting the value of parameter 1023, 10 is returned. When parameter 33 is polled, the resulting OID in the request will be 1.3.6.1.2.1.10.127.1.3.3.1.10.10, i.e., the returned value of parameter 1023 is used as the instance.

### table

This suffix indicates that the requested parameter represents a table.

> [!NOTE]
> The use of "table" is deprecated. Use tablev2 instead.

For example, suppose group 2000 has the following content:

```xml
<Group id="20">
  <Name>STBFastGroupMultipleTunerNewSnmpAgent</Name>
  <Description>STB Fast Group Multiple Tuner New SNMP Agent</Description>
  <Content multipleGet="true">
    <Param>304:table</Param>
  </Content>
</Group>
```

Where parameter 304 is defined as follows:

```xml
<Param id="304" trending="false">
  <Name>ifXTable</Name>
  <Description>ifXTable</Description>
  <Type options="loadOID">read</Type>
  <Interprete>
    <RawType>other</RawType>
    <LengthType>next param</LengthType>
    <Type>string</Type>
  </Interprete>
  <SNMP>
    <Enabled>true</Enabled>
    <OID type="complete">1.3.6.1.2.1.31.1.1.1;1.3.6.1.2.1.31.1.1.1.6;1.3.6.1.2.1.31.1.1.1.10</OID>
  </SNMP>
</Param>
```

In Param.SNMP.OID, specify the OID of the table entry, followed by the OIDs of the columns to retrieve.

This results in a number of GetNext request operations to retrieve the instances followed by a number of Get request operations with multiple variable bindings to retrieve the column data.

### tablev2

For example, suppose group 2000 has the following content:

```xml
<Group id="2000" connection="0">
  <Name>SNMP Poll Group</Name>
  <Content multipleGet="true">
    <Param>304:tablev2</Param>
  </Content>
</Group>
```

For example, parameter 304 states that the columns with OID 1.3.6.1.2.1.31.1.1.1.6 and 1.3.6.1.2.1.31.1.1.1.10 should be retrieved.

```xml
<Param id="304" trending="false">
    <Name>ifXTable</Name>
    <Description>ifXTable</Description>
    <Type options="loadOID">read</Type>
    <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
    </Interprete>
    <SNMP>
      <Enabled>true</Enabled>
      <OID type="complete">1.3.6.1.2.1.31.1.1.1.6;1.3.6.1.2.1.31.1.1.1.10</OID>
    </SNMP>
  </Param>
```

This results in a number of getBulkRequest operations being performed.

## Step 2: Processing the responses

To process the responses, create a QAction that triggers on the group of the multithreaded timer.

> [!NOTE]
> Whereas typically you provide a parameter ID in the triggers attribute, here you need to specify the ID of the group of the multithreaded timer.

```xml
<QAction id="2000" name="SNMP Data" encoding="csharp" row="true" triggers="2000" options="group">
```

Note the "group" option, which allows the use of the OldRow method (SLProtocol) to retrieve the result data.

Via the NewRow method (SLProtocol), you can verify whether the request succeeded:

```csharp
/// <summary>
/// QAction entry point.
/// </summary>
/// <param name="protocol">Link with SLProtocol process.</param>
public void Run(SLProtocolExt protocol)
{
    string rowKey = protocol.RowKey();
    bool timeout = true;

    try
    {
        // NewRow() is used to check if communication issues have occurred.
        object oCommunicationInfo = protocol.NewRow();
        string communicationInfo = oCommunicationInfo as string;
        
        if (communicationInfo != null)
        {
            protocol.Log("QA" + protocol.QActionID + "|New Row Result was: " + communicationInfo, LogType.Error, LogLevel.NoLogging);
            
            switch (communicationInfo)
            {
                case "NO IP":
                    // Perform specific action when "NO IP" was returned.
                    break;
                case "TIMEOUT":
                    // Perform specific action when timeout occurred.
                    break;
                case "NO SUCH NAME":
                    // Perform specific action when "NO SUCH NAME" was returned.
                    break;
                case "NO SUCH OBJECT":
                    // Perform specific action when "NO SUCH OBJECT" was returned.
                    break;
                case "NO SUCH INSTANCE":
                    // Perform specific action when "NO SUCH INSTANCE" was returned.
                    break;
                default:
                    // Perform action when something else went wrong.
                    break;
            }
        }
        else
        {
            timeout = false;
        }
    }
    catch (Exception e)
    {
        protocol.Log(8, 5, "An exception occurred:" + e);
    }
    
    if (!timeout)
    {
        ProcessResultData(protocol);
    }
}
```

In case the request succeeded, the result data can be obtained via the OldRow method (SLProtocol).

Format of the result data:

- responses (object[]): Result object. The number of entries in this object array equals the number of items in the group.

The type of the responses entry depends on the type of item that was requested (single value or table).

In case standalone parameters were retrieved, the value can be obtained as follows:


```csharp
public static void ProcessResultData(SLProtocolExt protocol)
{
    try
    {
        object result = protocol.OldRow();
        object[] newValues = result as object[];
    
        if (newValues != null && newValues.Length == 3) // Number of items in group.
        {
            string myFirstParameter = Convert.ToString(newValues[0]);
            //...
        }
        else
        {    
            protocol.Log("QA" + protocol.QActionID + "|ProcessResultData|Unexpected result.", LogType.Error, LogLevel.NoLogging);
        }
    }
    catch (Exception e)
    {
        protocol.Log(8, 5, "Error while parsing data : " + e);
    }
}
```

In case a table was requested, the table data can be obtained as follows:

```csharp
public static void ProcessResultData(SLProtocolExt protocol)
{
    object result = protocol.OldRow();
    object[] newValues = result as object[];
    
    if (newValues != null && newValues.Length == 1) // Number of items in group.
    {
        object[] myTable = (object[])newValues[0];
        
        protocol.Log("QA" + protocol.QActionID + "|myTable " + myTable.Length, LogType.Error, LogLevel.NoLogging);
        
        object[] instanceColumn = (object[])myTable[0];
        object[] myFirstRequestedColumn = (object[])myTable[1];
        // ...
    }
    else
    {
        protocol.Log("QA" + protocol.QActionID + "|ProcessResultData|Unexpected result.", LogType.Error, LogLevel.NoLogging);
    }
}
```
