---
uid: Web_apps_Feature_Release_10.4.8
---

# DataMiner web apps Feature Release 10.4.8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.8](xref:General_Feature_Release_10.4.8).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.8](xref:Cube_Feature_Release_10.4.8).

## Changes

### Enhancements

#### Dashboards app & Low-Code Apps: Enhancements related to the configuration of conditional graph colors [ID 39746]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made with regard to the configuration of conditional graph colors.

#### Dashboards app: Enhanced input validation when updating theme colors [ID 39749]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made with regard to the validation of theme color updates.

When you specify invalid colors or invalid regex patterns, you will not be able to click *Save* until all invalid values have been corrected.

#### Low-Code Apps: Default table cell hyperlink will no longer contain the URL of the DMA [ID 39963]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

Up to now, a table cell hyperlink would by default be the URL of the DataMiner Agent, followed by `{cellValue}`. From now on, a table cell hyperlink will by default be `{cellValue}`, without the URL of the DataMiner Agent.

### Fixes

#### Dashboards app & Low-Code Apps: Interactive Automation scripts launched from a node edge graph or a context menu action would not inherit the theme of the dashboard or low-code app [ID 39664]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When an interactive Automation script was launched from a node edge graph or a context menu action, the script would incorrectly not inherit the theme of the dashboard or low-code app.

#### Dashboards app & Low-Code Apps: Problems with feed links after migrating a dashboard or app [ID 39744]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

After a dashboard or a low-code app had been migrated from DataMiner server version 10.3.8 to DataMiner server version 10.3.9 or later,feed links defined in the web component, the text component or the *Navigate to a URL* action would no longer work.

#### Low-Code Apps: Problem when executing an 'Opening an app' action in which no app had been specified [ID 39785]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When a low-code app executed an *Opening an app* action in which no app had been specified, an error would occur.

From now on, when an incorrectly configured action is detected, it will no longer be executed. Instead, an error message will appear.

#### Dashboards app & Low-Code Apps: Problem when a Form component had to show the same data to multiple users [ID 39801]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When a form component on a dashboard or in a low-code app had to show the same data to multiple users, in some rare cases, an error could occur in the web APIs, causing the component to not show any data at all.

#### Low-Code Apps: Form component not able to create instances [ID 39808]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

In some cases, a form component would not be able to create instances when the behavior definition contained fields with default values that were not linked to the initial state.

#### Dashboards app & Low-Code Apps: Problems when configuring a Node edge graph component [ID 39821]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

In some cases, a runtime error could occur when configuring a node edge graph component.

#### Dashboards app - Column & bar chart component: Chart and legend would show different colors after removing a bar [ID 39847]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When, in edit mode, you removed a bar from a *Colum & bar chart* component, in some cases, the chart and the legend would show different colors.

#### Dashboards app & Low-Code Apps - Maps component: Problem when changing a layer setting [ID 39855]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When you changed a value in the layer settings of a maps component, all settings would be reloaded and the text box containing the value you changed would go out of bounds.

#### Dashboards app: Problem when updating the name of a dashboard folder while a dashboard was open [ID 39873]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When you updated the name of a dashboard folder while a dashboard was open, in some cases, a `Dashboard has not been found` error would be thrown.

#### Dashboards app: Components showing the result of a query filtered by feeds would not get updated when the feed values changed [ID 39877]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

In a dashboard, in some cases, components showing the result of a query filtered by feeds would not get updated when the feed values changed.

Also, in some cases, a query could keep on updating when it was linked to a time range feed that exposed a sliding window (e.g. "last 5 minutes").

#### Dashboards app & Low-Code Apps - Pie & donut chart component: Pie chart would not re-appear after an error message had disappeared [ID 39879]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When a pie chart disappeared to allow an error message to get displayed, in some cases, it would incorrectly not re-appear after the error message had disappeared.

#### Web API would incorrectly retrieve the time zone from the user-specific ClientSettings.json file [ID 39897]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

Up to now, the web API would incorrectly retrieve the current time zone from the *ClientSettings.json* file located in the user-specific `C:\Skyline DataMiner\users\<username>\` folder.

From now on, the current time zone will be retrieved from the *ClientSettings.json* file located in the `C:\Skyline DataMiner\users\` folder, which applies to all users.

#### Low-Code Apps: The app would incorrectly open in edit mode when you clicked 'Preview draft' [ID 39935]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When clicked *Preview draft* immediately after refreshing the browser window, in some rare cases, the draft version of the app would not be shown. Instead, the app would incorrectly open in edit mode.

#### Web API: Problem during the initialization of the dashboard cache would cause 'Dashboard was not found' errors to be displayed when opening low-code apps [ID 39946]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When you deleted a low-code app while the dashboard cache was still being initialized, in some cases, an exception could be thrown, and when, later on, you tried to open an app, a `Dashboard was not found` error would be displayed.

#### Dashboards app & Low-Code Apps: Parameter page component would incorrectly not use the time zone specified in the C:\\Skyline DataMiner\\users\\ClientSettings.json file [ID 39947]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

In dashboards and low-code apps, the *Parameter page* component would incorrectly not use the time zone specified in the *ClientSettings.json* file located in the `C:\Skyline DataMiner\users\` folder, which applies to all users.

From now on, this component will correctly use the time zone specified in the above-mentioned *ClientSettings.json* file.

#### Low-Code Apps - Timeline component: Timeline items would no longer be visible when you zoomed out on them [ID 39962]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When you kept on zooming out on a timeline item, at some point, that item would no longer be visible.

#### Dashboards app & Low-Code Apps - Query filters: Problem with highlight filtering on an enum value linked to a DOM object [ID 39971]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

Highlight filtering on an enum value linked to a DOM object would no longer work.

#### Low-Code Apps: Empty actions would incorrectly be considered invalid [ID 40027]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 [CU0] -->

Up to now, empty actions would incorrectly be considered invalid, causing a `This action is invalid` error to be thrown whenever they were executed.

As empty actions are added by default when you open the action editor of an event, from now on, empty actions will no longer be considered invalid. An error will only be thrown when an action has an invalid configuration.

#### Dashboards app & Low-Code Apps: App could become unresponsive due incorrectly configured overrides in GQI templates [ID 40171]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 [CU0] -->

In some cases, a GQI template could throw a large number of exceptions, causing the app to become unresponsive. This would occur when a GQI template in a GQI visual contained shapes that had overrides in which not all conditions had been filled in.
