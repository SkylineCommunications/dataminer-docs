---
uid: Connector_help_Telefonia_por_Cable_S.A_de_C.V._Topology_Aggregator
---

# Telefonia por Cable S.A de C.V. Topology Aggregator

This connector is to be used with the Telefonia por Cable S.A de C.V. Sapiens Offload driver. The information extracted from that connector is then used to create aggregated values in this connector using the configuration tables to establish relations and the KPI tables to store historical data points.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial Version  | \-           | \-                |

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

This connector is used to offload data retrieved from the DataMiner Aggregator to Elasticsearch storage.

The Configuration page contains the following settings:

- Network: These parameters are used to offload data to the Network Aggregated Table
- Market: These parameters are used to offload data to the Market Aggregated Table
- CCAP: These parameters are used to offload data to the CCAP Aggregated Table

File Path: This parameter contains the full file path of the CSV file that will be used by the connector to extract information from session records and store it in the corresponding table.

Processed Lines: This parameter displays the number of lines processed by the connector when reading the CSV file set in the previous parameter (File Path)

Last Update: This parameter displays the last time that a file was processed

Button 'Offload': This button can be used to execute a manual offload
