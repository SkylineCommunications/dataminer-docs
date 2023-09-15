---
uid: Connector_help_SeaChange_Spot_MVL
---

# SeaChange Spot MVL

The **SeaChange Spot MVL** makes it possible to monitor a Microsoft server, process log files and create very elaborate filters to generate alarms based on the lines of this logging.

## About

The Spot MVL connector periodically polls an MVL server to retrieve status information about the health of the SeaChange services, using parsing of SeaChange log files over a Windows administrative share. By default, this is done every 30 seconds. This data is used to verify the operation of the MVL server within a SeaChange Spot system.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **IP Address/host:** The polling IP of the server you wish to poll with **WMI.**
- **IP Port:** The IP port of the device - Not required.
- **Bus Address:** The bus address of the device - Not required.

## Usage

### General Page

This page provides a quick overview of the system status. This includes parameters such as the **Total Processor Load, Total Processes, Memory parameters**. The page also contains the **WMI** **Credentials** necessary for addressing the server through WMI, and **Remote** **Credentials** in order to access log files over a network.

Note

- If all log files will be present on the local server, then the Name can be left blank.
- If files are retrieved from a remote server, it is important that the same credentials work on the local server and all remote servers.

### Log File

This page provides an overview of the configured **filters** used to process log files, and the **current** **alarm state** of each filter. You can add a filter by means of the **Add Filter** page button.

The **Export/Import** page button leads to a page where the current configuration can be **exported** into a .csv file or where configurations can be **imported** from .csv files. For this to work, make sure that the **Path** is filled with a valid folder path, which ends with the name and extension of the file.

### Task Manager

This page displays the **Task Manager** for this server. It contains **process identifiers, CPU and memory data.** By default, the connector will not remove deleted processes from the table. However, you can change this by toggling the **Auto Clear button**.

### Service List

This page displays a list of all **Services** present in the server. This includes two columns that combine **service state/status with the start mode**.

### Network Interface

The page contains a table listing all **network interfaces** present in the system and their **Utilisation, Tx, Rx and Total Speed.**

Note: If some rows do not get filled in, a manual description will have to be set, chosen from the possible discreet values. Sliding open the very last hidden column (Virtual Key) in the table can give you more information as to what description to link to the specific interface.

### Disk Info

This page lists all **Disks** present in the server, indicating their **Name, Size, Free Space and Usage .**

## Notes

No additional notes.
