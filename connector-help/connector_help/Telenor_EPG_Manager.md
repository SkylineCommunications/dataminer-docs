---
uid: Connector_help_Telenor_EPG_Manager
---

# Telenor EPG Manager

This is a virtual connector that creates **Telenor EPG Channel** **elements for every channel** detected in the Telenor system.

To detect a channel, the connector compares the channels listed in a CSV file and the list of XML TV files contained in a folder. If a channel is listed in the CSV file and a matching XML TV file is present in the folder, an element is created.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                              | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Telenor EPG Channel](xref:Connector_help_Telenor_EPG_Channel) | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

On the **General** page, you can specify the path to the CSV file and the path to the folder that contains the XML TV files.

The Services table on the **Services** page list all the channels and the IDs of the created elements.
