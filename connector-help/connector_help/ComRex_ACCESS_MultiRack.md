---
uid: Connector_help_ComRex_ACCESS_MultiRack
---

# ComRex ACCESS MultiRack

ACCESS MultiRack is a rackmount IP audio multi-codec, capable of establishing and managing up to five simultaneous full-duplex IP audio codec connections. It is used for the encoding and decoding of audio data over an IP network and makes real-time audio communication between multiple locations easier.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### WebSocket Connection

This connector uses a serial connection and requires the following input during element creation:

WEBSOCKET CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. Required. Range: *81-85*. Default value: *81*.
- **Bus address**: The bus address of the device. Default value: *byPassProxy*.

### Initialization

Once the element has been created in DataMiner, the **Login** page allows you to specify the password to log in to the device (if the WebSocket connection is open).

After you click the **Login** button, the **Login Status** will indicate whether the login was successful.

## How to Use

The element has following data pages:

- **General**: Displays general information about the device.

- **Login** page button: Contains the WebSocket status, Password, Login button, and Login Status.

- **Connections**: Displays the Peers Table. With the right-click menu of the table, you can connect, disconnect, add, edit, or delete a peer.
  **Profiles:** Contains the Profiles Table.

- **Channels**: Displays channels and channel options.
