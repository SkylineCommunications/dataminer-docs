---
uid: Connector_help_Generic_Syslog_Receiver
---

# Generic Syslog Receiver

The Generic Syslog Receiver is used to capture and analyze information received via Syslog messages.

Elements using this protocol are **constantly listening** to incoming Syslog messages that are sent from **one or more network devices**. The driver processes these messages and displays the messages in an overview along with the severity. Filtering the incoming messages is possible based on severity or based on specific data in the message. The driver can also be used to trigger specific alarms and to write the messages to log files.

The communication method used is **smart-serial**.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                           | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                                                            | \-           | \-                |
| 1.0.1.x              | Partial attribute added to tables: Received Raw Messages and Message Table.                                                | \-           | \-                |
| 1.0.2.x \[Obsolete\] | Updated sort on messages table. Added Partial attribute to messages table to display 100 rows per page.                    | \-           | \-                |
| 1.0.3.x \[SLC Main\] | Maximum Messages Range updated to 10-10000. Partial attribute added or updated in Received Raw Messages and Message Table. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |
| 1.0.3.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.3.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The IP should be set to the specific keyword *any*. This will make sure the Syslog Receiver takes the Server role.
  - **IP port**: The IP port of the device, by default *514*.

## Usage

### General

This is the default page of the driver. It contains the **Message Table**, which displays all the information of the incoming syslog messages. There are also page buttons to specific subpages for **Priority**, **Layout** and **Raw** **Messages**.

### Alarms

This page contains the **Alarm Configuration** table. In this table, you can create specific alarms configurations based on the incoming messages.

It also contains the **Alarms Table**, which displays an overview of all the generated alarms.

### Log Messages

This page contains a toggle button that can be used to enable or disable the storing of syslog messages in log files. You can also specify the folder where those files will be stored.

### Alert Counter

This page contains the **Alert Counter Table**, which allows you to track the number of incoming syslog messages that match specific search criteria.
