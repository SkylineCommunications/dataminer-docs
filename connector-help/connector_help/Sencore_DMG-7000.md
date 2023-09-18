---
uid: Connector_help_Sencore_DMG-7000
---

# Sencore DMG-7000

The DMG 7000 provides a gateway between broadcast MPEG/IP networks and internet-based distribution protocols. These protocols, such as SRT, Zixi, RIST, and HLS, allow content providers to use consumer-based internet connections to provide reliable, low-cost distribution networks, without needing satellite and fiber links to backhaul high-quality content from remote sites to headends or to distribute content to regional hubs.

Being a software-based, the DMG 7000 can be deployed on COTS hardware in a variety of forms, from mini-PCs to 1RU rack mount servers and virtual environments such as AWS or Google Cloud.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.12.2                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To establish a connection with the API, specify the Username and Password on the Login page.

## How to use

The connector is used to monitor the KPIs of different gateways. Each gateway can have a number of receivers and transmitters that use a protocol. The KPIs of these will be displayed in different tables. The tables are grouped on different pages based on the protocol. A table with all the gateways and the relevant information can be found on the **Gateway** page.

A REST API is used to retrieve the device information, including alarms and logging information.
