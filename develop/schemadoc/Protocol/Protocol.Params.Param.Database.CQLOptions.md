---
uid: Protocol.Params.Param.Database.CQLOptions
---

# CQLOptions element

Specifies Cassandra-related database settings.

## Parent

[Database](xref:Protocol.Params.Param.Database)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Clustering](xref:Protocol.Params.Param.Database.CQLOptions.Clustering)|[0, 1]|Specifies how the primary key of the table is defined.|
|&nbsp;&nbsp;[Finalizer](xref:Protocol.Params.Param.Database.CQLOptions.Finalizer)|[0, 1]|Specifies the query that has to be executed after the creation of the table. This can for example be a query that will preload data or create indexes.|
|&nbsp;&nbsp;[TableProperty](xref:Protocol.Params.Param.Database.CQLOptions.TableProperty)|[0, 1]|Specifies the WITH clause that is to be used to set the necessary table properties.|

## Remarks

*Feature introduced in DataMiner 9.0.0 (RN 11853).*
