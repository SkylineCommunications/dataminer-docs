---
uid: Connector_help_Sony_Alarm_Receiver
---

# Sony Alarm Receiver

The purpose of this driver is to aggregate alarms from Sony devices.

## About

### Version Info

| **Range**            | **Key Features** | **Based on**                         | **System Impact** |
|----------------------|------------------|--------------------------------------|-------------------|
| 1.0.1.x \[SLC Main\] | Driver review    | \- Version 1.0.0.2 developed by Sony | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver has the following data pages:

- **Aggregated Alarms**: Displays an Alarm Table which contains rows that will be used to aggregate alarms raised by Sony devices. Via the context menu of the table, rows can be added. To do so, right-click the table and select **Add row**.
