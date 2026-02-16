---
uid: Protocol.Params.Param.Replication
---

# Replication element

Replicates specific parameters from another element.<!-- RN 4711 -->

## Parent

[Param](xref:Protocol.Params.Param)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[ip](xref:Protocol.Params.Param.Replication-ip)|string||Specifies the IP address of the DataMiner Agent on which the element is located.|
|[uid](xref:Protocol.Params.Param.Replication-uid)|string||Specifies the user name to log on to the DataMiner Agent on which the element is located.|
|[pwd](xref:Protocol.Params.Param.Replication-pwd)|string||Specifies the password to log on to the DataMiner Agent on which the element is located.|
|[domain](xref:Protocol.Params.Param.Replication-domain)|string||Specifies the domain containing the DataMiner Agent on which the element is located.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[Element](xref:Protocol.Params.Param.Replication.Element)|[0, 1]|Specifies the DataMiner Agent ID/element ID of the replicated element.|
|&nbsp;&nbsp;[Parameter](xref:Protocol.Params.Param.Replication.Parameter)|[0, 1]|Specifies the ID of the parameter that has to be replicated.|

## Remarks

- As soon as you configure parameter replication, the polling engine will stop processing groups, i.e., only replication will be performed.
- Parameter replication is currently only supported for standalone parameters.
- Replicating the same parameter of the same element multiple times into a different local parameter is not supported.

## Examples

In the following example, you replicate parameter 1234 from element 111/1. The parameter ID does not have to match that of the parameter you replicate:

```xml
<Replication ip="127.0.0.1" uid="uid" pwd="pwd" domain="domain">
	<Element>111/1</Element>
	<Parameter>1234</Parameter>
</Replication>
```

In the following example, the IDs are stored in parameters:

```xml
<Replication uid="12" pwd="13">
	<Element dynamic="14"></Element>
	<Parameter dynamic="15"></Parameter>
</Replication>
```
