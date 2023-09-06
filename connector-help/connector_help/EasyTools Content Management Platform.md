---
uid: Connector_help_EasyTools_Content_Management_Platform
---

# EasyTools Content Management Platform

The EasyTools Content Management Platform connector monitors and controls the corresponding unit through SNMP.

It polls relevant information from the device every 2 seconds, 30 seconds, or 1 hour. It also receives traps from the device and updates the values accordingly.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The *polling IP* of the device

SNMP Settings:

- **Port number**: *161*
- **Get community** **string**: *OpenHeadend*
- **Set community string**: *OpenHeadend*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

You can find more information about the data display pages of the connector below.

### General Page

This page displays the server **System ID, Version, Vendor, Time,** **Name**, and **IP Address** (which represents the polling IP), as well as the **Total Memory, Memory Cache, Free Memory**, and **Memory Buffers.**

There are two page buttons:

- **Ping**: Opens a page where you can enable or disable ping, set the ping cycle, configure the timeout, and see information about the pinging.
- **Licensing**: Opens a page with tables containing licensing information.

There are also two tables, which show a **List of CPUs** and **Disks.**

### Links Page

This page displays two user-configurable tables containing the **Network** and **Storage Links.**

### Nodes Page

This page displays information regarding the **Configured Nodes**.

### Functions and Operations Page

This page displays information regarding the **Configured** **Functions,** **Configured Operations**, and **Operation Transcode AAC** that are created in the device.

### Schedules and Jobs Page

This page displays information regarding both the **Configured Schedules** and **Configured Jobs** that are created in the device.

### Workflow Page

This page displays information regarding the relationships between the **Function Monitor Table** and **Function Record Table**.

### Function Tree Page

This page displays a tree structure for every **Configured Function**, showing each **operation** that is related to that particular function.

### Schedule Tree Page

This page displays a tree structure for every **Configured** **Schedule**, showing each **job** that is related to that particular schedule.

### Web Interface Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
