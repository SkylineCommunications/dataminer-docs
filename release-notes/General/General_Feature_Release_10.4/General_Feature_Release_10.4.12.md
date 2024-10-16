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

*No highlights have been selected yet.*

## New features

#### New SLProtocol process will be started when an SLProtocol process disappears [ID 40335]

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

#### Trending - Proactive cap detection: Generating an alarm when a parameter is expected to cross a certain alarm threshold [ID 41017]

<!-- MR 10.5.0 - FR 10.4.12 -->

The proactive cap detection feature is now able to generate an alarm when it expects that a parameter will cross a particular alarm threshold in the near future.

For more information on how to use this new feature in DataMiner Cube, see [Alarm templates - 'Anomaly alarm settings' window: New option to generate an alarm when a parameter is expected to cross a certain alarm threshold [ID 40837]](xref:Cube_Feature_Release_10.4.12#alarm-templates---anomaly-alarm-settings-window-new-option-to-generate-an-alarm-when-a-parameter-is-expected-to-cross-a-certain-alarm-threshold-id-40837)

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

#### Certain information events will no longer be generated when an element is duplicated [ID 40926]

<!-- MR 10.5.0 - FR 10.4.12 -->

When an element is duplicated, the following information events will no longer be generated:

- [Replicated Element]
- [Remote Element Name]
- [Remote DMA IP]

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

### Fixes

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

#### MySQL database optimization task would incorrectly be run on systems with a database other than MySQL [ID 40985]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, a MySQL database optimization task would incorrectly also be run on systems with a database other than MySQL.

#### GQI would no longer be able to send user-friendly error messages to client applications [ID 41019]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Since DataMiner feature version 10.3.9, SLHelper would wrap GQI exceptions incorrectly, causing GQI to no longer be able to send user-friendly error messages to client applications.
