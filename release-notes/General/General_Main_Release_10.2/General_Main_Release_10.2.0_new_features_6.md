---
uid: General_Main_Release_10.2.0_new_features_6
---

# General Main Release 10.2.0 - New features (part 6)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> A DataMiner Installer v10.2 is available on [DataMiner Dojo](https://community.dataminer.services/download/dataminer-installer-v10-2/).
>
> - For 64-bit systems only.
> - No longer contains the necessary files to install MySQL.
> - Unattended cluster installation is not supported.
> - On Windows Server 2022, an “Internal server error” is thrown after installation. Workaround:
>   - Go to <https://www.iis.net/downloads/microsoft/url-rewrite>.
>   - Download and install the URL rewrite module.
>   - Go to <http://localhost/root> and verify whether the root page is shown.

### DMS Service & Resource Management

#### ReservationInstances now have an 'AbsoluteQuarantinePriority' property \[ID_28080\]

ReservationInstances now have an “AbsoluteQuarantinePriority” property.

Resources reserved by a ReservationInstance of which the AbsoluteQuarantinePriority property was set to true will force all resource usages of overlapping ReservationInstances into quarantine.

The usages of a ReservationInstance with absolute quarantine priority do not need to reserve any capacities or capabilities.

In the example below, resources will be quarantined from 10h to 12h UTC tomorrow.

```csharp
var tomorrow = DateTime.UtcNow.AddDays(1).Date;
var timeRange = new TimeRangeUtc(tomorrow.AddHours(10), tomorrow.AddHours(12));
var instance = new ReservationInstance(timeRange) {
    HasAbsoluteQuarantinePriority = false,
    Status = ReservationStatus.Confirmed
};
instance.ResourcesInReservationInstance.Add(new ResourceUsageDefinition(resourceToQuarantine.ID));
```

When a ReservationInstance is added with absolute quarantine priority, an error with reason “ReservationUpdateCausedReservationsToGoToQuarantine” will be returned if this causes any bookings to be quarantined. In that case, the update must be executed using the “forceQuarantine” flag.

> [!NOTE]
>
> - It is possible to add multiple overlapping bookings with AbsoluteQuarantinePriority. If they book the same resource and if results in an overbooking of the resource, one of the instances will be quarantined. If there is no overbooking of the resources between the two bookings with AbsoluteQuarantinePriorit, both bookings will be scheduled.
> - When a booking with AbsoluteQuarantinePriority is removed, the other bookings using the resources will not automatically be taken out of quarantine.
> - Resources that are in quarantine because they overlap with a booking that reserves them with AbsoluteQuarantinePriority will have a QuarantineTrigger with reason “AbsoluteQuarantinePriorityReservationInstance”.

#### Calls requesting eligible resources will now also return information about the available capacity of the resources \[ID_28125\]

The EligibleResourceResult returned by the various GetEligibleResources calls will now contain information about the available capacity of the resources. The ResourceUsageDetails object now includes a CapacityUsageDetails list that contains the maximum available capacities for the requested time frame.

> [!NOTE]
>
> - The available capacity does not take into account the requested capacity.
> - The available capacity for capacities that were not requested in the GetEligible call, but which are present on the resource, will not be calculated, and will therefore not be present in the CapacityUsageDetails list.

#### Triggering an Automation script to reconfigure running bookings after a ProfileInstance was changed \[ID_28186\]

It is now possible to have an Automation script triggered when a profile instance update affects running bookings. That script can then reconfigure the bookings.

##### Configuring the script

The script to reconfigure the bookings can be set on the ProfileManagerConfiguration. See the example below.

```csharp
var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
var config = profileHelper.Config.Get();
config.UpdateBookingConfigByReferenceScript = "scriptname";
profileHelper.Config.Set(config);
```

This configuration is automatically synchronized among the Agents in the DMS. Updating the configuration does not require a DMA restart to take effect.

The script will be triggered using a new OnSrmBookingsUpdatedByReference entrypoint. See the example below.

- ProfileInstanceId will contain the ID of the ProfileInstance that was updated.
- reservationIds will contain the IDs of all running ReservationInstances that were reconfigured because of the update.

  This list does not have to include the IDs of the ReservationInstances that, although they did not reference the ProfileInstance, had usages quarantined because the update caused an overbooking.

```csharp
public class Script
{
    [AutomationEntryPoint(AutomationEntryPointType.Types.OnSrmBookingsUpdatedByReference)]
    public void RunEntryPoint(Engine engine, Guid profileInstanceId, List<Guid> reservationIds)
    {
    }
}
```

##### New errors

The UpdateAndApply call for a ProfileInstance can now return a number of additional errors.

When calling UpdateAndApply without forcing quarantine (i.e. with forceQuarantine set to false):

- If no instances need to be quarantined, the update will be applied and the following warning will be returned:

  - A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the running reservations that were reconfigured because of the update.

- If instances need to be quarantined, the update will not proceed and the following errors will be returned:

  - An error with reason ReservationsMustMovedToQuarantine, listing the reservations that need to be quarantined as well as the usages.
  - An error with reason ReservationsMustBeReconfigured, listing the bookings that will be affected by the ProfileInstance update.

When calling UpdateAndApply and forcing quarantine (i.e. with forceQuarantine set to true), the update will proceed and the following TraceData will be returned:

- A warning of type ReservationInstancesMovedToQuarantine, listing the reservations and the usages that were quarantined.
- A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the reservations that were reconfigured because of the update.

##### New RequiredProfileInstanceReconfiguration property

A new RequiredProfileInstanceReconfiguration property has been added to the ServiceReservationInstance class. When a ProfileInstance has been updated, all ReservationInstances referencing this ProfileInstance in any of their usages will have this property set to true. This way, solutions can keep track of the bookings that have been reconfigured in case the custom script was interrupted.

See the following example on how to filter on this property:

```csharp
var rmHelper = new ResourceManagerHelper();
rmHelper.RequestResponseEvent += (sender, args) => args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);
var filter = ServiceReservationInstanceExposers.RequiredProfileReconfiguration.Equal(true);
var instancesThatRequiredReconfig = rmHelper.GetReservationInstances(filter);
```

##### Additional information

- If triggering the configured script fails, a notice will be generated with the following text:

  ```txt
  Failed to run script to reconfigure bookings after updating ProfileInstance because an exception occurred. See SLProfileManager.txt logging for more details.
  ```

- When the UpdateBookingConfigByReferenceScript is not configured (i.e. when the setting is empty or null in the profile manager configuration):

  - No attempt will be made to trigger a script.
  - The RequiredProfileInstanceReconfiguration property will not be set to true on the instances.
  - No additional error or warning will be returned in the calls.

#### ResourceManagerHelper.SetReservationDefinitionsAndOverrides method has been rendered obsolete \[ID_28261\]

The ResourceManagerHelper.SetReservationDefinitionsAndOverrides method has been rendered obsolete.

#### ServiceNameInUse check when a ServiceReservationInstance is started \[ID_28327\]

From now on, when a ServiceReservationInstance is started, a check will be performed to see whether a service with the same name is already active. If so, a StartActionsFailureErrorData object will be returned with error reason “ServiceNameInUse”, the error will be logged and the OnStartActionsFailureEvent will be triggered.

The StartActionsFailureErrorData object will also contains the following:

- ReservationInstanceId: The ID of the ServiceReservationInstance that could not be started.
- ServiceId: The ID of the service that has the same name.

#### DVE element will only be updated when certain properties of the FunctionResource are updated \[ID_28450\]

Up to now, each time you updated a FunctionResource, the DVE element would also be updated. From now on, the DVE element will only be updated when one of the following properties of the FunctionResource is updated:

- DmaID
- ElementID
- MainDVEDmaID
- MainDVEElementID
- FunctionName
- FunctionGUID
- PK
- LinkerTableEntries

#### MinReservationStart and MaxReservationCeiling checks have been removed \[ID_28575\]

The MinimumReservationStart and MaximumReservationCeiling checks have been removed.

This means that the start and stop times of ReservationInstances and ReservationDefinitions no longer need to be between the MinimumReservationStart and MaximumReservationCeiling.

Also, the following ResourceManagerErrorData reasons have now all been marked as obsolete:

- BulkAddingFirstOrLastToOLateOrTooEarly
- EndsAfterMaximumReservationCeiling
- StartsBeforeMinimumReservationStart
- ReservationDefinitionMinimumReservationStart
- ReservationDefinitionMaximumReservationCeiling

#### ProfileDefinitions & ProfileInstances: Hiding parameters \[ID_28792\]

A ParameterSettings property has been added to the ProfileDefinition and ProfileInstance classes. Currently, this property can be used to configure whether a parameter should be displayed or not by setting the IsHidden property (which, by default, is false).

ProfileDefinition example:

```csharp
var profileDefinition = new ProfileDefinition()
{
    ID = Guid.NewGuid(),
    Name = "ProfileDefinition name",
    ParameterIDs = { profileParameter },
    ParameterSettings = new Dictionary<Guid, ParameterSettings>()
    {
        {profileParameter, new ParameterSettings() { IsHidden = false }}
    }
};
```

ProfileInstance example:

```csharp
var profileInstance = new ProfileInstance
{
    ID = Guid.NewGuid(),
    Name = $"ProfileInstance name",
    AppliesToID = profileDefinitionId,
    Values = new []
    {
        new ProfileParameterEntry
        {
            Parameter = new ProfileParameter()
            {
                ID = profileParameter
            },
            ParameterSettings = new ParameterSettings()
            {
                IsHidden = true
            }
        }
    }
};
```

#### ServiceDefinitions of type 'ProcessAutomation' \[ID_28799\]

The ServiceDefinition object now has a ServiceDefinitionType property, which can be used to distinguish ProcessAutomation ServiceDefinitions from default ServiceDefinitions.

The default value of ServiceDefinitionType is “Default”.

Example:

```csharp
// Creating a ServiceDefinition with the "ProcessAutomation" type
var serviceDefinition = new ServiceDefinition()
{
    Name = "some name",
    ServiceDefinitionType = ServiceDefinitionType.ProcessAutomation,
}
// Filtering on "ServiceDefinitionType"
var filter = ServiceDefinitionExposers.ServiceDefinitionType.Equal((int) ServiceDefinitionType.ProcessAutomation);
serviceManagerHelper.GetServiceDefinitions(filter);
```

#### Option to remember which view a function DVE was in when it got deactivated \[ID_28884\]

It is now possible for a function DVE that gets deactivated to remember the view it was in. That way, when it gets reactivated again afterwards, it can be placed in the same view as before.

Since this feature will prevent views of inactive function DVEs from being removed from the *Views.xml* file, it can make the *Views.xml* file grow extensively. Therefore, it is disabled by default and has to be enabled manually in the *MaintenanceSettings.xml* file. See the example below.

```xml
<MaintenanceSettings>
  <SLNet>
    <KeepFunctionDveViewsOnDisable>true</KeepFunctionDveViewsOnDisable>
  </SLNet>
</MaintenanceSettings>
```

> [!NOTE]
> When a resource is removed, all associated entries will be removed from the *Views.xml* file.

#### ServiceResourceUsageDefinition now has an IsContributing flag \[ID_28904\]

The ServiceResourceUsageDefinition object now has an IsContributing flag, which can be used to indicate that the resource is being used is a contributing resource.

Example:

```csharp
// Setting the flag
var reservationInstance = new ServiceReservationInstance(new TimeRangeUtc(DateTime.UtcNow.AddHours(1), TimeSpan.FromHours(1)));
reservationInstance.ResourcesInReservationInstance.Add(new ServiceResourceUsageDefinition(resource.ID)
{
    IsContributing = true
});
```

#### EligibleResourceContext can now contain a flag to indicate whether LinkerTableEntries should be filled in or not \[ID_28933\]

When requesting EligibleResources, it is now possible for the EligibleResourceContext to indicate whether the LinkerTableEntries property of the Resources should be filled in or not.

Example:

```csharp
var context = new EligibleResourceContext()
{
    TimeRange = _reservationTimeRange,
    RequiredCapacities = new List<MultiResourceCapacityUsage>()
    {
        new MultiResourceCapacityUsage(_capacityParameterId, 1),
    },
    FillLinkerTableEntries = true
};
resourceManagerHelper.GetEligibleResources(context);
```

> [!NOTE]
> As filling in the LinkerTableEntries can have a negative impact on the overall performance, the LinkerTableEntries flag will by default be set to false.

#### New option to retrieve ProfileInstance parameters from the cache \[ID_29160\]

When the GenerateRequiredCapas method is called on a ProfileInstance, the response will contain all parameters of that instance and its parents. If these parameters are not yet cached on the instances, they will automatically be retrieved from the server. However, in some cases, retrieving them from the server will not be necessary because the script or application in question already cached them.

From now on, the automatic server retrieval can be bypassed by

1. creating a retrieval method that tries to return the parameters that are already cached in the script or application before retrieving them from the server (see the example below), and
1. passing that method to the GenerateRequiredCapas(Func\<ProfileParameterEntry, Parameter> parameterResolver) call.

The following example shows a method that tries to return the parameters that are already cached in the script or application before retrieving them from the server. We first check whether a certain parameter can be found in the local “\_profileParameterCache”. If not, we then retrieve it using the built-in AutoSync collection by means of a get operation on Parameter property.

```csharp
private Parameter GetParameterForParameterEntry(ProfileParameterEntry entry)
{
    if (_profileParameterCache.TryGetValue(entry.ParameterID, out var parameter))
    {
        return parameter;
    }
    // Not found in cache, retrieve using internal AutoSync collection   (by just doing a get on Parameter)
    parameter = entry.Parameter;
    if (parameter == null)
    {
        throw new Exception($"Could not retrieve parameter with ID: {entry.ParameterID}");
    }
    // Add it to our cache
    _profileParameterCache.Add(parameter.ID, parameter);
    return parameter;
}
```

#### New log file: SLResourceManagerAutomation.txt \[ID_29233\]\[ID_29281\]

The following actions will now be logged in the SLResourceManagerAutomation.txt file instead of the SLResourceManager.txt file:

- Actions related to the registering and unregistering of ReservationInstances
- Actions related to the starting of ReservationInstances
- Actions related to the execution of ReservationInstance events

All these log entries will have log level 5.

> [!NOTE]
> In DataMiner Cube, you can access this new log file by going to *System Center \> Logging \> DataMiner \> Resource Manager Automation*.

#### New caching mechanism when retrieving ReservationInstances from Elasticsearch \[ID_29289\]

A caching mechanism involving three separate caches will now be used when retrieving ReservationInstances from an Elasticsearch database, especially when the already saved ReservationInstances have to be checked, e.g. when saving a new ReservationInstance or when requesting the availability of resources in a certain time frame.

##### Overview of the caches

| Cache | Description |
|--|--|
| Hosted ReservationInstance cache | When the ResourceManager module starts, this cache loads the ReservationInstances that are hosted on the agent and schedules the start/stop actions and booking events for these ReservationInstances. Any new instances hosted on the agent that are added or updated while the ResourceManager module is running will also be added to this cache so they can be scheduled. On startup, only the instances starting before a certain point in the future are loaded (default: 1 day). At regular intervals, the database will be checked for instances further in the future. |
| ID cache | When a specific ReservationInstance is requested by ID, the result is cached in this ID cache. When an internal request is made for a specific ID, the cached ReservationInstance will be returned. Used when adding or editing ReservationInstances and when executing start/stop actions and ReservationEvents. |
| Time range cache | When ReservationInstances within a specific time range are requested, all instances in that time range will be cached in this cache. Used when new bookings are created or when eligible resources are requested. |

> [!NOTE]
> GetReservationInstances calls from scripts or clients will go straight to the database. They will not use the caching mechanism.

##### Configuration of the caches

The caches can be configured in the *C:\\Skyline DataMiner\\ResourceManager\\Config.xml* file. See the following example.

```xml
<?xml version="1.0" encoding="utf-8"?>
<ResourceManagerConfig>
  <CacheConfiguration>
    <IdCacheConfiguration>
      <MaxObjectsInCache>100</MaxObjectsInCache>
      <ObjectLifeSpan>P1DT12H</ObjectLifeSpan>
    </IdCacheConfiguration>
    <TimeRangeCacheConfiguration>
      <MaxObjectsInCache>200</MaxObjectsInCache>
      <TimeRangeLifeSpan>PT30M</TimeRangeLifeSpan>
      <CleanupCheckInterval>PT5M</CleanupCheckInterval>
    </TimeRangeCacheConfiguration>
    <HostedReservationInstanceCacheConfiguration>
      <InitialLoadDays>P10D</InitialLoadDays>
      <CheckInterval>PT12H</CheckInterval>
    </HostedReservationInstanceCacheConfiguration>
  </CacheConfiguration>
</ResourceManagerConfig>
```

Overview of the different settings:

| Cache | Setting | Description | Default value |
|--|--|--|--|
| IdCacheConfiguration | MaxObjectsInCache | The maximum amount of objects that will be kept in this cache. When this threshold is exceeded, the oldest objects will be removed. | 500 |
|  | ObjectLifeSpan | The maximum period of time an entry will be kept in the cache. Each time the entry is hit, this timer is reset. This setting has to be formatted according to ISO 8601. | 10 minutes |
| TimeRangeCacheConfiguration | MaxObjectsInCache | The maximum amount of objects that will be kept in this cache. When this threshold is exceeded, the oldest time ranges will be removed. | 3000 |
|  | TimeRangeLifeSpan | The maximum period of time a time range will be kept in the cache. Each time a query hitting this time range is resolved, this timer is reset. This setting has to be formatted according to ISO 8601. | 10 minutes |
|  | CleanupCheckInterval | The interval at which the time ranges to be removed are checked. This setting has to be formatted according to ISO 8601. | 1 minute |
| HostedReservationInstanceCacheConfiguration | InitialLoadDays | The setting that controls how long into the future the ReservationInstances will be loaded at ResourceManager startup. This setting has to be formatted according to ISO 8601. | 1 day |
|  | CheckInterval | The period of time after which the ResourceManager will load new bookings from the database. | 6 hours |

> [!NOTE]
> The ResourceManagerConfig.InitialLoadDays setting no longer has any use, as the ReservationInstances will now be loaded according to the settings in HostedReservationInstanceCacheConfiguration.

##### ClientTest tool

The SLNetClientTest tool now allows you to retrieve the IDs of the currently cached ReservationInstances. To do so, go to *Advanced \> Apps \> SRMSurveyor \> Inspect ReservationInstance Cache*.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

##### Logging

If loglevel 6 is enabled, the caches will log any added, updated or removed items in the SLResourceManagerStorage.txt file.

#### Enhanced performance by implementing ISerializable on the ReservationInstance class using protocol buffer serialization \[ID_29306\]

Overall performance has increased by implementing ISerializable on the ReservationInstance class using protocol buffer serialization.

> [!WARNING]
> BREAKING CHANGES:
>
> - The Children and Parent property of a ReservationInstance will no longer be serialized between client and server. When the ResourceManagerHelper is used, backwards compatibility is implemented. However, if you use the messages yourself and receive ResourceManagerEventMessages via subscriptions (which is NOT recommended), you will need to call the GetStitched method on the ReservationInstance class. Saving ReservationInstances with a parent or child instance using messages may also cause issues.
> - When the SetReservationInstances method is called on the ResourceManagerHelper, a random ID will now be assigned before the instances are saved to the server. This could be an issue if scripts expect the ID to be empty and try to reuse the object.

#### ResourceUsageDetails object now has a ConcurrencyLeft property \[ID_29592\]

The ResourceUsageDetails object now has a ConcurrencyLeft property.

When, in the ResourceManagerHelper class, you use the GetEligibleResources method, the returned ResourceUsageDetails object will now include a ConcurrencyLeft property, which will indicate the amount of concurrency left for the resource in question.

When ResourceUsageDetails is equal to null, ConcurrencyLeft will be equal to 0.

#### Binding a VirtualFunctionResource using the primary key \[ID_29648\]

It is now also possible to bind a VirtualFunctionResource using the primary key of an EntryPointTable.

> [!NOTE]
> Binding two resources to the same row, one using the display key and one using the primary key, is not supported and will return a TargetAlreadyBound error.

#### Export and importing ServiceProfileDefinitions and ServiceProfileInstances \[ID_29673\]

Using the ProfileHelper, it is now possible to export and import ServiceProfileInstances and ServiceProfileDefinitions.

##### Exporting ServiceProfileDefinitions and ServiceProfileInstances

The ExportServiceProfiles method allows you to export ServiceProfileDefinitions and ServiceProfileInstances. See the following example.

```csharp
var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
var definitionsToExport = new List<Guid>(){ ... };
var instancesToExport = new List<Guid>(){ ... };
var exportResult = profileHelper.ImportExport.ExportServiceProfiles(definitionsToExport, instancesToExport);
```

As shown in the example above, two lists have to be provided:

- A list containing the IDs of the ServiceProfileDefinitions to be exported
- A list containing the IDs of the ServiceProfileInstances to be exported

Based on the information in those lists, the following data will be exported:

- All existing ServiceProfileDefinitions of which the ID is found in the first list.
- All existing ServiceProfileInstances of which the ID is found in the second list.
- All ServiceProfileInstances that are linked to the ServiceProfileDefinitions found in the first list.

> [!NOTE]
>
> - IDs of non-existing objects will be ignored.
> - If you only want to export the ServiceProfileInstances, you can leave the definitionsToExport list empty.

The ExportServiceProfiles method returns a ServiceProfilesExportResult object that contains the following data:

| Property                              | Type                             | Description                                                                  |
|---------------------------------------|----------------------------------|------------------------------------------------------------------------------|
| ZippedData                            | byte\[\]                         | A ZIP file containing all the exported data.                                 |
| ExportedServiceProfileDefinitions | List\<ServiceProfilesObjectInfo> | All ServiceProfileDefinitions that were successfully exported (ID and name). |
| ExportedServiceProfileInstances   | List\<ServiceProfilesObjectInfo> | All ServiceProfileInstances that were successfully exported (ID and name).   |

> [!NOTE]
>
> - When something goes wrong during an export operation, an unknown error will be added to the TraceData. which can be retrieved using profileHelper.ImportExport.GetTraceDataLastCall().
> - To pinpoint any non-existing objects, you can compare the list of IDs you provided to the list of IDs that was returned.
> - When two empty lists are passed to the export method, an ArgumentException will be thrown.

##### Importing ServiceProfileDefinitions and ServiceProfileInstances

The ImportServiceProfiles method allows you to import ServiceProfileDefinitions and ServiceProfileInstances. See the following example.

```csharp
var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
byte[] zippedData = ...;
var importResult = profileHelper.ImportExport.ImportServiceProfiles(zippedData);
```

During an import operation, the objects are first unzipped from the byte array and then saved to the database after a number of compatibility checks.

Checks performed before saving a ServiceProfileDefinition:

- When a ServiceProfileDefinition already exists with the same name but a different ID, the ServiceProfileDefinition will not be imported and an error with reason ServiceProfileDefinitionNameInUse will be returned.
- When not all ProfileParameters referenced in the NodeDefinitionConfiguration exist, the ServiceProfileDefinition will not be imported and an error with reason ServiceProfileDefinitionRefersToNonExistingParameters will be returned.

Checks performed before saving a ServiceProfileInstance:

- When a ServiceProfileInstance already exist with the same name but a different ID, the ServiceProfileInstance will not be imported and an error with reason ServiceProfileInstanceNameInUse will be returned.
- When not all ParameterOverrides on the NodeInstanceConfigurations and InterfaceConfigurations refer to existing ProfileParameters, the ServiceProfileInstance will not be imported and an error with reason ServiceProfileInstanceRefersToNonExistingParameters will be returned.
- When not all NodeInstanceConfigurations and InterfaceConfigurations refer to existing ProfileInstances, the ServiceProfileInstance will not be imported and an error with reason ServiceProfileInstanceRefersToNonExistingProfileInstances will be returned.

The ImportServiceProfiles method returns a ServiceProfilesImportResult object that contains the following data:

| Property                              | Type                             | Description                                                                  |
|---------------------------------------|----------------------------------|------------------------------------------------------------------------------|
| TraceData                             | TraceData                        | All errors that occurred when importing the objects.                         |
| ImportedServiceProfileDefinitions | List\<ServiceProfilesObjectInfo> | All ServiceProfileDefinitions that were successfully imported (ID and name). |
| ImportedServiceProfileInstances   | List\<ServiceProfilesObjectInfo> | All ServiceProfileInstances that were successfully imported (ID and name).   |

> [!NOTE]
>
> - The TraceData returned by profileHelper.ImportExport.GetTraceDataLastCall() will match the TraceData included in the ServiceProfilesImportResult object.
> - If you want to know why an object was not imported, you can check the TraceData.
> - When an empty byte array is passed to the import method, an ArgumentException will be thrown.

##### ServiceProfilesImportError

When an object cannot be saved to the database during an import operation, a ServiceProfilesImportError will be added to the TraceData. Below, you can find the list of all possible error reasons.

| Error reason | Description |
|--|--|
| Unknown | An unknown error occurred. |
| GeneralFailure | An unexpected exception occurred while importing. The zipped data that was provided is probably invalid.<br> - Exception: The full exception message. |
| UnrecognizedType | The zip file contained an object with an unrecognized type.<br> - EntryName: The name of the unrecognized entry. |
| ExtractingJsonFailed | Something went wrong when trying to extract the JSON data associated with an entry.<br> - Exception: The exception that occurred while extracting.<br> - ObjectType: The type of the entry for which the JSON data was extracted.<br> - ObjectId: The ID of the entry for which the JSON data was extracted. |
| DeserializationFailed | Something went wrong when trying to deserialize the JSON data.<br> - Exception: The exception that occurred while deserializing.<br> - ObjectType: The type of the entry for which the JSON data was deserialized.<br> - ObjectId: The ID of the entry for which the JSON data was deserialized. |
| ErrorOccuredSavingServiceProfileDefinition | An error occurred while saving the ServiceProfileDefinition.<br> - ServiceProfileDefinitionError: The error message.<br> - ObjectId: The ID of the ServiceProfileDefinition.<br> - ObjectName: The name of the ServiceProfileDefinition. |
| ErrorOccuredSavingServiceProfileInstance | An error occurred while saving the ServiceProfileInstance.<br> - ServiceProfileInstanceError: The error message.<br> - ObjectId: The ID of the ServiceProfileInstance.<br> - ObjectName: The name of the ServiceProfileInstance. |
| ServiceProfileDefinitionNameInUse | The name of a ServiceProfileDefinition that is being imported is being used by another ServiceProfileDefinition.<br> - ObjectId: The ID of the ServiceProfileDefinition that is being imported.<br> - ObjectName: The name of the ServiceProfileDefinition that is being imported.<br> - ConflictingId: The ID of the ServiceProfileDefinition that is using the same name.<br> - ConflictingName: The name that is being used. |
| ServiceProfileDefinitionRefersToNonExistingParameters | The NodeDefinitionConfiguration of a NodeDefinition references parameters that do not exist in this system.<br> - ObjectId: The ID of the ServiceProfileDefinition that is being imported.<br> - ObjectName: The name of the ServiceProfileDefinition that is being imported.<br> - MissingIds: The IDs of the missing parameters. |
| ServiceProfileInstanceNameInUse | The name of a ServiceProfileInstance that is being imported is being used by another ServiceProfileInstance.<br> - ObjectId: The ID of the ServiceProfileInstance that is being imported.<br> - ObjectName: The name of the ServiceProfileInstance that is being imported.<br> - ConflictingId: The ID of the ServiceProfileInstance that is using the same name.<br> - ConflictingName: The name that is being used. |
| ServiceProfileInstanceRefersToNonExistingParameters | Either the NodeInstanceConfiguration or the InterfaceConfiguration contains parameter overrides that refer to parameters that do not exist in the system.<br> - ObjectId: The ID of the ServiceProfileInstance that is being imported.<br> - ObjectName: The name of the ServiceProfileInstance that is being imported.<br> - MissingIds: The IDs of the missing parameters. |
| ServiceProfileInstanceRefersToNonExistingProfileInstances | Either the NodeInstanceConfiguration or the InterfaceConfiguration contains references to ProfileInstances that do not exist in this system.<br> - ObjectId: The ID of the ServiceProfileInstance that is being imported.<br> - ObjectName: The name of the ServiceProfileInstance that is being imported.<br> - MissingIds: The IDs of the missing ProfileInstances. |

#### Generating contributing functions for service definitions that use mediated virtual functions on one of more nodes \[ID_29752\]

It is now possible to generate contributing functions for service definitions that use a mediated virtual function on one or more nodes.

> [!NOTE]
>
> - For the replication to work, the profile parameter used to generate the parameter in the contributing protocol needs to contain a ProtocolParameterReference to the parameter in the protocol of the VirtualFunctionDefinition.
> - If a service definition node has both the VirtualFunctionID property (to use a mediated virtual function) and the FunctionID property (to use a protocol function) filled in, the VirtualFunctionID will be used during generation.
> - Only the profile definition of the VirtualFunctionDefinition’s VirtualNode will be taken into account when creating parameters.

#### SRM events can now be forwarded as ProtoBuf events on the NATS bus \[ID_29821\]

When an SRM object is created, updated or deleted, an event message is sent via the SLNet subscription system to notify everyone. The NATS forwarding logic also receives these event messages and will now publish a ProtoBuf event on the NATS bus each time it receives such a message.

##### Proto files

The ProtoBuf event messages are defined by ProtoBuf files, which can be obtained on request.

The events themselves are defined in the API protos, which import shared messages from the main shared folder.

##### Subscribing to the NATS event messages

To subscribe to one of the event messages you will need to compile the required proto files. In general, you need to compile the API proto of the event and the complete shared folder. For example, when you want to subscribe to the ReservationInstanceEvent, you need to compile the *reservation_instance_api.proto* file and everything in the general shared folder.

Alternatively, instead of compiling those files yourself, you can also add copies of those files to your project and include the Protobuf NuGet package. The package will then compile them for you.

When you have the compiled .cs file, you can subscribe to the messages as shown in the following C# code example.

```csharp
private void Run(Engine engine)
{
    // Create the message broker
    var broker = SLMessageBrokerFactorySingleton.Instance.Create();
    // Subscribe to the ReservationInstanceEvent
    var topic = "Skyline.DataMiner.Protobuf.Apps.Srm.ReservationInstance.Api.v1.ReservationInstanceEvent";
    broker.Subscribe(topic).WithHandler(Handler);
}
private void Handler(object sender, HandlerEventArgs e)
{
    // Parse the message
    var message = ReservationInstanceEvent.Parser.ParseFrom(e.Data);
    // Do something with the event message...
}
```

##### Errors

When an SRM event is sent out, in some cases, it cannot be forwarded to NATS because of issues related to the SLMessageBroker. In that case, an error will be logged in the SLResourceManager.txt file, stating that an event could not be forwarded.

Note that no retries will occur and that no messages will be queued.

##### Supported events

- ResourceManagerEventMessage

    When a ResourceManagerEventMessage contains multiple types of objects, it will be split up into multiple proto events. When the ResourceManager sends out one ResourceManagerEvent containing e.g. 2 ReservationInstances and 3 Resources, the forwarder logic will publish one ReservationInstanceEvent (with the 2 objects) and one ResourceEvent (with the 3 objects).

##### ReservationInstance object

| Event message name       | Proto file                         | NATS Topic                                                                          |
|--------------------------|------------------------------------|-------------------------------------------------------------------------------------|
| ReservationInstanceEvent | reservation_instance_api.proto | Skyline.DataMiner.Protobuf.Apps.Srm.ReservationInstance.Api.v1.ReservationInstanceEvent |

##### Resource object

| Event message name | Proto file             | NATS Topic                                                    |
|--------------------|------------------------|---------------------------------------------------------------|
| ResourceEvent      | resource_api.proto | Skyline.DataMiner.Protobuf.Apps.Srm.Resource.Api.v1.ResourceEvent |

#### Profile manager errors with ErrorReason 'ReservationsMustBeReconfigured' now include a ReservationInstanceDetails list \[ID_29914\]

From now on, an error with ErrorReason “ReservationsMustBeReconfigured” will include a ReservationInstanceDetails list containing the ID, the name and the start time of every affected ReservationInstance.

#### Returning all available capacities when requesting the eligible resources \[ID_29939\]

When you request the eligible resources, it is now possible to calculate all remaining capacities on the resources instead of only the requested ones.

To enable this feature, set the CalculateAllCapacities flag of the EligibleResourceContext to true.

Example:

```csharp
public class Script
{
    public void Run(Engine engine)
    {
        // We assume there is a resource named 'resourceWithCapacityTwoCapacities'
        var context = new EligibleResourceContext())
        {
            RequiredCapacities =
            {
                new MultiResourceCapacityUsage(firstCapacityId, 200.0m)
            },
            CalculateAllCapacities = true
        };
        var result = resourceManagerHelper.GetEligibleResources(context);
        var usageDetails = result.UsageDetails.FirstOrDefault(d => d.ResourceId == resourceWithCapacityTwoCapacities.GUID);
        var firstCapacityLeft = usageDetails.CapacityUsageDetails.FirstOrDefault(c => c.CapacityParameterId == firstCapacityId).CapacityLeft;
        // Without the 'CalculateAllCapacities' flag this would not be in the result
        var secondCapacityLeft = usageDetails.CapacityUsageDetails.FirstOrDefault(c => c.CapacityParameterId == secondCapacityId).CapacityLeft;
    }
}
```

#### Availability checks for contributing resources \[ID_30017\] \[ID_30498\]

From now on, the GetEligibleResources and AddOrUpdateReservationInstances calls will determine the availability of a contributing resource during a certain time range based on the following criteria:

- If the contributing booking linked to the resource has Status set to “Canceled”, “Disconnected”, “Interrupted” or “Undefined”, then the resource will be considered unavailable.
- If the contributing booking linked to the resource has Status set to a value other than “Canceled”, “Disconnected”, “Interrupted” or “Undefined”:

  - If the contributing booking linked to the resource has LockLifeCycle set to “Locked”, then the contributing resource will be considered available if the time range of the contributing booking is entire inside the time range.
  - If the contributing booking linked to the resource has LockLifeCycle set to “Locked” and the main booking has a start time in the past but an end time in the future, then the contributing resource will be considered available if the time range of the contributing booking only overlaps the future part of the time range of the main booking.
  - If the contributing booking linked to the resource has LockLifeCycle set to “Unlocked”, then the contributing resource will be considered available if the timing of the contributing booking intersects with the passed time.
  - If the contributing booking linked to the resource has LockLifeCycle set to “Undefined”, then the contributing resource will be considered not available.

Based on those criteria, the GetEligibleResource call will not return any resources that are unavailable.

Adding or updating bookings with resources that are unavailable based on the above-mentioned criteria will cause the complete resource usage to be quarantined. The QuarantineTrigger will have reason ContributingResourceNotAvailable.

If the contributing booking has Status set to “Interrupted”, then the bookings using its linked contributing resources will also have their usages quarantined.

#### More detailed parameter check error messages when generating protocols for virtual functions \[ID_30093\]

When an error occurs during a parameter check while generating a protocol for a virtual function, the error message will now contain more detailed information.

- When a parameter is not of category “Monitoring” or “Configuration”, a CrudFailedException containing a VirtualFunctionDefinitionError with reason InvalidProfileParameterCategory will be thrown.
- When a parameter is of type “discrete” but has no discrete values assigned to it, a CrudFailedException containing a VirtualFunctionDefinitionError with reason InvalidProfileParameterDiscrete will be thrown.

The VirtualFunctionDefinitionError will have the following properties filled in:

- VirtualFunctionDefinitionID: The ID of the VirtualFunctionDefinition.
- ParameterID: The ID of the parameter that cannot be resolved.

#### Profile Manager: Enhanced performance when executing bulk create/update operations against an Elasticsearch database \[ID_30152\]

Because of a number of enhancements to the AddOrUpdateBulk calls of the ProfilesHelper and ProfileManagerHelper, overall performance has increased when creating or updating ProfileParameters, ProfileInstances and ProfileDefinitions in bulk in an Elasticsearch database.

#### Automation - Service & Resource Management: New ServiceResourceUsageDefinition.Role property \[ID_30214\]

A *ServiceResourceUsageDefinition* object now has an extra *Role* property, with the following possible values: *Mapped* (default value), *Unmapped* and *Inheritance*. This property is intended to be used by the Booking Manager app, where it will determine whether a resource is mapped to a node of a service definition.

#### ReservationInstance behavior enhancements \[ID_30295\]

ReservationInstance behavior has been changed in the following ways:

- ReservationInstances that have a start time before the time the ResourceManager was initialized will no longer automatically have their status set to “Interrupted”. Only instances that were unable to start because the ResourceManager was not yet initialized will have their status set to “Interrupted”.
- All ReservationEvents that have not yet run will be scheduled if the ReservationInstance does not have its status set to “Interrupted”. In other words, all missed events will be run immediately when you add a ReservationInstance with a start time.

#### ResourceManagerEventMessage will now be sent when a ReservationInstance property was updated \[ID_30352\] \[ID_30668\]

From now on, a ResourceManagerEventMessage will be sent next to the existing ReservationInstanceChangePropertiesEventMessage when a ReservationInstance property was updated using either ResourceManagerHelper#UpdateProperties or ResourceManagerHelper#SafelyUpdateProperties.

DataMiner Cube has been adapted accordingly.

#### Automation - Service & Resource Management: Option to return time-dependent capabilities when requesting eligible resources \[ID_30576\]

When the eligible resources for a booking are requested, it is now possible to calculate all booked time-dependent capabilities for the eligible resources. For this purpose, the *CalculateAllCapabilities* flag should be set to true on *EligibleResourceContext*. This feature is intended to be used in the DataMiner Booking Manager app.

#### Profile Manager: Server-side user permissions \[ID_30748\]

The public API of the Profile Manager now has the following server-side user permissions.

| Operation                                                                                   | Required user permission                                                                     |
|---------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------|
| Read calls of ProfileParameters, MediationSnippets, ProfileDefinitions and ProfileInstances | ProfileManagerUI                                                                             |
| Create and Update of ProfileParameters, MediationSnippets ProfileDefinitions                | ProfileManagerEditAll                                                                        |
| Delete calls of ProfileParameters, MediationSnippets ProfileDefinitions                     | ProfileManagerDeleteAll                                                                      |
| Create and Update of ProfileInstances                                                       | ProfileManagerEditInstances                                                                  |
| Delete of ProfileInstances                                                                  | ProfileManagerDeleteInstances                                                                |
| Read calls of ServiceProfileInstances and ServiceProfileDefinitions                         | ServiceProfileManagerUI                                                                      |
| Create and Update ServiceProfileInstances                                                   | ServiceProfileManagerEditInstances                                                           |
| Delete of ServiceProfileInstances                                                           | ServiceProfileManagerDeleteInstances                                                         |
| Create and Update of ServiceProfileDefinitions                                              | ServiceProfileManagerEditDefinitions                                                         |
| Delete of ServiceProfileDefinitions                                                         | ServiceProfileManagerDeleteDefinitions                                                       |
| Mediation calls (MediateDeviceToProfile and MediateProfileToDevice)                         | ProfileManagerEditAll, AccessElement and DataDisplayAccess, as well as access to the element |
| Getting the ProfileManagerConfiguration                                                     | ProfileManagerConfiguration                                                                  |
| Setting the ProfileManagerConfiguration                                                     | ProfileManagerConfiguration                                                                  |
| Exporting and importing ServiceProfiles                                                     | ServiceProfileManagerEditInstances and ServiceProfileManagerEditDefinitions                  |
| Exporting and importing Parameters                                                          | ProfileManagerEditAll                                                                        |

The following new permissions will automatically be assigned to existing user groups:

| User permission...                     | will be assigned to...                                           |
|----------------------------------------|------------------------------------------------------------------|
| ProfileManagerDeleteAll                | groups with the ProfileManagerEditAll permission.                |
| ProfileManagerDeleteInstances          | groups with the ProfileManagerEditInstances permission.          |
| ServiceProfileManagerDeleteInstances   | groups with the ProfileManagerEditInstances permission.          |
| ServiceProfileManagerDeleteDefinitions | groups with the ServiceProfileManagerEditDefinitions permission. |
| ProfileManagerConfiguration            | groups with the ProfileManagerEditAll permission.                |

> [!NOTE]
>
> - The AddOrUpdateBulk, RemoveBulk and Create, Read, Update and Delete calls on single objects in the ProfileHelper will throw CrudFailedExceptions if the ThrowExceptionsOnErrorData property is true on the CrudComponent. If not, the TraceData will contain a ManagerStoreError with reason NoPermission.
>
>   The AddOrUpdateBulk and RemoveBulk calls normally never throw exceptions regardless of the ThrowExceptionsOnErrorData property. However, NoPermission is an exception since this makes the entire call fail.
>
> - The calls in the ProfileManagerHelper will always return TraceData (except for the CrudComponent properties on the helper).
> - Import/export of ProfileParameters and mediation messages will throw a DataMinerException.
> - Import/export of the ServiceProfiles will return TraceData. This helper does not have an option to throw exceptions on error data.

#### Resource Manager: Permission checks \[ID_30895\]

The following messages now have server-side permission checks:

| Operation | Required flags | Helper calls |
|--|--|--|
| Read calls of Resources and ResourcePools | ResManResourceUI | GetResources<br> GetEligibleResources<br> GetResourceUsage<br> GetAvailableResources<br> GetResourcePools |
| Adding Resources or ResourcePools | ResManResourceAdd | AddOrUpdateResources<br> AddOrUpdateResourcePools |
| Updating the status of a Resource | ResManResourceEditStatus | AddOrUpdateResources |
| Updating a Resource (unless only the status is updated) or updating a ResourcePool | ResManResourceEditOther | AddOrUpdateResources<br> AddOrUpdateResourcePools |
| Removing a Resource or ResourcePool | ResManResourceDelete | RemoveResources<br> RemoveResourcePools |
| Read calls of ReservationInstances and ReservationDefinitions | ResManReservationUITimeline | GetReservationInstances<br> GetReservationDefinitions |
| Adding ReservationInstances or ReservationDefinitions | ResManReservationAdd | AddOrUpdateReservation<br>Instances<br> AddOrUpdateReservation<br>Definitions |
| Editing ReservationInstances or ReservationDefinitions | ResManReservationEdit | AddOrUpdateReservation<br>Instances<br> AddOrUpdateReservation<br>Definitions<br> (Safely)UpdateReservation<br>InstanceProperties<br> (Safely)UpdateReservation<br>DefinitionProperties |
| Removing ReservationInstances or ReservationDefinitions | ResManReservationDelete | RemoveReservationInstances<br> RemoveReservationDefinitions |

All operations will now return a ResourceManagerErrorData with reason NotAllowed if the user does not have the correct permissions.

#### RemoveResources: New ignoreCanceledReservations flag \[ID_30936\]

When resources are deleted by means of a RemoveResources call, it is now possible to indicate whether errors should be generated when a resource is being used in canceled reservations.

If you set the ignoreCanceledReservations flag to true, no errors will be generated when deleting a resource that is being used in canceled reservations.

```txt
Resource[] RemoveResources(Resource[] resources, bool ignorePassedReservations, bool ignoreCanceledReservations)
```

### DMS Mobile Gateway

#### Getting and setting the value of a table column parameter \[ID_30399\]

It is now possible to get and set values of table column parameters using text messages.

Syntax:

- GET:\<ElementName>:\<ParameterName>\|\<TableIndex>
- SET:\<ElementName>:\<ParameterName>\|\<TableIndex>:\<Value>

Examples:

- Use “GET:MyElement:MyParam\|10113” to get the value stored in row 10113 of parameter “MyParam” of element “MyElement”.
- Use “SET:MyElement:MyParam\|10113:100” to set the value stored in row 10113 of parameter “MyParam” of element “MyElement” to 100.

Using special characters:

- If an argument contains a colon (“:”), a backslash character (“\\”) must be put in front of it. For example, the command “SET:MyElement:MyParam\|a\\:b:100” will set the value stored in row a:b to 100.
- If the table index contains a pipe character (“\|”), a backslash character (“\\”) must be put in front of it. For example, the command “SET:MyElement:MyParam\|a\\:b\\\|c:100” will set the value stored in row a:b\|c to value 100.

> [!WARNING]
> BREAKING CHANGE: Due to the introduction of this new syntax, it is no longer possible to get and set single-value parameters of which the name contains pipe characters.

### DMS tools

#### Standalone Elasticsearch Cluster Installer will no longer automatically configure TLS and security \[ID_29113\]

From now on, the Standalone Elasticsearch Cluster Installer tool will no longer automatically configure TLS and security.

For instructions on how to install this manually, see [Securing the Elasticsearch database](xref:Security_Elasticsearch).

#### Standalone Cassandra Backup Tool \[ID_29005\] \[ID_30234\]

The StandaloneCassandraBackup.exe tool can be used by an administrator to take a backup of a Cassandra database (either a single node or a cluster).

From DataMiner 10.1.8 onwards, this tool will be available on each DMA server in the folder *C:\\Skyline DataMiner\\Tools*. As it only affects Cassandra files, it can be used on any DataMiner system regardless of version.

For more information on this tool, see [Standalone Cassandra Backup Tool](xref:Standalone_Cassandra_Backup_Tool).

#### New tool to transform a DMS with separate databases into a DMS with a shared Cassandra/Elasticsearch cluster \[ID_31005\] \[ID_31280\] \[ID_31421\] \[ID_31423\] \[ID_31424\] \[ID_31505\] \[ID_31788\]

Using *SLCCMigrator.exe*, you can now transform a DataMiner System consisting of Agents with separate databases into a DataMiner System consisting of Agents that are all connected to a shared Cassandra/Elasticsearch cluster.

For more information on this tool, see [Cassandra Cluster Migrator](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster).

#### SLReset: Hostname can now be passed as an argument \[ID_32002\]

When running SLReset.exe, which can be used to fully reset a DataMiner Agent to its state immediately after installation, it is now possible to pass the hostname in a -ho argument, especially when resetting a DataMiner Agent that only allows you to connect via HTTPS.

```txt
SLReset.exe -ho hostname
```
