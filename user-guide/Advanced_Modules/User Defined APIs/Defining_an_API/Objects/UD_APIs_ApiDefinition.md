---
uid: UD_APIs_Objects_ApiDefinition
---
# ApiDefinition object

An `ApiDefinition` is an object that defines an API, including which tokens have access, the URL route, and which action should be triggered.

## Properties

The table below lists the properties of the `ApiDefinition` object. For each property, it also indicates whether the property can be used for filtering using the `ApiDefinitionExposers`.

|Property         |Type             |Filterable          |Explanation|
|-----------------|-----------------|--------------------|-----------|
|ID               |ApiDefinitionId  |Yes                 |The ID of the `ApiDefinition`.|
|Name             |string           |Yes                 |Optional name that makes the definition recognizable.|
|Description      |string           |No                  |Optional description.|
|Route            |string           |Yes                 |The suffix of the URL where this API call will be available. See [Route](#route).|
|SecuritySettings |SecuritySettings |Yes (AllowedTokens) |Info on who can call this API. See [SecuritySettings](#securitysettings).|
|ActionType       |ActionType       |Yes                 |The type of action that will be triggered when the API is called. See [Actions](#actions).|
|ActionMeta       |IActionMeta      |No                  |Additional data for the action. See [Actions](#actions).|
|CreatedBy        |string           |Yes                 |The name of the user who created the definition.|
|CreatedAt        |DateTime         |Yes                 |The UTC date and time when the definition was created.|
|LastModifiedBy   |string           |Yes                 |The name of the last user who modified the definition.|
|LastModified     |DateTime         |Yes                 |The UTC date and time when the definition was last modified.|

### Route

The route describes the URL route where the API will be available. It is a suffix that comes after the base URL `{hostname}/api/custom/`.

- The route must **not start or end with a forward slash** (`/`).

- The route must be **unique** for each API definition. When it is saved, DataMiner will automatically check this to prevent conflicts.

- Routes are **case-insensitive**.

For example, if you want to create an API to retrieve the status of all encoders in your system, a logical route would be `encoders/status`. The full API call would then look like this:

```txt
HTTP GET mydataminer.customer.local/api/custom/encoders/status
```

> [!TIP]
> We recommend that you keep routes simple and straightforward. For some great tips on this, refer to [restfulapi.net](https://restfulapi.net/resource-naming/).

### SecuritySettings

The `SecuritySettings` property can be used to describe which tokens can be used to access the API. It has the following property:

|Property         |Type                      |Description|
|-----------------|--------------------------|-----------|
|AllowedTokens    |HashSet&lt;ApiTokenId&gt; |Collection of token IDs that have access to the API.|

### Actions

Using the `ActionType` and `ActionMeta` properties, you can define which action should be executed when the API is triggered.

#### AutomationScript

This is the default value of the `ActionType` property. It will execute an Automation script through the `OnApiTrigger` entry point method.

To define which script should be executed and how the input data should be handled, you will need to assign an `AutomationScriptActionMeta` instance to the `ActionMeta` property. This has the following fields:

|Property   |Type      |Description|
|-----------|----------|-----------|
|ScriptName |string    |The name of the script that should be executed. Cannot be null or empty.|
|InputType  |InputType |Determines how the input data from the request will be handled. The options are *Parameters* or *RawBody*. See [Defining a new API](xref:UD_APIs_Define_New_API#input).|

#### AutomationScriptNoEntryPoint

This `ActionType` is similar to the *AutomationScript* action type, except that there is no need to define a special entry point method in the Automation script. The script will be executed through the default Run() method. This means that the `ApiTriggerInput` object is not available, and it is also not possible to return the `ApiTriggerOutput` to the API user. The action will return 200 OK with an empty response body in case the script succeeded, and an `AutomationActionError` response error when the script fails.

This action will always convert the request body to a `Dictionary<string, string>`. It will verify that there is a value in the parsed dictionary for each of the script parameters defined in the script. For more information, see [User input data](xref:UD_APIs_Define_New_API#user-input-data).

You will need to assign an `AutomationScriptNoEntryPointActionMeta` instance to the `ActionMeta` property. This has the following fields:

|Property   |Type      |Description|
|-----------|----------|-----------|
|ScriptName |string    |Name of the script that should be executed. Cannot be null or empty.|

> [!TIP]
> For an example of how to use this action, see [Using the script without the OnApiTrigger entry point](xref:UD_APIs_Using_existing_scripts#using-the-script-without-the-onapitrigger-entry-point).

## Requirements

- **Create & Update**
  - The `Name` property must not contain only white space characters. It must either contain visible characters or be empty/null.
  - The `Route` property must meet the requirements mentioned under [Route](#route).
  - The `ActionMeta` property must contain an instance of a meta class according to the configured action type. See [Actions](#actions).

## Errors

When something goes wrong during the CRUD actions, the `TraceData` can contain one or more `ApiDefinitionErrors`. Below is a list of all possible `ErrorReasons`. The `Id` property of the `ApiDefinitionError` object will always contain the ID of the API definition that could not be created or updated.

|Reason      |Description|
|------------|-----------|
|InvalidName |The specified name only contained white space characters.|
|RouteInUse |The specified route is already used by another `ApiDefinition`. *ConflictingDefinitionId* contains the ID of the definition that is already using the route. *Route* contains the invalid route.|
|InvalidRoute |The route did not meet the criteria. See [Route](#route). *Route* contains the invalid route.|
|InvalidActionMeta |The defined `ActionMeta` was empty, did not match the type, or contained an invalid configuration.|

## Security

To create, read, update, or delete API definitions, specific user permissions are needed:

- To read or count definitions, you need the user permission [Modules > User-Defined APIs > APIs > UI available](xref:DataMiner_user_permissions#modules--user-defined-apis--apis--ui-available).
- To create or update definitions, you need the user permissions [Modules > User-Defined APIs > APIs > Add/Edit](xref:DataMiner_user_permissions#modules--user-defined-apis--apis--addedit) and [Modules > Automation > execute](xref:DataMiner_user_permissions#modules--automation--execute).
- To delete definitions, you need the user permission [Modules > User-Defined APIs > APIs > Delete](xref:DataMiner_user_permissions#modules--user-defined-apis--apis--delete).
