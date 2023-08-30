---
uid: UD_APIs_Define_New_API
---

# Defining a new API

To create a new API, follow these steps as detailed below:

1. [Create the API Automation script](#creating-the-api-automation-script)
1. [Create the API definition(s) and token(s)](#creating-an-api-and-tokens-in-dataminer-automation)
1. [Configure the UserDefinableApiEndpoint extension module](#configuring-the-userdefinableapiendpoint-extension-module)

> [!NOTE]
> This is the recommended workflow when creating new APIs using new scripts. If you want to use an existing script for the API, see [Using existing scripts](xref:UD_APIs_Using_existing_scripts).

## Creating the API Automation script

To define an API, you will need an Automation script that contains the logic of the API. This Automation script needs the `OnApiTrigger` entry point method, which will be executed when the API is triggered. The entry point should look like this:

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
>
> - When developing the API script in DIS, make sure to update the *Skyline.DataMiner.Dev.Automation* NuGet package to its latest version so the types of the User-Defined APIs feature are available.
> - The `Run` method is not required in the script, but the entry point method must reside in the `Script` class, just like in any other DataMiner scripts.

### Input

The entry point method has two parameters.

- The `IEngine` object can be used to interact with the DataMiner Automation engine.

- The `ApiTriggerInput` is an object that contains information about the API trigger. It has the following properties:

  | Property | Type | Description |
  |--|--|--|
  | RequestMethod | `RequestMethod` | The HTTP method of the request. See [RequestMethod](#requestmethod). |
  | Route | `string` | The suffix of the URL that this API call is triggered with. Having this available makes it possible to reuse the same script for different routes. See [Route](#route).|
  | RawBody | `string` | The full body of the HTTP request as a string. This can be deserialized and used in the script. See [User input data](#user-input-data). |
  | Parameters | `Dictionary<string, string>` | Contains the deserialized parameters if you select *Dictionary (parsed from JSON)* when configuring the API. See [User input data](#user-input-data). |
  | Context | [ApiTriggerContext](#apitriggercontext) | Contains properties with info about the request. Available from DataMiner 10.3.9/10.4.0 onwards. <!-- RN 37015 --> |

#### ApiTriggerContext

  | Property | Type | Description |
  |--|--|--|
  | TokenId | `Guid` | Contains the ID of the [ApiToken](xref:UD_APIs_Objects_ApiToken) with which the API is triggered. Available from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36856 --><!-- RN 37015 -->. |

#### RequestMethod

You can use the *RequestMethod* property to check the HTTP method of the trigger. It can contain the following values:

- *Get*
- *Put*
- *Post*
- *Delete*

This makes it possible to define the four CRUD (create, read, update, delete) actions in one script. If one or more methods should not be used, you can return a status code 405 (see [ResponseCode](#responsecode)).

#### User input data

There are two ways to pass data to the API script if you make use of the *OnApiTrigger* entry point method. Which way is used depends on the selected option in the dropdown when you define the API in Cube. See [Creating the API definition(s)](#creating-an-api-and-tokens-in-dataminer-automation).

- If *Dictionary (parsed from JSON)* is selected, the JSON body of the HTTP request will automatically be converted to a `Dictionary<string, string>` in the `Parameters` property of the `ApiTriggerInput` object. In the `RawBody` property, the raw string body will remain available.

  > [!NOTE]
  > Note that only JSON in the form of key-value pairs is accepted as parameters. For example:
  >
  > ```json
  > {
  >     "userName" : "JohnDoe",
  >     "limit" : "10"
  > }
  > ```

- If the default option *Raw body* is selected, the `Parameters` property will contain an empty `Dictionary<string, string>`. In this case, you will need to take care of the deserialization of the raw body string which can be found in the `RawBody` property.

> [!TIP]
> To see how these two options are used in an API script, see [API script examples](xref:UD_APIs_API_script_examples).

#### Route

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

### Output

The entry point method returns an instance of the `ApiTriggerOutput` class. This will be used to determine the response to the API caller.

The `ApiTriggerOutput` object has the following properties:

| Property | Type | Description |
|--|--|--|
| ResponseCode | int | The HTTP status code. See [ResponseCode](#responsecode). |
| ResponseBody | string | Contains the response body as a string. |

> [!NOTE]
> A valid output instance always has to be returned.

#### ResponseCode

The status of the API trigger request is reflected in the `ResponseCode` property of the `ApiTriggerOutput`. This is an integer, so any valid HTTP status code can be passed here.

You can also use the `StatusCode` enum, which contains suggestions, and cast that to an integer. These are the values of the enum:

| Name | Value | Description |
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
> For more insight into which HTTP status codes to use in which circumstances, see [HTTP status codes](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status).

## Creating an API and tokens in DataMiner Automation

> [!NOTE]
>
> - Before you try to execute this procedure, make sure you have the user permissions available under [Modules > User-Defined APIs](xref:DataMiner_user_permissions#modules--user-defined-apis).
> - You can also create an API and tokens directly in code, for example if an API setup needs to be deployed in the install script of an application package. See [Creating APIs and tokens in code](xref:UD_APIs_Creating_in_code).

1. Open your API script in the Automation module in DataMiner Cube and click *Configure API* at the bottom of the window.

   This will open a window where you can create the API.

   ![Creating an API](~/user-guide/images/UDAPIS_CreateAPI.png)<br>
   *Creating an API in DataMiner 10.3.6*

   > [!NOTE]
   > You will only be able to see the button *Configure API*  in the UI if the following conditions are met:
   >
   > - You are using DataMiner 10.3.6 or higher.
   > - The DataMiner System has an active Indexing Engine (e.g. Elasticsearch).
   > - You have the permission to read API definitions.

1. Add a description (optional).

1. In the *URL* box, specify the unique [route](#route).

1. If you want to parse the JSON body of the HTTP request to a dictionary, make sure *Dictionary (parsed from JSON)* is selected. See [User input data](#user-input-data).

   > [!NOTE]
   > Leave *Method to be executed* set to the default selection. This option should only be changed for legacy scripts without the `OnApiTrigger` entry point. See [Using existing scripts](xref:UD_APIs_Using_existing_scripts).

1. Under *Tokens*, select the tokens that need access. You can also create new tokens using the *New token* button.

   > [!NOTE]
   > At least one token has to be linked before the API will be usable.

   > [!CAUTION]
   > Once a token is created with a specified secret, **it is not possible to retrieve that secret again**. The value is stored securely in the database with a non-reversible hashing function. Make sure to save it somewhere secure or pass it in a secure way to the API user.

> [!NOTE]
> You can change your API configuration at any time on the [User-Defined APIs page in System Center](xref:UD_APIs_Viewing_in_Cube#configuring-apis-and-tokens). Alternatively, you can also open this window in the Automation module again to change the settings.

## Configuring the UserDefinableApiEndpoint extension module

Make sure the *UserDefinableApiEndpoint* DxM has been configured to match your API needs. For more information, refer to [UserDefinableApiEndpoint configuration](xref:UD_APIs_UserDefinableApiEndpoint#configuring-the-dxm).

If you have already configured the DxM, there is no need to repeat this step for each user-defined API you create.
