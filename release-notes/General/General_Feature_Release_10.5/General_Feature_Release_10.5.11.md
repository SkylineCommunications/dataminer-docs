---
uid: General_Feature_Release_10.5.11
---

# General Feature Release 10.5.11 – Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.11](xref:Cube_Feature_Release_10.5.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.11](xref:Web_apps_Feature_Release_10.5.11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [Swarming: Parent DVE and Virtual Function elements can now also be swarmed [ID 43793]](#swarming-parent-dve-and-virtual-function-elements-can-now-also-be-swarmed-id-43793)

## New features

#### SLNetClientTest tool: Filtering messages using regular expressions [ID 43540]

<!-- MR 10.6.0 - FR 10.5.11 -->

In the *SLNetClientTest* tool, at the bottom of the main window, a new filter box has been added.

After you select the checkbox in front of it, it will allow you to filter the message list using a regular expression.

This new filter box should only be used when no new messages will be added to the list, e.g. when inspecting an *\*.slnetdump* file.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Swarming: Parent DVE and Virtual Function elements can now also be swarmed [ID 43793]

<!-- MR 10.6.0 - FR 10.5.11 -->

It is now also possible to swarm parent DVE and Virtual Function elements. If you do so, all child elements will then automatically be swarmed together with the parent element.

> [!NOTE]
>
> - Parent or child elements that are part of a redundancy group cannot be swarmed. Also, a parent element cannot be swarmed if one of its child elements is part of a redundancy group.
> - In DataMiner Cube, only parent elements will show up in the *Element swarming* window. As child elements will automatically follow their parent element, they will not appear in the *Element swarming* window.

## Changes

### Enhancements

#### Element replication: Replication buffer will now be read in chunks [ID 43281]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, when the connection to a replicated element was restored, the entire replication buffer would be read into memory at once. From now on, the replication buffer will be read in chunks.

#### Relational anomaly detection: RAD parameter groups can now contain parameters hosted by different DMAs [ID 43440] [ID 43686]

<!-- MR 10.6.0 - FR 10.5.11 -->

Up to now, relational anomaly detection (RAD) was only able to monitor parameters on the local DataMiner Agent. In other words, all parameter instances configured for a particular RAD parameter group had to be hosted on the same DMA.

From now on, it is also possible to create RAD parameter groups containing parameters hosted by different DMAs. Moreover, RAD parameter groups will now also keep working after an element has been swarmed.

> [!NOTE]
>
> - A RAD parameter group will be hosted on the DMA on which it was created, even after some of the parameters in the group were swarmed to other DMAs.
> - Whenever you delete an element that is being used in one or more RAD parameter groups, an error will immediately get logged, and the parameter groups containing parameters from that deleted element will be marked as "not monitored".
> - The RAD API messages no longer have to be sent to the agent monitoring the parameters in question. Each message will automatically be forwarded to the correct agent based on the name of the parameter group. If the agent could not be determined, an exception will be thrown.
> - The `GetRADParameterGroupsMessage` will now retrieve a list of all RAD parameter groups that have been configured across all agents in the cluster. Up to now, it would only retrieve the list of RAD parameter groups hosted on the local agent.
> - It is no longer allowed to have two groups with the same name, even when they are hosted by different agents.

#### Swarming: An unload request will now be broadcasted when an element is swarmed to the DMA that is hosting it [ID 43567]

<!-- MR 10.6.0 - FR 10.5.11 -->

Up to now, when an element was swarmed to the DataMiner Agent that was hosting it already, nothing would happen.

From now on, an unload request will be broadcasted to all DataMiner Agents in the cluster, making sure that no other DataMiner Agent is incorrectly hosting it.

#### DataMiner Object Models: Enhanced performance when filtering on FieldValues in memory via FilterElements [ID 43568]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When filtering on FieldValues in memory via FilterElements, the DomInstanceExposers.FieldValues exposer will no longer generate a JsonSerializableDictionary. Instead, it will now use a standard dictionary. This will enhance overall in-memory filtering performance.

#### VerifyGRPCConnection prerequisite check: Clearer error will now be logged when the check is performed on an agent that is not running [ID 43608]

<!-- MR 10.6.0 - FR 10.5.11 -->

When the *VerifyGRPCConnection* prerequisite check is performed on a DataMiner Agent that is not running, the error that is logged will now explain the problem clearer.

#### DataMiner upgrade: All but the Web.config file will be removed from the 'C:\\Skyline DataMiner\\Webpages\\API' folder [ID 43609]

<!-- MR 10.6.0 - FR 10.5.11 -->

During a DataMiner upgrade (or downgrade), up to now, only the `\bin` subfolder of the `C:\Skyline DataMiner\Webpages\API` folder would be cleared.

From now on, the entire `C:\Skyline DataMiner\Webpages\API` folder will be cleared. Only the `Web.config` file will be kept.

#### STaaS: Enhanced exception logging [ID 43626]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

A number of enhancements have been made with regard to the logging of exception messages on STaaS systems.

#### DxMs upgraded [ID 43642] [ID 43644] [ID 43677]

<!-- RN 43642: MR 10.5.0 [CU8] - FR 10.5.11 -->
<!-- RN 43644: MR 10.6.0 - FR 10.5.11 -->
<!-- RN 43677: MR 10.6.0 - FR 10.5.11 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.6
- DataMiner CloudGateway 2.17.12
- DataMiner CoreGateway 2.14.14
- DataMiner DataAPI 1.3.0
- DataMiner SupportAssistant 1.7.7

<!-- 43677 -->As from now, the DataAPI DxM will also be included in DataMiner upgrade packages. However, similar to the CloudGateway DxM, it will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, they will not be installed.

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### CPE: Enhanced performance [ID 43654]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

Because of a number of enhancements in the aggregation module, overall performance has increased.

#### SLDataGateway will now use a custom thread pool instead of TPL for operations towards Cassandra [ID 43658]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

For operations towards Cassandra, from now on, SLDataGateway will use a custom thread pool instead of *Task Parallel Library* (TPL).

Also, when any of the queues in SLDataGateway would get stuck, an alarm of type error will now be generated.

#### STaaS: A failure notice will now be returned immediately when an operation could not be sent to STaaS [ID 43667]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, when DataMiner was not able to send an operation to STaaS, it had to wait until the write operation timed out before it got confirmation that the operation had failed.

From now on, when DataMiner tries to send an operation of which the size exceeds the maximum package limit to STaaS, a failure notice will be returned immediately.

#### Automation scripts: No attempts will be made anymore to automatically detect the interactive behavior of script libraries [ID 43673]

<!-- MR 10.6.0 - FR 10.5.11 -->

From now on, no attempts will be made anymore to automatically detect the interactive behavior of script libraries, i.e. scripts of which all Exe blocks contain precompiled C# code. These libraries are not intended to be run independently.

#### DataMiner upgrade: All but the Web.config file will be removed from the 'C:\\Skyline DataMiner\\Webpages\\API' folder when downgrading to an older version [ID 43687]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

From now on, when a DataMiner Agent is downgraded to an older version, the entire `C:\Skyline DataMiner\Webpages\API` folder will be cleared. Only the `Web.config` file will be kept.

#### DataMiner Object Models: Requests will be kept on hold for up to 30 seconds when sent to a DOM manager that is reinitializing [ID 43711]

<!-- MR 10.6.0 - FR 10.5.11 -->

Up to now, when a request was sent to a DOM manager while it was reinitializing, that request would immediately fail with the following error message:

`The manager '<Manager Name>' is de-initialized`

From now on, when a request is sent to a DOM manager that it reinitializing, the request will be kept on hold (for up to 30 seconds) until the DOM manager is initialized again. If, after that 30-second delay, the DOM manager is not initialized, the following error message will be returned:

`Initialization failed or did not complete in time for manager '<Manager Name>'. Check logging for more info.`

#### SLLogCollector packages now also include the Web DcM log files [ID 43716]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

SLLogCollector packages now also include the log files of the Web DcM.

#### Relational anomaly detection: New API message to retrieve a RAD parameter subgroup [ID 43797]

<!-- MR 10.6.0 - FR 10.5.11 -->

From now on, the new `GetRADSubgroupInfoMessage` will allow you to retrieves all configuration information for a particular RAD parameter subgroup by subgroup ID.

#### DataMiner Object Models: A ModuleSettings update will no longer automatically trigger a network credentials check [ID 43799]

<!-- MR 10.6.0 - FR 10.5.11 -->

Up to now, each time a `ModuleSettings` object was updated, the network credentials would be checked, even when those credentials had not been changed.

From now on, when a `ModuleSettings` object is updated, the network credentials will only be checked if the network path or the credential ID were updated as well.

### Fixes

#### Problem when loading initial parameter data for remote elements [ID 43339] [ID 43552]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

In some cases, client applications like DataMiner Cube would fail to load initial parameter data for remote elements.

#### Protocols: Problems with pollingRate attribute [ID 43418]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

A number of issues have been fixed with regard to the `pollingRate` attribute, which allows you to slow down polling for specific SNMP columns in a table by specifying a minimum interval (in milliseconds) between polling.

- Using `pollingRate` would not work when the element was using the production version of the protocol or when the `partialSNMP` option was specified in the table options.

- Up to now, the decision to poll a column was taken by SLSNMPManager, which relied on the *Polling.xml* file that was stored alongside the *Protocol.xml* file. From now on, SLProtocol will determine which columns will be polled independently of the *Polling.xml* file.

> [!NOTE]
> Stream Viewer will now indicate more clearly which columns were polled. When some columns were polled while others were skipped, the message `[PollingRate polled column PIDs xxx,yyy]` will be shown. Also, when the timer was faster than the polling rate, the message `No column reached the PollingRate interval.` will be shown, and no Get operation will be executed.

#### Problem when trying to send an SNMP Set command to have all active alarms resent [ID 43442]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

You can have all active alarms resent by sending an SNMP Set command to the DMA (with the DataMiner IP address as target address) with OID 1.3.6.1.4.1.8813.1.1.1.1.4 and value set to the name of the SNMP manager.

However, since DataMiner versions 10.4.0 [CU12]/10.5.3, this would no longer work when the SNMP manager in question had the *Resend all active alarms every ...* option disabled.

#### Alarm indicating a run-time error would incorrectly say "-1 pending" when all threads cleared simultaneously [ID 43508]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When multiple threads of the same process have a run-time error, the associated alarm will say "+X pending", indicating the number of threads that are stuck.

Up to now, when all threads cleared simultaneously, in some cases, the alarm would incorrectly say "-1 pending".

#### Cassandra Cluster Migrator tool: Problem when reverse lookup of IP addresses returned hostnames other than those configured in the SSL certificate [ID 43520]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you tried to migrate a Cassandra Cluster with SSL/TLS enabled, up to now, the Cassandra Cluster Migration tool would not be able to initialize when a reverse lookup of IP addresses returned hostnames other than those configured in the SSL certificate.

This issue can be prevented by manually checking if the IP address is one of the SANs (Subject Alternative Names) of the SSL certificate.

#### Problem when trying to update the log levels of an element that was not hosted on the local DataMiner Agent [ID 43582]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

When you tried to update the log levels of an element that was not hosted on the local DataMiner Agent, up to now, the update request would incorrectly be ignored and would not be forwarded to the DataMiner Agent hosting the element.

From now on, the update request will correctly be forwarded to the DataMiner Agent hosting the element where it will be processed accordingly.

#### SLNet could return incorrect data to the client application when processing a cell subscription filter [ID 43600]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When processing a cell subscription filter, in some cases, SLNet could return incorrect data to the client application.

#### Restarting a replicated element could cause SLProtocol to leak memory [ID 43613]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you restarted a replicated element that was in the process of starting up, in some cases, the resources in memory would incorrectly not get cleaned up, causing SLProtocol to leak memory.

#### Copilot DxM - Natural language to GQI: Columns could get removed from the cache when repeatedly requesting queries against the same data source [ID 43616]

<!-- MR 10.6.0 - FR 10.5.11 -->

When you repeatedly requested GQI queries with aggregations like e.g. "group by" against the same data source, in some cases, certain columns could incorrectly get removed from the data sources cache.

#### Production version of DVE child elements would incorrectly be reset when you uploaded an updated copy of the DVE protocol version [ID 43640]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you uploaded an updated copy of a DVE protocol version that had already been uploaded before, up to now, the production version of the DVE child elements that were using that protocol would incorrectly be reset.

#### Service & Resource Management: Problem when updating existing properties of a booking [ID 43659]

<!-- MR 10.6.0 - FR 10.5.11 -->

Up to now, when the `SafelyUpdateReservationInstanceProperties` method of `ResourceManagerHelper` was used to update existing properties of a booking, in some cases, the `PropertiesWereAlreadyModified` error would incorrectly be returned.

From now on, when booking properties are updated, the master agent that processes the update will check whether the properties to be updated are existing properties of the booking in question. If so, the update will complete successfully, and no false `PropertiesWereAlreadyModified` errors will be returned.

#### Relational anomaly detection: Old RAD suggestion events would incorrectly be re-opened when a paused element was re-activated [ID 43688]

<!-- MR 10.6.0 - FR 10.5.11 -->
<!-- Not added to MR 10.6.0 -->

When an element with active RAD suggestion events is paused, in the Alarm Console, these suggestion events will disappear from the active alarms tab.

Up to now, when a paused element was re-activated, the suggestion events that had disappeared from the active alarms tab would incorrectly be re-opened again. From now on, they will no longer be re-opened. If the anomalous behavior persists when a paused element is re-activated, new RAD suggestion events will be generated instead.

#### STaaS: Data missing from heatmaps and alarm state pie charts [ID 43689]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When, in a client application connected to a system using STaaS, you viewed a heatmap or an alarm state pie chart, in some cases, an incorrect time zone conversion would cause those charts to not include all available data.

#### Service & Resource Management: No master agent would incorrectly get selected on systems with only a ResourceManager license [ID 43697]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, only on systems with both a ResourceManager license and a ServiceManager license would a master agent get selected.

From now on, a master agent will also get selected on systems with only a ResourceManager license. On these systems, the agent with the lowest DMA ID will always be promoted to master agent.

Also, when no master agent can be selected because the ResourceManager license is missing, the following log entry will be added to the SLMasterSyncerManager log file (with XXX being the IDs of the agents that do not have a ResourceManager license):

`WARNING: No master DMA could be picked. Missing required ResourceManager license for DMAs XXX.`

#### Swarming: Outdated data could remain in the SLNet event cache after an element had been swarmed [ID 43729]

<!-- MR 10.6.0 - FR 10.5.11 -->
<!-- Not added to MR 10.6.0 -->

After an element had been swarmed, in some cases, outdated data could remain in the SLNet event cache.

#### Swarming an element while automatic incident tracking was disabled would cause the alarms of that element to be removed from any user-defined alarm group they were in [ID 43739]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

If automatic incident tracking was disabled and an element had an alarm that had been manually added to an alarm group, up to now, swarming that element would cause that alarm to incorrectly be removed from the alarm group and appear again as a separate alarm. This will no longer occur.

If an element gets swarmed while automatic incident tracking is enabled, the behavior remains the same as before: Manually created groups keep their elements, but any active relational anomalies (including automatically created alarm groups) involving the element are cleared.

#### Problem when importing a DELT package containing average trend data into a Cassandra Cluster or STaaS database [ID 43768]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, after you had imported a DELT package containing average trend data into a Cassandra Cluster or STaaS database, that database would contain invalid trend data.

#### Failover: Problem when trying to update the failover configuration when the ClusterEndpointsManager soft-launch option had been disabled [ID 43794]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, it would not be possible to update the failover configuration when the *ClusterEndpointsManager* soft-launch option had explicitly been disabled.

#### Automation: No longer possible to send an email report in a C# code block after having selected a dashboard created by means of the Dashboards app [ID 43822]

<!-- MR 10.6.0 - FR 10.5.11 -->
<!-- Not added to MR 10.6.0 -->

Since DataMiner feature version 10.5.10, in Automation, it would incorrectly no longer be possible to send an email report in a C# code block after having selected a dashboard created by means of the Dashboards app.
