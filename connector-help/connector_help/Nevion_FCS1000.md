---
uid: Connector_help_Nevion_FCS1000
---

# Nevion FCS1000

This connector is used to monitor the Nevion FCS1000.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.0.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### HTTP Web Interface Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General

This page displays general information about the device (Product ID, Version, etc.) and lists the inputs.

### Overview

This page displays the inputs in a tree view. For each input, you can view more detailed information about the ASI or SDI data, the programs, etc.

### ASI

This page lists the ASI inputs, their programs, and their PIDs.

### SDI

This page lists the SDI inputs and their audio channels.

### Events

This page lists the events for each input.
