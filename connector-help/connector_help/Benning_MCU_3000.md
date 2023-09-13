---
uid: Connector_help_Benning_MCU_3000
---

# Benning MCU 3000

This connector is used to monitor the Benning MCU 3000 UPS system.

All the status information is retrieved via a serial command. The appropriate parameters are updated, and meaningful alarms are generated.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device. e.g. 192.168.1.2.
  - **IP port**: The IP port of the device. e.g. 4006.
  - **Bus address**: Not required.

### Initialization

When the timeout of a single command is set to a short duration, it can occur that not all response data is received.
Configure the settings below when you configure the element to allow full polling of the device response:

- **Timeout of a single command:** 5000
- **Number of retries:** 3

### Redundancy

There is no redundancy defined.

## How to Use

### General

This page contains general system information, such as the **Serial Number, Date, Time**, etc.

You can also find more detailed electrical data here, as well as an overview of the **Rectifier Current**.

The **Voltage** subpage displays all parameters related to voltage, and the **Current** subpage displays all parameters related to current and power.

### Alarms

All the alarms are grouped on this page, with information such as Load Fuse, Non-Urgent Alarm, Modem Status, etc.

Via page buttons, you can access the **Voltage Alarms**, **Status Alarms**, and **Battery Alarms** subpages, which contain more specific alarm parameters.
