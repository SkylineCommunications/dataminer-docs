---
uid: Web_apps_Feature_Release_10.4.11
---

# DataMiner web apps Feature Release 10.4.11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.11](xref:General_Feature_Release_10.4.11).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.11](xref:Cube_Feature_Release_10.4.11).

## New features

#### Web API: New methods capable of dealing with new alarm IDs [ID 40240]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

On a DataMiner System with Swarming enabled (from DataMiner 10.6.0/10.5.1 onwards), the following new methods will have to be used instead of their existing counterpart:

|New method | Existing counterpart |
|---|---|
| AddCommentToAlarmV2 | AddCommentToAlarm |
| GetAlarmDetailsV2   | GetAlarmDetails   |
| GetAlarmHistoryV2   | GetAlarmHistory   |
| GetCurrentAlarmByRootIDV3 | GetCurrentAlarmByRootIDV2 |
| MaskAlarmV2               | MaskAlarm |
| ReleaseOwnershipAlarmV2 | ReleaseOwnershipAlarm |
| TakeOwnershipAlarmV2    | TakeOwnershipAlarm    |
| UnmaskAlarmV2           | UnmaskAlarm           |

#### Low-Code Apps - Time range component: New 'Set value' action [ID 40569]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

It is now possible to configure a *Set value* action for a *Time range* component.

This action will allow users to set the current value of the component in question to either a preset range (today, yesterday, next year, ...) or a custom range (which can be either a static value or a feed).

#### Dashboards app: 'Security' selection box added to 'Create folder' window [ID 40600]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you create a dashboard folder, you will now also have to select a security setting similar to that on dashboard level.

The *Security* selection box offers the following preset options:

- Public, anyone can edit (default option)
- Protected, only you can edit
- Private, only you have access

#### Dashboards/Low-Code Apps - Table component: Applying a filter by feeding a string to the component [ID 40793]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

It is now possible to apply a filter to a Table component by feeding it a string. That string will then automatically be entered into the component's search box.

## Changes

### Enhancements

#### Web API - DataMiner Object Models: Client applications will now be notified when a DOM instance no longer matches the subscription filter [ID 40621]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

From now on, when a DOM instance no longer matches the subscription filter, the client application will be notified.

#### Dashboards/Low-Code Apps - Time range component: Apply and Cancel buttons [ID 40622]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Up to now, when you set a custom time range in the *Time range* component, the feed of the component would immediately be updated. From now on, the feed will only be updated when you click the *Apply* button.

Clicking the *Cancel* button will close the time range picker without updating the feed.

#### Dashboards/Low-Code Apps - Query filter component: Dates used in filters will now be in UTC format [ID 40653]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When, in a query filter component, you filtered by date, up to now, the date used in the filter would be in local format.

From now on, the displayed date will still be in local format, but the date that will actually be used in the filter will be in UTC format.

#### Dashboards/Low-Code Apps - Security: Enhanced loading of user access data [ID 40671]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

A number of enhancements have been made with regard to the loading of user access data when configuring user access restrictions for dashboards or low-code apps.

#### Dashboards app: Enhanced 'Location' box in 'Create dashboard' and 'Dashboard settings' windows [ID 40692]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

In the *Create dashboard* and *Dashboard settings* windows, the *Location* box has been reworked. It will now take up less screen real estate.

#### Dashboards/Low-Code Apps - Alarm table component: Enhanced performance when loading history alarms [ID 40696]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Because of a number of enhancements, overall performance of the alarm table component has increased when loading history alarms.

#### Dashboards app: 'Preserve feed selections' option is now an advanced setting [ID 40709]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Up to now, whether you added `showadvancedsettings=true` to the dashboard's URL or not, the *Create folder* window and the *Folder settings* window would always show the *Preserve feed selections* option.

From now on, the *Preserve feed selections* option will only be visible when you add `showadvancedsettings=true` to the dashboard's URL.

#### Dashboards/Low-Code Apps - Timeline component: Number of timeline items is now limited to 100,000 [ID 40761]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

From now on, the queries configured to fetch items to be displayed on a particular timeline component will no longer be allowed to fetch more than 100,000 items in total. When this limit has been reached, a message will be displayed at the bottom of the component.

#### Dashboards/Low-Code Apps - Table component: New setting to show or hide the table filter [ID 40818]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

In the *Layout* tab of a table component, it is now possible to indicate whether the table filter should be visible or not.

#### Low-Code Apps: Enhanced performance when creating a new draft of an existing low-code application [ID 40866]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Because of a number of enhancements, overall performance has increased when creating a new draft of an existing low-code application.

### Fixes

#### Low-Code Apps - Form component: Dropdown fields containing elements, resources or service definitions would show an incorrect warning message [ID 40399]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Up to now, dropdown fields defined as `ElementFieldDescriptor`, `ResourceFieldDescriptor` or `ServiceDefinitionFieldDescriptor` would display all items. However, when there were more than 100 items, an incorrect message would appear, stating that not all values were being displayed.

This behavior has now changed:

- If a dropdown field is defined as `ElementFieldDescriptor`, the above-mentioned message will no longer appear. The field will always show all elements.

- If a dropdown field is defined as `ResourceFieldDescriptor` or `ServiceDefinitionFieldDescriptor`, it will now initially show only 100 items. When there are more than 100 items, a message will appear, indicating that there are more items.

Also, dropdown fields defined as `ResourceFieldDescriptor` or `ServiceDefinitionFieldDescriptor` will now use a paging mechanism (in case of the former, only if the DataMiner server version is 10.4.9 or newer).

> [!NOTE]
>
> - If a resource is found in multiple resource pools, it will appear in a dropdown field multiple times (i.e. once for every pool it is found in).
> - If a dropdown field defined as `ResourceFieldDescriptor` or `ServiceDefinitionFieldDescriptor` contains more than 100 items, it is advised to adapt the filter in order to reduce the number of items in the dropdown field.

#### Dashboards app: Folders of which the name contained a slash ('/') or a backslash ('\\') character would stay hidden [ID 40532]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you created a dashboard folder of which the name contained a slash ("/") or a backslash ("\\") character, up to now, the folder would be created, but would stay hidden. It would not appear in the folder structure.

From now on, when you enter a folder name containing a slash ("/") or a backslash ("\\") character, an `Invalid folder name message` will appear.

#### Dashboards app: Inconsistent folder selection behavior [ID 40561]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a dashboard folder contained child folders, up to now, the main folder would open when you clicked it once, while the child folders would only open when you clicked them twice. From now on, all dashboard folders will open when you click their chevron once.

#### Dashboards/Low-Code Apps - Security: Users would incorrectly not have a profile picture [ID 40617]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you were configuring user access to a dashboard, a dashboard folder or a low-code app, up to now, users would incorrectly not have a profile picture. From now on, every user will have a profile picture.

#### Dashboards/Low-Code Apps - Security: User who duplicated a dashboard would incorrectly not be allowed to edit the newly created duplicate [ID 40627]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Up to now, when a user duplicated a dashboard with access restrictions, in some cases, that user would incorrectly not be added as editor to the user access settings of the newly created duplicate.

From now on, when a user duplicates a dashboard with access restrictions, that user will always be added as editor to the user access settings of the newly created duplicate.

#### Dashboards app: Problem when trying to delete a dashboard subfolder [ID 40634]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you tried to delete a subfolder of a dashboard folder, in some cases, an error could be thrown. That error would incorrectly state that the folder name cannot be empty.

#### Dashboards app - Security: Not possible to update the access permissions of the root folder [ID 40644]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

In some cases, it would not be possible to update the access permissions of the root folder.

#### Dashboards app: Newly added folder would incorrectly be shown twice in the UI [ID 40649]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you added a new dashboard folder, up to now, that folder would incorrectly be shown twice in the UI.

#### Dashboards app: Renaming a folder while a dashboard in that folder was open would incorrectly change the focus to the folder [ID 40656]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you opened a dashboard in a dashboard folder, and then renamed the folder, up to now, the folder would incorrectly get the focus. From now on, the focus will stay on the dashboard you opened.

#### Low-Code Apps: Output feed of a script would not be updated when a 'Launch a script' action was followed by post actions [ID 40664]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a *Launch a script* action was executed, followed by one or more post actions, the script's output feed would incorrectly not be updated.

#### Low-Code Apps: Components using feeds would not be rendered correctly [ID 40665]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

In some cases, components using feeds would not be rendered correctly.

#### Dashboards app: Parameter states would be empty if their index was not visible [ID 40672]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a parameter state had an index, but that index was not visible (e.g. a dropped process in Task Manager), up to now, the state itself would not be displayed. From now on, if a state is empty, the text "Not initialized" will be shown instead.

#### Dashboards app: URL would incorrectly not be updated when a selection was made in one of its components [ID 40673]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

In some cases, the URL of a dashboard would incorrectly not be updated when you made a selection in one of its components.

#### Dashboards/Low-Code Apps - Web component: Problem when using a URL pointing to an untrusted source [ID 40685]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

In some cases, a web component would not render a web page correctly when the URL pointed to an untrusted source.

#### Dashboards app: Problem when renaming a dashboard folder after having renamed its parent folder [ID 40688]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you renamed a dashboard folder immediately after having renamed its parent folder, the folder would be renamed in the system but the UI would incorrectly still show the old name.

#### Dashboards/Low-Code Apps - Maps component: Problem when refreshing a map [ID 40697]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a map was refreshed, in some cases, markers at the edges of the map would incorrectly disappear.

#### Low-Code Apps: New draft would incorrectly be a copy of a draft you discarded earlier [ID 40706]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you discarded a draft of a published low-code app, and then created a new draft of that same app, the new draft would incorrectly not be a copy of the published low-code app. Instead, it would be a copy of the draft you discarded earlier.

#### Dashboards/Low-Code Apps - Timeline component: Problem with 'Highlight time range' or 'Set viewport' actions when a default timezone had been set [ID 40722]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a default timezone had been set in the `C:\Skyline DataMiner\users\ClientSettings.json` file, in some cases, executing *Highlight time range* actions or *Set viewport* actions would have unexpected results.

#### Dashboards app: Problem when changing the name of several dashboard folders in rapid succession [ID 40752]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you changed the name of several dashboard folders in rapid succession, in some cases, the Dashboards app could stop working.

#### Dashboards app: Users without permission to edit dashboard folders would incorrectly be able to create or import a dashboard [ID 40778]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you did not have permission to edit the dashboards root folder or any other dashboard folder, up to now, you would incorrectly have permission to create or import a dashboard. However, you would get an error and the web API would deny your request.

From now on, when you do not have permission to edit the dashboards root folder or any other dashboard folder, you will no longer be able to create or import a dashboard.

#### Dashboards app: Problems when attaching CSV files to email reports [ID 40813]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

A number of problems could occur when attaching CSV files to email reports:

- When a CSV file was larger than 10 Mb, the generation of that file could get stuck. As this would cause the file to remain locked, it was not possible to attach it to the email message.
- When you toggled the *Include CSV* option in the report preview, the data would incorrectly already be fetched. From now on, the data will only be fetched when you click *Send*.
- When multiple components were spread over different pages of the PDF file, only the components on the last page of the PDF file would have their CSV file attached. From now on, all CSV files will get attached correctly.

#### Dashboards app: Alarm table components in a report could be empty due to a caching problem [ID 40819]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Due to a caching problem, when a report with alarm table components was generated, in some cases, those components could be empty although alarms were present on the system.

#### Dashboards/Low-Code Apps - Timeline component: Events of updated items would not be processed correctly when a custom timezone was configured [ID 40827]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a custom timezone was configured, up to now, a timeline component with the *Update data* option enabled would not correctly process the events of items that had been updated.

#### Dashboards app: Problem when importing a dashboard into a dashboard subfolder [ID 40828]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you imported a dashboard into a dashboard subfolder, the Dashboards app would navigate to an incorrect URL, causing an error to occur.

#### Dashboards/Low-Code Apps: Problem when a large amount of feed data was requested at the same time [ID 40835]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a large amount of feed data was requested at the same time (e.g. when you clicked Ctrl+A in a node edge graph component), in some cases, the Dashboards app could slow down and eventually stop working.

#### Low-Code Apps - GQI: Problem with persistent client subscriptions [ID 40852]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a client closed a GQI session, in some cases, the associated subscription would not get terminated. This would eventually lead to an excessive amount of obsolete subscriptions being left on the system, causing it to slow down.

#### Low-Code Apps: Components could incorrectly trigger updates in components to which they were not linked [ID 40875]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

In some cases, components could incorrectly trigger updates in other components, even though they were not linked.

#### Dashboards/Low-Code Apps - Timeline component: Highlighting issue when zooming [ID 40890]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a query filter is applied in a timeline component, by default, all items that are not part of the query result are shown in a lighter color. However, up to now, when zooming in or out, all items would incorrectly have the same color, whether they were part of the query result or not.

#### Low-Code Apps: Grid component that was fed with data would not create any grid items [ID 40957]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 [CU0] -->

When you opened a panel containing a Grid component that was fed with data, in some cases, that component would not create any grid items.
