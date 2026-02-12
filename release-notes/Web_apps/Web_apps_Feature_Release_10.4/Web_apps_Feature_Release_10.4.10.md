---
uid: Web_apps_Feature_Release_10.4.10
---

# DataMiner web apps Feature Release 10.4.10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.10](xref:General_Feature_Release_10.4.10).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.10](xref:Cube_Feature_Release_10.4.10).

## New features

#### Dashboards/Low-Code Apps: Access permissions on folder level & view/edit permissions on low-code apps [ID 40501]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In the Dashboards app, it is now possible to grant or deny users access to specific dashboard folders.

Also, the way in which to grant or deny users permission to view and/or edit a low-code app has been enhanced.

#### Dashboards/Low-Code Apps - Line & area chart component: New 'Show title' option [ID 40504]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When configuring a *Line & area chart* component, you can now use the *Show title* option to either show or hide the automatically generated chart title.

By default, this chart title will be shown.

## Changes

### Enhancements

#### Web apps - Visual Overview: Each instance will now have its own context [ID 40225] [ID 40497]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When, in a web application, you opened multiple instances of the same visual overview with user context (e.g. a visual overview with card variables), up to now, the contexts of those instances would be shared. When, for example, you clicked a button on one instance, the same button would also be clicked on the other instances. From now on, each instance of the same visual overview will have its own context. In other words, each instance will act independently.

Also, when you open a pop-up window in a visual overview, the context of this visual overview will now be transferred to the pop-up window. As a result, in web applications, card variables will now work exactly like they work in DataMiner Cube.

#### Dashboards/Low-Code Apps: Queries with ad hoc data source with missing argument no longer executed [ID 40361]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When one or more required arguments for an ad hoc data source are missing because of an empty feed, the query using the data source will now no longer be executed and an empty visual will be shown. Previously, an error about the missing argument was thrown instead in this situation.

#### Sharing pop-up loader background adjusted [ID 40408]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you share a dashboard in the cloud, the loader that is shown while a new tab opens where you can configure the cloud share will now have the same background as the pop-up window containing the loader. Previously, there was a slight color difference between the loader background and the rest of the pop-up window.

#### Web API - DataMiner Object Models: Enhanced performance when fetching bookings from a DOM form [ID 40411]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

Because of a number of enhancements, overall performance has increased when fetching bookings from a DOM form.

From now on, the web API will no longer retrieve all available bookings. Instead, it will only retrieve a maximum of 200 bookings at a time, of which only the first 100 will initially be displayed.

#### Dashboards/Low-Code Apps - Table and Grid components: Lazy loading [ID 40463]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

Both the *Table* and the *Grid* component now support lazy loading.

- When multiple queries are configured in a *Table* component, the component will now only load the visible table.
- When a *Grid* component has paging enabled (i.e. when it has a fixed number of rows and columns), it will now only retrieve items that are being displayed on the page.

> [!NOTE]
> When items selected in the URL are not included in the data that was loaded, they will also be loaded.

#### Dashboards/Low-Code Apps: Optimized feed value resolution [ID 40513]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

Up to now, when you used to *Link to feed* option to e.g. link feed values to GQI query nodes, data would sometimes be retrieved unnecessarily.

A number of enhancements have now been made to optimize feed value resolution.

#### Dashboards app: Users who duplicate a dashboard they are not allowed to edit will now be allowed to edit the newly created duplicate [ID 40556]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you duplicated a dashboard you were not allowed to edit, up to now, you would also not be allowed to edit the newly created duplicate.

From now on, when you duplicate a dashboard you are not allowed to edit, you will be allowed to edit the newly created duplicate.

#### Dashboards/Low-Code Apps - Security: Clearer visual difference between users and user groups [ID 40575]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you are configuring who will have access to a dashboard, dashboard folder or low-code app, users and user groups will now be marked by a special icon, making it easier to see the difference between a user and a user group.

### Fixes

#### Dashboards/Low-Code Apps: Intellisense no longer working when feed is configured with special character [ID 40340] [ID 40446]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When special characters such as "(" were used when configuring a feed, Intellisense no longer worked correctly.

#### Dashboards/Low-Code Apps: Query filter feed would show a 'Statistics are missing' error when linked to a query that did not return any rows [ID 40371]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you linked a query that did not return any rows to a query filter feed with filter assistance enabled, the latter would show a "Statistics are missing" error.

#### Dashboards: Dashboard PDF set to A0 format generated as A4 instead [ID 40398]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you created a PDF of a dashboard, and you set the *Paper format* to A0, the dashboard was incorrectly generated in A4 format instead.

#### Low-Code Apps: Empty header bar menu shown for users without necessary rights to execute actions [ID 40403]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In some cases, it could occur that the "..." button to open a menu with actions was shown in the header bar of a low-code app even when a user did not have the rights to execute any actions, so that an empty menu was shown when the user clicked the button.

#### Low-Code Apps: 'New draft available' pop-up message shown twice [ID 40406]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When the "New draft available" pop-up message for a low-code app was closed immediately after it appeared, it could occur that it was incorrectly shown a second time.

#### Dashboards/Low-Code Apps: DOM instances not updated in form component [ID 40412]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In some cases, it could occur that DOM instances in a form component within a dashboard or low-code app were no longer updated when they transitioned to a different state.

#### Dashboards/Low-Code Apps: Column in table component showing incorrect values after being moved [ID 40425]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

If a template was applied to a column in a table component and that column was dragged to a different location, it could occur that it then showed the values of a different column.

#### Dashboards/Low-Code Apps: GQI real-time updates not correctly applied in timeline component when grouping was applied [ID 40474]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In a timeline component of a dashboard or low-code app, it could occur that real-time updates from GQI were not applied correctly when the timeline was grouped by a column. Deleted rows were not correctly reflected in the component, and an update could result in a duplicate entry getting added.

#### Dashboards: Problem when dragging a button parameter onto a Button component [ID 40486]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When, while editing a dashboard, you dragged a button parameter onto a *Button* component, no button would appear. Instead, the component would be empty.

#### Dashboards/Low-Code Apps: 'Cannot read property of null (reading 'IsTable')' error [ID 40514]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In some cases, the following error could appear in the *State*, *Dropdown*, and *Parameter table* components:

``Cannot read property of null (reading 'IsTable')``

> [!NOTE]
> When this error appeared in a *Parameter table* component, the dashboard would keep on loading.

#### Dashboards/Low-Code Apps: Problem when you removed a component and then added another component [ID 40525]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you removed a component from a dashboard, and then added another component by first dropping data onto the dashboard and then picking the visualization afterwards, in some cases, runtime errors could be thrown that would make the dashboard unusable until you refreshed the app.

#### Dashboards app: Incorrect warning message would appear when stripping a dashboard (folder) creator of the edit permission [ID 40540]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When the person who created a dashboard or a dashboard folder was stripped of the permission to edit that dashboard or that dashboard folder, a warning message would appear, even if that person still had edit permission via "All members" of via a user group.

From now on, that warning message will no longer appear if the person in question still has edit permission via "All members" or via a user group.

#### Low-Code Apps: DOM instance updates could incorrectly get lost when a DOM instance subscription was stopped [ID 40551]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When a DOM instance subscription was stopped (e.g. by closing a browser tab) while another DOM instance was being updated, up to now, that DOM instance update could incorrectly get lost.

#### Dashboards app: Problem when trying to rename a dashboard folder [ID 40585]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In some rare cases, an error could be thrown when you tried to rename a dashboard folder.

#### Dashboards app: Problem when trying to delete a dashboard folder [ID 40586]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In some cases, an error could be thrown when you tried to delete a dashboard folder.

#### Dashboards/Low-Code Apps - Form component: Problem in case of multiple open connections [ID 40599]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

Up to now, only one connection could subscribe to *DOMInstanceChangeEvents* per DOM module. This meant that only the first connection would receive events to update the Form component in the client, and that every subsequent connection would not receive any updates as long as the first connection stayed open.

From now on, every *DOMInstanceChangeEvents* subscription will get a unique connection ID.

#### Dashboards/Low-Code Apps - Time range component: Problem when picking a custom time range [ID 40608]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When, in the *Time range* component, you picked a custom time range, the picker would become transparent, making it difficult to read its contents, especially when a dark dashboard theme was being used. From now on, the picker will no longer be transparent and will adapt its color scheme to the dashboard theme that is being used.

#### Dashboards/Low-Code Apps: Line & area chart component would not update correctly when the feed input changed [ID 40620]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 [CU0] -->

In some cases, a *Line & area chart* component would not update correctly whenever the feed input changed.

#### Dashboards/Low-Code Apps - Grid component: Problem when refetching data while data was being loaded [ID 40633]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 [CU0] -->

When the data displayed in a Grid component was refetched (by means of e.g. a refetch action or a Trigger component) while the component was busy loading data, the newly fetched data would not get loaded correctly.

#### Low-Code Apps - Timeline component: Groups would reserve more screen real estate than necessary due to a time zone conversion issue [ID 40639]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 [CU0] -->

Due to a time zone conversion issue, groups configured in a *Timeline* component would reserve more screen real estate than necessary.

#### Low-Code Apps - Table component: Problem with 'Select an item' action [ID 40643]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 [CU0] -->

When, in a low-code app, you had configured a "Select an item" action in a *Table* component, up to now, that action would not work when the *Table* component displayed less than fifty DOM instances.

#### Low-Code Apps - Interactive automation script component: Problem with scrollbars appearing unnecessarily [ID 40645]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 [CU0] -->

Up to now, when an interactive automation script was run inside an *Interactive automation script* component, the dimensions configured in the script would be ignored. Instead, the script would fill the entire component. Also, since the introduction of the *Interactive automation script* component, when an interactive automation script was run independently, scrollbars could appear unnecessarily in the script's pop-up windows.

From now on, the configured dimensions will never be ignored. Whether an interactive automation script is run inside an *Interactive automation script* component or whether it is run independently, its windows will now always behave in the same way.

#### Applying the theme and accent color to components used in places other than interactive automation scripts will now be optional [ID 40802]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 [CU0] -->

In feature release 10.4.9, all interactive automation script components were reviewed to make sure they fully inherit the script's theme and accent color. However, in some cases, changing the coloring of those components could cause issues when those components were used in other places (e.g. web apps).

From now on, when the above-mentioned components are used in places other than interactive automation scripts, applying the theme and accent color to those components will be optional. In interactive automation scripts, the theme and accent color will always be applied to the script's components.

#### Web API: Problem when sending heartbeats to GQI when an inactive connection had not yet been removed [ID 40826]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 [CU0] -->

When the web API was sending heartbeats to GQI, the following exception could be thrown when an inactive connection had not yet been removed:

`Collection was modified; enumeration operation may not execute.`
