---
uid: Connector_help_Rohde_Schwarz_THV9_DAB_N+1
---

# Rohde Schwarz THV9 DAB N+1

The R&S THV9 transmitter is used for multiplexed Digital Audio Broadcasting in a Single Frequency Network (SFN). It consists of a source switch system, 2 transmitters, a group of amplifiers, a transmitter controller unit (TCU) and an antenna system.

This SNMP connector can be used to monitor and configure the Rohde Schwarz THV9 DAB N+1 transmitter.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | **THV9 DAB N+1 - Transmitter**: In range 1.0.0.x, there are two transmitters. For each transmitter, a DVE is exported. |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private.*

## How to use

This connector retrieves the information available in the element through SNMP communication.

When the element has started up, the parameters will be filled in. When the **Transmitter B Fault** is retrieved, entries will be added to the **DVE Transmitters** table based on the **Tx Transmitter Commands** table. For each transmitter available, one DVE element will be created.
