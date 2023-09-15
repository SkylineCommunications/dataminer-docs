---
uid: Connector_help_GeoSync_Microwave_TRR-Ku2
---

# GeoSync Microwave TRR-Ku2

These Test Translators are designed for applications where frequency translation is needed with a minimum of amplitude and group delay distortion. A level control of 30 dB is provided at the front panel in "local mode" or on the remote bus in "remote mode".

## About

The **GeoSync Microwave TRR-Ku2** connector controls and monitors the bands and attenuation of the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.01                        |

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

The **Band, Output State, Attenuation, Reference Frequency Adjustment,** and **Title** can all be configured as well.

Information for the **LO Frequency, High Input and Output Frequency Ranges** as well as the **Reference Frequency Source** is also found on this page.

### System Info

Generic system information such as the **System Name, Temperature, 12V Power Supply,** and **Elapsed Time** are on this page.

The **User Generated Test,** **Local Oscillator, Power Supply,** and **Temperature** **Alarms** are displayed on this page. The user can test alarms using the **User Test Alarm** buttons.

### Log

The **Log Events** table is displayed on this page. The number of **Log Entries** is displayed at the top.

The entries can be cleared using the **Clear** button.

### Network

The **IP Address, Subnet Mask** and **Gateway** can be configured and applied on this page.

The SNMP **Read** and **Write Communities** are configurable, as well as the **Trap Interval** and **Destination**.

### Web Interface Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
