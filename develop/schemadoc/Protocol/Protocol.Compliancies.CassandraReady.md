---
uid: Protocol.Compliancies.CassandraReady
---

# CassandraReady element

Indicates whether the protocol is compatible with a Cassandra database.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Compliancies](xref:Protocol.Compliancies)

## Remarks

Used from DataMiner 9.0.3 onwards (RN 12958, RN 13008, RN 13202). Indicates whether the driver is compatible with a Cassandra database.

Contains:

**true**

The protocol is compatible with a Cassandra database. This means for example that all database calls in the protocol's QActions can be executed against every type of general database currently supported by DataMiner, i.e. MySQL and Cassandra. Prior to DataMiner 10.3.0, MSSQL is also supported.

> [!NOTE]
> A protocol that does not perform any local database queries will always be considered “Cassandra ready”. A protocol containing purely WMI queries will also be considered “Cassandra ready”.

**false**

The protocol is not compatible with a Cassandra database. This means for example that some database calls in the protocol's QActions cannot be executed against a local database of type “Cassandra”.

> [!IMPORTANT]
> If a DataMiner Agent detects running elements that use protocols that are not “Cassandra-ready”, migrating to Cassandra will be impossible. A DMA that is already using Cassandra will refuse to use any protocol that is not “Cassandra ready”.

> [!NOTE]
>
> The following will result in a protocol that is not compatible with a Cassandra database:
>
> - Performing SQL queries to a DMA database in QActions.
> - Using the displayColumn attribute in tables.
> - Presence of logger tables that make use of the autoincrement column type (see autoincrement).
