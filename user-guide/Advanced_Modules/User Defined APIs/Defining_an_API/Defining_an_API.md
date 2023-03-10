---
uid: UD_APIs_Define_API
---

# Defining an API

> [!WARNING]
> The current feature is in preview and is not fully released yet. This feature should not be used in any staging or production environment.

This page describes the steps of creating a new API. This is the recommended workflow when creating new APIs using new scripts. If an existing script needs to be used for the API, checkout the [Using existing scripts page](xref:UD_APIs_Using_existing_scripts).

## 1. Creating the API automation script

To define a custom API, you need to create an automation script that contains the logic of your API. Your automation script needs the `OnApiTrigger` entrypoint method that will be executed when the API is triggered. The entrypoint should look like this:

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;
using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

public class Script
{
    [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
    public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
    {
        var method = requestData.RequestMethod;
        var route = requestData.Route;
        var body = requestData.RawBody;

        return new ApiTriggerOutput
        {
            ResponseBody = $"Received {method} request for route: '{route}' with body: '{body}'",
            ResponseCode = (int) StatusCode.Ok,
        };
    }
}
```

> [!NOTE]
> It is not required to have the 'Run' method in your script. But the entry point method should reside in the 'Script' class as all other DataMiner Automation scripts.

### Input

The entrypoint method has two parameters. The IEngine object can be used to interact with the DataMiner Automation Engine. The `ApiTriggerInput` is an object that contains information about the trigger, and has the following properties:

|Property       |Type                      |Explanation|
|---------------|--------------------------|-----------|
|RequestMethod  |RequestMethod             |Contains the HTTP method of the request. See [RequestMethod](#requestmethod).|
|Route          |string                    |The suffix of the URL where this API call is triggered on. See the [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition#route) page. Having this available makes it possible to reuse a script.|
|RawBody        |string                    |Contains the full body of the HTTP request as a string. This can be deserialized and used in the script.|
|Parameters     |`Dictionary<string, string>`|Contains the deserialized parameters if the `InputType` property of the `ActionMeta` in the `ApiDefinition` is set to 'Parameters', see [User Input Data](#user-input-data).|

#### RequestMethod

You can use the RequestMethod to check the HTTP method of the trigger. It can contain the following values:

- Unspecified (should never occur)
- Get
- Put
- Post
- Delete

Having this available makes it possible to define the 4 CRUD actions on a document in one script. If one or more methods should not be used, you can return a status code 405. (See [here](#responsecode))

#### User Input Data

There are two ways to pass data to the API script. It should be configured on the `ActionMeta` in the `ApiDefinition`.

##### Parameters

If you choose parameters, the JSON body of the HTTP request will automatically be converted to a `Dictionary<string, string>`. If you have chosen `RawBody`, this will be an empty `Dictionary<string, string>`, so this property will never be `null`. The raw string body will still be available in the `RawBody` property of the `ApiTriggerInput`. Note that only JSON in the form of key-value pairs are accepted as parameters, see the example below:

```json
{
    "userName" : "JohnDoe",
    "limit" : "10"
}
```

##### RawBody

The `RawBody` property of the `ApiTriggerInput` will be filled in regardless of the type of input data, it contains the raw body of the HTTP request. In case you select `RawBody` as input type, you are responsible for the deserialization in the automation script.

### Output

The entrypoint method should return an instance of the `ApiTriggerOutput` class. This will be used to determine the response to the API caller. Note that it is mandatory to return a valid instance. The `ApiTriggerOutput` has following properties:

|Property       |Type       |Explanation|
|---------------|-----------|-----------|
|ResponseCode   |int        |The HTTP status code, see [ResponseCode](#responsecode).|
|ResponseBody   |string     |Contains the response body as a string.|

#### ResponseCode

You can reflect the status of the API trigger request with the `ResponseCode` property on the `ApiTriggerOutput`. This is an integer, so you are free to pass any value that is a valid HTTP status code here. You can also use the `StatusCode` enum that contains suggestions and cast that to an integer, you can see an example of that [here](#1-creating-the-api-automation-script). The values of the enum are:

|Name               |Value|Explanation|
|-------------------|-----|-----------|
|Ok                 |200  |The request got executed successfully.|
|Created            |201  |The request succeeded, and a new resource was created as a result.|
|Accepted           |202  |The request is received, but not executed yet. Could be used for long running async actions.|
|NoContent          |204  |There is no content to return for the request, but the request did succeed.|
|BadRequest         |400  |Something went wrong user side e.g. wrong parameters.|
|NotFound           |404  |The requested document was not found.|
|MethodNotAllowed   |405  |The HTTP method is not valid for this request. For example `DELETE` is used while `GET` was expected.|
|InternalServerError|500  |Return this if something went wrong in your automation script, e.g. you try to write to a file, but the file is in use by another application.|

If you want to have deeper insights on what HTTP status code to use in what circumstance, check the following site: [HTTP status codes](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status).

## 2. Creating the ApiToken(s)

TODO: UI oriented guide to create tokens.

## 3. Creating the ApiDefinition(s)

TODO: UI oriented guide to create definitions.

## 4. Configuring UserDefinableApiEndpoint extension module

It is important to configure the UserDefinableApiEndpoint extension module to match your API needs, how to do this is explained [here](xref:UD_APIs_UserDefinableApiEndpoint#configuration).
