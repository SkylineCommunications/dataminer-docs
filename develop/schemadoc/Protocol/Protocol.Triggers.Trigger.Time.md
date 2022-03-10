---
uid: Protocol.Triggers.Trigger.Time
---

# Time element

Defines, together with /Protocol/Triggers/Trigger/On, the exact moment at which a trigger will go off.

## Type

[TypeTriggerTime](xref:Protocol-TypeTriggerTime)

## Parent

[Trigger](xref:Protocol.Triggers.Trigger)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[case](xref:Protocol.Triggers.Trigger.Time-case)|string||Specifies the condition operator: equal, not equal, greater, less, or a logical combination of those operators.|
|[id](xref:Protocol.Triggers.Trigger.Time-id)|unsignedInt||Specifies the ID of the parameter, command, response, etc. (defined in /Protocol/Triggers/Trigger/On) of which the value will be checked.|
|[nr](xref:Protocol.Triggers.Trigger.Time-nr)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Set this attribute to true if the value attribute contains a parameter ID instead of a parameter value.|
|[value](xref:Protocol.Triggers.Trigger.Time-value)|string||Specifies the value that will be used as condition operand.|

## Remarks

Not all Protocol.Triggers.Trigger.Time values can be used in combination with the different Protocol.Triggers.Trigger.On types. See below for an overview of the possible combinations.

|\<On\> value|\<Time\> value|Description|
|--- |--- |--- |
|command|before|The trigger will go off before the specified command is executed.|
|command|after|The trigger will go off after the specified command is executed.|
|communication|DATA|The trigger will go off when the connection reports the specified DATA string. See example below\*.|
|group|before|The trigger will go off before the specified group is executed.|
|group|after|The trigger will go off after the specified group is executed.|
|pair|succeeded|The trigger will go off when the specified pair has successfully been executed.|
|pair|timeout|The trigger will go off when a timeout occurs on the specified pair.|
|pair|timeout after retries|The trigger will go off after the last retry. *Feature introduced in DMS 8.5.2 (RN 8573).*|
|parameter|change|The trigger will go off when the value of the specified parameter has changed.|
|parameter|change after response|The trigger will go off when the value of the specified parameter has changed and the incoming response has been fully received.|
|parameter|timeout|The trigger will go off when a timeout occurs on the specified parameter.|
|parameter|timeout after retries|The trigger will go off after the last retry. *Feature introduced in DMS 8.5.2 (RN 8573).*|
|protocol|after startup|The trigger will go off when the element running the protocol has (re)started. For example: Restart or Activate after stop. It will not trigger after a Pause. Note that at least one group must be defined in the protocol, as otherwise the trigger will not work.|
|protocol|link file changed|The trigger will go off when the protocol’s link file has changed. (This is a matrix-related option.)|
|response|before|The trigger will go off before the specified response is processed.|
|response|after|The trigger will go off after the specified response has successfully been received.|
|session|timeout|The trigger will go off when a timeout occurs on the specified session. Feature introduced in DataMiner 9.0.2 (RN 12542).|
|timer|before|The trigger will go off before the specified timer is executed.|

\* For example, for an HTTP connection, you can specify the following:

```xml
<Trigger id="100">
    <Name>OnCannotConnectTrigger</Name>
    <On>communication</On>
    <Time>0x4572726F72203A2031323032392E205B4552524F525F57494E485454505F43414E4E4F545F434F4E4E4543545D</Time>
    <Type>action</Type>
    <Content>
        <Id>100</Id>
    </Content>
</Trigger>
```

In the code above, the Time element is the hexadecimal representation of the following string:

Error : 12029. [ERROR_WINHTTP_CANNOT_CONNECT]

> [!NOTE]
>
> - If you define a trigger that will be activated by another trigger, then leave this tag empty.
> - Prior to DataMiner 9.0.0 [CU2], when `<NoTimeout>...</NoTimeOut>` is specified in the protocol, the "timeout after retries" trigger will not go off (whereas the "timeout" trigger will go off) when the response matches the value set in `<NoTimeout>`. However, from DataMiner 9.0.0 [CU2] (RN 12543) onwards, the "timeout after retries" trigger will go off despite the `<NoTimeout>` setting, resulting in similar behavior as the "timeout" trigger.
