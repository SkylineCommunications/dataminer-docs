---
uid: Connector_help_Zabbix_Platform
---

# Zabbix Platform

Zabbix is software that monitors numerous parameters of a network as well as the health and integrity of servers.

This HTTP connector connects to the Zabbix API to retrieve data from the Zabbix platform. The Zabbix API is a web-based API that is shipped as part of the web front end. It uses the JSON-RPC 2.0 protocol. This connector will export different connectors based on the retrieved hosts from the API. For more information on the device, refer to <https://www.zabbix.com/documentation/3.0/manual/api>.

## About

### Version Info

| **Range**            | **Key Features**                        | **Based on** | **System Impact** |
|----------------------|-----------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                        | \-           | \-                |
| 1.1.0.x \[SLC Main\] | API 4.0: new features were implemented. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | 4.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                    |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     |                       |                                                                            |
| 1.1.0.x   | No                  | Yes                     | \-                    | [Zabbix Platform - Host](xref:Connector_help_Zabbix_Platform_-_Host) |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To be able to retrieve data from the API, specify a **Username** and **Password** on the **Configuration** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **General** page, a tree view is displayed that allows you to drill down from a **Host Group** to a single **Host**. The **Configure DVEs** page button opens a subpage where DVEs can be configured.

The **Configuration** page displays the **API Info**. On this page, you can also set the **Username** and **Password** that are used to retrieve data from the API, and configure the **URL** needed to connect to the device.
