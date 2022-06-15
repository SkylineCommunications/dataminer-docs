---
uid: Protocol.Params.Param.Database.IndexingOptions
---

# IndexingOptions element

Specifies indexing options (Elastic).

## Parent

[Database](xref:Protocol.Params.Param.Database)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[enabled](xref:Protocol.Params.Param.Database.IndexingOptions-enabled)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)|Yes|Specifies whether the data of the logger table will be stored in the Elastic database instead of Cassandra. When set to true, the data of the logger table will be stored in the Elastic database instead of Cassandra|

## Remarks

*Feature introduced in DataMiner 9.6.4 (RN 13552).*

## Examples

```xml
<Database>
    <IndexingOptions enabled="true"/>
</Database>
```
