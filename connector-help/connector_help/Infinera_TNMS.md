---
uid: Connector_help_Infinera_TNMS
---

# Infinera TNMS

The Infinera TNMS is a Transcend Network Management System (NMS) that can provide full end-to-end network and service management. This connector allows you to monitor all the network elements (NE), ports and corresponding alarms.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.3                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                            |
|-----------|---------------------|-------------------------|-----------------------|--------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Infinera TNMS - NE](xref:Connector_help_Infinera_TNMS_-_NE) |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP address of the device.
- **IP port**: The port of the connected device, by default *161*.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device. The default value is *public*
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This element has several data pages:

- The **General** page displays the time when the last "keep alive" was received.
- The **DVE Control** page contains a table listing all the available **Network Elements** and the corresponding **DVEs**. Each table row matches a DVE and displays its ID, Name (the table's display key), Use Status, Detection Status, View Name and Overall Severity. In each row, you can also do a manual action to **remove** the DVE. The **DVE Config** button provides access to two extra removal options: **DVE Automatic Removal** and **Remove All**.
- The **NE** page contains the NE table.
- The **Ports** page contains the Ports table.
- The **Alarms** page shows an overview of the active alarms.

**SNMP traps** are implemented in the connector to update the **Alarms table**.
