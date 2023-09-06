---
uid: Connector_help_Paradise_PD80
---

# Paradise PD80

The **Paradise PD80** is a Digital Video Broadcast (DVB) satellite modem. It is possible to control and monitor the device through an **SNMP** connection.

## About

This driver allows you to configure the **modulation and demodulation** of the device. Interface, SNMP and SMTP configuration are also available in the driver.

The pages of the driver are divided into three sections: General Information, Status Information and Configuration Values.

### Ranges of the driver

| **Driver Range** | **Description**                       | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                       | No                  | Yes                     |
| 1.1.0.x          | Added parameters for the new firmware | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 1.5.50                      |
| 1.1.0.x          | 1.6.59a                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the device: **Manufacturer ID**, **Model Number**, **Serial Number**, **Software** and **Hardware Version**.

### Status Pages

The driver contains the following pages with status information:

- **Status**: Displays Tx and Rx values such as **L-Band Carrier Frequency**, **Terrestrial Bit Rate** and **Symbols Rate**.
- **SAF**: Provides information on software-activated features of the device.
- **Monitor**: Displays the **Power Supply Unit** (PSU) levels.

### Configuration Pages

The driver contains the following configuration pages:

- **Tx and Rx pages**: Allow you to configure some of the **modulation** and **demodulation** information. In the 2.0.0.x driver range, additional pages available: **Tx AUPC**, **PCMA**, **Tx Multistream** and **Rx Multistream**
- **FEC-Mod and BUC LNB**: Forward Error Correction and BUC configuration, available for Tx and Rx.
- **Interface**: Displays the interface configuration of the device.
- **M&C**: Monitor and Control values, including **Remote Connection**, **SNMP** and **SMTP**.
- **Network**: Displays basic network information: **Interfaces**, **IP Address**, **IP Routes** and **IP Net to Media.**
- **Configuration**: Displays the **Alarms** and **Test** configuration.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
