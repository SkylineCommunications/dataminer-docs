---
uid: Connector_help_SingTel_ForeTV_CMS_Generator
---

# SingTel ForeTV CMS Generator

This protocol can be used to import content information from XML files received by a content provider. An Excel file can also be exported with information for ForeTV.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

After you configure the credentials and the network location of the folder to import and export information, you will be able to perform some operations on the available files.

You can generate a file within a range from 1 to 24 hours with the information available on the CMS File table.

You can also import a flat File from ForeTV to DataMiner, and validate the content information available in the system.
