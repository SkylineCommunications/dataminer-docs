---
uid: Connector_help_Powerware_UPS
---

# Powerware UPS

This connector is intended for the monitoring and management of UPS devices from Powerware, a division of Eaton devices. It displays data related to input and output metrics of the UPS as well as its batteries and correlated alarms.

## About

### Version Info

| **Range**            | **Key Features**             | **Based on** | **System Impact**                                              |
|----------------------|------------------------------|--------------|----------------------------------------------------------------|
| 1.0.1.x \[SLC Main\] | Added Alarm Page and tables. | 1.0.0.5      | Changed display key to naming to make it Cassandra-compatible. |

### Product Info

| **Range** | **Supported Firmware**                          |
|-----------|-------------------------------------------------|
| 1.0.1.x   | Powerware 9100 - 1.30Eaton 9PX 1000 - 1.18.4945 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

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

The element has the following data pages:

- **General**: Contains general information such as Model, Up Time, Software version, Type, and others. Via a page button, you can check environmental information for the device, if available, i.e. the humidity and temperature.
- **Input**: Contains information regarding the inputs of the device, such as Input Frequency, Number of Input Phases, and Nominal Input Voltage. The Input Table lists all the inputs of the UPS.
- **Output**: Contains information regarding the outputs of the device, such as Output Frequency, Number of Output Phases, Nominal Output Voltage, Output Frequency, and Output Power. The Output Table lists all the outputs of the UPS.
- **Battery**: Contains information regarding the battery state of the device, such as Remaining Battery Time, Voltage, Battery Current, Battery Capacity, Battery Status, and Battery Last Replaced date.
- **Alarms**: Contains information regarding the alarms of the device, such as UPS Alarm Table and Number of Present Alarms. Also contains UPS Receptacles information and allows you to shut down, start up and restart those same receptacles.
