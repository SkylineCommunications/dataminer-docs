---
uid: UD_APIs_Define_New_API
---

# Defining a new API

> [!WARNING]
> This feature is in preview and is not fully released yet. For now, it should only be used on a staging platform. It should not be used in a production environment.

> [!NOTE]
> The User-Defined APIs feature is only available in DataMiner Cube if the soft-launch option *UserDefinableAPI* is set to true. See [soft-launch options](xref:SoftLaunchOptions).

To create a new API, follow these steps as detailed below:

1. [Create the API Automation script](#creating-the-api-automation-script)
1. [Create the API definition(s) and token(s)](#creating-an-api-and-tokens-in-automation)
1. [Configure the UserDefinableApiEndpoint extension module](#configuring-the-userdefinableapiendpoint-extension-module)

> [!NOTE]
> This is the recommended workflow when creating new APIs using new scripts. If you want to use an existing script for the API, see [Using existing scripts](xref:UD_APIs_Using_existing_scripts).

## Creating the API Automation script

To define a custom API, create an Automation script that contains the logic of your API.

Your Automation script needs the `OnApiTrigger` entry point method, which will be executed when the API is triggered. The entry point should look like this:

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
> The `Run` method is not required in the script, but the entry point method must reside in the `Script` class, just like in other DataMiner scripts.

### Input

The entry point method has two parameters.

- The `IEngine` object can be used to interact with the DataMiner Automation engine.

- The `ApiTriggerInput` is an object that contains information about the trigger. It has the following properties:

  | Property | Type | Explanation |
  |--|--|--|
  | RequestMethod | `RequestMethod` | The HTTP method of the request. See [RequestMethod](#requestmethod). |
  | Route | `string` | The suffix of the URL that this API call is triggered with. Having this available makes it possible to reuse the same script for different routes. See [Route](#route).|
  | RawBody | `string` | The full body of the HTTP request as a string. This can be deserialized and used in the script. See [User input data](#user-input-data). |
  | Parameters | `Dictionary<string, string>` | Contains the deserialized parameters if you select *Parse JSON of raw body to dictionary* when configuring the API. See [User input data](#user-input-data). |

#### RequestMethod

You can use the *RequestMethod* property to check the HTTP method of the trigger. It can contain the following values:

- *Unspecified* (must never occur)
- *Get*
- *Put*
- *Post*
- *Delete*

This makes it possible to define the 4 CRUD (create, read, update, delete) actions in one script. If one or more methods should not be used, you can return a status code 405 (see [ResponseCode](#responsecode)).

#### User input data

There are two ways to pass data to the API script if you make use of the *OnApiTrigger* entry point method. Which way is used depends on whether the checkbox to `Parse JSON of raw body to dictionary` is selected when the API is configured. See [Creating the API definition(s)](#creating-an-api-and-tokens-in-automation).

- If the checkbox is selected, the JSON body of the HTTP request will automatically be converted to a `Dictionary<string, string>` in the *Parameters* property of the `ApiTriggerInput` object. In the *RawBody* property, the raw string body will remain available.

  > [!NOTE]
  > Note that only JSON in the form of key-value pairs is accepted as parameters. For example:
  >
  > ```json
  > {
  >     "userName" : "JohnDoe",
  >     "limit" : "10"
  > }
  > ```

- If the checkbox is not selected, *Parameters* will contain an empty `Dictionary<string, string>`. In this, case, you will need to take care of the deserialization of the raw string body in the *RawBody* property in your Automation script.

#### Route

The route describes the URL route where the API will be available. It is a suffix that comes after the base URL `{hostname}/api/custom/`.

- The route must **not start or end with a forward slash** (`/`).
- The route must be **unique** for each API definition. When it is saved, DataMiner will automatically check this to prevent conflicts.
- Routes are **case-insensitive**.

For example, if you want to create an API to retrieve the status of all encoders in your system, a logical route would be `encoders/status`. The full API call would then look like this:

```
HTTP GET mydataminer.customer.local/api/custom/encoders/status
```

> [!TIP]
> We recommend that you keep routes simple and straightforward. For some great tips on this, refer to [restfulapi.net](https://restfulapi.net/resource-naming/).

### Output

The entry point method returns an instance of the `ApiTriggerOutput` class. This will be used to determine the response to the API caller.

The `ApiTriggerOutput` object has the following properties:

| Property | Type | Explanation |
|--|--|--|
| ResponseCode | int | The HTTP status code. See [ResponseCode](#responsecode). |
| ResponseBody | string | Contains the response body as a string. |

> [!NOTE]
> A valid instance always has to be returned.

#### ResponseCode

The status of the API trigger request is reflected in the *ResponseCode* property of the `ApiTriggerOutput`.

This is an integer, so any valid HTTP status code can be passed here.

You can also use the `StatusCode` enum, which contains suggestions, and cast that to an integer. The values of the enum are:

| Name | Value | Explanation |
|--|--|--|
| Ok | 200 | The request got executed successfully. |
| Created | 201 | The request succeeded, and a new resource was created as a result. |
| Accepted | 202 | The request was received, but not executed yet. Could be used for long-running async actions. |
| NoContent | 204 | There is no content to return for the request, but the request did succeed. |
| BadRequest | 400 | There was a client error, e.g. wrong parameters. |
| NotFound | 404 | The requested document was not found. |
| MethodNotAllowed | 405 | The HTTP method is not valid for this request. For example `DELETE` is used while `GET` was expected. |
| InternalServerError | 500 | Return this if something went wrong in your Automation script, e.g. you try to write to a file, but the file is in use by another application. |

> [!TIP]
>
> - A simple example is included in the [Automation script example](#creating-the-api-automation-script).
> - For more insight into which HTTP status codes to use in which circumstances, see [HTTP status codes](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status).

## Creating an API and token(s) in Automation

1. Open your API script in the Automation app in DataMiner Cube and click *Configure API...* at the bottom of the window.

   This will open a window where you can create the API.

   ![Creating an ApiDefinition](~/user-guide/images/UDPAIS_CreateAPI.png)<br>
   *Creating an API in DataMiner 10.3.6*
   
   > [!NOTE]
   > - The button will be shown in the UI when the system supports user-defined API (DataMiner 10.3.6.0 onwards) and when the system has an active Indexing Engine.
   > - The user must at least have the permission to read API definitions. It is recommended that the user should have all user-defined API permissions. This can be configured in *System Center* > *Users/Groups*  in Permissions *Modules* > *User-Defined APIs*.
   > - In DataMiner 10.3.5, the UI is only available if the soft-launch option *UserDefinableAPI* is set to true. See [soft-launch options](xref:SoftLaunchOptions).

1. Add a description.

1. In the *URL* box, specify the unique [route](#route).

1. If you want to parse the JSON body of the HTTP request to a dictionary, make sure *Parse JSON of raw body to dictionary* is selected. See [User input data](#user-input-data).

   > [!NOTE]
   > Leave *Method to be executed* set to the default selection. This option should only be changed for legacy scripts without the `OnApiTrigger` entry point. See [Using existing scripts](xref:UD_APIs_Using_existing_scripts).

1. Under *Tokens*, select the tokens that need access. You can also create new tokens using the *New token...* button.

   > [!NOTE]
   > It is not possible to delete a token that is in use by an API. You first need to unassign the token from all APIs using it before you can delete it.

   > [!CAUTION]
   > Once a token is created with a specified secret, **it is not possible to retrieve that secret again**. The value is stored securely in the database with a non-reversible hashing function. Make sure to save it somewhere secure or pass it in a secure way to the API user.

> [!NOTE]
> You can change your API configuration at any time by opening this window again and changing the settings.
> You can also navigate to the [API overview in DataMiner Cube](xref:UD_APIs_Viewing_in_Cube#apis-and-tokens-in-dataminer-cube).

## Configuring the UserDefinableApiEndpoint extension module

Make sure the *UserDefinableApiEndpoint* DxM has been configured to match your API needs.

For more information, refer to [UserDefinableApiEndpoint configuration](xref:UD_APIs_UserDefinableApiEndpoint#configuring-the-dxm).

If you have already configured the DxM, there is no need to repeat this step for each user-defined API you create.
