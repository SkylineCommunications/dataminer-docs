---
uid: Connector_help_Newtec_Dialog_Time_Series_Database_Manager
---

# Newtec Dialog Time Series Database Manage

This is a manager connector that operates on top of the **Newtec Dialog Time Series Database** connector, to spread remote and network DVEs over multiple hub elements. This helps to manage elements licensing and DMA load distribution and assures good performance when retrieving trending, alarms, etc.

The connector gathers all available remotes and networks on the configured Dialog hub elements. The detected items are then assigned to one of the hub elements.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of the managed Dialog elements

After a new element has been created using this connector, the Dialog hub elements that must be managed need to be selected.

To do so:

1.  Go to the **General** page.
2.  Click the **Refresh Elements** button to refresh the list of Dialog elements.
3.  Use the drop-down list to select the element. All elements using the connector "Newtec Dialog Time Series Database" will be shown.
4.  Apply your selection to add the element to the table.

## Usage

### General

This page provides an overview of all Dialog hub elements that are managed by this manager element.

The page also indicates the number of remotes and networks that are assigned to each hub element. However, note that this does not necessarily equal the number of DVEs that are active in the system.

It is possible that a remote or network is assigned to an element but is not currently active. In that case, that slot is reserved, so that the trending and alarm information for the item remains available in case it becomes active again.

### Configuration

On this page, the **synchronization interval** can be configured. By default, synchronization occurs every minute.

The **Auto Enable** toggle buttons allows you to specify whether newly detected remotes or networks should be enabled or disabled by default.

### Remotes

The table on this page contains all remotes that are detected on the configured hub elements. The creation of DVEs for the remotes can be enabled or disabled.

The button at the top of the page can be used to start a manual synchronization with the Dialog hub elements.

### Networks

The table on this page contains all networks that are detected on the configured hub elements. The creation of DVEs for the networks can be enabled or disabled.

The button at the top of the page can be used to start a manual synchronization with the Dialog hub elements.
