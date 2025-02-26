---
uid: Troubleshooting_Indexing_Database
---

# Troubleshooting – Indexing database

An indexing database is a specialized database designed to efficiently search and analyze large volumes of unstructured or semi-structured data.

In the context of DataMiner, if you do not use the recommended Storage as a Service setup but instead choose self-managed storage, you will need an indexing database (OpenSearch or Elasticsearch) alongside a Cassandra-compatible database service to configure a dedicated clustered storage setup.

An indexing database is required for many DataMiner features, including pattern matching, advanced analytics features, DataMiner Object Models (DOM), User-Defined APIs, and more.

> [!TIP]
> For more detailed information about DataMiner storage, see:
>
> - [About storage](xref:About_storage)
> - [Configuring an indexing database](xref:Indexing_Database)

## Basic concepts

Indexing databases create indexes, essentially data structures that organize and store information in a way that allows for fast retrievals. The key concepts of these architectures are:

| Concept | Description |
|--|--|
| Node | Single server within the database cluster that stores data and handles indexing and query operations. |
| Cluster | Collection of nodes that work together as a unified system to store, distribute, and manage data efficiently. |
| Index | Structured dataset used to organize and distribute data by categorizing it for faster querying. This structure can be compared to a table in a relational database. |
| Rollover | Creates a new index when the current one reaches a certain size, age, or document count. It ensures data is organized and manageable while automatically updating an alias to point to the new active index for seamless operations. |
| Alias | are logical references to one or more indexes, enabling seamless index management by abstracting indexes names. It simplifies query routing, versioning, and updates. For example, in rolling indexes, aliases are crucial for rollovers, pointing to the active index and updating automatically to ensure uninterrupted operations. |
| Shard | Subset or partition of an index, designed to distribute the data across multiple servers, enabling parallel processing and improved performance. |
| Replica | Copy of a shard, stored on a different node to ensure data redundancy and increase fault tolerance for high availability. |

For more detailed information on the basic concepts of indexing databases please refer to Intro to OpenSearch - OpenSearch Documentation and Elasticsearch basics | Elasticsearch Guide [8.15] | Elastic
Common problems associated with the indexing database
Taking into account the Dataminer data stored in these indexing DBs, the following symptoms may indicate that the health of the indexing DBs needs to be checked:
•	DataMiner does not start up: the agent may fail to start up if the indexing database is unavailable.
•	Element does not start up: at startup, elements read active alarm information from the indexing database. Failure to read the data will cause the error state on the element.
•	Data stored in the indexing database cannot be retrieved: 
o	Active or history alarms.
o	SRM data - bookings, resources, service definitions, etc. 
o	DOM data - This can be seen for example if a low-code app that uses DOM data is unable to display it.
•	User definable API functionality unavailable.
•	Analytics features unavailable.
•	Some DataMiner modules cannot be initialized: e.g. Resource Manager, UserDefinableApiManager, ProcessAutomationManager, etc.
