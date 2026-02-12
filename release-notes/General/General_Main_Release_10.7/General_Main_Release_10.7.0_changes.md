---
uid: General_Main_Release_10.7.0_changes
---

# General Main Release 10.7.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Breaking changes

#### Protocols: As many SLScripting processes as SLProtocol processes by default [ID 44420]

<!-- MR 10.7.0 - FR 10.6.3 -->

Up to now, one SLScripting process was used by default. From now on, by default, there will be as many SLScripting processes as SLProtocol processes.

Note that is possible to configure the number of simultaneously running SLScripting processes. See [Setting the number of simultaneously running SLScripting processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slscripting-processes).

> [!IMPORTANT]
> If you are using multiple SLScripting processes, it is important that elements running the same protocol are not sharing/exchanging data with each other through static fields. More information can be found in the [QAction documentation](xref:LogicQActionsMemberFields#sharing-and-persisting-data).

#### SNMP trap binding values will now only display plain ASCII characters [ID 44527]

<!-- MR 10.7.0 - FR 10.6.4 -->

When the system receives a trap binding value of type OctetString, that value will either be automatically converted into characters (e.g. 0x41 will become "A") or remain in a hexadecimal string format (e.g. when the value contains a byte that is not printable like 0x02, which is an STX control character).

Up to now, hexadecimal values above the ASCII range (i.e. values >= 0x7F) were considered printable characters, and were not converted into a hexadecimal string. This would cause issues with, for example, the Unicode control character 0x8C, which would be displayed as a question mark. In such cases, complex QAction code would then be required to have it converted back into a hexadecimal value.

Also, DataMiner is not aware of whether a binding value actually contains text (e.g. a MAC address consisting of octets) or, if the value contains text, how that text was encoded (e.g. Windows code page 1252, UTF-8, UTF-16, etc.).

From now on, hexadecimal values outside of the ASCII range will be considered non-printable characters, and will remain in hexadecimal string format.

This is a breaking change.

Up to now, text containing characters that were encoded in extended ASCII (i.e. Windows code page 1252) were converted from raw octets into string text. For example, the French word "hélicoptère" would be received correctly. From now on, that same word will be received as hexadecimal string "68e96c69636f7074e87265", and a QAction will need to convert it back into a string using the correct encoding.

### Enhancements

#### SLNet: Trend graphs in Cube will now also correctly display behavioral change points for table column parameters without advanced naming [ID 41751]

<!-- MR 10.7.0 - FR 10.6.1 -->

Because of a number of enhancements made in SLNet, trend graphs in DataMiner Cube will now also correctly display behavioral change points for table column parameters without advanced naming.

#### Protocols: Elements will now restart automatically when an SLScripting process has disappeared [ID 42306]

<!-- MR 10.6.0 - FR 10.5.5 >>> Published in 10.7.0 - FR 10.6.3 together with 44420 -->

Up to now, when an SLScripting process disappeared, elements relying on that process could become unstable, requiring manual intervention to restore functionality.

From now on, when an SLScripting process disappears, a new process instance will be started automatically, and any elements that depended on the process that disappeared will be restarted to maintain consistency across SLProtocol, SLScripting, and other related components. This will ensure that lost SLScripting data is properly reinitialized and remains in sync with other processes.

When an SLScripting process disappears, the following notice alarm will be generated:

`Process disappearance of SLScripting.exe with PID <processId>; <x> elements affected by the disappearance have been restarted.`

Also, the *SLElementsInProtocol.txt* log file has been updated to track restart reasons more accurately.

- The restart reason column will now indicate either "SLScriptingCrashRestart" or "SLProtocolCrashRestart" (if everything is OK, *NormalStart* will be shown instead).
- A new counter will now indicate the number of times the element was started due to a SLScripting process disappearance.

If SLProtocol requests an SLScripting process that is no longer valid, the system will now detect this, and trigger the same element restart flow.

> [!NOTE]
> There will be a one-minute delay between the disappearance of an SLScripting process and the creation of a new SLScripting process and the subsequent element restarts. However, when one of the elements that was hosted in the SLScripting process that disappeared tries to trigger a QAction within that one-minute delay, the new SLScripting process will be created when that QAction is triggered.

#### Automation: Engine class now has an OnDestroy handler that will allow resources to be cleaned up when a script ends [ID 43919]

<!-- MR 10.7.0 - FR 10.6.1 -->

An `OnDestroy` handler has now been added to the `Engine` class. This handler will allow resources to be cleaned up when a script ends.

Multiple handlers can be added. They will run synchronously, and if one handler throws an error, the others will keep on running.

#### New parameter caches for client apps [ID 43945]

<!-- MR 10.7.0 - FR 10.6.3 -->

Two new parameter caches are now available for client apps (e.g. DataMiner Cube):

- ProtocolParameters (linked to GetProtocolParameter on the client connection)
- ElementProtocolParameters (linked to GetElementProtocolParameter on the client connection)

Both caches are added on the connection object, and have the ability to cache in memory (for the current session) and on disk (for a next session).

#### Automation: All methods that use parameter descriptions have now been marked as obsolete [ID 43948]

<!-- MR 10.7.0 - FR 10.6.1 -->

All methods in the `Skyline.DataMiner.Automation` namespace that use parameter descriptions have now been marked as obsolete.

#### Service & Resource Management: New resource manager settings to configure the number of start action threads and simultaneous actions [ID 44056]

<!-- MR 10.7.0 - FR 10.6.1 -->

Because of a number of enhancements, overall performance has increased when starting multiple bookings in parallel.

Also, in the resource manager, it is now possible to configure the number of start action threads and simultaneous actions.

| Setting | Description |
|---------|-------------|
| MaxAmountOfThreads       | The number of threads the resource manager will use to start bookings.<br>By default, 6 threads will be used. To restore this setting to the default value, set its value to null.<br>Note: The number of threads must at least be set to 2 in order for the scheduler to be able to start an action and keep a thread available for asynchronous continuations. |
| MaxAmountOfParallelTasks | The number of parallel actions the resource manager will start on the threads.<br>By default, the number of parallel action is set to 7. To restore this setting to the default value, set its value to null. |

The following example shows how you can configure this from an automation script.

```csharp
private void UpdateResourceManagerConfigSettings()
{
    var setConfigMessage = new ResourceManagerConfigInfoMessage(ResourceManagerConfigInfoMessage.ConfigInfoType.Set)
    {
        ResourceManagerAutomationSettings = new ResourceManagerAutomationSettings()
        {
            ResourceManagerAutomationThreadSettings = new ResourceManagerAutomationThreadSettings()
            {
                MaxAmountOfParallelTasks = 30,
                MaxAmountOfThreads = 8
            }
        },
    };
    engine.SendSingleResponseMessage(setConfigMessage);
}
```

In most cases, these settings can keep their default value, unless performance has to optimized when multiple concurrent bookings have to be started. In order to increase performance, the number of threads and parallel tasks can be increased, provided the DataMiner Agent and the database can handle the increased load.

> [!NOTE]
>
> - When the above-mentioned settings have been changed, the resource manager must be restarted.
> - Only users with *Modules > System configuration > Tools > Admin tools* permission are allowed to change the above-mentioned settings.
> - If the `SkipDcfLinks` setting is set to true, we recommend that you do not set MaxAmountOfParallelTasks too high. DCF link creation can be an expensive operation. Performing a large number of action in parallel might decrease performance.

#### Enhanced visibility on SLNet connection issues [ID 44069]

<!-- MR 10.7.0 - FR 10.6.3 -->

Visibility on SLNet connection issues has been enhanced:

- When a dashboard cannot be loaded because a DataMiner Agent is offline, an appropriate error message will now appear in that dashboard.

- A new log file named *SLNetConnectionsMonitor.txt* will now keep a historic record of all SLNet connection states.

#### Augmented Operations: Server-side support for new flatline detection modes [ID 44094]

<!-- MR 10.7.0 - FR 10.6.2 -->

When, in DataMiner client applications (e.g. DataMiner Cube), you are configuring the Augmented Operations alarm settings for a particular parameter in an alarm template, from now on, it will be possible to choose between the following flatline detection modes:

| Mode | Description |
|------|-------------|
| Smart flatline alarming    | In this mode, SLAnalytics will automatically determine when a flatline period is anomalous by comparing it to the parameter's historical behavior. A new flatline period will only trigger an alarm if it is significantly longer than previously observed flat periods. |
| Absolute flatline alarming | In this mode, you can define a fixed duration threshold (in seconds) for when a flatline event should trigger an alarm. Additionally, you can assign a severity level to the generated flatline alarm event. |

See also: [Alarm templates: New flatline detection modes in Augmented Operations alarm settings [ID 44191]](xref:Cube_Feature_Release_10.6.2#alarm-templates-new-flatline-detection-modes-in-augmented-operations-alarm-settings-id-44191)

#### DataMiner upgrade: Web-only upgrades with version 10.6.x or above will now require the DMA to have version 10.5.x or above [ID 44103]

<!-- MR 10.7.0 - FR 10.6.1 -->

From now on, it will no longer be allowed to perform web-only upgrades with version 10.6.x or above on DataMiner Agents with a version below 10.5.x.

This means, that any DataMiner Agent on which you want to perform a web-only upgrade with version 10.6.x or above will first have to be upgraded to version 10.5.x or above.

#### dataminer.services: Restrictions when adding a DMA to a DMS [ID 44171]

<!-- MR 10.7.0 - FR 10.6.2 -->

From now on, when you try to add a DataMiner Agent to a DataMiner System, the operation will fail in the following cases:

- The DataMiner Agent is cloud-connected, but the DataMiner System is not.
- The DataMiner Agent and the DataMiner System are cloud-connected, but they do not have the same identity, i.e. they are not part of the same cloud-connected system.

If the DataMiner System is a STaaS system, adding a DataMiner Agent will also fail if the DataMiner Agent is not cloud-connected.

#### Scheduler will now be able to start more than 10 synchronously running automation scripts [ID 44200]

<!-- MR 10.7.0 - FR 10.6.2 -->

Up to now, using Scheduler, it would only be possible to start a maximum of 10 synchronously running automation scripts.

From now on, it will be possible to start more than 10 synchronously running automation scripts.

#### Relational anomaly detection: GetRADParameterGroupInfoResponseMessage now also includes the ID of the RAD parameter group [ID 44237]

<!-- MR 10.7.0 - FR 10.6.2 -->

The response to a `GetRADParameterGroupInfoMessage` will now also include the ID of the RAD parameter group.

#### Service & Resource Management: Enhanced communication between resource managers across DataMiner Agents [ID 44279]

<!-- MR 10.7.0 - FR 10.6.2 -->

A number of enhancements have been done with regard to the communication between resource managers across DataMiner Agents. This will especially enhance performance when starting multiple bookings on non-master DMAs.

#### DataMiner upgrade: DataMiner Assistant DxM will now be included in the DataMiner web upgrade packages [ID 44291]

<!-- MR 10.7.0 - FR 10.6.2 -->

In order to upgrade the DataMiner Assistant DxM, up to now, you had to install a full DataMiner server upgrade package (main release or feature release).

From now on, the DataMiner Assistant DxM will be included in the DataMiner web upgrade packages instead.

See also: [DataMiner upgrade: DataMiner Assistant DxM will now be included in the DataMiner web upgrade packages [ID 44291]](xref:Web_apps_Feature_Release_10.6.2#dataminer-upgrade-dataminer-assistant-dxm-will-now-be-included-in-the-dataminer-web-upgrade-packages-id-44291)

> [!NOTE]
> The DataMiner Assistant DxM will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, it will not be installed.

#### Automation: Entrypoint ID added to the 'Finished executing script' log entry [ID 44382]

<!-- MR 10.7.0 - FR 10.6.2 -->

The entry added to the *SLAutomation.txt* log file when an automation script has finished will now contain the entrypoint ID.

In the following example, the entrypoint ID can be found at the end of the entry between brackets (11):

`2025/12/18 13:40:00.546|SLAutomation.exe 8.0.1415.2|22300|16908|CAutomation::Execute|INF|0|Finished executing script: 'script_RT_USER_DEFINABLE_APIS_BodySizeLimit_RT_USER_DEFINABLE_APIS_BodySizeLimit_MaxResponseBodySize' (ID: 7) - SUCCEEDED - Execution took 00.308s. (11)`

#### DataMiner backup: 'Ticketing Gateway Configuration' removed from the list of backup options [ID 44401]

<!-- MR 10.7.0 - FR 10.6.3 -->

As the Ticketing app is End of Life as of DataMiner 10.6.x, *Ticketing Gateway Configuration* has now been removed from the list of backup options.

#### DataMiner backup: Scheduler configuration will now be included in full and configuration backups [ID 44584]

<!-- MR 10.7.0 - FR 10.6.3 -->

From now on, the Scheduler configuration found in `C:\Skyline Dataminer\Scheduler` will be included in the following pre-configured backups:

- Full backup (without database)
- Configuration backup (without database)

If you create a custom backup, the Scheduler configuration will be included only if you selected the *DataMiner settings* option.

#### SLDataGateway: Job queue updates will now be logged in SLJobQueues.txt [ID 44661]

<!-- MR 10.7.0 - FR 10.6.4 -->

Up to now, log entries regarding SLDataGateway job queue updates would be logged in the `C:\Skyline DataMiner\Logging\SLDbConnection.txt` file.

From now on, these log entries will be logged in the `C:\Skyline DataMiner\Logging\SLDataGateway\SLJobQueues.txt` file instead.

#### SLLogCollector: Separate log file per instance [ID 44668]

<!-- MR 10.7.0 - FR 10.6.4 -->

Up to now, all SLLogCollector logging of all SLLogCollector instances would end up in the following files, stored in the `C:\ProgramData\Skyline\DataMiner\SL_LogCollector\Log` folder:

- `SL_LogCollector_fulllog.log`
- `SL_LogCollector_log.log`

From now on, each SLLogCollector instance will have its own dedicated log file named `log-[creation timestamp].txt`, stored in the `C:\ProgramData\Skyline Communications\SLLogCollector` folder.

Up to 10 log files will be kept on disk, and the log file of the current instance will be added to the SLLogCollector package.

### Fixes

#### SLAnalytics would not receive 'swarming complete' notifications for swarmed DVE child elements [ID 43984]

<!-- MR 10.7.0 - FR 10.6.1 -->

Up to now, SLAnalytics would incorrectly not receive any "swarming complete" notifications for swarmed DVE child elements. As a result, alarm focus calculations for DVE child elements would be restarted from scratch instead of being fetched from the database.

#### Service & Resource Management: A capability could incorrectly be set to a null value [ID 44125]

<!-- MR 10.7.0 - FR 10.6.1 -->

In some cases, a capability could incorrectly be set to a null value.

From now on, when a capability is booked, it will no longer be possible to set its value to null.

#### Failover: Problem when reloading the scheduled tasks [ID 44234]

<!-- MR 10.7.0 - FR 10.6.1 -->

After a Failover switch, in some cases, the new online agent would incorrectly not reload the scheduled tasks that the former online agent had in memory.

#### Problem with SLAnalytics when trying to process an invalid database record [ID 44748]

<!-- MR 10.7.0 - FR 10.6.4 -->

In some cases, SLAnalytics would stop working when trying to process an invalid database record after having serialized it?
