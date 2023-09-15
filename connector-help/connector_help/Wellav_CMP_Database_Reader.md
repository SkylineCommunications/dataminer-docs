---
uid: Connector_help_Wellav_CMP_Database_Reader
---

# Wellav CMP Database Reader

This connector retrieves the CMP data from a MySQL database.

## About

### Version Info

| **Range**            | **Key Features**               | **Based on** | **System Impact** |
|----------------------|--------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | SQL requests using SLDatabase. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the **General** page, you can find four parameters that must be configured in order to retrieve data from the MySQL Database: **Database Name**, **Server Address**, **Username** and **Password**.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page, you can find the parameters to connect to the MySQL Database, as well as the **Database Connection** parameter, which indicates the status of the connection with the database. It will be either ***OK*** when the connection does not have problems or ***Fail*** if there is something wrong with the queries or the database connection.

With regard to the configuration of the tables (**CMP**, **Status**, **Alarms** and **Alarm History**), it is possible to configure the number of rows of the **Alarm History** table to retrieve from the database. For the **CMP** table, a button is available to repoll the data from the database.

The following columns are retrieved for each table available in the connector:

- **CMP:** Name, ID, Register Time and Modify Time.
- **Status:** Time, Channel ID, Lock Status, Bitrate, Signal, CNR, CMP ID, CMP Name, Board ID, Board Name and CMP Time.
- **Active Alarms:** Time, Type, Level, Description, CMP ID, CMP Name, Board ID and Board Name.
- **Alarm History:** Time, Start Time, Handled Time, Type, Level, Description, CMP ID, CMP Name, Board ID and Board Name.
