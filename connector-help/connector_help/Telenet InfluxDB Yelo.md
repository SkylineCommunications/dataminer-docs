---
uid: Connector_help_Telenet_InfluxDB_Yelo
---

# Telenet InfluxDB Yelo

This connector can receive JSON responses from the InfluxData InfluxDB Collector, parse these responses and display the parsed data in tables.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                    | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | InfluxData InfluxDB CollectorSupported Queries:- Yelo Total- Yelo Resources (Channel)- Yelo Channel Duplicate Rate- Yelo OS- Yelo Type- Yelo Client Type | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page, you can view all the data parsed from the JSON responses and grouped in tables.
