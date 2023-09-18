---
uid: Connector_help_Hiltron_HACU
---

# Hiltron HACU

The Hiltron HACU is a complete high-precision motorized satellite antenna control unit. With this connector, you can monitor and configure the Hiltron HACU via an SNMP connection.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                             | **Based on** | **System Impact**                                               |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                                                                                                              | \-           | \-                                                              |
| 1.0.1.x              | Connector review: spelling corrections, discrete updates, etc.                                                                                                                               | \-           | \-                                                              |
| 1.0.2.x \[SLC Main\] | \- Added Power Supply Table and renamed existing table to "Heater Power Supply". - Improved reset functionality (reset alarms is now similar to the web interface) and improved positioning. | \-           | \- Change to parameter name and descriptions. - Layout changes. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

Displays general information.

Via the **Polling Configurations** page button, you can access a subpage with toggle buttons that allow you to enable or disable polling for the main parameter groups of the element. If polling is disabled, the affected parameters will show the N/A state. If you see a parameter that is not polled elsewhere in the element, check this subpage to see if the polling configuration is the cause.

### Position

Displays information about the **Azimuth**, **Elevation** and **Polarization** angles and alarms.

### Tracking

Allows you to enable, disable, configure and monitor the satellite tracking.

### Satellite

Allows you to select a satellite and to direct the antenna to the satellite.

The **Redundancy settings** are available via a page button.

### Beacon Receiver

Displays all parameters and settings regarding the beacon receiver.

### Status

Displays the **Wind** and **Level** tables.

### Heater

Displays different tables with heater statistics.

Via page buttons, you can access the **Power Supply** and **Current** readings.

### Alarms

Displays the main alarms.
