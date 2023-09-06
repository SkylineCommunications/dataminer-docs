---
uid: Connector_help_CEFD_LBC-4000A_SNMP
---

# CEFD LBC-4000A SNMP

This connector is based on the obsolete CEFD LBC-4000 connector. It can be used to monitor **CEFD LBC-4000** devices. SNMP is used to retrieve and push information, as well as to receive traps with fault events.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2.2 1.2.5            |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (by default: *public*).
- **Set community string**: The community string used when setting values on the device (by default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **General**: Displays general device information such as the Model Number, Serial Number, Software Revision, etc.
- **Admin - Access**: Contains network information regarding the connection with the device.
- **Admin - SNMP**: Contains information related to SNMP traps, such as the trap IPs and trap version.
- **Config - Conv A/B**: Contains configuration parameters for converter A/B.
- **Config - Ref**: Contains information related to the reference oscillator.
- **Config - Utility**: Allows you to configure general parameters such as the Date, Time and Circuit ID. Also contains firmware information.
- **Config - Redundancy**: Contains redundancy configuration parameters.
- **Config - Serial**: Allows you to configure the settings for the serial connection of the device.
- **Status - Conv A/B**: Contains status information for converter A/B.
- **Status - Faults**: Contains fault events information.
