---
uid: OpenSearch_database
---

# OpenSearch database

From DataMiner 10.3 [CU0]/10.3.2 onwards, it is possible to install a dedicated OpenSearch indexing database cluster as an alternative for Elasticsearch. This indexing cluster also requires a Cassandra cluster.

> [!NOTE]
> If you are looking to use the Amazon OpenSearch Service instead of on-prem hosted OpenSearch nodes, see [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service)

> [!NOTE]
> If you are looking to use the Amazon OpenSearch Service instead of on-prem hosted OpenSearch nodes, see [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service)

## Compatibility

Supported versions:

- OpenSearch 1.X
- OpenSearch 2.X

## Setting up the OpenSearch Cluster

See the official [documentation](https://opensearch.org/docs/latest/) on how to set up your OpenSearch cluster. A lot of configuration is the same as for an Elasticsearch cluster.

> [!NOTE]
> OpenSearch is only supported on Linux and not on Windows, as opposed to Elasticsearch

It's also possible to set up OpenSearch Dashboards, this is the equivalent to Kibana for Elasticsearch.
This is optional and not required for DataMiner to function.

> [!IMPORTANT]
> The JVM Heap Space must be set to a value larger than the default on production systems.
> To configure this, see [Important settings](https://opensearch.org/docs/latest/opensearch/install/important-settings)

## Connecting your DMS to an OpenSearch cluster

You can configure the connection to your OpenSearch cluster via DataMiner Cube. Head to System Center, Database and select `Database per cluster`.

> [!IMPORTANT]
> Ensure your server version is compatible for OpenSearch. Cube will display `Elasticsearch/OpenSearch` instead of `Elasticsearch` if your server is compatible.

### [With TLS](#tab/tabid-1)

If TLS is enabled the full url must be specified as `DB Server`, including the https.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig_OpenSearch_FQDN.png)

You can add a custom port if required. Otherwise port 9200 wil be used by default.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig_OpenSearch_FQDN_and_Port.png)

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig_OpenSearch_FQDN.png)

### [Without TLS](#tab/tabid-2)

> [!WARNING]
> Running OpenSearch with TLS disabled is not recommended and poses security risks.

OpenSearch servers without TLS enabled can be connected to with just the IP address.
This will connect to the default port 9200. If another port is required, specify it, e.g. `10.1.2.3:12345`.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig_OpenSearch_IPs.png)

If the OpenSearch nodes are not running on default ports, the port must be explicitly added.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig_OpenSearch_IPs_With_Port.png)
