---
uid: Connector_help_DekTec_Xpect
---

# DekTec Xpect

The **DekTec Xpect** connector is used to monitor the different transport streams and their services and PIDs. Errors are monitored on transport stream level.

## About

This connector monitors the transport streams via SOAP calls.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 2.0.0.x          | HTTP Conversion | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.3.0 Build 5168            |
| 2.0.0.x          | 3.3.0 Build 5174            |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **IP port**: The port of the connected device. The default value is *5089.*

## Usage

### General

On this page, you can find a tree control that shows an overview of the **PIDs** contained in services, which are in turn contained in transport streams.

### Streams

This page displays a table with all the **transport streams** and additional information related to them.

### Services

This page displays a table with all the **services** and additional information related to them.

### PIDs

This page displays a table with all the **PIDs** and additional information related to them.

### Alarms

This page displays a table with all the **alarms** and additional information related to them.

### Errors Status

On this page, you can monitor **errors** on the transport streams. The errors are displayed in the following three tables: **TR 101 290 Errors Table**, **Template Rules Table** and **Extra Tests Table**.

### Shared PIDs

This page contains **PIDs** that are shared per service on each transport stream.

### Web Interface

This page contains the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
