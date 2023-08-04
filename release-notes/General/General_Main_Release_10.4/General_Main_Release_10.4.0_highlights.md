---
uid: General_Main_Release_10.4.0_highlights
---

# General Main Release 10.4.0 – Highlights - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

#### User-Defined APIs [ID_34910] [ID_35134] [ID_35169] [ID_35417] [ID_35743] [ID_35810] [ID_35880] [ID_35885] [ID_36118] [ID_36250] [ID_36273] [ID_36366]

With the DataMiner User-Defined APIs, you can define custom API calls that will be made available on DataMiner Agents hosting the *UserDefinableApiEndpoint* DxM. This DxM is included in DataMiner upgrade packages from now on and will be automatically installed when you upgrade. The APIs can be secured using API tokens, which can be generated on the fly and linked to the API definitions.

The main objects used by this new DataMiner module are API tokens and API definitions. These are stored in the indexing database. Consequently, this feature is only available in DataMiner Systems that use an Elasticsearch database or equivalent indexing database.

> [!IMPORTANT]
> This feature replaces the *APIDeployment* soft-launch feature, which will eventually become unavailable. If you were using it, we recommend that you move your old APIs from API deployment to the new feature.

##### Configuring the UserDefinableApiEndpoint extension module

If you want the UserDefinableApiEndpoint DxM to use a different port than the default port 5002, you can adjust this by creating custom DxM settings.

To do so, go to the folder `%programfiles%\Skyline Communications\DataMiner UserDefinableApiEndpoint\`, and create a copy of the file *appsettings.json* with the name *appsettings.custom.json*. You can then create your custom settings in that new file. You can then adjust the port with the *Kestrel* > *Endpoints* > *Http* > *Url* setting.

This settings file also contains other customizable settings, such as the maximum number of open connections, the logging service used, and the timeout time of the message broker.

> [!TIP]
> For detailed information and examples, see [Configuring the DxM](xref:UD_APIs_UserDefinableApiEndpoint#configuring-the-dxm).

##### Defining an API

To define an API, you will first need to **create an Automation script** containing the logic of the API. This Automation script should contain the OnApiTrigger entry point method, which will be executed when the API is triggered. Alternatively, you can also **use an existing script** and trigger the API through the *Run* method. However, the latter approach has some disadvantages: you will not have access to the *ApiTriggerInput* object and *ApiTriggerOutput* object in the script, and it will therefore not be possible to check the route or the request method, or to output anything back to the API caller.

When the script is ready, you will then need to **create an API and tokens**. This can be done in the Automation module or in System Center. If you use DataMiner Automation, open the script and click *Configure API* at the bottom of the window. This will open a window where you can specify the following information:

- A **description** of the API (optional).
- The **URL route** where the API will be available. This is a suffix that comes after the base URL `{hostname}/api/custom/`. This route must be unique, and must not start or end with a forward slash. For example, if you want to create an API to retrieve the status of all encoders in your system, a logical route would be `encoders/status`.
- The **method** to be executed:

  - If you are using a script with the **OnApiTrigger** method, you can select whether you want to use the raw body of the JSON input or parse the JSON body of the HTTP request to a dictionary. Using the raw body provides the most flexibility, as it allows you to parse the input from any format you like. Using dictionary parsing makes it easier to handle basic user input, as you do not need to parse the JSON data yourself.
  - If you are using an existing script and want to trigger the API through the *Run* method, select *Run method (no output)*.

- The **tokens** that need access. You can also create new tokens here. At least one token has to be linked before the API will be usable.

> [!CAUTION]
> When a token is created, you will get the secret corresponding with that token. Afterwards, this secret cannot be retrieved again. The value is stored securely in the database with a non-reversible hashing function. Make sure to save it somewhere secure or pass it in a secure way to the API user.

> [!TIP]
> For detailed information and examples, see [Defining an API](xref:UD_APIs_Define_New_API).

##### Triggering an API

To trigger an API, you can send an HTTP or HTTPS request to the UserDefinableApiEndpoint DxM, using a URL in the format `http(s)://{hostname}/api/custom/{URL route}`. You can for instance use Postman for this. The following HTTP methods are supported: GET, PUT, POST, DELETE. You are free to choose which of these methods your API will support.

To authenticate yourself to the API, you will need to add a *Bearer* authorization header to your request containing the secret. In case the API needs input from the user using the HTTP body, you need to specify a *Content-Type* header. The *Content-Length* header is calculated and filled in automatically depending on how you send the request. The format of input in the body is defined in the API definition. If the API definition is set to accept parameters, these are expected to be passed as JSON in a key-value format.

The API will return an HTTP status code indicating the status of the request and a body. The response is encoded in UTF-8. In case some input from the user is missing, or the user sends a request with a wrong HTTP method, the API can return an HTTP status code indicating the error and a JSON body with more information (depending on how the script is designed). The endpoint itself can also return errors with corresponding status code to indicate something went wrong before the script was executed.

API triggers are handled in parallel. To protect DataMiner, there is a limit to the number of concurrent triggers. As soon as that limit is reached, new triggers are added to a queue, to be handled as soon as another trigger is finished. It is not possible to adjust this limit, as it is automatically set based on the number of logical processors in the system (with a minimal concurrency of 4). The exact limit is logged in the file `C:\Skyline DataMiner\Logging\SLUserDefinableApiManager.txt`. Apart from this limit implemented by DataMiner, IIS for Windows 10 also has a concurrency limit of 10. IIS for Windows Server has no limits.

> [!TIP]
> For detailed information and examples, see [Triggering a user-defined API](xref:UD_APIs_Triggering_an_API).

##### Managing APIs and tokens in System Center

In DataMiner Cube, System Center now features a new *User-Defined APIs* page, where you can see an overview of all configured APIs and tokens. Buttons are available on the page that allow you to create or delete APIs or tokens, open an API, or rename a token. Via the right-click menu, you can also enable or disable a token and copy the URL for an API.

> [!NOTE]
> It is not possible to delete a token that is in use by an API. You first need to unassign the token from all APIs using it before you can delete it. If you want to block access to a token rapidly, disable it instead.

##### User permissions

On the *Users/Groups* page in System Center, several new user permissions are available related to DataMiner User-Defined APIs in the *Modules > User-Defined APIs* section:

- *Tokens > UI available*: Permission to view API tokens.
- *Tokens > Add/Edit*: Permission to create and update API tokens.
- *Tokens > Delete*: Permission to delete API tokens.
- *APIs > UI available*: Permission to view API definitions.
- *APIs > Add/Edit*: Permission to create and update API definitions. Note that users will also need to be granted the *Automation > Execute* permission.
- *APIs > Delete*: Permission to delete API definitions.

##### Logging

The main log files for this feature are included in the folder `C:\ProgramData\Skyline Communications\DataMiner UserDefinableApiEndpoint\Logs\`.

In addition, the file *SLUserDefinableApiManager.txt* in the `C:\Skyline DataMiner\Logging\` folder contains logging related to the CRUD actions on API tokens and definitions and related to API triggers.

> [!NOTE]
> When an API token or definition is added, updated, or deleted, an information event is also generated in the Alarm Console.

##### SLNetClientTest tool

In the SLNetClientTest tool, you can trigger a user-defined API, get an overview of all API definitions and tokens, delete API definitions or tokens, and enable or disable tokens. To do so, after you have connected to the DMA, go to *Advanced* > *Apps* > *User-Defined APIs*.

If you trigger an API via the SLNetClientTest tool, this will bypass the endpoint DxM and go directly to the API manager in SLNet, which can be useful to efficiently test and verify API scripts without the need to send an HTTP request. This is especially handy when you are developing an API, as it allows you to quickly and easily trigger it and get additional information such as the response time along with the result.

> [!TIP]
> For detailed information, see [Triggering and managing user-defined APIs](xref:SLNetClientTest_triggering_api)

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
