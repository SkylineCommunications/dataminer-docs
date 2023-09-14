---
uid: Connector_help_Cisco_Conductor
---

# Cisco Conductor

This connector is used to monitor the **Cisco Conductor** device.

## About

This connector uses **SNMP** to retrieve basic information from the device (processors, disk storage, etc.).

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host**: The polling IP of the device, e.g. 10.11.12.13.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

This connector contains 4 pages.

### Device

This page displays the **Hr Device Table**, which lists the devices contained by the host.

### Processor

This page displays the **Hr Processor Table**, which lists the processors contained by the host.

### Storage

This page displays the **Hr Storage Table**, which lists the logical storage area on the host.

### TCP

This page displays the **Tcp Conn Table**, which contains information related to the TCP connection.
