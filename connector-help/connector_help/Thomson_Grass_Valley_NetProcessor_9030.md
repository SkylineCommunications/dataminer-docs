---
uid: Connector_help_Thomson_Grass_Valley_NetProcessor_9030
---

# Thomson Grass Valley NetProcessor 9030

The **Thomson Grass Valley NetProcessor 9030** is a solution that offers multiplexing, remultiplexing, PSI/SI processing, data injection, and scrambling of hundreds of services received and delivered over DVB ASI and telecom interfaces.

## About

The connector is intended to be compatible with the NetProcessor 9030 and NetProcessor 9010. It uses SNMP to monitor and supervise all the relevant parameters.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 2.0.0.x          | New firmware    | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | 04.21.009 CG                |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION

- **IP address/host**: The IP address of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when reading values from the device, by default *private*.

## Usage

### General

This page contains general parameters: **Device Name**, **Description**, **IP Address**, **Serial Number**, **Software Version**, **MIB Version**, **Alarm Update Time**, **System Alarm Status**, **Last Configuration Status**, **Last Update Time**. It also contains a **Reboot** button.

In addition, there are 4 subpages that can be opened via page buttons:

- *Option*: Displays the **Option Information Table**.
- *Interface:* Displays the **Interface Table**.
- *Config*: Displays the **Configuration Table**.
- *Board*: Displays the **Board Table**.

### Alarms

This page displays the **Alarms Table** and **Service Alarms Table**. It also contains the parameters **Last Trap Number** and **Previous Trap Number** and a **Clean Up Config** page button.

#### Service Alarm Table

This table displays the same information as the Alarms Table, but the alarms are grouped by label.

The **Cleared Service Alarms** toggle button determines whether cleared events are displayed in this table or not.

Note: If cleared alarms are set to ***hidden***, then the table will not store these alarms. Setting this option back to ***visible*** will not show previous cleared alarms, only new cleared alarms form that point onwards.

#### Clean Up Config

The automatic cleanup of cleared service alarms can be configured on this subpage.

The **Clean Up Alarms** button can be used to manually start a cleanup job.

The following settings can be configured:

- **Service Alarm Cleanup Method:** The method that is used to determine when cleanup is needed.

- *Row Count*: Cleanup will start when the number of alarms in the table is greater than the **Max Service Alarms.**
  - *Alarm Age*: An alarm will be removed when it is older than the **Max Service Alarms Age.**
  - *Combo*: Both of the above methods will be used to automatically clean the service alarm table.

- **Max Service Alarms:** The maximum number of alarms allowed before cleanup starts (only with *Row Count* or *Combo*).

- **Max Service Alarms Age**: The maximum age of an alarm before it is removed (only with *Alarm Age* or *Combo*).

- **Service Alarm Cleanup Amount**: The number of alarms that will be removed at once (only with *Row Count* or *Combo*).

Note**:** If cleared alarms are ***hidden***, there will be no automatic cleanup.

### Events

This page displays the **Events Table**. It also contains the parameters **Last Trap Number** and **Previous Trap Number**.

### Manager

This page displays the **Manager Table**.

### Routing

This page displays the **Routing Transport Stream Table**.

### MPEG

This page displays the following tables:

- **MPEG Transport Stream Info Table**
- **MPEG Transport Stream Service Info Table**
- **MPEG Transport Stream Component Info Table**

It also contains three parameters: **TS Related Physical Interface Index**, **TS Info Index** and **TS Service Info Index**. If one of these parameters is updated, the corresponding table will be updated as well.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
