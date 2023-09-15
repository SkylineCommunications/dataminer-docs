---
uid: Connector_help_Skyline_IAM_DB
---

# Skyline IAM DB

This is a virtual connector, which is used to provision the system with new objects and provide updates to existing objects.

## About

This virtual connector is responsible for collecting **DSL (DataMiner Structured Language) files** and processing them sequentially. Based on the configuration of the IAM DB, the element will take the initiative to provision the system with new objects or provide updates to existing ones.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not require any input during element creation.

### Configuration

For this connector to work, the **DSL Files Configuration**, **Network Credentials Configuration** and the **DB Configuration** on the **General** page must be filled in as follows:

#### DSL Files Configuration

- **DSL Sync Rate**: The time defined in minutes between DSL retrieved actions. By default set to *5 minutes*.
- **DSL Directory**: The directory from which the DataMiner IAM DB element will retrieve the DSL files. By default set to *C:\Skyline DataMiner\DSL*.
- **Exclude DMA**: The IP addresses of DMAs where no DSL files are located, and for which therefore no lookup needs to be done.

Note:

- The DSL files are generated through the processing of different sources by **DSL-compatible connectors** (e.g. Huawei iManager U2000 D-CCAP) **or via a manual input file**.
- To use a **manual input file** (e.g. *IngestLocationDataOnDeviceManualIngest_xx_yy_zz*), the file has to be placed at the configured DSL path, as specified with the parameter **DSL Directory** on the **General** Page of the IAM DB element. It has to be placed on any server that is not excluded (cf. "Exclude DMA" parameter on the General page).
- Only manual files based on a **template** provided by Skyline can be used. Custom-made files will fail to be ingested.
- A DSL file is a **semicolon-separated CSV file**. It is important to check whether the file is formatted correctly, as some programs (e.g. Microsoft Excel) can add double quotes between the fields.
- When the processing of a file fails, you can find the reason for the failure in the **Log** table (cf. "IAM DB Information Page" section below). The file that could not be processed is moved into the folder *C:\Skyline_Data\IAM DB\Faulty Files,* on the DMA hosting the IAM DB element.

#### Network Configuration

- **Domain**: e.g. "SKYLINE2"
- **User** **Name**: e.g. "Admin"
- **Password**: e.g. "\*\*\*\*"

#### DB Configuration

- **DB** **Name**: e.g. "IAM"
- **Server** **Name**: e.g. "localhost"
- **DB** **User** **Name**: e.g. "root"
- **DB** **Password**: e.g. ""

To decrease the fetch time of the queries, you can increase the innodb_buffer_pool_size in the *my.ini* configuration file. The larger this is set, the less disk I/O is needed to access data in tables. On a dedicated database server, you can set this parameter to up to 80% of the machine physical memory size. However, be careful not to set it too large, because competition of the physical memory may cause paging in the operating system. Note that on 32-bit systems you may be limited to 2-3.5 G of user level memory per process, so do not set it too high.

## Usage

### General Page

The provisioning of the DataMiner system is done on a scheduled basis. You can also trigger it manually by checking the DM IAM DB element system (**Check DSL files button**) for available updates. The current status of the DM IAM DB element is displayed by the **DM IAM DB Status** (*Available*, *Busy*, *Error* or *Normal*) parameter. You can also find information related to the data status (*Normal* or *Invalid*) here, as well parameters related to the last sync, such as **Time Start**, **Time** **Finished** and **Time** **Duration**.

Finally, two extra parameters are displayed: **Total Number of DSL Files**, displaying the number of DSL files present in the *C:\Skyline_data\IAM\To Be Processed* folder, and **Current List of DSL Files**, displaying a list of the DSL files in the *To Be Processed* folder.

### IAM DB Information Page

This page provides the necessary information for a high-level verification of the current status of the connection and the data shared between DSL sources and IAM DB during the last sync. Three tables are displayed: **DMA**, **Log** and **Files**.

The **DMA table** displays the following information:

- **DMA IP**: IP address of the DMA.
- **Last Sync Total Number of DSL Files**
- **Last Sync Invalid Number of DSL Files**
- **Last Sync DMA Status**: *Normal*, *Error* or *Excluded.*
- **Last Sync Login Status**: *Valid* or *Invalid.*

The parameters above are available per DMA.

The **Log Table** records all the changes to the DMS provisioning data, data validation checks, the number of changes per cycle with timestamp and status information:

- **Index**: Auto-incremented.
- **Type:** *Info* or *Error.*
- **Duration Time:** Amount of time necessary to process an entire file.
- **Status Information:** Information or error message regarding the file processing.
- **Number of Changes:** Number of rows updated.
- **Timestamp:** Insertion time.

For the following **common issues**, you can find the **probable cause in the Log Table:**

- DMA access

  If the connection to a specific DMA failed, an exception is thrown, e.g. "*\|Unable to retrieved data from the following DMA: ...* ".

  In addition, the following message is logged: "*The connection has failed ... Last Error: ... Please recheck all network fields.*".

- Naming convention of DSL file

  The following DSL file format must be respected, as otherwise the file is not processed and it is moved to the *Faulty Files* folder:

  *StoredProcedureName_DataMinerID_ElementID_DAY_MONTH_YEAR_HOUR_MINUTES_SECONDS.CSV*

- DSL Processing

  If the DSL file contains no data or the EOF marker is not present in the file, an exception is thrown, the file is not processed and it is moved to the *Faulty Files* folder.

- StoredProcedure

  When inserting data into the DB, the input parameters of storedProcedure must be respected, as otherwise an exception is thrown and the processing of the file is stopped. E.g. "*Incorrect number of arguments for PROCEDURE iam.IngestAMPData; expected 8, got 9*". The DSL file is then also moved to the *Faulty Files* folder.

This information will be updated and logged each polling cycle.

Finally, the list of files per DMA is shown in the **Files Table**, which includes the following information:

- **File Name**
- **Source IP**
- **Time of Retrieval**

## Note

In order to avoid unlimited tables, older rows are removed every 24 hours.
