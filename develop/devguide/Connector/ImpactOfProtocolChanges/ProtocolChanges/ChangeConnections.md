---
uid: ChangeConnections
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
