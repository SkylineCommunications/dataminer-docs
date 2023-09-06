---
uid: Connector_help_Generic_SQL_Query
---

# Generic SQL Query

This connector can connect to an SQL Server database, execute queries, and retrieve the responses.

Note that this connector is different from the Generic MySQL Query connector, which is used specifically for MySQL integrations.

## About

### Version Info

| **Range**            | **Key Features**                                                                             | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Initial version. - Contains Queries Table to allow the configuration of periodic queries. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

### Redundancy

There is no redundancy defined.

## How to use

On the **Configuration** page, configure the **Server**, **Server Port**, **Database**, **SQL User** and **SQL Password** parameters in order to allow the connector to establish the connection.

The **SQL Connection State** parameter provides information about the current database connection state, while the **Execute State** provides more descriptive information about the connection state and query execution states.

If you intend to run a single query manually, you can configure the **SQL Query File Name** with the full file path to the file containing the query information.

You can also configure periodic queries in the **Queries** table, available on the **Queries** page.

The right-click menu of the table contains the following options:

- **Add Query**: Allows you to add a query by providing the Query Statement and the polling interval.
- **Delete Query**: Deletes the selected query from the table. You will need to confirm the deletion in a confirmation window.
- **Disable Query**: Disables the query polling, while keeping the query in the table.
