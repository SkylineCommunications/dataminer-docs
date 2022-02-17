---
uid: Protocol.Compliancies.CassandraRequired
---

# CassandraRequired element

Specifies whether a Cassandra database is required to execute the protocol.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Compliancies](xref:Protocol.Compliancies)

## Remarks

Used from DataMiner 9.0.3 onwards (RN 12958, RN 13008, RN 13202). Indicates whether the driver requires a Cassandra database.

Contains:

**true**

The protocol will only function on a DataMiner agent that uses a Cassandra database.

**false**

The protocol will also function on a DataMiner agent that does not use a Cassandra database.

> [!NOTE]
> If a protocol has CassandraRequired set to true, you will not be able to add this protocol on a DMS that does not use a Cassandra local database (RN 14427, RN 14464). If you attempt to do so, an error message will appear.
