---
uid: Connector_help_GeoSync_Microwave_UPC
---

# GeoSync Microwave UPC

The GeoSync Microwave UPC (Uplink Power Control) System provides control of the uplink RF power, with up to 3 attenuator modules, each capable of 20 dB of uplink power correction. The UPC is designed to adjust the uplink signal strength to minimize weather-induced variations in signal strength received by geostationary satellites. The received signals can be from a telemetry beacon or a carrier transmitted from the RF terminal and looped back into the satellite.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.04                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - SNMP Connection

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

The following data pages are available:

- **General**: Displays general information such as the model and serial number, the firmware revision, etc.
- **System**: Displays system information of the device, such as the date/time and alarms of the device. You can also change the algorithm, date/time, sample time, and idle time of the device.
- **Channel**: Provides channel monitoring and controls.
- **Receiver**: Provides receiver monitoring and controls
- **Receiver Calibration**: Provides receiver calibration controls.
- **Log**: Displays the **Log Events** table, with the total number of log entries displayed at the top. You can clear the entries in the table with the **Clear** button.
- **Communications**: Allows you to configure the IP address, subnet mask, gateway, and settings related to serial communication.
