---
uid: Connector_help_Asentria_SiteBoss_550
---

# Asentria SiteBoss 550

The **Asentria SiteBoss 550** connector is an SNMP connector that is used to monitor server equipment rooms or remote cabinets or enclosures.

## About

With this connector, it is possible to monitor and configure the SiteBoss 550 device via SNMP to control server equipment rooms or remote cabinets or enclosures.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.11.220                    |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation

SNMP Connection:

- **IP Address/host**: The polling IP of the device.

SNMP Settings:

- **Port Number:** The port of the connection device, by default *161.*
- **Get community string:** The community string required to read from the device. The default value is *public*.
- **Set community string:** The community string required to set to the device. The default value is *private*.

## Usage

### General Page

On this page, you can find general device statuses and settings such as **Site Name**, **Site Date/time**, and **Dialup Modem**.

In addition, you can also configure settings for Ethernet 1 and Ethernet 2, and configure the **Satellite Heater** settings.

### Status Page

On this page, there are four tables: **Internal Digital Contacts**, **Relay Outputs**, **Analog Inputs** and **Digital Contacts**. In these tables, you can find an overview of all statuses and configuration.

### ACPMS Configuration Page

This page displays the following information on the device: **Name**, **State**, **State Color Code**, **Voltage**, **Current**, **Frequency**, **Power Voltage State Event**, **Voltage Color Code**, **Current Color Code**, **Frequency Event State**, **Frequency Color Code**, **Power Event State** and **Power Color Code**.

### General Configuration Page

On this page, all general configuration can be set.

### Network Configuration Page

On this page, all network configuration can be set. There is also a **DNS Table** available that contains the DNS index and DNS addresses.

### Serial Configuration Page

On this page, all serial configuration can be set. There is also a page button, **Port Config Table**, that provides access to an extra table with the port settings.

### Security Configuration Page

On this page, all security configuration can be set. There is also a page button, **Security User Table**, that provides access to an extra table listing the users with their settings.

### Events Configuration Page

On this page, all event configuration can be set. There are also six page buttons available with extra settings.

### Actions Configuration Page

On this page, all action configuration can be set. There are four tables that can be configured, containing actions for **Host**, **Email**, **Call Numbers** and **Pager**. Each table contains extra settings.

### Logs Configuration Page

On this page, you can set all values concerning the **Event Logging** and **Audit Logging**.

### AC Power Monitoring Page

This page displays a table with the **AC Power Status**.

The page also contains seven page buttons, each one with the corresponding **AC Power Settings**.

### Web interface Page

On this page, you can access the web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
