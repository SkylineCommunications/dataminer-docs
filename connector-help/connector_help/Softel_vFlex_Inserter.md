---
uid: Connector_help_Softel_vFlex_Inserter
---

# Softel vFlex Inserter

This connector is used to monitor the Softel vFlex Inserter server, a tool for the processing and injection of data into the broadcast stream.

VFlex is a multi-purpose, rack-mounted ancillary data processor and inserter. It can receive, process and insert ancillary data, and is able to generate and insert clocks, bugs and other graphics into the transport stream. It also supports remote management for both configuration updates and error monitoring and correction.

## About

This connector uses HTTP sessions to obtain the configuration XML and the HTTP page of the vFlex, which contain the information shown in the element.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.6.16-1                    |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP/URL of the server
- **IP port**: The port used by the HTTP server, by default *80*.
- **Bus address**: b*ypassproxy.*

### Configuration of Authentication

In order for the connector to work and poll information, the **User Name** and **Password** must be configured on the **General** page. Otherwise, no information can be obtained.

## Usage

### General

The **Authentication** area on this page contains the parameters that need to be configured to communicate with the server.

The page also contains information on the unit (corresponding to the **Unit ID** device page) and the **Watchdog** state (corresponding to the **Main Configuration** device page).

### LAN

This page displays all the **LAN** and **SNMP** data, including **IP** addresses, **domains**, and the **ports** configuration.

### Serial

This page contains the **Serial Port Configuration Table**, which contains the configuration for all the serial ports supported by the system.

### Video Control

This page contains both the **Video Input** and **Video Output** table, which contain the configuration info for each input and output, respectively.

### Streams

This page displays the **Output Stream Configuration** table, containing the line configuration per resolution. It also contains the information present on the **Output Lines** device page (in the **Output Line**, **Source**, **Input Line**, **Stream Mode** and **Stream** columns).

### Subtitle Services

This page lists the subtitle services, showing whether they are active or not, and displaying the corresponding configuration.

### Regeneration Services

This page contains the data regarding the regeneration service setup for 1080i50, including its **state**, **type**, **input**, and the **VBI Lines**.

### GPIs

This page displays information on all the GPIs available in the system, including their behavior on encountering a change.

### GPOs

This page displays information on all the GPOs available in the system, including their behavior on encountering a change.

### Relays

This page displays information on all the relays available in the system, including their behavior on encountering a change.

### Logging

This page contains information for both the **loggers** and the **appenders**. There are four different appenders present in the system: **File**, **Rolling File**, **ODBC** (database) and **Console**.

### Web page

This page displays the web page provided by the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

This connector **requires an external dll file (HtmlAgilityPack.dll)**. This file needs to be present in the DMA's ProtocolScripts folder.
