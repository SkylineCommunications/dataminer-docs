---
uid: Connector_help_Verimatrix_RTES
---

# Verimatrix RTES

The **Verimatrix RTES** is a real-time encryption server. It provides real-time encryption of broadcast data.

Broadcast content is sent from a video server to the RTES using either a unicast or a multicast address. The RTES encrypts the data received on its source port and transmits it to a destination port.

## About

This connector uses **SNMP** to monitor the **Verimatrix RTES** device.

### Version Info

| **Range** | **Description**                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                          | No                  | Yes                     |
| 1.1.0.x          | Based on 1.0.0.1 Added support for firmware version 4.1. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 1.1.0.x          | 4.1                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *192.168.1.31*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays parameters such as the **System Name**, **System Up Time**, **State**, etc.

### Channel Objects

On this page, you can view and configure the channel-related settings, such as **Receive IP Address**, **All Channels Enabled**, etc.

### Local Configuration

On this page, you can find the device local configuration, including the settings **SQL Credentials**, **SNMP** and **Verbose Level**.

### Master Options Configurations

Similar to the Local Configuration page, this page allows you to configure the master options.

### RTES Options Configuration

On this page, you can configure the **RTES RTP Header** and **RTES Packet Size**.

### RTES Server

This page contains a table with all active channels in the device, allowing you to monitor the channels and to enable or disable them.

### Server Objects

This page displays generic device parameters.
