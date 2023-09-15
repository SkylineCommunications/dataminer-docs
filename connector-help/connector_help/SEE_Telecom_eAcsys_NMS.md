---
uid: Connector_help_SEE_Telecom_eAcsys_NMS
---

# SEE Telecom eAcsys NMS

The **SEE Telecom eAcsys NMS** is a management system that manages other elements that are used for Optical/RF transmission/reception. Other than that, it also monitors the state of the network element's chassis and the status of its PSU.

This connector monitors and controls an **SEE Telecom eAcsys NMS** management system, allowing the end user to assess Optical/RF measurements performed by the device, and to perform actions on the devices controlled by the device*.*

## About

This connector uses SNMP and polls the following information every five minutes:

- Device uptime
- Transmission/reception statistics
- PSU and chassis information
- EEPROM information

In addition, the connector polls generic information every 24 hours.

Finally, this connector will export different connectors based on the retrieved data. A list can be found in the section *"*Exported Connectors" below*.*

### Version Info

| **Range** | **Description**                                                                             | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                            | No                  | No                      |
| 2.0.0.x          | Dynamic Virtual elements are created for the modules available in the eACSYS Devices Table. | No                  | No                      |

### Product Info

| **Range** | **Device Firmware Version**            |
|------------------|----------------------------------------|
| 1.0.0.x          | Compatible with eAcsys Release R_0.2.6 |
| 2.0.0.x          | Compatible with eAcsys Release R_0.2.6 |

### Exported connectors

The protocol only supports DVEs for range 2.0.0.x

| **Exported Connector**                      | **Description**                         |
|--------------------------------------------|-----------------------------------------|
| SEE Telecom eAcsys NMS_X_eACSYS Dual RX US | Dual receiver information for device X. |
| SEE Telecom eAcsys NMS_X_eACSYS TX DS      | Transmitter information for device X.   |
| SEE Telecom eAcsys NMS_X_eACSYS PS 48V     | Power supply information for device X.  |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address, ranged between *1* and *16*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

This connector has the following pages: **General**, **Interfaces**, **Module Overview** and **DVE Tables**.

### General

On this page, the section on the left contains the following parameters:

- **Name**
- **Type**
- **Configuration**
- **Serial Number**
- **Operating System**
- **SNMP Agent**
- **eAcsys Release**
- **Software Version**
- **Hardware Version**
- **BIOS Version**
- **Rack Number**
- **Slot Number**

On the right-hand side of the page, the following parameters are displayed:

- **Uptime**
- **Total Uptime**
- **Number of restarts**
- **Temperature**

In addition, a **Reboot Device** button is available that can be used to reboot the device.

### Interfaces

On the left-hand side of this page, the following parameters are displayed:

- **IP Address**
- **Network Mask**
- **Default Gateway**

On the right-hand side of the page, you can find the following parameters:

- **HDO Bus IP Address**
- **HDO Bus Network Mask**
- **HDO Bus Default Gateway**
- **Mastering**
- **Master Address**
- **Poll Timeout**
- **Packet Timeout**

### Module Overview

This page displays the connected modules in the **eAcsys Devices** table. It is possible to remove missing modules using the drop-down menu **Remove Missing Modules**. With the **Configuration...** page button, the connector can be configured.

### DVE Tables

This page displays information regarding every exported connector, i.e.:

- The transmitter modules
- The receiver modules
- The power supply modules
- The chassis modules - however, note that these are no longer exported.
