---
uid: Connector_help_SeaChange_Spot_TSI
---

# SeaChange Spot TSI

The **SeaChange Spot TSI** makes it possible to monitor a Microsoft server, process log files and create very elaborate filters to generate alarms based on the lines of this logging.

## About

The Spot TSI connector periodically polls a TSI server to retrieve status information about the health of the SeaChange services. This happens every 30 seconds by default, and is done using WMI, parsing of SeaChange log files over a Windows administrative share, and receiving SNMPv2c traps from Transport Stream Insertion Logfile Monitor (ref:9 Transport Stream Insertion Logfile Monitor). This data is used to verify the operation of the TSI server within a SeaChange Spot system.

## Installation and configuration

### Creation

This connector uses multiple connections.

It uses a Simple Network Management Protocol (SNMP) connection to receive traps, and needs the following user information for this:

**SNMP Connection:**

- **IP address/host**: The IP that traps will be received from.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: N/A
- **Set community string**: N/A

The connector also uses a serial connection, for which it needs the following user information:

**SERIAL CONNECTION:**

- **IP Address/host:** The polling IP of the server you wish to poll with **WMI.**
- **IP Port:** The IP port of the device - Not required.
- **Bus Address**: The bus address of the device - Not required.

## Usage

### General Page

This page provides a quick overview of the system status. This includes parameters such as the **Total Processor Load, Total Processes, Memory parameters**. The page also contains the **WMI** **Credentials** necessary for addressing the server through WMI, and **Remote** **Credentials** in order to access log files over a network.

Note:

- If all log files will be present on the local server, then the Name can be left blank.
- If files are retrieved from a remote server, it is important that the same credentials work on the local server and all remote servers.

### Log File

This page provides an overview of the configured **filters** used to process log files, and the **current** **alarm state** of each filter. You can add a filter by means of the **Add Filter** page button.

The **Export/Import** page button leads to a page where the current configuration can be **exported** into a .csv file or where configurations can be **imported** from .csv files. For this to work, make sure that the **Path** is filled in with a valid folder path, which ends with the name and extension of the file.

### Task Manager

This page displays the **Task Manager** for this server. It contains **process identifiers, CPU** **and** **memory data.** By default, the connector will not remove deleted processes from the table. However, you can change this by toggling the **Auto Clear button**.

### Service List

This page displays a list of all **Services** present in the server. This includes two columns that combine **service state/status with the start mode**.

### Network Interface

This page contains a table listing all **network interfaces** present in the system and their **Utilisation, Tx, Rx** and **Total Speed.**

Note: If some rows do not get filled in, a manual description will have to be set, chosen from the possible discreet values. Sliding open the very last hidden column (Virtual Key) in the table can give you more information as to what description to link to the specific interface.

### Disk Info

This page lists all **Disks** present in the server, indicating their **Name, Size, Free Space** and **Usage.**

### Trap Monitor

This page displays a **trap receiver table** containing by default up to *500* of the latest received traps. This number can be adjusted using the **Maximum Record Count** parameter.

## Notes

No additional notes.
