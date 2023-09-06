---
uid: Connector_help_Vizrt_Viz_Graphic_Hub
---

# Vizrt Viz Graphic Hub

The Viz Graphic Hub makes the database available to clients in the network. To log in to and work with Viz Artist, users must connect to a running Viz Graphic Hub server on a machine in the network. The server is started and shut down from the Viz Graphic Hub Terminal.

The Viz Graphic Hub REST is a web service for Viz Graphic Hub. It is an interface to retrieve and send data to and from Viz Graphic Hub via HTTP requests. This connector allows you to monitor the global data, functions, and REST agent of the Viz Graphic Hub.

## About

### Version Info

| **Range**           | **Key Features** | **Based on** | **System Impact** |
|---------------------|------------------|--------------|-------------------|
| 1.0.0.x\[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.2.0 (API 2.2.1)      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *19398*).

### Initialization

On the **General** page, of the element specify the **username** and **password** to log in, so that the connector can receive data.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page of this connector, you can configure the **username** and **password** to access the device. It also shows the **monitoring data** of the configured Viz Graphic Hub.

- The memory parameters are displayed on the **Memory** page.
- Everything about files can be found on the **Files** page.
- The calls are displayed on the **Calls** page.
- The **Disk Space** page contains parameters related to the disk.

The **Monitor Functions** page displays the monitoring data of the server functions of the configured Viz Graphic Hub.

The **Rest Monitor** page represents the monitoring data of the **REST agent**.

- **Libraries**: This page contains the list of **libraries** with their version.
- **Partitions**: This page contains the list of **partitions** of the REST agent. You can find the label, name, and space of each partition.
- **Processors**: This page contains all the **processors** of the REST agent.
- **CPU Usage**: This page contains the used **CPU percentage** of each kernel.
- **Network Adapters**: This page lists the **network adapters**, with the **status** of each adapter.
