---
uid: General_Main_Release_10.4.0_highlights
---

# General Main Release 10.4.0 – Highlights

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

## Highlights

#### Storage as a Service (STaaS) [ID 34616] [ID 37141] [ID 37256] [ID 37257] [ID 37283]

<!-- MR 10.4.0 - FR 10.3.10 -->
<!-- RN 37141: MR 10.4.0 - FR 10.3.10 [CU1] -->

DataMiner now supports Storage as a Service (STaaS), a scalable and user-friendly cloud-native storage platform that provides a fully fletched alternative to on-premises databases.

For detailed information, see [Storage as a Service (STaaS)](xref:STaaS).

#### User-Defined APIs [ID 34910] [ID 35134] [ID 35169] [ID 35417] [ID 35743] [ID 35810] [ID 35880] [ID 35885] [ID 36118] [ID 36250] [ID 36273] [ID 36366]

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

To define an API, you will first need to **create an automation script** containing the logic of the API. This automation script should contain the OnApiTrigger entry point method, which will be executed when the API is triggered. Alternatively, you can also **use an existing script** and trigger the API through the *Run* method. However, the latter approach has some disadvantages: you will not have access to the *ApiTriggerInput* object and *ApiTriggerOutput* object in the script, and it will therefore not be possible to check the route or the request method, or to output anything back to the API caller.

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

#### Configuration of behavioral anomaly alarms [ID 36857] [ID 36976] [ID 37124] [ID 37246] [ID 37334] [37434]

<!-- MR 10.4.0 - FR 10.3.12 -->

The DataMiner software now supports a more extensive configuration of behavioral anomaly alarms.

From now on, you will be able to choose between the following types of anomaly monitoring:

- Smart anomaly monitoring (i.e. anomaly monitoring as it existed before)
- Customized anomaly monitoring

Customized anomaly monitoring will enable you to do the following:

- Set absolute or relative thresholds on the jump sizes of the change points of type *Level Shift* or *Outlier*.
- Enable or disable monitoring for each of the two possible directions of a behavioral change for level shifts, trend changes, variance changes and outliers. This will allow you, for example, to configure different alarm monitoring behaviors for downward level shifts and upward level shifts.

For more information on how to configure anomaly monitoring in DataMiner Cube, see [Alarm templates: Configuration of behavioral anomaly alarms [ID 37148] [ID 37171] [ID 37670]](xref:Cube_Feature_Release_10.3.12#alarm-templates-configuration-of-behavioral-anomaly-alarms-id-37148-id-37171-id-37670).

Summary of server-side changes:

- The behavioral anomaly configuration can be requested by sending a *GetAlarmTemplateMessage*. The *GetAlarmTemplateResponseMessage* will then return the behavioral anomaly configuration in a new *AnomalyConfiguration* field.

  If you enable behavioral anomaly monitoring, the *AnomalyConfiguration* field will contain information on which change point types are being monitored and how. If no behavioral anomaly monitoring has been configured, this field will remain empty.

  The legacy anomaly monitoring fields *LevelShiftMonitor*, *TrendMonitor*, *VarianceMonitor* and *FlatlineMonitor* in the *GetAlarmTemplateResponseMessage* have been marked as obsolete. If, in existing alarm templates, at least one of those legacy fields was enabled, the *AnomalyConfiguration* field will be filled with values consistent with the old settings.  

- The  anomaly configuration information for a parameter is no longer available in the *ParameterAlarmInfo* of each parameter. This means that the anomaly monitoring information can no longer be retrieved by means of a *GetElementProtocolMessage*.

  The legacy anomaly monitoring fields *LevelShiftMonitor*, *TrendMonitor*, *VarianceMonitor* and *FlatlineMonitor* in the *ParameterAlarmInfo* have been marked as obsolete and will no longer be taken into account by SLAnalytics.

- When upgrading to this DataMiner version, existing alarm template XML files will not be changed.

  When you update an existing alarm template or creating a new one, a new `<AnomalyConfig>` element will be added into the body of the `<Alarm>` element if, and only if, behavioral anomaly monitoring is enabled and an extended anomaly configuration has been set via the *AnomalyConfiguration* field of the *GetAlarmTemplateResponse* or the template parameters.

  The existing attributes of the `<Monitored>` element (i.e. *varianceMonitor*, *trendMonitor*, *levelShiftMonitor* and *flatLineMonitor*) have not been changed or removed to ensure compatibility of the new alarm template XML files with older DataMiner versions.

- When you set up a customized behavioral anomaly monitoring containing relative or absolute thresholds, this setup will be lost when you downgrade to an older server version that does not support this extended anomaly configuration (i.e. DataMiner version 10.3.11 or older). A fallback to the legacy "smart anomaly monitoring" will happen for all the change point types that had some kind of anomaly monitoring enabled.

- The internal SLAnalytics alarm template monitoring mechanism now also takes into account alarm template group information. As a result, SLAnalytics modules making use of this mechanism will get notified about changes to group entries and can react to these changes.

- A behavioral change point of type "flatline" shown in the trend graph will now always receive the correct alarm color when an anomaly alarm was created for it. In other words, if a critical behavioral anomaly alarm was created for the behavioral change of type "flatline", the change point bar shown in the trend graph will receive the red color.

#### DataMiner requirements: .NET 8.0 now required [ID 37969]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU0] - FR 10.4.3 [CU0] -->

To be able to upgrade to DataMiner 10.4.0, you will first need to install the [Microsoft ASP.NET 8.0 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.1-windows-hosting-bundle-installer).

If this requirement is not met, a new prerequisite check during the upgrade will notify you that you will first need to take care of this before you can install the upgrade.
