---
uid: Connector_help_Generic_Trap_Processor
---

# Generic Trap Processor

This driver will receive traps on a DMA. It allows you to specify rules that received traps need to match. Traps matching these rules will be logged with information that is generated based on the rule and trap data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device. For this driver, typically 127.0.0.1 is specified.

## How to Use

The element created with this driver has the following data pages:

- **General**: Contains 3 tables:

- **Rules table**: Allows you to add matching rules for received traps. A rule contains two OIDs, Alarm and Clear, and also contains binding filters. This is used to determine if a trap matches the rule. You can define the formats for Unique Entry, Alarm and Clear in this table. These formats contain placeholders that will be replaced with the data from the received trap.
  - **Source Name Table**: Allows you to specify rules for the name generation based on the trap information.
  - **Source IP Name Table**: Allows you to map IP addresses to names. The element will only log traps if the source IP is included in this table.

- **Import Operations**: Allows you to import the rule tables from CSV files. In these files, a semicolon (";") should be used as separator. Importing allows you to easily share and reuse rules.

- **Processed Message**: Contains a table listing the processed messages. Each entry has a matching rule. The information in the entry is based on the received trap and formatted based on the matching rules.

- **Received Traps**: Displays the Received Traps table, which contains an entry per received trap OID for which no match was found with the current rules. This can help you to determine if a new rule needs to be added.
