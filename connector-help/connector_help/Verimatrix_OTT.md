---
uid: Connector_help_Verimatrix_OTT
---

# Verimatrix OTT

The **Verimatrix OTT** is a video monitor.

## About

This connector uses **SNMP** to monitor the **Verimatrix OTT** device.

### Version Info

| **Range** | **Description**                                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                          | No                  | Yes                     |
| 1.1.0.x          | Based on 1.0.0.1. Added support for firmware version 4.1. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 1.1.0.x          | 4.1                         |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays parameters such as the **OTT State**, **OTT Logging Level**, **OTT Server Identification**, etc.

### Server Status

This page displays the current status and port of the servers.

Servers include the **Client Boot Server**, **Client Key Server**, **Client Management Server**, **Scrambler Key Server** and **Harmonic Server**.
