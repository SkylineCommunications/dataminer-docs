---
uid: Connector_help_EVE_Compliancy_Solutions
---

# EVE Compliancy Solutions

This driver implements a trap receiver for the EVE Compliancy Solutions device.

## About

EVE Compliancy Solution consists of a number of building blocks, each designed with a special network function in mind. A large number of EVE components can be used to passively intercept the production network. This offers a higher level of security and a lower impact on the production network.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unkown                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

> **IP address/host**: \[The polling IP or URL of the destination.\] **IP port**: \[The IP port of the destination.\]

SNMP Settings:

> **Get community string**: \[The community string used when reading values from the device. (default: *public*)\] **Set community string**: \[The community string used when setting values on the device. (default: *private*)\]



## How to Use

### General

This page shows the device status parameters like **Status**, **Status Message** and **Platform Identifier**. It also displays the **Trap Reception Status** and the **Last Trap Time**. In the Configuration sub page it is possible to set the **Trap Reception Time** and the **Max Number of Traps** in the Trap Table.

### Traps

Displays a table with the latest received traps.

### Active Trap

Displays a table with last trap received.


