---
uid: Connector_help_ADVA_Optical_Networking_FSP_Network_Manager
---

# ADVA Optical Networking FSP Network Manager

The ADVA Optical Networking FSP Network Manager is designed to ease the surveillance and maintenance of networks. It is part of the ADVA advanced network management suite, and streamlines operational processes, helps to isolate faults, gathers performance data and delivers comprehensive reporting.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 11.1.1.1               |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                    | ADVA Optical Networking FSP Network Manager - NODE<br>ADVA Optical Networking FSP Network Manager - C-N<br>ADVA Optical Networking FSP Network Manager - C-NEW<br>ADVA Optical Networking FSP Network Manager - C2-NEW<br>ADVA Optical Networking FSP Network Manager - C4-N4<br>ADVA Optical Networking FSP Network Manager - C10-N<br>ADVA Optical Networking FSP Network Manager - EDFA-SGCB<br>ADVA Optical Networking FSP Network Manager - EDFA-DGCV<br>ADVA Optical Networking FSP Network Manager - 4ROADM-C96 |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

This page contains information about the server, such as **System Description, System Uptime**, etc.

It also contains a section where you can check the **Heart Beat Status** as well as the time between each heartbeat (with the **Heart Beat Timer** parameter). If no heartbeat is detected within the defined interval, the Status will switch to *Not OK*.

There is also a section where the **Resync Status**, **Interval** and **Port** can be configured.

### Overview

This page contains a tree control overview.

### Network Inventory

This page contains the **Network Inventory Table**. This table displays the information of the **Network Inventory CSV** file present on the ADVA server. It also shows the time when the CSV file was last read as well as the CSV file name.

The location of the CSV file can be defined on the Network Inventory Config page via the Config page button.

### Services Inventory

This page contains the **Services Inventory Table**. This table displays the information of the **Services Inventory CSV** file present on the ADVA server. It also shows the time when the CSV file was last read as well as the CSV file name.

The location of the CSV file can be defined on the Services Inventory Config page via the Config page button.

### Resource Report

This page contains the **Resource Table**. This table displays the information of the **Resource CSV** file present on the ADVA server. It also shows the time when the CSV file was last read as well as the CSV file name.

The location of the CSV file can be defined on the Services Inventory Config page via the Config page button.

### ENC server A&E

This page contains the **ENC Alarms and Events Table**. This table displays all events and all current active alarms detected on the ADVA ENC server.

### Services

This page contains the **Services Status Table**, with all top-level services, and the **Services Alarms and Events Table**, with all events and all current active alarms related to services management on the ADVA ENC server.

### DVEs Equipment

This page displays the **DVE Equipment Table**, which can be used to enable or disable DVEs.

### DVE Alarm Entities

This page contains the **DVE Alarm Entities Table.**

### Exported DVEs

This page contains the export tables for every type of DVE.

### DVE Alarms

This page contains the **Network Elements Alarms Table**, as well as the Alarm Table for every type of DVE.
