---
uid: Connector_help_TDC_Topology_DB
---

# TDC Topology DB

The **TDC Topology DB** connector retrieves data from the **Topology** **Oracle** database and creates **DSL** (**DataMiner Structured Language**) offload files.

The connector will create DSL files from data available in the following tables:

- CMC
- OLT
- AMPLIFIER
- INSTALLATIONADDRESS
- ADDRESSCUSTOMERPRODUCT
- CUSTOMER
- MODEM_INSTALLATION_ADDRESS
- SPLITTER

The **offload cycle** for these tables, which determines when they should be polled and offloaded, can be configured in the connector. The same goes for the location where these DSL files should be stored.

When an offload is started, the data will be stored in a **temporary file**, and when all data is available in that file, the temporary file will be renamed to the following format: "*\[StoredProcedureName\]\_\[DataMinerID\]\_\[ElementID\]\_\[dd_MM_yyyy_HH_mm_ss\].csv*". After that, the file can be picked up to handle the data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

## How to use

This connector does not show any actual data from the database, because all data is immediately offloaded to **DSL** files.

### Offload Settings

To configure the **Offload Cycle** for the tables, use the **Offload Info** table on the **Configuration** page. By default, all tables are offloaded every 24 hours, but this time period can be increased or decreased. The Offload Info table also contains more information about the last offload (**Time**, **Duration**, **Status**, and **Entries**). You can also manually trigger a new offload.

To be able to offload the data to **DSL** files, you also have to configure the path where these files need to be stored. This is also done on the **Configuration** page. It is possible to configure a local or a network path. If a network path is configured, the **Network User** and **Network Password** are also required.

When **Check File Changes** is set to *Enabled*, only the changes since the last offload will be added in the new **DSL** file. To make it possible to compare the new data with the previous DSL, a copy is stored in the Documents folder of the DMA.

### Ping Query

To check the **connection** towards the database, a **ping query** can be used.

This query is executed in a configurable cycle (**Ping Query Cycle**) with a default of *15 minutes*. Note that this query will only be executed if the **Ping Query State** is *enabled* (which is not the case by default).

When the ping query **fails**, it will set the element into **timeout**, and the regular queries will not be executed. As soon as the ping query is OK again, the normal queries will also be executed.

### KQI/KPI Score

The **KQI/KPI Score File Path** defines the folder where the DSL files with the KQI/KPI score will be saved.

A query is executed periodically to check if the database was updated with the hourly KQI scores. After the update, the connector will wait for the duration of the **KQI Query Wait Time** before executing the query to poll the KQI score data.

The **Number of CMs** displays the number of CMs found in the KQI score file.

The **Max Number of KQI/KPI Files** parameters set the maximum number of files in the folder. The oldest files will be deleted when this maximum is reached. The **Last KQI/KPI Score Time** parameters display the time when the last file was created.

The **Retrieve Score Data** button creates new KQI and KPI files.

## Notes

Depending on the installed DataMiner version, it is possible that the following packages need to be installed on the DataMiner server to make sure that the Oracle connection works correctly:

- ODAC v12
- Instant client v12
- Instant client v12 - ODBC additions
