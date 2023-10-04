---
uid: Cube_Main_Release_10.3.0_CU8
---

# DataMiner Cube Main Release 10.3.0 CU8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU8](xref:General_Main_Release_10.3.0_CU8).

### Enhancements

#### System Center: Length of Cassandra database name restricted to max. 20 characters [ID_37340]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When you configure a Cassandra database in the *Database* section of *System Center*, from now on, the database name will no longer be allowed to be longer than 20 characters.

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

#### Opening element card for DVE alarm from Alarm Console did not work correctly [ID_37297]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When you opened the element card for an alarm on a parameter of a DVE element from the Alarm Console, this did not have the same behavior as for regular alarms. Now this action will open the trend graph of the parameter if the parameter is trended, or otherwise it will show the parameter details.

#### Alarm Console: Problem when creating a linked alarm tab while connected to a system with a large number of correlated/incident alarms [ID_37332]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When, in the Alarm Console, you created a linked alarm tab while connected to a system with a large number of correlated/incident alarms, in some cases, Cube could become unresponsive for a while until the tab was loaded.

#### No breadcrumbs would be displayed when you opened a service card [ID_37384]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you opened a service card, in some rare cases, no breadcrumbs would be displayed.

#### DataMiner Cube: Parameter value with decimals would be displayed incorrectly in context menus [ID_37420]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

Up to now, when you opened a context menu with a text box that contained a parameter value with decimals, and the default value of the parameter also contained decimals, the decimal point in the value in the text box would be displayed incorrectly. For example, 44.2 would incorrectly be displayed as 442.0.

The issue was due to Cube trying to parse the default value with the current culture in the Windows machine.

#### DataMiner Cube - Alarm Console: Tooltip of suggestion counter would incorrectly show 'suggestion' in capitals [ID_37454]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In the Alarm Console footer, you can find counters that display the number of alarms in the current tab per severity. When you hover over one of those counters, a tooltip appears with the text "[nr of alarms] [severity]" (e.g. 31 Major).

Up to now, when you hovered over the suggestions counter, the tooltip would incorrectly show the word "SUGGESTION" in capitals. From now on, it will be shown as "Suggestion" (with capital S).
