---
uid: Connector_help_Apache_Cassandra_Cluster_Monitor
---

# Apache Cassandra Cluster Monitor

Apache Cassandra is a NoSQL database designed to provide scalability, reliability, and availability with linear performance scaling. Cassandra databases are designed as a distributed system, aimed to handle big data efficiently.

This connector is designed to monitor a Cassandra cluster, providing useful information on nodes, roles, tables, repair history, and more.

## About

### Version Info

| **Range**            | **Key Features**                               | **Based on** | **System Impact** |
|----------------------|------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                | \-           | \-                |
| 1.0.1.x              | System checks                                  | 1.0.0.2      | \-                |
| 1.0.2.x \[SLC Main\] | Context menu to launch the Cassandra Installer | 1.0.1.5      | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                            |
|-----------|---------------------------------------------------------------------------------------------------|
| 1.0.0.x   | 3.11 4.0 (virtual tables: clients, disk_usage, max_partition_size, settings, tombstones_per_read) |
| 1.0.1.x   | 3.11 4.0 (virtual tables: clients, disk_usage, max_partition_size, settings, tombstones_per_read) |
| 1.0.2.x   | 3.11 4.x (virtual tables: clients, disk_usage, max_partition_size, settings, tombstones_per_read) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

**Note (only for the 1.0.0.x range): Make sure *ApacheCassandraCluster.dll* and *System.Threading.Tasks.Dataflow.dll* are present on the DMA in the folder *C:\Skyline DataMiner\Files*.**

### Initialization

When the element has been created, configure the connection to the Cassandra cluster. To do so, on the **Connector Settings** page, specify the **IP**, **Port**, **User Name,** and **Password**.

## How to Use

When the connection on the **Connector Settings** page has been configured, information from the Cassandra cluster will be retrieved and displayed in the element.
