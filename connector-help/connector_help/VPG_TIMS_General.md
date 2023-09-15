---
uid: Connector_help_VPG_TIMS_General
---

# VPG TIMS General

A passive analyzer of ASI and SDI video signals.

## About

This analyzer uses a combination of SNMP and HTML to pass the information related to the video streams and all services running on them.

### Version Info

| **Range**     | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                           | No                  | No                      |
| 1.1.0.x              | Release version                           | No                  | No                      |
| 2.1.0.x              | New OID 13130.6                           | No                  | No                      |
| 3.1.0.x              | Changed the connector with a tree controller | No                  | No                      |
| 3.1.1.x              | Changes for GlobeCast France              | no                  | Yes                     |
| 3.2.1.x \[SLC Main\] | Old OID 13130.5                           | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | Unknown                     |
| 2.1.0.x          | Unknown                     |
| 3.1.0.x          | Unknown                     |
| 3.1.1.x          | Unknown                     |
| 3.2.1.x          | Unknown                     |

## Installation and configuration

This connector uses an SNMP connection and an HTTP connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Required in the 3.1.x.x range of this connector, not in the 3.2.x.x range.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*

**HTTP CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, by default *8081.*
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

## Usage

### Overview

This page displays a tree view containing all information regarding the stream.

### Inputs

On this page, the **Inputs Information Table** displays the name, alarm filter and custom strings for the inputs of the device.

### Streams

This page displays the streams and associated alarms in the **Stream Instance Table** and **Streams Alarm Table**.

To clear the empty stream entries from the **Stream Instance Table**, **ASI Streams Table**, **Normalized Stream Info** and **SDI Streams Table**, click the **Remove Missing Streams** button.

### ASI Streams

This page displays the **ASI Streams Table** and **ASI Alarm Table**.

To edit the normalized used data rates, click the **Normalized Values** page button.

#### Normalized Values, Streams and Services

On these subpages, you can find the table with normalized values, and the following two buttons:

- **Reset Rates to Current Value**: Overwrites all the normalized rates with the actual values from the main table.
- **Force Synchronization**: Deletes all incoherent entries and adds any missing entries in the normalization table.

### SDI Streams

This page contains the **SDI streams Table** and **SDI Alarm Table**.

### Services

On this page, you can find the **Service Info** table, with editable alarm filter. To clear entries without values, click **Remove Missing Services**.

The page contains a page button that leads to the normalized values page described above.

### PIDs

This page is similar to the Services page.

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
