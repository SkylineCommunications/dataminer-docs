---
uid: UD_APIs
---

# User Defined APIs

> [!WARNING]
> The current feature is in preview and is not fully released yet. This feature should not be used in any staging or production environment.

The User Defined APIs feature allows users to define API calls that will be made available on the DataMiner agents that host the [UserDefinableApiEndpoint extension module](xref:UD_APIs_UserDefinableApiEndpoint). These APIs can be secured using API tokens that can be generated on the fly and linked to the API definitions.

## Cube

In System Center in Cube, you can manage your APIs and tokens in the User-Defined APIs tab.

> [!IMPORTANT]
> This tab will replace the obsolete API deployment tab in the future, so make sure to move your old APIs from API deployment to the new feature. How to create APIs from existing scripts is explained on the [using an existing script page](xref:UD_APIs_Using_existing_scripts).

To use the User Defined APIs Cube UI, you need DataMiner version 10.4.0/10.3.5. The Cube UI is not enabled by default. To enable it, set the soft-launch option *UserDefinableAPI* to true. See [soft-launch options](xref:SoftLaunchOptions).

### Permissions

APIs:

- To read or count definitions, and view the UI, the user needs the `User-defined APIs > Definitions > UI available` permission flag.
- To create or update definitions, the user needs the `User-defined APIs > Definitions > Add/Edit` permission flag. Also the `Automation > Execute` permission flag is required.
- To delete the definitions, the user needs the `User-defined APIs > Definitions > Delete` permission flag.

Tokens:

- To read or count tokens, and view the UI, the user needs the `User-defined APIs > Tokens > UI available` permission flag.
- To create or update tokens, the user needs the `User-defined APIs > Tokens > Add/Edit` permission flag.
- To delete the tokens, the user needs the `User-defined APIs > Tokens > Delete` permission flag.

## What are the different objects?

|Name          |Description|
|--------------|-----------|
|ApiToken      |Defines a secret string and metadata that can be used to access an API.|
|ApiDefinition |Defines the API. Including what tokens have access, the URL route and what action should be triggered.|

## Backup and restore

Since `ApiToken` and `ApiDefinition` objects are stored in the Elasticsearch database, these are NOT included in DataMine restore packages.
More information on how to backup and restore this data can be found [here](https://docs.dataminer.services/user-guide/Advanced_Functionality/Databases/Elasticsearch_database/Configuring_Elasticsearch_backups.html)

## Client Test UI

There is a UI available in the client test tool that makes it possible to easily see all the tokens and definitions. It can be found under `Advanced > Apps > User Definable APIs...`.

![Client Test UI Screenshot](~/user-guide/images/UDAPIS_ClientTestTool.jpg)

By selecting an object and clicking the 'View' or 'RawView' buttons, you can see all the properties of that object. It is possible to sort on values by clicking on the column headers.

In the Tokens tab, you can disable or enable an `ApiToken` by right-clicking on the ID field of an `ApiToken`. A context menu will open with a button to 'Disable' or 'Enable' the token.

It is also possible to trigger an API with the Client Test Tool. How to do this is described in the [triggering an API page](xref:UD_APIs_Triggering_an_API#client-test-tool).

## DataMiner UserDefinableApiEndpoint extension module

To use the User Definable API functionality, you need the `DataMiner UserdefinableApiEndpoint` extension module. This module should be installed together with a DataMiner upgrade package. Do not uninstall this!

To find how to change the settings and find the logging of this extension module, look at the [UserDefinableApiEndpoint page](xref:UD_APIs_UserDefinableApiEndpoint).

## Information events

Information events (on parameter 64650 with name "User-defined APIs") are generated for every create, update and delete action for an ApiToken or ApiDefinition.

The information event message includes the user doing the action, the object ID, in case of a token the object name and in case of a definition the route. For example:

```
ApiDefinition with route 'encoders/status' (c4cc7192-6ff5-4ca5-aae0-57c8615e25c8) was added by John Doe
ApiToken 'internal' (2faa728c-218d-4139-8aa1-8f033c60dd07) was updated by John Doe
```
