---
metadata_version: 1
uid: Protocol.Params.Param.Type-alarmRegistration
description: "Reference the DataMiner connector protocol schema entry for alarmRegistration attribute, including its documented structure, attributes, values, and const."
content_type: schema
applies_to:
  - DataMiner
---

# alarmRegistration attribute

Allows to trigger a QAction when specific parameters go into alarm.

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.Type)

## Examples

In the following example, the parameter with ID 500 will trigger the QAction when the parameters with ID 1001, 1002 or 1501 are in alarm:


```xml
<Param id="500" trending="false">
    <Name>alarmRegistration</Name>
    <Description>alarmRegistration</Description>
    <Type alarmRegistration="1001;1002;1501">read</Type>
    ...
    <QAction id="500" encoding="csharp" inputParameters="500" triggers="500">
```

The value of the parameter with ID 500 has the following format: PID/level/index

|Level|Description
|--- |--- |
|0|Undefined|
|1|Normal|
|2|Warning|
|3|Minor|
|4|Major|
|5|Critical|
