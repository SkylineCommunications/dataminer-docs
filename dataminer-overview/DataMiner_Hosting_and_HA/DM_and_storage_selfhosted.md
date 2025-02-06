---
uid: DM_and_storage_selfhosted
---

# Self-hosted DataMiner nodes and storage nodes

If this is really necessary, you can host both the DataMiner nodes and the storage nodes yourself. However, this is a **complex setup that we do not recommend**.

![Self-hosted](~/user-guide/images/Self-hosted.svg)

Each DataMiner System requires its own system data storage. This data storage serves as a repository for configuration data, historical parameter information, and alarm data. If you choose to host this data storage yourself, you will need to configure a dedicated clustered storage setup, using a Cassandra-compatible database service and an indexing database (i.e. a Search Cluster).

For detailed information, refer to [Dedicated clustered storage](xref:Dedicated_clustered_storage).
