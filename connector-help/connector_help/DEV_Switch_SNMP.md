---
uid: Connector_help_DEV_Switch_SNMP
---

# DEV Switch SNMP

The **DEV Switch SNMP** connector is used to display all information for devices supporting the dev-switch MIB. This connector was originally designed for the DEV7113 1:1 (without applied redundancy functionality), but was later extended to a generic version. Depending on the version range, the connector can create a DVE element for every module found in the **Port** table (see "Usage" section below).

## About

The information displayed in the connector is divided over seven pages:

- The **General** page contains general information about the device.
- The **Switch Configuration** page contains the basic switch configuration in two tables.
- The **Ports** page shows all available raw information of every port.
- The **Modules DEV7113 1:1** page translates the information of the Port table into making modules and DVE elements.
- The **Alarms** page contains information and controls related to the device's alarm monitoring.
- The **Surveillance** page contains additional information about the device status and the fan(s).
- The **Web Interface** page contains a link to the interface designed by manufacturer DEV.

### Version Info

| **Range** | **Description**                                                                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                          | No                  | No                      |
| 2.0.0.x          | Branch version based on 1.0.0.xDVE functionality added                                                   | No                  | No                      |
| 3.0.0.x          | Branch version based on 2.0.0.xAdded support for two port modulesExtended the connector to a generic connector | No                  | No                      |

### Product Info

| **Range** | **Device Firmware Version**                                 |
|------------------|-------------------------------------------------------------|
| 1.0.0.x          | Unknown                                                     |
| 2.0.0.x          | Unknown                                                     |
| 3.0.0.x          | A.08 (DEV1951) B.01 (DEV1520) P.01 (DEV7113) Q.03 (DEV2190) |

### Exported connectors

| **Exported Connector** | **Description**                                                                      |
|-----------------------|--------------------------------------------------------------------------------------|
| DEV Switch Module     | 2 port modules are only supported in range 3.0.0.x and only accurate for DEV7113 1:1 |

## Configuration and Installation

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page contains general information related to the device. In addition, the page contains the option to configure the **Control** and **Switch mode** of the device.

Note: It is only possible to change settings via SNMP through DataMiner if the system is in Remote mode.

### Switch Configuration Page

This page contains two additional tables that can be found in the application folder in the dev-switch MIB. For some types of devices (e.g. DEV 7113 1:1), these tables are not relevant. In that case, the tables are not polled, to avoid needless bandwidth use.

The **Switch Group** table is shown on the left. This table is used for the definition of the assignment of switch modules to configured groups, which are used for simultaneous switching applications.

The **Switch Units** table is shown on the right. With this table, the switching status of a switch unit (i.e. switch module) can be checked or altered using the column **Switch Position**. Additionally, the column **Switch Members** indicates which port of the Port Table is part of which switch module. If you double-click a cell, more information on the column in question is displayed.

### Ports Page

This page contains all the raw data of the **Ports table** of the MIB. Exceptions are introduced to inform the user that some columns might not be applicable for the specific device. If you double-click a cell, more information on the column in question is displayed. The **Port Slot** column, next to the index column, shows the slot location of the port.

### Modules DEV7113 1:1 Page

This page should only be used if the connector is used with the DEV7113 1:1 device. As the connector was originally intended to be used with this specific device, the table has been kept, in order to avoid conflicts with older versions of the connector. The information in the **DVE Modules** table is the same as that in the Ports table, except that for the DEV7113 1:1, the two ports belonging together in a module are displayed next to each other.

These modules are then displayed below in a **Slot Table**. With this Slot Table, you can create a DVE element by toggling the cells in the last column. These DVE elements are then created in the same view in the Surveyor and are processed by the exported connector. Even in case another device is used than the DEV7113 1:1, it is possible to create DVE elements. Users that were able to create DVE elements with this connector in a previous version will not experience any loss of functionality.

Since version **3.0.0.8**, it is possible to toggle the **visibility** of the DVEs in the Surveyor by using a button in the **DVE Modules** table (at the rightmost side of the table). This **will not** **delete** the DVE, but just **hide** it or **show** it. Also, the **DVEs are not deleted automatically** when a port is removed compared to the last polling cycle, to ensure that **trending data is not lost** when a module is removed from the equipment and installed again. If necessary, DVEs can be deleted manually. To delete the modules marked as removed, use the **Delete** button at the rightmost side of the DVE Modules table or the **Delete All Removed** button at the top of the page. The entries are synchronized with the **Slot Table**.

### Advanced Switching Page

This page contains all extra parameters of the application folder in the dev-switch MIB that were not displayed on the previous pages. These parameters are related to advanced switching and are only relevant for a specific type of devices of DEV. The parameters and tables of the page are displayed in a box. The polling of these parameters can be enabled/disabled with the toggle button above it. This ensures that the connector does not cause unnecessary network traffic or time-out alarms.

### Alarms Page

The top part of this page, **Alarms Config**, contains the alarm configurations. The four toggle buttons are used to enable/disable the sending of different types of alarm traps. You can find more detailed information about these types by double-clicking the parameter. You can also open a pop-up page with the **Error Alarm Config** button that allows you to further configure the type of error traps sent.

The bottom section of the page contains the alarms that were generated from inside the device, with a timestamp added by DataMiner.

### Surveillance Page

This page contains additional information about the internal/external device and support hardware status. The number of fans and their status are displayed in the **Fan Table**. The external device status might not be applicable. The same applies for the support hardware status.

### Web Interface Page

This page refers the user to the web interface of the device, which is developed by the manufacturer of the device, in this case DEV.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
