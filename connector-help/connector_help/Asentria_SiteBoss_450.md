---
uid: Connector_help_Asentria_SiteBoss_450
---

# Asentria SiteBoss 450

The **SiteBoss 450** is a controller specifically designed to integrate closely with external sensing devices for the purpose of monitoring these variables.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.10.390               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

For each of the different sensor types (Temperature, Contact Closures, Humidity, Noise, Analog Inputs and Relay), the driver has a page with detailed information. In addition, the **AC Power Monitoring** page contains a table with AC power status information.
