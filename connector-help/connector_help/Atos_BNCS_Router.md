---
uid: Connector_help_Atos_BNCS_Router
---

# Atos BNCS Router

This connector allows you to monitor and manage router instances of the BNCS, using the API developed by Atos.

The router can be used to switch several SDI signals.

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

The router instance can be defined on the *Matrix Configuration* page.

## Usage

### General

This page displays information about the current **connections**, as well as **WebSocket Info** and information about the **Router** **Instances** and dimensions.

### Router

This page contains information about the available **router inputs** and **outputs** and indicates which input the router is connected to. There are also parameters available that add support for a visual panel.

### Matrix Configuration

This page allows you to configure the **Router** **Instance** and check its dimensions.

### Subscription Details

This page allows you to check and configure notification subscriptions sent through the WebSocket connections. It displays a status count of how many router outputs will send notifications (for router input updates).

You can remove subscriptions by selecting *Remove i*n a subscription row or by clicking the *Remove* button next to Pending Subscriptions (to remove older subscriptions).

### Logging

This page contains a list of log messages, as well as settings to configure the cleanup of old messages, to keep the table from growing indefinitely.

### Connections

This page contains connection information related to redundancy and automatic switchover between API instances, in case of an API issue.

## DataMiner Connectivity Framework

The 1.0.0.1 range of the Atos BNCS Router protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.
DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- **RouterInput**: For every **Router Input**, this *in* interface is created.
- **RouterOutput**: For every **Router Output**, this *out* interface is created.

### Connections

#### Internal Connections

- Between a **Router Input** and a **Router Output**, an internal connection is created when the input is connected to the output.
