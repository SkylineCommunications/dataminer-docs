---
uid: Connector_help_Arista_MCS
---

# Arista MCS

The Arista MCS (Media Control Service) is a software service that provides APIs to quickly and dynamically configure bandwidth-protected multicast flows across an IP network topology.

Besides polling the API for monitoring devices and interfaces parameters, the Arista MCS connector also implements **Redis messages subscriptions**, so that it can receive very fast updates or changes to senders, receivers, flows, etc.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                           | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------------------------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | InterApp messages via Automation scripts using Flow Engineering | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

## How to use

When the element using the Arista MCS connector start up, it subscribes to the Redis channels. Redis messages are processed and handled in accordance with the channel message and the type of action each message carries. For example, a message might be to add or update a sender row in the Senders table.

The following pages are available:

- **Redis**: Contains the Redis Status table, which displays the last message for each Redis channel and the time when these were last received. It also contains the **Redis Settings** subpage.
- **Interfaces**: Displays the Interfaces table, listing the interfaces from every device (in the Devices table).
- **Senders**, **Receivers**,and **Active Flows**: The Senders and Receivers tables contain the configuration of each sender/receiver, the Source IP, Multicast IP, and Bandwidth. A sender/receiver is configured for a given device and an interface/port. Once a sender and receiver are correctly configured, a flow will be created and shown in the Active Flows Table.

## DataMiner Connectivity Framework

The **1.0.0.x** range of the Arista MCS connector supports the usage of DCF and can only be used on a DMA with DataMiner version **8.5.4** or higher.

DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g. a manager).

### Interfaces

#### Dynamic interfaces

Physical dynamic interfaces:

- Ethernet **inout** interfaces, dynamically exposed from the **Interfaces** table.

## Notes

- The connector contains a **hidden Debug page** with parameters for quick debugging and testing. To make this page visible, use the **Debug Page** parameter under the **General** page.
- The Arista MCS also implements an **InterApp receiver**. This allows the connector to receive messages from external sources, such as Automation scripts or applications.Currently, the connector supports the reception of certain **Flow Engineering messages**. These messages will then make use of the connector in order to configure a flow by setting up the configuration of senders and receivers for the MCS.
