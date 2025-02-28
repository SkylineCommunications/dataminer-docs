---
uid: ID_Troubleshooting_Tools
---

# Troubleshooting tools

## Available DataMiner drivers

We have multiple connectors available that allow you to actively monitor your indexing DB and its hosting servers.

### Elasticsearch Cluster Monitor

At the indexing DB level we have the [Elastic ElasticSearch Cluster Monitor](https://catalog.dataminer.services/details/afe7853b-2784-467c-8cd9-71be79d9ca50) to monitor the health of the indexing DB. This connector works for both ElasticSearch and OpenSearch.

Key parameters to monitor:

- Several parameters on the General page:

  - Connection Status: the expected value is "Success".

  - Cluster Status: the expected value is "All Primary and Replica Shards Are Active."

  - Cluster Nodes, Data Nodes: the count of nodes in the cluster. Numbers lower than normal indicate loss of a node.

  - Relocating Shards, Initializing Shards, Unassigned Shards: should be 0 during normal cluster operation.

  - Failed node communications: should be 0.

- JVM Heap Memory: parameters Heap Memory Usage Percent, Heap Memory Max Space in the table JVM Memory Statistics, page Node Stats - JVM.

- Disk Space: parameter Available Space in the table File System Statistics, page Node Stats - File System.

- CPU Usage: parameter CPU Usage, table Operating System Statistics, page Node Stats – OS / Processes.

- Index Size: parameters Store Size, Documents Count.

### SSL Certificate Monitor

If the communication between the DataMiner software and the indexing DB is secure, i.e., it uses SSL/TLS, you can use the [Skyline SSL Certificate Monitor](https://catalog.dataminer.services/details/382d6771-5162-47ce-aa2a-0f4a0d7ecd6d) to track the status of the SSL/TLS certificates that authenticate the connection and enable encryption.

Key parameters to monitor:

- General page, Sites table:

  - Status: the expected value is “Success”. If the status is “Error”, the certificate is not valid or connection could not be established due to another reason.

  - Remaining Days: the number of days the certificate remains valid. We advise to create an alarm when Remaining Days value is lower than 30.

### Linux Platform

[Linux Platform](https://catalog.dataminer.services/details/33a5c495-60c9-4409-aecc-91f1876dacf1) is a generic connector for monitoring servers with Linux OS. It does not have parameters specific to monitoring an indexing database, however, some general parameters may be used to assess the status of database nodes:

- Total Processor Load in the General page.

- Actual Physical Memory Usage in the Memory Info page.

## Elasticsearch/OpenSearch tools

Our focus in this document is troubleshooting. For that, several tools are available that can help you by interacting with indexing DB for example.

Which tool is the best depends on your specific needs and the complexity of your indexing DB Setup.

### Kibana/OpenSearch Dashboards

These are visualization tools that allow you to explore and interact with large volumes of data stored in indexing DBs. They help you build insightful visualizations, analyze logs, and set up dashboards for monitoring purposes.

[Kibana](https://www.elastic.co/pt/kibana) works with ElasticSearch and, as the name suggests, [OpenSearch Dashboards](https://opensearch.org/docs/latest/dashboards/) is compatible with OpenSearch.

### ElasticVue

This is a free and open-source GUI for interacting primarily with Elasticsearch, but it also supports OpenSearch. [ElasticVue](https://elasticvue.com/) provides a user-friendly way to explore, query, and visualize data stored in search clusters.

### Elasticsearch/OpenSearch APIs

These are REST APIs that can be helpful during troubleshooting to know the cluster health, node statistics, index statistics, and more. To have a detailed overview of the available APIs refer to [ElasticSearch REST APIs](https://www.elastic.co/guide/en/elasticsearch/reference/current/rest-apis.html) and [OpenSearch REST APIs](https://opensearch.org/docs/latest/api-reference/).

These APIs can be accessed using a variety of tools, including popular options like Postman and cURL.
