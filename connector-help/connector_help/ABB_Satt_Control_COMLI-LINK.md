---
uid: Connector_help_ABB_Satt_Control_COMLI-LINK
---

# ABB Satt Control COMLI-LINK

This connector makes it possible to monitor and gather information from an **ABB** **Satt Control COMLI-LINK** controller.

## About

COMLI (COMmunication LInk) is an ABB Automation data transmission system for communication between control systems and between control systems and computers.

To fill in the addresses that must be polled, you must import an Excel file. Such Excel files must be placed in the documents folder of the protocol.

All registers are categorized in the following tables:

- Inputs table: all addresses where object type is "A_ALARM", "A_ALARMER", "ALARMER", "ANTPOS", "APTAL", "ANNSIGNAL", "MPG", "PROPAL", "RDS", "SAT" or "VVS" and all of the remaining addresses except for the ones from the Commands table.
- Commands table: addresses where signal is "MANOVER" or starts with "K\_".

Two types of **messages** are supported:

- Read I/O bit (addresses that start with a B).
- Read registers (addresses that start with an R).

**DVEs** are created for each unique combination of **sign** and **service**.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

### Exported Connectors

| **Exported Connector** | **Description**           |
|-----------------------|---------------------------|
| FM Transmitter        | FM Transmitter module     |
| Audio Mux             | Audio Mux module          |
| Generator             | Generator module          |
| Rectifier             | Rectifier module          |
| Environment           | Environment module        |
| Receiver Ball         | Receiver Ball module      |
| Satellite Receiver    | Satellite Receiver module |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus address**: The bus address of the device.

PING SETTINGS:

- **IP address/host:** The IP address used to ping the device's status. This is used to know if the device is actually in a timeout status.

### Configuration

On the **Import** page, select the Excel file with all polling addresses to import, and click the **Import** button. For more information, refer to the "Import" section below.

## Usage

### General

This page contains a table with all the DVEs that have been created, more specifically the Comli devices found in the imported Excel file.

### Inputs

This page provides a table with the current settings defined at the ABB Satt COMLI-Link.

### Commands

This page provides a table with the results of each command address. The value column in this table is writable. Commands can be sent to the device.

### Connection

On this page, you can check the current connection status (**Serial Status**) of the device, along with information (**IP Address**, **Port** and **Bus Address**) concerning the serial connection. The page can also be used to check if the device is reachable via the ping address (**Ping Status**) configured in the element editor.

In version 1.0.0.10 of the connector, the **Reboot UDS button** is added on this page. When you click this button, a confirmation window will appear. If you then confirm the action, the IP of the element is dynamically retrieved and a Telnet connection is established on port 9999. Then option 9 is picked from the Telnet CLI Menu.

In version 1.0.0.11 of the connector, the 'Serial Status' parameter, which is located on the parent element, has alarm monitoring enabled and is exported to the DVEs.

### Import

This page is used to import an Excel file containing all information that is necessary to successfully poll the device.

To import a file:

- Click on the **Refresh Files** button to load the list with Excel files.
- Select the file you want to import, and apply the set.
- Click on the **Import** button.

### Settings

On this page, you can define whether the device should be polled through the current serial connection.

From version 1.0.0.2 onwards, you can also establish DCF connections of the DVEs on this page.

## Notes

For the connector to function correctly, **Microsoft Access Database Engine 2010** must be installed:

<http://www.microsoft.com/en-us/download/details.aspx?id=13255>

Otherwise, the following exception will occur:

\[InvalidOperationException: The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine.\]
