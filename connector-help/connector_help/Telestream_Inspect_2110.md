---
uid: Connector_help_Telestream_Inspect_2110
---

# Telestream Inspect 2110

This **HTTP** connector communicates via the **Restful API** provided by the system. It displays the data in such a way that users can easily monitor ST 2110 and ST 2022-6 IP video networks.

## About

### Version Info

| **Range**            | **Key Features**                           | **Based on** | **System Impact** |
|----------------------|--------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                            | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Extra hidden connection to collect metrics | 1.0.0.3      | \-                |

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

#### HTTP Connection - WebService Interface

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP address of the data source.

HTTP Settings:

- **Port number**: 443

#### HTTP Connection - WebSocket Interface

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP address of the data source.

HTTP Settings:

- **Port number**: 443

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

**Note**: The **System Username and System Password** parameters can only be edited by DataMiner users with **security access level 1.**

### Range 1.0.0.x

- On the **Alarms** page, you can find the alarms and all their information in the **Alarms Overview** table. This information is polled every 30 seconds.
- On the **Programs** page, you can find the programs and all their information in the **Programs Overview** table. This information is polled every 5 minutes.
- On the **Ancdata Streams** page, you can find all ancdata information in the **Ancdata Overview** table. This information is polled every 5 minutes.
- On the **Audio Streams** page, you can find all audio information in the **Audio Overview** table. This information is polled every 5 minutes.
- On the **Video Streams** page, you can find all video information in the **Video Overview** table. This information is polled every 5 minutes.
- On the **Configuration** page, you can enter the system username and password so that the connector can access the API.

### Range 1.0.1.x

- The **Aggregate Metrics** page contains multiple tables for different metrics where the **Average**, **Min**, and **Max** is calculated for each stream.
- On the **PTP** page, you can find the **PTP Status** table.
