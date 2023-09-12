---
uid: Connector_help_Generic_Data_Burst_Logger
---

# Generic Data Burst Logger

The Generic Data Burst Logger will retrieve information from different LAN switch drivers. The data will then be sent in a report to a number of selected email addresses.

## About

The Generic Data Burst Logger driver collects data from various other LAN switch drivers. The following data is retrieved: Transmit Rate, Maximum Transmit Rate, Minimum Transmit Rate, Receive Rate, Maximum Receive Rate, Minimum Receive Rate.

This information is received at a time interval that can be chosen freely. The fastest possible interval is every 5 minutes.

Every 3 months a report is sent to a number of email addresses that are specified in the driver.

## Installation and configuration

### Creation

This driver uses a Simple Network Management Protocol (SNMP) connection and needs the following user information:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Configuration

Go to the **Port** **Status** page, and add the different switches you want to monitor.
For each device, enter the **Label**, choose the **Type** of switch from the predefined types, the **Polling** **Port**, and the **Log** **Speed**.

## Usage

### Port Status page

The **Port** **Status** page only displays one table, where you can add a LAN switch as described in the Configuration section. The retrieved data for these LAN switches is also shown in this table.

### Settings page

On the **Settings** page, you can choose the decimal format (dot or comma), and the list of email addresses to send the report to. You can also enter a **Mail** **Subject**, and a **Mail** **Body**.

Underneath this, there is a page button, **Send Email.,** that will open a pop-up page where you can choose an attachment.

To send an email manually rather than automatically, click the **Send** **Email** button.

## Notes

N/A
