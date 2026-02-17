---
uid: LogicActionWmi
---

# wmi

This action must be executed on protocol.

This action will execute a WMI script.

## Attributes

### Type@script

Specifies a WMI class, e.g., Win32_PerfRawData_PerfOS_Memory.

### Type@arguments

Specifies the names of the columns to be returned (separated by semicolons).

### Type@options

Configures the script to be executed, made up of the following components (separated by semicolons):

|Option|Description|
|--- |--- |
|connection|The ID of the virtual connection to which the WMI query will be linked.|
|pwd|ID of the parameter containing the password with which to log on to the WMI server.|
|server|"POLLINGIP" or the ID of the parameter containing the name of the WMI server.|
|table|Set this option to true if you want a table to be returned (default: false). On that table, triggers can be set.|
|uname|ID of the parameter containing the username with which to log on to the WMI server.|
|where|The WHERE clause of the script. You can specify this clause hard-coded or you can specify "ID:[Parameter ID]". In the latter case, the specified parameter must contain the WHERE clause.|

> [!NOTE]
> When you specify a hard-coded WHERE clause, replace quotes by "\&quot;".

This is an example of a hardcoded WHERE clause:

```xml
where:name=&quot;SLDataMiner&quot;
```

This is an example of a dynamic WHERE clause:

```xml
where:ID:25
```

### Type@returnValue

Specifies the ID(s) of the parameter(s) containing the returned values (if table is set to true, this ID should be the ID of a parameter of type ARRAY). (Multiple items must be separated by semicolons).

## Examples

```
SELECT VirtualBytes

FROM Win32_PerfRawData_PerfProc_Process

WHERE name=SLDataMiner
```

The example above will produce the following WMI script:

```xml
<Action id="1">
   <On>protocol</On>
   <Type options="server:pollingip;where:name=&quot;SLDataMiner&quot;uname:2;pwd:3" script="Win32_PerfRawData_PerfProc_Process" arguments="VirtualBytes" returnValue="410">wmi</Type>
</Action>
```

Other examples of WMI actions:

```xml
<Action id="2001">
   <Name>Wmi Process Query</Name>
   <On>protocol</On>
   <Type options="server:pollingip;table:true;where:name != &quot;_Total&quot; and name != &quot;Idle&quot;;uname:103;pwd:104" script="Win32_PerfRawData_PerfProc_Process" arguments="Name;IDProcess" returnValue="2000">wmi</Type>
</Action>
```

```xml
<Action id="730">
   <Name>Execute with WMI Ping command with Args1</Name>
   <On>protocol</On>
   <Type options="where:ID:733;connection:0" script="Win32_PingStatus" arguments="StatusCode;ResponseTime" returnValue="730;731">wmi</Type>
</Action>
```

```xml
<Action id="20018">
   <Name>Bytes Disk</Name>
   <On>protocol</On>
   <Type options="connection:100;server:pollingip;table:true;where:name != &quot;_Total&quot;;uname:21100;pwd:21102" script="Win32_PerfRawData_PerfDisk_LogicalDisk" arguments="name;DiskReadBytesPerSec;DiskWriteBytesPerSec;DiskBytesPerSec;Timestamp_Sys100NS;PercentDiskReadTime;PercentDiskWriteTime;PercentDiskTime;AvgDiskSecPerRead;AvgDiskSecPerWrite;AvgDiskSecPerTransfer;AvgDiskSecPerRead_Base;AvgDiskSecPerWrite_Base;AvgDiskSecPerTransfer_Base;Frequency_PerfTime" returnValue="20080">wmi</Type>
</Action>
```
