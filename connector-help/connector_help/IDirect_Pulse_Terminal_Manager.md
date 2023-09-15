---
uid: Connector_help_IDirect_Pulse_Terminal_Manager
---

# IDirect Pulse Terminal Manager

With the **iDirect Pulse Terminal Manager** connector, you can monitor terminal components of an iDirect Pulse NMS.

## About

With this connector, iDirect terminals can be monitored. Other components should be monitored using the **iDirect Pulse Manager** connector. Multiple terminal manager elements can be created, to spread the load and trend data over multiple DataMiner Agents.

The iDirect Pulse manager is responsible for the distribution of the terminals that should be polled by this element.

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

| **Exported Connector**  | **Description**                            |
|------------------------|--------------------------------------------|
| iDirect Pulse Terminal | iDirect Terminals (installation on vessel) |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration

On the **Configuration** page, specify the credentials that should be used to communicate with the API.

## Usage

### General

This page displays general information about this element, such as the number of monitored terminals and connected manager elements. The page also displays the time retrieved with the most recent polling.

### Terminals

This page displays a table with all terminals monitored by this element. You can add or remove rows in this table with the iDirect Pulse Manager element. A DVE is created for each row in the table.

### Terminal Alarms

This page displays all active alarms for all terminals monitored by this element. On a terminal DVE, only linked rows are displayed.

### Geolocation

This page displays the GPS trace table, containing the GPS position history of each terminal.

### Configuration

On this page, you can specify the iDirect Pulse web service API credentials.

### Web Interface

This page displays the web interface of the iDirect Pulse NMS. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
