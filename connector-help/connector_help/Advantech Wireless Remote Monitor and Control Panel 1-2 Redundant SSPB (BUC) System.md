---
uid: Connector_help_Advantech_Wireless_Remote_Monitor_and_Control_Panel_1-2_Redundant_SSPB_(BUC)_System
---

# Advantech Wireless Remote Monitor and Control Panel 1-2 Redundant SSPB (BUC) System

This Monitor and Control Panel is used for redundant high-power units, monitoring the status of two SSPB units in a redundant system and three amplifiers in a 1-to-2 redundant phase-combined configuration, and providing control to the RF units.

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

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This connector uses SNMP parameters and tables to retrieve data from the device.
