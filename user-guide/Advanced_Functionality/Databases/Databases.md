---
uid: databases
---

# Databases

DataMiner supports multiple different [system data storage architectures](xref:Supported_system_data_storage_architectures). A standard setup makes use of an on-premises [Cassandra database](xref:Cassandra_database) and [Elasticsearch database](xref:Elasticsearch_database). However, instead of an on-premises Cassandra cluster, you can use the [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service)<!--  or use an [Azure Managed Instance for Apache Cassandra](https://azure.microsoft.com/en-us/products/managed-instance-apache-cassandra/) -->, and instead of Elasticsearch, you can also make use of the [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service) or use an on-premises [OpenSearch database](xref:OpenSearch_database).

In addition to these system databases, you can also configure an [offload database](xref:Offload_database), for example to produce reports without interfering with the live DataMiner System. [Additional databases](xref:Configuring_an_additional_database) can also be configured, for example for DataMiner Inventory & Asset Management.

> [!TIP]
> See also: [Securing the DataMiner databases](xref:Database_security)

> [!NOTE]
> When the main database is offline, file offloads are used to store write/delete operations. You can configure a limit for the file size of these offloads in the file [DBConfiguration.xml](xref:DBConfiguration_xml).
