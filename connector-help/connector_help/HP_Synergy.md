---
uid: Connector_help_HP_Synergy
---

# HP Synergy

This connector is used to monitor an HP Synergy device via the HP OneView management platform. The connector makes use of the RESTful API to communicate with the device.

## About

### Version Info

| **Range**            | **Key Features**         | **Based on** | **System Impact**                                   |
|----------------------|--------------------------|--------------|-----------------------------------------------------|
| 1.0.0.x              | Initial version          | \-           | \-                                                  |
| 1.0.1.x \[SLC Main\] | Add support for Unicode. | 1.0.0.3      | Element must be recreated. Saved data will be lost. |

### Product Info

| **Range** | **Supported Firmware**   |
|-----------|--------------------------|
| 1.0.0.x   | OneView API Version 1000 |
| 1.0.1.x   | OneView API Version 1000 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Initialization

The **HP Synergy** device requires authentication. Specify the necessary credentials on the **General** page.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General

On this page, you can enter the credentials to authenticate to the HP Synergy device. If the credentials are correct, the **Connection Status** parameter will indicate the value *Connected*, and the element will start polling data from the device.

The general page also displays the **Current Version** and **Minimum Version** supported by the device.

### Enclosures

This page displays information about the enclosures (Enclosure Group, Logical Enclosure, etc.).

### Servers

This page displays information about the servers (Server Hardware, Server Profile, etc.).

### Networks

This page displays information about the network and connections (Connection, Ethernet Network, etc.).

### Interconnect

This page displays the interconnections between the different resources.

### Storage

This page displays information about the storage (Storage Volume, Managed SANs, etc.).

### Facilities

This page displays information about data centers, power devices and racks.

### Activity

This page displays information about alerts, events and tasks.

### Appliance

This page displays information about appliances and licenses.
