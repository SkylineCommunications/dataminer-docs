---
uid: DM_and_storage_selfhosted
---

# Self-managed DataMiner nodes and storage nodes

Exceptionally, instead of going for a standard DataMiner deployment model, you can manage both the DataMiner nodes and the storage nodes yourself. However, note that this is a **deviation from our advised deployment** path, and it is a **complex setup that we do not recommend**. As such, it will involve additional costs (e.g. procurement of additional hardware for hosting the databases and associated running and maintenance costs, mandatory Skyline Communications engineering services for the deployment and configuration of the database cluster, as well as for database-related tickets, etc.).

![Self-managed](~/dataminer/images/Self-managed.svg)

Each DataMiner System requires its own system data storage. This data storage serves as a repository for configuration data, historical parameter information, and alarm data. If you choose to host this data storage yourself, you will need to configure a dedicated clustered storage setup, using a Cassandra-compatible database service and an indexing database (i.e. a Search Cluster).

For detailed information, refer to [Dedicated clustered storage](xref:Dedicated_clustered_storage).
