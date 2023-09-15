---
uid: Connector_help_Miranda_Edgevision
---

# Miranda Edgevision

The **Miranda Edgevision** is a video monitor with a web interface.

## About

The device has a web interface that is split up into an applet for advanced functionality and a webpage for general statuses and settings. Since the entire interface is obfuscated and no API is available, only the JSON messages are currently being scraped. The readable information is available in this connector.

When a webpage can be safely executed inside DataMiner to scrape the contents, improvements to this connector will be possible.

### Version Info

| **Range** | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                           | No                  | Yes                     |
| 1.1.0.x          | New firmware based on 1.0.0.x (see below) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.21 build 1096             |
| 1.1.0.x          | 1.44 build 1223             |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses an HTTP connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: A fixed destination port has been set to *80.*
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

## Usage

The interface of this connector mimics the interface of the Admin webpage. This means that there are 2 pages: **System Configuration** and **Status and Options.** These hold the information that could be scraped from the messages sent between the web interface and the device.

### System Configuration

The **General** and **Date and Time** groups can be found in the left-hand column. The **Ethernet** group is in the right-hand column.

### Status and Options

Since only a few parameters from the **Health** tab can be retrieved, this is currently the only group to be found on this page. The two temperatures can be monitored and trended.

### Web Interface

This page will attempt to load the device's Admin webpage in the displayed card. The local machine must be in the same address range for the page to load.
