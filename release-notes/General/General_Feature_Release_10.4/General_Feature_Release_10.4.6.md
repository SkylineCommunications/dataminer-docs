---
uid: General_Feature_Release_10.4.6
---

# General Feature Release 10.4.6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.6](xref:Cube_Feature_Release_10.4.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.6](xref:Web_apps_Feature_Release_10.4.6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

#### MessageBroker: New NATS reconnection algorithm [ID 38809]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

From now on, when NATS reconnects, it will no longer perform the default reconnection algorithm of the NATS library. Instead, it will perform a custom reconnection algorithm that will do the following:

1. Re-read the MessageBroker configuration file.
1. Update the endpoints to which MessageBroker will connect.

#### Simple alarm filters can now be translated to Elasticsearch/OpenSearch queries [ID 38898]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Simple alarm filters (without operators and/or brackets) can now be translated to Elasticsearch/OpenSearch queries. This will increase overall performance of Elasticsearch/OpenSearch queries containing alarm filters as alarm filtering will now be performed by the database itself. Post-filtering query results will no longer be needed.

#### User-defined APIs: An event will now be sent when an ApiToken or ApiDefinition is created, updated or deleted [ID 39117]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, the user-defined API manager will send out an event whenever an `ApiToken` or `ApiDefinition` object is created, update or deleted.

| Event name | Description |
|---|---|
| ApiTokenChangedEventMessage      | Generated when an [ApiToken](xref:UD_APIs_Objects_ApiToken) is created, updated, or deleted. |
| ApiDefinitionChangedEventMessage | Generated when an [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition) is created, updated, or deleted. |

When subscribing to event messages, you can use the `SubscriptionFilter` to only receive the messages matching a specific filter. See the following example.

```csharp
// In this example, you will take the Connection object from the script's Engine object
var connection = engine.GetUserConnection();

// Create a random set ID that identifies our subscription
var setId = $"ApiTokenSubscription_{Guid.NewGuid()}"

// Create the filter for the ApiToken events, only enabled tokens should match
var filter = ApiTokenExposers.IsDisabled.Equal(false);
var subscriptionFilter = new SubscriptionFilter<ApiTokenChangedEventMessage, ApiToken>(filter);

// Attach a callback when a new event message arrives
connection.OnNewMessage += (sender, args) =>
{
    // Handle the events
}

// Subscribe
connection.AddSubscription(setId, subscriptionFilter);
```

#### Storage as a Service: Support for data migration towards a STaaS system using a proxy server [ID 39313]

<!-- MR 10.5.0 - FR 10.4.6 -->

As from DataMiner version 10.4.5, Storage as Service (STaaS) supports the use of a proxy server.

From now on, it is also possible to migrate data towards a STaaS system that is using a proxy server.

#### Service & Resource Management: New GetFunctionDefinitions method added to ProtocolFunctionHelper class [ID 39362]

<!-- MR 10.5.0 - FR 10.4.6 -->

Up to now, it was only possible to retrieve a single function definition by ID using the *GetFunctionDefinition* method.

From now on, you can retrieve multiple function definitions in one go using the new *GetFunctionDefinitions* method.

#### GQI: Exposing the underlying GQI SLNet connection to extensions like ad hoc data sources and custom operators [ID 39489]

<!-- MR 10.5.0 - FR 10.4.6 -->

The `GetConnection()` method can now be used to expose the underlying GQI SLNet connection to GQI extensions like ad hoc data sources and custom operators via the `IConnection` interface. The method is compatible with existing Nuget packages for automation scripts.

```csharp
IConnection GetConnection()
```

This method will return an [IConnection](xref:Skyline.DataMiner.Net.IConnection) object representing the connection between GQI and SLNet.

> [!NOTE]
> The real underlying connection may be shared by other extensions and queries but can be used as if it were a dedicated connection.

## Changes

### Enhancements

#### MessageBroker: Each individual chunk will now be sent with a dynamic timeout [ID 38633]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

When chunked messages are being sent using MessageBroker, from now on, each individual chunk will be sent with a dynamic timeout instead of a static 5-second timeout.

The dynamic timeout will be calculated as the time it would take to send the chunk at a speed of 1 Mbps, rounded up to the nearest second.

> [!NOTE]
> The minimum timeout will always be 5 seconds.

#### Security enhancements [ID 38869]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

A number of security enhancements have been made.

#### MessageBroker: 'Subscribe' method of the 'NatsSession' class has now been made completely thread-safe [ID 38939]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

The *Subscribe* method of the `NatsSession` class has now been made completely thread-safe.

#### Service & Resource Management: Enhanced performance when activating function DVEs [ID 38972]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when activating function DVEs.

#### GQI: Errors related to real-time GQI data updates will now also be logged [ID 38986]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, errors related to real-time GQI data updates will also be logged.

For example:

- When an ad hoc data source is not able to send an update due to API methods being used incorrectly.
- When a built-in data source is not able to send an update.
- When the connection used to send the updates to the client gets lost.

Exceptions associated with a custom data source will be logged in the log file of the data source in question.

#### Enhanced performance when processing changes made to service properties [ID 39011]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when processing changes made to service properties.

#### NATS configuration files will now use plain JSON syntax [ID 39078]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

All NATS configuration files will now use plain JSON syntax.

#### Enhanced performance when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client [ID 39211]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Performance has increased when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client.

#### SLAnalytics - Behavioral anomaly detection: A decreasing trend slope will now be labeled as a trend change instead of a variance decrease [ID 39249]

<!-- MR 10.5.0 - FR 10.4.6 -->

Up to now, in some cases, a decreasing trend slope would be labeled as a variance decrease. From now on, a decreasing trend slope will be labeled as a trend change instead.

#### Enhanced performance when starting up a DataMiner Agent because of SLDataMiner loading protocols in parallel [ID 39260]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, at DataMiner startup, SLDataMiner will load protocols in parallel. This will considerably increase overall performance when starting up a DataMiner Agent.

#### Service & Resource Management: Queue will now be skipped when processing SetSrmJsonSerializableProperties requests [ID 39264]

<!-- MR 10.5.0 - FR 10.4.6 -->

When the *ResourceManagerHelper* methods *UpdateReservationInstanceProperties* or *SafelyUpdateReservationInstanceProperties* were used to update properties of a booking, up to now, their action was queued on the master DMA to be handled sequentially for all bookings.

From now on, the *SetSrmJsonSerializableProperties* requests will skip said queue.

#### Enhanced SLDBConnection logging [ID 39267]

<!-- MR 10.5.0 - FR 10.4.6 -->

A number of enhancements have been made with regard to the logging of errors and warnings in the *SLDBConnection.txt* log file.

#### SLAnalytics - Proactive cap detection: Enhanced clearing of proactive detection suggestion events [ID 39296]

<!-- MR 10.5.0 - FR 10.4.6 -->

A proactive detecting suggestion event indicating a forecasted crossing of a critical alarm threshold will now be cleared sooner. As soon as the system detects that the predicted trend has dropped below the threshold in question will the suggestion event be cleared.

#### DataMiner Cube clients using a gRPC connection are now able to better detect a disconnection [ID 39308]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, Cube clients connected to a DataMiner Agent via a gRPC connection will now be able to better detect when they have been disconnected.

#### GQI: Changing the minimum log level no longer requires an SLHelper restart [ID 39309]

<!-- MR 10.5.0 - FR 10.4.6 -->

Up to now, when you changed the *serilog:minimum-level* setting in `C:\Skyline DataMiner\Files\SLHelper.exe.config`, the change would only take effect after an SLHelper restart.

From now on, when you change this setting, the change will take effect the moment you save the configuration file. Restarting SLHelper will no longer be necessary.

#### ProtocolCache.txt replaced by ProtocolCacheV2.txt [ID 39316]

<!-- MR 10.5.0 - FR 10.4.6 -->

The *ProtocolCache.txt* file, located in the `C:\Skyline DataMiner\System Cache\` folder, has now been replaced by the *ProtocolCacheV2.txt* file.

While the *ProtocolCache.txt* file only contained information about the protocols that were not fully compatible with Cassandra, the *ProtocolCacheV2.txt* file will also contain information like minimum required DataMiner version.

> [!IMPORTANT]
> up to now, when no compliance information was specified in a protocol, all QActions would be checked for queries incompatible with Cassandra. From now on, it will be assumed that a protocol version is compatible with Cassandra unless Cassandra compliance is explicitly set to false in the `<Compliancies>` element of the protocol.

#### Enhanced performance when starting up a DataMiner Agent [ID 39331]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner Agent.

#### SLDataGateway: Enhanced logging [ID 39341]

<!-- MR 10.5.0 - FR 10.4.6 -->

A number of enhancements have been made with regard to the logging of the SLDataGateway process.

The *SLDBConnection.txt* and *SLCloudStorage.txt* log files will now contain cleaner entries, and entries of type "Error" will also be added to the *SLError.txt* file.

Also, runtime log level updates will now be applied at runtime without requiring a DataMiner restart.

#### GQI now also logs requests to SLNet [ID 39355]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, when the *serilog:minimum-level* setting in `C:\Skyline DataMiner\Files\SLHelper.exe.config` is set to "Debug" or lower, GQI will also log information about requests sent to SLNet.

Types of log entries related to SLNet requests:

- `Started SLNet request <RequestID> with <MessageCount> messages`

  This type of entry will be added to the log when GQI starts a request to SLNet, before the messages included in the request are sent.

  - *RequestID*: A unique ID that will allow you to find all log entries associated with one particular SLNet request.
  - *MessageCount*: The number of SLNet messages included in the request.

- `Sending SLNet message <RequestID>.<Index>: <Description>`

  This type of entry will be added to the log for each individual message in an SLNet request.

  - *RequestID.Index*: The unique ID of the message, consisting of the *RequestID* (which identifies the request) and an *Index* (i.e. the sequence number of the message).
  - *Description*: The string representation of the actual SLNet message, which should give a short but meaningful description of the message.

- `Finished SLNet request <RequestID> in <Duration>ms`

  This type of entry will be added to the log when GQI finishes a request to SLNet, regardless of whether the request was successful or not.

  - *RequestID*: The unique ID of request.
  - *Duration*: The duration of the request, including the time it took for GQI to process it (in milliseconds).

#### Enhanced error message 'Failed to create one or more storages' [ID 39360]

<!-- MR 10.5.0 - FR 10.4.6 -->

When DataMiner fails to start up due to a problem that occurred while connecting to the database, a `Failed to create one or more storages` message will be thrown.

From now on, this error message will include a reference to the StorageModule log file, in which you can find more information about the problem that occurred:

`More info might be available in C:\ProgramData\Skyline Communications\DataMiner StorageModule\Logs\DataMiner StorageModule.txt.`

#### MySql.Data.dll file is now deprecated [ID 39370]

<!-- MR 10.5.0 - FR 10.4.6 -->

The *MySql.Data.dll* file, located in `C:\Skyline DataMiner\ProtocolScripts\`, should from now on be considered deprecated.

This file will no longer be included in DataMiner upgrade packages. Also, a BPA test has been created to detect the presence and usage of this DLL file in protocols and automation scripts.

To remove all references to the *MySql.Data.dll* file in your protocols and automation scripts, do the following:

1. Open DataMiner Cube.
1. Open *System Center*.
1. Go to *Agents > BPA*.
1. Run the *Check Deprecated MySql DLL* test (if it has not been run yet).
1. If references to the DLL file have been found, click the ellipsis button next to the message to see an overview of all protocols and automation scripts that are still using this DLL file.

   This overview is displayed as a string in JSON format. It will contain the following information:

   - The names and versions of the protocols that are still using this file, including the IDs of the QActions in which this file is referenced.
   - The names of the automation scripts that are still using this file.

1. Replace every reference to the *MySql.Data.dll* file in the listed protocol QActions and automation scripts by a reference to the [MySql.Data NuGet](https://www.nuget.org/packages/MySql.Data). Using that NuGet should not require any other changes to the existing code.

When you have replaced all references to the *MySql.Data.dll* file, do the following:

1. Stop the DataMiner Agent.
1. Remove the *MySql.Data.dll* file from the `C:\Skyline DataMiner\ProtocolScripts\` folder.
1. Start the DataMiner Agent.

> [!IMPORTANT]
> The BPA test *Check Deprecated MySql DLL* is only able to detect whether the *MySql.Data.dll* file is referenced directly. For example, if a QAction would contain a reference to a particular DLL that references the *MySql.Data.dll* file, the BPA will not be able to detect this.
> When you remove the *MySql.Data.dll* file, it is advised to keep a temporary copy and to check the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *MySql.Data.dll* file when a QAction or an Automation script was executed.

#### GQI - Get parameters for element: Enhanced performance when querying sorted tables [ID 39376]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance of GQI queries using a *Get parameters for element* data source has been increased, especially when querying sorted tables.

#### SLNet: Enhancements that optimize the performance of the Jobs and Ticketing APIs [ID 39385]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements to SLNet, overall performance of the *Jobs* and *Ticketing* APIs has increased, especially when retrieving data from the database.

#### No longer possible to create new elements as long as SLDataMiner has not finished loading all element information [ID 39392]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

From now on, it will no longer be possible to create new elements as long as SLDataMiner has not finished loading all element information. If an attempt is made to create an element while SLDataMiner is still loading element information, an `Agent is starting up` error will now be returned.

#### SLLogCollector: Enhancements to make sure the JAVA_HOME variable is set [ID 39409]

<!-- MR 10.5.0 - FR 10.4.6 -->

A number of enhancements have been made to prevent SLLogCollector from experiencing problems when the JAVA_HOME variable is not set:

- SLLogCollector is now able to pass environment variables to helper executables. This will allow temporarily setting an environment variable to make sure a particular tool can be run correctly.

- In SLLogCollector, the timeout for helper executables has been reduced from 5 minutes to 1 minute.

- An upgrade action has been created to set the JAVA_HOME variable in case this has not been done by [nodetool](xref:TOONodetool).

#### SLAnalytics - Behavioral anomaly detection: Enhanced performance when updating anomalous change point alarms and suggestion events [ID 39453]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when updating an alarm or suggestion event generated after an anomalous change point has been detected.

#### GQI - Get parameters for element: Enhanced performance when querying single-value parameters [ID 39457]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance of GQI queries using a *Get parameters for element* data source has been increased, especially when querying single-value parameters.

### Fixes

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID 38441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### Protocols: Parsing problem could lead to string values being processed incorrectly [ID 39314]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

When string parameters are parsed, both an ASCII version and a Unicode version of the string value should be returned. However, up to now, when a string parameter was a table column parameter, the `Interprete` type of the table would be used. As a result, string values would be processed incorrectly.

From now on, when a table cell is saved, the `Interprete` type of the column will be used to determine whether or not it has to be processed as a string.

#### Skyline Device Simulator: Problem when loading HTTP simulation files that contained additional tags [ID 39379]

<!-- MR 10.5.0 - FR 10.4.6 -->

In some cases, when you tried to load a PDML file containing an HTTP simulation, the simulation would fail to load, especially when the PDML file contained additional tags (e.g. comments).

#### SLProtocol would return an error when it encountered the parameter type 'matrix' [ID 39398]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Up to now, SLProtocol would add the following line in the log file of an element when it encountered the [parameter type "matrix"](xref:UIComponentsTableMatrix).

`CParameter::ReadSettings|CRU|-1|!! Unknown <Type> MATRIX for parameter`

#### Redundancy group and derived element no longer visible in UI after deleting a protocol used by elements in that redundancy group [ID 39411]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

When a protocol that was being used by elements in a redundancy group was deleted, the redundancy group and the derived element would no longer be visible in the UI after a DataMiner restart, even if their definitions existed on disk. As a result, it would not be possible to delete the redundancy group in a DataMiner client application (e.g. DataMiner Cube).

#### STaaS: Problem when using a delete statement with a filter [ID 39416]

<!-- MR 10.5.0 - FR 10.4.6 -->

When, on a STaaS system, an attempt was made to delete data from the database using a delete statement with a filter, in some cases, the data would not be deleted and the following error would be logged in the *CloudStorage.txt* log file:

`Provided delete filter resulted in a post filter, post filtering is not supported for cloud delete requests.`

This issue has now been fixed.

#### Service & Resource Management: Problems caused by a failed midnight synchronization of the Resource Manager [ID 39420]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

If the midnight synchronization of the Resource Manager fails, it is retried up to 5 times. Up to now, when a synchronization retry was triggered, the internal caches of the Resource Manager would incorrectly be loaded twice. This could lead to e.g. bookings not being starting.

#### SLAutomation: Problem when clearing the internal parameter cache [ID 39441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

In some cases, an error could occur in SLAutomation when its internal parameter cache was being cleared.

#### SLDataMiner would not properly clean up in-memory element information [ID 39443]

<!-- MR 10.5.0 - FR 10.4.6 -->
<!-- Not added to MR 10.5.0: Issue introduced by RN 38988 -->

When an element was stopped or deleted, in some rare cases, SLDataMiner would not properly remove all information about that element from its memory.

#### Security: Problem when granting a user group access to multiple elements in the same view [ID 39449]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

When you tried to grant a user group access to multiple elements in the same view, only the first of the elements you selected would be added.

#### Caches would not get disposed correctly when the Resource Manager was reinitialized [ID 39493]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 [CU0] -->

When the Resource Manager was reinitialized, the caches would not be disposed correctly, causing SLNet to leak memory.

#### 'Security Advisory' BPA test: Issues fixed [ID 39503]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->
<!-- Only added to FR 10.4.6 -->

A number of issues have been fixed in the [Security Advisory](xref:BPA_Security_Advisory) BPA test:

- The NATS test would always report a severity rating, even if all was fine.
- A `NullReference` exception could be thrown when no HTTPS binding existed in IIS.
- When determining whether gRPC was being used, an error could occur when parsing the *MaintenanceSettings.xml* file.
