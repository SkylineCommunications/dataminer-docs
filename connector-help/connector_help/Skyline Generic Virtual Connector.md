---
uid: Connector_help_Skyline_Generic_Virtual_Connector
---

# Skyline Generic Virtual Connector

This is a generic driver with a master table in which rows can be added, deleted and edited via a context menu. Multiple rows can be deleted at the same time.

The display key is generated using the auto-incremented primary key (calculated in the table logic), column 1 value and column 2 value, so these are the only required data when a row is added.

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

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page shows the total number of entries or rows present in the master table.

On the **Master Table** page, you can right-click the table to open a context menu that allows you to perform the following actions:

- **Add**: Specify the values for the columns in the pop-up window and click *OK*. The ColumnValue1 and ColumnValue2 fields must always be filled in. Any fields that are left blank will automatically be filled with *N/A*.
- **Edit**: If you select this option for a selected row, in the pop-up window, you will be able to change any of its fields except the primary key. When you have specified your changes, click the OK button.
- **Delete**: Select this option for one or more selected rows in order to remove these from the table.
