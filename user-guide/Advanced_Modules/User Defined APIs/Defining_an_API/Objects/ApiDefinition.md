---
uid: UD_APIs_Objects_ApiDefinition
---
# ApiDefinition

An `ApiDefinition` is an object that defines an API. Including what tokens have access, the URL route and what action should be triggered.

## Properties

These are the properties of the `ApiDefinition` object. The table also defines whether the property can be used for filtering using the `ApiDefinitionExposers`.

|Property         |Type             |Filterable          |Explanation|
|-----------------|-----------------|--------------------|-----------|
|ID               |ApiDefinitionId  |Yes                 |The ID of the `ApiDefinition`.|
|Name             |string           |Yes                 |Optional name that makes the definition recognizable.|
|Description      |string           |No                  |Optional description.|
|Route            |string           |Yes                 |The suffix of the URL where this API call will be available on. See the [Route](#route) section below.|
|SecuritySettings |SecuritySettings |Yes (AllowedTokens) |Contains the info on who can call this API. See the [SecuritySettings](#securitysettings) section below.|
|ActionType       |ActionType       |Yes                 |Type of action that will be triggered when calling the API. See the [Actions](#actions) section below.|
|ActionMeta       |IActionMeta      |No                  |Additional data for the action. See the [Actions](#actions) section below.|
|CreatedBy        |string           |Yes                 |Name of the user that created the definition.|
|CreatedAt        |DateTime         |Yes                 |UTC date and time of when the definition was created.|
|LastModifiedBy   |string           |Yes                 |Name of the last user that modified the definition.|
|LastModified     |DateTime         |Yes                 |UTC date and time of when the definition was last modified.|

### Route

The route describes the URL route where the API will be available. It is a suffix that comes after the base URL `{hostname}/api/custom/`.

- The route must **not start or end with a forward slash** (`/`).
- The route must be **unique** for each API definition. When it is saved, DataMiner will automatically check this to prevent conflicts.
- Routes are **case-insensitive**.

For example, if you want to create an API to retrieve the status of all encoders in your system, a logical route would be `encoders/status`. The full API call would then look like this:

```text
HTTP GET mydataminer.customer.local/api/custom/encoders/status
```

> [!TIP]
> We recommend that you keep routes simple and straightforward. For some great tips on this, refer to [restfulapi.net](https://restfulapi.net/resource-naming/).

### SecuritySettings

The `SecuritySettings` property can be used to describe what tokens can be used to access the API. It has the following property:

|Property         |Type                      |Explanation|
|-----------------|--------------------------|-----------|
|AllowedTokens    |HashSet&lt;ApiTokenId&gt; |Collection of token IDs that have access to the API.|

### Actions

Using the `ActionType` and `ActionMeta` properties, you can define what action should be executed when the API is triggered.

#### AutomationScript

This is the default value of the `ActionType`, it will execute an automation script through the `OnApiTrigger` entry point method. To define which script should be executed and how the input data should be handled, you will need to assign an `AutomationScriptActionMeta` instance to the `ActionMeta` property. This has the following fields:

|Property   |Type      |Explanation|
|-----------|----------|-----------|
|ScriptName |string    |Name of the script that should be executed. Cannot be null or empty.|
|InputType  |InputType |Determines how the input data from the request will be handled. The options are 'Parameters' or 'RawBody'. See [Defining a new API](xref:UD_APIs_Define_New_API) for more info.|

#### AutomationScriptNoEntryPoint

This `ActionType` is the same as the previous one, with the difference that there is no need to define a special entry point method in your automation script. The script will be executed through the default Run() method. This means that the `ApiTriggerInput` object is not available, and it is also not possible to return the `ApiTriggerOutput` to the API user. It will return 200 OK with an empty response body in case the script succeeded, and an `AutomationActionError` response error when the script fails. An example of how to use this action can be found [here](xref:UD_APIs_Using_existing_scripts#using-the-script-without-the-onapitrigger-entry-point).

This action will always convert the request body to a `Dictionary<string, string>`. It will verify that there is a value for each of the script parameters defined on the script, in the parsed dictionary. More info [here](xref:UD_APIs_Define_New_API#user-input-data).

You'll need to assign an `AutomationScriptNoEntryPointActionMeta` instance to the `ActionMeta` property. This has the following fields:

|Property   |Type      |Explanation|
|-----------|----------|-----------|
|ScriptName |string    |Name of the script that should be executed. Cannot be null or empty.|

## Requirements

- **Create & Update**
  - The `Name` property must not contain only white space characters. It must either contain visible characters or be empty/null.
  - The `Route` property must meet the requirements mentioned in the [Route](#route) section above.
  - The `ActionMeta` property must contain an instance of a meta class according to the configured action type. See the [Actions](#actions) section above.

## Errors

When something goes wrong during the CRUD actions, the `TraceData` can contain one or more `ApiDefinitionErrors`. Below is a list of all possible `ErrorReasons`. The `Id` property of the `ApiDefinitionError` object will always contain the ID of the API definition that could not be created or updated.

|Reason      |Description|
|------------|-----------|
|InvalidName |The given name only contained white space characters.|
|RouteInUse |The given route is already used by another `ApiDefinition`. *ConflictingDefinitionId* contains the ID of the definition that is already using the route. *Route* contains the invalid route.|
|InvalidRoute |The route did not meet the criteria. See the [Route](#route) section above. *Route* contains the invalid route.|
|InvalidActionMeta |The defined `ActionMeta` was empty, did not match the type or contained invalid configuration.|

## Security

There are permission flags that secure the CRUD actions for this type.

- To read or count definitions, the user requires the `PermissionFlags.UserDefinableApiDefinitionRead` permission flag.
- To create or update definitions, the user requires the `PermissionFlags.UserDefinableApiDefinitionCreateUpdate` permission flag.
- To delete definitions, the user requires the `PermissionFlags.UserDefinableApiDefinitionDelete` permission flag.

> [!IMPORTANT]
> To create or update `ApiDefinition` objects that define a `AutomationScript` or `AutomationScriptNoEntryPoint` action, you need the permissions to execute an automation script. (`PermissionFlags.AutomationExecuteScripts`)
