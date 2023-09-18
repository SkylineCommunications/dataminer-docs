---
uid: Connector_help_Elemental_Delta
---

# Elemental Delta

The **Elemental Delta** device is a video delivery platform designed to optimize the management, monetization and distribution of video across internal and external IP networks.

## About

This connector makes it possible to monitor and control an Elemental Delta platform. The platform provides a complete solution for time-shifted TV and just-in-time video packaging while enabling real-time content delivery with advanced levels of personalization, customization and control. All data is retrieved using an **HTTP** and **SNMP** connection.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.1.1.200046                |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *8080*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

#### SNMP connection

This connector also uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *elemental_snmp*.
- **Set community string**: The community string used when setting values on the device. The default value is *elemental_snmp_write*.

## Usage

### Overview

This page provides an overview of all content managed by the device and associated output filters.

### Status

This page displays general status information about the device, such as the status of the Delta and HTTPd service, the firewall, the running software version and the **Healthcheck** verification.

### Alerts & Messages

This page provides information about current active alert conditions on the Elemental Delta unit. Messages provide an audit list of events on Delta.

### Input Filters

Input filters define ingest points for content received by the system. They can control storage locations for content, retention windows, and content types.

### Contents

Content defines the source input received by the system. Content can be either **Linear** (as sourced from products such as Elemental Live) or **VOD** (Video On Demand, as sourced from products such as Elemental Server). Content is received by the system through **input filters**.

**Output filters** allow the operator to manipulate content before it is served to a requesting end user. Output filters can be chained together to create more complicated workflows. For example, an operator can add an **Ad Removal** filter after a **Live to VOD** filter to create an endpoint that delivers a complete program without advertisements as a VOD asset to the end user.

The content status is added in version 1.0.0.4 of this connector, but is only available on devices running software version 1.7.0 or higher.

This page also contains the **Tracks Table**, with parameters such as **Bitrate**, **Stream Index**, **Sample Rate**, **Bits Per Sample**, etc.

### Output Templates

Output templates are sets of output filters that can be applied to new content. Input filters can be configured to apply a particular output template to incoming content.

### Nodes

Two Elemental Delta nodes can be configured as a cluster in order to support high availability and increased throughput. Input filters in a cluster should be configured to store content in shared storage. A single node in the cluster is denoted the leader, and all input filters will be active on that node. If the leader node fails, the second node will become the leader and begin ingesting content. Endpoints can be accessed on either node in a cluster.

The operator can configure a virtual IP (VIP) address which will point to the active leader node, and access control interfaces through the VIP.

### Settings

This page provides information on overall system settings (network, mount points, firewall and SNMP). Any updates to the settings must be done via the UI.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
