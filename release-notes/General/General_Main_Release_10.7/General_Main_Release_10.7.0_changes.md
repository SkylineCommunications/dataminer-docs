---
uid: General_Main_Release_10.7.0_changes
---

# General Main Release 10.7.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### SLNet: Trend graphs in Cube will now also correctly display behavioral change points for table column parameters without advanced naming [ID 41751]

<!-- MR 10.7.0 - FR 10.6.1 -->

Because of a number of enhancements made in SLNet, trend graphs in DataMiner Cube will now also correctly display behavioral change points for table column parameters without advanced naming.

#### Automation: Engine class now has an OnDestroy handler that will allow resources to be cleaned up when a script ends [ID 43919]

<!-- MR 10.7.0 - FR 10.6.1 -->

An `OnDestroy` handler has now been added to the `Engine` class. This handler will allow resources to be cleaned up when a script ends.

Multiple handlers can be added. They will run synchronously, and if one handler throws an error, the others will keep on running.

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

The following example shows how you can configure this from an Automation script.

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

#### DataMiner upgrade: Web-only upgrades with version 10.6.x or above will now require the DMA to have version 10.5.x or above [ID 44103]

<!-- MR 10.7.0 - FR 10.6.1 -->

From now on, it will no longer be allowed to perform web-only upgrades with version 10.6.x or above on DataMiner Agents with a version below 10.5.x.

This means, that any DataMiner Agent on which you want to perform a web-only upgrade with version 10.6.x or above will first have to be upgraded to version 10.5.x or above.

#### Relational anomaly detection: GetRADSubgroupFitScoresResponseMessage will now return additional information regarding subgroups of a shared model group [ID 44108]

<!-- MR 10.7.0 - FR 10.6.1 -->

The `GetRADSubgroupFitScoresResponseMessage` will now return additional information regarding subgroups of a shared model group.

In addition to the model fit score for each subgroup, the response message will now contain an `IsOutlier` boolean field. This field is set to true when a subgroup is identified as an outlier based on its relational behavior compared to the other subgroups.

In practical terms, this means that the subgroup's model fit score deviates from the other fit scores. The shared model fits this subgroup significantly worse than it fits most of the remaining subgroups.

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
