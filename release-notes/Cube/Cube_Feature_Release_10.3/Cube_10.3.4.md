---
uid: Cube_Feature_Release_10.3.4
---

# DataMiner Cube Feature Release 10.3.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.4](xref:General_Feature_Release_10.3.4).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### Visual Overview - ListView component: New component option 'SingleSelectionMode' [ID_35320]

<!-- MR 10.4.0 - FR 10.3.4 -->

By default, you can select multiple rows in a list view (e.g. using the CTRL or SHIFT key). With the new component option *SingleSelectionMode*, you can now set the selection mode of a list view to single instead, so that only one row can be selected at a time.

## Changes

### Enhancements

#### ListView component: Rows with an identical value will additionally be sorted by Name [ID_35500]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When, in a ListView component, you sort the rows by clicking a particular column header, from now on, all rows with an identical value in the column you sorted by will additionally be sorted by the *Name* column (in ascending order).

#### Bookings app: Default window of timeline area now set to '-8 hours <NOW> +16 hours' [ID_35525]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

In the *Bookings* app, the default window of the timeline area has now been changed from `-1 day <NOW> +1 day` to `-8 hours <NOW> +16 hours`.

This also means that a ListView component configured to list bookings will by default have its *StartTime=* and *EndTime=* options set to `NOW - 8 hours` and `NOW + 16 hours` respectively.

#### System Center - Agents: Clearer restart warning before an upgrade is started [ID_35687]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When you tried to upgrade an agent in System Center, up to now, the following general message would appear:

`Updating DataMiner requires a restart of the DataMiner Agent`

This message has now been changed to provide more details:

`Updating DataMiner using a full upgrade package requires a restart of the DataMiner Agent. A web upgrade package will only restart the web server.`

### Fixes

#### Visual Overview: Problem with EnableFollowMode option of Resource Manager timeline [ID_35528]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you had specified the *EnableFollowMode* option in the *ComponentOptions* shape data field of a shape configured to display the Resource Manager timeline, in some cases, that option would incorrectly be disabled.

From now on, when you activate the follow mode by specifying the *EnableFollowMode* option, the timeline will move along with the current time. When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again.

#### DataMiner Cube - Search box: Problem when loading templates after right-clicking an element and selecting 'Assign alarm template' or 'Assign trend template' [ID_35582]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When, in the search box in the middle of the Cube header bar, you enter the name of an element and right-click the suggested element, a context menu will open identical to that which opens when you click an element in the Surveyor.

However, when, in that context menu, you then selected *Protocols & Templates > Assign alarm template* or *Protocols & Templates > Assign trend template*, the available templates would not get loaded.

#### DataMiner Cube: Problem when receiving a notification from SLAnalytics while in alarm storm mode [ID_35596]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

An error could occur in DataMiner Cube when it received a notification from SLAnalytics while in alarm storm mode.

Also, from now on, DataMiner Cube will no longer group incident alarms into summary alarms while in alarm storm mode.

#### Resources app: Problem when moving a resource from one resource pool to another [ID_35612]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When, in the *Resources* app, you moved a resource from one resource pool to another, in some cases, the resource would have missing data after being moved.

#### DataMiner Cube: Pattern edit menu would incorrectly open when you resized the selected area in a trend graph [ID_35627]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you resized the selected area in a trend graph by dragging either the left or right selection boundary, the pattern edit menu would incorrectly open, even when you were not allowed to create a pattern or when you had no intention of editing a pattern.

#### DataMiner Cube - Alarm Console: Problem when a session variable was used in an alarm filter [ID_35681]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you applied a filter to an alarm tab, no alarms would be shown when you had used a session variable in the filter.
