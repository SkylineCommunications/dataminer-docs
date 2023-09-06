---
uid: Connector_help_SingTel_StableNet_Manager
---

# SingTel StableNet Manager

This connector can be used to export an Excel file with information for StableNet.

## About

### Version Info

| **Range**            | **Key Features**                                                          | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                          | \-           | \-                |
| 1.0.1.x              | Updated exception values on Downlink Frequency and Symbol Rate.           | 1.0.0.1      | \-                |
| 1.0.2.x \[SLC Main\] | Updated Events table primary key to use job ID instead of auto-increment. | 1.0.1.8      | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

After you configure the credentials and the network location or a local server location, you will be able to perform export operations.

You can generate a file every day at a time you define with the information available in the Events table. The automatic export can be disabled.

You can also manually export the information available in the Events table, and you can import information to the Events table from the Jobs API.
