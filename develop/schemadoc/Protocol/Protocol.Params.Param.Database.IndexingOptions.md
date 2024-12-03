---
uid: Protocol.Params.Param.Database.IndexingOptions
---

# IndexingOptions element

<!-- RN 13552 -->

Specifies indexing options (OpenSearch/Elasticsearch).

## Parent

[Database](xref:Protocol.Params.Param.Database)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[enabled](xref:Protocol.Params.Param.Database.IndexingOptions-enabled)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)|Yes|Specifies whether the data of the logger table will be stored in the indexing database instead of Cassandra. When set to true, the data of the logger table will be stored in the indexing database instead of Cassandra|

## Examples

```xml
<Database>
    <IndexingOptions enabled="true"/>
</Database>
```
