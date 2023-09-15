---
uid: Connector_help_IDirect_Pulse_Manager
---

# IDirect Pulse Manager

With the **iDirect Pulse Manager** connector, you can monitor components of an iDirect Pulse NMS.

## About

With this connector, the components of an iDirect Pulse NMS can be monitored. The connector must be used in combination with one or more **iDirect Pulse Terminal Manager** elements. This setup is implemented in order to spread the load and trend data over multiple elements and DataMiner Agents.

After an outage, all missing data will be polled and set to the element using history sets.

All data is retrieved over HTTP using the web service API.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                               |
|------------------|---------------------------------------------------------------------------|
| 1.0.0.x          | API version 1.0                                                           |
| 1.1.0.x          | API version 1.1 No other major changes when going from 1.0.0.x to 1.1.0.x |

### Exported Connectors

| **Exported Connector**  | **Description**  |
|------------------------|------------------|
| IDirect Pulse Beam     | iDirect Beam     |
| IDirect Pulse Linecard | iDirect Linecard |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration

On the **Configuration** page, specify the following:

- The credentials to communicate with the API.
- The terminal manager elements that will be used for terminal monitoring.

## Usage

### General

This page displays general information about this element, such as the time retrieved with the most recent polling.

### Terminals

This page contains a table with all terminals. For all terminals that are enabled, the manager will select a terminal manager element that will host the DVE of the terminal.

When the **Auto Enable Terminals** parameter is enabled, terminals are automatically enabled (and a DVE will be created by the terminal manager element).

Terminals that are removed from the NMS are not automatically removed from the table, except when the **Automatic Removal Terminal Elements** parameter is enabled. To remove terminals from the table, use the **Delete All Removed Terminals** button, or the context menu of the table.

### Networks

This page displays a table with all networks and corresponding configuration.

### Satellites

This page displays a table with all satellites and corresponding configuration.

### Beams

This page contains a table with all beams. For each beam in the table, a DVE will be created.

Beams that are removed from the NMS are not automatically removed from the table, except when the **Automatic Removal Beam Elements** parameter is enabled. To remove beams from the table, use the **Delete All Removed Beams** button, or the context menu of the table.

### Chassis

This page contains a table with all chassis and corresponding configuration. Alarms of the chassis are displayed on the **Chassis Alarms** page.

### Chassis Alarms

This page displays all active alarms for all chassis.

### Linecards

This page contains a table with all linecards and corresponding configuration. Alarms of the linecards are displayed on the **Linecard Alarms** page. For each linecard in the table, a DVE will be created.

Linecards that are removed from the NMS are not automatically removed from the table, except when the **Automatic Removal Linecard Elements** parameter is enabled. To remove terminals from the table, use the **Delete All Removed Linecards** button, or the context menu of the table.

### Linecard Alarms

This page displays all active alarms for all linecards. On a linecard DVE, only linked rows are displayed.

### Configuration

On this page, the iDirect Pulse web service API credentials should be specified.

Here you can also select the terminal manager elements that should be used by this element. To do so, first click the refresh button to poll the DMS for available elements, and then right-click in the table to add or remove elements using the context menu.

### Stats Metrics

This page displays a table with all possible metrics that are available to be polled.

### Web Interface

This page displays the web interface of the iDirect Pulse NMS. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
