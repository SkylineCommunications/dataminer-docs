---
uid: Connector_help_Inmarsat_BGAN_Manager
---

# Inmarsat BGAN Manager

The Inmarsat BGAN Manager driver is used to monitor the BGAN network and execute small operations. The BGAN network is a satellite communications network that allows voice, video and data sessions on remote terminals. This means that the bulk of interesting data focuses on the terminals and their details.

## About

### Version Info

| **Range**            | **Key Features**                          | **Based on** | **System Impact** |
|----------------------|-------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Poll Customers Poll Terminals and details | \-           | \-                |

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
- **IP port**: The IP port of the destination. (default: *443*)
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

The credentials must be filled in on the General page in order for any information to be polled. As long as this is not done, the element will not work. The credentials list is as follows:

- User Name
- Password
- Scope
- Client ID
- Client Secret

The user name and password can be configured in the network. The default scope, client ID and secret can be found in the Rest API documentation. However, they will be configurable in the network.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use (1.0.0.x)

### General

Credentials can be configured on this page, and a login can be enforced. There is also information on the current status of the authentication process.

### Customers

This page displays generic information for all customers currently accessible from the configured user.

### Terminals

The bulk of the data can be found here. The page contains a generic terminals table as well as the terminal details and terminal location information. These last tables will only be refreshed automatically every hour, but a refresh button can be used to force a manual refresh, if necessary.

This design takes the potential scaling of the system into account. The terminal details are obtained per terminal, which means that, in a larger network, this operation may take significantly longer than might be expected, and some strain may be added on the network. As such, the current values were chosen to allow for a more relaxed information update.

The progress bar can be useful to check the status of the terminal details refresh. The larger the network, the smaller each increment will be per terminal. In case the progress bar is not advancing at all for some time, this could indicate that there is an issue. In that case, contact Skyline Communications.

## Notes

**1.0.0.x**: **Terminal detail data is obtained per terminal**. This means that in **larger networks** this set of operations will become **slower**. The larger the network, the longer it will take to obtain all the terminal data.
