---
uid: Connector_help_APC_AP9340
---

# APC AP9340

The APC AP9340 is an environmental management system that uses several probes and inputs to display and manage the environment of several devices.

## About

The AP9340 uses probes to manage several parameters of the environment, namely the temperature and humidity. It allows the user to configure the thresholds, time variance and alarm monitoring associated with those parameters.

The connector communicates with the AP9340 through SNMP polling, if the correct IP and port are configured during element creation.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.5.6                       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device
- **Device address**: Not required

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### Unit Data

This page displays the identification information of the unit, including the name, firmware and other versions, as well as the basic status.

### Unit Configuration

On this page, you can configure basic unit data, such as its name, time, TFTP and traps.

The page also contains page buttons to access more parameters related to the two cores of the connector: the **Environmental Management System** (EMS) and the **Modular Event Manager** (MEM). There are page buttons related to **Inputs**, **Probes**, **Sensors**, **Alarm Devices**, **Outlets** and **Outputs.**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
