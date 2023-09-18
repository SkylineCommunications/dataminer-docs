---
uid: Connector_help_Hirschmann_-_a_Belden_Brand_MAR_1040
---

# Hirschmann - a Belden Brand MAR 1040

The MAR 1040 is an Industrial Ethernet Ruggedized Switch. It allows you to set up switched industrial Ethernet networks that conform to the IEEE 802.3 standard using copper wires or optical fibers.

This connector allows you to monitor and configure data related to the device.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | L3P-09.1.00            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMPv3 Settings:

- **Username**: The SNMPv3 username.
- **Security level**: The SNMPv3 security level.
- **Authentication type**: The SNMPv3 authentication type.
- **Authentication password**: The SNMPv3 authentication password (default: *public*).
- **Privacy type**: The SNMPv3 privacy type.
- **Privacy password**: The SNMPv3 privacy password (default: *private*).

## How to Use

### General

The General page contains basic system and contact information.

### System

The System page shows status parameters of system components, such as the CPU, Memory, Temperature, PSU, and Fans.

### Network

The network section consists of multiple pages with network information tables.

### PTP

The PTP section contains three categories: PTP, PTPv2, and PTPv2 TC, each with the basic PTP parameters and a ports table.
