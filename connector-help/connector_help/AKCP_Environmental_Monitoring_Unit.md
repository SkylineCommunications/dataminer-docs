---
uid: Connector_help_AKCP_Environmental_Monitoring_Unit
---

# AKCP Environmental Monitoring Unit

This device is an **SNMP** probe that can have several sensors attached to it. The selected sensors' parameters will be displayed in a **DVE**.

## About

This connector can be used to poll an **AKCP Environmental Monitoring Unit**. Multiple sensors of different types can be attached to this unit.
The value of the sensors will by default be retrieved every 30 seconds. However, note that this can be adapted using the **Timer Base** parameter.

This connector will export different connectors based on the retrieved data. A list can be found in the section 'Exported connectors' below.

### Version Info

The connector has 2 major ranges, which are not backwards compatible.

| **Range** | **Description**                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version with separate DVEs for sensor types | No                  | No (DisplayColumns)     |
| 2.0.0.x          | Single DVE Type                                     | No                  | No                      |

The 1.0.0.x range contains several tables to show sensor values for:

- Temperature
- Voltage
- Motion

The 2.0.0.x range contains only one table, but supports all sensors, including:

- Temperature
- Power
- Motion
- Smoke
- Humidity
- ...

Both ranges allow the (optional) creation of DVE elements for each sensor.

The suggested range for new installations is 2.0.0.x.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | SP8463                      |
| 2.0.0.x          | SP8463                      |

### Exported connectors

| **Exported Connector**                            | **Description**                                    |
|--------------------------------------------------|----------------------------------------------------|
| AKCP Environmental Monitoring Unit - Temperature | Temperature probes Only supported in range 1.0.0.x |
| AKCP Environmental Monitoring Unit - Voltage     | Voltage probes Only supported in range 1.0.0.x     |
| AKCP Environmental Monitoring Unit - Motion      | Motion probes Only supported in range 1.0.0.x      |
| AKCP Environmental Monitoring Unit - Sensor      | Any sensor probe Only supported in range 2.0.0.x   |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*
  *(Note: sets are currently not implemented, but we nonetheless suggest to enter the correct value for possible future updates.)*

## Usage: Range 1.0.0.x

### General Page

Because the switch table contains sensors of different types, it has been divided into separate tables for each requested type, i.e. **Voltage** and **Motion Sensors**. Each table is displayed on a separate page in the element.

#### Creating DVEs

For each sensor listed in the tables, a DVE can be created. Simply set the **Create DVE** column value to *Yes*, and the new element will be created under the same view as the main element.

#### DVE Settings

You can change how the element handles DVEs:

- **Automatic Removal**: Set to *On* if DVEs should be removed when the row is no longer present in the SNMP table's response. These rows are marked *Removed* in the **State** column. **Default**: *Off*.
- **Automatic Creation**: Set to *On* if DVEs should be created when a new row is added in the SNMP table's response. The value in column **Create DVE** will be set to *Yes* for these new rows. **Default**: *Off*.

### DVE Tables

A page button opens the **DVE Tables** page. This page contains the DVE tables for all 3 sensor types.

### DVE Naming

Next to the **Create DVE** column is the **DVE Name** column. The value in this column is initially the **Sensor Description**, but if that value is empty, the name will be replaced by the name of the main element with "DVE" as a suffix. To change the DVE name, edit the entry in the table, or use the same parameter found in the DVE at the right-hand side.

Since element names have to be unique, if a name is entered, it will be adjusted with a suffix if necessary. This also happens when identical **Sensor Descriptions** are used when sensors are added to the table.

#### Adjusting Alarm Descriptions

As long as no DVE is created, if a sensor is being monitored, it will create an alarm as follows:

- Element name - Name of the main element
- Parameter description - \[Column Name\] \[DVE Name\]/\[row index\]

For example: *SensorProbe* \| *Status - SwVoltage* *CH 27 Tx/0* \| *N/A*

When a DVE is created, however, the alarm will be:

- Element name - DVE Name
- Parameter Description - \[Column Name\]

For example: *CH 27 Tx* \| *Status - SwVoltage* \| *N/A*

To adjust a **parameter description** in the Alarm Console, use the *Parameter Names* tab under *Settings...* in the right-click menu of **Element Display**. Only the Status and Temperature can be monitored, so these are the values you might want to change. Please note that these will not change the parameter descriptions inside the DVEs, and inconsistent names will be displayed. e.g. *CH 27 Tx* \| *Voltage Status* \| *N/A* if *Status - SwVoltage* is changed to *Voltage Status*.

### General page on DVE

All generated DVEs only have one page: **General**.
This page contains the **Status** and the **Value** of the sensor.
The DVE name parameter will also be available, making it possible to rename the DVE element there.

## Notes

Temperature alarm levels are estimated for a healthy industrial environment. A *sensor error* status by default triggers a **Minor** **Alarm**.

## Usage: Range 2.0.0.x

### General Page

This page contains the **Sensor Table**, which lists all active ("online") sensors, providing amongst others the following information:

- **Description**
- **Value**
- **Unit**
- **State** (as reported by the device.)

Alarm monitoring is both possible on the unit and on the state column. (Alarm monitoring on only 1 column is suggested.)
See also "Defining Alarms*"* at the end of this document.

Notes:

- With the context menu you can force an immediate refresh.
- The format of the alarm naming is set to: *\[TYPE\] Sensor: \[DESCRIPTION\] (#\[ID\])*
  where: *\[TYPE\]* is the content of the **Sensor Type** column, *\[DESCRIPTION\]* is the content of the **Sensor Description** column and *\[ID\]* is the key of the row.

#### Creating DVEs

For each sensor listed in the tables, a DVE can be created. Simply set the **Create DVE** column value to *Yes*, and the new element will be created under the same view as the main element.

It is also possible to do this using a context menu. You can:

- Select the desired sensors, right-click and select *Create DVE.*
- Use multiple set for all sensors in all elements at once.

### DVE Naming

Naming occurs in a similar way as in the 1.0.0.x range. It is possible to set the DVE name in the **Sensor DVE Name** column, and when the name already exists, a suffix will be added to it. E.g. "*Temperature Sensor (1)*".

The default name is the same as the naming key for the row, except that the ": " is replaced by " - " (because colons are not allowed in element names). An example of a default DVE name could be: "*Smoke Sensor - Smoke Detector Port 1 (#30)*".

### General page on DVE

All generated DVEs only have one page: **General**.
This page contains the **Status** and the **Value** of the sensor.
Renaming is only possible in the main element, by means of the **Sensors Table**.

## Notes

### Defining Alarms

The advised alarm strategy is to monitor the **Sensor Value** parameter and to use filters in order to set different thresholds per sensor type.
For example:

