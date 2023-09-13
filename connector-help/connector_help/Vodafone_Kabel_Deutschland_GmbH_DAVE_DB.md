---
uid: Connector_help_Vodafone_Kabel_Deutschland_GmbH_DAVE_DB
---

# Vodafone Kabel Deutschland GmbH DAVE DB

This connector is used to communicate with the Digital Audio Video Environment database.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | JSDOC 3.6.4            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.

  If you want to use HTTPS, you can either specify the **IP address/host** preceded by **https://** or set the port to **443**.

- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

The connector needs to be able to authenticate in order to poll the different nodes. To configure this, go to the **General** page, and specify the correct **User Name** and **User Password**.

When authentication is successful, you can select the **Polling Stage** that needs to be polled.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Notes

The connector makes use of a poll queue to poll the different nodes. Each row present in the **Poll Queue** represents a different node.

Each node can be configured independently, meaning you can adjust the **State** and **Polling Interval** or perform a hard refresh.

You can make changes to every table in the connector by means of a **context menu** that you can access by right-clicking the table or a row in the table.

In each table, you can **add, update, and delete** items, except in the **Service-Names** table. That table can only be modified by **Content Employees**.
