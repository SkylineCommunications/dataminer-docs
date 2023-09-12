---
uid: Connector_help_Quintech_Matrix_Serial
---

# Quintech Matrix Serial

This driver allows you to view and control the Quintech matrix crosspoints.

This driver uses a serial connection to display information on a Quintech matrix and allows you to configure the matrix.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 9.34                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

Serial CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.19.19.30*.
- **IP Port:** The polling IP port (default: *9100*).
- **Bus Address**: Default: *ff* (version 1.0.0.6).

## How to use

On the **General** page of this driver you can find **system information** and a page button to the **Ethernet** subpage, where you can configure all connection-related parameters.

On the **Matrix** page, the serial matrix is displayed. You can set a crosspoint between an input and output here. It is also possible to lock or unlock an input or output to prevent incorrect crosspoint sets.

## Notes

The Quintech matrix only allows labels of at most 7 alphanumeric characters.

When you change the label with invalid data in DataMiner Cube:

1.  The Cube matrix will show the invalid data
2.  An attempt will be made to change the label on the Quintech matrix using a formatted value, e.g. limited to 7 characters.
3.  After the attempt, the label in Cube will be replaced with the data available in the Quintech matrix.
