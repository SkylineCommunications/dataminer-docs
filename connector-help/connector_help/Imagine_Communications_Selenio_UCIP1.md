---
uid: Connector_help_Imagine_Communications_Selenio_UCIP1
---

# Imagine Communications Selenio UCIP1

The **Imagine Communications Selenio UCIP1** is a multichannel SDI-to-IP encapsulator and IP-to-SDI de-encapsulator. This connector allows you to monitor the transmitters and receivers in the module.

## About

The current version of the connector uses **SNMPv2** to communicate with the device, while previous versions used SNMPv1.

There are two versions of this device. The classic SEL-UCIP1 has eight HD/SD-SDI interfaces, configurable to a maximum of six inputs and/or four outputs, not totaling more than eight I/Os. The AES67 version has four inputs and four outputs.

The **versioning** for the connector is specifically engineered to tie in with the firmware version of the card the connector supports. It uses the following format: *X.X.X.Y*, with X.X.X being the firmware version of the card, and Y the specific connector iteration for this firmware. For example, 5.0.28.2 means that the connector is the second iteration for firmware 5.0.28*.*

### Version Info

| **Range**            | **Description**                                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|-----------------------------|-----------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.1.0.x                     | Version number tied in with firmware 1.1                                                                                          | Yes                 | No                      |
| \<10.0.0.x **\[SLC Main\]** | The **versioning** for the connector is specifically engineered to tie in with the firmware version of the card the connector supports. | No                  | Yes                     |
| 10.0.0.x                    | Replaced "dynamic snmp get" with "dynamicSnmpGet="true"" under parameter type tag.                                                | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                       |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------|
| 1.1.0.x          | 1.1. Also tested on version 2.0                                                                                                   |
| \<10.0.0.x       | The **versioning** for the connector is specifically engineered to tie in with the firmware version of the card the connector supports. |
| 10.0.0.x         | Requires controller firmware "S/W=7.0-38, H/W= rev 02" or higher and will not work with older firmware.                           |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address (range: *14 - 1*).

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *public*.

## Usage

### General

This page contains general information on the device, such as **Slot,** **Card Type, Version, Serial Number, Chassis IP, Custom Chassis Name, Slot State, Slot Temperature, Slot Protection** and **Slot Protection Status.**

### Alarming

The page contains a table listing the current active alarms (with the **Alarm Name**, **State** and **Data**).

Below the table, you can change the polling speed to 30 seconds or 3 seconds.

### Module

This page allows you to define the **Module Name**, the **CTR SDI Out Select**, **Fault Alarm Priority**, **IO Configuration** and **Frame Reference**. It also displays the **Reference Standard.**

### Module Status

This page displays information on the module status and versions, such as **CTR SDI Status**, **Software Version**, **ROM Version** and **FPGA Version.**

### IP WAN General

This page displays information on the **TX Packets, RX packets, Payload TX Rate** and **RX Rate** for the **primary** and **secondary** transmitters. It also displays the **Mac Address** of the transmitters.

There is also a subpage with a table that allows you to configure both the primary and secondary **IP Address**, **Subnet Mask** and **Gateway**.

### IP WAN Status

This page contains statistics on the **Received Packets**, **Errored Packets** and **Discarded Packets**. There is also a button available to clear those values.

### SFP Status

On this page, you can check both the primary and secondary **Transmitting Signal**, **Received Power** and **SFP Attributes**. For both, the **Transmit State** can also be set.

### Transmitter General

On this page, you can define the **Transmitter Interface** and check the **Total Allocated BW**.

There is also a table listing the **SDI sources**, where you can configure the **Transmitter Tag**, **Max Rate**, **Destination IP and UDP** and if necessary the **Secondary IP and UDP** for each source.

### Receiver General

This page allows you to configure the **Packet Delay Variation**, **Max Path Differential** and **Playout Delay** for the **receiver**.

There is also a table listing the receivers, where you can configure the **Status, Wan, Output Source Debug and Audio Groups for each receiver**. The table also displays general information, such as the **Primary IP and VLAN**, **Secondary IP** and **Switch Status**.

### Selenio-Controller

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

Available in range 1.1.0.x.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic interfaces

- **Sources**: Reports the available interfaces **in** for the encoder or decoder.
- **Destination**: Reports the available interfaces **out** for the encoder or decoder.
