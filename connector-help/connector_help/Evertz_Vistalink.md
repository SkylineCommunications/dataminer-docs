---
uid: Connector_help_Evertz_Vistalink
---

# Evertz Vistalink

With this connector, it is possible to gather and view information from the device **Evertz Vistalink**, as well as to configure the device.

The connector receives traps from product items that are located in the field. For each product, a virtual element is created. One product can have multiple channels that can each send alarm info. The Alarm table displays the alarm states of all channels.

The connector also has an HTTP interface that will gather all the alarms registered on the device as well as the connected hardware and services.

## About

### Version Info

| **Range**            | **Key Features**       | **Based on** | **System Impact** |
|----------------------|------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.       | \-           | \-                |
| 1.1.0.x              | Initial version.       | \-           | \-                |
| 1.1.1.x \[SLC Main\] | Dynamic polling added. | 1.1.0.3      | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                                |
|-----------|-------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | Range based on MIB with NMP traps from July 7, 2016 - no specific version is highlighted in the MIB.  |
| 1.1.0.x   | Range based on MIB with NMP traps from July 21, 2014 - no specific version is highlighted in the MIB. |
| 1.1.1.x   | Range based on MIB with NMP traps from July 21, 2014 - no specific version is highlighted in the MIB. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**   |
|-----------|---------------------|-------------------------|-----------------------|---------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | Evertz Vistalink Hardware |
| 1.1.0.x   | No                  | No                      | \-                    | \-                        |
| 1.1.1.x   | No                  | No                      | \-                    | \-                        |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.220.224.16*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *private*.

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

SERIAL Connection:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.220.224.16*.
- **IP port**: The port of the destination, e.g. *8080*.
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *ByPassProxy*.

## Usage

### Service Summary Page

On this page, an overview is displayed of the different services that are implemented.

### Service Alarms Page

On this page, all the alarms of the services are displayed.

### Product Summary Page

On this page, product summary alarm traps are displayed in the **Product Summary** table. This table contains the following information:

- **ID**: Autonumber of the product trap.
- **Product ID**: IP address of the agent in alarm state that produced the product trap and custom product name assigned to the product in alarm state.
- **Custom Description**: Customized description of the product sending the information. This parameter does not come from the device.
- **Product IP**: IP address of the agent in alarm state that produced the product trap.
- **Product Default Name**: Default name of the product in alarm state.
- **Product Description**: Text description of the product trap.

Product traps can be removed. If you select **Remove All**, all of the product traps will be removed. When a product trap is removed, all corresponding alarms from the channels are removed.

#### Importing data

By clicking **Import Data**, you can upload a .csv file to fill in the product summary table. In order for this to be possible, the .csv file should be placed in the following directory:

*C:\Skyline DataMiner\Documents\Evertz VistaLink\\*

**Note: if there is already an entry in the table with the same index key,** **this** **entry will be ignored.**

#### Exporting data

To export data, right-click a row in the product summary table and select **Export table**. Then choose the location where you want to save the file.

### Product Alarms Page

The **Alarm table** consists of the following columns:

- **ID**: Autonumber.
- **Channel Alarm Description \[IDX\]**: Product Alarm Description \[IDX. Alarm keywords are removed.
- **Channel Alarm Severity**: The trap severity (product alarm severity).
- **Product Manual Alarm Override**: A write parameter that can be used to manually override the severity in the **Channel Alarm Severity** column. As long as this parameter does not have the *Not Used* value, it will ignore new incoming alarm updates for the specific alarm and will keep reporting the manually selected alarm value.
- **Product Manual Alarm Clear**: Automatically overrides the current active alarm to the normal state and then waits for new alarm updates.
- **Product Alarm Received**: Datetime of the last update of the row. The datetime is updated with the time when the last adaptation to the alarm was made, whether that change comes from the device or from an override or clear of the user. The datetime is not received from the device but taken from the machine where the DMA is installed.

The **Clear All** button will automatically clear all alarms to a normal state. When the button is used, the value *Clear* is set to all rows in the column **Product Manual Alarm Clear**, after which the value *Ok* is set to this column. If you set **Minor** to *Product manual alarm override* (the value is different from *Not Used*), and then try to set **Clear** to *Product manual alarm clear*, nothing will happen.

### Alarms Summary Page

This page contains a table with the alarms registered on the device.

The table displays the alarm date and time, alarm description, severity, whether the alarm has already been corrected, whether the alarm has already been acknowledged, the slot, the instance, and the host IP where the alarm was raised.

In this table you can also set an alarm as corrected and as acknowledged.

### Hardware Page

This page consists of a table that displays all hardware connected to the device. In this table, you can specify whether the hardware should create a DVE or not (in range 1.0.0.x only). You can also enable or disable all the DVEs, or enable or disable all DVEs of which the name matches with the string filled in in the parameter **Enable DVEs Name**.

It is also possible to discover new hardware and to remove dead hardware on this page. If there is any new hardware, or if any hardware needs to be removed, the tree control will be updated.

Finally, you can also use the page button **Hard. To Serv.** to assign hardware to a service.

### Services Page

This page displays a tree control with all the services present on the device.

Since the services have a hierarchy structure, the same structure was kept in this tree control.

This page also contains the same page button as the **Hardware Page.**

## Notes

For the web API to work, a license must be requested from Evertz.
