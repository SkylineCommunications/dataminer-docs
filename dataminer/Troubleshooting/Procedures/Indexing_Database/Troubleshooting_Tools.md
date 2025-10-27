---
uid: ID_Troubleshooting_Tools
---

# Troubleshooting tools

## DataMiner connectors

There are several DataMiner connectors available for download from the Catalog that can assist you in actively monitoring your indexing database and its hosting servers:

- [*Elasticsearch Cluster Monitor* connector](#elasticsearch-cluster-monitor)

- [*Skyline SSL Certificate Monitor* connector](#skyline-ssl-certificate-monitor)

- [*Linux Platform* connector](#linux-platform)

### Elasticsearch Cluster Monitor

The [*Elasticsearch Cluster Monitor* connector](https://catalog.dataminer.services/details/afe7853b-2784-467c-8cd9-71be79d9ca50) can be used to monitor the health of an Elasticsearch or OpenSearch cluster.

Key parameters that can be monitored using this connector include:

- *Data > General* page:

  - *Cluster Health* > *Connection Status*: Indicates whether DataMiner can successfully communicate with the cluster. The expected value is `Success`. If the status is different, it may indicate a connectivity issue.

  - *Cluster Health* > *Cluster Status*: Displays the current state of the cluster. The expected value is `All Primary and Replica Shards Are Active`.

  - *Cluster Health* > *Cluster Nodes*/*Data Nodes*: Displays the number of nodes in the cluster. A lower-than-expected number could mean that one or more nodes are unavailable.

  - *Cluster Health* > *Relocating Shards*/*Initializing Shards*/*Unassigned Shards*: Under normal circumstances, these values should be 0.

  - *Cluster Health* > *Failed Node Communications*: Displays the number of node communication failures detected by DataMiner. A value greater than 0 indicates that DataMiner has been unable to communicate with one or more nodes in the cluster.

- *Data* > *Cluster Stats - Nodes* page:

  - *Java Virtual Machine* > *Heap Memory Used Space*: Displays the percentage of allocated heap memory that is currently in use.

  - *Java Virtual Machine* > *Heap Memory Max Space*: Displays the maximum heap memory available to the JVM. This value is useful for determining how much memory the system can allocate.

- *Data* > *Cluster Stats - Nodes* > *Nodes - Operating/File System* page:

  - *File System* > *File System Available Space*: Indicates how much disk space is available on the node.

  - *Operating System* > *CPU Usage*: Displays the percentage of CPU resources being used by the node.

- *Data* > *Cluster Stats - Indices* page:

  - *Docs, Storage and Field Data* > *Stored Indices Size*: Displays the total storage size of the indices in the cluster.

  - *Docs, Storage and Field Data* > *Number of Documents*: Displays the total number of documents stored in the cluster.

### Skyline SSL Certificate Monitor

If the communication between DataMiner and the indexing database is secure, i.e. it uses SSL/TLS, you can use the [*Skyline SSL Certificate Monitor* connector](https://catalog.dataminer.services/details/382d6771-5162-47ce-aa2a-0f4a0d7ecd6d) to track the status of the SSL/TLS certificates that authenticate the connection and enable encryption.

Key parameters that can be monitored using this connector include:

- *Data* > *General* page:

  - *Sites* > *Status*: Displays the current state of the certificate. The expected value is `Success`. If the value is `Error`, the certificate is not valid, or the connection could not be established for another reason.

  - *Sites* > *Remaining Days*: Displays the number of days the certificate remains valid. We strongly recommend configuring an alarm to trigger when this value drops below 30.

### Linux Platform

The [*Linux Platform* connector](https://catalog.dataminer.services/details/33a5c495-60c9-4409-aecc-91f1876dacf1) is a generic solution for monitoring servers running a Linux operating system. While it does not include parameters specifically for monitoring an indexing database, some general parameters can be used to assess the status of database nodes:

- *Data* > *General* > *Total Processor Load*: Displays the overall CPU load on the server.

- *Data* > *Memory Info* > *Actual Physical Memory Usage*: Displays the amount of physical memory currently in use.

## Elasticsearch/OpenSearch tools

When troubleshooting, several tools are available to help interact with the indexing database and diagnose issues.

The best tool depends on your specific needs and the complexity of your indexing database setup.

### Visualization tools

These visualization tools allow you to explore and interact with large volumes of data stored in indexing databases. They help you build insightful visualizations, analyze logs, and set up dashboards for monitoring purposes.

- [Kibana](https://www.elastic.co/kibana) is designed for use with ElasticSearch.

- [OpenSearch Dashboards](https://opensearch.org/docs/latest/dashboards/) is compatible with OpenSearch.

### ElasticVue

[ElasticVue](https://elasticvue.com/) is a free, open-source graphical user interface (GUI) primarily for Elasticsearch, though it also supports OpenSearch. It provides a user-friendly way to explore, query, and visualize data stored in search clusters.

### Elasticsearch/OpenSearch APIs

Elasticsearch and OpenSearch provide REST APIs that can be useful for troubleshooting. These APIs offer insights into cluster health, node statistics, index statistics, and more.

For a detailed overview of the available APIs, see:

- [Elasticsearch REST APIs](https://www.elastic.co/guide/en/elasticsearch/reference/current/rest-apis.html)

- [OpenSearch REST APIs](https://opensearch.org/docs/latest/api-reference/)

These APIs can be accessed using various tools, including Postman and cURL.
