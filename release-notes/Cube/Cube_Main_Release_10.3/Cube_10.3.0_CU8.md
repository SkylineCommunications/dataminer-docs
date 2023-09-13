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

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

On a system with a large number of correlation/incident alarms, in some cases, an error could occur when one of those alarms was cleared. That alarm would then incorrectly remain visible in the Alarm Console.

#### DataMiner Cube - Trending: Problem with Y axis labels on trend graphs showing data from string and non-string parameters [ID_37281]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When you opened a trend graph showing trend data of a parameter of type string, and you added another, non-string parameter to that same graph, the Y axis of the newly added parameter would not be rendered correctly. The labels would be placed too close to each other, making them unreadable.
