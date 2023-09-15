---
uid: Connector_help_TDC_EDW_DB
---

# TDC EDW DB

The **TDC EDW DB** connector retrieves data from the **EDW Oracle** database and creates **DSL** (**DataMiner Structured Language**) offload files.

## About

This connector will create the following DSL files, which contain data from 1 or multiple database tables:

- **IngestEDWCableModemData**
- **IngestEDWAmplifierData**
- **IngestEDWCMCData**
- **IngestEDWLocationData**
- **IngestEDWSubscribersData**

The **Offload Cycle** for these stored procedures, which determines when tables should be polled and offloaded, can be configured in the connector. The same goes for the **location** where these DSL files should be stored. Each of these DSL files can also be disabled.

When an offload is started, the data will be stored in a **temporary file** and when all data is available in that file, the temporary file will be renamed to the following format: "*\[StoredProcedureName\]\_\[DataMinerID\]\_\[ElementID\]\_\[dd_MM_yyyy_HH_mm_ss\].csv*". After that, the file can be picked up to handle the data.

### Version Info

| **Range**     | **Description**                                                    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                    | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Based on v1.0.0.15. Review of the queries: Topology DB connection. | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of database connection

Before the database can be polled, you must first configure the **connection** to the database.

This is done on the **Configuration** page, where the following parameters need to be set before the offload can be started:

- **Host** (Database IP)
- **Port** (Database Port)
- **User ID**
- **Password**
- **Service Name**

### Configuration of offload

As mentioned in the "About" section of this page, it is possible to configure the **Offload Cycle** for both stored procedures. This can be done in the **Offload Info** table, on the **Configuration** page. By default, both stored procedures are offloaded every 24 hours, but you can increase or decrease this interval, or trigger the offload manually. The Offload Info table also contains more information about the last offload (**Time**, **Duration**, **Status** and **Entries**).

To be able to offload the data to the **DSL** files, you have to configure the **Path** where these files need to be stored. This is also done on the **Configuration** page. It is possible to configure a **local or network path**. If a network path is configured, then the **Network User** and **Network Password** are also required.

When **Check File Changes** is set to *Enabled*, only the changes since the last offload will be added in the new **DSL** file. To make it possible to compare the new data with the previous DSL, a copy is stored in the Documents folder of the DMA.

### Configuration of service packages (1.0.0.13 and higher)

From version **1.0.0.13** of the protocol onwards, the service packages can be configured in the **Service Packages** table. This table is available on a dedicated subpage that can be accessed via the **Configuration** page.

You can update the table either by individually adding entries via the right-click menu or via a CSV import. When you import from CSV, make sure that the header has the following format: *"Name \[IDX\] (Service Packages)";"DS (Service Packages)";"DS (Service Packages)".* This is the same header that will be used by DataMiner Cube when exporting the table.

## Usage

### Configuration

This connector does not show any actual data from the database, because all data is immediately offloaded to **DSL** files. The **Configuration** page is the only displayed page. It is used to configure the **Offload** and **Database** connection.

See the "Installation and configuration" section of this page for more info about the configuration of the element.

## Notes

Depending on the installed DataMiner version, it is possible that the following packages need to be installed on the DataMiner server to make sure that the Oracle connection works correctly:

- ODAC v12
- Instant client v12
- Instant client v12 - ODBC additions
