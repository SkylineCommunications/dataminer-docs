---
uid: Connector_help_Newtec_AZ720
---

# Newtec AZ720

The AZ720 is a high-performance L-band to IF frequency downconverter designed for a wide range of broadcast, telco, and IP satellite applications. Its main features are high gain, spectrum inversion, very high-frequency stability, and LNB power supply to guarantee the best signal quality.

This driver is designed to work with the model AZ720. It allows you to monitor and control the downconverter.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.40                   |

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

## How to use

The element created with this driver has the following data pages:

- **Architecture**: Contains general information about the unit. Several page buttons are available that provide access to specific settings: SNMP, Serial Port, Ethernet, Display Settings, and Configuration.
- **Setup**: Allows you to monitor and control the unit, and to add web users as well. In the Monitor section, you can find parameters related to the Power Supply and the Device Internal Temperature. The Control section contains the Device Reset, Sleep Mode, 10 MHz Reference and Reference Clock parameters.
- **Downconverter**: Contains the following settings: Outdoor Power Control. Receive Frequency, Receive Gain, Centre IF Output, Output Bandwidth, Rx Spectrum Inversion, IF Output Level, Output Level Clipping, and IF Output (can be enabled/disabled). Also allows you to monitor the Outdoor Current and the Frequency Conversion formula.
- **Alarm**: Contains the Converter Alarms Table and the General Alarms Table.
