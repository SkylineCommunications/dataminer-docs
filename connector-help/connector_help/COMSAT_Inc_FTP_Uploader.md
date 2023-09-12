---
uid: Connector_help_COMSAT_Inc_FTP_Uploader
---

# COMSAT Inc FTP Uploader

This connector takes data from a **General Dynamics ACU 980** element and uploads trending data to an FTP server over time defined within the element.

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

On the **General** page, use the **Linked Element** parameter to specify the name of the ACU element within the DataMiner System.

To make use of the FTP exporting, input the FTP setting information on the **FTP & Email Config** page. Additionally, Automation scripts can be used to send an email on success or failure of the FTP upload using the **Email Automation Scripts** section.

## How to use

By default, the element will export real-time trending data from the **Linked Element** every 24 hours with an interval of 5 minutes. These two values can be configured as necessary.

When the **Next Upload Time** has passed, the data is gathered and placed into the "Skyline DataMiner\DMA_COMMON_DOCUMENTS\ACU_DATA" folder of the DataMiner System. The format of the created file can be defined with **File Prefix** and **File Timestamp Format**.

After a successful upload attempt, the **Upload Statistics** will be set with the **Status**, **Upload Time**, and **Filename**. If an upload was unsuccessful, the **Next Upload Time** will be increased but the **Last Successful Upload Time** will not change. On the next attempt to upload, data will be gathered up to the **Last Successful Upload Time**.
