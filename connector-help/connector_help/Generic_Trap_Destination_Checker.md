---
uid: Connector_help_Generic_Trap_Destination_Checker
---

# Generic Trap Destination Checker

This is an SNMP connector that will process all traps received on a DMA, checking whether they were received from a known IP address or not.

## About

When a trap is received, the connector will check if it came from an IP address that corresponds to an existing element. If this is the case, the corresponding entry in the **Element Table** will be updated with the current date. Otherwise, an entry will be added to the **Unprocessed Trap Table**, indicating that a trap was received and discarded.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses an SNMP connection, but does not require any specific input during element creation.

SNMP CONNECTION:

- **IP address/host**: Any IP will work; this value will not be used.
- **Device address**: Not applicable.

SNMP Settings:

- **Port number**: Any port number will work; this value will not be used
- **Get community string**: Not applicable.
- **Set community string**: Not applicable.

## Usage

### General Page

This page displays the following parameters:

- **Update Element**: This button will force a refresh of the **Element Table**
- **Update Element Table Interval**: Allows you to configure the Element Table **refresh interval**.
- **Element Table**: This table will contain a row for each element on the current DMA. When a trap from a particular element is received, the column **Last Received Trap Date** will be updated to the current time.
- **Unprocessed Trap Table**: This table will contain all traps that were received from an unknown IP address. The functionality of this table is similar to that of the **Element Table**.
