---
uid: Connector_help_CPI_TL12DO
---

# CPI TL12DO

The **CPI TL12DO** is a 1.2 kW "SuperLinear" outdoor TWT amplifier designed for satellite uplink applications.

## About

This connector is intended to communicate with the device using serial commands as described in the manual of the device. For more information, see <https://www.cpii.com/product.cfm/4/15/255>.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **Type of Port:** TCP/IP
- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the device, by default *50000.*
- **Bus address***:* The bus address of the device, by default *48.*

## Usage

### General

This page contains general information on the device.

Via the **Log** page button, you can retrieve log entries for the device. To do so, set the **Log Entry RF Units** and then the **Log Entry Number to Get**. Retrieving the same entry number with a different unit will overwrite the row with the same entry number.

### Measurements

This page displays several measurement points of the device.

### Switch Controller

This page contains the parameters that control the switch position and priority.

### Switch System Status

This page displays the status of the switch.

### Settings

On this page, you can set the **Amplifier Name** as well as the **Time** of the device (via the **Set Time** page button).

The page also contains switch-related settings.

### Alarms

This page displays all alarms related to the device. The page buttons provide access to the alarms related to each component of the device.

### Web Interface

This page can be used to access the web interface of the device. However, note that the client machine needs to be able to access the device, as otherwise it will not be possible to open the web interface.
