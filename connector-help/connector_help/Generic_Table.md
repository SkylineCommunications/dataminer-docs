---
uid: Connector_help_Generic_Table
---

# Generic Table

This connector can ingest any **CSV** and **XLSX** files, which can be used for multiple purposes in a DataMiner System

## About

### Version Info

| **Range**            | **Key Features**                                                      | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version. Imports a CSV file with a specific header structure. | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Imports CSV and XLSX files with any headers.                          | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### General

This page will show a table containing all the ingested data from a CSV or XLSX file. After the required files have been imported, you can change any of the imported values.

### Import Table Configuration

On this page, you can specify the folder where the CSV and XLSX files are stored and can select which file you want to import.

In the **File to Import** drop-down box, only CSV and XLSX files will be displayed, if any are available in the specified folder.

If new files have been added into the folder and they do not show up in the File to Import drop-down box, click the **Refresh List** button.
