---
uid: Connector_help_Skyline_Data_Aggregator_Monitor
---

# Skyline Data Aggregator Monitor

This connector is responsible for continuously monitoring the status of jobs defined within the DataMiner Data Aggregator.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial version  | \-           | \-                |

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

On the **Job** page, the **Job Status table** shows the jobs defined in the Data Aggregator, along with their respective status data. The table's default refresh interval is set to 30 minutes, but you can adjust this using the **Update Interval** parameter.

Any errors encountered during job executions are logged in the **Log Failure** table. The number of rows retained in this table is defined with the **Log Row Limit** and **Log Age Limit** parameters.

The **General** page also contains a tree view with an overview of the previously mentioned information.
