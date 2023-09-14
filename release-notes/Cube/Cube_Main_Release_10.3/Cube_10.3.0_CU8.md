---
uid: Cube_Main_Release_10.3.0_CU8
---

# DataMiner Cube Main Release 10.3.0 CU8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU8](xref:General_Main_Release_10.3.0_CU8).

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Alarm Console : Problem when a correlation/incident alarm got cleared [ID_37231]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

On a system with a large number of correlation/incident alarms, in some cases, an error could occur when one of those alarms was cleared. That alarm would then incorrectly remain visible in the Alarm Console.

#### Trend templates: Offload settings would be lost when you disabled to 'Allow Offload Database Configuration' option [ID_37268]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In a trend template, you can configure the data offload settings for a particular parameter by clicking the cogwheel, enabling the *Allow Offload Database Configuration* option and configuring the settings in two dedicated columns.

Up to now, when you disabled the *Allow Offload Database Configuration* option, the two dedicated columns would disappear and the offload settings would be lost. From now on, when you disable the *Allow Offload Database Configuration* option, the offload settings that were specified will be kept and will re-appear when you enable the *Allow Offload Database Configuration* option again.

Also, when you open a trend template in which offload settings have been specified, from now on, the two dedicated columns will be visible by default.

#### Trending: Problem with Y axis labels on trend graphs showing data from string and non-string parameters [ID_37281]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you opened a trend graph showing trend data of a parameter of type string, and you added another, non-string parameter to that same graph, the Y axis of the newly added parameter would not be rendered correctly. The labels would be placed too close to each other, making them unreadable.

#### Alarm Console: Problem when creating a linked alarm tab while connected to a system with a large number of correlated/incident alarms [ID_37332]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When, in the Alarm Console, you created a linked alarm tab while connected to a system with a large number of correlated/incident alarms, in some cases, Cube could become unresponsive for a while until the tab was loaded.
