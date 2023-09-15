---
uid: Connector_help_Generic_sFlow_Collector
---

# Generic sFlow Collector

The purpose of this connector is to analyze the information received via **sFlow** packets to give network operators a better understanding of the flows of **data crossing the network**.

Depending on the range of this connector, incoming data might be **filtered** and **handled** in a different way.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                            | **Based on** | **System Impact**                                                                   |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                                                            | \-           | \-                                                                                  |
| 1.1.0.x              | Some of the logic has been moved to a separate **Generic sFlow Agent** connector.                                                              | 1.0.0.1      | An additional Generic sFlow Agent element will need to be created.                  |
| 2.0.0.x \[SLC Main\] | \- New branch supporting a different way of handling sFlow packets. - This branch works together with the **Generic sFlow Manager** connector. | \-           | \-                                                                                  |
| 3.0.0.x              | \- Offloads aggregated sFlow data to the **Elasticsearch** database. - This branch does not support the latest Elasticsearch changes yet.   | 2.0.0.x      | DataMiner Indexing needs to be installed on the DataMiner Agent to use this branch. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | sFlow Version 5        |
| 1.1.0.x   | sFlow Version 5        |
| 2.0.0.x   | sFlow Version 5        |
| 3.0.0.x   | sFlow Version 5        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | Generic sFlow Agent   | \-                      |
| 2.0.0.x   | No                  | Yes                     | Generic sFlow Manager | \-                      |
| 3.0.0.x   | No                  | Yes                     | Generic sFlow Manager | \-                      |

## Configuration

### Connections

#### Smart-Serial Main Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: *127.0.0.1*
  - **Type:** *UDP*
  - **IP port**: *6343*

### Initialization 2.0.0.x

Before an **sFlow collector** element will start processing the **sFlow** packets, the Agent first needs to be **confirmed**.

All Agents sending sFlow data to this collector will be listed in the **Agents** table, but confirming this Agent can only be done via the **sFlow Manager** element. Once the sFlow Manager confirms this Agent for the collector, the collector will start processing the received packets from the Agent.

## How to Use

**Only one** sFlow Collector element is supported per DataMiner Agent. These elements will listen to port **6343** of the Agent for incoming sFlow packets and process them (depending on filtering).

There are multiple branches of this connector, which all work differently.

### 1.1.0.x

The **Network Devices Overview** is the default page. It contains the **sFlow Agents Table**, which displays all sources from which sFlow packets are received.

The received sFlow data is offloaded to files. On the **Configuration** page, you can configure how long these offload files should be kept in case they were not processed by the sFlow Agent element.

You can also add or remove entries in the **ACL** table in order to filter specific sFlow data.

### 2.0.0.x and 3.0.0.x

Once an sFlow Agent is **confirmed** by the **sFlow Manager** element, the collector will start processing the packets from this Agent.

You can configure additional **filters** to make sure the sFlow Collector only processes the packets that you are interested in. These filters need to be set from the sFlow Manager.

There are some **statistics** available in the sFlow Collector that can be used to monitor **how many packets** have been **received**, how many are **processed** and if there is any **delay** in processing them.

The sFlow Collector will **aggregate** the sFlow packets and keep them in **memory** for 1 minute (sliding window). To investigate the traffic from the last minute, details about the aggregated sFlow data can be retrieved using the sFlow Manager.

Depending on the branch, the data can also be offloaded.

- In range 2.0.0.x, data is offloaded to files. However, this should only be done for debugging purposes.
- In range 3.0.0.x, data is offloaded to the Elasticsearch database. However, this range does not support the latest Elasticsearch implementation yet.
