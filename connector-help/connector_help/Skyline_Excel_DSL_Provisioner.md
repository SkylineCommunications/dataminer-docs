---
uid: Connector_help_Skyline_Excel_DSL_Provisioner
---

# Skyline Excel DSL Provisioner

This is a virtual connector that can be used to read Excel files and produce DSL files.

## About

With this virtual connector, all the information necessary to create a DSL (DataMiner Structured Files) file can be read from an Excel file, so that it can then be processed by the Skyline IAM DB Provision protocol.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not require any input during element creation.

## Usage

### General Page

This page displays the **Imported Data Table**, which contains with the information that was read from the selected **Excel file**.

In order to import data from the Excel file, the following information must be filled in:

- **Path of the files**: Directory where the **Excel files** are located.
- **Excel File Name**: Select an **Excel file** from the list.

The **Read Excel** button will import all the data from the selected Excel file into the **Imported Data Table**, where the data can then be edited.

Finally, to create the **DSL File**, define the **DSL Path** (by default: *C:\Skyline DataMiner\DSL*) and click the **Create DSL File button**.

### Import Errors Page

This page displays a table with any errors that occurred while the Excel file was imported. The **Import Errors DisplayKey** will display the file row number where the error occurred.

## Notes

If the **Read Excel button** does not perform any action, this can be because a **Microsoft Driver** is missing. You can find information about this error in the log file "*The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine*".

For this specific case, you can find the **Microsoft Driver** at <https://www.microsoft.com/en-us/download/confirmation.aspx?id=23734>.
