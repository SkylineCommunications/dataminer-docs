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
- month (only supported with Cassandra and indexing database or with STaaS)
- year (only supported with Cassandra and indexing database or with STaaS)
- infinite (only supported with indexing database or STaaS<!-- RN 19993 -->): Ensures no rollover can occur.

Please note the following:

- For SQL databases, the *Partition* tag must be specified on a column that has *ColumnDefinition* set to DATETIME.
- For Cassandra databases, if *ColumnDefinition* is set to *DATETIME* and the *Partition* tag is set, Cassandra will use a TTL with the specified time.<!-- RN 12170 --> The TTL of a logger table column can be specified via the *Partition* tag of any column.<!-- RN 16738 -->

```xml
<Param id="1003" trending="false">
    ...
    <Database>
        <ColumnDefinition>VARCHAR(200)</ColumnDefinition>
        <Partition partitionsToKeep="2">hour</Partition>
    </Database>
</Param>
```

However, in order to preserve compatibility with a RDBMS (SQL) database, we recommend that you still define a column of type DATETIME that specifies the partitions to keep.

```xml
<Database>
    <ColumnDefinition>DATETIME</ColumnDefinition>
    <Partition partitionsToKeep="7">hour</Partition>
</Database>
```
