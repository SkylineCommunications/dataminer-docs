---
uid: Connector_help_Telenet_InfluxDB_IPVOD
---

# Telenet InfluxDB IPVOD

This connector can receive JSON responses from the InfluxData InfluxDB Collector, parse these responses and display the parsed data in tables.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                  | **Exported Components** |
|-----------|---------------------|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | InfluxData InfluxDB CollectorSupported Queries:- IPVOD Concurrent Sessions- IPVOD API Response Times- IPVOD API Error Response Counts- IPVOD SSM-TRAXIS Response Times | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page, you can view all the data parsed from the JSON responses and grouped in tables.
