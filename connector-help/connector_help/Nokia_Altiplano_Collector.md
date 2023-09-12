---
uid: Connector_help_Nokia_Altiplano_Collector
---

# Nokia Altiplano Collector

The Nokia Altiplano Access Controller is a cloud-based network management application to visualize, optimize, and enhance the fixed access network, supporting SDN-native, legacy, and third-party equipment.

The Nokia Altiplano Collector connector collects the smart-serial response of Nokia Access Management System and Altiplano alarms and displays them in a single table.

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

#### Smart Serial Connection - Main

This connector uses a smart-serial connection and requires the following input during element creation:

Smart-Serial Connection:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Initialization

No additional configuration of parameters is necessary in a newly created element.

### Redundancy

No redundancy is defined in the connector.

### Web Interface

There is no web interface available for this connector.

## How to use

The **General** page contains the Alarm Notifications table that contains both AMS and Altiplano Alarms.

On the **Settings** page, you can define the maximum duration for each row in the Alarm Notification Table and the maximum row count for that table.
