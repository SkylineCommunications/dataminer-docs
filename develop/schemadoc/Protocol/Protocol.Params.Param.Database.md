---
uid: Protocol.Params.Param.Database
---

# Database element

<!-- RN 11853 -->

Specifies database-related settings for a particular parameter.

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[ColumnDefinition](xref:Protocol.Params.Param.Database.ColumnDefinition)|[0, 1]|Specifies the type of the corresponding column in the database table.|
|&nbsp;&nbsp;[Connection](xref:Protocol.Params.Param.Database.Connection)|[0, 1]|Specifies connection options.|
|&nbsp;&nbsp;[CQLOptions](xref:Protocol.Params.Param.Database.CQLOptions)|[0, 1]|Specifies Cassandra-related database settings.|
|&nbsp;&nbsp;[IndexingOptions](xref:Protocol.Params.Param.Database.IndexingOptions)|[0, 1]|Specifies indexing options (OpenSearch/Elasticsearch).|
|&nbsp;&nbsp;[Partition](xref:Protocol.Params.Param.Database.Partition)|[0, 1]|Specifies the partitioning configuration.|

## Examples

```xml
<Param>
   <Database>
      <CQLOptions>
         <Clustering>1;2</Clustering>
         <TableProperty>CLUSTERING ORDER BY (&quot;[PID:52]&quot; DESC)</TableProperty>
         <Finalizer>CREATE INDEX IF NOT EXISTS ON [TABLE] ([PID:52])</Finalizer>
      </CQLOptions>
   </Database>
</Param>
```
