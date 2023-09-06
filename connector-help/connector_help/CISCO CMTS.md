---
uid: Connector_help_CISCO_CMTS
---

# CISCO CMTS

The **CISCO CMTS** is an **SNMP** connector. It is used to poll data from the CMTS, which manages all data from a usually large number of connected CPEs.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                  | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                                                                  | \-           | \-                |
| 1.1.0.x              | The 1.1.0.x range is a standard range; the 1.1.1.x range has a different index column for tables 22000 and 22500. | \-           | \-                |
| 3.0.0.x \[Obsolete\] | Branch version based on version 1.1.1.41.                                                                         | 1.1.1.41     | \-                |
| 3.0.1.x \[Obsolete\] | Based on version 3.0.0.18.                                                                                        | 3.0.0.18     | \-                |
| 3.0.2.x \[Main\]     | New: DCF Connections available for Gigabit Interfaces Table (PID 24200).                                          | 3.0.1.1      | \-                |
| 4.0.0.x              | Branch for TDC (custom alarm properties).                                                                         | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 3.0.1.x   | 12.2(33)SCH6           |
| 3.0.2.x   | 12.2(33)SCH6           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.1.0.x   | No                  | No                      | \-                    | \-                      |
| 3.0.0.x   | No                  | No                      | \-                    | \-                      |
| 3.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 3.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 4.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.

## Usage

### General

Thispage contains all general device information, such as the **Uptime**, **Name**, **Contact**, etc. It also includes **Cable Modems** summary information and **Upstream/Downstream** capacity summary information.

In addition, you can normalize some parameters and **enable automatic cleaning** for the tables. However, note that this is not available from version 3.0.0.1 onwards, and should then be performed by template instead.

The page contains the following page buttons:

- **Advanced**: Used to manage the Capacity Factor.
- **Power Supplies**, **Processors**, **Physical Info**, **Temperature**, **Fans**: Display information related to each of these topics. From version 3.0.0.2 onwards, each of the polling tables can be enabled or disabled. By default, these tables are disabled. They can be managed on the **Polling Control** page.

### Configuration - Upstream Channels

On this page, a table is displayed where you can configure the **upstream** **channels** of the **CMTS**. From version 3.0.0.2 onwards, this table does not display content by default. You can enable this functionality on the **Polling Control** page.

### Configuration - Downstream Channels

On this page, a table is displayed where you can configure the **downstream** **channels** of the **CMTS**. From version 3.0.0.2 onwards, this table does not display content by default. You can enable this functionality on the **Polling Control** page.

### Measurement - Upstream Channels

This page contains a table with the current values of the **upstream** **channels** of the **CMTS**. From version 3.0.0.2 onwards, this table does not display content by default. You can enable this functionality on the **Polling Control** page.

In addition, some **alarm settings** can be configured.

### Measurement - Downstream Channels

This page contains a table with the current values of the **downstream** **channels** of the **CMTS**. From version 3.0.0.2 onwards, this table does not display content by default. You can enable this functionality on the **Polling Control** page.

In addition, some **alarm settings** can be configured.

### Measurement - Gigabit Interface

This page contains a table with the current values of the **Gigabit Interface** of the **CMTS**. From version 3.0.0.2 onwards, this table does not display content by default. You can enable this functionality on the **Polling Control** page.

In addition, you can configure the **Sliding Window Size.**

### Measurement - Wideband Interfaces

This page contains a table with the current values of the wideband interfaces of the CMTS. From version 3.0.0.2 onwards, this table does not display content by default. You can enable this functionality on the **Polling Control** page.

### Measurement - MAC Layer

This page contains a table with the current values of the **MAC Layer** of the **CMTS**. From version 3.0.0.2 onwards, this table does not display content by default. You can enable this functionality on the **Polling Control** page.

### CM Downstream

This page contains a summary of the CM-related information from the table **Measurement - Downstream**, containing only initialized records.

### CM Upstream

This page contains a summary of the CM-related information from the table **Measurement - Upstream**, containing only initialized records.

### Signal Quality

From version 3.0.0.2 onwards, detailed information related to signal quality is displayed on this page. However, SNMP polling is by default disabled. You can enable this functionality on the **Polling Control** page.

### Flaplist

This page contains a table with the current values of the **CPEs**.

### Interfaces

This page displays the interfaces contained in the CMTS, as well as page buttons that display additional information related to interfaces, i.e. **Extended Information**, **Interface Errors**, **Interface Utilization**, **Cable Modems per Bounding Group** and **Cable Modems per MAC Domain**.

From version 3.0.0.2 onwards, SNMP polling is not enabled by default. It can be managed on the **Polling Control** page. However, the Interface table is always enabled.

### Offload

This page contains settings concerning the **Offload** of the **CMTS**.

### CPE Manager InterOP

On this page, you can enable the functionality to establish interoperation with the **Generic DOCSIS Cable Modem Collector**. An element ID in the format DMAID/ElementID must be provided for this.

### Topology

On this page, you can configure the export of CPE topology information to CSV files. This process creates a set of provisioning CSV files in the indicated directory and is executed by a process button.

The **Topology Provisioning Schedule** table allows you to configure automatic topology file generation by adding entries with the day and time when a topology file should be generated.

If you enable **CM Differences Only**, the cable modems relationship is only created when there are changes or differences between readings.

### Ping Function

This page contains settings related to the **Ping Function** of the **CMTS**. You can also create a **Provisioning File** here.

### Polling Control

On this page, you can manage SNMP polling and determine which table content is displayed. Most of the features of this connector are disabled by default, in order to reduce the load on the CMTS. When a configuration or measurement table is enabled, any polling tables and/or display tables that are required for its functionality will be enabled.

Bitrate calculation mode can be calculated using the values indicated by the utilization table, based on the available capacity configured in the interface. Alternatively, the regular method of octets calculation can be used.

Interface capacity can be set for full bandwidth value or without the known size of header data in order to interpret saturation values for downstream type interfaces. This configuration can be managed on this page.

Finally, you can also force an update of the device interfaces on this page.

### Detailed Interface Info page

On thispage, the interface info is displayed.

Click **XMPL RPC** to retrieve data that is not available on the CISCO device itself, e.g. to retrieve the **IF Speed** from a server. The data will be retrieved via calls to a customized platform.

Via **Measurement Configuration**,you can configure a more detailed Interface.

More detailed information about the incoming and outgoing information can be found on the **Detailed Information Info - Rx** and **Detailed Information Info - Tx** pages.
