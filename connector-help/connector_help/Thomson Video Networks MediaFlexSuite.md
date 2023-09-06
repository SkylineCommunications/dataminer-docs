---
uid: Connector_help_Thomson_Video_Networks_MediaFlexSuite
---

# Thomson Video Networks MediaFlexSuite

This is an SNMP driver that allows you to monitor the parameters and tables in the MediaFlexSuite management system.

For each device in the system, a DVE can be created, which provides an overview of all information related to this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

## Configuration

### Connections

SNMP Main connectionThis driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the data pages detailed below.

### General

This page displays the general information of the device manager. At the top of the page, you can find the polling configuration. This allows you to enable or disable the fast polling and slow polling of the tables.

Below the configuration section, you can find the **Element Table**. This table contains all the available devices in the network. Device names, descriptions, statuses, types, functions, and states are displayed in this table for each device entry. With the button **Refresh Device Table,** you can manually update this table immediately. Below the Refresh Device Table button, there are 4 buttons that each open a page with a table.

Below that, you can disable/enable a DVE for one single device, or you can enable/disable DVEs for all the devices at once. For each created DVE, an entry is added in the **Dynamic Virtual Element (DVE) Table** and a DVE is created under the same view as that of the main element.

### Alarm

This page displays a table that contains the general alarms. Above the table, you can enable/disable polling and configure the polling time. Whenever a trap is received, the table will be polled.

### Events

This pagedisplays the General Event Table. At the top of this page, there is a button that retrieves the information for this table. The table is also polled whenever a trap is received.

## Notes

Each DVE child element of this driver has a General page and Alarm page. Only the information that is relevant to the DVE will be shown on these pages.
