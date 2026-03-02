---
uid: General_Main_Release_10.5.0_CU12
---

# General Main Release 10.5.0 CU12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU12](xref:Cube_Main_Release_10.5.0_CU12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU12](xref:Web_apps_Main_Release_10.5.0_CU12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### An error will now be logged if the response to an SNMP Get request cannot be mapped [ID 44329]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

If the response to an *SNMP Get* request cannot be mapped, from now on, an error will be logged in the log file of the element in question and in the *SLErrorsInProtocol.txt* file.

#### .dmprotocol packages included in DELT export packages will now also contain all assemblies used by the connectors in those .dmprotocol packages [ID 44345]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

From now on, *.dmprotocol* packages included in DELT export packages will also contain all assemblies used by the connectors in those *.dmprotocol* packages.

#### Factory reset tool: Actions that stop and stop DcMs and DxMs will now have a 15-minute timeout [ID 44387]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

The factory reset tool *SLReset.exe* can be used by an administrator to fully reset a DataMiner Agent to its default state from immediately after installation.

One of the actions performed by this tool when resetting a DMA is stopping and starting the DcMs and DxMs. Up to now, the DcMs and DxMs would be stopped and started without any timeout. From now on, the stop and start actions will have a 15-minute timeout.

Also, if an exception would be thrown during a stop action, a kill command will be executed instead.

#### Security Advisory BPA test: Enhancements [ID 44444] [ID 44477] [ID 44566]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

A number of enhancements have been made to the Security Advisory BPA test:

- Up to now, the *Local admin hygiene* test would verify whether the local admin account was disabled and whether there were not too many local administrator accounts. From now on, this test will no longer be performed as the recommendations in the [hardening guide](https://aka.dataminer.services/HardeningGuide) have been updated.

- The HTTP header test will now also check whether the referrer-policy header is set.

- A new test was added that will check the *versionhistory.txt* file to find out whether a system upgrade was performed in the last 6 months.

  If the contents of the *versionhistory.txt* file cannot be read, the test will check when that file was last updated, and if that also fails, it will check when the *SLNet.exe* file was last updated.

Also, the following issues have now been fixed:

- The *gRPC* test will now properly take the default configuration into account. Up to now, this test would assume gRPC was disabled when not configured. From DataMiner feature release 10.5.10, gRPC is enabled by default, causing the test to report a false positive.

- On systems where the `enableLegacyV0Interface` flag is not set in the *web.config* file, the test that verifies whether the v0 web API is disabled would incorrectly assume that the v0 web API was enabled. From now on, when the `enableLegacyV0Interface` flag is not set in the *web.config* file, the v0 web API will be considered disabled.

#### APIGateway now has a dedicated log file [ID 44469]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, APIGateway would send its log entries to the Microsoft Event Viewer. Now, a dedicated APIGateway log file has been added in `C:\ProgramData\Skyline Communications\DataMiner APIGateway\Logs`.

- When the current log file reaches its maximum size of 5 MB, a new log file will be started. Up to 2 files will be kept.
- The configuration of the log file can be adjusted using an `appsettings.custom.json` file. Copy the contents of the `appsettings.json` file to the `appsettings.custom.json` file, and change the necessary values.

#### SLAnalytics: Enhanced resilience during startup [ID 44476]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Because of a number of enhancements, from now on, SLAnalytics will be more resilient when starting up.

From now on, when an issue occurs during startup, in most cases, SLAnalytics will add an entry describing the issue to the SLAnalytics log file, and will keep on working.

#### BPA test 'Cube CRL Freeze': Enhanced performance [ID 44479] [ID 44616]

<!-- RN 44479: MR 10.4.0 [CU21] / 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->
<!-- RN 44616: MR 10.4.0 [CU21] / 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Because of a number of enhancements, overall performance of the the *Cube CRL Freeze* BPA test has increased.

This BPA test will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

#### GQI: Domain user name will now be included in the OnInitInputArgs of a GQI extension [ID 44509]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, for a GQI extension (i.e., an ad hoc data source or a custom operator) to be able to retrieve the username of the user who launched the query, an additional connection had to be set up, which could cause overall performance of the extension to decrease.

From now on, the `OnInitInputArgs` will include a `Session` object that will contains the domain user name of the user who launched the query.

#### SLManagedScripting will again add a log entry each time it has loaded or failed to load an assembly [ID 44522]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU1] - FR 10.6.3 -->

Since DataMiner version 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9<!-- RN 43690 -->, SLManagedScripting no longer added an entry in the *SLManagedScripting.txt* log file each time it had loaded or failed to load an assembly. From now on, it will again do so.

These log entries will include both the requested version and the actual version of the assembly.

#### Scheduler: Enhanced logging when a Windows task cannot be found and needs to be recreated [ID 44587]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

If, at DataMiner startup, the scheduled task configured for the DMA could not be found in the Windows Task Scheduler, up to now, SLScheduler would log a message like the following one:

```console
Failed to get info for task 1 [BTT: Cassandra Backup]: Failed to get info for task 'Skyline DataMiner Scheduled Task 1': 0x80070002h The system cannot find the file specified.
```

This message would incorrectly not indicate whether the task was missing in the Windows Task Scheduler or whether an issue had occurred while verifying it. Also, it would be unclear whether DataMiner would recreate the scheduled task.

From now on, when a task cannot be found in the Windows Task Scheduler and needs to be recreated, more detailed information will be added to the *SLScheduler.txt* log file. See the example log entry below:

```console
Failed to get MS task for Scheduler task 321/2 [Task 1]: (Task 'Skyline DataMiner Scheduled Task 321-2' not found in MS Task Scheduler). MS Task will be recreated.
Task 321/2 [Task 1] successfully added to MS Task Scheduler
```

#### User-Defined APIs: UserDefinableApiEndpoint DxM has been updated [ID 44718]

<!-- MR 10.5.0 [CU12] - FR TBD -->

The UserDefinableApiEndpoint DxM has been upgraded to version 3.3.1 in order to prevent a potential issue that caused the process to keep using more memory and CPU resources.

### Fixes

#### Numeric cell would incorrectly not be cleared when its exception value was set to 0 [ID 44356]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When a numeric cell had its exception value set to 0, up to now, it would incorrectly not be possible to clear that cell by setting its value to null or by using the `protocol.clear` property. When an attempt was made to clear the cell or to set its value to null, the cell would incorrectly show its exception value instead of the word "Uninitialized".

Also, in some cases, an exception would be displayed even when it had a type other than the parameter for which it had been defined. For example, an exception value of type string defined for a parameter of type double.

For more information, see [Exceptions element](xref:Protocol.Params.Param.Interprete.Exceptions). The `Exceptions` tag should only be used to intercept values of the same `Interprete.Type` as that of your parameter. If you want to intercept values of another type, then you should use the `Protocol.Params.Param.Interprete.Others` tag instead.

#### MessageBroker: Problem with hostnames and FQDNs containing a certain combination of dashes and characters [ID 44433]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU1] - FR 10.6.3 -->

Up to now, hostnames and FQDNs in the *MessageBrokerConfig.json* file would incorrectly be considered invalid when they contained a certain combination of dashes and characters.

Examples of hostnames that were incorrectly considered invalid:

- Hostnames that start with one letter or number, followed by a dash. For example, `a-agent`, `h-hostname`, etc.
- Full IPv6 addresses like `[2001:0db8:85a3:0000:0000:8a2e:0370:7334]`
- Shortened IPv6 addresses like `[::1]`

#### Delay of DataMiner startup routine caused by SLDataMiner starting up faster than SLNet [ID 44438]

<!-- MR 10.5.0 [CU12] - FR 10.6.2 [CU0] -->

During DataMiner startup, in some rare cases, SLDataMiner would start up faster than SLNet. This would cause a delay of about 2 minutes in the entire startup routine.

#### GQI: Problem with Timer callbacks could cause SLHelper to stop working [ID 44458]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

In some cases, exceptions could be thrown in the callback of System.Threading.Timer, causing the SLHelper process to stop working.

See also: [GQI DxM: Problem with Timer callbacks could cause the GQI DxM to stop working [ID 44460]](xref:Web_apps_Feature_Release_10.6.3#gqi-dxm-problem-with-timer-callbacks-could-cause-the-gqi-dxm-to-stop-working-id-44460)

#### Event message would return the object twice in case of two subscriptions to the same object [ID 44486]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When, on the same connection, there were two subscriptions to the same object, in some cases, that object would incorrectly be returned twice in the event message.

#### SLA would degrade after an element had been restarted [ID 44490]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When an element was restarted, and that element had alarms with service impact that were being tracked by an SLA, in some cases, the SLA would degrade when one of those alarms no longer affected the SLA.

#### Elements: Clicking 'Test connection' while adding or editing an element could cause SLProtocol to stop working [ID 44514]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

If, while adding or editing an element based on a connector that had an additional thread specified, you clicked *Test connection*, in some cases, SLProtocol could stop working.

#### Problem with SLDataMiner after sending an NT_READ_SAVED_PARAMETER_VALUE call [ID 44597]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU1] - FR 10.6.4 -->

When an NT_READ_SAVED_PARAMETER_VALUE call was sent to retrieve data from an element without a connector while that data was still present in SLDataGateway, up to now, SLDataMiner could stop working.
