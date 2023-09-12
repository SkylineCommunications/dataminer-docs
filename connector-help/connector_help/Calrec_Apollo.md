---
uid: Connector_help_Calrec_Apollo
---

# Calrec Apollo

With this connector, you can receive and process traps sent from the Calrec configuration server.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the Calrec configuration server.
- **Device address**: The IP address of the corresponding network element. This IP will be used to filter the traps.

## Usage

### General

This page displays the **Traps Table**. When a trap is received and correctly processed, the corresponding value will be introduced in this table.

Depending on the parameter, alarm monitoring is possible on the values in this table.

Note: You can remove selected rows or remove all rows in the table. Right-click the table and select the appropriate option.
