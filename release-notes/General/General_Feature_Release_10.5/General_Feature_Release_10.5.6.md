---
uid: General_Feature_Release_10.5.6
---

# General Feature Release 10.5.6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

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

- [Automation: Separate log file for every automation script that is run [ID 42572]](#automation-separate-log-file-for-every-automation-script-that-is-run-id-42572)

## New features

#### New NotifyProtocol call NT_CLEAR_PARAMETER [ID 42368] [ID 42397]

<!-- RN 42397: MR 10.6.0 - FR 10.5.6 -->
<!-- RN 42368: MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

A new NotifyProtocol call *NT_CLEAR_PARAMETER* (474) can now be used to clear tables and single parameters. When used, it will also clear the parameter's display value and save any changes when the parameter is saved.

Internally, this new *NT_CLEAR_PARAMETER* call will now also be used by the existing SLProtocol function `ClearAllKeys()`. As a result, the latter will now be able to clear tables of which the RTDisplay setting was not set to true.

> [!NOTE]
>
> - *NT_CLEAR_PARAMETER* cannot be used to clear table columns.
> - This new NotifyProtocol method can be invoked from within a QAction by using the `protocol.ClearParameter(<paramId>`) function.
> - When using `ProtocolExt`, you can now use e.g., `protocol.getRequests.Clear()` to clear a table parameter named *getRequests*. Internally, this new `Clear()` function will then execute a `protocol.ClearAllKeys(<getRequests parameter ID>)` call.

#### Automation: Separate log file for every automation script that is run [ID 42572]

<!-- MR 10.6.0 - FR 10.5.6 -->

From now on, when an automation script is run, every entry that is logged in the *SLAutomation.txt* file by the `Engine.Log` method will also be logged in a separate log file located in `C:\Skyline DataMiner\Logging\Automation\`. That log file will have a name that is identical to that of the automation script.

- The first time an automation script is run, a log file will be created in `C:\Skyline DataMiner\Logging\Automation\` for that particular script.
- After a DataMiner restart, the first time a script is executed, its existing log file will get the "_Bak" suffix and a new log file will be created.
- If an automation script is renamed, a new log file will be created with a name identical to that of the renamed script. The old file will be kept.
- If you want to configure a custom log level for a particular automation script, send an `UpdateLogfileSettingMessage` in which *Name* is set to "Automation\ScriptName". If no custom log configuration exists for a particular automation script, the default configuration will be used.
- These new automation script log files will also be included in SLLogCollector packages.
- Each time a DataMiner upgrade package is installed, all automation script log files will be deleted.

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
>
> - In the automation script log file, you will find an indication of when the script execution started and stopped. However, this indication will be slightly different from the one you will find in the *SLAutomation.txt* log file. The one in the *SLAutomation.txt* log file will represent the total time it took for the script to run, while the one in the script log file will only take into account the C# blocks in the automation script.
> - For each entry that is logged in one of the above-mentioned script log files, an identical copy will also be logged in the *SLAutomation.txt* file. However, note that the timestamps of both entries may not be identical.

#### SNMPv3: Parameter value can now be used as context name or context ID when executing an SNMP get or set command [ID 42676]

<!-- MR 10.6.0 - FR 10.5.6 -->

In a connector of an SNMPv3 element, it is now possible to indicate that the value of a specific parameter should be used as context name or context ID whenever an SNMP get command or an SNMP set command is executed on the particular connection.

To define that the value of a particular parameter should be used as context name for connection 0, specify the following:

```xml
<Param ...>
    ...
    <SNMP options="ContextName:0"/>
    ...
</Param>
```

To define that the value of a particular parameter should be used as context ID for connection 0, specify the following:

```xml
<Param ...>
    ...
    <SNMP options="ContextID:0"/>
    ...
</Param>
```

If the parameter is not initialized or is set to an empty string, the default parameter value will be used (i.e., an empty string).

The context name and context ID can be changed at runtime, and are not saved by default. When the element is restarted, the parameter data will be lost unless the `save` attribute of the parameter was set to true (e.g., `<Param id="1" save="true">`).

## Changes

### Enhancements

#### VerifyNatsIsRunning prerequisite check has now been replaced by the VerifyNatsCluster check [ID 42206]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

The *VerifyNatsIsRunning* prerequisite check has now been replaced by the *VerifyNatsCluster* check.

This check, which is included in upgrade packages, verifies whether the crucial NATS service used by DataMiner is running on all required DataMiner Agents and whether communication between all NATS nodes is possible.

The same prerequisite is also available as a BPA test in System Center.

This prerequisite check prevents situations where a DataMiner System becomes non-functional after an upgrade because of pre-existing issues with NATS. If this check fails, [troubleshoot NATS](xref:Investigating_NATS_Issues) before continuing the upgrade.

#### Service & Resource Management: Enhanced locking mechanism in ID cache and Time range cache [ID 42463]

<!-- MR 10.6.0 - FR 10.5.6 -->

Because of a number of enhancements, the locking mechanism in the following Resource Manager caches has been improved.

| Cache | Description |
|---|---|
| ID cache | When a specific ReservationInstance is requested by ID, the result is cached in this ID cache. When an internal request is made for a specific ID, the cached ReservationInstance will be returned. Used when adding or editing ReservationInstances and when executing start/stop actions and ReservationEvents. |
| Time range cache | When ReservationInstances within a specific time range are requested, all instances in that time range will be cached in this cache. Used when new bookings are created or when eligible resources are requested. |

#### Executing automation scripts using a Run method or a custom entry point containing the async keyword is no longer supported [ID 42534]

<!-- MR 10.6.0 - FR 10.5.6 -->

From now on, when an automation script is executed asynchronously using either a `Run` method or a custom entry point containing the `async` keyword, an error message will appear, mentioning that this is not supported.

In that error message, users will also be directed to the [documentation](https://aka.dataminer.services/AsyncAutomation) for more information on handling async code.

#### SLAnalytics: Enhanced caching of DVE element information [ID 42555]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

A number of enhancements have been made with regard to the caching of DVE element information.

#### SLAnalytics - Relational anomaly detection: Upon deletion of a parameter group all open suggestion events associated with that group will be cleared [ID 42602]

<!-- MR 10.6.0 - FR 10.5.6 -->

When you delete a Relational Anomaly Detection (RAD) parameter group, from now on, all open suggestion events associated with that parameter group will automatically be cleared.

#### NotifyMail.html: Updated report footer [ID 42567]

<!-- MR 10.6.0 - FR 10.5.6 -->

In the `C:\Skyline DataMiner\NotifyMail.html` file, i.e., the email report template, the report footer has been updated to `Generated by DataMiner`.

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

#### SLAnalytics - Relational anomaly detection: Model training will start immediately after a parameter group was created [ID 42661]

<!-- MR 10.6.0 - FR 10.5.6 -->
<!-- Not added to MR 10.6.0 -->

Up to now, when you created a new Relational Anomaly Detection (RAD) parameter group, the system would wait until the group was active for 5 minutes before training the model. From now on, when a new Relational Anomaly Detection (RAD) parameter group is created, the system will immediately start to train the model.

#### DxMs upgraded [ID 42688]

<!-- MR 10.6.0 - FR 10.5.6 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.3
- DataMiner CoreGateway 2.14.12
- DataMiner FieldControl 2.11.2
- DataMiner Orchestrator 1.7.5
- DataMiner SupportAssistant 1.7.3

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### Protocols: Configuring an override parameter to replace the nominal smart baseline value of a column parameter [ID 42712]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In the [type](xref:Protocol.Params.Param.Alarm-type) attribute of the *Protocol.Params.Param.Alarm* tag, it is now possible to configure an override parameter for a column parameter.

If an override parameter is configured in the protocol, the smart baseline calculation will first check if a value is configured in the override parameter and if a value is present. If that value is not an exception value, it will take this value and copy it to the nominal value parameter instead of trying to calculate a nominal value whenever the smart baseline timer elapses.

To configure an override parameter, use the following syntax:

```xml
<Alarm type="absolute:NOMINAL_VALUE_PID,FACTOR_PID,OVERRIDE_PID">
```

> [!NOTE]
>
> - The `FACTOR_PID` is optional and can be left empty.
> - The ID of the override parameter (`OVERRIDE_PID`) is the third value in the comma-separated list. The `OVERRIDE_PID` value must be (a) the parameter ID of a column in the same table as the source column or (b) the parameter ID of a standalone column. Any other parameter ID will not work.

#### SLAnalytics - Relational anomaly detection: No more references to 'MAD' in RAD API [ID 42738]

<!-- MR 10.6.0 - FR 10.5.6 -->
<!-- Not added to MR 10.6.0 -->

In all messages of the Relational Anomaly Detection API, the term "MAD" has now been replaced by "RAD". For example:

- A new `TimeRange` class has now been added to the `Skyline.DataMiner.Analytics.Rad` namespace, and in `RetrainRADModelMessage`, a field using that type has been added.

- A new `RadDataPoint` class has been added, and in `GetRADDataResponseMessage`, a field using that type has been added.

Also, all objects that referred to items containing "MAD" have now been deprecated.

#### Security enhancements [ID 42747] [ID 42843]

<!-- 42747: MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 [CU0] -->
<!-- 42843: MR 10.3.0 [CU22]/10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 [CU0] -->

A number of security enhancements have been made.

#### SLNetClientTest tool - DataMiner Object Model: Enhancements made to the ModuleSettings window [ID 42788]

<!-- MR 10.6.0 - FR 10.5.6 -->

A number of enhancements have been made to the *ModuleSettings* window.

- When, in the *ModuleSettings* window, you delete an entire DOM module, the DOM instances in that module will now be deleted in bulk, and the maximum number of DOM instances that can be deleted in one go has been increased from 10,000 to 100,000. Also, the estimation of the cleanup time will now be more accurate, and the cleanup message will now refer to the [Removing DOM indices in Elasticsearch or OpenSearch](xref:DOM_data_storage#removing-dom-indices-in-elasticsearch-or-opensearch) section in docs.dataminer.services.

- When, in the *ModuleSettings* window, you click *Open* to see the details of a DOM module, and then go to the *Statistics* tab, it is now possible to sort the statistics by a particular column. Also, a number of enhancements have been made to have the data on the tab displayed more clearly.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

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

#### Problem with SLAutomation when a Notify method was called shortly after an automation script had finished [ID 42465]

<!-- MR 10.6.0 - FR 10.5.6 -->

When a Notify method was called from a thread created within an automation script shortly after that automation script had finished, in some cases, the SLAutomation process could stop working.

#### Redundancy groups: Matrix parameter updates in a derived element would incorrectly not get applied in the source element (and vice versa) [ID 42598]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When, within a redundancy group, a matrix parameter in a derived element was updated, in some cases, that same matrix parameter would incorrectly not get updated in the source element (and vice versa).

#### SLHelper - GQI: Log entry of caught exception would incorrectly not include all details [ID 42608]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

On systems using the SLHelper process for GQI-related operations, up to now, an exception thrown when using a custom implementation of an ad hoc data source would be caught, but the log entry would incorrectly not include the full message. From now on, the log entry will include all details of the exception that was thrown.

#### Problem when starting an element with DCF connections towards a previously deleted element [ID 42632]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When an element that had DCF connections towards a previously deleted element was started, in some cases, an "unhandled exception" notice could appear in the Alarm Console. Also, as a result of the exception, the element's connection information would not be available in SLNet and DataMiner Cube, and no connection lines would be displayed for the connections in question.

#### SNMP forwarding: Inconsistent messages in alarm storm information events [ID 42642]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

SNMP managers generate an information event each time an alarm storm starts and ends.

Up to now, the word "SNMP manager" would not be spelled consistently in both messages. The information event announcing the start of an alarm storm would start with `Alarmstorm for SNMP Manager: ...`, while the information event announcing the end of an alarm storm would start with `Alarmstorm for SNMPManager: ...`

From now on, both information events will start with `Alarmstorm for SNMP Manager: ...`

#### ModelHost DxM would stop working when it failed to retrieve a proxy endpoint [ID 42651]

<!-- MR 10.6.0 - FR 10.5.6 -->

At startup, up to now, the ModelHost DxM would stop working when it failed to retrieve a proxy endpoint. From now on, when it fails to retrieve a proxy endpoint, it will retry until it succeeds.

#### Swarming: Certain alarm event messages would be logged incorrectly in SLDataMiner.txt [ID 42671]

<!-- MR 10.6.0 - FR 10.5.6 -->
<!-- Not added to MR 10.6.0 -->

On swarming-enabled systems with information log level set to 2 or above, certain alarm event messages would be logged incorrectly in the *SLDataMiner.txt* log file.

#### Problem with trend windows after switching from daylight saving time to standard time [ID 42685]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In some rare cases, trend windows could get stuck in SLDataGateway after switching from daylight saving time to standard time.

#### VerifyClusterPorts: Log entries would incorrectly ask you to check the DMS.xml file when using the BrokerGateway-managed NATS solution [ID 42701]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

When the *VerifyClusterPorts* prerequisite failed, up to now, its log entries would incorrectly always ask you to check the *DMS.xml* file, regardless of whether the system was using the legacy SLNet-managed NATS solution or the BrokerGateway-managed NATS solution introduced in DataMiner 10.5.0 [CU2]/10.5.5.

From now on, the *VerifyClusterPorts* log entries will ask you to check the following file, depending on the NATS solution the system is using:

| NATS solution being used | File mentioned in VerifyClusterPorts log entries |
|---|---|
| SLNet-managed NATS solution         | DMS.xml               |
| BrokerGateway-managed NATS solution | ClusterEndpoints.json |

#### SLNet protocol cache would incorrectly retain the names of deleted protocols [ID 42710]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In some rare cases, the SLNet protocol cache would incorrectly retain the names of deleted protocols.

#### 'Register DataMiner as Service.bat' would incorrectly register services as 32-bit services [ID 42713]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In some cases, the Windows batch file *Register DataMiner as Service.bat* would incorrectly assume that a machine was running a 32-bit operating system. As a result, it would incorrectly register services as 32-bit services.

As 32-bit Windows systems are no longer supported, from now on, the *Register DataMiner as Service.bat* file will no longer check the architecture of the operating system.

#### GQI DxM: Problem when using certain extensions because of issues with named pipes [ID 42782]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

In order to communicate with its extension processes, the GQI DxM uses named pipes. In some cases, because a pipe would fail to connect to the core GQI process, it would no longer be possible to use a particular extension.

Additionally, a number of enhancements have been made with regard to the management of named pipes.

#### Antivirus software could incorrectly flag DcomConfig.exe as a virus and remove it from the system [ID 42979]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 [CU0] -->

Since DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5, some antivirus software could incorrectly flag `C:\Skyline DataMiner\tools\DcomConfig.exe` as a virus and remove it from the system. As a result, DataMiner upgrades would fail.
