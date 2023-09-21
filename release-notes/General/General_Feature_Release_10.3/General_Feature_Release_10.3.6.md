---
uid: General_Feature_Release_10.3.6
---

# General Feature Release 10.3.6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.6](xref:Cube_Feature_Release_10.3.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.6](xref:Web_apps_Feature_Release_10.3.6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

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

## Changes

### Enhancements

#### DataMiner Object Models: Enhanced performance when reading DOM objects and ModuleSettings [ID_35934]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Because of a number of enhancements, overall performance has increased when reading DOM objects and ModuleSettings.

#### SLLogCollector now also collects SyncInfo files [ID_35995]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

SLLogCollector packages will now also include all files found in `C:\Skyline DataMiner\Files\SyncInfo` relevant for troubleshooting.

#### Service & Resource Management: An error will now be thrown when an SRM event has been stuck for more than 15 minutes [ID_36013]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When an SRM event has been stuck for more than 15 minutes, the following run-time error will now appear in the Alarm Console:

```txt
Thread problem in SLNet: SRM event thread for booking with id <booking id>
```

This error will also be added to the *SLWatchDog2.txt* log file.

> [!NOTE]
>
> - This run-time error will appear when a custom booking event script that was configured to run synchronously has been running for more than 15 minutes. We highly recommend configuring custom booking events to run asynchronously. For more information, see [Service Orchestration custom events configuration](xref:Service_Orchestration_custom_events).
> - Half-open run-time errors (which are thrown after an SRM event has been stuck for more than 7.5 minutes) will also be added to the *SLWatchDog2.txt* log file.

#### DataMiner upgrades and downgrades can now be performed over gRPC [ID_36023]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

DataMiner upgrades and downgrades can now be performed over gRPC.

To make gRPC the default communication method, do the following on every DataMiner Agent in the cluster:

- To make gRPC the default communication method for **client-server communication**, modify [ConnectionSettings.txt](xref:ConnectionSettings_txt).

- To make gRPC the default communication method for **server-server communication**, do one of the following:

  - Disable *.NET Remoting* in [MaintenanceSettings.xml](xref:MaintenanceSettings_xml) by adding `<EnableDotNetRemoting>false</EnableDotNetRemoting>` to the `<SLNet>` section.
  
  OR
  
  - Add explicit `<Redirect>` tags in [DMS.xml](xref:DMS_xml).

> [!NOTE]
>
> - *.NET Remoting* remains the default communication method for both client-server and server-server communication.
> - Certain connectors and Automation scripts still rely on having the *.NET Remoting* port 8004 open.

#### SLAnalytics: Trend data predictions displayed in trend graphs will be more accurate [ID_36038]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Because of a number of enhancements with regard to the detection of periodic behavior in trend data, the trend data predictions displayed in trend graphs will be more accurate.

#### SLAnalytics - Trend prediction: Enhanced trend prediction verification [ID_36102]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

The verification of trend predictions has been enhanced.

#### SLAnalytics - Behavioral anomaly detection: Enhanced detection of behavioral changes after a gap in the trend data [ID_36186]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

A number of enhancements have been made with regard to the automatic detection of behavioral changes in trend data of trended parameters.

Up to now, in some cases, level shifts and trend changes would remain unlabeled when they occurred immediately after a gap in the trend data.

#### ConnectionSettings.txt: type=RemotingConnection now obsolete [ID_36196]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In the *ConnectionSettings.txt* file, the **type=** setting defines the default connection method to be used by DataMiner client applications.

One of its values, "RemotingConnection", is now obsolete. If you continue to use this value, we are planning to soon have DataMiner automatically switch to *GRPCConnection* when you upgrade. If you do not want to use *GRPCConnection*, use *LegacyRemotingConnection* to avoid getting automatically switched. However, note that we strongly recommend using *GRPCConnection*.

#### API Gateway module now targets Microsoft .NET 6.0 [ID_36238]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

As Microsoft .NET 5 is being phased out, the *API Gateway* module will now use Microsoft .NET 6.0 instead.

#### Service & Resource Management: Enhanced performance when stopping an ongoing booking [ID_36255]

<!-- MR 10.4.0 - FR 10.3.6 -->

Because of a number of enhancements, overall performance has increased when stopping an ongoing booking.

#### Element replication is now able to use gRPC [ID_36262]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Element replication will now automatically detect the connection settings of the target DMA and will use gRPC when the connection type is set to "GPRCConnection".

#### Failover on RTE now also supports DMAs that communicate using gRPC [ID_36267]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In the *MaintenanceSettings.xml* file, SLWatchDog can be configured to trigger a Failover switch when it detects a run-time error in a critical process on the active Agent of a Failover pair. From now on, this *Failover on RTE* feature will also support Agents that communicate using gRPC.

#### SLNetClientTest tool now supports gRPC when it needs to establish additional connections [ID_36279]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

The *SLNetClientTest* tool now supports gRPC when it needs to establish additional connections to remote DataMiner Agents.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

### Fixes

#### DataMiner Agent was not able to connect to the Cassandra database due to a problem with the TLS certificate [ID_35895]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When a DataMiner Agent was restarted after its database had been configured to use TLS, in some cases, it would not be able to connect to its Cassandra database due to a problem with the TLS certificate validation.

#### Updating a Resource or ResourcePool would incorrectly cause the 'CreatedAt' and 'CreatedBy' fields to be overwritten [ID_35913]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When a Resource or ResourcePool was updated, the *CreatedAt* and *CreatedBy* fields would incorrectly be overwritten.

#### NATS-related error: 'Failed to copy credentials from [IP address] - corrupt zip file' [ID_35935]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.6 -->

In some rare cases, the following NATS-related error would be thrown:

```txt
Failed to copy credentials from [IP address] - corrupt zip file
```

#### Improved error handling when elements go into an error state [ID_35944] [ID_36198]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When an element goes into an error state after an attempt to activate it failed, from now on, no more calls to SLProtocol, SLElement or SLSpectrum will be made for that element.

Also, when an element that generates DVE child elements or virtual functions goes into an error state, from now on, the generated DVE child elements or virtual functions will also go into an error state. However, in order to avoid too many alarms to be generated, only one alarm (for the main element) will be generated.

The following issues have also been fixed:

- When a DVE parent element in an error state on DataMiner startup was activated, its DVE child elements or virtual functions would not be properly loaded.

- When a DVE parent element was started, the method that has to make sure that ElementInfo and ElementData are in sync would incorrectly not check all child elements.

#### Problem after offloading element data to Elasticsearch [ID_35962]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When element data had been offloaded to Elasticsearch via a logger table, after restarting the element, the Elasticsearch table could not be populated.

#### Creating or updating a function resource while its parent element was in an error state would incorrectly be allowed [ID_35963]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you created or updated a function resource while its parent element was in an error state, up to now, the state of that parent element would not be checked correctly. As a result, adding or updating the function resource would incorrectly be allowed.

From now on, when you create or update a function resource while its parent element is in an error state, an error will be thrown.

#### Business Intelligence: Problem when a replicated SLA was stopped or deleted [ID_35973]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, an error could occur when a replicated SLA was stopped or deleted.

#### Cassandra: Cleared alarms would incorrectly be added to the activealarms table and never removed [ID_36002]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

Cleared alarms would incorrectly be added to the activealarms table and never removed.

#### Spectrum analysis: Measurement points would not be set correctly [ID_36005]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, measurement points would not be set correctly when a trace was being displayed.

#### Virtual functions linked to a parameter with a hysteresis timer could be assigned an incorrect alarm severity [ID_36024]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When a virtual function was linked to a parameter that had a hysteresis timer running, in some cases, that virtual function would be assigned an incorrect alarm severity.

#### NT Notify type NT_GET_BITRATE_DELTA would return incorrect values [ID_36025]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, NT Notify type NT_GET_BITRATE_DELTA (269) would return incorrect bitrate counter values when an SNMPv3 element was going into or coming out of a timeout state.

#### SLReset.exe would not clean an Elasticsearch database when no <DB> element was specified in DB.xml [ID_36040]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When, in the *DB.xml* file, no `<DB>` element was specified for an Elasticsearch database, the factory reset tool *SLReset.exe* would not clean that database when the `cleanclustereddatabases` option had been used.

From now on, when no `<DB>` element is specified for a Elasticsearch database, *SLReset.exe* will use the default database name "dms".

#### Memory leak in SLSPIHost [ID_36041]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In some cases, the SLSpiHost process could leak memory.

#### SLAnalytics - Behavioral anomaly detection: No flatline stop events would be generated when an element was deleted [ID_36050]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When an element was deleted, no flatline stop events would be generated for parameters of that element.

#### Business Intelligence: Alarms that had to be replayed would incorrectly have their weight recalculated [ID_36051]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When an SLA has to process alarms generated due to history sets or alarms generated with hysteresis enabled, those alarms are replayed to ensure that the outages contain the correct information.

Up to now, when an alarm was fetched from a logger table in order to be replayed, the system would incorrectly recalculate its weight instead of taking into account its previously calculated weight stored in the logger table.

> [!NOTE]
> When you change an SLA's violation settings, offline windows, etc., we recommend resetting that SLA as the alarm weights of previously processed alarms will not be recalculated retroactively.

#### DataMiner Object Models: Problem when creating a DomInstance with an empty status [ID_36063]

<!-- MR 10.4.0 - FR 10.3.6 -->

When a DomInstance was created with an empty status, in some cases, a `MultipleSectionsNotAllowedForSectionDefinition` error could be returned, even when the configuration was correct.

#### New SLScripting processes would incorrectly be created when using 'SeparateProcesses' [ID_36133]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When the *DataMiner.xml* file contained `<ProcessOptions protocolProcesses="5" scriptingProcesses="protocol">` either in combination with `<SeparateProcesses>` or with `<RunInSeparateInstance>true</RunInSeparateInstance>` specified in the *protocol.xml* file, every time an element of a separate protocol restarted, a new SLScripting process would be created and the previous SLScripting process would not be stopped.

#### Errors would incorrectly state that OpenSearch 2.4 and 2.5 were not supported [ID_36137]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Although DataMiner supports all OpenSearch 1.x and 2.x versions, in some cases, errors stating that OpenSearch 2.4 and 2.5 were not officially supported would incorrectly be added to the *SLDBConnection.txt* and *SLSearch.txt* log files.

#### Problem with BPA test 'Cassandra DB Size' [ID_36138]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Up to now, the BPA test *Cassandra DB size* would spawn a number of cmd processes meant to be executed by the Cassandra nodetool utility without checking whether nodetool was running. When nodetool was not running, these cmd processes would not get cleaned up.

#### DataMiner Backup: Low-code apps would incorrectly not be restored [ID_36139]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When you restored a DataMiner backup that included low-code apps, those apps would incorrectly not be restored.

#### Problem when multiple clients had subscribed to a cell of a partial table [ID_36148]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When multiple clients had subscribed to a cell of a partial table, in some cases, deleting the row or renaming the row via a display key would not trigger a deletion of the cell in the subscription.

#### Problem when retrieving alarm events from Cassandra Cluster after an element restart [ID_36177]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 [CU0] -->

When an element that had more than 10,000 alarm events stored on a Cassandra cluster was restarted, those alarm events would not all get retrieved from the database. As a result, SLElement would generate additional alarm events, causing the alarm trees to become incorrect.

#### External authentication via SAML: Removal of whitespace characters from signatures would cause validation to fail [ID_36181]

<!-- MR 10.4.0 - FR 10.3.6 -->

In some cases, whitespace characters would incorrectly be removed from signatures, causing validation to fail.

#### Inaccessible logger table data in Elasticsearch because of incorrect casing [ID_36343]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 [CU0] -->

Since DataMiner versions 10.3.0/10.3.3, if a logger table that had `Indexing` set to true contained column names with uppercase characters, *SLDataGateway* would incorrectly change these column names to lower case. This lead to the data getting stored in a different field than expected and therefore not being retrieved when requested.

For more information on this issue, see [Inaccessible logger table data in Elasticsearch because of incorrect casing](xref:KI_Inaccessible_data_Elasticsearch_casing)
