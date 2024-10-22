---
uid: General_Feature_Release_10.4.12
---

# General Feature Release 10.4.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.12](xref:Cube_Feature_Release_10.4.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.12](xref:Web_apps_Feature_Release_10.4.12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [DataMiner Agent will no longer restart when an SLProtocol process crashes [ID 40335]](#dataminer-agent-will-no-longer-restart-when-an-slprotocol-process-crashes-id-40335)

## New features

#### DataMiner Agent will no longer restart when an SLProtocol process crashes [ID 40335]

<!-- MR 10.5.0 - FR 10.4.12 -->

Up to now, when an SLProtocol process disappeared, the DataMiner Agent would restart. From now on, when an SLProtocol process disappears, a new SLProtocol process will be started and all elements that were hosted by the process that disappeared will now be hosted by the newly created process. However, as all parameter data in the SLProtocol process that disappeared is lost, all affected elements will be restarted. Also, a notice alarm will be created with the following value:

`Process disappearance of SLProtocol.exe with PID <processId>; <x> elements hosted by the disappeared process have been restarted.`

> [!IMPORTANT]
> When an SLProtocol process disappears, typically, a crashdump will also be created. It is highly recommended to ask [Skyline TechSupport](mailto:techsupport@skyline.be) to investigate that crashdump so that future SLProtocol disappearances and subsequent element restarts can be prevented.

In the *SLElementInProtocol.txt* log file, the following fields have been added:

- *NormalStart*/*SLProtocolCrashRestart* will indicate whether the element was started by a start action or due to an SLProtocol process disappearance.
- The number of times the element was started by a normal start action since the DataMiner Agent was started.
- The number of times the element was started due to an SLProtocol process disappearance.

> [!NOTE]
>
> - The process ID of the new SLProtocol process can be found in the *elementName.txt* log file, while the process ID of the old SLProtocol process can be found in the *elementName_BAK.txt* log file.
> - There will be a delay of one minute between the disappearance of an SLProtocol process and the creation of a new SLProtocol process.

#### Interactive Automation scripts: New option to skip the confirmation window when aborting [ID 40683]

<!-- MR 10.5.0 - FR 10.4.12 -->

`UIBuilder` now has a new `SkipAbortConfirmation` property. When set to true, the confirmation window will not be displayed when the interactive Automation script is aborted. By default, this property will be set to false.

Example:

```csharp
UIBuilder uib = new UIBuilder();
uib.SkipAbortConfirmation = true;
```

> [!TIP]
> See also: [Interactive Automation scripts: New option to skip the confirmation window when aborting [ID 40720]](xref:Cube_Feature_Release_10.4.12#interactive-automation-scripts-new-option-to-skip-the-confirmation-window-when-aborting-id-40720)

#### Trending - Proactive cap detection: Generating an alarm when a parameter is expected to cross a particular alarm threshold or be outside a set range [ID 41017]

<!-- MR 10.5.0 - FR 10.4.12 -->

The proactive cap detection feature is now able to generate an alarm when it expects that the value of the parameter will soon cross a particular alarm threshold or be outside a set range.

For more information on how to use this new feature in DataMiner Cube, see [Alarm templates - 'Anomaly alarm settings' window: New option to generate an alarm when a parameter is expected to cross a particular alarm threshold or be outside a set range [ID 40837] [ID 41109]](xref:Cube_Feature_Release_10.4.12#alarm-templates---anomaly-alarm-settings-window-new-option-to-generate-an-alarm-when-a-parameter-is-expected-to-cross-a-particular-alarm-threshold-or-be-outside-a-set-range-id-40837-id-41109)

## Changes

### Enhancements

#### OpenSearch: Enhanced performance of alarm queries [ID 40674]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

Alarm filters containing brackets can now be translated to OpenSearch queries. This will considerably improve overall performance of alarm queries against OpenSearch databases.

#### VerifyDotNetVersion prerequisite check now returns the missing .NET version and a link to the download page [ID 40677]

<!-- MR 10.5.0 - FR 10.4.12 -->

When you run the DataMiner installer or install a DataMiner upgrade package, the *VerifyDotNetVersion* prerequisite check will verify whether Microsoft ASP.NET 8.0 is installed. When this is not the case, the installation or upgrade will be aborted and a pop-up window will appear, showing the following message:

*Please install the latest \"ASP.NET Core Runtime hosting bundle\" for .NET 8.0 from [https://aka.ms/dotnet/download](https://aka.ms/dotnet/download)*

#### Security enhancements [ID 40684]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

A number of security enhancements have been made.

#### PortLog.txt file now supports IPv6 addresses [ID 40753]

<!-- MR 10.5.0 - FR 10.4.12 -->

In the *PortLog.txt* file, you can specify IP addresses of DataMiner elements for which log information has to be added to the *SLPort.txt* log file.

In this *PortLog.txt* file, it is now possible to specify IPv6 addresses as well as IPv4 addresses.

#### Automation: SubScriptOptions.SkipStartedInfoEvent will now by default be set to true [ID 40867]

<!-- MR 10.5.0 - FR 10.4.12 -->

If you have created an Automation script that launches subscripts, you can use the `SkipStartedInfoEvent` option to specify whether "Script started" information events should be generated for the subscripts or not.

Up to now, this `SkipStartedInfoEvent` option would by default be set to false. From now on, it will by default be set to true.

#### Enhanced gRPC connection quality in case of poor network performance [ID 40903]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, in some cases, a gRPC call between two SLNet instances could become unresponsive, causing run-time errors to be thrown in other processes. From now on, all gRPC calls will have a deadline of 15 minutes.

Also, from now on, a new SLNet option *HttpTcpKeepAliveInterval* can be configured on DataMiner Agents that are known to have unstable network connectivity. See the example below.

```xml
<MaintenanceSettings>
  <SLNet>
    <HttpTcpKeepAliveInterval>60</HttpTcpKeepAliveInterval>
  </SLNet>
</MaintenanceSettings>
```

#### Certain information events will no longer be generated when an element is duplicated [ID 40926]

<!-- MR 10.5.0 - FR 10.4.12 -->

When an element is duplicated, the following information events will no longer be generated:

- [Replicated Element]
- [Remote Element Name]
- [Remote DMA IP]

#### NT Notify types NT_ADD_VIEW_NO_LOCK and NT_ADD_VIEWS_NO_LOCK have been deprecated [ID 40928]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

The following NT Notify types have been deprecated:

- NT_ADD_VIEW_NO_LOCK
- NT_ADD_VIEWS_NO_LOCK

#### SLLogCollector: Miscellaneous enhancements [ID 40935]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

A number of enhancements have been made to the SLLogCollector tool:

- SLLogCollector packages will now include:

  - SSL certificates
  - Cube version information
  - Web API version information

- Hostnames will now be resolved via both *nslookup* and `System.Net.Dns.GetHostAddresses`.

#### SLXML: Enhanced error when erroneous XML code is received [ID 40995]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when SLXML received erroneous XML code, the error message logged in *SLXML.txt* would lose vital information when it was trimmed by SLLog due to the 5120-character error message size limit. The error message in question has now been adapted so that the most important information is found at the beginning.

#### SLLogCollector will no longer be configured by default to collect the log files of the DataAPI DxM [ID 41003]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, SLLogCollector would by default be configured to collect the log files of the DataAPI DxM. From now on, this will no longer be the case. Only when the DataAPI DxM is deployed, will SLLogCollector be configured to collect the log files of said DxM.

#### SLLogCollector will no longer be configured by default to collect the log files of the CommunicationGateway DxM [ID 41004]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Up to now, SLLogCollector would by default be configured to collect the log files of the CommunicationGateway DxM. From now on, this will no longer be the case. Only when the CommunicationGateway DxM is deployed, will SLLogCollector be configured to collect the log files of said DxM.

#### Web apps - Visual Overview: Default page will now be the first page that has not been set to 'hidden' [ID 41013]

<!-- MR 10.5.0 - FR 10.4.12 -->

For visual overviews in web apps (e.g. Monitoring, Dashboards, etc.), up to now, the default page would always be the first page, regardless of whether that page had been set to "hidden" or not. From now on, the default page will be the first page that has not been set to "hidden".

#### DataMiner installer: A progress bar will now be shown during the installation of WSL [ID 41032]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

When, while running the DataMiner installer to install a DataMiner Agent, you select the database type "Self-hosted - Local Storage", the installer will automatically install Windows Subsystem for Linux (WSL) as this is needed to run a Cassandra database. A progress bar will now be shown during the installation of WSL.

Also, when you select the above-mentioned database type, the following warning message will now be displayed:

`Warning: Selecting this option requires nested virtualization to be enabled on the host machine. Failure to do so will result in the feature not functioning.`

#### Default number of simultaneously running SLProtocol processes has been increased from 5 to 10 [ID 41077]

<!-- MR 10.5.0 - FR 10.4.12 -->

The number of simultaneously running SLProtocol processes can be set in the `<ProcessOptions>` tag of the *DataMiner.xml* file.

Up to now, the number of simultaneously running processes was by default set to 5. From now on, this number will by default be set to 10.

### Fixes

#### StorageModule DcM would not be aware of newly generated DataMiner GUID [ID 39121]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

When, at DataMiner start-up, no GUID is present in the `<DataMinerGuid>` element in *DataMiner.xml*, DataMiner will automatically generate one.However, up to now, when a new GUID was generated, the StorageModule DcM would not be aware of it. As a result, DataMiner would fail to start.

From now on, when a new DataMiner GUID is generated, the StorageModule DcM will be restarted to make sure it uses the new GUID.

#### Memory leaks in SLDMS [ID 40287]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

In some cases, SLDMS could leak memory.

#### SLNet: Problem when internal and external authentication were used within the same DMS [ID 40635]

<!-- MR 10.5.0 - FR 10.4.12 -->

When, in a DataMiner System, some agents used external authentication while other agents used internal authentication, in some rare cases, the SLNet error "SSPI.DLL is no longer supported" could be thrown on certain agents.

#### Problem when trying to access trend statistics on a DataMiner Cube connected via gRPC [ID 40668]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When DataMiner Cube was connected to a DataMiner Agent via gRPC, because of a deserialization issue on the server, it would not be possible to access trend statistics.

#### Problem when DataMiner Agent is named DATAMINER [ID 40743]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

From DataMiner 10.4.0 [CU2]/10.4.5 onwards, when the computer name of a DataMiner server was DATAMINER, the server would no longer function correctly.

> [!TIP]
> See also: Known issue [Problem when DMA server is named DATAMINER](xref:KI_Problem_when_server_name_is_DATAMINER)

#### Problem when requesting alarm details for DELT elements via legacy references [ID 40747]

<!-- MR 10.5.0 - FR 10.4.12 -->
<!-- Not added to MR 10.5.0 - Introduced by RN 40089 -->

Since DataMiner feature release 10.4.10, requesting alarm details for DELT elements via legacy [hosting DMA ID]/[root alarm ID] references would not work as expected.

`GetAlarmDetailsMessage` and `GetAlarmTreeMessage` have now been updated.

#### SLAnalytics - Behavioral anomaly detection: Updates to alarm templates used in alarm template groups could be disregarded [ID 40783]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when an alarm template used in an alarm template group was updated, and no element was using that template directly, in some cases, SLAnalytics would disregard the update. This could then lead to an incorrect anomaly alarm configuration being applied to elements using the alarm template group and to incorrect focus values being set in the alarms of the elements using the alarm template group.

#### Service & Resource Management: Bookings could incorrectly be saved with a non-existing capacity parameter [ID 40808]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, a booking could incorrectly be saved with a non-existing capacity parameter of which the value was set to zero.

#### Problem with alarm severity of a service not being updated correctly [ID 40840]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

In some cases, the alarm severity of a service would not be updated correctly when, during a row update, both the display key and the monitored value had been changed.

#### Failover: Problem with SLSNMPManager at startup [ID 40883]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a DataMiner Agent that was part of a Failover setup started up, in some cases, SLSNMPManager could stop working.

#### Problem when a DVE or virtual function element was deleted while a subscription was updated [ID 40900]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a DVE element or virtual function element was deleted while a subscription on the parent element or one of the child elements was updated, in some cases, especially when Stream Viewer was open, a run-time error could occur.

#### Incomplete CorrelationDetailsEvent messages after a DMA had reconnected to the DMS [ID 40934]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a DataMiner Agent reconnected to the DataMiner System of which it was a member (e.g. after having been restarted), in some rare cases, *CorrelationDetailsEvent* messages could be incomplete.

#### SLAnalytics - Behavioral anomaly detection: Alarm template of DVE parent element would incorrectly be used when monitoring was disabled in the alarm template of the DVE child template [ID 40963]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

When a DVE child element had an alarm template in which you had configured that a particular parameter should not be monitored while, in the alarm template of the DVE parent element, you had configured anomaly monitoring for that same parameter, up to now, the behavioral anomaly detection mechanism would incorrectly use the alarm template configuration of the DVE parent element. From now on, in these situations, it will use the alarm template configuration of the DVE child element instead.

#### Problem when executing a GQI query after a DMA had been restarted [ID 40975]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a GQI query was executed on a DataMiner System with storage per DMA, and then executed again after a DMA in that DataMiner System had been restarted, it would fail.

#### MySQL database optimization task would incorrectly be run on systems with a database other than MySQL [ID 40985]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, a MySQL database optimization task would incorrectly also be run on systems with a database other than MySQL.

#### Cassandra Cluster Migrator tool: Problem when encountering invalid or corrupt row while migrating alarm data [ID 41002]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

In some rare cases, the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*) would throw an error when it encountered an invalid or corrupt row in the source database while migrating alarm data. From now on, all invalid or corrupt rows will be skipped.

#### Element connections: Value of write parameters would incorrectly be resent [ID 41010]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When an element connection had a write parameter as source, up to now, the value of that parameter would be pushed to the destination when the element connections of the source element were modified or when the destination element was restarted. In some cases, this could result in unexpected behavior. For example, when the write parameter was a button, the destination element would start to execute the actions as if the button would have been pressed. From now on, write parameters used as source will only be forwarded to the destination when their value is actually updated.

The behavior of read parameters used as source will remain unchanged. Their value will still be forwarded to the destination when the destination element is restarted or when the element connections of the source element are modified. Read parameters are typically used to display the same value in both source and destination.

Also, up to now, when an element connection was saved without the *Include Element State* option being selected, the destination parameter (read parameter) would incorrectly be triggered twice with the same value. From now on, the value will only be forwarded once.

> [!NOTE]
> If you want write parameters used as source to behave as before, you can enable the *LegacyElementConnectionsResendWriteParams* soft-launch option.

#### GQI would no longer be able to send user-friendly error messages to client applications [ID 41019]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Since DataMiner feature version 10.3.9, SLHelper would wrap GQI exceptions incorrectly, causing GQI to no longer be able to send user-friendly error messages to client applications.

#### Problem with the NATS cluster configuration after a DataMiner start-up [ID 41072]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

After a DataMiner start-up, in some cases, the NATS cluster would be configured incorrectly and the following error message would be added to the *SLError.txt* log file:

`ResetLocalNatsCluster|ERR|0|18|System.IO.InvalidDataException: Central Directory corrupt. ---> System.IO.IOException: An attempt was made to move the position before the beginning of the stream.`

#### Protocols: Stuffing attribute of Protocol.Advanced element was not parsed correctly [ID 41092]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

The value of the `stuffing` attribute of the *Protocol.Advanced* element was not parsed correctly.

#### Enhanced exception handling in SLDMS, SLASPConnection and SLWatchdog [ID 41121]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

A number of enhancements have been made to SLDMS, SLASPConnection and SLWatchdog with regard to exception handling.
