---
uid: Connector_help_Vertiv_Watchdog_100-PNPS
---

# Vertiv Watchdog 100-PNPS

The Vertiv Watchdog 100-PNPS is a self-contained environmental monitor with onboard temperature and humidity/dewpoint sensors. It has two digital RJ12 sensor ports, four I/O ports to connect analog external sensors, and an output of one NO/NC relay contact to trigger external devices like an auto-dialer.

## About

### Version Info

| **Range**            | **Key Features**                                                                              | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Monitoring support for temperature, air flow, dewpoint, CCAT, T3HD, THD, RPM and A2D sensors. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.4.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
- **IP port**: The IP port of the device, e.g. *161*.
- **Bus address**: The bus address of the device.

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

At the top of the Visual Overview page for this connector, information about the internal sensors is displayed. Below this, you can find information about the external sensors connected to the unit. Select a sensor to view detailed information.

Under Data, the following pages are available:

- **General**: Contains general information about the device, such as the system name, location, contact, version, etc. Via a page button, you can change the **units** used for temperature values (§C/§F).
- **Internal Sensors**: Displays the current internal sensor values, including temperature, dew points, humidity, and analog data.
- **External sensors**: Contains a tree view that displays external sensor values for each selected sensor. The page button at the bottom of the page displays the tables this tree view is based on.

## Notes

This connector is intended to be used with a custom Visio file.
