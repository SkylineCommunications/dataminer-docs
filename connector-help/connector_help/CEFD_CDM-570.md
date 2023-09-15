---
uid: Connector_help_CEFD_CDM-570
---

# CEFD CDM-570

The CDM-570 Satellite Modem is the 70/140 MHz IF version, intended for closed network applications. This modem is essentially identical to CDM-570L, apart from the operating frequency band.

## About

The connector polls data from the device using SNMP protocol.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### Main View

This Page displays the basic information related to the **Transmitter** and the **Receiver**. In the **Normalized Value** sub page it is possible to set the **Normalize Rx EbNo** parameter.

### General

In the General Page the user can find information about the device, like the **Serial Number**, **System Uptime**, **Temperature**, **IP Address** etc. There are subpages that give information about the **Admin Configuration** and **IP Configuration**.

### Traffic

In this Page display the **Interfaces** Table and parameters about the **WAN Traffic**.

### Transmitter

The Transmitter Page displays information about the Transmitter status like the **TX Frequency, TX Satellite Frequency**, **Modulation**, **TX Power Level**.

### Receiver

The Receiver Page displays information about the Receiver status like the **RX Frequency**, **RX Satellite Frequency**, **Demodulation**, **RX Signal Level**.

In the **LNB Configuration** sub page it is possible consult the information about the LNB (low-noise block).

### BUC

This Page displays data about the BUC (Block upconverter), like the **BUC Power**, **BUC Current**, **BUC Voltage**.

### Stats - Modem Logs

In this Page it is possible to check information about the Events in the **Stored Events Table**.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
