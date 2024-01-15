---
uid: General_Main_Release_10.4.0_changes
---

# General Main Release 10.4.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### SLXML no longer used to read out element data [ID_33515] [ID_33616] [ID_33625] [ID_33659]

<!-- MR 10.4.0 - FR 10.3.4 -->

From now on, SLXML will no longer be used to read out the following files containing element data:

- *Element.xml* files
- *ElementData.xml* files
- *EPMConfig.xml* files
- *Description.xml* files
- *Ports.xml* files

> [!IMPORTANT]
> This is a breaking change. Make sure that none of the protocols in your system is using the following deprecated Notify types:
>
> - DMS_GET_INFO
> - DMS_GET_INFO_ALL
> - NT_ADD_DESCRIPTION_FILE
> - NT_GET_ITEM_DATA
> - NT_GET_PARAMETER_BY_DATA
> - NT_GET_XML_COOKIE
> - NT_RELOAD_ELEMENT
> - NT_SET_ITEM_DATA
> - NT_SET_PARAMETER_BY_DATA

#### More detailed logging when the certificate chain is invalid while connecting to Cassandra [ID_34822]

<!-- MR 10.4.0 - FR 10.3.2 -->

More detailed information will now be added to the `SLDBConnection.txt` log file when the certificate chain is invalid while connecting to Cassandra.

Log entry syntax: `Certificate chain error: {chainStatus.Status}, details: {chainStatus.StatusInformation}`

#### SLLogCollector now collects more API Gateway data [ID_34967]

<!-- MR 10.4.0 - FR 10.3.8 -->

SLLogCollector packages now include the following API Gateway data:

- *appsettings.json*
- DLL version
- Health
- Log file
- Version

#### SLAnalytics - Proactive cap detection: Enhanced accuracy when generating alarm predictions [ID_35080]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall accuracy has increased when generating alarm predictions.

#### DataMiner Object Models: DomInstanceButtonDefinitions can only reference a single action [ID_35156]

<!-- MR 10.4.0 - FR 10.3.2 -->

From now on, DomInstanceButtonDefinitions can only reference a single action. If multiple actions are defined, a `DomBehaviorDefinitionError` with reason `InvalidButtonActionCombination` will be returned.

Also, when using the DomBehaviorDefinition inheritance system, the server-side logic will now make sure that there are no buttons or actions with identical IDs on both the parent and child definition.

- If a duplicate action is found, a `DomBehaviorDefinitionError` with reason `DuplicateActionDefinitionIds` will be returned.
- If a duplicate button is found, a `DomBehaviorDefinitionError` with reason `DuplicateButtonDefinitionIds` will be returned.

#### SLLogCollector: Custom CollectorConfig XML files will now be synchronized across the DataMiner cluster [ID_35180]

<!-- MR 10.4.0 - FR 10.3.2 -->

From now on, all custom CollectorConfig XML files will be synchronized across the DataMiner cluster.

#### SLAnalytics - Pattern matching: Manually created tags will now be saved as pattern occurrences [ID_35299]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when you define a tag for pattern matching, the pattern you selected will be saved as a pattern occurrence in the Elasticsearch database and highlighted in bright orange, similar to so-called "streaming matches", which are detected while tracking for trend patterns whenever a trended parameter is updated.

#### SLDataGateway: Memory enhancements with regard to average trending [ID_35312]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the SLDataGateway process, a number of memory enhancements have been made with regard to the management of average trend data.

#### Maps: Markers will now move more gradual when zooming [ID_35337]

<!-- MR 10.4.0 - FR 10.3.3 -->

Because of a number of enhancements, markers will now move more gradual when zooming.

#### Alarm templates - Smart baseline calculations: NullReferenceException prevented & enhanced exception logging [ID_35348]

<!-- MR 10.4.0 - FR 10.3.3 -->

In some cases, a `Baseline Calculation Failed: System.NullReferenceException: Object reference not set to an instance of an object` error would be added to the *SLSmartBaselineManager.txt* log file. The issue causing that error has now been fixed.

Also, log entries indicating an exception thrown during baseline calculations will now include details regarding the element and parameter associated with the exception.

#### Maps: Enhanced zooming behavior [ID_35351]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when you zoom in or out, the data of the previous zoom level will stay visible until the data of the current zoom level has been loaded.

#### SLAnalytics - Automatic incident tracking: Enhanced performance when fetching relation information [ID_35414] [ID_35508]

<!-- 35414:  MR 10.4.0 - FR 10.3.3 -->
<!-- 35508:  MR 10.4.0 - FR 10.3.4 -->

Because of a number of enhancements, overall performance has increased when fetching relation information for the automatic incident tracking feature.

#### Security enhancements [ID_35434] [ID_35997] [ID_36319] [ID_36624] [ID_36928] [ID_37345] [ID_37540]

<!-- 35434: MR 10.4.0 - FR 10.3.4 -->
<!-- 35997: MR 10.4.0 - FR 10.3.5 -->
<!-- 36319/36928: MR 10.4.0 - FR 10.3.9 -->
<!-- 36624: MR 10.4.0 - FR 10.3.8 -->
<!-- 37345: MR 10.4.0 - FR 10.3.11 -->
<!-- 37540: MR 10.4.0 - FR 10.3.12 -->

A number of security enhancements have been made.

#### SLAnalytics - Behavioral anomaly detection: No longer available for discrete parameters [ID_35465]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, anomaly detection will no longer be available for discrete parameters.

#### SLAnalytics - Pattern matching: Enhanced performance when detecting large patterns [ID_35474]

<!-- MR 10.4.0 - FR 10.3.4 -->

Because of a number of enhancements, overall performance has increased when detecting trend patterns that cover more than 30,000 data points.

#### SLNetClientTest: New DOM-related features [ID_35550]

<!-- MR 10.4.0 - FR 10.3.5 -->

In the *SLNetClientTest* tool, the following new DOM-related features have been made available:

- Viewing a JSON representation of a selected ModuleSettings configuration.

- Completely remove a DOM Manager from the system.

  > [!NOTE]
  >
  > - When you instruct the *SLNetClientTest* tool to delete a DOM Manager, it will count the number of DOM instances. If the DOM Manager in question contains more than 10,000 DOM instances, an error message will appear, saying that deleting the DOM Manager would take too long.
  > - When you instruct the *SLNetClientTest* tool to delete a DOM Manager, it will not remove the indices from the Elasticsearch database. These indices have to be deleted manually. If you do not delete them manually, we recommend to not re-use the module ID as this could cause configuration conflicts.

> [!CAUTION]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### SLAnalytics - Proactive cap detection: Enhanced accuracy [ID_35695]

<!-- MR 10.4.0 - FR 10.3.4 -->

Proactive cap detection predicts future issues based on trend data in the Cassandra database. Because of a number of enhancements, overall prediction accuracy has increased.

#### Service & Resource Management: Bookings of type 'Custom Process Automation' no longer consume license credits [ID_35742]

<!-- MR 10.4.0 - FR 10.3.4 -->

From now on, ReservationInstances of type *Custom Process Automation* will no longer consume SRM credits. This means that, from now on, you can schedule an unlimited number of concurrent bookings of type *Custom Process Automation*.

#### SLAnalytics: A message will be added to the SLAnalytics.txt log file when no Cassandra database is present [ID_35748]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, SLAnalytics would stop working without giving any notice whatsoever when it was started on a system without a Cassandra database.

From now on, when no Cassandra database is present, SLAnalytics will be stopped gracefully and a message will be added to the *SLAnalytics.txt* log file.

#### SLNetClientTest: More user-friendly pop-up window will now appear when connecting to a DMA that uses external authentication via SAML [ID_35755]

<!-- MR 10.4.0 - FR 10.3.5 -->

When, in the SLNetClientTest tool, you connected to a DataMiner Agent that used external authentication via SAML, up to now, a pop-up window showing the authentication URL would prompt you to enter the SAML response string. From now on, a pop-up window similar to the one used in Cube will appear instead.

> [!CAUTION]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Service & Resource Management: Enhanced performance when loading service profile instances [ID_35878]

<!-- MR 10.4.0 - FR 10.3.7 -->

Because of a number of enhancements, overall performance has increased when loading service profile instances.

#### SLAnalytics - Behavioral anomaly detection: Events associated with a DVE child element will no longer be linked to the DVE parent element [ID_35901]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, when an event associated with a DVE child element was generated, internally, that event would be linked to the DVE parent element. From now on, it will be linked to the child element instead.

#### Service & Resource Management: Enhanced performance when stopping an ongoing booking [ID_36255]

<!-- MR 10.4.0 - FR 10.3.6 -->

Because of a number of enhancements, overall performance has increased when stopping an ongoing booking.

#### SLAnalytics - Pattern matching: No automatic pattern matching anymore after creating or editing a pattern [ID_36265]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, when a trend pattern was created or edited, the system would automatically start searching for that new or updated pattern. Now, this will no longer happen. Pattern matching will only be done after explicitly sending a `getPatternMatchMessage`.

#### SLAnalytics - Automatic incident tracking: Relations based on alarm data will now also be taken into account [ID_36337]

<!-- MR 10.4.0 - FR 10.3.7 -->

Up to now, alarm grouping based on parameter relationship data would only take into account relations based on change points. From now on, relations based on alarm data will also be taken into account.

On systems running alarm grouping based on both parameter and alarm relationship data, the `C:\Skyline DataMiner\analytics\configuration.xml` will contain an `<item>` tag like the following. Note that `cpRelationThreshold` has been renamed to `relationThreshold` and that its value is set to 0.7 by default.

Example:

```xml
<Value type="skyline::dataminer::analytics::workers::configuration::RelationVisitorConfiguration">
   <enable>true</enable>
   <relationThreshold>0.7</relationThreshold>
</Value>
```

> [!CAUTION]
> Always be extremely careful when changing any of the settings configured in `C:\Skyline DataMiner\analytics\configuration.xml`, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Service & Resource Management: Enhanced performance when creating and updating bookings [ID_36391]

<!-- MR 10.4.0 - FR 10.3.8 -->

Because of a number of enhancements, overall performance has increased when creating and updating bookings, especially on systems with a large number of overlapping bookings.

#### SLAnalytics: Overall accuracy of the proactive cap detection function has increased [ID_36476]

<!-- MR 10.4.0 - FR 10.3.8 -->

Because of a number of enhancements, overall accuracy of the proactive cap detection function has increased.

#### Enhancements in order to deal with situations where HTTP traffic is modified [ID_36540]

<!-- MR 10.4.0 - FR 10.3.8 -->

A number of enhancements have been made in order to deal with situations where proxy servers, gateways, routers or firewalls modify HTTP traffic.

#### Cassandra Cleaner can now also be used to clean the 'infotrace' table [ID_36592]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, the *Cassandra Cleaner* tool could only be used to remove data from the *timetrace* table. From now on, it can also be used to remove data from the *infotrace* table.

1. In the *db.yaml* file, set `table.name` to "infotrace".

   By default, `table.name` is set to "timetrace".

1. Specify a time range by setting the `delete.start.time` and `delete.end.time` fields.

  > [!CAUTION]
  > All infotrace data between the `delete.start.time` and `delete.end.time` timestamps will be deleted, so be careful.

1. Run the following command: `clean -l`

   > [!NOTE]
   > The *infotrace* table can only be cleaned using the `clean -l` command.

For more information, see [Cassandra Cleaner](xref:Cassandra_Cleaner).

#### SLAnalytics - Automatic incident tracking: Alarms will no longer be regrouped after a manual operation [ID_36595]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, manually removing an alarm from an incident could result in that alarm being regrouped with another existing or newly created incident. Also when you manually cleared an incident could all base alarms of that incident be regrouped.

From now on, alarms will no longer be regrouped after a manual operation.

#### SLAnalytics - Automatic incident tracking: Automatic incidents can now also be cleared manually [ID_36600]

<!-- MR 10.4.0 - FR 10.3.8 -->

From now on, users will be allowed to manually clear automatic incidents.

#### SLAnalytics - Behavioral anomaly detection & Proactive cap detection: Enhanced caching mechanism [ID_36639]

<!-- MR 10.4.0 - FR 10.3.8 -->

A number of enhancements have been made to the caching mechanism used by the *Behavioral anomaly detection* and *Proactive cap detection* features.

#### SLProtocol is now a 64-bit process by default [ID_36725]

<!-- MR 10.4.0 - FR 10.3.9 -->

SLProtocol is now a 64-bit process by default.

However, if necessary, it can still be run as a 32-bit process. For more information, see [Activating SLProtocol as a 32-bit process](xref:Activating_SLProtocol_as_a_32_Bit_Process).

#### Service & Resource Management: A series of checks will now be performed when you add or upload a functions file [ID_36732]

<!-- MR 10.4.0 - FR 10.3.10 -->

When a functions file is added or uploaded, the following checks will now be performed:

1. Can the content of the file (in XML format) be parsed?
1. Does the file contain the name of the protocol?
1. Does the protocol name in the file correspond to the protocol name in the request?
1. Does the file contain a version number?
1. Does the DataMiner System not contain a functions file with the same version for the protocol in question?

When you try to upload a functions file using DataMiner Cube, the log entry (in Cube logging) and the information event (in the Alarm Console) created when the upload fails will indicate the checks that did not return true.

#### DataMiner Object Models: DomInstanceHistory will now be saved asynchronously [ID_36785]

<!-- MR 10.4.0 - FR 10.3.9 -->

When a DomInstance is created or updated, a HistoryChange record is stored in the database, and when a DomInstance is deleted, all HistoryChange objects associated with that DomInstance are deleted from the database. Up to now, those HistoryChange records were always created, updated and deleted synchronously.

From now on, all DOM managers will create, update and delete their HistoryChange records asynchronously, which will considerably enhance overall performance when creating, updating or deleting DomInstances.

Using the new `DomInstanceHistoryStorageBehavior` enum on the new `DomInstanceHistorySettings` class, you can configure whether HistoryChange records will be stored and how they will be stored. See the following example:

```csharp
​ModuleSettings.DomManagerSettings.DomInstanceHistorySettings.StorageBehavior = DomInstanceHistoryStorageBehavior.Disabled;
```

The `DomInstanceHistoryStorageBehavior` can be set to one of three values:

- **EnabledAsync** (default value): The HistoryChange records will be created, updated and deleted asynchronously.

- **EnabledSync**: The HistoryChange records will be created and deleted synchronously.

- **Disabled**: No HistoryChange records will be created, updated or deleted.

  > [!NOTE]
  > If you set the value to "Disabled" after it had been set to one of the other options, the existing HistoryChange records in the database will be left untouched, even if the corresponding DomInstance is deleted.

> [!NOTE]
> When you delete a DomInstance with a large number of associated HistoryChange records, deleting all those HistoryChange records can take a long time, even when this is done asynchronously. Therefore, we recommend disabling the creation of HistoryChange records if you do not need them.

#### Service & Resource Management: Enhanced performance when adding or updating ReservationInstances [ID_36788]

<!-- MR 10.4.0 - FR 10.3.9 -->

Because of a number of enhancements, overall performance has increased when adding or updating ReservationInstances, especially on systems with a large number of overlapping bookings and a large number of bookings using the same resources.

#### SLAnalytics - Automatic incident tracking: Root time of an alarm group will be set to the most recent of the base alarm root times [ID_36809]

<!-- MR 10.4.0 - FR 10.3.9 -->

From now on, the root time of an alarm group (i.e. the time of arrival of the first alarm in the alarm group tree) will be set to the most recent of the base alarm root times.

Up to now, when alarm groups were recreated after a DataMiner upgrade, their time of arrival and root time was set to the time of the upgrade.

#### DataMiner upgrade: Microsoft .NET 5 will no longer be installed by default [ID_36815]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, Microsoft .NET 5 would always be installed during a DataMiner upgrade. As all DataMiner components using .NET 5 have been upgraded to use .NET 6 instead, .NET 5 will no longer be installed by default.

> [!NOTE]
> If Microsoft .NET 5 is present, it will not be automatically uninstalled during a DataMiner upgrade.  

#### Elasticsearch/OpenSearch: Unused suggest indices have been disabled [ID_36875]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, each time a new DOM manager was initialized, SLDataGateway would create a main data index and a suggest index in the Elasticsearch database for each DOM type. As these suggest indices are not used, they have now been disabled. As a result, overall performance will increase when initializing new DOM managers.

Other unused suggest indices have been disabled as well. This will have a positive impact on the hardware resources required for Elasticsearch or OpenSearch.

The following suggest indices have been disabled:

- ApiDefinition
- ApiToken
- AutoIncrementer
- DomBehaviorDefinition
- DomDefinition
- DomInstance
- DomTemplate
- HistoryChange
- JobDomain
- JobTemplate
- MediationSnippet
- ModuleSettings
- PaProcess
- Parameter
- PaToken
- ProfileDefinition
- ProfileInstance
- Record
- RecordDefinition
- ReservationDefinition
- ReservationInstance
- Resource
- ResourcePool
- SectionDefinition
- ServiceDefinition
- ServiceDeletionHistory
- ServiceProfileDefinition
- ServiceProfileInstance
- SRMServiceInfo
- SRMSettableServiceState
- Ticket
- TicketFieldResolver
- TicketHistory
- VirtualFunctionDefinition
- VirtualFunctionProtocolMeta

> [!NOTE]
> Existing suggest indices will not automatically be removed from the database. You can remove them manually if necessary.

#### SLNetClientTest: Enhancements made to 'DataMiner Object Model' window [ID_36891]

<!-- MR 10.4.0 - FR 10.3.9 -->

A number of enhancements have been made to the *DataMiner Object Model* window.

- The *DataMiner Object Model* window will now only subscribe to the events of the DOM manager you selected in the *ModuleSettings* window. Up to now, it would subscribe to all events of all DOM managers.

- The *DomInstances* and *History* pages will initially only load up to 500 objects. A warning message at the top of the window will indicate that only a limited list was loaded, and that you will need to click *Refresh* to load all items.

- The objects listed on the *DomInstances* and *History* pages will now be sorted by the data that was last modified (descending), allowing you to quickly see the recently updated objects.

- On the *History* page, the GUID of the DomInstance will no longer have a "DomInstanceId" prefix.

- The *Attachments* page will no longer load all DomInstances at startup. If you want all DomInstances to be loaded, you will need to click *Load all DOM instances*.

- On the *SectionDefinitions* page, the IDs of the section definitions will now be shown in the first column.

- When you click *View* after selecting a section definition, the text will no longer include a *Validators* line if no validators could be found.

- When no name is assigned to a *DomBehaviorDefinition* or a *DomDefinition*, the text "(no name)" will appear to indicate that no name was assigned.

- If, on any of the pages, you want to select an item in a table, you can now click the item anywhere. Up to now, you had to click the cell in the first column.

> [!CAUTION]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Service & Resource Management: Improved ResourceManager logging [ID_36989]

<!-- MR 10.4.0 - FR 10.3.10 -->

The ResourceManager logging (*SLResourceManager.txt*) has been improved to make debugging easier.

Some log entries have been rewritten to make them clearer, have been assigned another log level or have been removed entirely.

#### DataMiner Object Models: Bulk deletion of history records when deleting a DOM instance [ID_37012]

<!-- MR 10.4.0 - FR 10.3.10 -->

Up to now, when a DOM instance was deleted, the associated HistoryChange records were removed one by one. From now on, when a DOM instance is deleted, its HistoryChange records will be deleted in bulk. This will greatly improve overall performance when deleting DOM instances, especially when they are deleted synchronously.

#### DataMiner.xml: objectId attribute of AzureAD element will now be considered optional [ID_37162]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, a run-time error would be thrown when the `<AzureAD>` element in the *DataMiner.xml* file did not contain an `objectId` attribute.

This `objectId` attribute will now be considered optional. Hence, no run-time error will be thrown anymore when it has not been specified.

#### SLAnalytics: Enhanced performance when using automatic incident tracking based on properties [ID_37198]

<!-- MR 10.4.0 - FR 10.3.10 -->

Because of a number of enhancements, overall performance has increased when using automatic incident tracking based on service, view or element properties.

> [!IMPORTANT]
> For the properties that should be taken into account, the option *Update alarms on value changed* must be selected. For more information, see [Configuration of incident tracking based on properties](xref:Automatic_incident_tracking#configuration-of-incident-tracking-based-on-properties).

#### SLLogCollector now collects information regarding the IIS configuration [ID_37273]

<!-- MR 10.4.0 - FR 10.3.11 -->

SLLogCollector packages now include information regarding the IIS configuration:

| Folder              | Information                                           |
|---------------------|-------------------------------------------------------|
| IIS                 | The IIS configuration                                 |
| Network Information | Information regarding the SSL certificate on port 443 |
| SSL Cert            | The SSL certificate for port 443                      |

#### Improved alarm grouping for DVE child elements [ID_37275]

<!-- MR 10.4.0 - FR 10.3.11 -->

Alarm grouping for DVE child elements has been improved. As change points are generated on DVE parent elements, previously these were not taken into account for the grouping of alarms for the DVE child elements. Now the change points of the DVE parent element will be taken into account for the DVE child elements as well.

However, note that cases where a main DVE element exports the same parameter to multiple DVE child elements are not supported for this.

#### SLAnalytics - Proactive cap detection: Enhanced verification of forecasted alarms [ID_37368]

<!-- MR 10.4.0 - FR 10.3.12 -->

A number of enhancements have been made with regard to the verification of forecasted alarms generated by the proactive cap detection feature.

#### SLNetClientTest: New 'Debug SAML' checkbox [ID_37370]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, in the SLNetClientTest tool, you select the new *Debug SAML* checkbox before connecting to a DataMiner Agent that used external authentication via SAML, two additional pop-up windows will now appear, displaying the SAML requests and SAML responses respectively.

> [!CAUTION]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### DataMiner Object Models: Enhanced checks when removing field descriptors from a section definition [ID_37395]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, when a field descriptor was removed from a section definition that was being used by any DOM instances, the update of the section would fail and a `SectionDefinitionError` with reason `SectionDefinitionInUseByDomInstances` would be added to the trace data.

To allow certain field descriptors to be removed, this behavior has now been changed. From now on, the update of a section will only fail if the removed field descriptors are still being used.

A `SectionDefinitionError` with reason `SectionDefinitionFieldsInUse` will be added to the trace data in the following cases:

- If any of the removed field descriptors is being used in the DOM manager settings of the DOM module (either in the name definition or in one of the field aliases). When a field descriptor is detected in those settings, `UsedInDomManagerSettings` will be set to true in the `SectionDefinitionError`.

- If any of the removed field descriptors is being used in the name definition defined on a DOM definition. The IDs of those DOM definitions will be specified in `DomDefinitionIds` of the `SectionDefinitionError`.

- If any of the removed field descriptors is being used in any of the status section definition links on a DOM behavior definition. The IDs of the DOM behavior definitions will be specified in `DomBehaviorDefinitionIds` of the `SectionDefinitionError`.

- If any of the removed field descriptors is assigned a value in any DOM instance. The IDs of the DOM instances (limited to 100) will be specified in `DomInstanceIds` of the `SectionDefinitionError`. If a large number of field descriptors were removed, only the first 100 field descriptors that match will be taken into account.

Also, the `SectionDefinitionError` will have `SectionDefinitionID` set to the ID of the SectionDefinition that could not be updated. `FieldDescriptorIds` will contain the IDs of the FieldDescriptors that were found to be in use.

Other changes to a section definition that fail when the section is being used by any DOM instance will still fail with reason `SectionDefinitionInUseByDomInstances`. Up to now, all DOM instance IDs would be included in the error data. From now on, only the first 100 IDs will be included.

> [!NOTE]
> Currently, on systems using STaaS, the validation of DOM instances might not detect if a field descriptor is in use when there are more then 100 DOM instances. In that case, the removal of the field descriptor in question will be allowed.

#### SLAnalytics - Trend predictions: Flatline periods will no longer be included in the prediction model training data [ID_37432]

<!-- MR 10.4.0 - FR 10.3.12 -->

When a parameter has anomalous flatline periods in its trend data history that are breaking the normal trend data patterns, from now on, those flatline periods will no longer be included into the training data of the prediction model. As a result, a more accurate prediction can be expected on this kind of behavior.

#### Configuration of database offload functionality moved from DBConfiguration.xml to DB.xml [ID_37446]

<!-- MR 10.4.0 - FR 10.4.2 -->

Up to now, the database offload functionality described below had to be configured in the *DBConfiguration.xml* file. From now on, it has to be configured in the *DB.xml* file instead.

- **Configuring a size limit for file offloads**

  When the main database is offline, file offloads are used to store write/delete operations. You can configure a limit for the file size of these offloads. When the limit is reached, new data will be dropped.

  Example:

  ```xml
  <DataBases>
    ...
    <FileOffloadConfiguration>
      <MaxSizeMB>20</MaxSizeMB>
    </FileOffloadConfiguration>
  </DataBases>
  ```

- **Configuring multiple OpenSearch or Elasticsearch clusters**

  It is possible to have data offloaded to multiple OpenSearch or Elasticsearch clusters, i.e. one main cluster and several replicated clusters.

  Example:

  ```xml
  <DataBases>
    <!-- Reads will be handled by the ElasticCluster with the lowest priorityOrder -->
    <DataBase active="true" search="true" ID="0" priorityOrder="0" type="ElasticSearch">
      <DBServer>localhost</DBServer>
      <UID />
      <PWD>root</PWD>
      <DB>dms</DB>
      <FileOffloadIdentifier>cluster1</FileOffloadIdentifier>
    </DataBase>
    <DataBase active="true" search="true" ID="0" priorityOrder="1" type="ElasticSearch">
      <DBServer>10.11.1.44,10.11.2.44,10.11.3.44</DBServer>
      <UID />
      <PWD>root</PWD>
      <DB>dms</DB>
      <FileOffloadIdentifier>cluster2</FileOffloadIdentifier>
    </DataBase>
  </DataBases>
  ```

#### SLAnalytics: Not all occurrences of multivariate patterns containing subpatterns hosted on different DMAs would be detected [ID_37451]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, when you had created a multivariate pattern containing subpatterns hosted on different DMAs, in some cases, not all occurrences would get detected internally. From now on, all occurrences of multivariate patterns containing subpatterns hosted on different DMAs will be correctly detected.

#### Storage as a Service: DataMiner Agent will now communicate with the database via port 443 only [ID_37480]

<!-- MR 10.4.0 - FR 10.3.11 [CU0] -->

Up to now, a DataMiner using STaaS communicated with the database via TCP/IP ports 443, 5671 and 5672. From now on, it will communicate with the database via port 443 only.

#### DataMiner Object Models: Generic enum field descriptors now allow you to select multiple values [ID_37482]

<!-- MR 10.4.0 - FR 10.4.1 -->

A generic enum field descriptor now allows you to select multiple values.

For a *GenericEnumFieldDescriptor* to allow multiple values, its field type should be set as follows:

- For integer values: `FieldType = typeof(List<GenericEnum<int>>)`
- For string values: `FieldType = typeof(List<GenericEnum<string>>)`

Values need to be set as follows:

- Integer values:

  ```csharp
  new ListValueWrapper<int>(new List<int>(){0, 1});
  ```

- String values:

  ```csharp
  new ListValueWrapper<string>(new List<string>(){ "Value 0", "Value 1" });
  ```

#### Storage as a Service: Enhanced performance of DOM and SRM queries [ID_37495]

<!-- MR 10.4.0 - FR 10.3.12 -->

Because of a number of enhancements, overall performance of DOM and SRM queries has increased.

#### GQI: Enhanced error handling when an error occurs while executing a query before it is joined with another query [ID_37521]

<!-- MR 10.4.0 - FR 10.4.1 -->

Up to now, when an error occurred during the execution of a GQI query that, later on, was joined with another query, the exception message would always read `One or more errors occurred`.

From now on, an exception that occurs when executing a query before it is joined with another query will be re-thrown afterwards. This will make sure the exception reveals the actual reason why the query failed.

#### SLAnalytics - Automatic incident tracking: Enhanced error handling [ID_37530]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, when the table index of an alarm update had a casing that was not identical to that of previous alarm events in the same alarm tree, SLAnalytics would log errors similar to the following ones:

`Updating alarm in tree X/X , but old alarm could not be found in the loose alarms or in the groups`

`Alarm X/X was in state but neither in loose alarms, in an automatic group or in a manual group`

Because of a number of enhancements made to the automatic incident tracking feature, SLAnalytics will no longer throw errors like the ones above.

#### DataMiner Object Models: GQI sort operations will now be executed by the database [ID_37541]

<!-- MR 10.4.0 - FR 10.3.12 -->

Previously, when you added a sort node to a GQI query against the DOM data source, all DOM instances matching any filter node needed to be retrieved before the sorting could occur. Sorting a data set with a large amount of DOM instances was practically impossible.

From now on, the sort nodes (e.g. By X, Then By Y, etc.) will be forwarded to the database. This will considerably increase overall performance when sorting DOM instances, especially when the data set includes a large amount of items.

> [!NOTE]
>
> - Fields that have multiple values (i.e. list fields) cannot be sorted.
> - All string sorting occurs in a non-natural way.
> - TimeSpan fields are evaluated as strings. As a result, similar to strings, they will also be ordered in a non-natural way.
> - Multiple sorts are supported using the `Sort by, Then sort by, etc.` node concatenation. If a new *Sort by* node is added to the query, the previous will be ignored.
> - When sorting by DOM status or by an enum field, the sorting is will occur on the underlying value stored in the DOM instance and not on the display value.
> - When the DOM GQI query is combined in a join operation, any sort node added after the join node will not be forwarded to the database. This will also be the case when the sorting uses the header of the table and the DOM query is part of a join.

#### Storage as a Service: Enhanced error handling [ID_37554]

<!-- MR 10.4.0 - FR 10.3.12 -->

A number of enhancements have been made with regard to error handling.

#### New downgrade action that adapts the SLAnalytics configuration file when downgrading to version 10.3.0 or older [ID_37582]

<!-- MR 10.4.0 - FR 10.3.12 -->

When you downgrade a DataMiner Agent from version 10.3.1 or later to version 10.3.0 or older, a downgrade action will now remove the section related to relation grouping from the SLAnalytics configuration file.

#### SLAnalytics: Enhanced error handling [ID_37607]

<!-- MR 10.4.0 - FR 10.3.12 -->

Because of a number of enhancements with regard to error handling, the following error message will no longer be generated when the SLAnalytics process is restarted on one of the DataMiner Agents in the DataMiner System:

`Unexpected number of responses returned on GetInfoMessage...`

#### ManagerStore: Exceptions thrown during actions of high importance will now be logged as errors [ID_37631]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, when managers under the control of the ManagerStore framework in SLNet (DOM, Profiles, User-Defined APIs) threw exceptions during a de-initialization, a failover switch or a midnight synchronization, those exceptions would be logged as level-5 log entries of type *Info*. From now on, they will be logged as level-0 log entries of type *Error*.

#### Storage as a Service: Enhanced performance when restarting elements or performing certain DOM and SRM operations [ID_37638]

<!-- MR 10.4.0 - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased, especially when restarting elements or performing certain DOM and SRM operations.

#### DataMiner Objects Models: Fields used in multiple sections will no longer be returned for GQI queries [ID_37644]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, a GQI query starting from a DOM node would return columns that contained multiple values due to being linked to SectionDefinitions that allowed multiple sections in one DOM instance. However, when displayed in a table, those columns would only show the first value found in the DOM instance. Also, when you sorted the data by one of those columns, in some cases, the order would seem random as the database would pick either the lowest or highest value available for a field when sorting.

From now on, when GQI detects that having multiple sections is allowed for a particular SectionDefinition, all fields part of that SectionDefinition will no longer be returned as columns.

> [!IMPORTANT]
> This change will break any existing query that references columns containing multiple values due to being linked to SectionDefinitions that allowed multiple sections in one DOM instance.

#### Service & Resource Management: ProfileManager cache [ID_37735]

<!-- MR 10.4.0 - FR 10.4.1 -->

When profile data is stored in an Elasticsearch/OpenSearch database, all ProfileDefinitions and ProfileParameters in the ProfileManager will now be cached on each of the DMAs in the DataMiner System. During the midnight synchronization, all these caches will be reloaded to ensure that they all remain in sync.

Also, additional logging has been added to indicate when a cache was refilled and how many objects were added, updated, removed or ignored. Each log entry will also include the IDs of the first ten of these objects.

#### Storage as a Service: Enhanced performance when migrating data from Cassandra to the cloud [ID_37740]

<!-- MR 10.4.0 - FR 10.3.12 [CU0] -->

Because of a number of enhancements, overall performance has increased when migrating data from a Cassandra database to the cloud.

#### User-Defined APIs: Maximum size of HTTP request body has been reduced to 29MB [ID_37753]

<!-- MR 10.4.0 - FR 10.4.1 -->

The maximum size of the HTTP request body has been reduced from 30 MB to 29 MB.

Also, additional logging will be added to the *SLUserDefinableApiManager.txt* log file when subscribing on NATS fails and when sending a reply on an incoming NATS request fails.

#### Legacy Reports, Dashboards and Annotations modules are now end-of-life and will be disabled by default [ID_37786]

<!-- MR 10.4.0 - FR 10.4.1 -->

As from DataMiner versions 10.1.10/10.2.0, the *LegacyReportsAndDashboards* and/or *LegacyAnnotations* soft-launch options allowed you to enable or disable the legacy *Reports*, *Dashboards* and *Annotations* modules. By default, they were enabled.

Now, the above-mentioned soft-launch options will be disabled by default, causing the legacy *Reports*, *Dashboards* and *Annotations* modules to be hidden. If you want to continue using these modules, which are now considered end-of-life, you will have to explicitly enable the soft-launch options.

#### SLAnalytics - Behavioral anomaly detection: Changes made to the anomaly configuration in an alarm template of a main DVE element will immediately be applied to all open anomaly alarm events [ID_37788]

<!-- MR 10.4.0 - FR 10.4.1 -->

When you change the anomaly configuration in an alarm template assigned to a main DVE element, from now on, the changes will immediately be applied to all open anomaly alarm events. The severity of the open alarm events will be changed to the new severity defined in the updated anomaly configuration.

#### GQI: Enhanced performance when executing inner of left join queries in which sorting is applied to the left query [ID_37803]

<!-- MR 10.4.0 - FR 10.4.1 -->

Because of a number of enhancements, overall performance has increased when executing inner or left join queries in which sorting is applied to the left query.

#### GQI: Enhanced performance when executing sorted queries [ID_37806]

<!-- MR 10.4.0 - FR 10.4.1 -->

Forwarding sort operators to the backend is now supported for a wider range of query configurations. This will considerably increase overall performance of numerous sorted queries.

#### SLNet will no longer allow DataMiner Agents to connect when they share the same DataMiner GUID [ID_37819]

<!-- MR 10.4.0 - FR 10.4.1 -->

When two DataMiner Agents try to connect via SLNet, from now on, this will no longer be allowed if the two agents share the same DataMiner GUID (except when they are both part of the same Failover setup).

#### DataMiner upgrade: New 'UninstallAPIDeployment' upgrade action and 'VerifyNoObsoleteApiDeployed' prerequisite [ID_37825]

<!-- MR 10.4.0 - FR 10.4.1 -->

When you upgrade DataMiner from a version older than 10.4.0 to a version from 10.4.0 onwards, the newly added *VerifyNoObsoleteApiDeployed* prerequisite will check whether the *APIDeployment* soft-launch flag is active and whether APIs are deployed. If so, the prerequisite will fail and return a link to the following page:

- [Upgrade fails because of VerifyNoObsoleteApiDeployed.dll prerequisite](xref:KI_Upgrade_fails_VerifyNoObsoleteApiDeployed_prerequisite)

Also, the newly added *UninstallApiDeployment* upgrade action will remove everything related to the deprecated [API Deployment](xref:Overview_of_Soft_Launch_Options#apideployment) feature:

- Stop and delete the *SLAPIEndpoint* service.

- Remove the following files (if present):

  - *C:\Skyline DataMiner\SLAPIEndpoint*
  - *C:\Skyline DataMiner\DeployerTokens*
  - *C:\Skyline DataMiner\ForceDeployerTokensFileStorage.txt*
  - *C:\Skyline DataMiner\Resources\SLAPIEndpoint.zip*

- If present, remove the rewrite rules for API Deployment.

- Remove the API Deployment configuration file from *C:\Skyline DataMiner\Configurations\JSON*.

- Remove the *APIDeployment* soft-launch flag from *SoftLaunchOptions.xml*.

#### Parameter ID range 10,000,000 to 10,999,999 now reserved [ID_37837]

<!-- MR 10.4.0 - FR 10.4.1 -->

Parameters IDs in the range of 10,000,000 to 10,999,999 are now reserved for DataMiner parameters. These will be used for DataMiner features in the future.

#### GQI: Ad hoc data sources and custom operators now support row metadata [ID_37879]

<!-- MR 10.4.0 - FR 10.4.1 -->

Ad hoc data sources and custom operators now support row metadata.

- In case of an ad hoc data source, any metadata can be attached to a row.
- In case of a custom operator, row metadata can be read from existing rows, and row metadata can be modified.

#### DataMiner upgrade: New prerequisite will check whether the DMA still contains legacy reports or legacy dashboards [ID_37922]

<!-- MR 10.4.0 - FR 10.4.1 -->

When you upgrade DataMiner from a version older than 10.4.0 to a version from 10.4.0 onwards, the newly added prerequisite will check whether the DataMiner Agent still contains legacy reports or legacy dashboards. If so, the prerequisite will fail.

See also: [Upgrade fails because of VerifyNoLegacyReportsDashboards.dll prerequisite](xref:KI_Upgrade_fails_VerifyNoLegacyReportsDashboards_prerequisite)

#### Service & Resource Management: Enhanced performance when updating/applying profile instances [ID_37976]

<!-- MR 10.4.0 - FR 10.4.1 -->

Overall performance has increased when updating/applying profile instances by providing a way to pass cached profile instances instead of first having to retrieve them from the database. To achieve this, the `ResourceUsageDefinition` now has a new overload method:

```csharp
public virtual void UpdateAllCapacitiesAndCapabilitiesByReference(Func<FilterElement<ProfileInstance>, List<ProfileInstance>> retriever, Dictionary<Guid, ProfileInstance> profileInstanceCache, IEnumerable<QuarantinedResourceUsageDefinition> correspondingQuarantines = null);
```

#### GQI - 'Get parameter table by ID' data source: Enhanced sorting [ID_38039]

<!-- MR 10.4.0 - FR 10.4.2 -->

When multiple, separate sort operators were optimized by the GQI data source *Get parameter table by ID*, up to now, they would be incorrectly combined into a single multi-level sort operation. From now on, only the last sort operator will be used, consistent with the behavior in case the sort operators are not optimized.

For example, from now on, when you sort by A and, later on in the GQI query, sort again by B, the query will now only be sorted by B.

#### SLAnalytics - Behavioral anomaly detection: Reduction of memory used for flatline detection [ID_38118]

<!-- MR 10.4.0 - FR 10.4.2 -->

The amount of memory used for flatline detection has been reduced.

#### GQI: Right query will be fetched lazily in case of a right join [ID_38134]

<!-- MR 10.4.0 - FR 10.4.2 -->

Up to now, when a *Join* operator of type "Right join" was applied, both the entire left query and the entire right query would be fetched. From now on, the right query will be fetched lazily.

#### SLAnalytics - Behavioral anomaly detection: Enhanced anomaly check algorithm [ID_38176]

<!-- MR 10.4.0 - FR 10.4.2 -->

A number of enhancements have been made to the anomaly check algorithm.

#### SLAnalytics - Alarm focus: Alarm occurrences will now be identified using a combination of element ID, parameter ID and primary key  [ID_38184]

<!-- MR 10.4.0 - FR 10.4.3 -->

When calculating alarm likelihood (i.e. focus score), up to now, the alarm focus feature used a combination of element ID, parameter ID and display key (if applicable) to identify previous occurrences of the same alarm. From now on, previous alarm occurrences will be identified using a combination of element ID, parameter ID and primary key.

#### SLLogCollector will now also collect the backup logs of the StorageModule DxM [ID_38228]

<!-- MR 10.4.0 - FR 10.4.2 -->

SLLogCollector will now also collect the backup logs of the *StorageModule* DxM located in the `C:\ProgramData\Skyline Communications\DataMiner StorageModule\Logs\Backup` folder.

### Fixes

#### Problem with Resource Manager when ResourceStorageType was not specified in Resource Manager settings [ID_34981]

<!-- MR 10.4.0 - FR 10.3.1 -->

In some cases, Resource Manager could throw a NullReferenceException when *ResourceStorageType* was not specified in the `C:\Skyline DataMiner\ResourceManager\Config.xml` file.

#### External authentication via SAML: Issues fixed when using Okta as identity provider [ID_35374]

<!-- MR 10.4.0 - FR 10.3.3 -->

Using Okta as identity provider, it would incorrectly no longer be possible to read out signed assertions. Also, when the group claim setting is enabled in the *DataMiner.xml* file, the user will now be added to the correct groups.

Up to now, in case of a claim mismatch, an exception would be thrown. From now on, an entry containing a clear message will be added to the *SLNet.txt* log file instead.

#### Automation: DataMiner would incorrectly remove the xmlns attribute when importing or saving an Automation script [ID_35708]

<!-- MR 10.4.0 - FR 10.3.4 -->

When DataMiner imported or saved an Automation script, it would incorrectly remove the `xmlns` attribute specified in the `<DMSScript>` element, even when that attribute had been added by DataMiner Integration Studio. From now on, when DataMiner imports or saves an Automation script, it will no longer remove this attribute. Moreover, if no such attribute is specified, it will automatically add `xmlns="http://www.skyline.be/automation"`.

Example:

```xml
<DMSScript options="272" xmlns="http://www.skyline.be/automation">
   <Name>...</Name>
   ...
</DMSScript>
```

#### DateTime instances would not get serialized correctly when an SLNet connection supported protocol buffer serialization [ID_35777]

<!-- MR 10.4.0 - FR 10.3.5 -->

When an SLNet connection supported protocol buffer serialization, DateTime instances would not get serialized correctly.

#### Input/output values of a matrix element would incorrectly be overridden due to a caching issue [ID_35857]

<!-- MR 10.4.0 - FR 10.3.4 [CU0] -->

When an ElementProtocol object was being created, due to a caching issue in SLNet, the input/output values stored in the protocol of a matrix element would incorrectly be overridden with the input/output values in the ElementProtocol object that was being created.

#### Message broker: Memory leak [ID_35898]

<!-- MR 10.4.0 - FR 10.3.4 [CU0] -->

The native message broker code could leak memory when using the request/response workflow in combination with chunking. The message handlers would not be cleaned up after the response had been received.

#### Business Intelligence: Outage correction would incorrectly be increased when a history alarm affected the outage [ID_35942]

<!-- MR 10.4.0 - FR 10.3.5 -->

When a history alarm affected a closed outage to which a correction had been applied, the correction would incorrectly be increased. From now on, the correction will be left untouched.

#### Handle in the Timer class would not be cleaned correctly [ID_35959]

<!-- MR 10.4.0 - FR 10.3.4 [CU0] -->

In some cases, a handle in the Timer class would not be cleaned correctly, causing handles to leak.

#### DataMiner Object Models: Problem when creating a DomInstance with an empty status [ID_36063]

<!-- MR 10.4.0 - FR 10.3.6 -->

When a DomInstance was created with an empty status, in some cases, a `MultipleSectionsNotAllowedForSectionDefinition` error could be returned, even when the configuration was correct.

#### External authentication via SAML: Removal of whitespace characters from signatures would cause validation to fail [ID_36181]

<!-- MR 10.4.0 - FR 10.3.6 -->

In some cases, whitespace characters would incorrectly be removed from signatures, causing validation to fail.

#### NATS auto-reconnect mechanism could lead to a situation in which a large number of TCP ports were left open [ID_36339]

<!-- MR 10.4.0 - FR 10.3.9 -->

When NATS tried to automatically reconnect at a moment when none of the servers were available, it would incorrectly not wait for a while until the cluster was online again. In some cases, this could lead to a situation in which a large number of TCP ports were left open.

#### Community credentials from the credential library would be ignored for SNMPv1 and SNMPv2 [ID_36353]

<!-- MR 10.4.0 - FR 10.3.7 -->

When, in element settings, community credentials from the credential library were used, those credentials would be ignored for SNMPv1 and SNMPv2. The get-community and set-community configured on the element would incorrectly be used instead.

#### SLNet would incorrectly return certain port information fields of type string as null values [ID_36524]

<!-- MR 10.4.0 - FR 10.3.8 -->

When element information was retrieved from SLNet, in some cases, certain port information fields of type string would incorrectly be returned as a null value instead of an empty string value. As a result, DataMiner Cube would no longer show the port information when you edited an element.

Affected port information fields:

- BusAddress
- Number
- PollingIPAddress
- PollingIPPort

#### Cassandra Cluster Migrator would fail to start up [ID_36804]

<!-- MR 10.4.0 - FR 10.3.8 [CU0] -->

When the *Cassandra Cluster Migrator* tool (*SLCCMigrator.exe*) was started, in some cases, it would get stuck in the initialization phase due to a connection issue.

#### Certain alarms would have their 'root creation time' set incorrectly [ID_36812]

<!-- MR 10.4.0 - FR 10.3.9 -->

In some cases, the *root creation time* of an alarm would not be equal to the *creation time* of the root alarm.

For example, when an alarm group was created with an old time of arrival, the *root creation time* would be set to the root time (i.e. the time of arrival of the root alarm), while the *creation time* would be set to the time at which the alarm was created.

#### Problem when renaming an element [ID_36855]

<!-- MR 10.4.0 - FR 10.3.9 -->

In some rare cases, an error could be thrown when an element was renamed.

#### Deprecated DMS_GET_INFO call could return unexpected DVE child data [ID_36964]

The deprecated DMS_GET_INFO call would return unexpected data when it returned data of elements that contained remotely hosted DVE child elements.

#### SLAnalytics: Problem when creating or editing a multivariate pattern [ID_37212]

<!-- MR 10.4.0 - FR 10.3.10 -->

When you created or edited a linked pattern with subpatterns from elements on different agents, and the first subpattern was from an element on an agent other than the one from which the CreateLinkedPatternMessage or EditLinkedPatternMessage was originally sent, SLNet would throw an exception.

#### Problem when importing an existing element [ID_37214]

<!-- MR 10.4.0 - FR 10.3.10 -->

When you imported an element that already existed in the system, in some cases, an error could occur in SLDataMiner.

#### SLAnalytics: Problem when deleting trend pattern while connected to a DMA running an old DataMiner version [ID_37225]

<!-- MR 10.4.0 - FR 10.3.10 -->

When you deleted a trend pattern when connected to a DataMiner Agent running an old DataMiner version (e.g. 10.3.0), the pattern itself was deleted but the occurrences/matches would remain visible until you closed the trend graph and opened it again.

#### DataMiner.xml: Entire LDAP section could get removed when settings were updated with values containing illegal XML characters [ID_37235]

<!-- MR 10.4.0 - FR 10.3.11 -->

When settings inside the `<LDAP>` element of the *DataMiner.xml* file were updated with values that contained illegal XML characters, the entire `<LDAP>` element would be removed from the file.

#### MessageHandler method in SLHelperTypes.SLHelper would incorrectly try to serialize exceptions that could not be serialize [ID_37238]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, the MessageHandler method in SLHelperTypes.SLHelper would incorrectly try to serialize exceptions that could not be serialized, causing other exceptions to be thrown.

#### SLAnalytics: Problem when trying to edit a multivariate pattern [ID_37270]

<!-- MR 10.4.0 - FR 10.3.11 -->

Due to a cache synchronization issue, problems could occur when trying to edit a multivariate pattern of which one of the elements is located on another DataMiner Agent.

#### EPM: Problem when SLNet requested information from other DataMiner Agents in the DMS [ID_37462]

<!-- MR 10.4.0 - FR 10.3.11 -->

In EPM environments, an error could occur when SLNet requested information from other DataMiner Agents in the DMS.  

#### Problem with ExistsCustomDataTypeRequest message when using a database other than Cassandra [ID_37470]

<!-- MR 10.4.0 - FR 10.3.12 -->

On systems using a database other than Cassandra, up to now, an `ExistsCustomDataTypeRequest` message would always return false and cause an error to be logged in the *SLDBConnection.txt* and *SLErrors.txt* files.

#### Storage as a Service: Row limits were disregarded when a post filter was applied to a query result [ID_37515]

<!-- MR 10.4.0 - FR 10.3.12 -->

In cases where SLDataGateway retrieved an entire table and then applied a filter afterwards, any row limits defined for the query in question would incorrectly be disregarded.

#### Problem when using MessageBroker with chunking [ID_37532]

<!-- MR 10.4.0 - FR 10.4.1 -->

On high-load systems, MessageBroker threads could leak when using chunking.

#### Storage as a Service: Paged data retrieval operations would be cut off prematurely [ID_37533]

<!-- MR 10.4.0 - FR 10.3.12 -->

When reading data from the database page by page, in some cases, the operation would be cut off prematurely.

#### Newly created element could get assigned the same DmaId/ElementId key as another, already existing element [ID_37560]

<!-- MR 10.4.0 - FR 10.3.12 -->

In some cases, a newly created element could get assigned the same DmaId/ElementId key as another, already existing element on another DataMiner Agent in the cluster. From now on, this will be prevented as long as the DataMiner Agents in questions can communicate with each other.

#### PropertyConfiguration.xml: New properties could incorrectly be assigned an existing property ID [ID_37596]

<!-- MR 10.4.0 - FR 10.4.2 -->

When, in a client application (e.g. DataMiner Cube) you created a new custom property, in some cases, that new property would incorrectly be assigned an ID that had already been assigned to another, existing property.

#### Storage as a Service: Every agent in the DMS would send the average trend data to the cloud during a migration [ID_37717]

<!-- MR 10.4.0 - FR 10.3.12 -->

When data was being migrated from a Cassandra Cluster database to a STaaS database, every DataMiner Agent in the DMS would incorrectly send the average trend data to the cloud. From now on, only one of the agents will send this data.

#### DELT package created on DataMiner v10.3.8 or newer could no longer be imported on DataMiner v10.3.7 or older [ID_37731]

<!-- MR 10.4.0 - FR 10.4.1 -->

When you exported elements via a DELT package on a DMA running DataMiner version 10.3.8 or newer, it would no longer be possible to import that DELT package on a DMA running DataMiner version 10.3.7 or older.

#### SLAnalytics: Problem with table parameter indices containing special characters [ID_37860]

<!-- MR 10.4.0 - FR 10.4.2 -->

Up to now, SLAnalytics would not correctly handle special characters in the table parameter indices. These characters will now be handled correctly. If parameters with indices containing special characters are trended, they will now also receive a trend prediction in the trend graph, and their behavioral change points will now be displayed.

Also, special characters in parameter indices will no longer cause errors to be logged.

#### Incorrect 'Clearing cache ...' entries in SLEventCache.txt [ID_37874]

<!-- MR 10.4.0 - FR 10.4.1 -->

Incorrect entries would be added to the *SLEventCache.txt* log file on DataMiner startup and when new objects (e.g. elements) had been created.

Example of an incorrect log entry:

`Clearing cache: predicate<entries with old hosting agent id> for type XXXXXX`

#### Storage as a Service: Problem when starting a database migration [ID_38059]

<!-- MR 10.4.0 - FR 10.4.1 [CU0] -->

When you tried to start a migration of an on-premises database to a DataMiner Storage as a Service platform, the connection towards the cloud could not get established.

#### DataMiner Storage Module: Thread leak [ID_38095]

<!-- MR 10.4.0 - FR 10.4.1 [CU0] -->

In some cases, the DataMiner Storage Module could leak threads.

#### Behavioral anomaly detection: Unlabelled changes would cause the trend icon to not be updated [ID_38105]

<!-- MR 10.4.0 - FR 10.4.2 -->

When small, unlabelled changes were detected in a trend graph of a parameter of which the value was clearly increasing, decreasing or remaining stable, up to now, the trend icon would incorrectly not be updated to indicate this increasing, decreasing or stable trend. From now on, when a small, unlabelled change occurs in a trend graph that clearly increases, decreases or remains stable, the trend icon will be updated to indicate this.

#### Storage as a Service: Database write operations would not get processed [ID_38112]

<!-- MR 10.4.0 - FR 10.4.1 [CU0] -->

In some rare cases, a database write operation could incorrectly remain stuck in an internal queue and would never get processed.

#### Problem when loading data of elements hosted on another DMA while a correlation rule action was running [ID_38121]

<!-- MR 10.4.0 - FR 10.4.2 -->

When, while an extensive correlation rule action was running, you opened an element card of an element hosted on a DataMiner Agent other than the one you were connected to, loading the data of that element could get delayed until the correlation rule action had finished.

#### Problems with gRPC connections when SLNet was not running [ID_38177]

<!-- MR 10.4.0 - FR 10.4.2 -->

When a DataMiner Agent had the APIGateway service running but not the SLNet process (e.g. a DataMiner Agent that had been fully stopped), the following issues would occur:

- No exception would be thrown when a client application sent a message via one of the gRPC connections that was still open. Instead, an empty response was returned. As a result, client applications would not notice that there was a problem.

- When an attempt was made to establish a new gRPC connection, an `Invalid username or password` would be returned instead of a `DataMinerNotRunningException`.

#### SLAnalytics - Automatic incident tracking: Problem after clearing or removing an alarm [ID_38239]

<!-- MR 10.4.0 - FR 10.4.2 -->

When an alarm had been cleared or removed, in some cases, the automatic incident tracking feature could incorrectly assume that no more alarms were associated with the parameter in question. As a result, alarms could get grouped incorrectly or error messages similar to the following one could start to appear:

`Parameter key [PARAMETER_KEY] was not in parameterKeyConverter, while it should have been.`

#### SLAnalytics - Automatic incident tracking: Empty alarm group would be created when manually creating an incident with non-active alarms [ID_38248]

<!-- MR 10.4.0 - FR 10.4.2 -->

When, while automatic incident tracking was running, you manually created an incident (i.e. an alarm group) containing non-active alarms, an empty alarm group would be created.

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the time frame specified in the 'Collect events for ... after first event, then evaluate conditions and execute actions' setting [ID_38292]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Up to now, when alarms were cleared before the end of the time frame specified in the *Collect events for ... after first event, then evaluate conditions and execute actions* correlation rule setting, the alarm buckets would not get cleaned up.

From now on, when a correlation rule is configured to use the *Collect events for ... after first event, then evaluate conditions and execute actions* trigger mechanism, all alarm buckets will be properly cleaned up, unless there are actions that need to be executed either when the base alarms are updated or when alarms are cleared.
