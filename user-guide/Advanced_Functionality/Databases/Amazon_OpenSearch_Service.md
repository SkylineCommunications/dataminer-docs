---
uid: Amazon_OpenSearch_Service
---

# Amazon OpenSearch Service

From DataMiner 10.3(CU0)/10.3.1 onwards, it is possible to Amazon OpenSearch Service on AWS as an alternative to a on-prem hosted Elasticsearch/OpenSearch cluster.

## Compatibility

Supported versions:

- OpenSearch version 1.3.

> [!NOTE]
> No Elasticsearch setups on Amazon OpenSearch Service are currently supported.

## Create your Amazon OpenSearch Service domain

1. Go to [AWS Management Console](https://aws.amazon.com/console/) and log in.
1. Go to [Amazon OpenSearch Service](https://aws.amazon.com/opensearch-service/).
1. Create your domain

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CreateDomain.png)

Configure your domain with the appropriate settings.
Make sure to select `Production` for `Deployment type`, OpenSearch version 1.3 and at least 3 nodes.

Also keep `compatibility mode` disabled.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_DeploymentType.png)

In the fine-grained access control settings, choose `Create master user`.

Provide a user name and password. Make sure to store this information somewhere as you are going to need it later to connect from Cube.

New domains typically take 15–30 minutes to initialize, but can take longer depending on the configuration. After your domain initializes, select it to open its configuration pane.

Note the domain endpoint under General information.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_DomainEndpoint.png)

## Connect your DMS to your Amazon OpenSearch Service domain

1. Ensure your DMS is up and running
1. Connect with Cube to your DMS and go to System Center -> Database

Configure your OpenSearch cluster together with your Cassandra Cluster as a `Database per cluster`.

> [!IMPORTANT]
> Ensure your server version is compatible for OpenSearch. Cube will display `Elasticsearch/OpenSearch` instead of `Elasticsearch` if your server is compatible.
>
> Since TLS will be enabled on AWS, the `DB Server` must be the full url, starting with https and ending with the port. For Amazon OpenSearch Service this means port 443, for example: `https://search-mydomain-123456798.eu-north-1.es.amazonaws.com:443/`

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CubeConfig.png)

## Restart the entire DMS

Restart the entire DMS so the configuration can take place.

## (Optional) Verify that the DMS is using the database

Open the `OpenSearch Dashboards URL` which will redirect you to your dashboard (equivalent of Kibana for Elasticsearch).

If you navigate to Management -> Dev Tools in the hamburger menu, you can execute the query `GET _cat/indices` and you should see that the DMS has created the necessary indices.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_DevTools.png)

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CatIndices.png)

> [!NOTE]
> In the example screenshots, the cluster health is yellow because only 1 node is used and 1 node clusters are always yellow.
