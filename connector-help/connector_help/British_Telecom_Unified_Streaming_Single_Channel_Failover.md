---
uid: Connector_help_British_Telecom_Unified_Streaming_Single_Channel_Failover
---

# British Telecom Unified Streaming Single Channel Failover

The purpose of this connector is to manage the different Unified Origin Monitoring elements. It can change the streams to a different channel using Automation scripts.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                       | **Exported Components** |
|-----------|---------------------|-------------------------|---------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Unified Streaming Unified Origin Monitoring | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

To use this application, in the **Configurations** table, select the **Unified Streaming Controller** for each name.

## How to Use

The **General** page contains the list with all the data of the different controllers. Each row displays the state of its four controllers.

On the **Configurations** page, you can configure Unified Streaming Controllers.
