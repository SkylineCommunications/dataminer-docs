---
uid: Connector_help_Ceragon_Networks_Netmaster
---

# Ceragon Networks Netmaster

Ceragon Netmaster is a Network Management System offering centralized operation and maintenance capability for a range of network elements. This connector focuses on monitoring alarms provided by this NMS.

As this NMS monitors several devices, for a better representation of the alarms per device, this connector can generate a **Dynamic Virtual Element (DVE)** for each device monitored by the NMS. The list of the devices is available in the Entity Physical table (OID: 1.3.6.1.2.1.47.1.1.1). DVEs are not exported automatically; instead, the user can decide for which elements a DVE should be created.

## About

Information is polled from the device via SNMP. The connector is also able to process the following SNMP traps:

- netmasterAlarmTrap (1.3.6.1.4.1.2378.1.2.1.0.1)
- netmasterHeartBeatTrap (1.3.6.1.4.1.2378.1.2.1.0.2)
- netmasterShutdownTrap (1.3.6.1.4.1.2378.1.2.1.0.3)
- netmasterHWInventoryChange (1.3.6.1.4.1.2378.1.2.1.0.4)
- netmasterSWInventoryChange (1.3.6.1.4.1.2378.1.2.1.0.5)

### Version Info

| **Range**            | **Description**                     | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                    | No                  | Yes                     |
| 1.0.1.x              | Adaptation based on change request. | No                  | Yes                     |
| 1.0.2.x (Obsolete)   | Added Redundancy Status table.      | No                  | Yes                     |
| 1.0.3.x \[SLC Main\] | Modified Redundancy Status table.   | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | R14 Rev. A04           |
| 1.0.1.x   | R14 Rev. A04           |
| 1.0.2.x   | R14 Rev. A04           |
| 1.0.3.x   | R14 Rev. A04           |

### Exported connectors

| **Name**                            | **Range** |
|-------------------------------------|-----------|
| Ceragon Networks Netmaster - Device | 1.0.0.x   |
| Ceragon Networks Netmaster - Device | 1.0.1.x   |
| Ceragon Networks Netmaster - Device | 1.0.2.x   |
| Ceragon Networks Netmaster - Device | 1.0.3.x   |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device Address**: The bus address of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Configuration of the element properties

The element's custom properties **Client Id** and **MHA Identifier**need to be created as soon as the main element is created, so that the values from the provisioning file can be filled in.

### Configuration of DVEs.

To create DVEs, go to the **General Information** page. On this page, the **Device Table** lists the devices that were retrieved from the system. To create a DVE corresponding to a particular device, change the **Device View** to an existing view, and change the **Device Name** to a custom name. Then click the toggle button to set **Device Creation State** to *Created*. If the column **Device View** is not filled in, the element will be placed in the root view.

Alternatively, you can also create all DVEs at once, using the **Create All Devices** button.

## Usage

### General

This page displays general information, such as the **Description** of devices found in theNMS.

It displays the **Connection Redundancy Status** table, which shows the current redundancy status of both element connections and gives an overview of what polling address is currently in use, in standby or unreachable.

It also allows you to **create or remove** **DVEs**, or to set the parameters for removal of DVEs for elements that are no longer detected by the system.

### Physical Entities

This page displays information about the **Systems** that are detected in the NMS.

It shows information such as **Description**, **Name**, **Serial Number**, **Alias**, etc.

### Hardware Inventory

This page displays information about the **Hardware** that is detected in the NMS, including **Resource**, **Article Code**, **Serial Number**, **Revision**, etc.

It also displays how long ago the **Hardware Inventory** was last updated.

### Software Inventory

This page displays information about the **Software** that is detected in the NMS, including **Resource**, **Name**, **Memory Bank**, etc.

It also displays how long ago the **Software Inventory** was last updated.

### Alarms (range 1.0.0.x)

This page displays information about the alarms that are detected in the NMS, via traps or via SNMP polling. This includes information such as **Event Alarm Time**, **Object Name**, **Native Probable** **Cause**, etc.

It also displays how long ago the **Software Inventory** was last updated.

### Alarms (range 1.0.1.x)

This page contains two alarm tables:

- **Alarms Table**: Displays information about the alarms detected in the NMS, via traps or via SNMP polling. This includes information such as **Event Alarm Time**, **Object Name**, **Native Probable** **Cause**, etc. The index of this alarm table uses the alarm index from the traps.
- **New Alarms Table**: This table is similar to the Alarms Table; however, the index of this table uses a combination of two bindings from Ceragon alarm traps. The bindings are combined as **\[netmasterAlarmResourceDisplayName/netmasterAlarmNativeProbableCause\]**.

### Debug

This page displays information about which DVEs have been exported, including the **Export Custom DVE Name**, the **DVE View**, etc.

### Provisioning

This page contains the following parameters:

- **Provisioning File Format**: Displays the format that should be followed when the structure of the CSV provisioning file is created.
- **CSV File Name Path**: Allows you to enter a valid path for the CSV file.
- **Import File:** Button that can be used to execute the provisioning.
- **Import File Status**: By default, if no operation has been executed, the status is set to *Not Busy*. After the Import File button is clicked, either *Success*or *Failed*will be displayed as the final state for the provisioning operation.
- **Import Report:** Displays how many rows are in both the Device Table and the CSV file. Also confirms how many rows have empty values for both the Client Id and MHA Identifier properties, and, in case of a mismatch in the number of rows, displays the rows that are missing in the Device Table and present in the CSV file or vice versa.

### Web Interface

This page opens the web interface of the NMS. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
