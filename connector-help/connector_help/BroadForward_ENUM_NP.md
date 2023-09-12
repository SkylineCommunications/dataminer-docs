---
uid: Connector_help_BroadForward_ENUM_NP
---

# BroadForward ENUM NP

The **BroadForward Number Portability** software solution (NP) provides a unified access point for number portability. It enables centralized operations for streamlined lookup access to number and address registries.

The **BroadForward ENUM NP** connector uses an SNMP connection in order to receive SNMP traps. These traps help indicate the state of the cluster, nodes, processes, and queues.

## About

| **Range**            | **Key Features**          | **Based on** | **System Impact** |
|----------------------|---------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Processing of SNMP traps. | \-           | \-                |

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

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

On the **General** page, the **Status Table** displays all the status traps sent by the BroadForward ENUM NP.

The number of traps in the table and the maximum duration that they can stay in the table must be configured on the **Auto Clear** subpage. By default, the maximum number of traps is set to 200, and the duration is set to 30 days.
