---
uid: Connector_help_Peak_Communications_P7000_SNMP
---

# Peak Communications P7000 SNMP

The **Peak Communications P7000 SNMP** connector can be used to display and configure information of P7000 converters.

## About

An **SNMP** connection is used in order to retrieve and configure the information of the device.

In addition, the connector offers several possibilities for **alarm monitoring** and **trending** of the supported Peak converters.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.99                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the device, such as the **System Name**, **System Description**, **Remote Status** and **OS Version**.

### Network

This page displays network parameters, some of which can be configured by the user. It also contains two tables with quick information about **Admin** and **Operational Status**.

### IP Tables

This page displays the **IP Route Table**, which contains routing protocol information.

There is also a page button that provides access to the **IP Net To Media Table**.

### Down Converter Module

This page displays the **Down Converter Table**, which contains detailed information about converter settings, such as **Frequency**, **Gain**, **Feed Voltage** and **Spectrum Inverter**.

### Faults Module

This page contains the **Faults Table**, which displays alarms and complete information about the origin of faults.

### WebInterface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
