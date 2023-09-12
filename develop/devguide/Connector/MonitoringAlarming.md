---
uid: MonitoringAlarming
---

# Alarming

## Introduction

DataMiner provides the possibility to define alarm templates. An alarm template is an XML file containing all alarm thresholds for all parameters that support alarming in a DataMiner protocol. For more information about alarm templates in DataMiner, refer to [Alarm templates](xref:About_alarm_templates).

Typically, only a subset of the parameters defined in a protocol should support alarming (and therefore be included in the alarm template overview). This is because many parameters in a protocol are defined to implement internal protocol logic.

By default, a parameter will not support alarming (and therefore will not be shown in alarm templates for the protocol). To configure a parameter so it supports alarming, the following must be included in the parameter definition:

```xml
<Alarm>
   <Monitored>true</Monitored>
</Alarm>
```

> [!NOTE]
>
> - A parameter that supports alarming should be visualized to the user (i.e. have a position on a page).
> - Monitoring must never be applied on parameters of type "write".

In an alarm template, a user can specify values for different alarm severity levels. In order to avoid users having to spend too much time specifying these values, default values can be provided in a protocol (which can then be overridden by a user in DataMiner if desired).

It is possible to define default values for the following alarm levels:

|Alarm severity level|Tag|
|--- |--- |
|-|Info|
|Critical low|CL|
|Major low|MaL|
|Minor Low|MiL|
|Warning low|WaL|
|Normal|Normal|
|Warning high|WaH|
|Minor high|MiH|
|Major high|MaH|
|Critical high|CH|

For example, for a numeric parameter you can define that a value of 40 is normal and 80 results in a warning (WaH). This will result in an alarm with severity "warning high" when the value of the parameter is at least 80. Values below 80 will have severity "Normal". Once the value of the parameter has dropped below 80 again, the alarm will be cleared.

```xml
<Param id="22" trending="false" save="true">
   <Name>CpuUsage</Name>
   <Description>CPU Usage</Description>
   <Information>…</Information>
   <Type>read</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
   </Interprete>
   <Display>…</Display>
   <Measurement>
      <Type>number</Type>
   </Measurement>
   <Alarm>
      <Monitored>true</Monitored>
      <Normal>40</Normal>
      <WaH>80</WaH>
   </Alarm>
</Param>
```

For parameters holding discrete values, the discrete value can be used for setting default alarm values.

> [!NOTE]
>
> - In DataMiner, the corresponding display value (as indicated in the Display tag) will be displayed in the alarm template.
> - For parameters with measurement type set to discreet or string, the low severity levels are not applicable (i.e. only the tags Normal, WaH, MiH, MaH and CH can be used in this case).

```xml
<Param id="10" trending="true">
   <Name>OperationalStatus</Name>
   <Description>Operational Status</Description>
   <Information>…</Information>
   <Type>read</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
   </Interprete>
   <Display>…</Display>
   <Measurement>
      <Type>discreet</Type>
      <Discreets>
         <Discreet>
            <Display>OK</Display>
            <Value>0</Value>
         </Discreet>
         <Discreet>
            <Display>Alarm</Display>
            <Value>1</Value>
         </Discreet>
      </Discreets>
   </Measurement>
   <Alarm>
      <Monitored>true</Monitored>
      <Normal>0</Normal>
      <CH>1</CH>
   </Alarm>
</Param>
```

The principle mentioned above also applies to column parameters. In this case, DataMiner provides additional functionality. The alarm template allows you to define multiple entries for the same column parameter, but with a different filter. In case an alarm occurs for the column parameter, the parameter description is used in combination with the key in the alarm.

For more information on how to implement alarming in a protocol, see <xref:Protocol.Params.Param.Alarm>.

## Exception values

In case you want to define default alarm values for exception values, use the value mentioned in the value tag of the exception and use '$' as prefix.

```xml
<Interprete>
   <RawType>numeric text</RawType>
   <LengthType>next param</LengthType>
   <Type>double</Type>
   <Exceptions>
      <Exception id="1" value="-9999">
         <Display state="disabled">Invalid</Display>
         <Value>-9999</Value>
      </Exception>
      <Exception id="2" value="-9998">
         <Display state="disabled">Transponder disabled</Display>
         <Value>-9998</Value>
      </Exception>
   </Exceptions>
</Interprete>
<Alarm>
   <Monitored>true</Monitored>
   <WaL>$-9999;$-9998</WaL>
</Alarm>
```

## Threshold

With the threshold option, you can define that when the value of the second parameter is lower than the first, no alarm should be created.

```xml
<Alarm options="threshold:102,2206">
```

## Conditional parameter alarming

Alarm monitoring of a parameter can be deactivated based on a condition.

In the example below, if parameter 10003 equals "Not Monitored", the parameter will no longer be monitored until the condition is again not met.

```xml
<Alarm>
   <Monitored disabledIf="10003,Not Monitored">true</Monitored>
</Alarm>
```

> [!NOTE]
> In case a condition is defined in the protocol, this condition acts as a default condition in the alarm template. This default can be disabled in the alarm template. For more information about using conditions in an alarm template, see [Using conditions in an alarm template](xref:Using_conditions_in_an_alarm_template).
