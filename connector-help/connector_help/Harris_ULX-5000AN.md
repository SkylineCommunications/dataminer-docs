---
uid: Connector_help_Harris_ULX-5000AN
---

# Harris ULX-5000AN

The Harris ULX-5000AN is an analog television transmitter. It uses a simplified control system that minimizes the number of microprocessors.

## About

This connector can be used to monitor and configure the Harris ULX-5000AN system.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Initialization

No extra configuration is needed.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created using this connector consists of the data pages detailed below.

### General

This page displays system information, including the **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time** and other general parameters.

### Transmitters

This page is divided in four sections: **System**, **Driver Chain**, **Power** and **Output Configurations**. It displays among others the **Device Name** and **Model Number**, and allows you to monitor the **Transmitter**, **Driver Chain** and **Output Status**, as well as **switch the exciter**.

There is also a page button in the System section, which allows you to enable/disable the traps in the Harris ULX-5000AN.
