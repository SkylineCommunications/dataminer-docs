---
uid: Connector_help_Pixel_Power_Clarity
---

# Pixel Power Clarity

This connector allows the user to view a report for each Clarity, describing the status of the loaded job and of any pending jobs.

## About

The connector presents its information in two tables, the **System Table** and the **Clarity Table**. There, you will find information about the overall status that can be used as a top-level indicator of whether or not there are any issues within the system. The data of these tables is polled via **SNMP** protocol every 10 seconds.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | SKY22                       |

## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device e.g. *10.10.250.150*
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### System

This page displays the **System Table**, which shows the **Index**, **Name** and **Status** for each detected system.

### Clarity

This page displays the **Clarity Table**. This table shows the **Index**, **System Index**, **Name**, **Overall Status**, **Connection Status**, **Pending Job Status**, **Pending Job Name**, **Pending Job Load Time**, **Missed Event Status**, **Missed Event ID**, **Missing Event Status** and **Missing Event ID** for each Clarity detected. The index of a specific Clarity entry consists of *\[Index (System Table)\].\[Index (Clarity Table)\]*. You can find the System Status on the **System** page mentioned above.
