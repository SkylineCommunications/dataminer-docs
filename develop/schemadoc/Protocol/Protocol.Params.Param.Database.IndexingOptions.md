---
metadata_version: 1
uid: Protocol.Params.Param.Database.IndexingOptions
description: "Learn how to use the IndexingOptions element to configure OpenSearch or Elasticsearch storage for logger table data in a DataMiner connector protocol."
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
