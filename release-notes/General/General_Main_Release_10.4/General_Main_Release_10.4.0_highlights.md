---
uid: General_Main_Release_10.4.0_highlights
---

# General Main Release 10.4.0 – Highlights - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

#### Interactive Automation scripts: New button style 'CallToAction' [ID_34904]

<!-- MR 10.4.0 - FR 10.3.1 -->

In an interactive Automation script launched from a dashboard or a low-code app, you can now apply the *CallToAction* style to a button.

When you apply this style to a button

- the background color of the button will be the color of the app,
- the color of the text on the button will be white, and
- the button will have a shadow.

To set the style of a button in an interactive Automation script, set the *Style* property of the button's *UIBlockDefinition* to the name of the style. All supported styles are available via `Style.Button`.

Alternatively, you can also pass a button style directly to the `AppendButton` method on an `UIBuilder` object.

> [!NOTE]
>
> - Up to now, `StaticText` blocks already supported a number of styles. Those styles are now also available via `Style.Text`: *Title1*, *Title2* and *Title3*.
> - The *CallToAction* style will only be applied in interactive Automation scripts launched from a web app. It will not be applied in interactive Automation scripts launched from Cube.

#### User-Defined APIs [ID_36273]

With the DataMiner User-Defined APIs, you can define API calls that will be made available on DataMiner Agents hosting the *UserDefinableApiEndpoint* DxM, which is included in DataMiner upgrade packages from now on. These APIs can be secured using API tokens, which can be generated on the fly and linked to the API definitions.

The main objects used by this new DataMiner module are API tokens and API definitions. These are stored in the Elasticsearch database.

> [!IMPORTANT]
> This feature replaces the *APIDeployment* soft-launch feature, which will eventually become unavailable. If you were using it, we recommend that you move your old APIs from API deployment to the new feature. To make this migration easier, we support creating APIs based on existing scripts.

##### Configuring the UserDefinableApiEndpoint extension module

The first time you use DataMiner User-Defined APIs, make sure you adjust the UserDefinableApiEndpoint DxM settings to match your API needs.

To do so, go to the folder `%programfiles%\Skyline Communications\DataMiner UserDefinableApiEndpoint\`, and create a copy of the file *appsettings.json* with the name *appsettings.custom.json*. You can then create your custom settings in this custom file.

These are the main settings you can adjust:

- *Kestrel* > *Endpoints* > *Http* > *Url*: This determines the endpoint where the UserDefinableApiEndpoint DxM will be run. You can change the port here. Note that IIS also has a rewrite rule (Reroute User Definable APIs) that forwards API requests to the port used by UserDefinableApiEndpoint (5002). When you specify a custom port, you will also have to update that rule.
- *Kestrel* > *Limits* > *MaxConcurrentConnections*: This setting defines the maximum number of open connections. By default, the DxM will allow 100 concurrent connections, but you can customize this number here.
- *Serilog*: Serilog is the logging service used for UserDefinableApiEndpoint. Here you can change where the log files should be located, how big they can get, and how many files should be kept. You can also change the default log levels.
- *UserDefinableAPIs* > *MessageBrokerTimeOutSeconds*: This setting indicates how long the message broker (sending the NATS trigger to SLNet) will wait for a response before it times out. By default, this is set to 90 seconds (i.e. 1.5 minutes). If you increase the timeout value, you will also need to increase the timeout in IIS.

> [!TIP]
> For detailed information and examples, see [Configuring the DxM](xref:UD_APIs_UserDefinableApiEndpoint#configuring-the-dxm).

##### Defining an API

To define an API, you will first need to **create an Automation script** containing the logic of the API. This Automation script should contain the OnApiTrigger entry point method, which will be executed when the API is triggered. Alternatively, you can also use an existing script and trigger the API through the *Run* method. However, the latter approach has some disadvantages: you will not have access to the *ApiTriggerInput* object and *ApiTriggerOutput* object in the script, and it will therefore not be possible to check the route, request the method of the API trigger, or output anything back to the API caller.

When the script is ready, you will then need to **create an API and tokens**. This can be done in the Automation module, or directly in code. If you use DataMiner Automation, open the script and click *Configure API* at the bottom of the window. This will open a window where you can specify the following information:

- A **description** of the API
- The **URL route** where the API will be available. This is a suffix that comes after the base URL `{hostname}/api/custom/`. This route must be unique, and must not start or end with a forward slash. For example, if you want to create an API to retrieve the status of all encoders in your system, a logical route would be `encoders/status`.
- Select the **method** to be executed:

  - If you are using a script with **OnApiTrigger** method, you can select whether you want to use the raw body of the JSON input or parse the JSON body of the HTTP request to a dictionary. Using the raw body provides the most flexibility, as it allows you to parse the input from any format you like. Using dictionary parsing makes it easier to handle basic user input, as you do not need to parse the JSON data yourself.
  - If you are using an existing script and want to trigger the API through the *Run* method, select *Run method (no output)*.

- Select the tokens that need access. You can also create new tokens here. At least one token has to be linked before the API will be usable.

> [!CAUTION]
> When a token is created, you will get the secret corresponding with that token. Afterwards, this secret cannot be retrieved again. The value is stored securely in the database with a non-reversible hashing function. Make sure to save it somewhere secure or pass it in a secure way to the API user.

> [!TIP]
> For detailed information and examples, see [Defining an API](xref:UD_APIs_Define_New_API).

##### Triggering an API

To trigger an API, you can send an HTTP or HTTPS request to the UserDefinableApiEndpoint DxM, using a URL in the format `http(s)://{hostname}/api/custom/{URL route}`. You can for instance use Postman for this. The following HTTP methods are supported: GET, PUT, POST, DELETE. You are free to choose which of these methods your API will support.

To authenticate yourself to the API, you will need to add a Bearer authorization header to your request containing the secret.

##### Managing APIs and tokens in System Center

In DataMiner Cube, System Center now features a new *User-Defined APIs* page, where you can see an overview of all configured APIs and tokens. Buttons are available on the page that allow you to create or delete APIs or tokens, open an API, or rename a token. Via the right-click menu, you can also enable or disable a token and copy the URL for an API.
