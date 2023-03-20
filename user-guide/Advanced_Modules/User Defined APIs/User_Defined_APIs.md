---
uid: UD_APIs
---

# User-defined APIs

> [!WARNING]
> The current feature is in preview and is not fully released yet. This feature should not be used in any staging or production environment.

The User-defined APIs feature allows users to define API calls that will be made available on the DataMiner agents that host the [UserDefinableApiEndpoint extension module](xref:UD_APIs_UserDefinableApiEndpoint). These APIs can be secured using API tokens that can be generated on the fly and linked to the API definitions.

## Cube

In System Center in Cube, you can view your APIs and tokens in the User-Defined APIs tab.

> [!IMPORTANT]
> This tab will replace the obsolete API deployment tab in the future, so make sure to move your old APIs from API deployment to the new feature. How to create APIs from existing scripts is explained on the [using an existing script page](xref:UD_APIs_Using_existing_scripts).

To use the User-defined APIs Cube UI, you need DataMiner version 10.4.0/10.3.5. The Cube UI is not enabled by default. To enable it, set the soft-launch option *UserDefinableAPI* to true. See [soft-launch options](xref:SoftLaunchOptions).

## What are the different objects?

|UI Name         |Description|
|----------------|-----------|
|Token           |Defines a secret string and metadata that can be used to access an API.|
|API (definition)|Defines the API. Including what tokens have access, the URL route and what action should be triggered.|

## Backup and restore

Since Tokens and API (definition) objects are stored in the Elasticsearch database, these are NOT included in DataMiner restore packages.
More information on how to backup and restore this data can be found [here](https://docs.dataminer.services/user-guide/Advanced_Functionality/Databases/Elasticsearch_database/Configuring_Elasticsearch_backups.html)

## DataMiner UserDefinableApiEndpoint extension module

To use the User-defined API functionality, you need the `DataMiner UserdefinableApiEndpoint` extension module. This module should be installed together with a DataMiner upgrade package. Do not uninstall this!

To find how to change the settings and find the logging of this extension module, look at the [UserDefinableApiEndpoint page](xref:UD_APIs_UserDefinableApiEndpoint).

## Information events

Information events (with name "User-defined APIs") are generated for every create, update and delete action for a Token or API (definition).
