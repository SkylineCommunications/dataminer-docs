---
uid: Connector_help_Evertz_MVP-DEC32-4-IP
---

# Evertz MVP-DEC32-4-IP

This connector is used to monitor **Evertz** **MVP-DEC32-4-IP** decoders, which can decode 32 IP streams in total.

## About

All data is retrieved using a single SNMP connection.

The connector can export DVE elements that display information for each stream and stream-related data.

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

On the main element, this page provides an overview of the available streams. On a DVE element, this page contains stream-related data and settings.

Use the page buttons to access settings for stream faults and notifications.

### Video

This page contains a table with all video streams and a table with all possible faults.

The most important column here is **Video Stream Fault Present**, which can either be *Yes* (if there is a fault) or *No*.

### Audio

This page contains a table with all audio streams and a table with all possible faults.

The most important column here is **Audio Stream Fault Present**, which can either be *Yes* (if there is a fault) or *No*.

Click the page button to access a table with all channels for each stream.

### Data Services

This page contains a table with the data services related to the specific stream. This table only contains configuration parameters.

## Notes

### Virtual Elements

It is possible to create a virtual element per stream in the device.

The name of such an element will be the *name of the element (parent) + the name of the stream + the index of the stream in square brackets*.
For example, if the element is called "*Evertz MVP-DEC32-4-IP Backup*" and there is a stream "*DEC8:BNC_P*" then the virtual element will be "*Evertz MVP-DEC32-4-IP.DEC8_BNC_P \[16\]*".
Note that any illegal characters in element names (e.g. ':') will be replaced with an underscore '\_'.

Until version 1.0.0.3, virtual elements were automatically created for all streams. From version 1.0.0.4 onwards, you can select for which streams an element should be created.
Note: when you update from a version older than 1.0.0.4 to a more recent version (1.0.0.4 and higher), or the other way around, all existing DVEs will be removed. This could have an impact on services or visual overviews that use the element IDs to include or select a target.

To create or delete virtual elements, select the row(s) of the stream(s) in the **Streams** table on the **General** page, then right-click to open the context menu and select **Create DVE** or **Remove DVE**.
Below this table, the page button **Virtual Elements ...** can be used to open a page listing all created virtual elements. In this table, you can also see the name and the element ID of those elements.
Note that renaming elements can be done by renaming the streams on the device, in the **Streams** table.

Update 1.0.0.3 to 1.0.0.4

When updating from version 1.0.0.3 (or earlier) to version 1.0.0.4 or later, there may be some problems with the DVEs. It can occur that not all 'old' dynamic virtual elements are properly removed. Some of these unremoved elements may be in stopped state, while others are active. It will not be possible to open these elements and if there are any such elements, the new element may not start polling.

To solve these problems, a DataMiner restart may be required. However, you may be able to avoid the DataMiner restart by using the following procedure:

If you upgrade from version 1.0.0.3 (or lower) to 1.0.0.4 (or higher):

1. Pause all elements using this protocol.
1. Change the main element to use the new version.
1. Start the element.
1. Wait until all DVEs have been removed.
1. Restart the element.

If you downgrade to 1.0.0.3 or lower:

1. On the **General** page, click the **Virtual Elements ...** button.
1. On the pop-up page, select all the rows in the **DVE Table**.
1. Right-click the rows and select **Remove Virtual Elements**.
1. Change the protocol version.
