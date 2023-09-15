---
uid: Connector_help_Generic_Firmware_Collector
---

# Generic Firmware Collector

The Generic Firmware Collector driver gathers information related to the firmware version of all elements using a specific driver.

## About

### Version Info

| **Range**            | **Key Features**                                 | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Retrieves firmware version from driver elements. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

### General

This page contains the **Configuration Table**. In this table, the information on the connectors must be configured in order to obtain the firmware of their respective elements.

For this purpose, an entry must be added in the table for each driver. This can be done by right-clicking the table and selecting the option **Add** in the context menu. After this, a pop-up window will appear where the following fields must be configured:

- **Protocol**: Name of the connector.
- **Selection String**: Indicates the **PID** of the parameter where the firmware is available in the connector. If the firmware is available in a table, you must indicate the PID of the table, the PID of the column and the primary key in the following format: *Table:Column:PK*.
  The primary key can contain the wildcard "\*", which represents any number of characters, and "?", which represents any single character. To specify multiple PIDs, separate them using a semicolon (";").
- **State**: Indicates if the firmware data of the connector will be retrieved when the **Retrieve Data** button is pressed.
- **Delete**: Deletes an entry from the table.

This page also contains the subpage **Firmware Search**. This subpage contains the **Firmware Search Table**, which displays the firmware of the elements of the connectors that are enabled in the Configuration Table when the **Retrieve Data** button is pressed.

The **Firmware Search Table** contains the following columns:

- Element: Name of the element.
- Protocol: Name of the connector.
- Version: Version of the connector.
- Firmware: Firmware of the element.

### Firmware

This page contains the **Firmware Table**, which displays the firmware of the elements of all the connectors in the Configuration Table. This table is updated every day at 2 AM. The table contains the same columns as the **Firmware Search Table**.
