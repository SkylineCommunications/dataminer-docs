---
uid: Connector_help_DAC_System_Data_Logger
---

# DAC System Data Logger

This driver is used to monitor a DAC System Data Logger using SNMP. This is a physical device that collects data from connected junction boxes and sensors, which monitor antenna systems. The driver can retrieve the collected data, allowing the monitoring of the connected junction boxes and sensors.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.4.11                 |

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

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

Note: In order to monitor the Junction Box Hardware Mismatch alarm and the sensor temperature and humidity, **traps** need be configured on the device via its web interface (DataLogger -\> SNMP). These traps must be sent to the DMA (port 162) and the option "Send sensor readings as trap" must be enabled.

## How to Use

### General

The General page contains the Data Logger's **Name**, **Type** and **Site Name**, as well as a **Power Supply Failure Alarm** indicating if there is a problem with the redundant power supplies.

### Junction Boxes

The Junction Boxes page contains an overview of the connected junction boxes. For each junction box, you can view the **Name**, **Type**, **Temperature** and **Humidity**, a **No Response Alarm** and a **Hardware Mismatch Alarm**. The **Last Measurement** indicates the moment when the Data Logger performed the measurement. This timestamp is in GMT.

### Sensors

The Sensors page contains an overview of the connected sensors. For each sensor, a **Name** and a **Type** are displayed. The **Transmitting Signal Power**, **Receiving Signal Power**, **Return Loss**, **VSWR** (Voltage Standing Wave Ratio), **Temperature** and **Humidity** of each sensor are retrieved. Each sensor has sixteen alarms. These are used to indicate any problems concerning the measured **Return Loss**, **Tx Signal**, **Current**, **Temperature** or **Humidity**,or to indicate a general **Malfunction**. The **Last Measurement** indicates the moment when the Data Logger performed the sensor measurement.

### Web Interface

The web interface is only accessible when the client machine has network access to the product. It does not support Internet Explorer.
