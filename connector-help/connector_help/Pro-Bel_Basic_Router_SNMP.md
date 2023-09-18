---
uid: Connector_help_Pro-Bel_Basic_Router_SNMP
---

# Pro-Bel Basic Router SNMP

This connector is used to monitor and control a **Pro-Bel router** device.

## About

This connector is used to monitor and control matrix devices from the vendor Pro-Bel. The maximum supported size is 256 inputs and 256 outputs, but the size is automatically adjusted according to the device dimensions.

The SNMP protocol is used to retrieve information from the device.

### Version Info

| **Range** | **Description**                                        | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                        | No                  | Yes                     |
| 1.1.0.x          | Name changed to Basic Router (old name: Sirius Router) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.0.x          | SNMP agent ver 3.04         |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values on the device, by default *private.*

## Usage

### Matrix

This page displays the matrix control.

### Matrix Settings

On this page, you can change all outputs that use input A to input B, in one bulk operation.

### General

This page contains general information about the device.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
