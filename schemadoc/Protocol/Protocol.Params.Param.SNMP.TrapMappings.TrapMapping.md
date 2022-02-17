---
uid: Protocol.Params.Param.SNMP.TrapMappings.TrapMapping
---

# TrapMapping element

Specifies a trap mapping.

## Parent

[TrapMappings](xref:Protocol.Params.Param.SNMP.TrapMappings)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[bindingMatch](xref:Protocol.Params.Param.SNMP.TrapMappings.TrapMapping-bindingMatch)|string||Specifies one or more values for a specific binding.|
|[severity](xref:Protocol.Params.Param.SNMP.TrapMappings.TrapMapping-severity)|string||Specifies a DataMiner severity level.|
|[value](xref:Protocol.Params.Param.SNMP.TrapMappings.TrapMapping-value)|string||Specifies an alarm value.|

## Remarks

When a trap is received, all Protocol.Params.Param.SNMP.TrapMappings.TrapMapping tags will be checked top down. When a tag matches the incoming trap, the severity and/or the value specified in that mapping will be kept in memory. As soon as both the severity and the value are known, the search will stop and the alarm will be generated.

At the end of the list of Protocol.Params.Param.SNMP.TrapMappings.TrapMapping tags, you can add such a tag in which you specify a wildcard. In the event that severity or value still cannot be determined, the method with the mapAlarm attribute on the Protocol.Params.Param.SNMP.TrapOID tag will be executed in order to try to determine the severity and value.

### Using alarm templates in /Protocol/Params/Param/SNMP/TrapMappings

Proceed as follows if you want to use an alarm template in Protocol.Params.Param.SNMP.TrapMappings.

1. Define the monitored parameter (normally, this should already be done).
1. Define an “interprete” type (which, in most cases, will be “string”).
1. Define discreets for every TrapMapping.
1. In the Protocol.Params.Param.SNMP.TrapMappings.TrapMapping tag, define the severity (id:x) in the severity attribute.

```xml
<Param id="800">
	<Interprete>
		<Type>string</Type>
	</Interprete>
	<Alarm>
		<Monitored>true</Monitored>
	</Alarm>
	<SNMP>
		<Enabled>true</Enabled>
		<TrapOID mapAlarm="TRUE|Link:3" setBindings="2,801;6,802" ipid="*" />
		<TrapMappings>
			<TrapMapping bindingMatch="*" severity="id:1" value="[3] : Gone"/>
		</TrapMappings>
	</SNMP>
	<Measurement>
		<Type>discreet</Type>
		<Discreets>
			<Discreet>
				<Display>Gone</Display>
				<Value>1</Value>
			</Discreet>
		</Discreets>
	</Measurement>
</Param>
```
