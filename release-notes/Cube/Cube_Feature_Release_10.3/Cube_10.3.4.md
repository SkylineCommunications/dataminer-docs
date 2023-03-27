---
uid: Cube_Feature_Release_10.3.4
---

# DataMiner Cube Feature Release 10.3.4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.4](xref:General_Feature_Release_10.3.4).

## New features

#### Visual Overview - ListView component: New component option 'SingleSelectionMode' [ID_35320]

<!-- MR 10.4.0 - FR 10.3.4 -->

By default, you can select multiple rows in a list view (e.g. using the CTRL or SHIFT key). With the new component option *SingleSelectionMode*, you can now set the selection mode of a list view to single instead, so that only one row can be selected at a time.

#### Visual Overview: Re-arranging grouped shapes [ID_35323]

<!-- MR 10.4.0 - FR 10.3.4 -->

When, in a Visio drawing, shapes had been positioned dynamically based on properties, up to now, it was possible to re-arrange individual shapes manually. From now on, it will also be possible to re-arrange grouped shapes.

#### Embedded web apps can now interact with Cube when using the Microsoft Edge (WebView2) browser plugin [ID_35655]

<!-- MR 10.4.0 - FR 10.3.4 -->

From now on, when using the Microsoft Edge (WebView2) web browser plugin, embedded web apps can interact with Cube (e.g. open an element card).

#### Users no longer have to log in to embedded low-code apps [ID_35657]

<!-- MR 10.4.0 - FR 10.3.4 -->

When a low-code app was embedded in Cube (e.g. in a visual overview), up to now, users had to explicitly log in to that app. From now on, Cube will automatically pass the authentication ticket to the low-code app, allowing users to access the app without having to log in again.

## Changes

### Enhancements

#### ListView component: Rows with an identical value will additionally be sorted by Name [ID_35500]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When, in a ListView component, you sort the rows by clicking a particular column header, from now on, all rows with an identical value in the column you sorted by will additionally be sorted by the *Name* column (in ascending order).

#### Bookings app: Default window of timeline area now set to '-8 hours <NOW> +16 hours' [ID_35525]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In the *Bookings* app, the default window of the timeline area has now been changed from `-1 day <NOW> +1 day` to `-8 hours <NOW> +16 hours`.

This also means that a ListView component configured to list bookings will by default have its *StartTime=* and *EndTime=* options set to `NOW - 8 hours` and `NOW + 16 hours` respectively.

#### Database TTL settings will now be limited to 10 years [ID_35533]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

From now on, DataMiner Cube will no longer accept database TTL settings that exceed 10 years.

#### Selecting 'Help' will now open the 'Getting started' page of the online DataMiner user guide [ID_35571]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When, in DataMiner Cube, you select *Help* in the user menu or the *Apps* pane, the ['Getting started' page of the online DataMiner user guide](xref:Part1GettingStarted) will open in a browser window.

#### Services app: Enhanced performance when opening the 'Profiles' tab [ID_35634]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

Because of a number of enhancements made with regard to the retrieval of overrides for parameter values, overall performance has increased when opening the *Profiles* tab of the *Services* app.

#### Automation script editor: Intellisense added for timeUpDownConfig.ShowTimeUnits [ID_35672]

<!-- MR 10.4.0 - FR 10.3.4 -->

In the Automation script editor, Intellisense has been added for the new `timeUpDownConfig.ShowTimeUnits` property.

This property is only applied in interactive Automation scripts that are launched from a web app.

#### System Center - Agents: Clearer restart warning before an upgrade is started [ID_35687]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When you tried to upgrade an agent in System Center, up to now, the following general message would appear:

`Updating DataMiner requires a restart of the DataMiner Agent`

This message has now been changed to provide more details:

`Updating DataMiner using a full upgrade package requires a restart of the DataMiner Agent. A web upgrade package will only restart the web server.`

### Fixes

#### Bookings app: Initial time window was incorrect [ID_35527]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you open the *Bookings* app, Cube adds a small offset to the time window when it requests the list of bookings from the server. Up to now, instead of subtracting 1 minute from the start time, it would incorrectly add 1 minute to it. When the initial time window was e.g. 11h00 to 12h00, it would incorrectly request the bookings from 11h01 to 12h01 instead of from 10h59 to 12h01.

Also, in some cases, the "loading" indicator of the bookings timeline would incorrectly not disappear when all bookings were loaded.

#### Visual Overview: Problem with EnableFollowMode option of Resource Manager timeline [ID_35528]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you had specified the *EnableFollowMode* option in the *ComponentOptions* shape data field of a shape configured to display the Resource Manager timeline, in some cases, that option would incorrectly be disabled.

From now on, when you activate the follow mode by specifying the *EnableFollowMode* option, the timeline will move along with the current time. When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again.

#### DataMiner Cube - Search box: Problem when loading templates after right-clicking an element and selecting 'Assign alarm template' or 'Assign trend template' [ID_35582]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When, in the search box in the middle of the Cube header bar, you enter the name of an element and right-click the suggested element, a context menu will open identical to that which opens when you click an element in the Surveyor.

However, when, in that context menu, you then selected *Protocols & Templates > Assign alarm template* or *Protocols & Templates > Assign trend template*, the available templates would not get loaded.

#### DataMiner Cube: Full user name would incorrectly no longer be displayed at the top of the user menu [ID_35584]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When, in DataMiner Cube, you clicked the user icon in the top-right corner, the full user name would incorrectly no longer be displayed at the top of the user menu.

#### DataMiner Cube: Problem when receiving a notification from SLAnalytics while in alarm storm mode [ID_35596]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

An error could occur in DataMiner Cube when it received a notification from SLAnalytics while in alarm storm mode.

Also, from now on, DataMiner Cube will no longer group incident alarms into summary alarms while in alarm storm mode.

#### EPM: Number of alarms would incorrectly not be indicated in the navigation pane of an EPM card [ID_35604]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When you open the card of an element, a view or a service, in the navigation pane on the left, the number of alarms is indicated next to the name of the ALARMS section. Up to now, this was not the case when you opened the card of an EPM object. From now on, the number of alarms that affect the EPM object in question will be indicated next to the name of the ALARMS section.

#### Resources app: Problem when moving a resource from one resource pool to another [ID_35612]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When, in the *Resources* app, you moved a resource from one resource pool to another, in some cases, the resource would have missing data after being moved.

#### DataMiner Cube: Pattern edit menu would incorrectly open when you resized the selected area in a trend graph [ID_35627]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you resized the selected area in a trend graph by dragging either the left or right selection boundary, the pattern edit menu would incorrectly open, even when you were not allowed to create a pattern or when you had no intention of editing a pattern.

#### DataMiner Cube - Alarm Console: Problem when a session variable was used in an alarm filter [ID_35681]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you applied a filter to an alarm tab, no alarms would be shown when you had used a session variable in the filter.

#### DataMiner Cube: Exception values with decimals would be displayed incorrectly in trend graph [ID_35714]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Because DataMiner Cube would use the incorrect culture when parsing exception values, in some cases, exception values with decimals would be displayed incorrectly in trend graphs.

#### DataMiner Cube - Asset Manager app: Enum fields would not immediately be updated after clicking 'Apply' [ID_35747]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When, in the *Asset Manager* app, you tried to update an enum field, the value would not immediately be updated in the UI after clicking *Apply*.

#### No longer possible to configure a PDF report generated based on a dashboard [ID_35874]

<!-- MR 10.4.0 - FR 10.3.4 [CU0] -->

When, in the *Automation*, *Correlation* and *Scheduler* modules, you generated a PDF report based on a dashboard, it would incorrectly no longer be possible to click the *Configure* button to configure that report.
