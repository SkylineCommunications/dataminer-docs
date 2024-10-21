---
uid: Protocol.Params.Param.Mediation.LinkTo
---

# LinkTo element

Defines a link between a parameter of a base protocol and a parameter of this protocol.

## Parent

[Mediation](xref:Protocol.Params.Param.Mediation)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[description](xref:Protocol.Params.Param.Mediation.LinkTo-description)|string||Allows you to provide a description of the defined link.|
|[ops](xref:Protocol.Params.Param.Mediation.LinkTo-ops)|string||Specifies one or more conversion operations separated by semicolons ").|
|[pid](xref:Protocol.Params.Param.Mediation.LinkTo-pid)|unsignedInt||Specifies the ID of the parameter this parameter is linked to.|
|[protocol](xref:Protocol.Params.Param.Mediation.LinkTo-protocol)|string||Specifies the name of the protocol that contains the parameter this parameter is linked to.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[ValueMapping](xref:Protocol.Params.Param.Mediation.LinkTo.ValueMapping)|[0, *]|Defines a value mapping.|

## Remarks

For more information, refer to [DataMiner Mediation Layer](xref:AdvancedDataMinerMediationLayer).

## Examples

```xml
<Param id="73102">
	<Name>Name Process</Name>
	<Description>Name Process</Description>
	<Mediation>
		<LinkTo protocol="Network Server Manager" pid="82"/>
		<LinkTo protocol="Linux Server Manager" pid="82"/>
		<LinkTo protocol="windows Server Manager" pid="82"/>
		<LinkTo protocol="Microsoft Platform" pid="97"/>
	</Mediation>
	…
</Param>
```
