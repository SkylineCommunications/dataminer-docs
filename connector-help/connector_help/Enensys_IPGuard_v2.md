---
uid: Connector_help_Enensys_IPGuard_v2
---

# Enensys IPGuard v2

The Enensys IPGuard v2 is a unique, secure solution that enables 1+1 automatic redundancy of IP streams with bypass mechanism.

## About

IPGuard v2 is a switching module from Enensys that provides 1+1 redundancy of any equipment that delivers TSoIP or IP streams or any IP network used to transport those IP streams. This connector allows you to completely monitor, configure, and control the device, and allows advanced alarm monitoring and trending mechanisms.

### Version Info

| **Range**            | **Key Features**      | **Based on** | **System Impact**                                                                                   |
|----------------------|-----------------------|--------------|-----------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.      | \-           | \-                                                                                                  |
| 1.0.1.x \[SLC Main\] | New firmware.         | 1.0.0.9      | \-                                                                                                  |
| 1.0.2.x \[SLC Main\] | Override Timeout DVE. | 1.0.1.5      | Timeout alarms might get stuck on (function) DVEs when you upgrade to or downgrade from this range. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.1                  |
| 1.0.1.x   | 2.10.0                 |
| 1.0.2.x   | 2.10.0                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private.*

## How to Use

### System

This page displays generic system information, such as the **name**, **type**, **location**, **serial number**, **firmware version**, **system date and time**, **last update time**, and **update address**. It also contains the **device temperature** and **GPS status**.

Three page buttons provide access to the **Network Information** config table, the generic **Options** table, and the **Date and Time** configuration, including NTP server settings.

Finally, the page also contains a set of control buttons:

- **Blink LED**: Blinks the front LED to allow identification of the device.
- **Reboot**: Reboots the device
- **Factory Reset**: Resets the entire device to its factory state.
- **Network Reset**: Resets only the network configuration.
- **Non-Network Reset**: Resets the entire device to its factory state, except for the network configuration.

### General

This page allows you to monitor and control the main operation of the device. At the top of the page, you can find the **bitrate summary** in Mbps for both input and output interfaces. Below this, the page allows you to configure numerous settings, such as **interface names**, **peering**, **redundancy type**, **inputs**, **outputs**, and **passthru mode**.

### IP Streams

This page contains information on the IP streams. It contains a tree control with one entry per existing IP stream. When you select an IP stream, you can immediately monitor the main state of the stream, including the following information: the **selected input**, **number of switches from IP1 to IP2** and vice versa, and **IP1** and **IP2 bitrates**. Below these parameters, two tabs are displayed, containing **general** and **switching conditions.**

You can also navigate through the tree control and go directly to each branch, visualizing data as standalone parameters instead of table rows.

From version 1.0.0.6 onwards, you can also configure the IP Stream display key format.

### TS Streams

Similar to the IP Streams page, this page contains a tree control that can be used to visualize and modify any stream on the device. When you select a TS stream, the main parameters are displayed, such as **IP1 and IP2 bitrates**, **delay between IP1 and IP2**, **delay applied to IP1 and IP2**, **selected input**, **number of switches from IP1 to IP2** and vice versa, IP1 and IP2 **total packets**, **packets recovered**, **protocol type**, **packets lost**, **TS packets**, and **FEC matrix**. Below these parameters, there are three tabs displaying configurable information, i.e. **general**, **FEC management**, and **switching conditions**.

You can navigate through the tree control to directly access each page. Selecting the **Switching Conditions** node also displays a set of tabs, which provide a faster and more personalized access to **ETR1**, **ETR2**, **ETR3**, **MIP**, **T2MI**, **Bit Rate**, and **Advanced** configuration.

From version 1.0.0.6 onwards, you can also configure the TSoIP Stream display key format.

### Summary

Similar to the summary page of the device's web interface, this page allows you to quickly check both the **settings** and the **monitoring** status of every existing stream.

### Alarms

This page contains the **Current Alarms** table and contains two page buttons that allow access to the **Alarm Configuration** table and **Log Table**.

From version 1.0.0.8 onwards, you can remove alarms with severity "No Log" from the Current Alarms table. You can do so by setting the **No Log Entries Displayed** parameter to *No*.

From version 1.0.1.3 onwards, you can select the **Current Alarms table** **display key**. You can choose between the formats *Index/Name and Description* (default), *Index/Description*, *Index/Name and Description/Description*, and *Custom Description*.
If you select **Custom Description**, you can define a custom description in the Alarm Table (on the Alarm Configurations subpage) that will be used as the display key for the Current Alarms table. If the **Custom Description column** is **empty** for a specific alarm, the display key will be the default **Index/Name and Description**.

### Polling Configuration

From version 1.0.1.3 onwards, the **Polling Configuration** page allows you to define the polling intervals for the following groups of parameters:

- **System Monitoring**
- **System Configuration**
- **Date and Time**
- **Options**
- **Control Network Interface**
- **General Monitoring**
- **General Configuration**
- **General Outputs**
- **IP Streams Monitoring**
- **IP Streams Configuration**
- **IP Streams Switching Configuration**
- **TS Streams Monitoring**
- **TS Streams Configuration**
- **Summary**
- **Alarms**
- **Alarms Configuration**
- **Log Table**

By default, polling is enabled for these groups and the same polling intervals are used as in previous versions: 10 seconds for fast parameters, 1 minute and 5 minutes for medium parameters, and 30 minutes for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.

### Web interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

DCF is supported in this connector, starting from version 1.0.0.9. DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party protocols (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- An interface is exposed for every row in the **Network Interface Table**. Type: inout.

### Connections

Currently no connections are created by this connector itself.
