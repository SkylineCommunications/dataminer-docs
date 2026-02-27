---
uid: General_Main_Release_10.6.0_CU1
---

# General Main Release 10.6.0 CU1 - Preview

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

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU1](xref:Cube_Main_Release_10.6.0_CU1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU1](xref:Web_apps_Main_Release_10.6.0_CU1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLManagedScripting will again add a log entry each time it has loaded or failed to load an assembly [ID 44522]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU1] - FR 10.6.3 -->

Since DataMiner version 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9<!-- RN 43690 -->, SLManagedScripting no longer added an entry in the *SLManagedScripting.txt* log file each time it had loaded or failed to load an assembly. From now on, it will again do so.

These log entries will include both the requested version and the actual version of the assembly.

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

#### SLDataGateway: StorageTypeNotFoundException will now always mention the StorageType that could not be found [ID 44603]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLDataGateway throws a `StorageTypeNotFoundException`, from now on, the message will always mention the StorageType that could not be found.

#### An updated parameter value will no longer be written to the database if it is equal to the old value [ID 44609]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a user or a QAction updated a parameter value, up to now, the new value would always be written to the database, even when the new value was equal to the old value.

From now on, when the new value is equal to the old value, the value will no longer be written to the database. If any triggers or QActions are configured to be executed following a parameter update, these will still be executed.

Also, write parameters will no longer be saved as this would cause unnecessary load.

#### Enhanced distribution of SNMPv3 traps [ID 44626]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a DMA receives an SNMPv3 trap that it cannot process (e.g., because the SNMPv3 user is unknown), and trap distribution is enabled, from now on, the trap will be distributed to the other DMAs in the cluster in an attempt to have it processed by one of those other DMAs.

Also, in some cases, traps could be forwarded to the wrong elements because the SNMPv3 USM ID was not validated correctly.

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

#### Enhanced performance when activating DaaS systems [ID 44737]

<!-- MR 10.6.0 [CU1] - FR 10.6.4 -->

Because of a number of enhancements, overall performance has increased when activating DaaS systems.

#### Enhanced performance when executing a full element update on STaaS systems with Swarming enabled [ID 44772]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Because of a number of enhancements, on STaaS systems with Swarming enabled, overall performance has increased when executing a full element update.

### Fixes

#### MessageBroker: Problem with hostnames and FQDNs containing a certain combination of dashes and characters [ID 44433]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU1] - FR 10.6.3 -->

Up to now, hostnames and FQDNs in the *MessageBrokerConfig.json* file would incorrectly be considered invalid when they contained a certain combination of dashes and characters.

Examples of hostnames that were incorrectly considered invalid:

- Hostnames that start with one letter or number, followed by a dash. For example, `a-agent`, `h-hostname`, etc.
- Full IPv6 addresses like `[2001:0db8:85a3:0000:0000:8a2e:0370:7334]`
- Shortened IPv6 addresses like `[::1]`

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

Since DataMiner 10.5.12/10.6.0, the *Check Deprecated DLL Usage* BPA test would incorrectly flag the *MySql.Data* NuGet (*MySql.Data.dll*) as deprecated.

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
