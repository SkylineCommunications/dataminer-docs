---
uid: Connector_help_Teleste_EMS
---

# Teleste EMS

The **Teleste EMS** connector monitors a Teleste EMS system unit through **SNMP**.

## About

The **Teleste EMS** connector receives traps from the device and displays them in three tables.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community** **string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### Status Tables Page

This page displays two tables, the **Message Table** and the **Device Name Table**, which contain parameters regarding the trap information sent from the device. You can remove a row from each table by clicking the respective **Remove** button. The **Device Name** and **Message** **Name**, **Description** and **Severity** are obtained from the Alarms Table.

In addition, there is also a parameter displaying the **Maximum Number of Elements**, with a default value of *500*. You can update this parameter to any desired number of elements.

### Tree View Page

This page shows a tree view of the tables on the previous page, where you can scroll through **Device Location** **-\>** **Device IP range** **-\>** **Device Name** -\> **Device Message**. Each node of the tree view has a remove button that will recursively delete all the child nodes.

In addition, there is also a parameter displaying the **Maximum Number of Elements**, with a default value of *500*. You can update this parameter to any desired number of elements.

### Configure Locations Page

This page shows a user-configurable **IP Range Table**, in which you can define multiple **IP Ranges** (for which the connector should accept traps from the device) and **Region Names.** There are three buttons below the table: **Add Rows**, **Clear Table**, and **Update Changes**. After you have changed the IP Range Table, click the **Update Change** button to make sure that the correct tree structure and **Location FK** is updated.

There are also two buttons, **Save CSV** and **Load CSV**, that you can use to easily save or retrieve all the correct **IP Ranges** and **Region Names** at the specified **CSV Location Full Path.**

Note: When loading a CSV file to update the locations, the connector will clear all the saved messages, devices and locations.

### Configure Alarms Page

This page shows a user-configurable **Alarms Table**, in which you can define multiple **Alarms**, for which the connector should accept traps from the device. The **Alarm Text** must be an exact match with the sixth binding from the Teleste EMS trap in order for the connector to accept that particular trap. You can select up to two **Alarm Severities** that a particular alarm trap can generate (two different rows, and two different severities). The Alarm Trap will trigger the highest severity, while the Warning trap will trigger the lowest. The **Alarm Description** will override the description in the trap message and the **Alarm ID** must be a different and unique value for each row. Finally, there are two buttons below the table: **Add Rows** and **Clear Table**.

There are also two buttons, **Save CSV** and **Load CSV**, that you can use to easily save or retrieve all the correct alarms at the specified **CSV Alarm Full Path**.
