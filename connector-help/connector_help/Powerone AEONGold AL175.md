---
uid: Connector_help_Powerone_AEONGold_AL175
---

# Powerone AEONGold AL175

The Aeon Gold is the central controller unit in a PRS where the AL175 is a control and monitoring unit for safe operation of the DC power system. Simple parameters and tables are retrieved/set through SNMP.

## About

This driver retrieves status and configuration parameters through SNMP. It can among others be used to configure voltages and currents to provide to a DC application.

### Version Info

| **Range**            | **Key Features**       | **Based on** | **System Impact** |
|----------------------|------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Monitoring and control | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the System Parameters page, you can set **Reference Voltages**, **Voltage Limits**, **Voltage Disconnect Limits**, **Partial Load Disconnection Limits**, **Boost Limits**, **Limits for Tests**, **Temperature Limit** and **Shunt Voltage/Current Rating.**

On the Agent Setup page, you can configure the SNMP agent by setting up to 6 **Trap Recipient** IP addresses, specifying the structure of the trap messages with the **Include Text** parameter, and selecting whether traps should be sent when an alarm is cleared (**Trap on Clear**).

The remaining pages are used to monitor the system and the respective alarms.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Powerone AEONGold AL175 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).
