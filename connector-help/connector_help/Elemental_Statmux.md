---
uid: Connector_help_Elemental_Statmux
---

# Elemental Statmux

The **Elemental Statmux** is a software-based statistical multiplexer that optimizes content delivery for pay TV operators by reallocating bits in real time between video encoders and combining the outputs from multiple encoders into a single transport stream.

## About

The **Elemental** **Statmux** connector is an **HTTP** connector that is used to monitor Elemental systems. It also contains an **SNMP Connection** to set some important settings.

The content retrieved via the HTTP connection comes in XML format. Information sent to the device also uses the same format.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.10.1bt.301246             |

## Installation and configuration

### Creation

HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *elemental_snmp*.
- **Set community string**: The community string used when setting values on the device, by default *elemental_snmp_write*.

### Configuration of HTTP Connection

In order to start retrieving HTTP content, the **Login** and **API Key** must be filled in on the **General** page.

The **API Key** is not the same as the password of the user account. (See "Notes" section below.)

## Usage

### General

This page contains general information and settings.

### Settings

This page contains more specific settings. Via page buttons, you can access different types of additional settings: **Cluster**, **Authentication**, **Cloud**, **Network** and **Network** **Tables**.

### Messages

This page displays the latest messages available in the device.

### MPTS

On this page, you can check the current configured MPTSs. To add or update one, use the page button under the table.

To add a new MPTS, fill in the necessary fields. If at least the **Modify Name** and the **Modify Destination 1 URI** are filled in, you can click the **Create** button.

To change an existing MPTS, first select the MPTS to be changed via **Load MPTS** and then click the page button. This will load the current values. After you have made the changes, click the **Update** button.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

The **API Key** that is needed in order to retrieve the HTTP content can be found via the web interface. Log on with the Login and Password, and go to *http://\<ipaddress\_\>/user_profile*.
