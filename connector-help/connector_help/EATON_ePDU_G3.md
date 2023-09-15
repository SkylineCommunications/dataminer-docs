---
uid: Connector_help_EATON_ePDU_G3
---

# Eaton ePDU G3

The Eaton ePDU G3 connector can be used to monitor and configure Eaton ePDU G3 rack-mounted power distribution units.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v04.01.0002            |

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
- **IP port**: Default:*161*.

SNMP Settings:

- **Get community string**: Default: *public-community.*
- **Set community string**: Default: *private-community.*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

You can find detailed information on the data pages of the element below.

### General

This page contains the system information of this PDU. You can configure the **system name**, **location**, and **contact**.

### Overview

This is an overview of the Phase L1 information, based on different input tables.

On the **Input** subpage, you can find one of these tables, showing general status information for the current input (Phase L1).

The **Input Setting** subpage contains additional tables with detailed voltage, current and power information, including different configurable threshold values. The total power usage of the input is also displayed.

### Branch Circuits

This page contains a table with general group information. It includes the current, voltage, power, and energy value of the groups.

On the **Group Settings** subpage, several tables are available with detailed current, voltage and power information, including different configurable threshold values.

The **Group Control** subpage contains a table with the control settings of the groups. This includes the On, Off, and Reboot command. The number indicated in the table is the time in seconds until the command is issued.

### Outlets

This page contains a table with general outlet information, including the current, voltage, power and energy value of the outlets.

On the **Outlet Settings** subpage, you can find the Outlet Current table, with the current usage information for each of the outlets, including the threshold levels. This subpage also contains the Outlet Power table, with the power usage information for each of the outlets. You can configure the outlet watt-value, as this value can be reset to 0.

The **Outlet Control** subpage contains a table with the control settings of the outlets. This includes the On, Off, and Reboot command. The number indicated in the table is the time in seconds until the command is issued.

### Units

This page contains the **Unit table**, which provides an overview of the unit information, and the **Unit Control table**, with the configuration of the units.

### Environment

This page contains the environmental information of the device.

- The **Contact table** indicates the status of the contact sensors.
- The **Temperature and Humidity tables** show the temperature and humidity value, and the status of the device. These also include threshold values.

### Active Alarms

The table on this page lists the active alarms sent via traps.

On the **Alarm Trap Setting** subpage, you can find settings for the table on the main page:

- **Alarm Auto Clean up Method**: The method used to automatically clean up the trap records in the table. The following options are available:

- *Row Count*: When the number of traps reaches the number configured under Max Alarm Trap, the records are cleaned up.
  - *Age*: When traps exceed the age configured under Max Age Alarm Traps, they are removed.
  - *Both*: Combines the *Row Count* and *Age* options.

- **Max Alarm Trap**: The maximum number of rows the table should contain.

- **Clean up Alarm Amount**: The number of records that will be cleaned up when the maximum number is reached.

- **Max Age Alarm Traps**: The maximum date and time that the records can be kept.

### Logs

This page contains a table with the logging information sent via traps.

On the **Log** **Trap Setting** subpage, you can find settings for the table on the main page. These settings are similar to the ones on the Alarm Trap Setting subpage.
