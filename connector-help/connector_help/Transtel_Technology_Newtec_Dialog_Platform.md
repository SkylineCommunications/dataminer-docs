---
uid: Connector_help_Transtel_Technology_Newtec_Dialog_Platform
---

# Transtel Technology Newtec Dialog Platform

This connector is designed to retrieve information from a DMA set up by Newtec and exports connectors made by Newtec.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.3                  |

### System Info

| Range     | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                     | - Transtel Technology Newtec Dialog Platform - Modulator<br>- Transtel Technology Newtec Dialog Platform - MDC6000<br>- Transtel Technology Newtec Dialog Platform - MDC6000 HCR<br>- Transtel Technology Newtec Dialog Platform - MDC7000 4CPM<br>- Transtel Technology Newtec Dialog Platform - General Switch<br>- Transtel Technology Newtec Dialog Platform - AZ212 and AZ202 Redundancy Switch |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP of the Newtec DMA.
- **IP port**: 80
- **Device address**: BypassProxy

#### Virtual connection

This connector uses a virtual connection, for which no input is required during element creation.

### Initialization

This connector is designed to poll one DMA. In case of a cluster consisting of multiple DMAs, one element will be needed for each DMA in the cluster.

To set up the element, you need to specify the DMA ID of the Agent you want to poll and the credentials.

On the **Polling Config** page, you can enable what should be polled. Once this has been configured, the element should start retrieving info from the DMA.

### Redundancy

There is no redundancy defined.

## How to use

This connector retrieves all the **elements** and **protocols** on the specified DMA, as well as particular **tables** and **parameters** from elements, and displays these.

It is possible to create DVEs for some of these DataMiner elements. These can be enabled in the exported protocol overview table.
