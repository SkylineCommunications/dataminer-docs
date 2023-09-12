---
uid: Connector_help_Telenor_Newtec_Dialog_Platform
---

# Telenor Newtec Dialog Platform

This driver is designed to retrieve information from a DMA that is set up by Newtec and contains protocols made by Newtec.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP of the Newtec DMA.
- **IP port**: 80
- **Device address**: BypassProxy

#### Virtual connection

This driver uses a virtual connection, for which no input is required during element creation.

### Initialization

This driver is designed to poll one DMA. In case of a cluster consisting of multiple DMAs, one element will be needed for each Agent in the cluster.

You need to specify the DMA ID of the agent you want to poll and the credentials.

On the **Polling Config** page, you can enable what you want to poll. Once this has been done, the element should start retrieving info from the other DMA.

### Redundancy

There is no redundancy defined.

## How to use

This driver retrieves all the **elements** and **protocols** on the specified DMA, as well as particular **tables** and **parameters** from elements, and displays these.
