---
uid: UD_APIs
---

# User-Defined APIs

> [!WARNING]
> This feature is in preview and is not fully released yet. For now, it should only be used on a staging platform. It should not be used in a production environment.

With the DataMiner User-Defined APIs feature, you can define API calls that will be made available on DataMiner Agents hosting the [UserDefinableApiEndpoint DxM](xref:UD_APIs_UserDefinableApiEndpoint). These APIs can be secured using API tokens, which can be generated on the fly and linked to the API definitions.

In short, these are the different objects used by this DataMiner module:

| Object | Description |
|--|--|
| API Token | Defines a secret string and metadata that can be used to access an API. |
| API definition | Defines the API. Including what tokens have access, the URL route and what action should be triggered. |

To use this functionality, you need the [DataMiner UserDefinableApiEndpoint](xref:UD_APIs_UserDefinableApiEndpoint) DxM. This module is automatically installed on each DMA on the DMS via the general DataMiner upgrade packages.

> [!NOTE]
> Since API tokens and API definition objects are **stored in the Elasticsearch database**, these are NOT included in DataMiner backup packages. For information on how to back up and restore this data, see [Configuring Elasticsearch backups](https://docs.dataminer.services/user-guide/Advanced_Functionality/Databases/Elasticsearch_database/Configuring_Elasticsearch_backups.html)

## Information events

An information event will be generated for every create, update and delete action for an API token or definition. These information events include the following details:

- **API token**: name, token ID and user who executed the action.
- **API definition**: URL route, definition ID and user who executed the action.

## Logging

There are two locations that contain logging about this feature.

1. The logging related to receiving the HTTP requests can be found in the UserDefinableApiEndpoint DxM logging folder. More info can be found on the [DataMiner UserDefinableApiEndpoint](xref:UD_APIs_UserDefinableApiEndpoint#consulting-logging-for-the-dxm) page.
1. The logging related to the CRUD actions for tokens and definitions is available in the file *SLUserDefinableApiManager.txt*, which can be found in the folder `C:\Skyline DataMiner\Logging`.
