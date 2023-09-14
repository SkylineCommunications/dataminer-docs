---
uid: Connector_help_Racktivity_DC2
---

# RACKTIVITY DC2

The Racktivity DC2 meter connector is used to monitor and control a **RACKTIVITY DC2 METER** device.

## About

This connector displays the information of the device on different pages, grouping parameters in different categories.

The connector uses **SNMP** to retrieve and update the data of the device. The Racktivity DC2 meter has the ability to send out SNMP traps when certain events occur in the sensor. Traps will result in instant updates in the corresponding DataMiner element.

### Version Info

| **Range** | **Description**                                                                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                    | No                  | Yes                     |
| 1.0.1.x          | Corrected Displayed Items. Reset Max/Min Values function. Improved Polling timing. | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**        |
|------------------|------------------------------------|
| 1.0.0.x          | RTF0035 v2.1.1.1 Version v0.1.2.67 |

## Installation and configuration

### Creation

SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Device address**: Not used

SNMP Settings:

- **Port number**: The port of the connected device, default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### Power / Overview

This page displays the general overview of the **Current (A)**, **Power utilization (kWh)**, **Active Energy (kWh)** and **Charging Energy** on the device sensors.

### Power / Current

This page displays information about the **Amperage**, including the general status of the individual transducers and their totals. You can configure warning thresholds, activate/deactivate trap notifications and keep a quick track of min/max utilization. This data can be reset.

### Power / Power

This page displays information about the **Voltage**, including the general status of the individual transducers and their totals. You can configure warning thresholds, activate/deactivate trap notifications and keep a quick track of min/max utilization. This data can be reset.

### Power / Energy

This page displays information about the **Voltage Feed** usage of the individual transducers and their totals. This data can be reset.

### Sensor Labels

On this page, you can view and modify the label name of the individual transducers.

### Environment

This page displays information related to:

- **Electrical Feed Data**: Maximum and Minimum historical values, thresholds configuration, trap notifications.
- **Ambient**: General device temperature, thresholds configuration, trap notifications.

### Network Settings

On this page, you can view and configure the management of SNMP settings for the network and traps.

### Settings

On this page, you can view and configure device information, and manage the device web portal and the NTP Server usage.

## WebInterface

This page provides access to the webpage of the device, where you can check information and configure general settings of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
