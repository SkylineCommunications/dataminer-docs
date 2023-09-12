---
uid: Connector_help_Javit_Alarm_Monitoring
---

# Javit Alarm Monitoring

The Javit Alarm Monitoring system collects sound alarms from various monitoring computers and forwards the alarms as SNMP traps to a central monitoring application.
The Javit Alarm Monitoring driver displays a list of all monitoring computers with their current alarm status and delay times.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The driver consists of one page, the **General** page, which contains the **Alarm Contact Table**.

This table displays a list of all connected monitoring systems with their status parameters, such as **System Name**, **Alarm status**, **First Delay**, **Resend Delay** and **Clear Delay**.
