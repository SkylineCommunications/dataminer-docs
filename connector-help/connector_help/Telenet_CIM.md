---
uid: Connector_help_Telenet_CIM
---

# Telenet CIM

The Telenet CIM protocol provides an interface to communicate with nodes where CIM flow notification counters are installed.

This protocol will establish an HTTP connection via TCP/IP with the CIM nodes. The communication channel (requests/responses) between the DMA and the CIM nodes will be based on the Jolokia API, which is an external API used to optimize the retrieval of Flow Engine related counters in this case.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.3.5                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. xxx.yyy.zzz.com.
- **IP port**: The IP port of the device, e.g. 8080.
- **Device address**: The device address (default: ByPassProxy).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

You can find the following parameters on this page:

- **HTTP Connection Status:** *Ok* in case of a successful HTTP connection, or *Error* in case of a failure during the HTTP connection attempts.
- **Request Time**: The date (DD/MM/YYYY) and time (HH:MM:SS) when the DMA last successfully retrieved information via the HTTP connection.
- **Refresh Connection** button: Sends a new request to the target. The request time should update immediately after this action.
- **Tree control:** In this section, information about the flow statistic counters is displayed in a tree structure. The flow counters are at the top of the tree, with their specific state counters in a drop-down list.

### Flow Statistics

The same information as you can find in the tree control on the General page is available in two tables on this page:

- The **Flow Statistics** table lists the flow and state counters in the same order as they are received.
- The **Flow Statistics (Tree Overview)** table shows information after it has been grouped by state counters and no two of the same counters are displayed in multiple rows. This approach makes it easier to understand the structure of the tree control.

A **Tree Overview** button is also included for a pop-up version of the tree overview.
