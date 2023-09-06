---
uid: Connector_help_Unified_Streaming_Unified_Origin_Monitoring
---

# Unified Streaming Unified Origin Monitoring

The purpose of this driver is to monitor the health of the different channels within the Unified Origin software.

## About

### Version Info

| **Range**            | **Key Features**                                                                             | **Based on** | **System Impact**               |
|----------------------|----------------------------------------------------------------------------------------------|--------------|---------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                                             | \-           | \-                              |
| 1.0.1.x \[SLC Main\] | \- Endpoint Channel Error table added.- Stream Key, Poll Delta Time and Error columns added. | 1.0.0.1      | Changed displayed column order. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To start polling channel data, right-click the **Endpoint Configuration** table, and select one of the following options in the context menu to specify the channels to poll:

- **Add new row**: If you select this option, you will be able to define the **Channel Name** you intend to poll data from, the **Polling Speed**, the **Channel State** and the **Multiple HTTP Requests** option.If you specify "***all***" as the Channel Name, every channel at the defined HTTP page will be polled.
- **Import CSV File**: If you select this option, you will be able to import a table from an existing CSV file. To do so, specify the **File Path** where the CSV file is located.

### Redundancy

There is no redundancy defined.

## How to use

This driver has four different tables:

- The **Endpoint Configuration** table allows you to define and view the channels from which information is polled.
- The **Custom Label** table allows you to define the custom label that will identify every row containing the associated **Wildcard Name** in the following tables: **Endpoint Channel Error** and **Endpoint Health**.
- The **Endpoint Channel Error** table lists the channels that cannot be polled because of certain issues.
- The **Endpoint Health** table lists the multiple streams related to the different channels in the **Endpoint Configuration** table.

## Notes

The **Row State** column in the **Endpoint Health** table indicates the current state of the associated stream. A stream can have one of the following types of **Row State**:

- **New**:This type indicates that the stream was added to the table
- **Updated**: This type indicates that the current stream state in the **State** column is different from the previous one.
- **Equal**: This type indicates that the previous state in the **State** column and the current state are the same.
- **Deleted**: This type indicates that the channel from which the stream comes in the **Endpoint Configuration** table is disabled or deleted, and no longer polled.
