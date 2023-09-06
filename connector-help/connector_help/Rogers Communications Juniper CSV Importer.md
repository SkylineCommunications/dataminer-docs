---
uid: Connector_help_Rogers_Communications_Juniper_CSV_Importer
---

# Rogers Communications Juniper CSV Importer

This is a **data collector** driver that will import a CSV report file from the **Juniper** and will allow the user to filter the report using specific parameter filters.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

To get the data from the Juniper, configure the file path to the CSV report file on the **General** page, and then import the report.

Once the report has been read, the **Data** page can be used to display filtered rows from the CSV file. In order for the **Report** table to be filled in, select any combination of filters and click the **Search** button.
