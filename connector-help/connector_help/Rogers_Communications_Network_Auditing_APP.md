---
uid: Connector_help_Rogers_Communications_Network_Auditing_APP
---

# Rogers Communications Network Auditing APP

This Network Auditing app gathers data collector input and output flow data so that it can be inserted into an SQL database.

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

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the **General** page, make sure to fill in the appropriate database information: the server **IP address**, the schema **Name**, and the **Username** and **Password**.

### Redundancy

There is no redundancy defined.

## How to use

In the **Polling Control** table, the connector will automatically list compatible elements it can gather data from to put into the database.

By default, all rows will be disabled. If you want the data of a specific element to be inserted into the database, **enable** the row and set the **polling frequency** to indicate how often you want the database to be updated.

The **Data Export** page allows you to export database tables to CSV files for storage. Note: These files will only be exported onto the DMA that hosts the Network Auditing APP element.

When element data has been successfully exported to the database, the **Polling Control** table will indicate the last time data was inserted. Polling error information will also be shown in this table.

## Notes

The following connectors are currently supported: **Harmonic Prostream** (1.0.1.x range), **Harmonic NMX** (4.0.1.x range), **Cisco DCM** (1.0.3.x range), and **Elemental Live** (1.0.0.x range).
