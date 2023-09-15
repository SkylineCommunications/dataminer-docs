---
uid: Connector_help_Siemens_Netviewer
---

# Siemens Netviewer

This connector provides an overview of the information from the Siemens Netviewer device, a management system.

## About

The Siemens Netview connector provides an overview of the different network elements connected to the management system. The connector has several pages with general information about the management system and information regarding the status and alarms of the network element.

The connector uses **SNMP** to retrieve data from the device. All data is polled every 30 seconds, except for the alarm table, which is polled every 30 minutes.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private.*

## Usage

### General page

This page displays general information about the management system. This includes the **Equipment Type** and **System Type**, the **Connection Status**, **Connection Severity** and **Connection Last Changed**, the **Severity** and several clocks like the **Internal**, **Reference** and **Delta Clock**.

The **Software Build and Package versions** and the **Software Reorder Code** are also displayed on this page.

With the **DVE Creation Mode** parameter, you can create DVEs directly from the data provided by the device, or from commands from the **Management System**. DVEs for each Radio Link will be created with the respective information and alarms.

### NE Status page

On this page, the network element statuses are displayed in the **NE Status Table**. The columns contain information like the **Connection Status**, **NE Name** and **NE Status**.

The **Number of Network Elements** and **Map Name** can be found above the table.

### NE Overview page

This page displays the **NE Overview Table**, with information about the **Equipment Type and Name**, the **System Type**, the **IP Address**, the **Software Version Release** and the five **Clocks** (Internal Clock, Reference Clock, Reference Clock in seconds, Delta Clock and Delta Clock in seconds) of the network elements.

### NE Alarms page

This page displays the **NE Alarm Table** and **NE Alarm Active Table**.

- The NE Alarm Table has columns containing info about the **Alarm Index**, the **Alarm Additional Text**, the **Alarm Probable Cause**, the **Alarm Panel ID**, the **Alarm Type**, the **Alarm Perceived Severity**, the **Alarm Status**, the **Alarm Operator Name and Type** and the **Alarm Time Stamp**.
- The NE Alarm Active Table has only one column: the **Alarm Active Perceived Severity**.

In addition, you can also find the following information on this page: the **Alarm Active Photo**, the **Alarm Trap Counter**, the **Alarm Trap Filter**, the **Alarm Trap NE Index**, the **Alarm Trap Alarm Index**, the **Alarm Trap Operation Status** and the **Managed NE in the Map Tree**.

### Trap page

This page displays the **Trap Table** , with the **Trap ID**, the **Trap Type**, the **Time Sent** and the thirteen different **Bindings**.

You can also find the **Trap Count** and the **Trap Filter** on this page.

### Trap Utility page

This page displays information about the **Netviewer Server Trap**, like its **Counter**, **Index**, **Log** **Length**, **Mode**, **Manager** **Status**, **Active** **Window**, **Retry** **Time**, **ACK**, **Additional** **Text**, **Alarm** **Type** and **Probable** **Cause**.

### Web Interface page

On this page, you can view the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
