---
uid: Connector_help_Audemat_Aztec_Goldeneagle_FM
---

# Audemat Aztec Goldeneagle FM

With this connector, information can be gathered and viewed from the device **Audemat Aztec Goldeneagle FM**. The connector also allows you to configure the device to an extent.

## About

This connector is used to gather information from the **Audemat Aztec Goldeneagle FM** device.

### Version Info

| **Range** | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                           | No                  | No                      |
| 2.0.0.x          | New firmware                              | No                  | Yes                     |
| 2.1.0.x          | Added support for device firmware 10.9.0. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 8.5                         |
| 2.0.0.x          | 10.8                        |
| 2.1.0.x          | 10.9.0                      |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage (1.x.x.x)

### General Page

This page displays general parameters of the **Audemat Aztec Goldeneagle FM** device, such as the **Device Name**, **Software Version**, **Device Serial Number** and **Device Status**.

This page also contains the page buttons **Trap Config**, **Email Config**, **Events Config**, **Modules**, **Hardware Version**, **Software Version**, and **Webcam.**

The page also contains buttons to **Initialize** and **Reset Device**.

### Channels Configuration

This page displays a table with all available channels and their configuration.

It also contains the page buttons **Pilot Monitoring**, **AF Monitoring**, **RF Monitoring**, **Transmission Alarm**, **White Noise Monitoring**, **Extended RDS Monitoring**, **RDS Monitoring**, **MPX Monitoring** and **Channel ID Watch.**

### Measurement

This page displays a table with all the measurements for the channels.

### Commands

This page contains parameters that can be used to send commands to the device, for example to erase a video or audio file, or to perform a manual scan.

It also contains the page button **Channels Auto Configuration** and the buttons **RDS Sync**, **Take Snapshot** and **Get In/Out Status**.

### Scanning

This page allows you to set the scanning configuration.

### Recording

This page allows you to set the recording configuration.

It also contains the page button **Recordings**, which displays the existing audio recordings.

### Audio Tag

This page allows you to set the audio tag configuration.

It also contains the page button **Tag Configurations**, which displays the existing tag configurations.

### Web Interface

This page shows the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (2.x.x.x)

### General Page

This page displays general parameters of the **Audemat Aztec Goldeneagle FM** device, such as the **System Name**, **Software Version**, **CPU Temperature** and **Serial Number**.

The page also displays the **Channels** table, which displays all configured FM channels.

It also contains the following page buttons:

- **SNMP Configuration**: Allows you to configure the SNMP parameters, such as the **SNMP Manager Address**, **Trap Version** and **Local Agent Port**.
- **Email Configuration**: Allows you to configure the **Email Address** of the main recipient and two copy recipients.

### Carriers

This page shows a tree view with all available channels and their measured values.

The page also contains a page button that displays the raw data used to build the tree view.

### Alarms

This page shows a tree view with all available channels and their alarm values.

The page also contains a page button that displays the raw data used to build the tree view.

### Tuner

This page shows the current **Tuner Status**. It also allows you to **Start** and **Stop Streams**.

### Web Interface

This page shows the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
