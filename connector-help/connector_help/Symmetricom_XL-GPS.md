---
uid: Connector_help_Symmetricom_XL-GPS
---

# Symmetricom XL-GPS

The Symmetricom XL-GPS is a time and frequency receiver. This connector allows you to monitor and configure this device via an SNMP and Telnet connection.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                 | **Based on** | **System Impact**                                                          |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------------------------|
| 1.0.0.x              | Initial version. SNMP connection to retrieve general and status information about the device.                                                                    | \-           | \-                                                                         |
| 1.0.1.x \[SLC Main\] | \- Telnet connection added to retrieve Option Bay and GPS Satellite information. - Tree control implemented to display Option Bay and GPS Satellite information. | 1.0.0.1      | Additional Telnet connection requires configuration in the element editor. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 192-8001               |
| 1.0.1.x   | 192-8001               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
  - **Get community string**: The community string needed to read from the device. The default value is *public*.
  - **Set community string**: The community string needed to set to the device. The default value is *private*.

#### IP Connection - TELNET

This connector uses an HTTP connection and requires the following input during element creation:

HTTP connection:

- **IP address/host**: The polling IP or URL of the destination. This will likely be the same as the SNMP IP address.

TCP/IP Settings:

- **IP port**: The IP port the device is listening on for Telnet requests (default: *23*).

## How to Use

The element consists of the pages detailed below.

### General

This page displays general information, such as the **System Description**, **System Up Time** and **various statuses**.

### Settings

On this page, you can enable or disable settings like **Primary/Secondary Reference Clock**, **Primary/Secondary Power**, **Rubidium Oscillator** and **Time Out Threshold**.

You can also enable and configure the **Telnet connection** required to receive the Option Bay and GPS Satellite information displayed on the Inventory page.

### Faults

This page shows latched **faults** of the device. These latches can be reset with the button **Clear Faults**.

### Inventory

This page shows a tree control view of **Option Bays** and any corresponding **GPS Satellites**. This information can be found in table format on the **Inventory Data** subpage.

Note that **polling** for this information is **disabled by default**.
