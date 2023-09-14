---
uid: Connector_help_Rohde_Schwarz_DVMS
---

# Rohde Schwarz DVMS

The **Rohde Schwarz DVMS** is a digital TV monitoring system that allows users to view streams, services, PIDs and their associated bitrates.

## About

By means of a tree view, the connector displays all streams, services and PIDs. The tree view is divided into DVB-S streams, DVB-T streams, and DVB-T2 streams.

### Version Info

| **Range** | **Description**                                                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. This range uses the Round Robin type scheduler from Rohde Schwarz. | No                  | No                      |
| 2.0.0.x          | Based on full review of range 1.0.0.x. This range only uses the DVMS directly.      | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |

## Installation and Timing

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *public.*

## Usage (1.0.0.x range)

### Main View Page

This page contains the **Device Description**, **Device Name**, **Device Location**, etc.

### DVB-T Signal Interfaces

This page contains a table that provides information about all the **streams** in the system and their **measurements**. It also contains a button **Normalize Aliases** and a page button **Normalization**, which shows the **Alias Normalization table**.

## Usage (2.0.0.x range)

### General Page

This page displays the **Firmware Version**, **Image Version**, **Stock Number** and **Serial Number**. It also contains parameters that can be used to manage **configurations**, **reboot** the device and **execute** external scripts.

### Modules Page

This page displays all **Ethernet ports** and their **configuration**.

### Device Overview

This page contains a tree view that provides a complete overview of the **streams**, **services** and **PIDs** in the system.

### DVBS / DVBT / DVBT2 Interface

These three pages contain tables that provide information concerning all the **streams** in the system and their **measurements**.

### Services

This page contains the **Services Table**.

### PIDs

This page contains the **PID Table**.

It also contains the page button **PID Table Configuration**, which opens a subpage where you can configure the display key of the PID table, and as such also the content of this table. Please note the following regarding this configuration:

- If you select the option **Stream ID/Service ID/PID** as the display key, the PIDs will be displayed in the PID Table as many times as they are referenced. For example, if a PID is found in two different services, two PID entries will be displayed in the table.
- If the option **EsInfo PID** is selected, each PID will only be displayed once.

### Bit Rate

This page contains information about the bit rates. It displays the bit rate for several instances, listed in the **Bit Rate Table**, which among others displays the **Bitrate Minimum** and **Bit Rate Maximum**.

Some additional information is also displayed, such as the **ASI Total Bit Rate Minimum** and the **DVB-S Total Bit Rate Maximum**.

### Log

This page contains the **Log Table**, as well as page buttons to the following subpages:

- **Configuration**: Allows you to update the CSV file that contains the custom event descriptions.
- **Control Monitoring:** Contains the Control Monitoring table, which allows you to clear all statistics and logging related to a port number.

### TS Test

This page contains the following tables:

- **Test Statistics Table**: Contains information such as the **Module Name**, **Port Number** and **Alarm State**.
- **Test Failure Summary Table**: Also displays the **Module Name** and **Port Number**, along with **Test Failure** information, among others.

This page is only available from version **2.0.0.16** onwards.
