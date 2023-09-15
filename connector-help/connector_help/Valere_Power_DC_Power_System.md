---
uid: Connector_help_Valere_Power_DC_Power_System
---

# Valere Power DC Power System

The Valere Power DC Power System is a power supply unit.

## About

This connector allows you to retrieve information from a Valere PSU. It allows you to monitor alarm and statistical information, and to configure and activate the device.

The connector retrieves and sets information on the device through SNMP.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 24.03.36                    |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values from the device, by default *private.*

## Usage

### System

This page contains general information about the device.

It also contains a number of page buttons:

- **System Config**: Allows you to configure system temperature compensation settings and internal temperature thresholds.
- **Rectifier Config**: Allows you to configure the Rectifier Float Voltage Setpoint and Rectifier High Voltage Shutdown Setpoint.
- **LVD Configuration:** Displays the LVD settings.

### Battery

On this page, the **Battery Temperature** table allows you to monitor the battery temperature if probes are connected. The **Thermal Probe** table displays the thermal probe status.

Via the **Battery Config** page button, you can configure the battery temperature settings.

### Alarm

On this page, you can monitor and configure the alarms in the device.

### SNMP Configuration

This page contains a table with traps settings and allows you to configure the **Read/Write/Trap Community String** settings.
