---
uid: Connector_help_EC3_Networks_-_DDS
---

# EC3 Networks - DDS

With the EC3 Networks - DDS connector, you can monitor the DDS status and visualize and monitor the proxy and plugin info.

## About

### Version Info

| **Range**            | **Key Features**                                                        | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version. Includes proxy info, plugin info, and DDS status info. | \-           | \-                |
| 1.0.1.x \[SLC Main\] | REST API implementation                                                 | 1.0.0.x      | New connection.   |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination
- **IP port**: The IP port of the destination (default: *7899*).
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## How to Use

On the **General** page of this connector, you can monitor the overall **DDS Service Status**, the **API Status**, and the status of all the monitoring topics: **EPG**, **Ablaufplan**, **Senderprotokoll**, **Playlist Generator**, **ADC to DDS**, and **SL Editor**.

The **Proxy** and **Plugin** pages list the respective entries with their **Proxy Status** and **Plugin Status**.

To receive data from the **REST API**, fill in the **username** and **password** on the REST API page. When a **restart** of a plugin of an app pool is triggered, the last valid restart will be shown with its date and time.
