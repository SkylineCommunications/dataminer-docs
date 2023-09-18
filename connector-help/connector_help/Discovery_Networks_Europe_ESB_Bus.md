---
uid: Connector_help_Discovery_Networks_Europe_ESB_Bus
---

# Discovery Networks Europe ESB Bus

This connector can retrieve traps from the ESB Bus device, parse them into a table, and display this information in DataMiner.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) to retrieve traps. It does not use any SNMP polling. It requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP or URL of the ESB Bus.
- **IP port**: The IP port of the ESB Bus.

## How to use

The General page displays all the information collected by the connector. You can find this information in the **KPI Table**. This table results from the parsing of the received traps. Each row contains information regarding a specific KPI, such as **Application Name**, **Module Name,** **Application Criticity**, **Value**, **Importance**, **Broadcast Type** and **Status**.
