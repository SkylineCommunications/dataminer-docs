---
uid: Connector_help_Kentrox_72771_DataSMART_MAX_T1_Multimedia_Access
---

# Kentrox 72771 DataSMART MAX T1 Multimedia Access

The DataSMART T1 MAX Quad-Port handles complicated voice, video, and data integration applications. It allows up to four departmental routers to connect to the network, and multiplexes voice, data and video. Some key features are SNMP Management, optional Ethernet connection for SNMP and Telnet management, front panel LCD, and LEDs for setup and troubleshooting. It is a software-selectable data port for flexibility (V.35 and EIA-530). It supports leased-line, internet, frame relay, and frame-based SMDS/ATM DXI network services.

This driver was designed to work with the Kentrox model 72771 DataSMART MAX T1. It allows users to display and configure all available parameters, by means of serial communication (Telnet).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range**   | **Supported Firmware** |
|-------------|------------------------|
| 1.0.0.x1.31 | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

## How to use

The element created with this driver consists of the data pages detailed below.

### Login

This page displays the connection state.

### Alarms

This page contains alarm configuration menu parameters. It also contains a table with **Alarm History Report** information.

### System

This page allows you to configure system device parameters such as the Name, Device Date, Device Time, Device Address and Device Clock Source. The **Default Reset** option allows you to return the device to the default manufacturer settings. **Zeroes ALL** resets all counters to zero. You can also enableor disable the Front Panel and DataSMART Compatibility.

In addition, this page also displays system status information.

### Ports

This page allows you to configure control port and data port settings.

Note: Be careful with the Character Echo command, because this can break the communication with the device.

### Interfaces

This page allows you to configure terminal interface and network interface settings.

### Management

This page allows you to configure the IP addresses and netmask, IP/SLIP addresses, community strings, the IP Address Screening List, the Trap Destination IP Address Screening List and the Telnet password.

### Access and Passwords

The page allows you to configure the device password and the access level parameters.

To configure a new password:

1.  Enter the new password in the **Password** box.
2.  Select the access level for the password in the **Access** drop-down box.
3.  Click the **Add New Pwd** button.

The passwords and corresponding access levels are stored in the Password and Access Table. In this table, you can:

- Retrieve the privileges for a password with the **Get Privileges** button.
- Delete a password with the **Delete** button.

The **Delete All** option allows you to delete all the entries from the Password and Access Table at once.

### Maintenance

This page allows you to select the local loopback and remote loopback settings, as well as set the test commands.

### Fractional T1 A/B Configuration

These two pages are very similar, allowing the allowing the configuration of network interface channels mapping, DS0 lines port assignment, and network interface channels assignment to Terminal Interface (data or voice) or IDLE.

For the **DS0 Lines Port Assignment A/B**, use the following syntax:

- For a single channel, just use the number of the channel (for example 11).
- To specify a range of channel numbers, use a dash (for example 2-8). Specify one range at a time.
- For a series of odd or even numbers, separate the numbers with a comma (for example 2,4,6,8 or 1,3,5,7).

### User NI Performance/User TI Performance/Carrier NI Performance/Far End PRM Performance Reports

These pages display both short and long versions of the relevant report. They each also include a parameter that allows you to enable polling for this report. By default, this polling is disabled.

### NI/TI Statistical Reports

These pages can display the "Cleared" and "No Cleared" versions of the Network Interface Statistical Performance Report (NI) or the Terminal Interface Statistical Performance Report (TI). are displayed on this page. They each also include a parameter that allows you to enable polling for this report. By default, this polling is disabled.
