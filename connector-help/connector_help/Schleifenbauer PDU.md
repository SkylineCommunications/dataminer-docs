---
uid: Connector_help_Schleifenbauer_PDU
---

# Schleifenbauer PDU

The Schleifenbauer Intelligent Power Distribution Unit (PDU) is designed to distribute power. The Schleifenbauer data bus makes it possible to read and manage many PDUs with a single IP address. This PDU adds an Ethernet port to this functionality, so that alongside the advantages of a data bus, a whole range of new options becomes available.

This connector allows you to monitor status parameters, retrieve information on the device, and change certain system parameters.

The PDU may contain metered outlets, switched outlets, metered and switched outlets, or passive outlets.

The connector polls data from the device using **SNMPv1**.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                       | **Based on** | **System Impact**                                   |
|----------------------|------------------------------------------------------------------------------------------------------------------------|--------------|-----------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                                        | \-           | \-                                                  |
| 1.1.0.x \[SLC Main\] | \- Added support for firmware version 270.- Added the tables Inputs Totals, Device Performance, and Reset Performance. | 1.0.0.2      | May not be compatible with older firmware versions. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 244                    |
| 1.1.0.x   | 270                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page displays information about the **Devices Connected**, such as Hardware Address, New Devices, Ring State, etc. It also displays the **System Status**, including the Device Status Code and Alerts.

You can also enable or disable the **Outlet** **Automatically Unlock** feature on this page. When this is enabled, there is no need for a manual unlock before a change to the current state or a reboot of a certain outlet.

### Sensors

This page contains an overview of the **connected sensors and their measurements**, such as the Internal/External Temperature and Temperature Peak.

### Inputs

This page displays all the connected inputs. The parameters on this page allow you to monitor the **actual consumption of energy** (current, voltage, and power).

The **Inputs Totals table** shows the totals of the connected inputs calculated by the device.

### Outlets

This page lists all the **outlets (metered and switched)** in different tables.

The **Metered Outlets table** displays parameters related to the current, voltage, and power.

In the **Switched Outlets table**, you can configure the Individual Outlet Delay, Current State, Unlock, Reboot, etc. The **Reboot** button will be unavailable if the outlet is set to off.

### Performance

This page lists information about the sensors of the connected devices in the **Device Performance table.**

It also displays information about the last reset in the **Reset Performance table**.

### System

This page displays system information in the **Identification table**, such as the SPDM and Firmware Version, Product ID, Build Number, etc.

It also displays the main device settings in the **Settings table** and configuration informationin the **Configuration table**, including the Power Saver Mode, Fixed Outlet Delay, Duration, Phases, Maximum Load, etc.

Finally, the **Reset table** allows you to reboot the equipment or to reset certain information, such as alerts and power consumption.

### Web Interface

This page displays the device web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
