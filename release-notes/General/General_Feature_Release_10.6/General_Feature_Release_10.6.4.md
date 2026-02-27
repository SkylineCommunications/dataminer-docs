---
uid: General_Feature_Release_10.6.4
---

# General Feature Release 10.6.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)
>
> - Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution. For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).
>
>   See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.4](xref:Cube_Feature_Release_10.6.4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.4](xref:Web_apps_Feature_Release_10.6.4).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### New BPA test: Detect unsupported connector versions [ID 44607]

<!-- MR 10.7.0 - FR 10.6.4 -->

From now on, a new BPA test named *Detect unsupported connector versions* will run every day to check for elements that are using connector versions that have been removed from the Catalog.

When a connector version is removed from the Catalog, this means that it is no longer supported by Skyline Communications. Using unsupported connector versions can lead to compatibility issues, lack of support, and potential security vulnerabilities. It is important to regularly check for unsupported connector versions and update them to supported versions to ensure optimal performance and security of the system.

#### Automation: Time zone of the client can now be passed to the automation script that is executed [ID 44742]

<!-- MR 10.7.0 - FR 10.6.4 -->

When an automation script is executed, it is now possible to pass the time zone of the client to that script.

In the `ExecuteScriptMessage`, you can add the time zone information to the string parameter array in the following format:

`CLIENT_TIME_ZONE:<Serialized TimeZone String>`

Example: `CLIENT_TIME_ZONE:Tokyo Standard Time;540;(UTC+09:00) Osaka, Sapporo, Tokyo;Tokyo Standard Time;Tokyo Summer Time;;`

In the automation script, the time zone will be available on the `IEngine` input argument:

`engine.ClientInfo.TimeZone`

> [!NOTE]
>
> - If the script was executed from a source other than a web app, or if the time zone information could not be parsed, the `TimeZone` property can be null.
> - In case a subscript is executed, the `ClientInfo` of the parent script will also be available in the subscript.

## Changes

### Breaking changes

#### SNMP trap binding values will now only display plain ASCII characters [ID 44527]

<!-- MR 10.7.0 - FR 10.6.4 -->

When the system receives a trap binding value of type OctetString, that value will either be automatically converted into characters (e.g., 0x41 will become "A") or remain in a hexadecimal string format (e.g., when the value contains a byte that is not printable like 0x02, which is an STX control character).

Up to now, hexadecimal values above the ASCII range (i.e., values >= 0x7F) were considered printable characters, and were not converted into a hexadecimal string. This would cause issues with, for example, the Unicode control character 0x8C, which would be displayed as a question mark. In such cases, complex QAction code would then be required to have it converted back into a hexadecimal value.

Also, DataMiner is not aware of whether a binding value actually contains text (e.g., a MAC address consisting of octets) or, if the value contains text, how that text was encoded (e.g., Windows code page 1252, UTF-8, UTF-16, etc.).

From now on, hexadecimal values outside of the ASCII range will be considered non-printable characters, and will remain in hexadecimal string format.

This is a breaking change.

Up to now, text containing characters that were encoded in extended ASCII (i.e., Windows code page 1252) were converted from raw octets into string text. For example, the French word "hélicoptère" would be received correctly. From now on, that same word will be received as hexadecimal string "68e96c69636f7074e87265", and a QAction will need to convert it back into a string using the correct encoding.

### Enhancements

#### BPA test 'Large Alarm Trees' will now run on a daily basis [ID 44565]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

From now on, the *Large Alarm Trees* BPA test will run on a daily basis, and will now generate an error or a warning in the following cases:

- It will generate an error when there is at least one alarm tree that consists of 5000 or more alarms. Only the alarm trees that have reached this size will be returned in the detailed result.

- It will generate a warning when there is at least one alarm tree that consists of 1000 or more alarms, but all alarm trees have less than 5000 alarms. Only the alarm trees that have reached this size will be returned in the detailed result.

Also, no notice will be generated anymore when alarm trees are getting large. As a result, in the `AlarmSettings` section of the *MaintenanceSettings.xml* file, the `recurring` attribute of the `AlarmsPerParameter` element is now obsolete.

#### Security enhancements [ID 44579] [ID 44821]

<!-- 44579: MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->
<!-- 44821: MR 10.6.0 [CU1] - FR 10.6.4 -->

A number of security enhancements have been made.

#### DataMiner Objects Models: Selected subset of fields from DomInstance objects will now be read from the repository API [ID 44600]

<!-- MR 10.7.0 - FR 10.6.4 -->

Since DataMiner 10.6.0/10.6.1, it is possible to read only a selected subset of fields from `DomInstance` objects. In order to further enhance performance, from now on, those subsets will be read from the repository API.

Currently, the repository API will still request the full objects from the database and extract the required values.

> [!NOTE]
> When a field value is requested, the type defined in the field descriptor will be used. In order to determine that type, field descriptor IDs should be unique across section definitions in a DOM module.

#### SLDataGateway: StorageTypeNotFoundException will now always mention the StorageType that could not be found [ID 44603]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLDataGateway throws a `StorageTypeNotFoundException`, from now on, the message will always mention the StorageType that could not be found.

#### An updated parameter value will no longer be written to the database if it is equal to the old value [ID 44609]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a user or a QAction updated a parameter value, up to now, the new value would always be written to the database, even when the new value was equal to the old value.

From now on, when the new value is equal to the old value, the value will no longer be written to the database. If any triggers or QActions are configured to be executed following a parameter update, these will still be executed.

Also, write parameters will no longer be saved as this would cause unnecessary load.

#### NotifyMail.html has been updated in order to better support both classic Microsoft Outlook and new Microsoft Outlook [ID 44617]

<!-- MR 10.7.0 - FR 10.6.4 -->

The `C:\Skyline DataMiner\NotifyMail.html` file, i.e., the email report template, has been updated to better support both classic Microsoft Outlook and new Microsoft Outlook.

#### Enhanced distribution of SNMPv3 traps [ID 44626]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a DMA receives an SNMPv3 trap that it cannot process (e.g., because the SNMPv3 user is unknown), and trap distribution is enabled, from now on, the trap will be distributed to the other DMAs in the cluster in an attempt to have it processed by one of those other DMAs.

Also, in some cases, traps could be forwarded to the wrong elements because the SNMPv3 USM ID was not validated correctly.

#### SLDataGateway: Job queue updates will now be logged in SLJobQueues.txt [ID 44661]

<!-- MR 10.7.0 - FR 10.6.4 -->

Up to now, log entries regarding SLDataGateway job queue updates would be logged in the `C:\Skyline DataMiner\Logging\SLDbConnection.txt` file.

From now on, these log entries will be logged in the `C:\Skyline DataMiner\Logging\SLDataGateway\SLJobQueues.txt` file instead.

#### Enhanced performance when filtering history alarms using complex filters [ID 44664]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Because of a number of enhancements, overall performance has increased when filtering history alarms using complex filters.

Performance has especially increased using filters that consist of multiple equality conditions involving the following types of objects:

- Element
- Function
- Protocol
- Service
- View

> [!NOTE]
>
> - Non-equality and wildcard/regex filtering has not been altered.
> - If more than 1,000 elements are affected, filtering will revert to the legacy behavior.

#### SLLogCollector: Separate log file per instance [ID 44668]

<!-- MR 10.7.0 - FR 10.6.4 -->

Up to now, all SLLogCollector logging of all SLLogCollector instances would end up in the following files, stored in the `C:\ProgramData\Skyline\DataMiner\SL_LogCollector\Log` folder:

- `SL_LogCollector_fulllog.log`
- `SL_LogCollector_log.log`

From now on, each SLLogCollector instance will have its own dedicated log file named `log-[creation timestamp].txt`, stored in the `C:\ProgramData\Skyline Communications\SLLogCollector` folder.

Up to 10 log files will be kept on disk, and the log file of the current instance will be added to the SLLogCollector package.

#### Enhanced performance when activating DaaS systems [ID 44737]

<!-- MR 10.6.0 [CU1] - FR 10.6.4 -->

Because of a number of enhancements, overall performance has increased when activating DaaS systems.

#### Enhanced performance when executing a full element update on STaaS systems with Swarming enabled [ID 44772]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Because of a number of enhancements, on STaaS systems with Swarming enabled, overall performance has increased when executing a full element update.

### Fixes

#### Problem with SLNet when receiving a subscription with a large filter that contained wildcards [ID 44512]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLNet received a dynamic table subscription with a very large filter that contained wildcards, up to now, it would throw a stack overflow exception and stop working.

From now on, SLNet subscriptions will now be blocked when they contain a filter that exceeds 140,000 characters.

#### SLNetClientTest tool: External authentication would not work when the Microsoft Edge (WebView2) browser engine was installed on a per user basis [ID 44583]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When you connected to a DataMiner Agent, up to now, it would not be possible to use external authentication from a client computer on which the Microsoft Edge (WebView2) browser engine was installed on a per user basis.

> [!NOTE]
> When the Microsoft WebView2 browser engine is installed on a per user basis, it will be automatically updated each time you open Microsoft Edge.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Problem with SLDataMiner after sending an NT_READ_SAVED_PARAMETER_VALUE call [ID 44597]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU1] - FR 10.6.4 -->

When an NT_READ_SAVED_PARAMETER_VALUE call was sent to retrieve data from an element without a connector while that data was still present in SLDataGateway, up to now, SLDataMiner could stop working.

#### Data would not show up in DVE child elements due to a problem with foreign key linking to logger tables [ID 44651]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some cases, a problem with foreign key linking to logger tables would cause data to not show up in DVE child elements.

#### Alarm properties passed along by Correlation or SLAnalytics could get lost when an alarm was created [ID 44669]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some cases, alarm properties passed along by Correlation or SLAnalytics could get lost when an alarm was created.

#### API Gateway would incorrectly add multiple routes with the same basePath when multiple registration requests were received for the same route [ID 44676]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When multiple registration requests were received for the same route, in some cases, instead of updating the route, API Gateway would incorrectly add multiple routes with the same basePath. As a result, the proxy would not be able to route the HTTP request.

#### Failover: Two Agents in a Failover pair could get stuck during startup [ID 44680]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some cases, the two Agents in a Failover pair could get stuck during startup.

#### Scheduler: Windows task will no longer be recreated when only the actions of a scheduled task were changed [ID 44691]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a scheduled task was updated close to its execution time, in some cases, the task would incorrectly not be executed. It would miss its execution window because, during the update, the Windows task would be deleted and recreated again.

From now on, when only the task actions are changed during an update of a scheduled task, the Windows task will no longer be recreated. The latter will only be recreated when the status, name, description, or timing of the scheduled task are changed.

#### History set trending would show gaps where no gaps were expected [ID 44705]

<!-- MR 10.7.0 - FR 10.6.4 -->

Up to now, history set trending would show gaps where no gaps were expected.

From now on, trend records with the following *iStatus* values will no longer cause gaps in trend graphs:

| Value | Description |
|-------|-------------|
| -1  | Element is starting up. |
| -2  | Element is being paused. |
| -3  | Element is being activated. |
| -4  | Element is going into a timeout state. |
| -5  | Element is coming out of a timeout state. |
| -6  | Element is being stopped. |
| -9  | Trending was started for the specified parameter. |
| -10 | Trending was stopped for the specified parameter. |

#### Problem with SLNet when rolling over log files [ID 44711]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some cases, SLNet could stop working when rolling over from one log file to another (e.g., from *SLNet.txt* to *SLNet0.txt*).

From now on, when an issue occurs when rolling over log files, an error will be logged in the Windows Event Viewer.

> [!NOTE]
> Some logging may get lost because of this fix.

#### BrokerGateway installation could fail when the nsc.exe file was locked by an antivirus application [ID 44721]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Up to now, a BrokerGateway installation could fail when the *nsc.exe* file was locked by an antivirus application.

From now on, a locked *nsc.exe* file will no longer cause a BrokerGateway installation to fail.

#### Problem with SLAnalytics during the storage initialization routine [ID 44745]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some rare cases, the SLAnalytics process could stop working during the storage initialization routine.

#### Problem with SLAnalytics when trying to process an invalid database record [ID 44748]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some cases, SLAnalytics would stop working when trying to process an invalid database record after having serialized it.

#### Problem when an alarm was updated while a hysteresis timer was scheduled [ID 44749]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When an alarm was updated while a hysteresis timer was scheduled, in some cases, the timestamp of the alarm update would be more recent than that of the alarm generated by the clear hysteresis. As a result, the state changes timeline would no longer be correct.

#### Problem with SLProtocol when multiple connections of the same element went into a timeout state simultaneously [ID 44752]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some rare cases, SLProtocol could stop working when multiple connections of the same element went into a timeout state simultaneously.

#### BPA test 'Check Deprecated DLL Usage' would incorrectly flag the MySql.Data NuGet as deprecated [ID 44758]

<!-- MR 10.6.0 [CU1] - FR 10.6.4 -->

Since DataMiner 10.5.12/10.6.0, the *Check Deprecated DLL Usage* BPA test would incorrectly flag the *MySql.Data* NuGet (*MySql.Data.dll*) as deprecated, especially when that file was located in `C:\Skyline Dataminer\ProtocolScripts\DllImport\` or one of its subfolders.

#### SLLogCollector: Problem when process dumps were triggered in parallel [ID 44780]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Up to now, when SLLogCollector tried to trigger process dumps in parallel, in some cases, certain dumps would not be added to the package.

From now on, in order to be able to include all dumps in the package, process dumps will no longer be triggered in parallel.

#### Incorrect error message would appear when a configuration mismatch prevented DataMiner Agents from being clustered [ID 44781]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a configuration mismatch prevented DataMiner Agents from being clustered, up to now, the following incorrect error message would appear:

`Cannot cluster Agents as remote Agent has an unsupported database type.`

From now on, the following correct error message will appear instead:

`Cannot cluster Agents as the agent configuration is incompatible. Please check SLNet logging for more information.`

#### Problem when an element was updated immediately after having been swarmed [ID 44783]

<!-- MR 10.6.0 [CU1] - FR 10.6.4 -->

When an element was updated immediately after having been swarmed from one host to another, in some cases, it would incorrectly re-appear on its former host.

#### STaaS: Retrieving the active alarms of an element would incorrectly be limited to 10,000 [ID 44793]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Up to now, if an element had more than 10,000 active alarms, on STaaS systems, only the first 10,000 would incorrectly be retrieved.

From now on, all active alarms will be retrieved, even if the element in question has more than 10,000 active alarms.
