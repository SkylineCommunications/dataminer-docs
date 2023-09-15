---
uid: Connector_help_HP_Proliant
---

# HP Proliant

The HP Proliant connector makes it possible to monitor general and critical parameters of the HP Proliant server.

## About

This connector displays information from the server that is retrieved using SNMP polling.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains information such as the **Host OS Name**, **Server Model**, **General System Status**, etc.

### CPU

This page contains the **CPU Table**, with information such as the CPU **Speed**, **Cores**, etc.

### Disk Physical/Logical

This page contains the following tables:

- **Physical Drive Table**: Displays information about the physical drive, such as the **Status**, **Size**, etc.
- **Logical Drive Table**: Displays information about the logical drive, such as the **Fault Tolerance**, **Status**, etc.

### Disk Array/Accelerator

This page contains the following tables:

- **Array Controller Table**: Displays information about the controller, such as the **Condition**, **Board Status**, etc.
- **Accelerator Board Table**: Displays information about the accelerator board, such as the **Status**, **Error Code**, etc.

### Fan

This page contains the **Fan Table**, with information such as the fan **Speed**, **Condition**, etc.

### Memory

This page contains the **Memory Table**, with information such as the memory **Module**, **Module Size**, etc.

### Power Supply

This page contains the **Power Supply Table**, with information such as the power supply **Status**, **Capacity**, etc.

### Temperature

This page contains the **Temperature Table**, with information such as the temperature **Value**, **Threshold**, **Condition**, etc.
