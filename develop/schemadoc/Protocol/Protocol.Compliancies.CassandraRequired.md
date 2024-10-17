---
uid: Protocol.Compliancies.CassandraRequired
---

# CassandraRequired element

<!-- RN 12958, RN 13008, RN 13202 -->

Specifies whether a Cassandra database is required to execute the protocol.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Compliancies](xref:Protocol.Compliancies)

## Remarks

Contains:

- **true** if the protocol will only function on a DataMiner Agent that uses a Cassandra database.

- **false** if the protocol will also function on a DataMiner Agent that does not use a Cassandra database.

> [!NOTE]
> If a protocol has *CassandraRequired* set to true, you will not be able to add this protocol on a DMS that does not use a Cassandra database for general DataMiner storage. If you attempt to do so, an error message will be shown.<!-- RN 14427, RN 14464 -->
