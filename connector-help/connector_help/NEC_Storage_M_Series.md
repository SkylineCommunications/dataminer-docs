---
uid: Connector_help_NEC_Storage_M_Series
---

# NEC Storage M Series

The NEC Storage M Series is a highly efficient storage solution that reduces the ever-growing cost of storing business-critical data. This connector can be used to monitor this device.

## About

The connector uses an **SNMP** connection to monitor **NEC Storage M Series** devices. SNMP traps can be retrieved when this is enabled on the device. The connector displays information about the connectivity units present in the system.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

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
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Unit

This page contains information about the connectivity units present in the system. It displays two tables:

- **Unit Table**: A list of units under a single SNMP agent.
- **Unit Revision Table**: Revisions supported by units managed by the agent.

### Sensor

This page displays the **Unit Sensor Table.** This table contains information about the sensors supported by each unit.

### Port

This page displays the **Unit Port Table**. This table shows generic information about the ports of each unit.

### Event

This page contains the **Event Table**, which displays the events associated with each unit.

### Report

This page contains the **Report Indicator** and **Report Counter Table**.

### Disk

This page displays two tables:

- **Unit Disk Enclosure Table**: Contains information about the disk enclosure supported by each unit.
- **Unit Physical Disk Table**: Contains information about the physical disk supported by each unit.

### Web Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
