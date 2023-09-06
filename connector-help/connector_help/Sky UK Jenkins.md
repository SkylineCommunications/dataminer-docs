---
uid: Connector_help_Sky_UK_Jenkins
---

# Sky UK Jenkins

This driver integrates with Jenkins. It will generate an overview of all channels, streams and jobs available on servers that have been manually specified, and it can execute jobs on the servers.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Jenkins ver. 2.48      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP main connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: 127.0.0.1
- **IP port**: 8080

### Initialization

To start using the element, add the necessary servers on the **Servers** page.

## How to use

The element consists of the following data pages:

- **General**: Contains information about the used job folder and the communication method.
- **Overview**: Contains a tree control with an overview of the structure of the job folder containing 3 levels: **Channels**,**Streams** and **Jobs**.
- **Channels**: Contains a table listing the channels. A channel is related to a certain type of sport and each channel has several **streams** in it.
- **Streams**: Contains a table listing the streams. A stream has a specific set of **jobs** that can be executed.
- **Jobs**: Contains a table listing thejobs. A job has a **pipeline** with several stages. After each execution, a status indicates if the execution was successful.
- **Servers**: Contains a table where you can manually add servers in order to communicate with them using the driver. Each job that is run will be executed on each server in the table.
