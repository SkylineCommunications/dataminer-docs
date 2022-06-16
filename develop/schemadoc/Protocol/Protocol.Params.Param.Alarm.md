---
uid: Protocol.Params.Param.Alarm
---

# Alarm element

Specifies the default parameter alarming configuration.

## Parent

[Param](xref:Protocol.Params.Param)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[activeTime](xref:Protocol.Params.Param.Alarm-activeTime)|unsignedInt||In case of a constant alarm: the time (in milliseconds) before the alarm is cleared.|
|[options](xref:Protocol.Params.Param.Alarm-options)|string||Specifies a number of options, separated by semicolons (”;”). These options can only be used if the table is linked to another table.|
|[type](xref:Protocol.Params.Param.Alarm-type)|string||When the polled device is able to send a nominal value for the parameter, this attribute can be added to the Protocol.Params.Param.Alarm tag.|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[CH](xref:Protocol.Params.Param.Alarm.CH)|[0, 1]|Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "critical high" alarm.|
|&nbsp;&nbsp;[CL](xref:Protocol.Params.Param.Alarm.CL)|[0, 1]|Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "critical low" alarm.|
|&nbsp;&nbsp;[Info](xref:Protocol.Params.Param.Alarm.Info)|[0, 1]|When the value of the alarm is equal to the value specified in this element, an information event is generated.|
|&nbsp;&nbsp;[MaH](xref:Protocol.Params.Param.Alarm.MaH)|[0, 1]|Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "major high" alarm.|
|&nbsp;&nbsp;[MaL](xref:Protocol.Params.Param.Alarm.MaL)|[0, 1]|Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "major low" alarm.|
|&nbsp;&nbsp;[MiH](xref:Protocol.Params.Param.Alarm.MiH)|[0, 1]|Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "minor high" alarm.|
|&nbsp;&nbsp;[MiL](xref:Protocol.Params.Param.Alarm.MiL)|[0, 1]|Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "minor low" alarm.|
|&nbsp;&nbsp;[Monitored](xref:Protocol.Params.Param.Alarm.Monitored)|[0, 1]|Allows enabling or disabling the /Protocol/Params/Param/Alarm element assigned to the parameter.|
|&nbsp;&nbsp;[Normal](xref:Protocol.Params.Param.Alarm.Normal)|[0, 1]|When the parameter value equals this value or does not exceed the specified warning limits, DataMiner will not generate an alarm. If an alarm was generated earlier, its type will be set to “dropped”.|
|&nbsp;&nbsp;[WaH](xref:Protocol.Params.Param.Alarm.WaH)|[0, 1]|Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "warning high" alarm.|
|&nbsp;&nbsp;[WaL](xref:Protocol.Params.Param.Alarm.WaL)|[0, 1]|Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "warning low" alarm.|

## Remarks

Each alarm consists of two essential factors:

- Severity: Critical, Major, Minor, Warning or Normal
- Severity Range: Low, Medium or High

These factors are combined into the following alarm levels:

- Critical Low (CL)
- Major Low (MaL)
- Minor Low (MiL)
- Warning Low (WaL)
- Normal (Normal)
- Warning High (WaH)
- Minor High (MiH)
- Major High (MaH)
- Critical High (CH)

Each alarm level is included in the Protocol.Params.Param.Alarm tag, so a value can be assigned to it. If the value of the monitored parameter is equal to or exceeds a value included in the Protocol.Params.Param.Alarm tag, DataMiner will process an alarm depending on the alarm level that corresponds to the value.

These assigned values are not only accessible via the protocol, but also via DataMiner Cube. The alarm values of a parameter can be altered by means of alarm templates, on condition that a Protocol.Params.Param.Alarm tag has been assigned to the parameter in the protocol. The alarm levels of a parameter can be adapted at any moment, regardless of the values included in the protocol.
