---
metadata_version: 1
uid: ChangeConnections
description: "Describe the DataMiner connector development topic Change connection(s), including its purpose, behavior, implementation guidance, and relevant constraint."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
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

# Change connection(s)

Adding or removing one or multiple connections in a protocol is considered a major change.

Changing the type of a connection is also considered a major change, e.g., from SNMP to SNMPv3.

*DIS MCC*

| Full ID | Error message           | Description                                                                                                       |
|---------|-------------------------|-------------------------------------------------------------------------------------------------------------------|
| 1.23.8  | ConnectionsOrderChanged | Order of connections changed from '{oldOrder}' to '{newOrder}'.                                                   |
| 1.23.9  | ConnectionTypeChanged   | {connectionType} Connection '{connectionId}' with name '{connectionName}' was changed into '{newConnectionType}'. |
| 1.23.10 | ConnectionAdded         | {connectionType} Connection '{connectionId}' with name '{connectionName}' was added.                              |

## Impact

- **Element reconfiguration**: Existing elements need to be reconfigured before the new connection(s) will be taken in use.

## Advised method

When an upgrade is done to a new range that has been modified for different connections, element reconfiguration is needed.

Bulk reconfiguration can be performed by means of the [export/import functionality](xref:Importing_and_exporting_elements).
