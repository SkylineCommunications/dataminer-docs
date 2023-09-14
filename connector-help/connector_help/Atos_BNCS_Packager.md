---
uid: Connector_help_Atos_BNCS_Packager
---

# Atos BNCS Packager

This connector allows you to monitor and manage router and packager instances of BNCS, using the API developed by Atos.

The router can be used to switch several SDI signals. The packager can be used to logically route signals in different qualities from a source (e.g. grouped per booking) to the required destination.

## About

The connector will poll the API using HTTP requests with JSON documents. Some updates are available using asynchronous notifications via WebSockets containing JSON documents.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Atos BNCS API Draft 2.0.2   |

## Installation and configuration

### Creation

#### HTTP "WebSocket Notifications" connection

This connector uses an HTTP WebSocket connection to be able to receive notifications from the device. It requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, using the format *ws://\[IP or URL\]*.
- **IP port**: The IP port of the destination, by default *5555*.
- **Bus address**: *bypassproxy*

#### HTTP "HTTP Polling" connection

This connector uses an HTTP connection to enable polling and configuration of the device. It requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *5001*.
- **Bus address**: *bypassproxy*

#### HTTP "HTTP Notification Requests" connection

This connector uses an HTTP connection to maintain the notification subscriptions of the WebSocket connection. It requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *5002*.
- **Bus address**: *bypassproxy*

### Configuration of instance

The router instance and packager instance can be defined on the *Matrix Configuration* page.

## Usage

### General

This page contains information about the IP and port of the current **connections**, as well as **WebSocket Info** and information about the **Router** and **Packager Instances** and dimensions.

### Router

This page contains information about the available **router inputs and outputs** and indicates which input the router is connected to. There are also parameters available that add support for a visual panel.

### Source Packages

This page contains information about the available packager inputs in the **Source Packages** table. The Label, Title, MCR Title, Start, End, Info, LACVI status and Booking ID of a source package are displayed. There are also parameters available that add support for a visual panel.

On the **Source Packages Details** subpage, you can find the following detailed information related to source packages: Video HD, HDE and SD router inputs, Video TX, Audio, IFB and talkback.

On the **Source Packages Conferences** subpage, you can find the following information related to source package conferencing: IFB Queue Top, Conference Suffix and talkback functionality.

### Destination Packages

This page contains information about the available packager outputs in the **Destination Packages** table. The Label, Title, SDI output, Park Source, IFB, Mix Minus, Input Package and Level of a destination package are displayed. There are also parameters available that add support for a panel.

### Matrix Configuration

This page allows you to configure the **Router** and **Packager Instance** and check their dimensions.

### UHD

This page allows you to configure the **UHD Sources** and **Destination** linking router inputs (for sources) or outputs (for destinations) to a UHD signal. A UHD source or destination can be added or removed via the right-click menu of the corresponding tables. There are also parameters available that add support for a panel.

### Studios

This page allows you to configure **Studios** used for **Devolved IFB Management**. You can add or remove a studio by right-clicking the table.

### Subscription Details

This page allows you to check and configure notification subscriptions sent through the WebSocket connections. It displays a status count of how many router outputs (for router input updates), packager outputs (for packager input and level updates) and packager inputs (for IFB queue updates) will send notifications.

You can remove subscriptions by selecting *Remove i*n a subscription row or by clicking the *Remove* button next to Pending Subscriptions (to remove older subscriptions).

### Logging

This page contains a list of log messages, as well as settings to configure the cleanup of old messages, to keep the table from growing indefinitely.

### Connections

This page contains connection information related to redundancy and automatic switchover between API instances, in case of an API issue.

## DataMiner Connectivity Framework

The 1.0.0.1 range of the Atos BNCS Packager protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.
DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Virtual dynamic interfaces:

- **Source Package HD Input**: For every **Source Package**, this *inout* interface is created.
- **Source Package HDE Input**: For every **Source Package**, this *inout* interface is created.
- **Source Package SD Input**: For every **Source Package**, this *inout* interface is created.
- **Source Package HD Output**: For every **Source Package**, this *inout* interface is created.
- **Source Package HDE** **Output**: For every **Source Package**, this *inout* interface is created.
- **Source Package SD** **Output**: For every **Source Package**, this *inout* interface is created.
- **Destination Package Video Input**: For every **Destination Package**, this *inout* interface is created.

Physical dynamic interfaces:

- **RouterInput**: For every **Router Input**, this *in* interface is created.
- **RouterOutput**: For every **Router Output**, this *out* interface is created.

### Connections

#### Internal Connections

- Between a **Router Input** and a **Router Output**, an internal connection is created when the input is connected to the output.
- Between a **Router Input** and a **Source Package HD Input**, an internal connection is created if the router input is defined as an HD SDI input on the source package.
- Between a **Source Package HD Input** and a **Source Package HD Output**, an internal connection is created.
- Between a **Source Package HD Output** and a **Destination Package Video Input**, an internal connection is created if the destination package is linked to that source package, its level is HD and the router input, defined as an HD SDI input on the source package, is connected to the router SDI output defined in the destination package.
- Between a **Router Input** and a **Source Package HDE Input**, an internal connection is created if the router input is defined as an HDE SDI input on the source package.
- Between a **Source Package HDE Input** and a **Source Package HDE Output**, an internal connection is created.
- Between a **Source Package HDE Output** and a **Destination Package Video Input**, an internal connection is created if the destination package is linked to that source package, its level is HDE and the router input, defined as an HDE SDI input on the source package, is connected to the router SDI output defined in the destination package.
- Between a **Router Input** and a **Source Package SD Input**, an internal connection is created if the router input is defined as an SD SDI input on the source package.
- Between a **Source Package SD Input** and a **Source Package SD Output**, an internal connection is created.
- Between a **Source Package SD Output** and a **Destination Package Video Input**, an internal connection is created if the destination package is linked to that source package, its level is SD and the router input, defined as an SD SDI input on the source package, is connected to the router SDI output defined in the destination package.
