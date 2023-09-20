---
uid: Connector_help_Skyline_Data_Aggregator_Monitor
---

# Skyline Data Aggregator Monitor

The *Skyline Data Aggregator Monitor* is responsible for continuously monitoring the status of Jobs defined within the Dataminer Data Aggregator.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial Version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Redundancy

There is no redundancy defined.

## How to use

In the Job page, the Job Status table presents the jobs defined in the Data Aggregator, along with their respective status data. The table's default refresh interval is set at 30 minutes, but this can be adjusted using the 'Update Interval' parameter.

Any errors encountered during the job executions are logged in the Log Failure table. The number of rows retained in this table are defined in the configurable parameters 'Log Row Limit' and 'Log Age Limit.'

Furthermore, the General page contains a tree view that presents an overview of the information previously mentioned.