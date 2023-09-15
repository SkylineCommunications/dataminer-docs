---
uid: Connector_help_British_Telecom_Unified_Streaming_Controller
---

# British Telecom Unified Streaming Controller

This connector can be used to get an overview of the configured channels on origin servers, as well as to control the blackout state on a specific channel.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To be able to start using this connector, you must specify the following AWS credentials on the **Configuration** page of the element:

- **Access Key**
- **Secret Key**
- **AWS Region**
- **Service Name**

### Redundancy

There is no redundancy defined.

## How to use

Once the credentials have been specified on the Configuration page, the General page will show multiple rows from the Configured Channels table, containing the following information:

- **Channel Name:** The channel name configured at origin servers.
- **Origin:** The encoder associated to the channel. You can select a different channel encoder.
- **Blackout:** The blackout state of the channel. You can also configure this state.
