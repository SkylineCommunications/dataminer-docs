---
uid: Connector_help_Riedel_Communications_RSP_1200
---

# Riedel Communications RSP 1200

This connector is used to communicate with an RSP 1200 smart panel. This panel has different levers of which the current state can be read out. Each lever has an upper and lower LED of which the color can be changed. Each lever also has a small place on the screen of the panel; on this part of the screen a text and subtext can be set and the background color can also be changed. The screen on the right-hand side of the panel can also display an image. With a smart panel, the operator can send commands to DataMiner by pushing the levers. The changes of these levers will typically trigger Automation scripts that then perform actions, e.g. perform a set on a router element. DataMiner can then give feedback by changing LED colors and changing the displayed text and subtext. This way, you can have complete control using the panel without needing to have a screen with a DataMiner client open.

## About

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact** |
|----------------------|---------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                             | \-           | \-                |
| 2.0.0.x \[SLC Main\] | Fixed API. Integration with software panel. | 1.0.0.1      | \-                |

### Product Info

| **Range** | **Supported Firmware**            |
|-----------|-----------------------------------|
| 1.0.0.x   | Node API v1.3 Connection API v1.1 |
| 2.0.0.x   | API v1.3                          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.X   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection Panel

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: *bypassproxy*.

#### HTTP WebSocket Panel Connection (WebSocket Connection Consumer)

This connector uses an HTTP WebSocket connection. This will be dynamically filled in by the connector at runtime and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: Randomly selected port, different from the main connection to avoid conflicts at startup.
- **Bus address**: *bypassproxy*.

#### HTTP Connection DataMiner (Smart-serial)

This connector uses a smart-serial connection, which acts as an HTTP server and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- **IP address/host**: The IP of the DataMiner Agent hosting the element. The **device must be able to reach this IP**. This could be the IP of the second NIC. Do **not** specify localhost or 127.0.0.1.
- **IP port**: The IP port that the DataMiner Agent hosting the element will be listening to. This can be a randomly selected port, but it must not be in use by a process yet, and the **firewall** needs to be opened for this incoming TCP port traffic.

#### WebSocket DataMiner Connection (WebSocket Connection Producer - Smart-serial)

This connector uses a smart-serial connection, which acts as an HTTP WebSocket server and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- **IP address/host**: The IP of the DataMiner Agent hosting the element. The **device must be able to reach this IP**. This could be the IP of the second NIC. Do **not** specify localhost or 127.0.0.1.
- **IP port**: The IP port that the DataMiner Agent hosting the element will be listening to. This can be a randomly selected port, but it must not be in use by a process yet, and the **firewall** needs to be opened for this incoming TCP port traffic.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

HTTP GET calls will poll all needed UUIDs, which are then used to subscribe to the lever states entering through the WebSocket client connection. With an HTTP POST call, the device can subscribe through the WebSocket server connections to the settings that the element wants to set on the device.

The **General** page displays all functionality. The **Levers** table contains a row for every lever. The **Lever State** column will display if the lever is in the position *Up*, *Middle,* or *Down*. The other columns make it possible to set the title, subtitle, and colors.

Via the **Logo** page button, you can have an image displayed on the panel. To display an image file:

1.  Click the *Refresh* button of the **File List** parameter.
2.  Select an image file using the **File Location Logo** parameter. These image files are located under the Documents folder.
3.  Click the *File* button of the **Logo Upload** parameter to actually load the image on the device.

You can also upload the current Visio image that is assigned to the element. To do so, click the **Visio** button of the **Logo Upload** parameter. At startup, it can take up to 30 seconds to generate the Visio image. To avoid this delay, the **Fast Visio Loading** can be set to *Enabled*. To save resources, leave this parameter to *Disabled* if no Visio file needs to be loaded to the device or if this does not have to be loaded quickly.

The **Web Socket** page button displays the current dynamic URL that is being used, and the **Web Socket Status** shows if the connection is opened or closed. We highly recommend activating monitoring on this parameter to know if the device is still connected. If there is a timeout, try to restart the element to initiate all subscriptions again. As a WebSocket connection does not automatically reconnect when there is a timeout, the **Web Socket Automatic Reconnect** parameter provides this functionality. If there is no connection, each minute an attempt will be done to set up the connection again.

## Notes

WebSocket subscription can only be done once per item. This means that there can be **only one element communicating with the device**. When a second element is started, it will overwrite the subscriptions done by the first element, and the first element will no longer be able to perform any sets.

Moving from firmware 1.0.0-BETA3-e912b82#! to 1.1.0-Alpha-2a1729b changes the numbering of the levers. In the 1.0.0 firmware, the numbering of the upper levers is 1,3,5,7,9,11,13,15, and the lower levers are 2,4,6,8,10,12,14,16. In the 1.1.0, firmware the numbering of the upper levers is 1,2,3,4,5,6,7,8, and the lower levers are 9,10,11,12,13,14,15,16. This means that pushing the second upper lever on the device changes the state of the row with lever key 3 when firmware 1.0.0 is used, but it changes the state of the row with lever key 2 when firmware 1.1.0 is used.
