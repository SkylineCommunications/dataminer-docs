---
uid: Connector_help_Ciena_CN6500_Platform
---

# Ciena CN6500 Platform

The **Ciena CN6500 Platform** is an optical transport network device that supports multiple technologies ranging from Ethernet, WDM, OTN, CES, MPLS, SDH, and SONET to many other transport technologies.

This connector uses an **SNMP** connection to monitor Ciena CN6500 Platform devices.

## About

### Version Info

| **Range**            | **Description**                                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version. Features interface data, equipment data, SNMP data, NMM topology, Nortel optical performance, and alarm data. | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | DCF                                                                                                                            | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 10.10Z.OF              |
| 1.0.1.x   | 10.10Z.OF              |

## Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device (default: 161).
- **Read Community**: The community string in order to read from the device.
- **Write Community**: The community string in order to write in the device.

## How to Use

Since this device supports a wide range of technologies, the data polling is based on two timers in order to provide more flexibility and more reliability to the connector communication. The polling configuration can be found on the Polling Configurations page. Each page also contains a refresh button that allows you to force the polling for every parameter and table on that page.

### General

This page contains the general system data such as the **System Description**, **System OID**, **System Up Time**, **System Contact**, **System Name**, etc. It also contains the **Polling Configuration** page button.

### Polling Configurations

The polling of the device is not enabled by default. To start the polling, you need to enable the **polling state** of the connector. For each page, select the **polling configuration**:

- **No polling**: No data will be polled from device.
- **Slow polling**: Polling will be based on the slow timer.
- **Fast polling**: Polling will be based on the fast timer.

### Shelf Equipment

On this page, you can find shelf-related data, including **shelf identification parameters** and the following tables:

- **Equipment Provision table**: Contains information regarding the cards that are equipped on the device. You can configure the administrative state and check its status.
- **Inventory Table**:Provides more detailed information for a card and allows you to send a cold or warm restart command to a given card.

### Physical Entities

In the **Physical Entities** table, you can find the full description of every card and module equipped on the device. You can also set the admin state of a port.

### Interfaces

This page provides information about every port present in the device. You can also set the administrative state of a port.

### Interfaces Tree

This page provides a tree view of all interfaces. For each interface, performance information is displayed. The performance information is shown per performance type.

### NMM Topology

The NMM (Nortel Management MIB) Topology page contains the data related to the Nortel Discovery Protocol.

The protocol can be deactivated with the **NMM Topology status** toggle button.

The **Ethernet Multi Segment NMM Topology Table** allows you to identify every NMM topology segment.

### PM - Optical Power / Optical Loss / Code Violation / Failure Counts / Frames Statistics / Errored Seconds

These pages contain information regarding the optical power data (in dBm), optical loss data (in dBm), code violations data, failure counts data, frames statistics data, and errored seconds data for the device, respectively. On each of the pages, you can check this data for each measurement point enabled in the device. Trending is enabled on the Value column.

### SNMP Data

This page allows you to analyze and configure SNMP data present on the equipment. The following page buttons are available: **SNMP USM**, **SNMP View Based Data**, **SNMP Notify**, **SNMP Targets** and **SNMP Community**.

### Alarms

This page contains tables regarding alarm data: **Active Alarm** **data** and **Cleared Alarm data**.
