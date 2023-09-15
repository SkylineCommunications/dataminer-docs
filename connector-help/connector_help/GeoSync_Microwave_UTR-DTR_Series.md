---
uid: Connector_help_GeoSync_Microwave_UTR-DTR_Series
---

# GeoSync Microwave UTR-DTR Series

This series of converters provides high performance and high reliability. They are available for operations in the S, C, X, Ku, and DBS band and feature low phase noise and excellent dynamic range to carry almost any type of analog or digital communication signal.

The **GeoSync Microwave UTR-DTR Series** connector provides controls for the converter, power, IP configuration, and serial communication. It also allows you to monitor the device and view logging.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.06                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

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

The element consists of the following data pages:

- **General**: Displays general information such as the model and serial number, the firmware revision, etc. You can also configure and monitor the output state, IF and RF attenuation, slope, etc.
- **Control**: Contains converter and power controls.
- **Config**: Allows you to configure the IP address, subnet mask, gateway, and settings related to serial communication.
- **Alarms**: Allows you to monitor parameters related to alarms such as Test, Logged, Temperature, etc. You can also configure **external alarms**, and you can test alarms with the **User Test Alarm** buttons.
- **Log**: Displays the **Log Events** table, with the total number of log entries displayed at the top. You can clear the entries in the table with the **Clear** button.
