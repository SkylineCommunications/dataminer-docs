---
uid: Protocol.Params.Param.HyperLinks.HyperLink
---

# HyperLink element

Deprecated. Defines a custom command (i.e. “hyperlink”) that has to appear on the shortcut menu when users right-click an alarm of the parameter in question. This is not supported in DataMiner Cube. Instead, a separate [Hyperlinks.xml](xref:Hyperlinks_xml) file is used.

## Type

string

## Parent

[HyperLinks](xref:Protocol.Params.Param.HyperLinks)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[valueParsing](xref:Protocol.Params.Param.HyperLinks.HyperLink-valueParsing)|string||Makes the command appear on the shortcut menu of specific alarms and information events.|

## Remarks

Contains the actual command that has to be displayed on the shortcut menu.

The string you specify can contain

- keywords, which allow you to insert real-time data in the command name that is displayed, and
- placeholders, which allow you to insert (parts of) the value of the alarm or information event in the command that is displayed

The string you specify inside the HyperLink tag can contain the following keywords. These will be replaced by real-time data in the command that is displayed on the shortcut menu.

|Placeholder|Description
|--- |--- |
|[ENAME]|The element name.|
|[PNAME]|The parameter name.|
|[DMAID]|The ID of the DataMiner agent.|
|[EID]|The ID of the element.|
|[ALARMID]|The ID of the alarm or the information event.|
|[ROOTKEY]|The ID of the root alarm.|
|[VALUE]|The value of the alarm.|
|[POLLINGIP]|The IP address of the device.|
|[PROPERTY:VIEW:name]|The value of the view property called “name”.|
|[PROPERTY:ELEMENT:name]|The value of the element property called “name”.|
|[PROPERTY:ALARM:name]|The value of the alarm property called “name”.|
|[PROPERTY:PARAMETER:name]|The value of the parameter property called “name”.|

## Examples

If you specify the following, in the right-click menu of every alarm of the parameter in question, users will be able to click a command that will open the element in Element Display:

```xml
<HyperLink valueParsing="">http://dma_id/DataDisplay.htm?id=[DMAID]/[EID]</HyperLink>
```

If you specify the following, the name of the Automation script, indicated by the placeholder “[1]” in the valueParsing attribute, will appear at the end of the command name displayed on the shortcut menu. So, if you right-click an alarm or an information event of which the value starts with, for example, “Set by Automation-script MyScript to”, then the shortcut menu will contain a custom command named “ExecuteScript.exe -n MyScript”:

```xml
<HyperLink valueParsing="Set by Automation Script [1] to *">ExecuteScript.exe -n [1]</HyperLink>
```

If you specify the following, a web page will be opened:

```xml
<HyperLink>http://www.skyline.be</HyperLink>
```

If you specify the following, a web page will be opened and the alarm ID will be passed to that page:

```xml
<HyperLink>http://intranet/troubleticket.aspx?ID=[ALARMID]</HyperLink>
```

If you specify the following, an Automation script will be executed:

```xml
<HyperLink>Script:MyScript|ph1=1/2;ph2=1/2|Parameter1=12;Parameter2=15|Mem1=memoryfile1; Mem2=memoryFile2</HyperLink>
```
