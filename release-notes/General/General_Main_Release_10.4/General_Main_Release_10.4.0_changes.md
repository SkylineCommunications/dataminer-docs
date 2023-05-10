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

#### Maps: Zoom range can now be set by means of a slider [ID_35381]

<!-- MR 10.4.0 - FR 10.3.3 -->

The zoom range of a map can now be set by means of a slider.

#### SLAnalytics - Automatic incident tracking: Enhanced performance when fetching relation information [ID_35414] [ID_35508]

<!-- 35414:  MR 10.4.0 - FR 10.3.3 -->
<!-- 35508:  MR 10.4.0 - FR 10.3.4 -->

Because of a number of enhancements, overall performance has increased when fetching relation information for the automatic incident tracking feature.

#### Security enhancements [ID_35434] [ID_35997]

<!-- 35434: MR 10.4.0 - FR 10.3.4 -->
<!-- 35997: MR 10.4.0 - FR 10.3.5 -->

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

#### SLAnalytics will now send regular notifications instead of client notifications [ID_35591]

<!-- MR 10.4.0 - FR 10.3.4 -->

Up to now, when SLAnalytics sent a notification, it would generate an event of type *client notification* with parameter ID 64574. From now on, it will instead generate an event of type *notification* with parameter ID 64570.

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

#### SLAnalytics - Behavioral anomaly detection: Events associated with a DVE child element will no longer be linked to the DVE parent element [ID_35901]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, when an event associated with a DVE child element was generated, internally, that event would be linked to the DVE parent element. From now on, it will be linked to the child element instead.

#### API Gateway module now targets Microsoft .NET 6.0 [ID_36238]

As Microsoft .NET 5 is being phased out, the *API Gateway* module will now use Microsoft .NET 6.0 instead.

#### Service & Resource Management: Enhanced performance when stopping an ongoing booking [ID_36255]

<!-- MR 10.4.0 - FR 10.3.6 -->

Because of a number of enhancements, overall performance has increased when stopping an ongoing booking.

#### DataMiner Cloud Packs have been restructured [ID_36335]

<!-- MR 10.4.0 - FR 10.3.7 -->

Two different DataMiner Cloud Packs are now available.

| Cloud Pack  | Included modules | Description |
|-------------|------------------|-------------|
| Full pack | CloudGateway<br>CloudFeed<br>ArtifactDeployer<br>CoreGateway<br>FieldControl<br>Orchestrator<br>SupportAssistant | Pack to be installed on a DataMiner Agent that will connect to dataminer.services directly |
| Proxy/DMZ pack | CloudGateway<br>CloudFeed<br>Orchestrator | Pack to be installed on a proxy server or a DMZ server via which a DataMiner Agent will connect to dataminer.services |

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

#### NATS-related error: 'Failed to copy credentials from [IP address] - corrupt zip file' [ID_35935]

<!-- MR 10.4.0 - FR 10.3.6 -->

In some rare cases, the following NATS-related error would be thrown:

```txt
Failed to copy credentials from [IP address] - corrupt zip file
```

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

#### Client connection would be dropped because an SLNet request handled by SLHelper took too long to process [ID_36296]

<!-- MR 10.4.0 - FR 10.3.7 -->

When it took SLHelper more than 15 minutes to process an SLNet request received from a client, a NATS exception was returned to the client. However, as this exception was not serialized, the client would not receive it, causing the client connection to get dropped.

From now on, NATS exceptions returned to a client following an SLHelper timeout will always be serialized.
