---
uid: Connector_help_Measat_Signal_Attenuation_Collector
---

# Measat Signal Attenuation Collector

The signal attenuation collector is a virtual connector that collects the current rain intensity and signal attenuation levels of 3 antennas for the AABC and ACBC site.

All collected data will be stored in the Elasticsearch database.

## About

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

On the **Configuration** page, you can configure from which elements and parameters data needs to be collected. Use the following syntax to configure this: *DMA ID*/*Element ID*/*Parameter ID*.
