---
uid: Connector_help_Miranda_GSM_Traps
---

# Miranda GSM Traps

This connector can be used to monitor the Miranda GSM.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: Default:*161*.

SNMP Settings:

- **Get community string**: Default: *public-community.*
- **Set community string**: Default: *private-community.*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element contains the data pages detailed below.

### General

On this page, the **device table** lists the devices created by users through the input fields at the top of the table. The devices that are initially listed in the table are retrieved from the devices list text file.

The **initial device file path** by default is ***C:\InitialDeviceList.txt***. In the TXT file, the device should be specified in the format ***label;device name***.

### Device Status

This page contains device status information filtered based on the list of the devices in the **device table**.

The **Polling Traps** toggle button allows you to enable or disable the polling of the traps. If this is disabled, the device status table will no longer be updated.

The **Remove All** button at the bottom of the table allows you to clear all entries in the device status table.

### Tree

This page contains a **tree view** that shows the relationship between the device and the device status table.
