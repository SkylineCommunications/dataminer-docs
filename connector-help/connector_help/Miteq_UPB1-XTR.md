---
uid: Connector_help_Miteq_UPB1-XTR
---

# Miteq UPB1-XTR

The **Miteq UPB1-XTR** device is an up-convertor switch unit.

## About

This connector uses SNMP to monitor and configure the Miteq UPB1-XTR.

### Version Info

| **Range**     | **Description**                                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                                                                                   | No                  | Yes                     |
| 2.0.0.x \[SLC Main\] | **Impacting changes** when moving from another range to this one. Recreated version to match the UX of the Miteq DNB1-XTR 1.0.0.X | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | D163995V1.182.25            |
| 2.0.0.x          | D163995V1.182.25            |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

The connector contains 5 pages.

### General

This page displays information regarding the **Device Number**, **Serial Number** and **Firmware**, as well as the current **Voltage** and **Temperature** of the unit.

In addition, it allows you to change the **Device Name**, permit or prohibit the **Firmware Upgrade**, and configure the **Password**, **System Clock**, **Logout** **Time** due to inactivity, and **Frequency of Web Alarm** (i.e. the frequency with which the web alarm status is refreshed).

The page contains one page button, **Network**, which opens a subpage where you can change **Network and SNMP settings**.

Finally, there are also three buttons: **Enable Test Fault**, **Disable Test Fault** and **Factory Defaults**.

### Alarms

This page displays various **Unit Condition Faults**. The parameters change from *OK* to *Fault* when there is a fault (alarm).

The page also displays the current values of **Voltage**, **Temperature** and **LNA Current**.

### Bands

This page displays information regarding the **bands**, **Minimum** and **Maximum Input/Output Frequencies**, **Attenuations** and **LNA Current**.

It allows you to change **Attenuation**, configure **LNA limit values**, and set the device to **Mute/Unmute**.

Finally, there is also a page button, **Frequency**, which opens a subpage where you can configure the **Frequency**, **Input/Output Switch**, and **Slope**.

### Log

This page displays a table with **Log/Error** entries, from *1* to *63* in descending order. The table shows the **date and time** when each logged event or error occurred, and the **description** of the log or error.

There is also a **Clear Logs** button, which can be used to clear out the log table.

As date and times are by default displayed in the local culture settings, an extra formatted column is added: **Date and Time (Formatted)**. This can be configured via the **Extra Time Notation**.
When this value is set to *None*, no extra date and time will be displayed. Otherwise, the formats below will be applied:

- **AM/PM**: year-month-day 12-hours:minutes:seconds AM or PM
- **24H**: year-month-day 24-hours:minutes:seconds

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
