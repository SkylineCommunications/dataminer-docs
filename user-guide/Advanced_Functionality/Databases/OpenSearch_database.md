---
uid: OpenSearch_database
---

# OpenSearch database

From DataMiner 10.3(CU0) and 10.3.1 onwards, it is possible to install a dedicated OpenSearch indexing database cluster as an alternative for Elasticsearch. This cluster also requires a Cassandra Cluster.

> [!NOTE]
> If you are looking to use the Amazon OpenSearch Service instead of on-prem hosted OpenSearch nodes, see [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service)

## Compatibility

Supported versions:

- 1.X
- 2.X

## Set up the OpenSearch Cluster

See the official [documentation](https://opensearch.org/docs/latest/) on how to set up your OpenSearch Cluster. A lot of configuration is the same as an Elasticsearch cluster. You can mostly the same settings if you are more familiar with those.

> [!NOTE]
> OpenSearch is only support on Linux and now Windows, as opposed to Elasticsearch

It's also possible to set up OpenSearch Dashboards, this is the equivalent to Kibana for Elasticsearch.
This is optional and not required for DataMiner to function.

## Connecting your DMS to an OpenSearch cluster

### Without TLS enabled

OpenSearch servers without TLS enabled can be connected to with just the IP address.
This will connect to the default port 9200.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig_OpenSearch_IPs.png)

### Non-default port

If the OpenSearch nodes are not running on default ports, the port must be explicitly added.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig_OpenSearch_IPs_With_Port.png)

### TLS enabled

If TLS is enabled the full url must be specified as `DB Server`, including the https.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig_OpenSearch_FQDN.png)

Again you can add a custom port if required.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig_OpenSearch_FQDN_and_Port.png)
