---
uid: UD_APIs
---

# User Defined APIs

> [!WARNING]
> The current feature is in preview and is not fully released yet. This feature should not be used in any staging or production environment.

The User Defined APIs feature allows users to define API calls that will be made available on the DataMiner agents that host the [UserDefinableApiEndpoint extension module](xref:UD_APIs_UserDefinableApiEndpoint). These APIs can be secured using API tokens that can be generated on the fly & linked to the API definitions.

## Cube

In System Center in Cube, you can manage your APIs and tokens in the User-Defined APIs tab.

> [!WARNING]
>- This tab will replace the obsolete API deployment tab in the future, so make sure to move your old APIs from API deployment to the new feature. How to create APIs from existing scripts is explained on the [using an existing script page](xref:UD_APIs_Using_existing_scripts).
>- The UI is not visible by default as the feature is not released yet.

## What are the different objects?

|Name          |Description|
|--------------|-----------|
|ApiToken      |Defines a secret string + metadata that can be used to access an API.|
|ApiDefinition |Defines the API. Including what tokens have access, the URL route and what action should be triggered.|

## Client Test UI

There is a UI available in the client test tool that makes it possible to easily see all the tokens and definitions. It can be found under `Advanced > Apps > User Definable APIs...`.

![Client Test UI Screenshot](~/user-guide/images/UDAPIS_ClientTestTool.jpg)

By selecting an object and clicking the 'View' or 'RawView' buttons, you can see all the properties of that object. It is possible to sort on values by clicking on the column headers.

In the Tokens tab, you can disable or enable an `ApiToken` by right-clicking on the ID field of an `ApiToken`. A context menu will open with a button to 'Disable' or 'Enable' the token.

It is also possible to trigger an API with the Client Test Tool. How to do this is described in the [triggering an API page](xref:UD_APIs_Triggering_an_API#client-test-tool).

## DataMiner UserDefinableApiEndpoint extension module

To use the User Definable API functionality, you need the `DataMiner UserdefinableApiEndpoint` extension module. This module should be installed together with a DataMiner upgrade package. Do not uninstall this!

To find how to change the settings and find the logging of this extension module, look at the [UserDefinableApiEndpoint page](xref:UD_APIs_UserDefinableApiEndpoint).
