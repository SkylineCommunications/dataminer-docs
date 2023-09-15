---
uid: Connector_help_Evertz_Mediator_Nexus
---

# Evertz Mediator Nexus

This connector communicates with the Mediator Mesh API. It can retrieve and display channel status and playlist information.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                        |
|-----------|-----------------------------------------------|
| 1.0.0.x   | Mediator Mesh API. No version info available. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

#### HTTP Connection - Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: Default 80.
- **Bus address**: Default *bypassproxy.*

IP CONNECTION:

- **IP address/host**: Acting as a server. Use "any" to listen from any source.
- **IP port**: Default 3000.
- **Bus address**: Default *bypassproxy.*

### Initialization

On the **General** page, specify the **Token** in the format "*MED \<token\>*".

Also on the **General** page, specify which channels should be retrieved from the device.

## How to Use

Once the channels and the token have been properly configured on the **General** page, the connector will poll the following information for each channel:

- Playlist Status
- Flat Playlist

The status is shown on the **Channel Status** page, and the flat playlist is shown on the **Playlist** page.

The connector will receive push notifications on the IP connection. When a notification is received, the status will be updated, and the playlist for the channel will be requested.
