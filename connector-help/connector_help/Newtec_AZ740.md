---
uid: Connector_help_Newtec_AZ740
---

# Newtec AZ740

The AZ740 is a high-performance frequency upconverter designed for a wide range of broadcast, telco and IP satellite applications. The AZ740 converts a standard L-band (950-1750 Mhz) signal to a wide range of RF frequencies such as C-band, Ku-band or DBS-band. The AZ740 guarantees the best signal quality thanks to a very high frequency stability and very low spurious characteristics.

## About

This is an SNMP connector to monitor and configure the **Newtec AZ740** device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | v1.65                       |

## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.220.224.16*.

SNMP settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General

This page displays general information about the device, such as the **Device Serial Number**, **SNMP Version**, **Software Version** and **System Time**.

The page also contains the following page buttons:

- **SNMP**: Allows you to configure the SNMP settings.
- **Ethernet**: Allows you to configure the Ethernet settings.
- **Display**: Allows you to configure the display settings.
- **Power Supply**: Displays the Power Supply Status.

### Combiner

This page displays the combiner parameters of the device, such as **Internal L-Band Input**, **RF Transmit** and **RF Centre Frequency Gain**.

### Alarm Status

This page displays a table with the alarms present on the device.

You can both monitor and configure these alarms.

### Control

This page allows you to configure the device, with settings such as **Device Sleep Mode**, **Reference Clock Selection**, **10 MHz Reference Calibration Control**, etc.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
