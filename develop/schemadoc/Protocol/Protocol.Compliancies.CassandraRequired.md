---
metadata_version: 1
uid: Protocol.Compliancies.CassandraRequired
description: "Reference the DataMiner connector protocol schema entry for CassandraRequired element, including its documented structure, attributes, values, and constra."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
