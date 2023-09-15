---
uid: Connector_help_Victron_UPS
---

# Victron UPS

The **Victron UPS** is an Uninterruptible Power Supply made by Victron.

## About

The **Victron UPS** operates in the **SNMP** protocol and in the serial **Modbus TCP** protocol. The connector implements two ranges: one range is used with **SNMP**, the second range is used for **serial Modbus**.

### Version Info

| **Range** | **Description**          | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version (SNMP)   | No                  | Yes                     |
| 1.0.1.x          | Initial version (SNMP)   | No                  | Yes                     |
| 2.0.0.x          | Initial version (Modbus) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \-                          |
| 1.0.1.x          | \-                          |
| 2.0.0.x          | Modbus TCP                  |

## Installation and configuration

### Creation

#### 1.0.x.x.: SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.

#### 2.0.0.x: Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *502*.

## Usage (Range 1.0.x.x)

### General

This page contains general information about the device, such as the **Manufacturer**, **Model**, **Software Version**, etc.

### Input/Output

This page displays information about the I/O of the device, including the **Frequency**, **Voltage**, **Current** and **Power.**

### Bypass/Battery

This page contains information about the battery and bypass, such as **Bypass Frequency**, **Battery Status**, **Battery Temperature**, etc.

### Alarm Page

This page contains a table displaying all the alarms as well as settings regarding the status or accepted values.

### Control

This page allows you to **shut down** or **reboot** the device with a configurable **delay**.

## Usage (Range 2.0.0.x)

### General

This is the default page of the connector. It contains all the parameters related to com.victronenergy.system, such as MAC Address, Relay State, System Battery Voltage, etc.

### VE.Bus

This page contains all the parameters related to com.victronenergy.vebus, such as **Input Voltage**, **Output Voltage**, **Input Current**, etc.

### VE.Bus Alarm

This page contains all the status and alarm parameters related to the VE.Bus page, such as **Temperature Alarm**, **BMS Error**, etc.

### Battery

This page contains all the parameters related to com.victronenergy.battery, such as **Battery Voltage**, **Current, Capacity**, **State of Charge**, etc.

### Battery Alarm

This page contains all the status and alarm parameters related to the Battery page, such as **Low Voltage Alarm**, **High Temperature Alarm**, **State**, etc.

### Settings

This pages allows you to configure the **ESS Battery Life State** and **ESS Minimum SoC.**
