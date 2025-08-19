---
uid: General_Feature_Release_10.5.9
---

# General Feature Release 10.5.9

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.9](xref:Cube_Feature_Release_10.5.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.9](xref:Web_apps_Feature_Release_10.5.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

#### New BPA test 'Large Alarm Trees' [ID 42952]

<!-- MR 10.6.0 - FR 10.5.9 -->

A new BPA test named "Large Alarm Trees" is now available. This test will retrieve the active alarm trees and check if any are getting too large, because excessively large alarm trees can potentially have a negative impact on your DataMiner System. If any large alarm trees are found, you will need to take the necessary [corrective actions](xref:Best_practices_for_assigning_alarm_severity_levels#keep-alarm-trees-from-growing-too-large).

The BPA test is available in System Center on the *Agents > BPA* tab.

#### Automation scripts: New Interactivity tag [ID 42954]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, Automation scripts using the IAS Interactive Toolkit required a special comment or code snippet in order to be recognized as interactive. From now on, you will be able to define the interactive behavior of an Automation script by adding an `<Interactivity>` tag in the header of the script. See the following example.

```xml
<DMSScript xmlns="http://www.skyline.be/automation">
  ...  
  <Interactivity>Always</Interactivity>
  ...
  <Script>
    ...
  </Script>
</DMSScript>
```

Possible values:

| Value | Description |
|-------|-------------|
| Auto     | Like before, an attempt will be made to automatically detect the interactive behavior of the script. |
| Never    | The script will never show any UI element. |
| Optional | The script will be interactive when it needs to be. |
| Always   | The script will always be interactive. |

#### Automation script and QAction dependencies can now also be uploaded to the 'DllImport\\SolutionLibraries' folder [ID 43108]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, the `UploadScriptDependencyMessage` was only able to upload Automation script and QAction dependencies to the `C:\Skyline DataMiner\Scripts\DllImport` folder. From now on, it will also be able to upload those dependencies to the `C:\Skyline DataMiner\ProtocolScripts\DllImport\SolutionLibraries` folder.

See the following example. The `UploadScriptDependencyMessage` now has a `DependencyFolder` property, which allows you to specify the destination of the dependency to be uploaded.

```csharp
var uploadDependencyMessage = new UploadScriptDependencyMessage()
{
  Bytes = bytes,
  DependencyName = name,
  Path = string.Empty, // Subfolders within the destination can be specified here
  DependencyFolder = ScriptDependencyFolder.SolutionLibraries // Default is 'ScriptDependencyFolder.ScriptImports'
};
```

After a dependency has been uploaded, all scripts using that dependency will be recompiled.

> [!NOTE]
> For QActions in protocols, the relevant SLScripting process must be restarted before the new DLL will get loaded.

#### SLNet: 'TraceId' property added to ClientRequestMessage & extended logging [ID 43187]

<!-- MR 10.6.0 - FR 10.5.9 -->

The `ClientRequestMessage` class has been extended with a new `TraceInfo` class, which has one `TraceId` property of type string. In a later phase, this property will be used to track requests across multiple modules (e.g. queries coming from ad hoc data sources).

CrudLoggerProxy logging will also support trace IDs for CRUD operations by the following managers:

- AppPackageContentManager
- BaseFunctionManager
- BaseProfileManager
- BPAManager
- ClusterEndpointsManager
- ClusterManager
- ConfigurationManager
- DOMManager
- IncrementManager
- JobManager
- MigrationManager
- ModuleSettingsManager
- NATSCustodianManager
- SRMServiceStateManager
- TicketingManager
- UserDefinableApiManager
- VisualManager

Examples of CRUD operation log entries with a trace ID:

```txt
2025/07/02 13:19:14.170|SLNet.exe|CrudLoggerProxy|INF|3|6|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] Object: SectionDefinition, Forced: False, User: DOMAIN\UserName, Action: Creating CustomSectionDefinition[IDQ1XPM7DXBIL9YXKWZZ,c74e85be-2c1d-4002-aaba-a3b7d712fe3a].

2025/07/02 13:19:14.457|SLNet.exe|CrudLoggerProxy|INF|3|6|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] Object: SectionDefinition, Forced: False, User: DOMAIN\UserName, Action: Created CustomSectionDefinition[IDQ1XPM7DXBIL9YXKWZZ,c74e85be-2c1d-4002-aaba-a3b7d712fe3a].
```

Also, the trace ID will be logged for the following messages:

- slow client messages (in *SLNet.txt* and *SLSlowClientMessages.txt*)

  ```txt
  2025/07/02 13:19:34.715|SLNet.exe|LogSlowClientMessage|INF|0|252|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] [Facade.HandleMessage] 60908.7999ms were needed to handle Cube (FirstName LastName @ GTC-USERNAME) => Diagnostic Request: Hang ()
  ```

- incoming messages in SLNet (in *SLNet.txt* and *SLNet\FacadeHandleMessage.txt*)

  ```txt
  2025-07-02 15:05:04.329|277|Facade.HandleMessage|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] Incoming (RTManagerGUI.exe (FirstName LastName @ GTC-USERNAME)): Skyline.DataMiner.Net.Messages.ManagerStoreCreateRequest`1[Skyline.DataMiner.Net.Apps.DataMinerObjectModel.DomDefinition]
  ```

The logging of a DOM manager will now also contain a line indicating the start of status transitions. This will be logged on information level 3, i.e. the same type and level as regular CRUD actions:

```txt
2025/07/02 15:05:11.110|SLNet.exe|HandleStatusTransitionRequest|INF|3|269|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] Handling status transition with ID 'new_to_closed' for instance with ID '1ff720a3-0aa2-4548-8b51-d8b975e19ea4'.
```

#### Service & Resource Management: Support for capacity ranges [ID 43335]

<!-- MR 10.6.0 - FR 10.5.9 -->

Resource capacity ranges are now supported. To that end, profile parameters can now be of type "range".

A resource can have one capacity range per profile parameter. This range can be either fully booked or partially booked.

- If a range is partially booked, other bookings can book the unbooked part of the range as long as the bookings do not overlap.
- The same range can be booked by two overlapping bookings on condition that the same reference string is used and that the range is identical in both bookings. `GetEligibleResources` has been updated to take this into account.

##### Examples

Scenario: A Resource has a capacity range parameter with a range from 100 to 200.

Example 1:

- If a booking books the entire range without a reference string, no other overlapping bookings can book that resource while requesting that same capacity range.
- `GetEligibleResources` will not return that resource if asked for that capacity range with an overlapping time range.

Example 2:

- If a booking books the range from 100 to 110, another booking can book that range from 110 to 200, etc.
- `GetEligibleResources` will return that resource, specifying the available range from 110 to 200.

Example 3:

- If a booking books the range from 100 to 110 with reference string "Example 3", another booking can book the same range from 100 to 110 if it uses the same "Example 3" reference.
- `GetEligibleResources` wil return the entire range if "Example 3" is provided as reference.

##### Creating a range parameter

This is how you can create a range parameter.

```csharp
var rangeCapacityParameter= new ProfileParameter
{
  ID = Guid.NewGuid(),
  Categories = ProfileParameterCategory.Capacity,
  Name = "Range Parameter",
  Type = ProfileParameter.ParameterType.Range,
};
profileHelper.ProfileParameters.Create(rangeCapacityParameter);
```

##### Creating a resource with a capacity range

This is how you can add range 100 to 1000 to a resource.

```csharp
var capacities = new List<MultiResourceCapacity>
{
  new MultiResourceCapacity
  {
    CapacityProfileID = rangeCapacityParameter.ID,
    Value = new CapacityParameterValue(100, 1000),
  }
};

var resource = new Resource(Guid.NewGuid())
{
  Name = "Resource",
  Mode = ResourceMode.Available,
  Capacities = capacities,
  MaxConcurrency = 10
};

resourceManager.AddOrUpdateResources(resource);
```

##### Booking a range

This is how you can book the range from 100 to 150 of a specified resource.

```csharp
var resourceUsage = new ResourceUsageDefinition(resource.ID)
{
  RequiredCapacities = new List<MultiResourceCapacityUsage>
  {
    new MultiResourceCapacityUsage
    {
      CapacityProfileID = rangeCapacityParameter.ID,
      RangeStart = 100,
      DecimalQuantity = 50
    }
  }
};

booking.ResourcesInReservationInstance.Add(resourceUsage);
```

##### Checking which resources have a specific range available

This is how you can check which resources have a specific range available.

```csharp
var requiredCapacities = new List<MultiResourceCapacityUsage>()
{
  new MultiResourceCapacityUsage(rangeCapacityParameter, 100, 50)
};

var requiredCapabilities = new List<ResourceCapabilityUsage>();

result = resourceManager.GetEligibleResourcesWithUsageInfo(now, now.AddHours(1), requiredCapacities, requiredCapabilities);
```

#### Trap forwarding: Traps can now be forwarded to target elements of which a specific hostname was configured in the port settings [ID 43347]

<!-- MR 10.6.0 - FR 10.5.9 -->

SLSNMPManager is now capable of forwarding traps to target elements of which a specific hostname was configured in the port settings.

If the hostname cannot be resolved to an IP address, an error alarm with the following message will be generated on the target element:

`Could not resolve destination host to an IP: polling host=<hostname>, or failed to set the destination address. <ERROR>`

Example:

`Could not resolve destination host to an IP: polling host=localhost123, or failed to set the destination address. Host to IP failure. Error : 11001. [WSAHOST_NOT_FOUND]`

## Changes

### Enhancements

#### SLDataGateway will now check all Cassandra, OpenSearch and Elasticsearch certificates on a daily basis [ID 41793]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

SLDataGateway will now check all Cassandra, OpenSearch and Elasticsearch certificates on a daily basis.

- If a certificate is set to expire within 30 days, a notice alarm will be created.
- If a certificate is set to expire within 7 days, an error alarm will be created.

#### Failover: NATS cluster state will now be visible in DataMiner Cube's Failover Status window [ID 42250] [ID 43169]

<!-- MR 10.6.0 - FR 10.5.9 -->

In DataMiner Cube, the NATS cluster state will now be visible in the *Failover Status* window. This state will indicate whether NATS communication between main agent and backup agent is up and running and whether the *clusterEndpoints.json* file is synchronized between the two agents.

#### OpenSearch: auto_expand_replicas with minimum 0 and maximum 2 [ID 43179]

<!-- MR 10.6.0 - FR 10.5.9 -->

In OpenSearch, indexing will now use the `auto_expand_replicas` setting.

If the database consists of a single node at the time of index creation, an index will be made that has no replicas (minimum number of replicas is set to 0). If, at a later stage, nodes are then added to or removed from the cluster, replicas will automatically be assigned up to a maximum of 2 (maximum number of replicas is set to 2).

#### Swarming: An information event will be generated when an element was successfully swarmed [ID 43196]

<!-- MR 10.6.0 - FR 10.5.9 -->

From now on, an information event will be generated when an element has been successfully swarmed.

Example:

`Swarmed from <DmaName> (<DmaId>) to <DmaName> (<DmaId>) by <UserName>`

> [!NOTE]
> When the source DMA is no longer available or unknown, the information event will be shortened to `Swarmed to <DmaName> (<DmaId>) by <UserName>`.

#### GQI: Enhanced performance when setting up GQI connections [ID 43251]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When executing GQI queries via SLHelper, overall performance has increased when setting up GQI connections.

#### DxMs upgraded [ID 43205] [ID 43298] [ID 43334]

<!-- RN 43205: MR 10.6.0 - FR 10.5.9 -->
<!-- RN 43298: MR 10.5.0 [CU6] - FR 10.5.9 -->
<!-- RN 43334: MR 10.6.0 - FR 10.5.9 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.5
- DataMiner CloudGateway 2.17.9
- DataMiner DataAggregator 3.2.0
- DataMiner FieldControl 2.11.4
- DataMiner Orchestrator 1.7.8
- DataMiner SupportAssistant 1.7.5

<!-- RN 43205 / RN 43334 -->As from now, the CloudGateway and DataAggregator DxMs will also be included in DataMiner upgrade packages. However, these DxMs will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, they will not be installed.

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### Service & Resource Management: Enhanced performance when creating or editing bookings [ID 43254]

<!-- MR 10.6.0 - FR 10.5.9 -->

Because of a number of enhancements, overall performance has increased when creating or editing bookings, especially on systems with a large number of resources.

#### SLAnalytics: Reduced memory usage because of enhanced management of parameters with constant values [ID 43266]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

Because of a number of enhancements, overall memory usage of SLAnalytics has been reduced, especially when managing parameters of which the values remain constant for a long time.

#### NT Notify types NT_SNMP_GET and NT_SNMP_RAW_GET now have infinite loop protection [ID 43273]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

The NT Notify types NT_SNMP_GET (295) and NT_SNMP_RAW_GET (424) now have infinite loop protection.

When an infinite loop is detected, the following will be returned:

- When the `splitErrors` option is set to false, the error message `INFINITE LOOP` will be returned.
- When the `splitErrors` option is set to true, the values will be returned.

#### Automation: An error message will now appear when a script import operation fails [ID 43316]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, in the *Automation* module, you imported an Automation script, up to now, you would not receive any feedback about whether or not the import operation had been successful. Only after checking the Cube logs would you be able to find out that an import operation had failed.

From now on, the following error message will appear whenever an exception is thrown while an Automation script is being imported:

`Something went wrong. Please check the Cube and Automation logging for more information.`

#### Relational anomaly detection: Configuration moved from XML file to database [ID 43320]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, the configuration settings of the relational anomaly detection feature were stored in `C:\Skyline DataMiner\Analytics\RelationalAnomalyDetection.xml`. From now on, these settings will be stored in the *ai_rad_models_v2* database table instead.

As a result, all configuration will have to be done using either the *RAD Manager* app or the RAD API.

The first time DataMiner starts up after having been upgraded to version 10.6.0/10.5.9, all configuration settings will automatically be migrated from the *RelationalAnomalyDetection.xml* file to the *ai_rad_models_v2* database table.

Also, a number of smaller changes have been made:

- The response to a `GetRADParameterGroupInfoMessage` now includes an IsMonitored flag. This flag will indicate whether the (sub)group is correctly being monitored ("true"), or whether an error has occurred that prevents the group from being monitored ("false"). In the latter case, more information can be found in the SLAnalytics logging.
- Instances of (direct) view column parameters provided in the `AddRADParameterGroupMessage` or the `AddRADSubgroupMessage` will now automatically be translated to the base table parameters.
- DVE child parameters provided in the `AddRADParameterGroupMessage` or the `AddRADSubgroupMessage` will now automatically be translated to the parent parameters.
- Security has been added to all RAD messages. From now on, you will no longer be able to edit, remove or retrieve information about groups that contain parameters of elements to which you do not have access. The `GetRADParameterGroupsMessage` will still return all groups though.

#### Proactive cap detection: Enhanced detection of predicted data range breaches [ID 43338]

<!-- MR 10.6.0 - FR 10.5.9 -->

The decision when to trigger a proactive detection suggestion event for a future data range breach (e.g. predicted 100% between ... and ...) has been fine-tuned. This will prevent suggestion events from being generated for parameters with values near or on the data range that should not be considered problematic.

#### DataMiner upgrade: BPA tests 'Check Agent Presence Test In NATS' and 'Verify NATS is Running' replaced by 'Verify NATS Cluster' [ID 43359]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

The BPA tests *Check Agent Presence Test In NATS* (which was renamed to *Nats connections between the DataMiner Agents* in DataMiner versions 10.5.0/10.4.12) and *Verify NATS is Running* have now both been replaced by the *Verify NATS Cluster* test.

This means that, from now on, during a DataMiner upgrade, the *Verify NATS Cluster* test will be installed and any existing instances of the deprecated *Check Agent Presence Test In NATS* and *Verify NATS is Running* tests will be removed.

#### SLDataGateway: Enhanced caching of TTL overrides for the trend data of specific protocols or protocol versions [ID 43362]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

A number of enhancements have been made to the mechanism that is used to cache TTL overrides for the trend data of specific protocols or protocol versions in SLDataGateway, especially for Cassandra and Cassandra Cluster databases.

#### Migration from ElasticSearch to OpenSearch: is_write_index flag of the aliases will no longer be reset [ID 43369]

<!-- MR 10.6.0 - FR 10.5.9 -->

When migrating data from Elasticsearch to OpenSearch, at some point, the *ReIndexElasticSearchIndexes* tool needs to be used to re-index the data.

This tool has now been adapted to make sure the `is_write_index` flag of the aliases is not reset during the migration process.

#### Video thumbnails: New fitMode parameter [ID 43388]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In URLs of video thumbnails, it is now possible to pass a *fitMode* parameter, which will indicate how the image should be displayed.

These are the possible values:

| fitMode | Description |
|---------|-------------|
| fill    | The image will completely cover the container. It may crop parts of the image, but it ensures no empty space. |
| fit     | The image will be fully visible inside the container while maintaining aspect ratio. There may be empty space if aspect ratios differ. |
| stretch | The image will stretch to exactly fill the container, ignoring aspect ratio. This may cause distortion. |
| center  | The image will retain its original size and will be aligned at the center. It may overflow or be cropped. |
| shrink  | The image will behave like *fill* or *center*, whichever results in a smaller image. It will only scale down if needed. |

Default value: fill

Example:

```txt
https://myDMA/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true&fitMode=center
```

#### Trend predictions with prediction intervals spanning the full data range will no longer be shown [ID 43399]

<!-- MR 10.6.0 - FR 10.5.9 -->

From now on, trend predictions with prediction intervals spanning the full data range (i.e. based on `RangeLow` and `RangeHigh`) will no longer be shown.

Such intervals indicate highly unpredictable data behavior, offering little to no meaningful forecasting value.

#### Relational anomaly detection: New default values for 'Anomaly threshold' and 'Minimum anomaly duration' [ID 43400]

<!-- MR 10.6.0 - FR 10.5.9 -->
<!-- Not added to MR 10.6.0 -->

When you add a new relational anomaly parameter group using either the *RAD Manager* app or the RAD API, from now on, the default values of the following settings will be the following:

| Setting | New default value |
|---------|---------|
| Anomaly threshold | 6 |
| Minimum anomaly duration | 15 minutes |

#### Relational anomaly detection: Enhanced logging when swarming elements [ID 43415]

<!-- MR 10.6.0 - FR 10.5.9 -->
<!-- Not added to MR 10.6.0 -->

Up to now, when an element of which no parameter was included in any of the RAD parameter groups was swarmed, the following error would be logged:

`ERR|0|Parameter XXX/YYYY is currently swarming to another hosting agent: RAD groups including this parameter are no longer supported`

From now on, this error will only be logged when at least one parameter of the swarmed element is included in a RAD parameter group.

#### DataMiner Object Models: Updating the display value of an enum is now allowed [ID 43452]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, it was not possible to change the display name of an enum entry when the enum was being used by a DOM instance, despite it having no effect on the underlying enum value or DOM behavior.

This limitation has now been removed. From now on, it will be allowed to update the display name of an enum entry, even if the enum is being used by DOM instances.

#### Improved logging in case STaaS system is not registered [ID 43455]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

To allow easier troubleshooting, logging has now been improved in case a DataMiner System using STaaS is not correctly registered on dataminer.services.

#### Exception when RAD (sub)group is added with anomaly threshold of 0 [ID 43459]

<!-- MR 10.6.0 - FR 10.5.9 -->

When a relational anomaly group or subgroup is added with the AddRADParameterGroupMessage or AddRADSubgroupMessage with anomaly threshold set to 0, an exception will now be thrown. Previously, the exception for this invalid configuration was silently ignored and the anomaly threshold was set to the default value of 3.0.

### Fixes

#### SLManagedScripting: The same dependency would be loaded multiple times by different connectors [ID 42779]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, the same dependency would be loaded multiple times by different connectors. From now on, if multiple connectors attempt to load the same dependency at the same time, it will only be loaded once.

#### Problem when a connector had been modified on a system running multiple SLScripting processes [ID 42877]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, on a system running multiple SLScripting processes, a connector was modified, but its version was left untouched, in some cases, a number of SLScripting processes could incorrectly keep on using outdated QActions or helper libraries, resulting in exceptions like the following being thrown:

`System.ArgumentException: Object of type 'Skyline.DataMiner.Scripting.ConcreteSLProtocolExt' cannot be converted to type 'Skyline.DataMiner.Scripting.SLProtocolExt'`

#### Elements deleted during an element migration could incorrectly not be recovered when an action failed [ID 42976]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When some action would fail during one of the phases of an element migration, up to now, there would be no way to recover any elements that had already been deleted.

From now on, elements will only be deleted once all steps in the migration process have been completed successfully. Moreover, if a step in the process fails after an element has been deleted, it will now be possible to manually recover the deleted element.

#### Problem when restarting an element multiple times in rapid succession [ID 42996]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When an element was restarted multiple times in rapid succession, in some cases, an run-time error could occur in the parameter thread of SLElement.

#### Problem when stopping an element or performing a Failover switch when another action was being executed [ID 43089]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When you stopped an element or performed a Failover switch when another action was being executed (e.g. a parameter set being performed by a QAction), in some cases, a deadlock could occur.

#### Service & Resource Management: Reservation ID of a service created from a service template would disappears when the template was re-applied [ID 43090]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When a service created from a service template had a reservation ID defined, up to now, that reservation ID would incorrectly disappear when the service template was re-applied.

#### Incorrect license check could cause DaaS systems to shut down [ID 43100]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, when a DaaS system was not able to validate its license, after a certain amount of time it would shut down because of an incorrect license check.

#### Service replication would not work when a gRPC connection was being used [ID 43133]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, service replication would not work when a gRPC connection was being used.

#### Service & Resource Management: Booking could incorrectly be set to 'Confirmed' indefinitely [ID 43140]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a booking with status "Ongoing" or "Ended" had its timing or one of its properties updated, in some cases, its status could incorrectly remain set to "Confirmed" indefinitely. This behavior has now been fixed.

Also, from now on, the booking status will only be set to "Confirmed" in the following cases:

- When the start time of the new booking is in the future.
- When the prior reservation has ended, and the new end time is extended to a point in the future beyond the original end time.

#### SLDMS and SLDataMiner could get into a deadlock when redundancy group properties were being updated [ID 43148]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, SLDMS and SLDataMiner could get into a deadlock when redundancy group properties were being updated.

#### DataMiner upgrade: Redirect tags in DMS.xml would incorrectly not be taken into account [ID 43172]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When `<Redirect via="..." />` tags were configured in the *DMS.xml* file, these would incorrectly not be taken into account when an SLNet instance retrieved upgrade progress messages from another SLNet instance.

Although the upgrade would succeed in the background, no information regarding the remote agents would be available in DataMiner Cube or the DataMiner TaskBar Utility during the upgrade, and notices saying that `http://<ip>:8004/UpgradeService` was unavailable would be added to the logs.

#### OpenSearch: Queries with a limit could cause scroll contexts to linger [ID 43191]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In OpenSearch, in some cases, queries with a limit could cause scroll contexts to linger. From now on, queries with a limit will be properly tracked and cleaned up.

#### BrokerGateway would not be able to retrieve local IP addresses at start-up [ID 43209]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

As BrokerGateway is started alongside the Microsoft Windows operating system, in some cases, it would not be able to retrieve the local IP addresses of the server.

To prevent being unaware of certain IP addresses, from now on, BrokerGateway will not only refresh its IP address cache every 5 minutes, it will also refresh that cache each time it detects a network adapter update.

#### SNMP elements could get stuck in slow poll mode [ID 43216]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, SNMP elements could get stuck in slow poll mode because they would fail to recover after connectivity was restored.

#### AnnounceHostingAgentEvent instances could linger around in the cache after a remote agent had reconnected [ID 43230]

<!-- MR 10.6.0 - FR 10.5.9 -->
<!-- Not added to MR 10.6.0 -->

When a remote agent disconnected and later reconnected, in some cases, `AnnounceHostingAgentEvent` instances could linger around in the cache even though the event, element, service or redundancy group no longer existed on that remote agent.

#### Failover: Primary IP address could incorrectly be set to the IP address of the online agent [ID 43257]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, in a Failover setup using a shared hostname, in some cases, the primary IP address would incorrectly be set to the IP address of the online agent instead of the hostname. Moreover, if that primary IP address was set to an incorrect IP address, it would be impossible to remove the Failover pair from the DataMiner System.

Also, from now on, the primary IP address of the offline agent will be set to either the virtual IP address or the hostname of the Failover pair. Up to now, it would be set to the local IP address.

#### Start-up process of a DMA without Swarming enabled would fail abruptly if no db.xml file was present [ID 43274]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a DataMiner Agent that did not have Swarming enabled was started without a *db.xml* file present, up to now, the start-up process would fail abruptly because of an unhandled exception in SLNet. From now on, it will fail gracefully.

#### SNMP managers could get stuck in 'not responding' ping mode [ID 43278]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a northbound SNMP manager configured to send inform messages exhausts all its retries, it enters ping mode. At this point, it generates a "not responding" timeout alarm, and sends a ping inform message to the endpoint to check whether it is up and running again.

Up to now, when an SNMP manager was in ping mode, it could, in some cases, stop sending further ping inform messages to the endpoint.

From now on, when the first ping inform message is unsuccessful, a new ping inform message will be scheduled. Additionally, the following entry will be logged at information log level 1 (in which %s will be replaced by the name of the SNMP manager):

```txt
Adding a ping message for SNMP Manager %s. Too long since last ping was sent. Retrying...
Logging has been adjusted to not spam if multiple SNMP Managers send to the same IP/Port:
Failed resolving authoritative context ID for SNMP Manager
```

#### BrokerGateway: GetConnectionDetails call would incorrectly not return any destinations [ID 43292]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When using the BrokerGateway-managed NATS solution, in some cases, the `GetConnectionDetails` call would incorrectly not return any destinations when an attempt was made to connect to NATS.

Also, up to now, when a `GetNatsConnection` call was made while no endpoints were specified in the *appsettings.runtime.json* file, the response would incorrectly contain `nats://<ip>:4222` instead of `<ip>:4222`.

#### Problem when deleting a DVE child element [ID 43302]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, a run-time error could be thrown when a DVE child element was deleted.

#### Problem when an error was thrown while setting up the Repository API connections between SLDataGateway and SLNet [ID 43314]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When an error was thrown while setting up the Repository API connections between SLDataGateway and SLNet, in some cases, threads in SLNet could get stuck indefinitely, causing certain DataMiner features (e.g. DOM, SRM, etc.) to not being able to progress beyond their initialization phase.

#### Swarming: An element being swarmed would briefly run on the old DMA as well as on the new DMA [ID 43345]

<!-- MR 10.6.0 - FR 10.5.9 -->
<!-- Not added to MR 10.6.0 -->

In some cases, when an element was being swarmed, for a short while, the element in question would incorrectly run on the old DMA as well as on the new DMA.

#### StorageModule DcM would fail to read an element XML file [ID 43350]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some rare cases, the StorageModule DcM would fail to read an element XML file because that file was being used by another process.

From now on, it will try up to three times to read an element XML file that is being used by another process.

#### Fields of type datetime would incorrectly not be empty when the DOM definition field did not have a default value defined [ID 43351]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When a DOM definition field does not have a default value defined, by default, no value should be displayed. However, up to now, when the default time zone had been changed in the *ClientSettings.json* file, fields of type datetime would incorrectly contain the value "01/01/1970 - DefaultTimezone".

From now on, if a DOM definition field does not have a default value defined, all fields of that type will be empty when displayed on a form.

#### Swarming: Element would incorrectly be stuck in the Swarming state after being swarmed [ID 43360]

<!-- MR 10.6.0 - FR 10.5.9 -->
<!-- Not added to MR 10.6.0 -->

After an element had been swarmed, in some cases, that element would incorrectly be stuck in the Swarming state.

#### Swarming: Synchronization issues caused by SLDMS accepting outdated notifications [ID 43373]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

In systems where swarming was enabled, it could occur that SLDMS accepted outdated notifications about element changes, which could lead to synchronization issues between different SLDMS instances, such as race conditions and missing information.

#### SLAnalytics: Problem when grouping suggestion events generated after detecting a relational anomaly or a multivariate pattern [ID 43379]

<!-- MR 10.6.0 - FR 10.5.9 -->
<!-- Not added to MR 10.6.0 -->

When a relational anomaly or a multivariate pattern is detected, suggestion events are generated for all parameters in the corresponding relational anomaly group or all parameters associated with the multivariate pattern, and then those events are grouped into an incident.

Up to now, When the DataMiner Agent that detected the relation anomaly or the multivariate pattern was also the incident tracking leader, in some cases, a deadlock could occur while grouping the suggestion events that had been generated.

#### Failover: DMS call DMS_VERIFY_CLIENT_COOKIE would incorrectly be sent to the offline agent [ID 43397]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In a Failover setup using a shared hostname, the DMS call `DMS_VERIFY_CLIENT_COOKIE` would incorrectly be sent to the offline agent instead of the online agent.

From now on, whenever the offline agent receives a `DMS_VERIFY_CLIENT_COOKIE` call, it will forward it to the online agent.

#### SLDataMiner.txt log file entries could incorrectly contain a placeholder instead of the actual name of the function [ID 43398]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In the *SLDataMiner.txt* log file, log entries could incorrectly contain the `__FUNCTION__` placeholder instead of the actual name of the function in question.

#### Certain log files would have their maximum size incorrectly set to 0 [ID 43403]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some rare cases, certain log files could have their maximum size incorrectly set to 0, causing them to start a new file each time an entry was added.

From now on, by default, all log files will have their maximum size set to 10 MB.

#### Failover: Problem when synchronizing the ClusterEndpoints.json files on large systems [ID 43407]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

In large DataMiner Systems, in some cases, an issue could occur when the *ClusterEndpoints.json* files were being synchronized, causing the DataMiner Agents to keep on synchronizing those files indefinitely.

#### SLAnalytics - Pattern matching: Problem when retrieving the streaming matches [ID 43419]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a linked pattern was created on elements hosted on different DataMiner Agents, in some cases, the `getPatternMatchMessage` would not return the correct number of streaming matches.

#### Swarming: Hosting agent cache in SLDataMiner could get out of sync after an element had been swarmed [ID 43434]

<!-- MR 10.6.0 - FR 10.5.9 -->
<!-- Not added to MR 10.6.0 -->

After an element had been swarmed, in some rare cases, the hosting agent cache in SLDataMiner could get out of sync.

#### SLAnalytics - Automatic incident tracking: Problem due to an incorrect internal state [ID 43451]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, an incorrect internal state in the automatic incident tracking feature could cause the SLAnalytics process to stop working.

#### Memory issues caused by file offloads on a STaaS system [ID 43471]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 [CU0] -->

When a system using STaaS switched back from file storage to database storage after it had not been able to reach the database for some time, this could cause too much data to be pushed at the same time, causing memory issues on the DMA.
