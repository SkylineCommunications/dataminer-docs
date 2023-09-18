---
uid: Connector_help_UPC_Nederland_Subscriber_Provisioner
---

# UPC Nederland Subscriber Provisioner

This connector can be used to import information in **Arris D5 EdgeQAM**, **Arris E6000**, **Cisco CBR-8, Casa Systems C100G** and/or **Cisco RFGW-1-D** elements.

## About

This connector exports data to **Arris D5**, **Cisco RFGW-1-D**, **Casa Systems C100G, Cisco CBR-8** and **Arris E6000** elements. The data is imported from a CSV file.

Current version: **1.0.0.21**

Note:

- **Cisco RFGW-1-D** elements are only supported in this connector from version **1.0.0.6** onwards.
- **Arris E6000** elements are only supported in this connector from version **1.0.0.7** onwards.
- **Casa Systems C100G** elements are only supported in this connector from version **1.0.0.8** onwards.
- **Cisco CBR-8** elements are only supported in this connector from version **1.0.0.16** onwards.

The following information is exported:

- **Arris E6000** (from version 2.0.0.1 onwards):

  - **RF Ports** Table:

    - DTV subscribers
    - Custom description

  - **QAM Streams** Table:

    - HFC segment
    - QAM VOD cluster
    - DTV subscribers
    - HFC segment group ID

- **Arris D5** (from version 1.0.0.15 onwards):

  - **RF Ports** Table:

    - DTV subscribers
    - Custom description

  - Extra HFC segment info

- **Cisco RFGW-1-D** (from version 2.0.0.1 onwards):

  - **Global RF Port Configuration**

    - DTV subscribers
    - DTV custom description

  - Extra HFC segment info

- **Casa Systems C100G** (ranges 1.1.0.x and 3.0.0.x):

  - **RF Ports** Table:

    - DTV subscribers
    - Custom description

- **Cisco CBR-8** (from version 1.0.0.16 onwards):

  - **RF Ports** Table:

    - DTV subscribers
    - Custom description

  - **QAM Streams** Table:

    - HFC segment
    - VOD cluster
    - DTV subscribers
    - HFC segment group ID

Elements using Casa Systems and Cisco CBR-8 connectors:

An external set action is automatically done on the button **Update Service Groups** on the QAM page.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

To use this connector, you must supply the CSV file for import in the **Documents** folder of the element ("**C:\Skyline DataMiner\Documents\UPC Nederland Subscriber Provisioner\\**").

This file must contain semicolon-separated values in the following order:

"NETWORK ID;QAM;Type;Module;Port;Channel;VOD Cluster;HFC Segment;FiberNode;DTV Subscribers\[;Servicegroup\]".

Since this connector works with XLS files, the package "2007 Office System Driver: Data Connectivity Components" needs to be installed.

## Usage

### General

Select the CSV file in **File** by selecting a file name from the drop-down list. If the file you are looking for is not in the list, make sure you upload the CSV file to the Documents folder of the element (see Configuration section above).
Additionally, you can click the **Update File List** button to refresh the drop-down list.

To import the CSV file, click the **Read File** button.

The parameter **File Read Status** shows the status of the current import:

- *No file name provided*: Nothing was selected for the **File** parameter.
- *File not found*: The file does not exist or the user does not have the appropriate rights.
- *Reading file*: The file is currently being read.
- *Import successful*: The export has ended successfully.
- *Import failed*: An error occurred while reading the file.

A **File Progress Bar** is also displayed.

As soon as the **Configure Reports** button is pressed, a CSV file with the format *Export_ReportData_dd_MM_yyyy.csv* is generated.
This file is placed in the folder "**C:\Skyline DataMiner\Documents\UPC Nederland Subscriber Provisioner\KPI and KQI Editor**" and is automatically imported by a Skyline KPI & KQI element.

### Topology Converter

This page allows you to import a topology file from the drop-down list. If the file you are looking for is not in the list, make sure to upload the XLS file to the Documents folder of the element (see Configuration section above). Additionally, you can click the **Update File List** button to refresh the drop-down list.

To import the XLS file, click the **Import Topology** button.

The parameter **Topology File Read Status** shows the status of the current import:

- *No file name provided*: Nothing was selected for the **Topology File** parameter.
- *File not found*: The file does not exist or the user does not have the appropriate rights.
- *Reading file*: The file is currently being read.
- *Import successful*: The export has ended successfully.
- *Import failed*: An error occurred while reading the file.

It is also possible to have the **DTV Subscribers column** filled in based on several filters. To do so, click the **DTV Subscribers** **button** to open a subpage where you can set several filters and fill in a **DTV Subscriber Value**. Alternatively, the subpage also allows you to import DTV subscribers from a CSV file.

Finally, the **Export CSV File** button can be used to export a CSV file, which can later be imported on the General page.
