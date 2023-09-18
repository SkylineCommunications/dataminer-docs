---
uid: Connector_help_Juniper_Networks_QFX3x00
---

# Juniper Networks QFX3x00

This SNMP connector allows monitoring of the chassis and the interfaces for the **Juniper Network QFX3x00** switches.

## About

This connector is a standard SNMP connector that generally does not need any specific user interaction in order to work. After creation, various information is polled from the device and presented on different pages.

However, the connector does have one extra feature that requires user interaction, i.e. the conditional monitoring. With conditional monitoring, the user can set which rows should be monitored or not in certain tables. These settings can be imported or exported (see Configuration section below). Of course, conditional monitoring will only work if an alarm template has been assigned to the element.

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required for this connector.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values from the device. The default value is *private*.

### Configuration of Conditional Monitoring

Conditional monitoring settings can be found on the page **Conditional Monitoring**. In an extra column in the monitored tables of the connector, you can set which rows should or should not be monitored.

These settings can be imported or exported. To import, first set the **Import/Export Folder** and **Select File**, then click **Import File**. To export, click **Export File**, and a new file will be created automatically in the selected folder. Click **Refresh** to add the files available in the **Import/Export Folder** to the **Select File** drop-down options.

## Usage

### Chassis

This page displays information about the chassis, such as box information: **Box Class**, **Box Description**, **Box Serial Number**, **Box Revision**, etc.
You can also find more important information here, such as the **Containers** table and **Contents** table.

The page contains four page buttons that link to other pop-up pages:

- **LED:** Displays the **LED** table, which contains information about the various LEDs on the chassis.
- **Filled Status:** Shows the **State (Filled)** of the containers.
- **Operating Status:** Shows operating info (Temperature, CPU, ISR, DRAM Size, Heap, Memory, State, CPU Load, Up Time info, ... ).
- **FRU Status:** Shows a list of FRU status entries.

### Interfaces

The **Interfaces Table** on this page contains all physical and logical location information of the interfaces. The **Interfaces Additional Object Table** contains additional objects for the interface table.

### Configuration

This page lists information about the configuration of the device and displays a **Configuration Events Table.**

### System Info

This page displays information about the system, such as the **System Name**, **System Contact**, **System Location**, **System Description**, **System Object ID**, **System UpTime** and **System Services**.

### Interfaces Table

The **Interfaces Table** on this page is the standard interface table found in MIB-2 (RFC1213). It lists info about all the switch interfaces.

### IP Table

The **IP Address Table** on this page is the standard IP Address Table found in MIB-2 (RFC1213). It contains addressing information relevant to this entity's IP addresses.

### Conditional Monitoring

This page allows the user to import/export the conditional monitoring settings. Refer to the section "Configuration of Conditional Monitoring" above for more info.
