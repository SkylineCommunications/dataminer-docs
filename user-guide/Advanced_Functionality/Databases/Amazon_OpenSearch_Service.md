---
uid: Amazon_OpenSearch_Service
---

# Amazon OpenSearch Service

From DataMiner 10.3 [CU0]/10.3.2 onwards, it is possible to Amazon OpenSearch Service on AWS as an alternative to a on-prem hosted Elasticsearch/OpenSearch cluster.

## Compatibility

Supported versions:

- OpenSearch version 1.3.
- OpenSearch version 2.3.

> [!NOTE]
> No Elasticsearch setups on Amazon OpenSearch Service are currently supported.

## Create your Amazon OpenSearch Service domain

1. Go to [AWS Management Console](https://aws.amazon.com/console/) and log in.
1. Go to [Amazon OpenSearch Service](https://aws.amazon.com/opensearch-service/).
1. Create your domain

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CreateDomain.png)

Configure your domain with the appropriate settings.
Make sure to select `Production` for `Deployment type`, a supported OpenSearch version and at least 3 nodes.

Keep `compatibility mode` disabled.

For access policy, choose `Only use fine-grained access control`.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_DeploymentType.png)

In the fine-grained access control settings, choose `Create master user`.

Provide a user name and password. Make sure to store this information somewhere as you are going to need it later to connect from Cube.

New domains typically take 15–30 minutes to initialize, but can take longer depending on the configuration. After your domain initializes, select it to open its configuration pane.

Note the domain endpoint under General information.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_DomainEndpoint.png)

## Connect your DMS to your Amazon OpenSearch Service domain

To configure the connection to an Amazon OpenSearch Service database, configure the settings as detailed under [Amazon OpenSearch Service database](xref:Configuring_the_database_settings_in_Cube#amazon-opensearch-service-database)

> [!IMPORTANT]
> An Amazon OpenSearch Service database requires a separate Cassandra cluster or Amazon Keyspaces database.
