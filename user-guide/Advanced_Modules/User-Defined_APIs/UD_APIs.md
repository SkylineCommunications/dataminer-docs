---
uid: UD_APIs
keywords: user-definable API
---

# User-Defined APIs

This feature is available from DataMiner 10.3.6/10.4.0 onwards on DataMiner Systems using [Storage as a Service](xref:STaaS) or a self-hosted storage setup with [indexing database](xref:Indexing_Database). In DataMiner 10.3.5, it is available in preview if the soft-launch option *UserDefinableAPI* is enabled. See [soft-launch options](xref:SoftLaunchOptions).

With the DataMiner User-Defined APIs feature, you can [define API calls](xref:UD_APIs_Define_New_API) that will be made available on DataMiner Agents hosting the [UserDefinableApiEndpoint DxM](xref:UD_APIs_UserDefinableApiEndpoint). These APIs can be secured using API tokens, which can be generated on the fly and linked to the API definitions.

In short, these are the different objects used by this DataMiner module:

| Object | Description |
|--|--|
| [API token](xref:UD_APIs_Objects_ApiToken) | Defines a secret string and metadata that can be used to access an API. |
| [API definition](xref:UD_APIs_Objects_ApiDefinition) | Defines the API. Including what tokens have access, the URL route and what action should be triggered. |

To use this functionality, you need the [DataMiner UserDefinableApiEndpoint](xref:UD_APIs_UserDefinableApiEndpoint) DxM. This module is automatically installed on each DMA in the DMS via the general DataMiner upgrade packages.

> [!TIP]
> Check out our [tutorials](xref:UD_APIs_Tutorials) to get started with creating user-defined APIs.

> [!NOTE]
> Since API tokens and API definition objects are **stored in the indexing database**, these are NOT included in DataMiner backup packages. For information on how to back up and restore this data in case you are using self-hosted DataMiner storage nodes, see [Configuring OpenSearch backups](xref:Configuring_OpenSearch_Backups) or [Configuring Elasticsearch backups](xref:Configuring_Elasticsearch_backups).

> [!IMPORTANT]
> This feature replaces the *APIDeployment* soft-launch feature. If you were previously using the *APIDeployment* soft-launch option, keep in mind that the *User-Defined APIs* tab in System Center will replace the obsolete *API deployment* tab from 10.4.0 onwards. Make sure to move your old APIs from API deployment to the new feature. For information on how to create APIs from existing scripts, see [Using existing scripts](xref:UD_APIs_Using_existing_scripts).

> [!TIP]
> See also: [User-Defined APIs benchmarks](xref:user-defined_API_benchmarks)
