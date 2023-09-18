---
uid: Connector_help_Scilla_C2100
---

# Scilla C2100

The **Scilla C2100** Carousel Server generates DSM-CC data and object carousels. The server supports signaling and playout of HbbTV, MHP and MHEG-5 applications as well as CI Plus data carousels.

## About

This protocol displays information about the device and the installed carousels. Information is retrieved via HTTP get commands.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

## Usage

### General

This page displays general information about the device. There are also page buttons that show the current services running on the device, the reserved IDs, and the network interfaces of the device.

### MPEG-2 AV

This page displays information on the MPEG streams and their elementary streams in a tree structure. There is also a page button that displays the tables the tree view is based on.

### DSM-CC

This page displays a table with a list of the object carousels on the device. There is also a page button that shows the settings for the DSM-CC.

### Multiplexer

This page displays a table of the transport stream recordings, as well as a page button to access the settings of the multiplexer.

### PSI/SI

This page displays a table of the PSI/SI services running on the device, as well as a page button to access to the PSI/SI settings.

### Events

This page displays a table of the events on the device. Via a page button, a new event can be added.

### Schedule

This page displays two tables, showing the streams and service streams on the device, respectively.

### Settings

This page contains different page buttons that can be used to access various menus with settings for the device.

### Log

This page shows a table with the logs on the device and has a button to clear the log.
