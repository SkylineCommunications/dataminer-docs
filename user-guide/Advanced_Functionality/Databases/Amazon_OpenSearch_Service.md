---
uid: Amazon_OpenSearch_Service
---

# Amazon OpenSearch Service

From DataMiner 10.3.0/10.3.3 onwards, it is possible to use Amazon OpenSearch Service on AWS as an alternative to a on-prem hosted Elasticsearch/OpenSearch cluster.

> [!NOTE]
> Although the service is named after OpenSearch, it offers both OpenSearch and Elasticsearch clusters.

## Compatibility

Supported versions:

- Elasticsearch version 6.8
- OpenSearch version 1.X
- OpenSearch version 2.X

> [!NOTE]
> DataMiner currently does not support Elasticsearch version 7.X setups.

## Creating your Amazon OpenSearch Service domain

1. Go to [AWS Management Console](https://aws.amazon.com/console/), and log in.

1. Go to [Amazon OpenSearch Service](https://aws.amazon.com/opensearch-service/).

1. Create your domain.

   ![Create Domain](~/user-guide/images/Amazon_OpenSearch_CreateDomain.png)

1. Configure your domain with the appropriate settings.

1. Set `Deployment type` to "Production", and select a supported version and at least 3 nodes.

1. Choose an instance type.

   The instance type determines the hardware specifications of your cluster. You cannot change this setting later without creating a new domain. This setting determines the resources of your cluster and will dictate the performance of the cluster as well as the price.

   For more information on the specifications and pricing of each type, see [Amazon OpenSearch Service Pricing](https://aws.amazon.com/opensearch-service/pricing/).

1. Keep `Compatibility mode` disabled.

   ![Create Domain](~/user-guide/images/Amazon_OpenSearch_DeploymentType.png)

1. Set `Network` to "Public Access".

   ![Create Domain](~/user-guide/images/Amazon_OpenSearch_Network.png)

1. Set `Access policy` to "Only use fine-grained access control".

   ![Create Domain](~/user-guide/images/Amazon_OpenSearch_AccessPolicy.png)

1. Go to the fine-grained access control settings, and select "Create master user".

   ![Create Domain](~/user-guide/images/Amazon_OpenSearch_MasterUser.png)

1. Specify a user name and a password.

   > [!TIP]
   > Store this information somewhere as you are going to need it later to configure the database in DataMiner Cube.

1. Under `Advanced cluster settings - optional`, set `Max clause count` to "2147483647".

   ![Create Domain](~/user-guide/images/Amazon_OpenSearch_MaxClauseCount.png)

New domains typically take 15 to 30 minutes to initialize, but it can take longer depending on the configuration. Once your domain is initialized, select it to open its configuration pane.

Note the domain endpoint under `General information`.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_DomainEndpoint.png)

## Connect your DMS to your Amazon OpenSearch Service domain

To configure the connection to an Amazon OpenSearch Service database, configure the settings as detailed in [Amazon OpenSearch Service](xref:Configuring_the_database_settings_in_Cube#amazon-opensearch-service).

> [!IMPORTANT]
> An Amazon OpenSearch Service database requires a separate Cassandra cluster or Amazon Keyspaces database.
