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

#### Enhanced consistency when handling alarm property updates [ID 44074]

<!-- MR 10.7.0 - FR 10.6.1 -->

To ensure that all alarm property updates are handled consistently, whatever the source of the alarm (DataMiner System, Correlation, Analytics, etc.), messages sent out following an alarm property update will now always include a reference to the base alarm of the alarm in question.

#### DataMiner upgrade: Web-only upgrades with version 10.6.x or above will now require the DMA to have version 10.5.x or above [ID 44103]

<!-- MR 10.7.0 - FR 10.6.1 -->

From now on, it will no longer be allowed to perform web-only upgrades with version 10.6.x or above on DataMiner Agents with a version below 10.5.x.

This means, that any DataMiner Agent on which you want to perform a web-only upgrade with version 10.6.x or above will first have to be upgraded to version 10.5.x or above.

#### SLAnalytics RAD: GetRADSubgroupFitScoresResponseMessage will now return additional information regarding subgroups of a shared model group [ID 44108]

<!-- MR 10.7.0 - FR 10.6.1 -->

The `GetRADSubgroupFitScoresResponseMessage` will now return additional information regarding subgroups of a shared model group.

In addition to the model fit score for each subgroup, the response message will now contain an `IsOutlier` boolean field. This field is set to true when a subgroup is identified as an outlier based on its relational behavior compared to the other subgroups.

In practical terms, this means that the subgroup's model fit score deviates from the other fit scores. The shared model fits this subgroup significantly worse than it fits most of the remaining subgroups.

### Fixes

#### SLAnalytics would not receive 'swarming complete' notifications for swarmed DVE child elements [ID 43984]

<!-- MR 10.7.0 - FR 10.6.1 -->

Up to now, SLAnalytics would incorrectly not receive any "swarming complete" notifications for swarmed DVE child elements. As a result, alarm focus calculations for DVE child elements would be restarted from scratch instead of being fetched from the database.
