---
uid: Connector_help_Thrane_and_Thrane_Sailor_900_VSAT_SNMP
---

# Thrane and Thrane Sailor 900 VSAT SNMP

The Thrane and Thrane Sailor 900 VSAT is an advanced maritime stabilized Ku-band antenna system.

## About

This driver uses **SNMP** to retrieve information from the device, and allows the user to monitor and configure the Thrane and Thrane Sailor 900 VSAT.

The driver also allows access to the **web interface** of the device.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.54                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## How to use

The element created with this driver consists of the data pages detailed below.

### General

This page displays general information about the device, such as the **System Description**, **System Contact**, **System Name,** and **System Location**. For the three latter parameters, a new value can be configured.

The page also displays the following parameters:

- **Active Polling IP**: The IP that the driver is currently polling.
- **IP Address (Primary)**: The IP address defined for the SNMP connection.
- **IP Address (Backup)**: Allows you to define a backup IP address.
- **Daily Availability**: Relates to both the main and the backup IP.

The page includes two page buttons that provide access to additional information and data related to the **System Configuration** and **Software Download**.

### Antenna

This page provides an overview of the **Status, Mode, Azimuth, Elevation** and **Skew** for the antenna.

### Modem

This page provides general information about the modem, such as its **Profile Name, Modem Type** and **Type Name.**

### Navigation

This page displays data concerning the ship's **GPS Position** and the **Vessel Heading**.

### Satellite

This page displays information concerning the satellite used for the connection. This includes such parameters as the **Nominal Longitude, Max Inclination, Skew, Elevation Cutoff, Polarization and Rx- Tx Frequencies**

### Interface

On this page, the **Interface Details** table provides an overview of all interfaces available to the device, including such data as the **MAC Address**, **Speed, Type**, **State**, etc.

### Tracking

This page displays information concerning the **Tracking Receiver**.

### Event Table

This page displays a table with all the events.

A page button provides access to the **Historical Events** subpage, where all events are listed until they are deleted or until the maximum number of days defined by the user has elapsed.

### Status Overview

This page displays a history of the last 24 hours for the ACU status parameters (updated every 5 minutes).

This includes parameters such as the **Antenna Azimuth Relative Position**, **Antenna Relative Elevation**, **Polarization Skew**, etc.

### Blocking Zone Table

This page contains a table with all the blocking zones, detailing their **Azimuth and Elevation start and end**.

A **blocking zone** identifies a region where the antenna is not allowed to transmit data. This zone can for instance identify where the ship bridge is located, so that the antenna will never aim at the bridge and start transmitting data that may be harmful for people working there.

### Blind Sector Settings

On this page, you can add blind sectors, define the **Start and Stop Azimuth and Elevation** and determine ifa blind sector is **Active or Inactive.**

A **blind sector** identifies a region where the antenna cannot successfully communicate because of an obstacle, such as for example a ship's mast. With this table, you can identify such regions and make the element generate an alarm if the ACU aims the antenna into such a blind sector.

### Blind Sector History

This page contains an overview of the **History of all Blind Sector Activity**. The **History Threshold** is by default set to *365 days* or approx. *1 Year*.

The button **Full History Check** carries out a complete check of all the records in the **History Table** and all **Currently Active or Inactive Blind Sectors**. It will not delete existing records.

Click this button to check the validity of each record. If a record is found to be invalid, the driver will attempt to fix this. For example, if a record exists in the history table that does not have a "Stop DateTime", but the settings table was cleared using a database query, this could lead to a record that never gets a "Stop DateTime", as the setting was not removed using "in-driver" means. In that case, this button can be used to clear up this discrepancy.

### Ping Function

This page displays information about the ping queries, such as **Ping Status**, **Average Success**, **Average RTT**, **Availability** and **Percentage of Packet Loss**. It also contains a toggle button to enable or disable ping queries, as well as other editable properties of the queries, such as **Cycle**, **Timeout**, **Requests per Cycle** and **Requests History**.

You can also select the type of **Protocol** to perform the ping: **ICMP** (default) or **TCP**. If you select the TCP protocol, you will also need to specify the **Port**. For the ICMP protocol, the Port field is disabled.

You can also enable and disable the **SNMP Poll Auto Swap** on this page. This swaps the polling IP from main to backup based on the **Ping Swap Threshold** defined below.

The page includes a page button with information about the **Backup Ping Function**, with a similar layout as the main page but with metrics for the backup polling IP.

### Export GPS Trace

On this page, you can enable or disable the **GPS data export feature** (which stores GPS locations in the database)and adjust the corresponding settings.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
