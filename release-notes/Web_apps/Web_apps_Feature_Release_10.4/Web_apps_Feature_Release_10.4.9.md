---
uid: Web_apps_Feature_Release_10.4.9
---

# DataMiner web apps Feature Release 10.4.9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.9](xref:General_Feature_Release_10.4.9).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.9](xref:Cube_Feature_Release_10.4.9).

## New features

#### Low-Code Apps: New 'Interactive automation script' component [ID 39969]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In low-code apps, you can now use *Interactive automation script* components.

An *Interactive automation script* component allows you to launch a preset interactive automation script (ad hoc, on view, or after an event has occurred) and to display its UI. It also allows you to select a script and launch it, or to abort the script that is being run.

When you launch a new script while another is being run, the new script will start once the other script has finished.

In the settings of the component, you can also opt to have the component either show or hide the name of the script.

> [!NOTE]
>
> - The component cannot be used to launch automation scripts that are not interactive.
> - The component will not ask for any missing parameters or dummies. It expects them to be filled in either in its settings or via feeds. When input is missing, the script will not be launched and the component will be blank.
> - By default, scripts will time out after 15 minutes. If a script times out, an error will be displayed in the component.

#### Low-Code Apps: New 'Set value' action [ID 40252]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

It is now possible to configure a *Set value* action for a *Numeric input*, *Text input* or *Search input* component.

This action will allow users to set the current value of the component in question to either a static value or a feed.

When the component has the *General > Feed value on > Value change* option enabled, the value will immediately be passed as the component's feed.
If the component does not have this option enabled, the value will only be passed as the component's feed on `Enter` or `Focus lost`.

## Changes

### Enhancements

#### Dashboards app & Low-Code Apps: Enhanced retrieval of element/protocol parameters [ID 39954]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, from now on, all components that retrieve element/protocol parameters will do so more efficiently.

#### Dashboards app & Low-Code Apps: Several components now support zooming in/out using Ctrl+Scroll [ID 40017]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

From now on, you will be able to zoom in and out using Ctrl+Scroll on the following components:

- Line & area chart

- Node edge graph

- Service definition

- Maps

- Visual Overview

- Timeline

#### Web API: DOM methods will no longer check whether DOM object GUIDs are empty [ID 40024]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Up to now, the DOM methods in the web API would check whether a DOM object GUID was empty, and would block the call if this was the case.

As the DOM SLNet API support objects with empty GUIDs, all empty GUID checks have now been removed from the web API.

#### Low-Code Apps: Enhancements with regard to concurrent editing [ID 40075]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

A number of enhancements have been made to prevent issues from occurring when a low-code app is being edited by multiple users at the same time.

When one user makes a change to a low-code app, all other users who are editing the same app will receive a notice saying that they should reload the app because changes were made. If a user ignores that notice and tries to make changes anyway, the header bar will show an error message saying that the edit has failed.

#### Low-Code Apps: Header bar enhancements [ID 40077]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In the header bar of a low-code app, all app options (e.g., *Versions*, *Settings*, *Duplicate app*, etc.) have been moved from the user menu to a separate menu.

In published and previewed apps, the *Edit* button will now always be displayed directly in the header bar. It will no longer be in a separate menu.

#### Dashboards app & Low-Code Apps: Enhanced performance when loading dashboards, pages and panels that contain trend graphs [ID 40079]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, overall performance has increased when loading dashboards, pages and panels that contain trend graphs.

#### Review of all interactive automation script components to make sure they fully inherit the correct theme [ID 40092]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

As from DataMiner version 10.4.4, when an interactive automation script is launched from a web app, the windows and popups of that script will inherit the foreground color and the default component background color of the page, panel or dashboard from which the script was launched.

All interactive automation scripts components have now been reviewed to make sure they fully inherit the correct theme.

#### Security enhancements [ID 40210] [ID 40290]

<!-- 40210: MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->
<!-- 40290: MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

A number of security enhancements have been made.

#### Dashboards app & Low-Code Apps: Time range feed will now automatically adapt its color scheme and width [ID 40226]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Up to now, a *Time range* feed would always have a white background and take the full width of the dashboard or low-code app. From now on, it will automatically adapt its color scheme to the dashboard theme and adjust its width depending on the number of columns it has to show in its filter pane.

#### Web apps: Placeholders in empty text boxes will now be displayed more clearly [ID 40233]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In all DataMiner web applications, placeholders in empty text boxes will now be displayed more clearly, especially when a dark theme is being used.

#### Dashboards app: Improved positioning of WebSocket connection status indicator on shared dashboards [ID 40294]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

On shared dashboards, the position of the WebSocket connection status indicator in the top-right corner of the screen has been improved.

#### Dashboards app & Low-Code Apps: Number of GQI queries is now limited [ID 40370]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

From now on, the number of GQI queries that can be added to a dashboard or a low-code app will be limited.

- A dashboard can contain a maximum of 30 GQI queries.
- A low-code app can contain a maximum of 200 GQI queries.

### Fixes

#### Dashboards app & Low-Code Apps: Problem when a tree view is expanded or collapsed in an interactive automation script [ID 39862]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, in a interactive automation script launched from a dashboard or a low-code app, a tree view component was expanded or collapsed, in some cases, multiple *Continue* messages would incorrectly be sent to the script. From now on, when a tree view component is expanded or collapsed, only one *Continue* message will be sent.

#### Web apps: Users would not get logged in after pressing ENTER on the authentication page [ID 39961]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, on a mobile device, you entered your credentials on the authentication page of a DataMiner web app and pressed ENTER, you would incorrectly not be logged in. Instead, the authentication page would simply refresh.

#### Dashboards app & Low-Code Apps: Parameters dataset would not include any parameters of type 'Button' when filtered by protocol [ID 39973]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, in the *Parameters* dataset, you filtered by protocol, the parameters list would incorrectly not include any parameters of type "Button".

#### Dashboards app & Low-Code Apps - Timeline component: Regional settings would not be taken into account [ID 39987]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When positioning items, the *Timeline* component would incorrectly not take into account the regional settings (e.g., time zone) specified in the `C:\Skyline DataMiner\users\ClientSettings.json` file.

#### Dashboards app & Low-Code Apps - Table component: Problem when grouping an empty table by a column [ID 40012]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, when an empty table was grouped by a column, the grouping would not be applied.

#### Dashboards app & Low-Code Apps - Ad hoc data sources & custom operators: Timespan metadata would not be converted to the local time zone [ID 40033]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When you link dataminer objects to rows in an ad hoc data source or when you configure a custom operator, you can add timespan data as metadata. Up to now, this timespan metadata would incorrectly not be converted to the local timezone specified in the `C:\Skyline DataMiner\users\ClientSettings.json` file.

> [!TIP]
> See also:
>
> - [Linking rows to DataMiner objects](xref:Ad_hoc_Metadata)
> - [Modifying links to DataMiner objects](xref:CO_Metadata)

#### Dashboards app & Low-Code Apps: Time range component would pass along a reversed time range to another time range component [ID 40056]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When a time range feed component fed a time range to another time range feed component, in some cases, it would pass along a reversed time range.

#### Monitoring app - Visual Overview: Pop-up window would incorrectly not open when navigating from another card page [ID 40140]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, in the Monitoring app, you navigated from a card page to a visual overview page, and then tried to open a pop-up window, that pop-up window would incorrectly not open.

#### Web API would throw a 'Compatibility Manager not initialized yet' error [ID 40148]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, the web API would throw a `Compatibility Manager not initialized yet` error. Error handling has now been enhanced to prevent this error from being thrown.

#### Dashboards app & Low-Code Apps: Bookings feed would no longer return any bookings matching the filter [ID 40157]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Since DataMiner version 10.4.6, a bookings feed would incorrectly no longer return any bookings matching the filter. From now on, the bookings feed will again return all bookings that match the filter.

#### Dashboards app & Low-Code Apps: Components could lose focus after having been resized [ID 40180]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, components could lose focus after having been resized.

#### Low-Code Apps: Description of 'Close all panels' action set to 'Do nothing' after a migration from a version older than 10.4.7 [ID 40191]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When you opened a low-code app that was migrated from a version older than version 10.4.7, the *Close all panels* action had an incorrect description. Instead of "Close all panels", the description was incorrectly set to "Do nothing".

#### Dashboards app & Low-Code Apps - Table component: Table filter would incorrectly take into account hidden columns [ID 40196]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When you used the search box to apply a general filter across a table, up to now, matches in hidden columns would incorrectly also be taken into account. As a result, after you had applied a filter, in some cases, rows without any visual match could get filtered out.

#### Dashboards app & Low-Code Apps: Query used as a 'start from' query and linked to a feed and a Trigger component would no longer be updated following a feed update once the Trigger component had been triggered [ID 40207]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When a query used as a "start from" query was linked to a feed and a *Trigger* component, in some cases, feed updates would no longer update the query once the Trigger component had been triggered.

#### Web API - GQI: Query version would incorrectly not be equal to the GQI version after a migration [ID 40216]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

After a GQI query had been migrated, in some cases, the query version would incorrectly not be equal to the GQI version, leading to unexpected behavior.

#### Low-code Apps - Action editor: Problems with window width and 'Navigate to a URL' action favicon [ID 40239]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Up to now, the action editor window could get too wide to fit onto a screen. Its width has now been limited.

Also, up to now, while a *Navigate to a URL* action would automatically add a `http://` or `https://` prefix, its favicon incorrectly would not. This has now been fixed.

#### Dashboards app: Table and State components would not be rendered correctly when generating PDF reports [ID 40261]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

when you generated a PDF report based on a dashboard, in some cases, Table and State components would not be rendered correctly.

#### Web API: Problem when a low-code app was created while a page was being added to another low-code app [ID 40280]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When a low-code app was created while a page was being added to another low-code app, in some cases, the web API could get into a deadlock, causing all low-code apps to become unresponsive.

#### Dashboards app & Low-Code Apps - Table component: Loading bar would incorrectly be displayed behind the data in the first table row [ID 40325]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When data was being loading into a table component of which the appearance of a column had been customized, the "Loading" bar would incorrectly be displayed behind the data in the first table row.

#### Dashboards app: State components would not be rendered correctly when generating a PDF report [ID 40327]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When you shared a dashboard as a PDF report, *State* components would not be rendered correctly when you had not selected the *Stack components* option.

Also, when you shared a dashboard as a PDF report, component templates containing text boxes would not be rendered correctly.

#### Web API: Problem with client logging due to errors being serialized to invalid JSON [ID 40352]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When an app threw an error, that error would be serialized to invalid JSON. As a result, it would get added to the client logs in invalid JSON format.

#### Dashboards app & Low-Code Apps: Parameter subscriptions would not be closed due to a memory leak in the State component [ID 40360]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Due to a memory leak in the *State* component, parameter subscriptions would incorrectly not be closed.

#### Dashboards app & Low-Code Apps - Dropdown component: Problem with 'Select first item by default' option [ID 40362]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When a *Dropdown* component had its *Select first item by default* option selected, the first item would incorrectly not get selected when the items in that component depended on another *Dropdown* component in which the first item was selected.

#### Monitoring app: 'Connection has been interrupted' message would not disappear when the connection was restored [ID 40364]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When the Monitoring app is connected to a DaaS system, a "Connection has been interrupted" message will appear when the connection is lost. Up to now, when you reloaded the app, the "Connection has been interrupted" message would incorrectly not disappear when the connection was restored.

#### Dashboards app & Low-Code Apps - Query filter feed: Icon of 'Toggle free form'/'Toggle checklist' button would not match its label [ID 40367]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In a *Query filter feed* component, next to columns containing discrete values of type string or number, you can find a button that allows you to change how the possible values are displayed when you hover your mouse over it. This button will have a label that reads either *Toggle free form* or *Toggle checklist*. Up now on, the button's icon would not match the button's label.

#### Dashboards app: Problem when hovering over a long dashboard name in the sidebar [ID 40390]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, in the sidebar, you hovered the mouse pointer over an ellipsed long dashboard name, the full name would be displayed on two lines, causing the entire list to shift.

From now on, when you hover the mouse pointer over an ellipsed long dashboard name, the full name will be shown in a tooltip instead.
