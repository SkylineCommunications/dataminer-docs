---
uid: Connector_help_GeoSync_Microwave_TLE
---

# GeoSync Microwave TLE

This series of Outdoor Block Upconverters provides one RF composite output covering 2 satellite transponder frequencies and accepts 2 separate & independent Lband IF inputs in an integral, self-contained weather proof package designed for outdoor antenna mounting.

## About

The **GeoSync Microwave TLE** connector controls and monitors the slope and attenuation of the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.01                        |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

The **Model, Serial Number, Firmware Revision,** and **Remote Mode** are displayed at the top of the page.

The **Output State, IF and RF Attenuation, Slope, Reference Frequency Adjustment,** and **Title** can all be configured.

### System Info

Generic system information such as the **System Name, Temperature, 12V Power Supply,** and **Elapsed Time** are on this page.

The **User Generated Test**, **Logged Fault**, **Local Oscillator, External, Auxiliary External, Power Supply**, and **Temperature Alarms** are displayed on this page. The user can test alarms using the **User Test Alarm** buttons.

### Log

The **Log Events** table is displayed on this page. The number of **Log Entries** is displayed at the top.

The entries can be cleared using the **Clear** button.

### Network

The **IP Address, Subnet Mask** and **Gateway** can be configured and applied on this page.

The SNMP **Read** and **Write Communities** are configurable, as well as the **Trap Interval** and **Destination**.

### Web Interface Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
