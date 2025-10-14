---
uid: MaintenanceSettings.WatchDog
---

# WatchDog element

Configures the watchdog process SLWatchdog.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[Actions](xref:MaintenanceSettings.WatchDog.Actions) | [0, 1] | Specifies the action to perform. Possible values: alarm, restart, switch. Multiple values must be separated by a semicolon (";"). |
| &#160;&#160;[EMail](xref:MaintenanceSettings.WatchDog.EMail) | [0, 1] | Configures email settings. |
| &#160;&#160;[Errors](xref:MaintenanceSettings.WatchDog.Errors) | [0, 1] | Specifies how many consecutive missed thread signals (errors) are tolerated before the system considers a thread to be in a problematic state and triggers error handling actions. |
| &#160;&#160;[FailoverOnRTE](xref:MaintenanceSettings.WatchDog.FailoverOnRTE) | [0, 1] | Configures settings related to performing a Failover switch when a runtime error (RTE) occurs. |
| &#160;&#160;[ProcessMonitor](xref:MaintenanceSettings.WatchDog.ProcessMonitor) | [0, 1] | Configures settings related to the process monitor. |
| &#160;&#160;[TechsupportNotifications](xref:MaintenanceSettings.WatchDog.TechsupportNotifications) | [0, 1] | Configures settings related to tech support notifications. |
| &#160;&#160;[TimeoutTime](xref:MaintenanceSettings.WatchDog.TimeoutTime) | [0, 1] | Specifies the timeout time in minutes. |

## Remarks

You can configure Watchdog to:

- Initiate a Failover switch in case of a runtime error, by specifying the value "switch" in the tag. Optionally, to exclude certain threads from initiating a Failover switch, add the *\<FailoverOnRTE>* subtag and specify the threads in *\<SkipRTE>* subtags.

    > [!NOTE]
    >
    > - If a Failover switch is launched, the DMA is then also restarted to make sure that it frees the virtual IP address. Before the restart is initiated, the DMA is marked as "offline".
    > - If DataMiner Watchdog is set to initiate a Failover switch in case of a runtime error, it will even do so if the Failover type is set to "Manual" in the Failover settings.

- Initiate an element restart in case of a runtime error on an element-related SLProtocol thread, by adding the attribute *restartElementOnProtocolRTE*, and setting it to *true*.

> [!NOTE]
>
> - To make these changes to *MaintenanceSettings.xml* take effect, after you have saved the file, stop the DMA, manually stop the SLWatchdog service, and then restart the DMA.
> - If DataMiner Watchdog is set to initiate both a Failover switch and an element restart, then the latter takes precedence. No Failover switch will be initiated when the element restart succeeds.

## See also

- [Configuring the SLWatchdog process](xref:Configuration_of_DataMiner_processes#configuring-the-slwatchdog-process)
