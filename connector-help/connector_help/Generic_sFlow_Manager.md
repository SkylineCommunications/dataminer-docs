---
uid: Connector_help_Generic_sFlow_Manager
---

# Generic sFlow Manager

The Generic sFlow Manager is used to manage the different Generic sFlow Collector elements in a DMS.

## About

### Version Info

| **Range**            | **Key Features**                                                                          | **Based on** | **System Impact**       |
|----------------------|-------------------------------------------------------------------------------------------|--------------|-------------------------|
| 1.0.0.x              | Initial version                                                                           | \-           | \-                      |
| 1.0.1.x              | Data stored in Elasticsearch database                                                     | 1.0.0.3      | Requires Elasticsearch. |
| 1.0.2.x \[SLC Main\] | New columns added to the Persistent Flows table, in order to display the interface names. | 1.0.1.1      |                         |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**   | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Generic sFlow Collector | \-                      |
| 1.0.1.x   | No                  | Yes                     | Generic sFlow Collector | \-                      |
| 1.0.2.x   | No                  | Yes                     | Generic sFlow Collector | \-                      |

## Configuration

### Connections

#### Range 1.0.0.x - Virtual connection

This connector uses a **virtual** connection and does not require any input during element creation.

#### From 1.0.1.1 onwards - HTTP connection

From version **1.0.1.1** of this connector onwards, an **HTTP** connection is used with **default port** 9200 in order to communicate with the Elasticsearch database.

## How to Use

### Configuration of sFlow Collectors

New **sFlow Collector** elements added to the DMS are **automatically** **registered** by the sFlow Manager element. The known sFlow Collectors can be found in the **Collectors** table on the Collectors page.

Any Agent sending sFlow packets to these collectors also gets registered by the sFlow Manager element. The Agents sending sFlow data to the DMS can be processed on the **Agents** page.
The sFlow packets sent by an Agent are not processed by the sFlow Collector as long as the sFlow Manager does not **confirm** that this Agent needs to be processed by that specific sFlow collector.

When a new Agent is **detected**, it will be added to the **Detected** **Agents** table, along with the sFlow collector that received data from this Agent. To start processing this Agent, it needs to be **confirmed** and then the linked sFlow collector will start processing the packets.
Note, however, that if an Agent sends sFlow data to multiple sFlow collectors, only one of these sFlow collectors can be used to process this data.

When an Agent is confirmed, it will be removed from the **Detected Agents** table and will be available in the **Agents** table. In the **Agents** table, several **configuration** options are available for the Agent, e.g. assigning it to a different collector, **pausing** the Agent, or **decommissioning** it.

### Configuration of Filters

You can assign **filter expressions** to an Agent to filter the sFlow packets received by the Agent.
Any packet that does not match the filter expression will not be processed.

These filters can be managed on the Filters page. The following tables are used to build the filters:

- **Filter Definitions**: The definitions are a base that can be used to filter on specific fields of an sFlow packet. These definitions are JSON files that are saved on the DataMiner Agent. You can override specific values from these definitions and provide a clear name for these.
- **Filter Instances**: A filter instance uses a specific definition and overrides the overridable fields with a specific value that will be used to check if the incoming packet matches that value.
- **Filter Expressions**: A filter expression is what can be assigned to an Agent. This expression could be a single filter instance, but it could also be a combination of different filter instances. Only AND and OR statements are supported in the expressions.

### Configuration of Protocol Headers

**Protocol** **Headers** are extra headers you can define that could be inside an sFlow packet.

The standard headers are automatically parsed by the sFlow Collector, but if you want more specific headers to also be parsed, then these can be configured in a file and that file record will be available here.

### Flows

The Flows page can be used to retrieve the aggregated flows data that was received in the **last minute** on all collectors for a specific Agent and interface.

### Persistent Flows

The **persistent flows** feature is available from version **1.0.0.2** of this connector onwards and can be used to **persistently monitor certain sFlow data**.

When an entry is added to the **Persistent Flows Configuration** table, this configuration is used each interval to get the active sFlow data matching the configured filter from the sFlow collectors.

The sFlow data will be added to the **Persistent Flows** table and is available for alarm monitoring and trending. When no data is received or some rows are no longer available, the values will be set to *"N/A"*, but the row itself will not be removed.

From version **1.0.1.1** of this connector onwards, the sFlow data is also stored in an Elasticsearch database. It is stored in two indices, one keeping a log of all the new information received, and another storing the general information of the sFlows and their most recent log data.

The information stored in the Elasticsearch database is used by the **Generic sFlow Viewer** and **Generic sFlow Monitor** connectors.
