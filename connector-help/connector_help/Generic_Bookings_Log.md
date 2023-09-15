---
uid: Connector_help_Generic_Bookings_Log
---

# Generic Bookings Log

This connector manages log files linked to a booking application of the Service & Resource Management (SRM) framework.

## About

This connector will create/update log files for an SRM booking application. If a request is sent to the **Request Message** parameter, the connector will create or update a log file.

If a folder is selected where the files need to be created or updated, the connector will monitor its size and the number of files it contains.

Note that **no data traffic** will be visible for this connector in the **Stream Viewer**.

### Version Info

| **Range**               | **Description**                                                        | **DCF Integration** | **Cassandra Compliant** |
|--------------------------------|------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\]           | Initial version (22/12/2017)                                           | No                  | Yes                     |
| 1.0.1.x \[Standard Solutions\] | Log message request format changed. Not compatible with range 1.0.0.x. | No                  | Yes                     |

## Installation and configuration

### Creation

#### Main Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of Path Parameter

For the connector to work correctly, the **Path** parameter on the **Configuration** page must be set to an existing folder on the server or it should have **Cluster Mode** selected in order to
replicate the logging files on all the DMAs in the DMS.

## Usage

### General

This page displays the **Folder Statistics** of the **path** configured for the element. This includes the **Number of Files** in the folder, the **Folder** **Size** and the **Log Status Table Size**.

In addition, the page also contains the **Log Status** table, which lists the current log files in the folder. For each log file, the **File Name**, **Prefix** and **Postfix**, and the current **Status** are displayed.

In each row of the table, there are two buttons to **Update** or **Remove** a log file manually.

### Configuration

This page consists of three sections:

- The **Folder Setup** section contains the **Path** that is needed to create and update log files. The **Path Status** will indicate *Needs Configuration* in case no path has been set yet. In that case, new log entries will be discarded. Otherwise, it will indicate *Collecting*, and new log entries will be buffered and offloaded. This section also contains the **File Deletion Set Off Time** parameter, which determines when log files in the folder will automatically be removed to keep the folder from growing too large.
- The **File Data Setup** section contains the **Timestamp Addition** parameter. A timestamp is added to this parameter each time a log file is updated, taking into account the selected **Time Zone** and the defined **Date Time Format**. This section also allows you to define the **Separator** used to divide the logging information.
- The **File Name Setup** section contains the parameters to specify a **Prefix** and **Postfix** for the **File Name**.
