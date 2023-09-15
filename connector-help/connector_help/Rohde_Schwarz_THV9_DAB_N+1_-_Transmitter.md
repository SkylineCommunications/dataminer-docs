---
uid: Connector_help_Rohde_Schwarz_THV9_DAB_N+1_-_Transmitter
---

# Rohde Schwarz THV9 DAB N+1 - Transmitter

The R&S THV9 transmitter is used for multiplexed Digital Audio Broadcasting in a Single Frequency Network (SFN). It consists of a source switch system, 2 transmitters, a group of amplifiers, a transmitter controller unit (TCU), and an antenna system.

## About

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

#### SNMP CONNECTION

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.
