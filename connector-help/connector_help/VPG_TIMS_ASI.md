---
uid: Connector_help_VPG_TIMS_ASI
---

# VPG TIMS ASI

The main purpose of the VPG TIMS ASI connector is to monitor an ASI monitor and configure its video channels.

## About

This analyser uses a combination of SNMP and HTML to pass the information related to the video streams and all services running on them.

### Version Info

| **Range** | **Description**                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------|---------------------|-------------------------|
| 1.2.0.x          | New MIB implemented on the device | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.0.X          | Software Version: 2.5.1     |
| 1.2.0.x          | Software Version: 3.1.0     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The Channel input to be monitor. (Range: 1 - 16).

SNMP Settings:

- **IP port**: The port of the connected device. (default: 161)
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

#### HTTP Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Bus address**: The Channel input to be monitor. (Range: 1 - 16).

## Usage

### General

This page displays general information concerning the current channel: **Channel Number, Signal Present, Transport Stream Rate**, etc.

### PCR Statistics

This page displays the Statistics of the PCR.

### Alarm Status

On this page, it's possible to find the different alarm status for the current channel: **Loss of Synchronisation, PAT Error, PMT Error, CAT Error**, etc.

### Input Status

This page displays the Status for each device input.

### Channel Configuration

This page displays the **Channel Config** and **IP Decode Config** table

The **Channel Config** table it's possible to find and edit the channel configuration: **Service Name (Channel), Switching Control** and **Alarms.**

The **IP Decode Config** table, it's possible to edit the **Input Mode,** **VLAN**, and **Source/Destination IP Address/Port.**

### Service Info

On this page, there is a **Service Info** table with editable alarm filter. It's possible to remove unused entries by selecting **Remove Missing Services**.

The page also have a button to create new services based on Service Info table that uses **VPG TIMS Service**.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
