---
uid: Connector_help_EEG_iCap_Caption_Server
---

# EEG iCap Caption Server

This protocol is used to monitor the EEG iCap Caption Server. From SDI to IP video, 4K, and everything in between, iCap is the largest closed-captioning and subtitle delivery network in the world.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver has several data pages:

- The **General** page contains the web interface credentials.
- The **Users**, **Access Codes** and **Caption Cast** pages display information about those subjects. You can add and edit information via their subpages.
- On the **Encoder Permissions**, **Shared Encoders** and **Access Keys** pages, you can find numerous tables with information related to those topics.
- On the **Logs**, **Session IDs** and **Uptime Statistics** pages you can request information by first specifying the username and time frame to retrieve the information.
- On the **Caption Providers** page, you can find a table with the information on every provider.
- The **System Health** page shows multiple parameters with some metrics related to the topic.
