---
uid: Connector_help_Network_Technologies_Inc_Enviromux_SEMS-16
---

# Network Technologies Inc Enviromux SEMS-16

The NTI Enviromux SEMS-16 is a server environment monitoring system.

## About

This connector uses an SNMP connection to communicate with the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.

## Usage

### General

This page displays general information about the device, including the **Time** and **Enterprise Name**, **Location**, **Contact** and **Phone**.

### Sensors

This page contains the following tables:

- **Internal Sensor Table**: For each sensor measurement, this table lists the **Type** of measurement, the **Description** (i.e. user-editable information about the items measured by the sensor), the measured **Value**, the **Unit Name** that applies for this value, and the **Status** of the sensor value.
- **External Sensor Table**: For each sensor measurement, this table lists the **Type** of measurement, the **Description** (i.e. user-editable information about the items measured by the sensor), the **Connector**, and the **Value** measured by the sensor.
- **External Sensor ACLM Table**: This table displays the maximum **Peak Value** registered from the sensor, **Frequency** values, **Current**, **Spikes**, **Swells**, **Sags** and **Relay**.

### I/O

This page contains the following tables:

- **Digital Inputs Table**: In this table, the user-configurable **Description** column provides information about the items measured by the sensor. The table also displays the **Value** measured from the digital input and the **Status** of the input.
- **Output Relays Table**: This table lists output relays with a user-editable **Group Nb** and **Description**, the **Group** in which each output relay belongs, the **Normal Value** expected from the output and the measured **Value**.

### Power Supply

This page contains only the **Power Supply Table**. For each power supply, this table lists the (user-editable) **Group Number**, the **Group** in which each power supply belongs, the measured **Value** and the **Status** of the power supply**.**

### Settings

This page contains the following tables:

- **IP Devices Table**: For each IP device, this table allows you to view and configure the **Address**, the **Description**, the **Group Nb**, the **Group** in which each IP belongs, the **Timeout**, the number of **Retries**, and the **State**. In the final column of the table, the **Status** is displayed.
- **IP Link Table**: For each IP link, this table allows you to view and configure the **Address** and **Description.**

### Web Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
