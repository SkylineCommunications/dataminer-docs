---
uid: Connector_help_Elemental_Live
---

# Elemental Live

This connector polls information from an **Elemental Live** server, namely the status of streamed live events and of the encoding of live events. The connector also enables the user to create new output streams on the server.

An **Elemental Live** system can stream multiple video outputs through the following three input types: HD-SDI, IP or local files.

## About

The connector retrieves the following information from an **Elemental Live** system:

- On-going live events
- Physical inputs
- Schedules
- Media Routers
- MPEG Transport Streams
- Alarms/Messages
- Settings pre-defined by the user, such as event profiles and media presets

Most of these items can also be added or deleted in the connector.

The connector uses **HTTP REST** commands to perform GET/POST commands based on the Elemental Live API. In addition, **SNMP** is used for the Elemental Live's traps and basic settings.
Each polling request (HTTP/SNMP) command is performed every 10 seconds.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                          |
|------------------|------------------------------------------------------|
| 1.0.0.x          | Software version 2.7.0.30234 Software version 2.12.6 |

## Installation and Configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

- **IP Address**: The polling IP of the HTTP server.
- **Port**: The server's HTTP IP port.
- **Bus address**: The default value *bypassproxy* is specified to bypass the proxy server.

#### SNMP Traps/General Settings Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

- **IP Address:** The SNMP polling IP of the server.
- **Port:** The server's SNMP port, by default *161*.
- **Get Community:** The server's read community string, by default *elemental_snmp.*
- **Set Community:** The server's write community string, by default *elemental_snmp_write*.

### Configuration

If the device supports the use of REST API authentication, fill in the following parameters on the **General Settings** page:

- **Username:** The username defined in the device for polling purposes.
- **REST API key:** The API key associated with the username.

Otherwise these parameters should be left blank.

Also on the **General Settings** page, **SNMP Polling** can be enabled or disabled.

## Usage

### Live Events

On this page, the current events of the device are displayed in a tree structure. For each event, there can be one or more nodes representing output group settings, with each output group containing a specific number of output streams.

New events can be created with the **Create Event** page button. In addition, you can perform operations on existing events via the **Event Actions** page button, such as **Start/Stop Encoding**, **Archive/Cancel Event** and **Reset/Delete**.

### Event Profiles

On this page, existing predefined event profiles are displayed in a tree structure, similar to the tree structure on the **Live Events** page. These can be used to create new streaming schedules or live video output streams.

It is possible to delete profiles in the tree structure, and new profiles can be created based on existing presets, via the **Create Profile** page button.

### MPTS

On this page, information from MPEG Transport Streams is displayed. You can add new streams via the **MPTS Creation** page button, or delete them directly with the **Delete** button in the MPTS table.

### Alerts/Messages

This page displays two tables, one concerning the message logs (**Messages Table)** and another regarding the device's alerts (**Alerts Table**).

### Schedules

This page displays the existing schedules in a tree view structure. Each schedule can have several inputs associated with it.

In addition, schedules can be created based on existing profiles, by means of the page buttons **Create Monthly by Day**, **Create Monthly by Week**, **Create Weekly** and **Create Daily**.

### Presets

This page displays the predefined presets of the device in a tree structure, including the presets predefined by the user. At its root, the tree structure shows several preset categories. For each of these preset categories, it displays the media settings for a group of presets.

In addition, new categories can be created via the **Create Category** page button. It is also possible to add new presets to a specific category with the **Create Preset** page button.

### Devices

This page displays the **Devices Table**, which shows what input devices are connected to the **Elemental Live** system.

### Routers

This page displays any routers associated with the **Elemental Live** system. More routers can be added by means of the **Add Router** page button. Routers can also be deleted with the **Delete** button in the **Routers Table.**

### Live Events Traps/Alerts

This page contains the Live Event Table.

### General Settings

This page allows you to configure general settings. In the **Polling Configuration** table, you can control the pace at which content is polled from the API.

### Webpage

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
