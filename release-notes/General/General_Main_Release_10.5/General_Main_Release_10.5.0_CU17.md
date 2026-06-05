---
uid: General_Main_Release_10.5.0_CU17
---

# General Main Release 10.5.0 CU17 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> Before you upgrade to this DataMiner version:
>
> - Make sure the Microsoft **.NET 10** hosting bundle is installed (download the latest Hosting Bundle under ASP.NET Core Runtime from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)). See also: [DataMiner upgrade: New prerequisite will check whether .NET 10 is installed](xref:General_Main_Release_10.5.0_CU10#dataminer-upgrade-new-prerequisite-will-check-whether-net-10-is-installed-id-44121).
> - Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU17](xref:Cube_Main_Release_10.5.0_CU17).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU17](xref:Web_apps_Main_Release_10.5.0_CU17).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### Exception.Source field will now be added to ErrorLog.txt when a managed process stops unexpectedly [ID 44722]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When a managed process stops unexpectedly, from now on, the contents of the exception's *Source* field will now be added to the *ErrorLog.txt* log file. This should provide more debug information.

#### GQI will now throw an exception when data is requested from a mediated table parameter [ID 45539]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Currently, because of server limitations, GQI is unable to retrieve parameter table data from DataMiner when that table is a mediated parameter. As a result, when you select a table of a mediated protocol in a client UI, that table will not contain any data, and will also not provide any details on why it does not do so.

From now on, when a query using the *Parameters for elements where* data source attempts to retrieve data from a mediated table parameter, GQI will throw an error. That error will indicate that the request is not valid because mediated tables are not supported, and will also mention the table or table columns involved.

#### SLElementInProtocol.txt log file entries will now be added by SLLog instead of SLProtocol [ID 45578]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Up to now, the *SLElementInProtocol.txt* log file entries were added by SLProtocol.

From now on, these log file entries will be added by SLLog instead.

#### SLLogCollector will now retrieve the value of the Windows security policy 'System cryptography: Use FIPS compliant algorithms for encryption, hashing, and signing' is enabled [ID 45592]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

From now on, SLLogCollector will also retrieve the value of the Windows security policy *System cryptography: Use FIPS compliant algorithms for encryption, hashing, and signing*.

DataMiner does not support having this policy enabled. Having this option enabled will prevent DataMiner from starting up properly.

### Fixes

#### History set trending would show gaps where no gaps were expected [ID 44705]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.4 -->

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

#### Visual Overview in web apps: Problem when creating a new window [ID 45517]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Because of the way Cube sessions are loaded in the SLHelper process when creating visual overviews, up to now, Windows could throw an exception creating a new window. This would cause the SLHelper process to crash, affecting all active Cube sessions.

From now on, the system will attempt to recreate the Cube session when the initial creation fails, and will handle any failures gracefully to ensure other sessions remain unaffected.

#### Cassandra Cluster / STaaS: 'Alarm events' graph on 'Reports' page of service card would incorrectly be empty [ID 45533]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When, in a DataMiner Cube connected to a DataMiner System using Cassandra Cluster or STaaS, you opened the *Reports* page of a service card, the *Alarm events* graph would incorrectly be empty, showing "Alarm data not found in the current time range".

#### AssemblyResolveHelper now returns already loaded fallback assembly if it was already loaded [ID 45567]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When the `AssemblyResolveHelper` in `SLCompilationEngine` cannot find the exact version of the assembly it has to load, by default, it will try to load an assembly with the same name but a different version.

Up to now, when the assembly with the different version was already loaded in the application domain, the `AssemblyResolveHelper` would incorrectly return null.

From now on, when the assembly with the different version is already loaded in the application domain, the `AssemblyResolveHelper` will again correctly return the already loaded assembly.

#### SLWatchDog: Log entry describing a process restart would incorrectly not include the names of the restarted processes [ID 45614]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When SLWatchDog had queued a process restart after having detected that one or more non-critical processes had stop working, up to now, the associated log entry would incorrectly not include the names of the affected processes: `Queueing Process Restarts in 1 minute ()`

From now on, this log entry will correctly include the names of the processes being restarted. For example: `Queueing Process Restarts in 1 minute (SLProtocol.exe)`
