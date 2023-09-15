---
uid: Connector_help_Delta_Power_Solutions_Orion_controller
---

# Delta Power Solutions Orion controller

This connector can be used to monitor and configure the Orion Controller from Delta Power Solutions.

It uses SNMP to communicate with the device. In version 1.0.1.x, HTTP is used to retrieve the log file from the system.

Note: This connector **requires .Net Framework 4.0** or higher.

## About

### Version Info

| **Range**            | **Key Features**       | **Based on** | **System Impact** |
|----------------------|------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.       | \-           | \-                |
| 1.0.1.x \[SLC Main\] | HTTP connection added. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v6.60 (Build22)        |
| 1.0.1.x   | v6.61 (Build02)        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device (default: *161*).
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: private).

HTTP secondary connection \[only available on version 1.0.1.x\]

This connector also uses, as a secondary connection, an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *8080*).
- **Bus address**: The proxy server to be bypassed (default: *bypassproxy*).

### Access configuration

In range **1.0.1.x** of the connector, you need to specify the necessary information in the **Access Configuration** section on the **General** page, so that the connector can connect with the device and retrieve data stored in a log file. You need to specify the credentials (username and password), the exact name of the log file (e.g. LOG_Data20Log\_ ) and the number of the log file (e.g. 15).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below. On each page except the General and Alarms page, you can **enable or disable polling**.

### General

This page contains general information about the system, such as the System Name and System Date Time.

You can also check the **Heartbeat Status**, and view and configure the **Heartbeat Interval**. The **Time of the Last Iteration** is also displayed.

With the **Create Inv. Report** button, you can create an inventory report. Page buttons are also available to numerous subpages, related to configuration, IP address, etc.

In range **1.0.1.x only**, this page also contains the settings for the **access configuration**, as mentioned in the "Access configuration" section above.

### Alarms

This page displays various alarm information, including information for urgent alarms, non-urgent alarms, critical alarms, etc. Via page buttons, you can access the Alarm Table, Generic Alarm Table and History Table.

### System Monitor

This page shows information about the system itself, such as the System Voltage, Battery Temperature and System Power.

### Rectifier

This page shows the number of rectifiers, along with rectifier status information. Page buttons provide access to the Rectifier Table, Rectifier Group Table and Rectifier Functions subpages.

### PVC

This page shows the number of PVCs, along with PVC status information. Page buttons provide access to the PVC Table and PVC Group subpages.

### Battery

This page contains general information about the battery. Several page buttons are available that lead to subpages with more detailed information and settings.

### Input Output Event

This page shows the Control Event Table.

## Notes

In version 1.0.1.x, when the element goes into timeout, it will wait until the log file has been retrieved from the device and all the available data in the file has been added in the element. However, for this to work, the necessary settings need to be configured on the General page. See "Access configuration" above. After that, the connector will search for the next 5 files, trying to fetch all the values available. If it has tried to fetch the next 5 files but could not find any value, the normal flow will resume.

**Note**: The connector will only insert the values in the log file if these are available in the Measurement table (on the Measurement subpage of the General page).
