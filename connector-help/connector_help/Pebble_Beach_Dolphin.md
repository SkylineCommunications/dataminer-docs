---
uid: Connector_help_Pebble_Beach_Dolphin
---

# Pebble Beach Dolphin

**Pebble Beach Dolphin** delivers highly automated integrated audio, video, and graphics functionality for ingest, channel branding, and frame-accurate multi-channel playout.

This connector communicates with the data source through HTTP requests.

## About

### Version Info

| **Range**            | **Key Features**              | **Based on** | **System Impact**                                                              |
|----------------------|-------------------------------|--------------|--------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version               | \-           | \-                                                                             |
| 1.0.1.x \[SLC Main\] | Implemented IS07 subscription | 1.0.0.x      | Existing elements will need to be recreated to make use of the new connection. |

### Product Info

| **Range** | **Supported Firmware**                                   |
|-----------|----------------------------------------------------------|
| 1.0.0.x   | Node: 1.3 \| Connection: 1.1 \| Events: 1.1              |
| 1.0.1.x   | Node: 1.3 \| Connection: 1.1 \| Events: 1.1 (WebSockets) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### WebSocket Nodes Connection (range 1.0.1.x)

From range 1.0.1.x onwards, this connector also uses a WebSocket connection.

WEBSOCKET CONNECTION:

- **IP address/host**: The polling IP or URL of the destination \[ws://IP\].
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

On the **General** page, versions need to be selected.

### Redundancy

There is no redundancy defined.

### Web Interface

Not available.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Allows you to select the node, connection, and events version to be polled. You can also specify at which rate the information should be polled.
- **Node:** Contains all node-related information.
- **Connection:** Contains all connector-related information.
- **Events:** Contains all events-related information.
- **Subscriptions**: Allows you to determine whether the sources are polled or updated by subscription.

## Notes

The current implementation of this connector is focused on Node version v1.3, Connection version v1.1, and Events version v1.1. Changing these versions may change the current results.
