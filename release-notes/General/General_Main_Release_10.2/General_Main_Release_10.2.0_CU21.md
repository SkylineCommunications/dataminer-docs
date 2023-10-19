---
uid: General_Main_Release_10.2.0_CU21
---

# General Main Release 10.2.0 CU21 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Cube - Trending: All trend patterns will now be loaded when you open a trend graph showing data from several parameters [ID_36661]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when you opened a trend graph showing data from several parameters, only the trend patterns of the first parameter would be loaded onto the graph. From now on, the trend patterns of all parameters shown on the graph will be loaded.

The SLAnalytics feature "pattern matching" has now fully been integrated in the Trending module.

#### Security enhancements [ID_37267]

<!-- RN 37267: MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.11 -->

A number of security enhancements have been made.

#### DataMiner Cube - Alarm Console: Button to show focused alarms now shows the number of focused alarms [ID_37455]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

From now on, the button to only show the focused alarms in the current alarm tab will show the number of focused alarms in the current alarm tab and will only be visible when the alarm tab actually contains focused alarms.

#### DataMiner Cube - Surveyor: Enhanced processing of alarm statistics [ID_37552]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

In the Surveyor, statistical alarm data can be displayed next to elements, services and views. A number of enhancements have now been made to enhance the processing of those alarm statistics.

#### DataMiner Cube: Caching enhancements [ID_37553]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

A number of general enhancements have been made with regard to cache management.

### Fixes

#### NATSCustodian could incorrectly pick an offline DMA as NAS candidate [ID_37312]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when NATSCustodian had to pick a NAS candidate, in some cases, it could pick a DataMiner Agent that was offline, causing an error to occur when trying to copy the credentials.

From now on, it will only be possible to trigger a NATS configuration reset when all DataMiner Agents in the cluster are online/running.

#### Updated dynamic IP address would incorrectly be applied to all connections of an element [ID_37445]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a parameter that was used to store the dynamic IP address of an element connection was updated, the dynamic IP address would incorrectly be applied to all connections of that element when the element was restarted.

#### DataMiner Cube - Alarm Console: Alarm tab filter would not be re-evaluated when the focus score of an alarm was updated [ID_37475]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When an alarm in a filtered alarm tab received a focus score update, the system would incorrectly not re-evaluate whether that alarm still matched the filter that was applied.

#### DataMiner Cube - Alarm Console: Display issues when a correlation alarm was based on another correlation alarm [ID_37497]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a correlation rule was based on another correlation rule, display issues could occur in the Alarm Console.

When the main correlation alarm got cleared, the base alarm would no longer be shown in the alarm tab, and when the base alarm got updated, it would be shown twice: once as the source of the other correlation alarm and once as a regular alarm.

#### DataMiner Cube: Problem when trying to display broadcast messages while being used as a service [ID_37524]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When Cube tried to display a broadcast message it had received from the DataMiner Agent while being used as a service by SLHelper, an error could occur in the latter.

From now on, Cube will no longer display any broadcast messages while being used as a service (e.g. when displaying a visual overview on a mobile device).

#### DataMiner Cube - Spectrum Analysis: Problem when making changes to a spectrum monitor [ID_37542]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When you create a spectrum monitor, you can define a parameter and select a number of measurement points. Each combination of a parameter and a measurement point then is assigned an ID.

Up to now, when you made a change to a spectrum monitor, in some cases, the ID of certain parameter/measurement point combinations could change even when the parameter or the measurement points had not been changed.

#### DataMiner Cube - Alarm Console: Problem when changing the alignment of an alarm property column [ID_37574]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When, in the Alarm Console, you add a column showing an alarm property you are allowed to edit, all cells in that column will display a pencil icon you can click to update a particular value.

Up to now, when you changed the alignment of such a column, the pencil icons would disappear and the new alignment would not be applied. From now on, when you change the alignment of a column showing an alarm property you are allowed to edit, the new alignment will be applied correctly and the pencil icons will stay visible. However, regardless of the alignment, the pencil icons will stay on the left, and when you change a value, the text box will also be aligned to the left.

#### PropertyChangeEvents would not be removed from the SLNet event cache when an element was deleted [ID_37576]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When an element was deleted, `PropertyChangeEvent` instances for that element would incorrectly not get removed from the SLNet event cache.

#### DataMiner Cube - Alarm Console: Text-to-speech button would overlap the counter showing the number of alarms with severity 'Suggestion' [ID_37590]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

In the footer of the Alarm Console, the button to cancel the current text-to-speech operation would overlap the counter showing the number of alarms with severity "Suggestion" in the current alarm tab.

#### DataMiner Cube - Alarm Console: Focus score would not be updated correctly when an alarm was duplicated [ID_37600]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When, in the Alarm Console, an alarm was duplicated, in some cases, its focus score would not be updated correctly.
