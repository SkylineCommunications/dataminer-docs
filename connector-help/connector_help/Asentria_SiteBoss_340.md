---
uid: Connector_help_Asentria_SiteBoss_340
---

# Asentria SiteBoss 340

The **SiteBoss 340** is a small site controller. It is a versatile and powerful system used for monitoring and control of equipment sites via SNMP.

- Monitoring of serial and environmental event conditions.
- Monitoring of connected sensor devices (contact inputs, voltage inputs, relay outputs, temperature sensor).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.11.620               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The port of the connection device, by default *161.*

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

On the **General** page, you can find general device statuses and settings such as the System Name, System Location, System Services. Via a page button, you can open a subpage showing the **Event Sensors** table.

For each of the different sensor types (Temperature, Contact Closures, Humidity, Noise, Analog Inputs and Relay), the connector has a page with detailed information. In addition, the **AC Power Monitoring** page contains a table with AC power status information.
