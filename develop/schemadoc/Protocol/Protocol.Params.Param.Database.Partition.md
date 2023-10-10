---
uid: Protocol.Params.Param.Database.Partition
---

# Partition element

Specifies the database partitioning configuration.

## Type

[EnumDatabasePartition](xref:Protocol-EnumDatabasePartition)

## Parent

[Database](xref:Protocol.Params.Param.Database)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[partitionsToKeep](xref:Protocol.Params.Param.Database.Partition-partitionsToKeep)|unsignedInt||Specifies the number of partitions to keep.|

## Remarks

One of the following values:

- day
- hour
- month (only supported with Cassandra and indexing database)
- year (only supported with Cassandra and indexing database)
- infinite (only supported with indexing database, from DataMiner 9.6.4 (RN 19993) onwards): Ensures no rollover can occur.

Please note the following:

- For SQL databases, the Partition tag must be specified on a column that has ColumnDefinition set to DATETIME.
- Partitioning in Cassandra is supported since DataMiner version 9.0.0 (RN 12170). If ColumnDefinition is set to DATETIME and the Partition tag is set, Cassandra will use a TTL with the specified time. Since DataMiner version 9.5.7, you can specify the TTL of a logger table column via the Partition tag on any column.

```xml
<Param id="1003" trending="false">
    ...
    <Database>
        <ColumnDefinition>VARCHAR(200)</ColumnDefinition>
        <Partition partitionsToKeep="2">hour</Partition>
    </Database>
</Param>
```

However, in order to preserve compatibility with a RDBMS (SQL) database, it is advised to still define a column of type DATETIME that specifies the partitions to keep.

```xml
<Database>
    <ColumnDefinition>DATETIME</ColumnDefinition>
    <Partition partitionsToKeep="7">hour</Partition>
</Database>
```
