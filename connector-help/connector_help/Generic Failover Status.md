---
uid: Connector_help_Generic_Failover_Status
---

# Generic Failover Status

Thisconnector makes information available related to each of the DMAs in a Failover configuration.

It is a virtual connector, which requires no configuration during element creation. It will only display correct information if the DMA it is installed on is part of a Failover setup.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses a **virtual** connection and does not require any input during element creation.

## How to use

The General page contains two sections, one for each DMA in the Failover setup. Information on the first DMA is displayed on the left, while information on the second DMA is displayed on the right.

The information displayed on this page consists of the DMA details and overall status as well as a table with detailed status information.
