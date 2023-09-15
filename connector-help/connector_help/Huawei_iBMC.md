---
uid: Connector_help_Huawei_iBMC
---

# Huawei iBMC

The Huawei iBMC or Intelligent Baseboard Management Controller is an embedded server management system that is used to manage servers throughout their life cycle.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                               |
|-----------|------------------------------------------------------|
| 1.0.0.x   | 3.31 (U4282) iBMC SW on Huawei FusionServer 2288H V5 |

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

On the **General** and **System** page, you can find information related to the system.

The **CPU**, **Memory**, **Hard Disk**, **Fans**, **Power**, **Network**, **PCIe** and **SD Card** pages show the overall alarm status for that aspect of the system and contain a table with detailed information.

The **Sensors** and **Temperature** pages display the detailed sensor readings and thresholds.

The **Alarms** page contain the **Active Alarms Table**. This table displays a list of all Active Alarms received from the server. If a de-assert event is received for a specific event, that event will automatically be removed from the table.
Note that the connector was developed and tested with the device configured to use "OID" mode for the trap notification settings. It is therefore recommended to use the connector in combination with the Trap OID mode on the device itself.

On a subpage, the **Trap Table** is included, where you can view all incoming traps from the server with their raw information. It is possible to limit the number of traps by a maximum number of traps or number of days.
