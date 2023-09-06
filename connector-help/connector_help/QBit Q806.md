---
uid: Connector_help_QBit_Q806
---

# Qbit Q806

This is an SNMP driver for the **Qbit Q806 redundancy switch**.It can be used to display and configure information of this device.

## About

### Version Info

| **Range**            | **Key Features**                                        | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Important parameters can be retrieved and set via SNMP. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

## How to Use

The element created with this driver consists of the following data pages:

- **General**: Contains general information about the hardware and software of the device. Via the **Firmware Update** page button, you can access a subpage where you can update the device firmware.
- **Digital Inputs** and **Analog Inputs**: These pages contain information about the signals at the inputs of the device. The layout of these pages and tables is based on the web interface of the device. All tables have a fixed number of rows and fixed primary and display keys.
- **Alarms**: Displays the status of the digital and analog switching criteria, as well as the network status and the currently selected MPX source.
- **Redundancy Alarm Criteria**: Allows you to set the operation mode of the device, and to enable or disable the different switching criteria for digital and analog signals.
- **Redundancy Detection**: Allows you to configure the detection parameters for Level, Pilot, RDS Carrier and AES3 Lock.
- **AUX Outputs**: Allows you to manually set the outputs.
- **Network**: Allows you to view and configure network parameters.
