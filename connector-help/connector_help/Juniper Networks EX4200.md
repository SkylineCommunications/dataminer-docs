---
uid: Connector_help_Juniper_Networks_EX4200
---

# Juniper Networks EX4200

This SNMP-based driver allows you to monitor and configure the Juniper Networks EX4200. The device settings can be monitored and changed using the TVG450 driver.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | JUNOS 15.1X53-D63.9    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. 10.11.12.13.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the following data pages:

- **Operating State**: Displays general device status information.
- **Memory**: Contains information about the memory size, buffer, etc.
- **Temperature**: Contains information regarding temperatures.
- **CPU**: Contains information about CPU usage.
- **CPU ISR**: Contains information about CPU ISR usage.
- **Fan**: Contains information about the fan operating state.
- **Power Supply**: Contains information about the power supply operating state.
- **IPv4**: Displays a table with information regarding IPv4 addresses.
- **Virtual Chassis**: Displays a table with information regarding the virtual chassis.
- **Chassis**: Contains chassis-related information.
- **Configuration**: Contains tables with device configuration information.
- **Interfaces**: Contains tables with information about the interfaces.
- **Alarms**: Contains alarm status information.
- **System Info**: Contains general information about the system, such as the System Name, System Uptime, etc.
- **IP Parameters**: Contains information about IP forwarding.
- **IP Table**: Contains tables with information about IP routes and IP addresses.
