---
uid: General_Feature_Release_10.5.6
---

# General Feature Release 10.5.6 – Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.6](xref:Cube_Feature_Release_10.5.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.6](xref:Web_apps_Feature_Release_10.5.6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Tracking DataMiner app package contents via SLNet [ID 42353]

<!-- MR 10.6.0 - FR 10.5.6 -->

`AppPackageContent` classes have now been added to SLNet. These classes can be accessed via `AppPackageContentHelper`, and will allow you to track which items (e.g. connectors, Automation scripts, etc.) were installed using a *.dmapp* package.

Using these classes, you can add, update and delete AppPackageContent records in bulk. Each record will contain the following fields:

- ID (GUID)
- DmappName (string)
- DmappVersion (string)
- DmappCatalogGuid (GUID)
- ContentType (type of installed item)
- ContentName (unique identifier per type)
- ContentHash (hash of the content at installation, which will allow tracking changes)

By default, all users will have read access to these records, but only users with *Install Application Package* permission will be able to edit them.

> [!IMPORTANT]
> This functionality will only work on systems using STaaS or systems using an OpenSearch/Elasticsearch indexing database. It will not work on systems using a Cassandra database.

#### New NotifyProtocol call NT_CLEAR_PARAMETER [ID 42368] [ID 42397]

<!-- RN 42397: MR 10.6.0 - FR 10.5.6 -->
<!-- RN 42368: MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

A new NotifyProtocol call *NT_CLEAR_PARAMETER* (474) can now be used to clear tables and single parameters. When used, it will also clear the parameter's display value and save any changes when the parameter is saved.

Internally, this new *NT_CLEAR_PARAMETER* call will now also be used by the existing SLProtocol function `ClearAllKeys()`. As a result, the latter will now be able to clear tables of which the RTDisplay setting was not set to true.

> [!NOTE]
>
> - *NT_CLEAR_PARAMETER* cannot be used to clear table columns.
> - This new NotifyProtocol method can be invoked from within a QAction by using the protocol.ClearParameter(<paramId>) function.
> - When using `ProtocolExt`, you can now use e.g. `protocol.getRequests.Clear()` to clear a table parameter named *getRequests*. Internally, this new `Clear()` function will then execute a `protocol.ClearAllKeys(<getRequests parameter ID>)` call.

#### Automation: Separate log file for every Automation script that is run [ID 42572]

<!-- MR 10.6.0 - FR 10.5.6 -->

From now on, when an Automation script is run, every entry that is logged in the *SLAutomation.txt* file by the `Engine.Log` method will also be logged in a separate log file located in `C:\Skyline DataMiner\Logging\Automation\`. That log file will have a name that is identical to that of the Automation script.

- The first time an Automation script is run, a log file will be created in `C:\Skyline DataMiner\Logging\Automation\` for that particular script.
- After a DataMiner restart, the first time a script is executed, its existing log file will get the "_Bak" suffix and a new log file will be created.
- If an Automation script is renamed, a new log file will be created with a name identical to that of the renamed script. The old file will be kept.
- If you want to configure a custom log level for a particular Automation script, send an `UpdateLogfileSettingMessage` in which *Name* is set to "Automation\ScriptName". If no custom log configuration exists for a particular Automation script, the default configuration will be used.
- These new Automation script log files will also be included in SLLogCollector packages.
- Each time a DataMiner upgrade package is installed, all Automation script log files will be deleted.

Log entry format: `1|2|3|4|5|6|7|8`

1. Date/time
1. "SLManagedAutomation"
1. Method that created the log entry
1. Log type
1. Log level
1. Thread ID
1. Script run ID
1. Message

Example: `2025/04/01 16:31:31.813|SLManagedAutomation|RunSafe|INF|0|959|473|Example message`

> [!NOTE]
> In the Automation script log file, you will find an indication of when the script execution started and stopped. However, this indication will be slightly different from the one you will find in the *SLAutomation.txt* log file. The one in the *SLAutomation.txt* log file will represent the total time it took for the script to run, while the one in the script log file will only take into account the C# blocks in the Automation script.

## Changes

### Enhancements

#### VerifyNatsIsRunning prerequisite check has now been replaced by the VerifyNatsCluster check [ID 42206]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

The *VerifyNatsIsRunning* prerequisite check has now been replaced by the *VerifyNatsCluster* check.

This check, which is included in upgrade packages, verifies whether the crucial NATS service used by DataMiner is running on all required DataMiner Agents and whether communication between all NATS nodes is possible.

The same prerequisite is also available as a BPA test in System Center.

This prerequisite check prevents situations where a DataMiner System becomes non-functional after an upgrade because of pre-existing issues with NATS. If this check fails, [troubleshoot NATS](xref:Investigating_NATS_Issues) before continuing the upgrade.

#### SLAnalytics: Enhanced caching of DVE element information [ID 42555]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

A number of enhancements have been made with regard to the caching of DVE element information.

#### SLAnalytics - Relational anomaly detection: Upon deletion of a parameter group all open suggestion events associated with that group will be cleared [ID 42602]

<!-- MR 10.6.0 - FR 10.5.6 -->

When you delete a Relational Anomaly Detection (RAD) parameter group, from now on, all open suggestion events associated with that parameter group will automatically be cleared.

#### NotifyMail.html: Updated report footer [ID 42567]

<!-- MR 10.6.0 - FR 10.5.6 -->

In the `C:\Skyline DataMiner\NotifyMail.html` file, i.e. the email report template, the report footer has been updated to `Generated by DataMiner`.

#### MessageBroker: Enhanced performance when checking for local IP addresses [ID 42570]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

As the MessageBroker prefers to set up NATS connections using local IP addresses, up to now, it would request the local IP addresses from the DNS for every item in the list of NATS endpoints. From now on, it will request the local IP addresses from the DNS only once.

The IP addresses returned by the DNS will be cached for one minute only. This will prevent providing outdated information when connections have to be set up later on.

#### Cassandra Cluster: Enhanced performance when importing DELT packages [ID 42613]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

Because of a number of enhancements, overall performance has increased when importing DELT packages on systems with a database of type *Cassandra Cluster*, especially when those packages contain a large amount of trend data.

#### Additional SLNet log files [ID 42625]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

From now on, SLNet logging will not only be kept in the *SLNet.txt* log file. Certain entries will now also be kept in one of the following new log files, which will all be located in the `C:\Skyline DataMiner\Logging\SLNet\` folder.

| Log file | Contents |
|----------|----------|
| FacadeHandleMessage.txt | All SLNet log entries created by the `Facade.HandleMessage` method. |
| ReducedLog.txt          | All SLNet log entries that have not been added to any of the other new log files. |
| RepositoriesMessage.txt | All SLNet log entries created by the `SLNet.Repositories` method. |
| StartupLog.txt          | The first 1000 SLNet log entries added to the *SLNet.txt* log file after SLNet was started. |

> [!NOTE]
>
> - The existing *SLNet.txt* log file will remain unchanged.
> - Contrary to the *SLNet.txt* log file, which can have up to 3 rollover files (*[logfile]0.txt*), the above-mentioned new log files can only have one single rollover file each.

#### DxMs upgraded [ID 42688]

<!-- MR 10.6.0 - FR 10.5.6 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.3
- DataMiner CoreGateway 2.14.12
- DataMiner FieldControl 2.11.2
- DataMiner Orchestrator 1.7.5
- DataMiner SupportAssistant 1.7.3

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

### Fixes

#### Problem with SLProtocol when a protocol version was overwritten while an element using that protocol version was starting up [ID 42344]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When a protocol version was overwritten while an element using that protocol version was starting up, in some cases, the SLProtocol process could stop working. Also, this could result in alarms like the following being generated:

`Unexpected Exception [Exception from HRESULT: 0x8004024C]: The element is unknown.`

#### Problem when an element was swarmed immediately after being created or after having its state changed to Active, Stopped, Paused, etc. [ID 42381]

<!-- MR 10.6.0 - FR 10.5.6 -->
<!-- Not added to MR 10.6.0 -->

When an element was swarmed immediately after being created or after having its state changed to "Active", "Stopped", "Paused", etc., in some rare cases, SLNet modules could end up being confused about where the element was being hosted.

#### DataMiner not able to start up after installation [ID 42431]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

After installation, in some cases, DataMiner would not be able to start up because the *MessageBrokerConfig.json* file could not be found in the `C:\ProgramData\Skyline Communications\DataMiner\` folder.

#### Problem with SLAutomation when a Notify method was called shortly after an Automation script had finished [ID 42465]

<!-- MR 10.6.0 - FR 10.5.6 -->

When a Notify method was called from a thread created within an Automation script shortly after that Automation script had finished, in some cases, the SLAutomation process could stop working.

#### Redundancy groups: Matrix parameter updates in a derived element would incorrectly not get applied in the source element (and vice versa) [ID 42598]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When, within a redundancy group, a matrix parameter in a derived element was updated, in some cases, that same matrix parameter would incorrectly not get updated in the source element (and vice versa).

#### Problem when starting an element with DCF connections towards a previously deleted element [ID 42632]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When an element that had DCF connections towards a previously deleted element was started, in some cases, an "unhandled exception" notice could appear in the Alarm Console. Also, as a result of the exception, the element's connection information would not be available in SLNet and DataMiner Cube, and no connection lines would be displayed for the connections in question.

#### SNMP forwarding: Inconsistent messages in alarm storm information events [ID 42642]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

SNMP managers generate an information event each time an alarm storm starts and ends.

Up to now, the word "SNMP manager" would not be spelled consistently in both messages. The information event announcing the start of an alarm storm would start with `Alarmstorm for SNMP Manager: ...`, while the information event announcing the end of an alarm storm would start with `Alarmstorm for SNMPManager: ...`

From now on, both information events will start with `Alarmstorm for SNMP Manager: ...`

#### Problem with trend windows after switching from daylight saving time to standard time [ID 42685]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In some rare cases, trend windows could get stuck in SLDataGateway after switching from daylight saving time to standard time.

#### VerifyClusterPorts: Log entries would incorrectly always ask you to check the DMS.xml file [ID 42701]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

When the *VerifyClusterPorts* prerequisite failed, up to now, its log entries would incorrectly always ask you to check the *DMS.xml* file.

From now on, when necessary, the *VerifyClusterPorts* log entries will ask you to check *ClusterEndpoints.json* instead.

#### SLNet protocol cache would incorrectly retain the names of deleted protocols [ID 42710]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In some rare cases, the SLNet protocol cache would incorrectly retain the names of deleted protocols.

#### 'Register DataMiner as Service.bat' would incorrectly register services as 32-bit services [ID 42713]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In some cases, the Windows batch file *Register DataMiner as Service.bat* would incorrectly assume that a machine was running a 32-bit operating system. As a result, it would incorrectly register services as 32-bit services.

As 32-bit Windows systems are no longer supported, from now on, the *Register DataMiner as Service.bat* file will no longer check the architecture of the operating system.
