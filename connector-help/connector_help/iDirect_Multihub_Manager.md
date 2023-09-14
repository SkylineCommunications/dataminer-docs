---
uid: Connector_help_iDirect_Multihub_Manager
---

# iDirect Multihub Manager

This is a manager connector that operates on top of the **iDirect Platform** connector, to spread remote, linecard and network DVEs over multiple hub elements

## About

This connector gathers all available remotes, linecards and networks on the configured iDirect hub elements. The detected items are then assigned to one of the hub elements.

The purpose of this is to distribute the remote, linecard and network DVEs to multiple hub elements, to assure a good performance when retrieving trending, alarms, etc.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of the managed iDirect elements

After a new element has been created using this connector, the iDirect hub elements that must be managed need to be selected.

To do so:

1. Go to the **iDirect Elements** page.
1. Click the **Refresh Elements** button to refresh the list of iDirect elements.
1. Use the drop-down list to select the element. All elements using the connector "iDirect Platform" will be shown.
1. Apply your selection to add the element to the table.

## Usage

### iDirect Elements

This page provides an overview of all iDirect hub elements that are managed by this manager element. See the "Configuration of the managed iDirect elements" section for more information.

The page also indicates the number of remotes, linecards and networks that are assigned to each iDirect element. However, note that this does not necessarily equal the number of DVEs that are active in the system. It is possible that a remote, linecard or network is assigned to an element, but is not currently active. In that case, that slot is reserved, so that the trending and alarm information for the item remains available in case it becomes active again.

### Remotes

The table on this page contains all remotes that are detected on the configured iDirect hub elements. The creation of DVEs for the remotes can be enabled or disabled.

The button at the top of the page can be used to start a manual synchronization with the iDirect hub elements.

### Linecards

The table on this page contains all linecards that are detected on the configured iDirect hub elements. The creation of DVEs for the linecards can be enabled or disabled.

The button at the top of the page can be used to start a manual synchronization with the iDirect hub elements.

### Networks

The table on this page contains all networks that are detected on the configured iDirect hub elements. The creation of DVEs for the networks can be enabled or disabled.

The button at the top of the page can be used to start a manual synchronization with the iDirect hub elements.

### Configuration

On this page, the **synchronization interval** can be configured. By default, synchronization occurs every minute.

The **Auto Enable New** toggle buttons allows you to specify whether newly detected remotes, linecards or networks should be enabled or disabled by default.
