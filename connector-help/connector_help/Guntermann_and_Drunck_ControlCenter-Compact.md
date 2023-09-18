---
uid: Connector_help_Guntermann_and_Drunck_ControlCenter-Compact
---

# Guntermann and Drunck ControlCenter-Compact

The **Guntermann & Drunck ControlCenter-Compact** is a KVM Matrix System that can be used to control multiple computers from one or more sets of keyboard, video monitors and mouse (KVM stands for Keyboard, Video and Mouse).

The KVM matrix systems of the ControlCenter-Compact series consist of at least one central module, one user module and one target module. Both target and user modules are connected to the central module.

## About

With this connector, you can monitor status parameters and retrieve information from the device.

The connector polls data from the device using SNMPv2.

### Version Info

| **Range**     | **Description**         | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version         | No                  | Yes                     |
| 1.0.1.x              | New connection (serial) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.001 (00214)             |
| 1.0.1.x          | 1.0.001 (00214)             |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private.*

#### Serial IP-Control-API connection

This connector uses a serial connection and requires the following input during element creation:

Serial connection:

- **IP address/host:** The polling IP of the device.
- **Device address:** By default *5000*.
- **Timeout of a single command (ms):** *15000*

## Usage

### General

This page displays the general system information. This includes the **System Description**, **System Up Time**, **System Contact**, **System Name** and **System Location**.

### Compact

This page contains an overview of all the device information, such as the **Device ID**, **Class**, **Type**, **Serial Number**, **Firmware Version** and **MAC Address A** and **B**.

### Compact Status

This page displays the compact status, including the **Errors**, the status of the **Interfaces**, **Power Supply** and **Temperature**, and the **Fan Speeds**.

On the right-hand side, a table displays the **Port Status** information.

### User Modules

This page contains a single table listing the console modules.

### Target Modules

This page contains a single table listing the CPU modules.

### Web Interface

This page contains the device web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
