---
uid: Connector_help_Sky_UK_BSS
---

# Sky UK BSS

This driver can be used to obtain information on when a certain channel does not have to follow its master.

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

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation

### Installation

After you have filled in the connection settings on the **Database Settings** page of the element, the driver will connect to the Oracle database to retrieve data.

## How to Use

The element created with this driver consists of the following data pages:

- **General**: Displays the BSS Table, which lists entries showing when a channel does not have to follow its master.
- **Database Settings**: Contains the configuration parameters **Database Name**, **Server IP**, **Port**, **User Name** and **Password**. These parameters are needed to connect to the Oracle database.
