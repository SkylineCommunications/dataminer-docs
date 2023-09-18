---
uid: Connector_help_MediaKind_CE1
---

# MediaKind CE1

With this connector, you can gather and view information from the device **MediaKind CE1** as well as configure the device.

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

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.220.224.16*.
- **IP port**: The port of the destination, e.g. *8080*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element contains the data pages detailed below.

### General

This page displays a tree view of the relationship between **Channel Components**, **Channel**, and **Channel Alarms**.

### Auto Clean Setting

This page contains the **Auto Clean table**, which is used to set the auto-clean rules for tables in this connector.

To add a new rule, right-click the table, select **Add New Row**, and fill in the value for every column.

Notice that for each of the tables, **only one rule** can be enabled each time.

### Channel Type

This page shows three tables, **Channel Types**, **Channels**, and **Channel Components.**

The channel progress bar indicates the progress of the channel being fetched from the device.

### Saved Configurations

On this page, the saved configurations information is displayed, including the table **Save Configurations** and **Saved Configuration Components**.

To remove a saved configuration, select one or more records from the **Saved Configurations** table, right-click, and select **Delete Selected Rows** in the context menu.

### Service

This page displays all **services** in the MediaKind CE1.

To **add a new service**, right-click and select **Add New Row** in the context menu. The **Type**, **Configuration** **Version**, and **Configuration Name** must be filled in.

### Channel Alarms

This page displays the **alarms** for each component in different channels.

The auto-clean for the **Channel Alarms** table is auto-added when the element is created.
