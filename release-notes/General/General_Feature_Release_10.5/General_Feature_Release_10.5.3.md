---
uid: General_Feature_Release_10.5.3
---

# General Feature Release 10.5.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.3](xref:Cube_Feature_Release_10.5.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.3](xref:Web_apps_Feature_Release_10.5.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### DataMiner Object Models: Configuring trigger conditions for CRUD scripts [ID 41780]

<!-- MR 10.6.0 - FR 10.5.3 -->

From now on, conditions can be used to prevent the update script from being triggered for each and every `DomInstance` update. This allows you to make a solution more efficient as no unnecessary script triggers are executed. These conditions can be configured by instantiating one of the supported condition classes and adding it to the `OnUpdateTriggerConditions` collection property on the `ExecuteScriptOnDomInstanceActionSettings`.

The conditions are evaluated using a logical 'OR', meaning that only one condition needs to be true for the script to trigger.

> [!IMPORTANT]
> When you configure conditions, the update script will no longer be triggered when a status transition is done. A status-related condition to define a trigger based on a specific status is currently not available.

##### FieldValueUpdatedTriggerCondition

This condition type allows you to check whether a `FieldValue` for a given `FieldDescriptor` has been added, updated, or removed. It also supports multiple sections, meaning the condition will be met if:

- A **new** `FieldValue` is added in a new or existing `Section`.
- An **existing** `FieldValue` is deleted from a deleted or existing `Section`.

To use this condition, define the ID of the `FieldDescriptor` by passing it to the condition's constructor.

Example:

```csharp
var licensePlate = new FieldDescriptorID(Guid.Parse("81915fe0-8f55-4ad1-8da5-3b703f9e7842"));
var insuranceId = new FieldDescriptorID(Guid.Parse("7cd4366c-983c-46d2-aa92-e0308a3102e5"));

moduleSettings.DomManagerSettings.ScriptSettings.OnUpdateTriggerConditions = new List<IDomCrudScriptTriggerCondition>
{
   new FieldValueUpdatedTriggerCondition(licensePlate),
   new FieldValueUpdatedTriggerCondition(insuranceId)
};
```

## Changes

### Breaking changes

#### Protocols: Separate SLScripting process for every protocol used [ID 41713]

<!-- MR 10.6.0 - FR 10.5.3 -->

From now on, DataMiner will by default start a separate SLScripting process for every SLProtocol process.

Up to now, if you wanted to have separate SLScripting processes created for every protocol being used, you had to explicitly configure this in `ProcessOptions` element of the *DataMiner.xml* file. See the example below.

```xml
<DataMiner>
  <ProcessOptions protocolProcesses="protocol" scriptingProcesses="protocol" />
</DataMiner>
```

If you only want a single SLScripting process for all protocols that are used, then set the `scriptingProcesses` attribute to "1".

### Enhancements

#### Security enhancements [ID 40632]

<!-- 40632: MR 10.6.0 - FR 10.5.3 -->

A number of security enhancements have been made.

#### Change Element States Offline tool: Service elements will now be hidden by default [ID 41341]

<!-- MR 10.5.0 - FR 10.5.3 -->

From now on, the *Change Element States Offline* tool will hide service elements by default. This will prevent users from mistakenly stopping those elements.

If you do want service elements to be visible, select the *Advanced* checkbox.

#### Protocols: New 'overrideTimeoutVF' option to override the timeout for a Virtual Function [ID 41388]

<!-- MR 10.6.0 - FR 10.5.3 -->

Up to now, when the `overrideTimeoutDVE` option was enabled in a *protocol.xml* file, the timeout would apply to DVE elements as well Virtual Functions.From now on, this option will only apply to DVE elements.

In order to override the timeout for a Virtual Function, you will now be able to specify the new *overrideTimeoutVF* option in a *Functions.xml* file.

#### Swarming: Clearer exception will now be thrown when the state of an element is changed while the element is being swarmed [ID 41634]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

When the state of an element was changed while that element was being swarmed, up to now, a "host unknown" exception would be thrown.

From now on, an *SL_SWARMING_IN_PROGRESS* exception will be thrown instead. This exception will now clearly state that the update cannot be performed because the element is being swarmed.

#### DataMiner Connectivity Framework: Enhanced processing of SRM services by the connectivity manager [ID 41649]

<!-- MR 10.5.0 - FR 10.5.3 -->

Because of a number of enhancements made to the DataMiner Connectivity Framework, overall performance of the connectivity manager has increased when processing SRM services.

#### Enhanced error and exception handling when updating or clearing correlation alarms [ID 41675]

<!-- MR 10.5.0 - FR 10.5.3 -->

Error and exception handling has been enhanced in order to prevent duplicate or sticky correlation alarms due to errors or exceptions thrown when updating or clearing correlation alarms.

#### SLNet: Enhancements to prevent SLNet modules from forwarding requests back and forth between two DMAs [ID 41827]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

A number of enhancements have been made to prevent SLNet modules from forwarding requests back and forth between two DataMiner Agents.

#### SLAnalytics: New check to verify if the incident tracking leader is still a member of the current DMS [ID 41836]

<!-- MR 10.5.0 - FR 10.5.3 -->

At DataMiner start-up, from now on, SLAnalytics will check whether the DataMiner Agent configured as leader\* is still a member of a current DataMiner System.

Also, from now on, a new leader will be elected when the former leader has left the cluster.

*\* In DataMiner Cube, the leader can be configured in the *Leader DataMiner ID* box, which can be found in *System Center > System settings > Analytics config > Automatic incident tracking*.*

#### Service & Resource Management: Enhanced performance when processing history entries for booking instances and resources [ID 41842]

<!-- MR 10.6.0 - FR 10.5.3 -->

Up to now, history entries for booking instances and resources would be processed individually. From now on, they will be processed in batches of 100 entries. This will considerably enhance overall performance when processing these history entries.

#### Smart baselines will now also get capped when the parameter only has either a low value or a high value [ID 41870]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When DataMiner calculates a smart baseline value that lies outside the range specified in the protocol for the parameter in question, then the value is capped. However, up to now, this would only happen when the range had both a low value and a high value.

From now on, calculated smart baseline values will also get capped when the parameter in question only has either a low value or a high value.

#### Amazon Keyspaces Service is now end-of-life [ID 41874] [ID 41914]

<!-- MR 10.5.0 [CU0] - FR 10.5.3 -->

Support for Amazon Keyspaces Service is now officially end-of-life.

When you run the DataMiner installer or install a DataMiner upgrade package, the *VerifyNoAmazonKeyspaces* prerequisite will check whether the DataMiner Agent is configured to use a database of type *Amazon Keyspaces*. If so, the upgrade process will not be allowed to continue.

We recommend using [Storage as a Service (STaaS)](xref:STaaS) instead. If you want to use self-hosted storage, install a [Cassandra Cluster](xref:Cassandra_database) database.

For more information, see [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service)

#### SLLogCollector now collects data regarding the GQI DxM [ID 41880]

<!-- MR 10.5.0 - FR 10.5.3 -->

SLLogCollector packages now include the following data regarding the GQI DxM:

- *appsettings.json*
- Log file
- Version

#### SLLogCollector packages now also contain the ClusterEndpoints.json file [ID 41887]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

SLLogCollector packages now also include the *ClusterEndpoints.json* file.

#### SLPort: Enhanced performance and reduced memory and CPU usage [ID 41896]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Because of a number of enhancements, overall performance of SLPort has increased. The process will now also use less memory and CPU.

#### Swarming prerequisites: Entries will now be added to SLNet.txt while checking alarm ID usage in Automation scripts and protocol QActions [ID 41930]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

While checking the Swarming prerequisites, DataMiner checks alarm ID usage in Automation scripts and protocol QActions. As this step can take up to several minutes, log entries will now be added to the *SLNet.txt* log file while alarm ID usage is being checked.

#### Swarming: Elements polling the local IP address no longer blocked from being swarmed [ID 41957]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

Up to now, it was not allowed to swarm elements polling the local IP address of any agent in the DMS and elements polling the loopback address.

From now on, it will be allowed to swarm elements polling the local IP address of any agent in the DMS. However, elements polling the loopback address will remain blocked.

#### SLNet: Enhanced performance when clearing the alarms cache [ID 41998]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Because of a number of enhancements, overall performance of SLNet has increased when clearing the alarms cache.

### Fixes

#### Elements no longer visible after having been swarmed [ID 41635]

<!-- MR 10.5.0 - FR 10.5.3 -->
<!-- Not added to MR 10.5.0 -->

In some rare cases, when an element had been swarmed, it would no longer be visible in client apps like DataMiner Cube.

#### Missing DATAMINER_NOTIFICATION_QUEUE thread [ID 41699]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When DataMiner was restarted, an issue could occur, causing the DATAMINER_NOTIFICATION_QUEUE thread not to be registered in processes like SLDMS, SLElement or SLDataGateway. These missing threads could then lead to a number of symptoms like empty element data cards or not being able to swarm back elements.

#### Problem with incorrect virtual element states [ID 41705]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some rare cases, the element state of a DVE or Virtual Function element would end up incorrect in the SLNet cache, causing some caches to not be initialized correctly.

#### Problem when trying to swarm an element back to its original DataMiner Agent [ID 41709]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

In some cases, it would not be possible to swarm an element back to its original DataMiner Agent due to a caching issue in the SLDataMiner process.

#### Problem with SLDataMiner when a DMS with swarming enabled had a database connection issue at start-up [ID 41714]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

When, while starting up, a DataMiner System with swarming enabled experienced a problem with its database connection, the SLDataMiner process would incorrectly shut down.

#### Service & Resource Management: Problem when a previously deleted booking was created again [ID 41718]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a previously deleted booking was created again with the same ID, up to now, that booking would incorrectly not be retrieved.

#### GQI: Min and Max aggregation of a datetime column would incorrectly result in a number column [ID 41789]

<!-- MR 10.5.0 - FR 10.5.3 -->

Up to now, when a Min or Max aggregation was performed on a datetime column, the aggregated column would incorrectly be a number column instead of datetime column.

#### Uploading the same version of a DVE connector twice would incorrectly cause the production version of DVE child elements to be changed [ID 41798]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When the same version of a DVE connector was uploaded twice, the production version of all DVE child elements using another version of that connector as production version would incorrectly have their production version set to the newly uploaded version.

#### Protocols: Problem when deleting an element with a parameter that had a duplicate RawType tag configured [ID 41871]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When an element was deleted, a run-time error could occur in SLProtocol when a parameter had a duplicate `RawType` tag configured.

#### SNMP managers would incorrectly receive some or all active alarms at DMA start-up [ID 41878]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a DataMiner Agent was started, in some cases, the configured SNMP managers would incorrectly receive some or all active alarms.

#### Fixes made with regard to the management of locally-stored element documents [ID 41882]

<!-- MR 10.5.0 - FR 10.5.3 -->

A number of fixes have been made with regard to the management of locally-stored element documents that are not synchronized among the DMAs in a DataMiner System.

#### Problem when swarming elements between two DMAs with a time difference [ID 41910]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

When elements were swarmed between two DataMiner Agents, in some rare cases, a problem could occur when there was a time difference between both agents.

#### Alarms without focus value would not be correctly removed from alarm groups when the associated element was deleted, stopped or paused [ID 41950]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, alarm groups containing alarms without a focus value (e.g. notices or errors) would not be correctly removed from the group when the element associated with the alarm was deleted, stopped or paused.

#### Problem with SLDataMiner when creating a dmimport package [ID 41963]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Up to now, in some cases, SLDataMiner could stop working while creating a dmimport package.

A number of enhancements have now been made with regard to error handling during the creation of dmimport packages. From now on, when an issue occurs while a dmimport package is being created, an error message will be shown in the client (e.g. DataMiner Cube).

#### Errors would be logged in SLErrors.txt and SLNet.txt when Mobile Gateway was enabled in a DMS with more than one agent [ID 41988]

<!-- MR 10.5.0 - FR 10.5.3 -->

Up to now, errors would be logged in the *SLErrors.txt* and *SLNet.txt* log files when Mobile Gateway was enabled in a DataMiner System with more than one DMA.

Also, the Mobile Gateway process would only be aware of elements that were hosted on the same agent as the one on which it was hosted itself. As a result, actions like GET and SET on other elements via the Mobile Gateway would fail.

#### BPA tests would fail to load the necessary DLL files [ID 42000]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, BPAs tests would fail to load the necessary DLL files.
