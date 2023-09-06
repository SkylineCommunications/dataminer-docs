---
uid: Connector_help_Courtyard_CY460
---

# Courtyard CY460

The Courtyard CY460 is a **Universal SPG (Sync Pulse Generator)** designed according to the needs of broadcast serial digital, mixed analog/digital, post-production, OB and other operational environments.

## About

The **Courtyard CY460** driver is used to monitor the device of the same name.
This driver uses an SNMPv1 interface to communicate with a **Courtyard CY460** device.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read values from the device. The default value is *public*.
- **Set community string**: The community string required to set values on the device. The default value is *public*.

## Usage

### General Page

This page displays generic **system information**.

### SPG Status Page

This page displays the **Sync Pulse Generator status parameters**, such as the reference signal status and the device functional mode (Master or Slave).

### Power Supply Page

This page monitors the **power supply state**, by monitoring parameters such as the voltage regulator temperatures or fan speeds.

### Audio Channel Page

This page displays the **sync state** of the different **audio channels**.
