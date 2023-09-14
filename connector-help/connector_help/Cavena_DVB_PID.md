---
uid: Connector_help_Cavena_DVB_PID
---

# Cavena DVB PID

The **Cavena DVB** is a subtitling system for TV channels.

The **Cavena DVB PID** connector can be used to monitor Cavena DVB products.

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

## How to use

The connector has the following data pages:

- **General:** This page contains general information about the system such as **Name**, **Description**, **Uptime**, etc.
- **Products:** This page contains the **Products**, **Hardware** and **License** tables.
- **Ports:** This page contains the **Ports** and **Incoming Ports** tables.
- **Events:** This page contains the **Current Events** table.
- **Input:** This page contains the **Input Channel Language** and **Timecode** tables.
