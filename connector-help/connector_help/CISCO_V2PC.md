---
uid: Connector_help_CISCO_V2PC
---

# CISCO V2PC

This connector can be used to monitor the activity of the Cisco V2PC video processor chassis.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v3.3.8-18642           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *8443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

An access token is required to access the API in the V2PC system. You can obtain this access token via the login API, for which a valid **username** and **password** must be specified on the Credentials subpage of the General page of this connector.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Displays the node statistics, alarms and events. On the **Credentials** subpage, you can set the device credentials (see "Initialization" above).
- **Infrastructure**: Contains a tree view of the infrastructure objects. Via page buttons, you can access subpages for the Nodes, Regions, Providers and Zones.
- **Channels**: Contains a tree view of the channels. Via page buttons, you can access subpages for the Sources, Streams and Channel Lineups.
- **Profiles**: Displays the channel profiles.
- **Policies**: Displays the device policies for asset redundancy, asset lifecycle, HTTPS header and subtitle.
- **Templates**: Displays the Publishing Templates table.
- **NAS**: Displays the NAS Media Sources and the NAS Stores.
- **Media Workflow**: Displays the Media Workflows and the Media Workflows Types.
- **Resources**: Displays the Nodes, Providers and Image Flavours.
- **Deployed Applications**: Displays a table listing the deployed applications.
- **Deployed Platforms**: Displays a table listing the deployed platforms.
- **Cloud Object Store (COS)**: Displays the COS IP Pools, Clusters and Nodes.
- **COS Nodes**: Displays detailed information about the COS clusters and nodes in a tree view.
