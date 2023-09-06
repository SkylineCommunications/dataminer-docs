---
uid: Connector_help_TAG_Video_Systems_MBC-7000
---

# TAG Video Systems MBC-7000

The MBC-7000 IP multiviewer enables creation of a broadcast-quality mosaic channel from a mixture of sources in a variety of layouts.

This driver uses an HTTP connection to poll data from the MBC-7000 device. The driver can update the channel and system events in real time based on received traps.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                                  |
|-----------|---------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | V-2.0.6 (from version 1.0.0.11 of the driver onwards; previous supported firmware versions are unknown) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the device.
- **IP port**: The IP port of the destination, default *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### SNMP TRAPS Connection

This driver uses a Simple Network Management Protocol (SNMP) connection for incoming traps received by DataMiner.

SNMP CONNECTION:

- **IP address/host**: The IP address of the DMA receiving the traps

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

To properly connect to the device, fill in the **Username** and **Password** on **Login** subpage under **System Information**.

## How to Use

When the necessary login information has been specified (see "Initialization"), data will be polled for the channels and streams. On subpages, you can create and delete **Scan Tasks**, **Channels**, and **Layouts**
