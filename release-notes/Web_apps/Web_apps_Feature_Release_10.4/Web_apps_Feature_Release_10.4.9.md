---
uid: Web_apps_Feature_Release_10.4.9
---

# DataMiner web apps Feature Release 10.4.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.9](xref:General_Feature_Release_10.4.9).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps: New 'Interactive Automation script' component [ID_39969]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In low-code apps, you can now use *Interactive Automation script* components.

An *Interactive Automation script* component allows you to launch a preset interactive Automation script (ad hoc, on view, or after an event has occurred) and to display its UI. It also allows you to select a script and launch it, or to abort the script that is being run.

When you launch a new script while another is being run, the new script will start once the other script has finished.

In the settings of the component, you can also opt to have the component either show or hide the name of the script.

> [!NOTE]
>
> - The component cannot be used to launch Automation scripts that are not interactive.
> - The component will not ask for any missing parameters or dummies. It expects them to be filled in either in its settings or via feeds. When input is missing, the script will not be launched and the component will be blank.
> - By default, scripts will time out after 15 minutes. If a script times out, an error will be displayed in the component.

## Changes

### Enhancements

#### Dashboards app & Low-Code Apps: Enhanced retrieval of element/protocol parameters [ID_39954]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, from now on, all components that retrieve element/protocol parameters will do so more efficiently.

#### Dashboards app & Low-Code Apps: All components now support zooming in/out using CTRL+Scroll [ID_40017]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

From now on, in all components, you will be able to zoom in and out using CTRL+Scroll.

#### Web API: DOM methods will no longer check whether DOM object GUIDs are empty [ID_40024]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Up to now, the DOM methods in the web API would check whether a DOM object GUID was empty, and would block the call if this was the case.

As the DOM SLNet API support objects with empty GUIDs, all empty GUID checks have now been removed from the web API.

#### Low-Code Apps: Enhancements with regard to concurrent editing [ID_40075]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

A number of enhancements have been made to prevent issues from occurring when a low-code app is being edited by multiple users at the same time.

When one user makes a change to a low-code app, all other users who are editing the same app will receive a notice saying that they should reload the app because changes were made. If a user ignores that notice and tries to make changes anyway, the header bar will show an error message saying that the edit has failed.

#### Dashboards app & Low-Code Apps: Enhanced performance when loading dashboards, pages and panels that contain trend graphs [ID_40079]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, overall performance has increased when loading dashboards, pages and panels that contain trend graphs.

### Fixes

#### Web apps: Users would not get logged in after pressing ENTER on the authentication page [ID_39961]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, on a mobile device, you entered your credentials on the authentication page of a DataMiner web app and pressed ENTER, you would incorrectly not be logged in. Instead, the authentication page would simply refresh.

#### Dashboards app & Low-Code Apps: Parameters data set would not include any parameters of type 'Button' when filtered by protocol [ID_39973]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, in the *Parameters* data set, you filtered by protocol, the parameters list would incorrectly not include any parameters of type "Button".

#### Dashboards app & Low-Code Apps - Timeline component: Regional settings would not be taken into account [ID_39987]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When positioning items, the *Timeline* component would incorrectly not take into account the regional settings (e.g. time zone) specified in the *C:\\Skyline DataMiner\\users\\ClientSettings.json* file.

#### Dashboards app & Low-Code Apps - Table component: Problem when grouping an empty table by a column [ID_40012]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, when an empty table was grouped by a column, the grouping would not be applied.

#### Dashboards app & Low-Code Apps - Ad hoc data sources & custom operators: Timespan metadata would not be converted to the local time zone [ID_40033]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When you link dataminer objects to rows in an ad hoc data source or when you configure a custom operator, you can add timespan data as metadata. Up to now, this timespan metadata would incorrectly not be converted to the local timezone specified in the *C:\\Skyline DataMiner\\users\\ClientSettings.json* file.

> [!TIP]
> See also:
>
> - [Linking rows to DataMiner objects](xref:Ad_hoc_Metadata)
> - [Modifying links to DataMiner objects](xref:CO_Metadata)

#### Dashboards app & Low-Code Apps: Time range component would pass along a reversed time range to another time range component [ID_40056]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When a time range feed component fed a time range to another time range feed component, in some cases, it would pass along a reversed time range.

#### Web API would throw a 'Compatibility Manager not initialized yet' error [ID_40148]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, the web API would throw a `Compatibility Manager not initialized yet` error. Error handling has now been enhanced to prevent this error from being thrown.

#### Dashboards app & Low-Code Apps: Bookings feed would no longer return any bookings matching the filter [ID_40157]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Since DataMiner version 10.4.6, a bookings feed would incorrectly no longer return any bookings matching the filter. From now on, the bookings feed will again return all bookings that match the filter.

#### Dashboards app & Low-Code Apps: Components could lose focus after having been resized [ID_40180]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, components could lose focus after having been resized.

#### Low-Code Apps: Description of 'Close all panels' action set to 'Do nothing' after a migration from a version older than 10.4.7 [ID_40191]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When you opened a low-code app that was migrated from a version older than version 10.4.7, the *Close all panels* action had an incorrect description. Instead of "Close all panels", the description was incorrectly set to "Do nothing".

#### Dashboards app & Low-Code Apps - Table component: Table filter would incorrectly take into account hidden columns [ID_40196]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When you used the search box to apply a general filter across a table, up to now, matches in hidden columns would incorrectly also be taken into account. As a result, after you had applied a filter, in some cases, rows without any visual match could get filtered out.

#### Dashboards app & Low-Code Apps: Query used as a 'start from' query and linked to a feed and a Trigger component would no longer be updated following a feed update once the Trigger component had been triggered [ID_40207]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When a query used as a "start from" query was linked to a feed and a *Trigger* component, in some cases, feed updates would no longer update the query once the Trigger component had been triggered.
