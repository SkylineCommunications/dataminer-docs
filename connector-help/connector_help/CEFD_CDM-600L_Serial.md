---
uid: Connector_help_CEFD_CDM-600L_Serial
---

# CEFD CDM-600L Serial

The **CEFD CDM-600L Serial** is a serial connector intended to communicate with CDM-600L Comtech devices.

## About

This connector uses serial communication to retrieve information from the device and to set the device configuration.For more information, refer to the following page: <http://www.comtechefdata.com/support/docs/satellitemodemdocs>.

### Version Info

| **Range**     | **Description**                                   | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version (EF Data CDM600L)                 | No                  | Yes                     |
| 2.0.0.x \[SLC Main\] | Change of protocol name, based on EF Data CDM600L | No                  | Yes                     |

## Installation and configuration

### Creation

Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the Ethernet to serial converter, e.g. *10.11.12.13*.
- **IP port**: The port addressed to connect the device, set in the Ethernet to serial converter, e.g. *4001*.
- **Bus address**: The BUS address set in the device, e.g. *1*. (Range: 1 to 9999.)

## Usage

### Main View

This page shows more info about the modulator and demodulator.

### General

This page provides a general perspective on some of the most important parameters of the device.

### Logs

The **Modem Events Log** table represents the stored events on the device. The device can store max 200 events in memory, but the connector can store more events. New events will be added to the table, oldest events will be removed based on the configured **Max Event Log** setting

- **Clear Events** button will send a command to clear the stored events on the device, as a result the **Modem Events Log** table will be reset.
- **Initialize Events Pointer** button, will clear the Modem Events Log table and retrieve all the stored events again from the device.

Setting one of these buttons, will clear the table on the connector, as a result the Index will start again from 'Event 1'.
