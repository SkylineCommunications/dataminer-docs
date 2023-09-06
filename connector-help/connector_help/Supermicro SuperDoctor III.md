---
uid: Connector_help_Supermicro_SuperDoctor_III
---

# Supermicro SuperDoctor III

The **Supermicro SuperDoctor III** driver is an SNMP-based driver that can be used to monitor and configure the **Supermicro SuperDoctor III Monitoring Platform**.

## About

This driver provides a monitoring and configuration interface for the **Supermicro SuperDoctor III Monitoring Platform**. It allows the user to display measurement values of different **Monitor Devices** and to configure their measurement limits.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Health Info

This page displays a table listing the different **Monitor Devices** installed in the **Supermicro SuperDoctor III Monitoring Platform**.

A monitor device can be **Fan**, **Voltage**, **Temperature** or **Status**. Measurement values are shown for each device.

Measurement **high limits** can be configured for **Temperature** and **Voltage** devices only. Measurement **low limits** can be configured for **Fan** and **Voltage** devices only. The **divisor** can be configured for **Fan** devices only.

With a toggle button, you can set the monitoring state of each device to ***Monitored*** or ***Not Monitored***.

### Webpage

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
