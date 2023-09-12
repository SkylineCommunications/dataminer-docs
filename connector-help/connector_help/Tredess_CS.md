---
uid: Connector_help_Tredess_CS
---

# Tredess CS

Tredess CS (Compact Series) is used to ensure the correct functioning of terrestrial and satellite transmitters. Several modules can be plugged into the device, such as the GPS, UCA N+1, UCA, UCA 1+1, DVB-S2/ASI, and IP/ASI module.

This connector retrieves and sets data via **SNMP**. If this is enabled on the device, **SNMP traps** can also be retrieved. The connector exports different connectors based on which modules are plugged in.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                                                                                                                                                   | **Based on** | **System Impact**                                                                                                         |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                                                                                                                                                                                                                                                                                                    | \-           | \-                                                                                                                        |
| 1.0.1.x \[SLC Main\] | Custom display key added to: - Multiplexer Alarms Overview - Multiplexer Configurations - Multiplexer Measurements - GPS Alarms Overview - Contacts Input - Contacts Output - UCA Alarms Overview - UCA N+1 Compact Alarms Overview - UCA 1+1 Alarms Overview New SNMP Control Address Column added to Multiplexer Measurements Table resulting in a change of order in the table. | 1.0.0.6      | DMS filters, Automation scripts, Visual Overview pages, reports, and web API implementations may need to be reconfigured. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 02.M04.2               |
| 1.0.1.x   | 02.M04.2               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                        |
|-----------|---------------------|-------------------------|-----------------------|--------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Tredess CS - Transmitter: exported connector representing transmitter modules. |
| 1.0.1.x   | No                  | Yes                     | \-                    | Tredess CS - Transmitter: exported connector representing transmitter modules. |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: 10.145.1.36
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.
- **Timeout of a single command (ms):** The timeout used when the DMA does not receive a response from the device. The default value is *10000.* This timeout configuration is necessary because the device responds relatively slowly.

## Usage

Because modules can be plugged into the device or removed from it, the possibility to **enable/disable polling** is available for each module. When the state is set to *disable*, no data will be polled for this module. When the state changes to *enable*, data will immediately be polled from the device for the module in question.

### General

This is the default page, which displays **general** information. This includes the **name**, **description**, **versions**, and **admin settings**.

The following page buttons are available:

- **Servers**: Edit **web server** and **NTP server** settings.
- **SNMP**: Edit SNMP settings and general **trap** information.
- **Network**: Edit **default network** settings and **routing table**.

### Polling Control

From version 1.0.0.5 onwards, a **Polling Control** page is available where you can define the polling intervals for the following groups of parameters:

- **General**
- **Network**
- **SNMP**
- **Web Server**
- **NTP Server**
- **MUX Fast**
- **MUX Slow**
- **GPS Fast**
- **GPS Slow**
- **Contacts Fast**
- **Contacts Slow**
- **UCA N+1 Fast**
- **UCA N+1 Slow**
- **UCA 1+1**
- **DVB-S2/ASI Fast**
- **DVB-S2/ASI Slow**
- **IP/ASI Fast**
- **IP/ASI Slow**
- **UCA Fast**
- **UCA Slow**

By default, polling for these groups is enabled, and the polling intervals for these groups are the same as in previous versions of the connector: 10 seconds for fast parameters and 1 hour for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.

Note: Enabling **MUX Slow** or **Fast** enables both parameters since enabling this also enables the DVEs.

### Configuration

This page contains an overview of all the modules for which **polling** can be **enabled/disabled**. The enable/disable parameters are also displayed on each of the corresponding pages.

The page also provides the possibility to **enable/disable** the **automatic removal of DVE elements** for modules that have been removed.

### Multiplexer

This page contains information on the Multiplexer module, for which **polling** can be **enabled/disabled**.

The page contains a table with all the **Transmitter DVE elements**. When data is polled and there is a new module available, it will be added to this table.

In this table, the **description** is a combination of the original description of the module and the original index. In case of a new module, this description will be used as the **name** for the DVE element. It is possible to edit the name of a DVE element in the table, in which case the connector will execute a check before this change is implemented. If the name you want to implement is already in use, the DVE name will remain the original description.

When a module is removed from the device, this will be indicated in the **state column** as *removed*. It is then possible to **delete** the DVE. If you do not delete the DVE and the module becomes available again, the **name** of the DVE will stay the same and the **state** will be updated to *available*. To delete all DVEs that are marked as removed, you can use the **Delete All Removed** button.

### GPS

This page contains information on the GPS module, for which **polling** can be **enabled/disabled**.

The page is used to edit and monitor the **configuration, measurements**, and **alarm overview** for the GPS module.

The following page buttons are available:

- **Trap config**: Enable/disable several **traps** of the GPS module.
- **Alarm config**: Enable/disable several **alarms** of the GPS module.
- **GPS Splitter**: Information concerning the **splitter**.
- **GPS Config**: Settings for the GPS module.

### Contacts

This page contains information on the Contacts module, for which **polling** can be **enabled/disabled**.

The page is used to edit and monitor the **input/output configuration** and **general information** for the Contacts module.

### UCA N+1 State

This page contains information on the UCA N+1 module, for which **polling** can be **enabled/disabled**.

The page is used to edit and monitor **general information**, **priorities**, and **state information** for the UCA N+1 module.

The following page buttons are available:

- **Test**: Contains a table with test parameters.
- **Commutations**: Contains a table with **commutation** information.
- **Priorities**: Priority values for the **UCA N+1 module**.

### UCA N+1 Compact

This page is used to edit and monitor the **general information**, **compact relays multiplexer parameters**, **compact relays priorities**, **compact alarm overview**, and **multiplexer mute** of the UCA N+1 module.

The page contains several page buttons:

- **Mutes**: Contains a table that can be used to **enable/disable** relays.
- **Relays Priorities**: Contains a table with **priority values** for each relay.
- **Relays**: Contains a table with information about the **relays**.

### UCA 1+1

This page contains information on the UCA 1+1 module, for which **polling** can be **enabled/disabled**.

The page is used to edit and monitor **general information**, **multiplexer commutation**, and an **alarm overview** for the UCA 1+1 module.

### UCA

This page contains information on the UCA module, for which **polling** can be **enabled/disabled**.

The page is used to edit and monitor **general information**, check the **alarms overview**, **enable alarms**, **enable traps**, and configure the **alarm level** for the UCA module.

### DVB-S2/ASI

This page contains information on the DVB-S2/ASI module, for which **polling** can be **enabled/disabled**.

The page is used to edit and monitor the **redundancy configuration**, **RF input**, **ASI output**, **control configuration**, and **alarm overview** for the DVB-S2/ASI module.

The page contains several page buttons:

- **Trap config**: Enable/disable several **traps** of the DVB-S2/ASI module.
- **Alarm config**: Enable/disable several **alarms** of the DVB-S2/ASI module.
- **Control**: General information on the **DVB-S2/ASI** module.
- **Redundancy**: Redundancy information for each **input**.

### IP/ASI

This page contains information on the IP/ASI module, for which **polling** can be **enabled/disabled**.

The page is used to edit and monitor the **general configuration**, **I/O configuration**, and **alarm overview** for the IP/ASI module.

The following page buttons are available:

- **Trap config**: Enable/disable several **traps** of the IP/ASI module.
- **Alarm config**: Enable/disable several **alarms** of the IP/ASI module.

### Web interface

This page displays the embedded web UI of the device. The address of the host/web UI is the same as the polling IP of the element.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
