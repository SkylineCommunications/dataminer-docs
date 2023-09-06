---
uid: Connector_help_Ciena_Switch_5100_Series
---

# Ciena Switch 5100 Series

This driver monitors the activity of Ciena 5100 series switches. The Ciena 5000 family is part of a set of service aggregation switches. These switches provide aggregation to efficiently fill higher capacity links within both the metro access and aggregation tiers, minimizing the number of router assets required in the core.

## About

The driver polls data from the device using SNMP. The driver supports different switch series. Depending on the device, it will display data on the corresponding device page.

### Ranges of the driver

| **Driver Range**     | **Description**                                                                                                                      | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                                                                                      | No                  | Yes                     |
| 1.0.1.x \[Obsolete\] | Improved bitrate calculation                                                                                                         | No                  | Yes                     |
| 1.0.2.x \[SLC Main\] | Added new table wwpLeosPortStatsTable, added button for removing in error in interface table and resolved high bandwidth utilization | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | saos-06-14-00-0337          |
| 1.0.1.x          | saos-06-14-00-0337          |
| 1.0.2.x          | saos-06-14-00-0337          |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## Usage

### General

This page displays system information parameters, including the **Description** of the device, the **Object ID**, the **Up Time** and the **Device Availability**. Parameters like **Contact**, **Name** and **Location** can be set on the device. The **Availability** parameter shows the device availability in percent, based on the device connectivity monitoring.

### Detailed Interface Info

This page displays information about the interfaces connected to the device. It allows you to change the **Admin Status** and to set a new **Alias** on each interface.

### Statistics

This page displays the sum of all interface traffic of some parameters in the Detailed Interface Info table and in the Queue Group QStats table.

### Ciena WWP Leos Chassis

This page displays information related to the Ciena 5100 series switches (WWP Leos Chassis), including **CPU Load** data and tables with information about the **Memory** of the device, the **Power Supply** modules, the **Temperature Sensors** and the **Fan**.

### Ciena WWP Leos Data Plane

This page displays information related to the data plane, the number and name of the ports and statistical data of the packets.
