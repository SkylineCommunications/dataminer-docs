---
uid: Connector_help_Ziggo_CPE_WiFi_Provisioning
---

# Ziggo CPE WiFi Provisioning

The **Ziggo CPE WiFi Provisioning** connector converts CSV files containing a list of cable modems to **DSL** (**DataMiner Structured Language**) files ready to be processed by a **Skyline IAM DB** element.

## About

Every day, at a configurable time, the connector retrieves CSV files from a specific folder. There are two types of CSV files, one type per footprint (**fZiggo** or **fUPC)**. The CSV file names must have the following format:

- **fUPC**: *YYYYMMDD*-fUPC.csv
  E.g*. '20170418-fUPC.csv'*
- **fZiggo**: *YYYY*-*MM*-*DD*-*HH*-*MM*-fZiggo.csv\[.gz\]\>
  E.g. *'2017-06-05-01-08-fZiggo.csv'*

The connector will parse the CSV files and convert them to **DSL** files.

When all the files are processed, the connector checks if there is an element using the **Skyline IAM DB** protocol in the DMS. If such an element exists, the connector triggers a set to that element to start the processing of the **DSL** file. The **Skyline IAM DB** element then calls the appropriate MySQL procedures to insert the modems in the IAM Database.

The connector also allows the configuration of the community string for both footprints.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page displays the main configuration parameters:

- **Provisioning Folder**: Folder containing the CSV files. By default *C:\MFTProvisioning\\*.

- **DSL Folder**: Folder where the DSL files will be saved. By default *C:\Skyline DataMiner\DSL*.

- **Provisioning mode** :

- *Full*: All the cable modems will be saved in the output **DSL** file.
  - *Differential*: The connector will compare the current list of modems with the previous list. Only the new, updated or deleted modems will be included in the **DSL** file.

- **Maximum Number of Files in History Folder**: When a CSV file has been processed, it is saved in a *History* folder (a subfolder of the **Provisioning Folder**). The parameter **Maximum Number of Files in History Folder** specifies how many files to keep in this *History* folder.

- **Provisioning time**: Time when the CSV files must be retrieved.

The **Start Provisioning** button can be used to start the retrieval of the CSV files manually.

The **Modem Type Table** lists the different available modem types. For each type, it is possible to configure:

- **fZiggo footprint**: The corresponding value in the CSV from the Ziggo footprint (if any).
- **fUPC footprint**: The corresponding value in the CSV from the UPC footprint (if any).
- **Polling:** Whether the modem type has to be polled by the DMS or not.

The **SNMP Config Table** allows you to configure the SNMP community for each footprint. When the footprint is modified, a **DSL** is generated in the **DSL Folder** and the **Skyline IAM DB** element is triggered.

### Statistics

This page displays statistics for the provisioning.

**Last Provisioning** indicates the last time the provisioning was executed (either via daily provisioning or when **Start Provisioning** was clicked).

The **Provisioning Statistics** table displays statistics for each footprint: **Number of modems**, **Status**, **Provisioning Date**, etc. The table also contains the parameter **File Size Threshold**. When a new CSV file is retrieved, the connector compares the size of the file to this threshold. If the file is too small, the file is discarded and the **Status** cell shows '*File Too Small*'.

### Collectors

This page contains a table listing all the collectors available in the system and the number of modems they manage.
