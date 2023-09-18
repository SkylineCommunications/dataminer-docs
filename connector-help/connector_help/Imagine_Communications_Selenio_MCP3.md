---
uid: Connector_help_Imagine_Communications_Selenio_MCP3
---

# Imagine Communications Selenio MCP3

The **Imagine Communications Selenio MCP3** connector can be used to monitor a Selenio 3RU Media Convergence Platform card slotted into a Selenio chassis. This connector lists the important parameters from this controller and provides an overview of all the different slots in the chassis.

## About

### Version Info

| **Range**        | **Description**                                                                                                                                                                                             | **DCF Integration** | **Cassandra Compliant** |
|-------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x                 | Initial version.                                                                                                                                                                                            | No                  | Yes                     |
| 4.0.1.x                 | Updated to firmware 4.0.                                                                                                                                                                                    | No                  | Yes                     |
| 4.1.0.x                 | Updated to firmware 5.0. Cross Connections, Module Association, Module Function, Module Interface, Module Output, Repository, Slot Upgrade, and VLAN pages are functional from this connector version onwards. | No                  | Yes                     |
| \<10.0.0.x \[SLC Main\] | The versioning of the connector is specifically engineered to tie in with the firmware version of the card the connector supports.                                                                                | No                  | Yes                     |
| 10.0.0.x                | Replaced "dynamic snmp get" with "dynamicSnmpGet="true"" under parameter type tag.                                                                                                                          | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                  |
|------------------|------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | 1.0                                                                                                                          |
| 4.0.1.x          | 1.0                                                                                                                          |
| 4.1.0.x          | 5.0                                                                                                                          |
| \<10.0.0.x       | The versioning of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. |
| 10.0.0.x         | Requires controller firmware "S/W=7.0-38, H/W= rev 02" or higher and will not work with older firmware.                      |

## Installation and Timing

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: This is always 0, and as such it is disabled in the configuration screen.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *public*.

### Timing

All data gets retrieved from the device in three ways.

- **Timers**

- **Slow Timer**: Triggers every hour and retrieves non-essential and configurable parameters.
  - **Medium Timer**: Triggers every 10 minutes and retrieves status parameters and the connections table.
  - **Alarm Slow Timer**: Triggers every 30 seconds and retrieves alarm information (see note below).
  - **Fast Timer**: Triggers every 10 seconds and retrieves slot information (state, temperature, protection, etc.).
  - **Very Fast Timer**: Triggers every 3 seconds and retrieves dirty changes, alarm information (see note below), and CPU polling if enabled.

- **Dirty changes**

- Every 3 seconds a check is done for any changed configurable values. If such a change is detected, the new value is retrieved and instantly updated in the element. (If the change concerns a table cell, the complete table is refreshed.) After a change is detected, the check occurs more quickly and is performed every 0.5 seconds until no more changes are waiting to be detected.

- **Traps**

- When enabled and set up on the controller, traps can be sent to DataMiner whenever an alarm occurs. The traps are accepted and processed for the controller.

Note: You can toggle alarm information to be received either every 30 seconds or every 3 seconds. The default value is every 3 seconds. It is recommended to only change this to 30 seconds when you enable traps to be sent to DataMiner.

## Usage

### General Page

This page contains version information and controller status parameters.

The **Processor Usage** page button can be used to monitor the total CPU % of the chassis. This polling is disabled by default but can be toggled on.

### Alarming Page

All possible alarms for the controller are listed on this page. If an alarm is active, the **Controller Alarm State** will indicate what kind of alarm it is.

This page also contains a toggle button to change alarm polling speed between 3 and 30 seconds. It is recommended to set up traps and reduce the polling speed to 30 seconds.

### Slot Table Page

This page provides an overview of all the slots in the chassis and the cards they contain, if any. It also allows you to configure **Failover**, **Failback** and **Slot Protection** and provides the possibility to **Reboot**.

For the MCP1, only the first 3 slots can be used.

### Connections Page

This page contains the **Connections** table, which provides a complete overview of all internal connections made in the chassis. The table displays **interface data, slot data** and currently running **services**.

Using the **Add Connection** page button, you can add additional connections. You can clean invalid connections from the table by clicking the **Remove Invalids** button.

### Cross Connections Page

This page is available from version 4.1.0.1 onwards and displays the cross-connections table relationship, which provides a complete overview of all internal connections made in the chassis.

Using the **Add Connection** page button, you can add additional connections. You can edit connections with the **Edit Connection** button, and clean invalid connections from the table with the **Remove Invalids** button.

### Module Association Page

This page displays the association relationship between interfaces and modules.

### Module Function Page

This page displays the module functionality by module slot.

### Module Interface Page

This page displays the interface information by module.

### Module Output Page

This page displays the input-output routing relationship.

### Repository Page

This page displays the content of the module repository slot use.

### Slot Upgrade Page

This page displays information about the firmware versions, and allows you to manage upgrade tests and activate the upgrade process.

### VLAN Page

This page displays the VLAN table information for the interfaces in the module.

### Module Information Page

This page displays the module map information and allows you to manage the system module slot labels.

### General Section

This section contains information concerning the internal **Modules**, the **Reference** and **TSG**, and allows you to load certain system stored **Presets**.

It also displays the main, controller and slot **power supply status** and allows you to manage the **External SDI**.

### Control Section

This section contains parameters that allow you to enable or disable certain communication protocols, such as **SNMP, FTP, HTTP, SSH, CCSP** and **Telnet**. It also contains three pages for specialized **SNMP**, **GPI** or **Ethernet** settings.

### Redundancy Section

This section contains the **Router** page, which contains information concerning 15 different levels in the router.

### Selenio Controller Page

This page provides access to the internal HTTP portal of the device.

The web interface is only accessible when the client machine has network access to the product.
