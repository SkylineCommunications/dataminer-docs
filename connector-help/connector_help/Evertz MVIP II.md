---
uid: Connector_help_Evertz_MVIP_II
---

# Evertz MVIP II

The MVIP II is an IP-based multi-image display and monitoring solution used as a tool for digital headends, IPTV networks, and sites using IP distribution.

This connector retrieves all data using a single SNMP connection. SNMP traps can also be retrieved if this is enabled on the device.

## About

### Version Info

| **Range** | **Key Features**                                                    | **Based on** | **System Impact** |
|-----------|---------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version                                                     | \-           | \-                |
| 1.0.1.x   | \- Layout changed. - multipleGetBulk is now used.                   | \-           | \-                |
| 1.0.2.x   | \- Added minimum required version.- Removed multipleGetBulk option. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values on the device, by default *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### Main

This page contains the following parameters: **Version**, **SNMP** **Trap** **Addresses**, **HTTP** **Proxy**, **Number of Inputs**, **Number of Outputs**, **Audio Input**, and **Audio Stream**.

In addition, two tables are displayed: **Monitor Control** and **Layout Definition**.

### Input & Output

Four tables are available on this page: **Source Definition**, **Source Programs Definition**, **Source Management Fault**,and **Output Definition**.

### Video

This page displays two tables: **Video Stream Management Fault** and **Video Stream Definition**.

### Audio

This page displays three tables: **Audio Stream Management Fault**, **Audio Stream Channel Management Fault**,and **Audio Stream Channel Definition**.

### Traps Notification

This page displays the **Alerts** table (implemented as trap receiver table) and the **Source Changes** table. All traps are parsed in the Alerts table, with the exception of the *sourceChanged* trap, which is logged in the Source Changes table.

With the **Clear All** buttons, you can erase the entire content of each of the tables. With the **Clear Ok** button, you can clear all clearable (Ok) rows in the Alerts table.

The **Auto Clear** page button allows you to automatically remove rows based on the number of rows and the age of the received SNMP traps.

### Faults

This page contains the **Faults Table**, which displays the current status of each possible fault retrieved via SNMP traps. The indexes of this table are obtained from the **Source Definition** table and represent the sources monitored by this device. Each column of this table represents a specific fault. For example, the column Video Black represents the traps *faultVideoBlackFalse* (1.3.6.1.4.1.6827.50.297.5.0.1000) and *faultVideoBlackTrue* (1.3.6.1.4.1.6827.50.297.5.0.1001). To avoid alarms being stuck in this table, every time the element is restarted, the columns representing the faults will be set to "N/A".

In version 1.0.0.4, an extra column, **Input in Use**, is added to the Faults Table, which can be set to *Yes* or *No*. This makes it possible to apply conditional monitoring to the Faults Table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
