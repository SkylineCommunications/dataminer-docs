---
uid: Connector_help_Atos_BNCS_Intercom
---

# Atos BNCS Intercom

This connector allows you to monitor and manage Riedel ring modules connected to BNCS, using the API developed by Atos.

It can be used to route Riedel ports and add them to conferences, monitor them and manage panel keys.

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

This connector uses an HTTP connection to maintain the notification subscriptions of the *Websocket* connection. It requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *5002*.
- **Bus address**: *bypassproxy*

### Configuration of instance

The router instance can be defined on the *Matrix Configuration* page.

## Usage

### General

This page contains information about the IP and port of the current **connections**, as well as **WebSocket Info**.

### Intercom Router

This page contains information about the available **input and output intercom ports** and indicates which input port an output is connected to.

Per **output** port, the **Port Gain** and **Port Usage** (**Conference Membership**, **IFB Output** and **Mixer Output**) are displayed.

Per **input** port, the **Port Gain** and **Port Usage** (**XY Routes**, **Conference Membership**, **IFB Mix Minus** and **Mixer Input**) are displayed.

There are also parameters available that add support for a router panel.

### Monitor Ports

This page contains information about the status of a **Monitor Port**. Right-clicking the table provides access to a context menu that allows you to add or delete a monitor port, to change or remove the monitored target or to synchronize with the available monitor ports.

### Conferences

This page contains information about the conferences and their members. To import conferences, you can import a *comms_mapping_tb.xml* file. Right-clicking the **Conferences** table provides access to a context menu that allows you to add a conference member, refresh the conference members or remove all conference members. Via the right-click menu of the **Conference Member** table, you can remove a member from a conference.

### Panel Keys

This page contains information about the available Riedel panels and their keys. Via the right-click menu of the **Panels** table, you can refresh its keys or clear all keys functions. Via the right-click menu of the **Panel Keys** table, you can add a key to a conference or IFB, or clear its functions.

### Highways

This page contains a list of intercom highway tielines between rings, detailing the source and destination port and the current tieline status. Via the right-click menu of the **Highways** table, you can refresh the current highway status.

### Rings and Ports

This page contains a list of the maintained rings and a list of the associated ports.

For each **Ring**, the ID and Label can be defined. In addition, the number of associated ports is displayed. There are also parameters available to add support for a visual panel. Via the right-click menu of the table, you can add or remove a ring, or refresh the associated ports.

For each **Port**, the ID, Type, Address, Input Names, Output Names, Function (General, Highway, Monitor and Monitor Highway) and Operational Area are displayed. Via the right-click menu of the table, you can refresh port details or force a synchronization of the intercom router inputs and outputs when ports have shifted or changed functionality.

### Panel Areas

This page contains a list of the maintained panel areas and a list of the associated intercom panels.

For each **Area**, the ID and Label can be defined. There are also parameters available to add support for a visual panel. Via the right-click menu of the table, you can add or remove an area, or refresh the associated panels.

For each **Panel**, the ID, Area, Name and Type are displayed. Via the right-click menu of the table, you can refresh the panel keys or clear functionality of all keys.

### Subscription Details

This page allows you to check and configure notification subscriptions sent through the WebSocket connections. It displays a status count of how many router outputs (for router input updates) will send notifications.

You can remove subscriptions by selecting *Remove i*n a subscription row or by clicking the *Remove* button next to Pending Subscriptions (to remove older subscriptions).

### Logging

This page contains a list of log messages, as well as settings to configure the cleanup of old messages, to keep the table from growing indefinitely.

### Connections

This page contains connection information related to redundancy and automatic switchover between API instances, in case of an API issue.

## DataMiner Connectivity Framework

The 1.0.0.1 range of the Atos BNCS Intercom protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.
DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- **RouterInput**: For every **Intercom Router Input**, this *in* interface is created.
- **RouterOutput**: For every **Intercom Router Output**, this *out* interface is created.

### Connections

#### Internal Connections

- Between a **Router Input** and a **Router Output**, an internal connection is created when the input is connected to the output.
