---
uid: Connector_help_Telefonia_por_Cable_S.A_de_C.V._Sapiens_Offload
---

# Telefonia por Cable S.A de C.V. Sapiens Offload

Loads data from CSV files on button presses and loads information to Logger Tables to be retrieved via GQI Custom Operators. This connector works in hand with the Telefonia por Cable S.A de C.V Topology Aggregator connector to map out and aggregate the data points.

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

Configure the file paths in the configuration page and trigger button when ready to ingest file.

Upstream Channel SNR: These parameters are used to offload data to the table Upstream Channel SNR Data- Upstream Utilization: These parameters are used to offload data to the table Upstream Channel Utilization- Upstream Utilization: These parameters are used to offload data to the table Downstream Channel Utilization

File Path: This parameter contains the full file path of the CSV file that will be used by the connector to extract information from session records and store it in the corresponding table.Processed Lines: This parameter displays the number of lines processed by the connector when reading the CSV file set in the previous parameter (File Path)

Last Update: This parameter displays the last time that a file was processed.

Button 'Offload': This button can be used to execute a manual offload.

## Notes

On the General page of the element, you can find a read me with more information.
