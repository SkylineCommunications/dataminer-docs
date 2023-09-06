---
uid: Connector_help_Mediaproxy_Logserver
---

# Mediaproxy Logserver

This connector monitors the activity of the Mediaproxy LogServer, which is a hardware and software compliance logging and monitoring platform.

The connector uses **SNMP traps** to capture the logging of the device. It uses an **HTTP** connection to retrieve information from the Mediaproxy LogServer REST API. It will show information related to channels, events, and extracts, as well as alarm status information (updated based on traps and events).

## About

### Version Info

| **Range**            | **Key Features**              | **Based on** | **System Impact** |
|----------------------|-------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.              | \-           | \-                |
| 1.0.1.x \[SLC Main\] | REST API communication added. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**      |
|-----------|-----------------------------|
| 1.0.0.x   | \-                          |
| 1.0.1.x   | Mediaproxy LogServer API v1 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP connection

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: Set this as any

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: Default 443
- **Bus address**: Default *bypassproxy.*

SERIAL CONNECTION:

- Interface connection:

<!-- -->

- **IP address/host**: Set this as any
- **IP port:** Set this as any

Push API:

- When setting up the push API urls on the device, be sure to use the following formats:

- **http://\<ip of device\>/events** for event messages
  - **http://\<ip of device\>/dpi** for dpi/scte messages
  - **http://\<ip of device\>/nave** for NAVE event messages
  - **http://\<ip of device\>/captions** for closed caption messages
  - **http://\<ip of device\>/eas** for EAS messages

### Initialization

Specify the authentication token on the General page. The token will be used for the HTTP communication with the REST API.

## Usage

The element consists of the following data pages:

- **General**: Used to specify the authentication token. Will also show the device IP configuration.
- **Channels**: Shows the information from the REST API GET/Channels response.
- **System Status**: Displays system status information. This information is updated with received traps and events from the REST API.
- **Channel Status**: Displays channel status information. This information is updated with received traps and events from the REST API.
- **Traps**: Displays the received traps. Traps will be mapped to status information.
- **Events**: This page and its subpages display the event-related information retrieved from the REST API. Events will be mapped to status information.
- **Extracts**: This page and its subpages display the extract-related information retrieved from the REST API.
- **Push API Status**: This page contains a table which shows the timeout status/configurations for the different Push API channels
