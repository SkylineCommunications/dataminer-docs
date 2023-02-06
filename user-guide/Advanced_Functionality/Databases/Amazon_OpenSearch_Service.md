---
uid: Amazon_OpenSearch_Service
---

# Amazon OpenSearch Service

From DataMiner 10.3 [CU0]/10.3.3 onwards, it is possible to Amazon OpenSearch Service on AWS as an alternative to a on-prem hosted Elasticsearch/OpenSearch cluster. Note that although the service is named after OpenSearch, it offers both OpenSearch as well as Elasticsearch clusters.

## Compatibility

Supported versions:

- Elasticsearch version 6.8.
- OpenSearch version 1.X.
- OpenSearch version 2.X.

> [!NOTE]
> No Elasticsearch version 7.X setups on Amazon OpenSearch Service are currently supported.

## Create your Amazon OpenSearch Service domain

Go to [AWS Management Console](https://aws.amazon.com/console/) and log in.

Go to [Amazon OpenSearch Service](https://aws.amazon.com/opensearch-service/).

Create your domain

![Create Domain](~/user-guide/images/Amazon_OpenSearch_CreateDomain.png)

Configure your domain with the appropriate settings.

Make sure to select `Production` for `Deployment type`, a supported version and at least 3 nodes.

Choose an instance type. These are the hardware specifications of your cluster. You cannot change these later without creating a new domain. These determine the resources your cluster get and will dictate the performance of your cluster as well as the price.
You can find the specifications and pricing for each type [here](https://aws.amazon.com/opensearch-service/pricing/).

Keep `compatibility mode` disabled.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_DeploymentType.png)

For the network, choose `Public Access`.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_Network.png)

For access policy, choose `Only use fine-grained access control`.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_AccessPolicy.png)

In the fine-grained access control settings, choose `Create master user`.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_MasterUser.png)

Provide a user name and password. Make sure to store this information somewhere as you are going to need it later to configure the database in Cube.

Under `Advanced cluster settings - optional`, put the `Max clause count` to `2147483647`.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_MaxClauseCount.png)

New domains typically take 15–30 minutes to initialize, but can take longer depending on the configuration. After your domain initializes, select it to open its configuration pane.

Note the domain endpoint under General information.

![Create Domain](~/user-guide/images/Amazon_OpenSearch_DomainEndpoint.png)

## Connect your DMS to your Amazon OpenSearch Service domain

To configure the connection to an Amazon OpenSearch Service database, configure the settings as detailed under [Amazon OpenSearch Service](xref:Configuring_the_database_settings_in_Cube#amazon-opensearch-service)

> [!IMPORTANT]
> An Amazon OpenSearch Service database requires a separate Cassandra cluster or Amazon Keyspaces database.
