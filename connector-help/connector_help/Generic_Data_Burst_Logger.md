---
uid: Connector_help_Generic_Data_Burst_Logger
---

# Generic Data Burst Logger

The Generic Data Burst Logger will retrieve information from different LAN switch drivers. The data will be displayed in one table, then for each LAN Switch driver a report will be built and saved in the documents page. These reports are then monthly sended via e-mail to a number of selected email addresses.

## About

The Generic Data Burst Logger driver collects data from various other LAN switch drivers. The following data is retrieved: Transmit Rate, Maximum Transmit Rate, Minimum Transmit Rate, Receive Rate, Maximum Receive Rate, Minimum Receive Rate.

This reports are updated at a time interval that can be chosen freely. The fastest possible interval is every 5 minutes.

Every month a report is sent to a number of email addresses that are specified in the connector.

### Version Info

| **Range**            | **Key Features**                                                                                                           | **Based on** | **System Impact**                |
|----------------------|----------------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------|
| 1.0.0.x \[obsolete\] | Initial version                                                                                                            | \-           | \-                               |
| 2.0.0.x \[SLC Main\] | Complete driver refactoring and implement Dynamic Table replacing the standalone parameters displayed in Port status page. | 1.0.0.18     | **Old trend data will be lost.** |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \[Unknown\]            |
| 2.0.0.x   | \[Unknown\]            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the devices is defined in each row of the dynamic table, this connector can poll from several different LAN Switches*.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Configuration

Go to the **Port** **Status** page, and add the different switches you want to monitor.
For each device, enter the **Label**, choose the **Type** of switch from the predefined types, the **Polling** **IP** and the **Polling Instance.**

## How to Use

### Port Status page

The **Port** **Status** page only displays one table, where you can add LAN switches by clicking **Add Row** and defining the **Label**, **Type**, **Polling IP** and **Polling Instance**. Once added the switches the retrieved data for these LAN switches is shown in this table.

In this page you can also define the **Log Speed Period** that defines the period that the log files are updated (reports).

You can also define a csv import file from where you can import the table from the previous version of the connector. To do this you need do define the **Import File Path**, the **Import File Name** and click **Import**.

### Settings page

On the **Settings** page, in the **Log File Settings** you can choose the decimal format (dot or comma) to be included in the Log files.

In the **Mail settings** you can define the list of email addresses to send the report to separated by ";", you can also enter a **Mail** **Subject**, and a **Mail** **Body**.

In the **Send Mail** section you can select the respective label of the device you want to send the report by email form the **Selected Label in Attachment,** clicking in **Send E-mail** it will send an E-mail to all addresses with the selected LAN Switch Log File in attachment**.**

The **Refresh Labels** button is to update the list of available labels in the table if it did not update automatically.

#### Multi-Threaded Timer sub-page

In this sub-page you can check all the debug parameters of the Multi-Threaded timer implemented in the table.

## Notes

The SMTP tag in DataMiner.xml must be correctly configured if you want to receive the emails.
