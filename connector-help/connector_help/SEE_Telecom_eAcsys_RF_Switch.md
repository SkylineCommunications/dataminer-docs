---
uid: Connector_help_SEE_Telecom_eAcsys_RF_Switch
---

# SEE Telecom eAcsys RF Switch

This is connector is aimed for the control and monitoring of the RF switch modules for the SEE eACSYS device.

## About

The connector uses 2 connections. The main connection (*SNMPv2*) is used for normal polling. Besides this connection, a secondary *HTTP* connection is used to send control commands (through **GET** methods).

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | E_2.4.3                     |



## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (**SNMP**) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device (e.g. *127.0.0.1*).
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (e.g. *public*).
- **Set community string**: The community string used when setting values on the device (e.g. *private*).


#### HTTP Control connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination (e.g. *127.0.0.1*).
- **IP port**: The IP port of the destination (e.g. *80*).
- **Bus address**: *bypassproxy.*

## Usage

### RF Switch Module 1

On this page, you can find the following parameters:

- **Address RF Switch Module 1**: this parameter allows to address a particular switch slot.
- **Path RF Switch Module 1:** allows the user to set the path of the RF Switch Module.
- **Mode RF Switch Module 1:** allows the user to set the mode of the RF Switch Module.
- **Voltage Main RF Switch Module 1:** displays the voltage of the Main RF Switch 1.
- **Voltage Backup RF Switch Module 1:** displays the voltage of the Backup RF Switch 1.
- **User Description RF Switch Module 1:** allows the user to add a description to this module. Automatically, all parameter names of this module will also include this description to allow an easy identification. Note that these names will furthermore be used throughout the DataMiner System.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
