---
uid: Connector_help_Benning_MCU_1868
---

# Benning MCU 1868

This is a snmp protocol for the Benning MCU 1868 device.

The protocol is designed to retrieve information from the UPS.

## About

The connector needs a snmp connection to retrieve information from the device.

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. | No                  | Yes                     |

## Installation and configuration

### Creation

#### SNMP \[Main\] connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: 192.168.236.59

SNMP Settings:

- **Port number**: 161

## Usage

### General

Here you can find some general parameters about the device such as **Manufacturer, Software Version, Agent Software Version, Model.** You can also define the **Name** and the number of **Attached Devices.** At the buttom of the page there are two page buttons, one for **Configuration** and other for **Control**.

> #### Configuration
>
> > In this page you can configure the values of the **Input/Output Voltage**, **Input/Output Frequency**, **Low Baterry Time**, **Low/High Voltage Transfer Point** and **Audible Status**. It is also possible to see the current **Output Power** and **Output Apparent Power**.
>
> Control
>
> > This page contains the various properties which can control the shutdown and restart times and also the reboot duration.

### Battery

On this page you can various details for the **Battery** information.

### Test

Here you can initiate tests to the UPS.

### Input

This page contains the **Input Line Bads** which represents a count of the number of times the input entered an out-of-tolerance condition as defined by the manufacturer, the **Number of Lines** on the input which corresponds to the number of entries on the table. The table has four columns showing the **Input Frequency**, **Voltage**, **Current** and **True Power.**

### Output

This page contains the three parameters plus a table. The first contains the present source of output power, the second indicates the current frequency and the last corresponds to the number of lines that also corresponds to the number of entries in the table, the columns give the information about **Output Voltage**, **Current**, **Power** and **Percentage Load**.

### ByPass

Like in previous pages this also show the **Frequency** of the bypass and the number of lines which also correponds to the number of lines in the table, where each column represents respectively the **Voltage**, **Current** and **Power**.

### Alarms

The last page has a table containing all the Alarms of the device.
