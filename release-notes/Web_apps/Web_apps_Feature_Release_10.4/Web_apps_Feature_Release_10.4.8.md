---
uid: Web_apps_Feature_Release_10.4.8
---

# DataMiner web apps Feature Release 10.4.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.8](xref:General_Feature_Release_10.4.8).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards app & Low-Code Apps: Enhancements related to the configuration of conditional graph colors [ID_39746]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made with regard to the configuration of conditional graph colors.

#### Dashboards app: Enhanced input validation when updating theme colors [ID_39749]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made with regard to the validation of theme color updates.

When you specify invalid colors or invalid regex patterns, you will not be able to click *Save* until all invalid values have been corrected.

### Fixes

#### Dashboards app & Low-Code Apps: Interactive Automation scripts launched from a node edge graph or a context menu action would not inherit the theme of the dashboard or low-code app [ID_39664]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When an interactive Automation script was launched from a node edge graph or a context menu action, the script would incorrectly not inherit the theme of the dashboard or low-code app.

#### Dashboards app & Low-Code Apps: Problems with feed links after migrating a dashboard or app [ID_39744]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

After a dashboard or a low-code app had been migrated from DataMiner server version 10.3.8 to DataMiner server version 10.3.9 or later,feed links defined in the *Web* component, the *Text* component or the *Navigate to a URL* action would no longer work.

#### Low-Code Apps: Problem when executing an 'Opening an app' action in which no app had been specified [ID_39785]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When a low-code app executed an *Opening an app* action in which no app had been specified, an error would occur.

From now on, when an incorrectly configured action is detected, it will no longer be executed. Instead, an error message will appear.

#### Dashboards app & Low-Code Apps: Problem when a Form component had to show the same data to multiple users [ID_39801]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When a *Form* component on a dashboard or in a low-code app had to show the same data to multiple users, in some rare cases, an error could occur in the web APIs, causing the component to not show any data at all.

#### Low-Code Apps: Form component not able to create instances [ID_39808]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

In some cases, a *Form* component would not be able to create instances when the behavior definition contained fields with default values that were not linked to the initial state.

#### Dashboards app & Low-Code Apps: Problems when configuring a Node edge graph component [ID_39821]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

In some cases, a run-time error could occur when configuring a *Node edge graph* component.

#### Dashboards app - Column & bar chart component: Chart and legend would show different colors after removing a bar [ID_39847]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When, in edit mode, you removed a bar from a *Colum & bar chart* component, in some cases, the chart and the legend would show different colors.

#### Dashboards app: Problem when updating the name of a dashboard folder while a dashboard was open [ID_39873]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When you updated the name of a dashboard folder while a dashboard was open, in some cases, a `Dashboard has not been found` error would be thrown.

#### Dashboards app: Components showing the result of a query filtered by feeds would not get updated when the feed values changed [ID_39877]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

In a dashboard, in some cases, components showing the result of a query filtered by feeds would not get updated when the feed values changed.

Also, in some cases, a query could keep on updating when it was linked to a time range feed that exposed a sliding window (e.g. "last 5 minutes").

#### Dashboards app & Low-Code Apps - Pie & donut chart component: Pie chart would not re-appear after an error message had disappeared [ID_39879]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When a pie chart disappeared to allow an error message to get displayed, in some cases, it would incorrectly not re-appear after the error message had disappeared.

#### Dashboards app & Low-Code Apps - Service definition component: Names of the resources would no longer be displayed [ID_39888]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

Due to a problem with the web API, the *Service definition* component would no longer display the names of the resources.

#### Web API would incorrectly retrieve the time zone from the user-specific ClientSettings.json file [ID_39897]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

Up to now, the web API would incorrectly retrieve the current time zone from the *ClientSettings.json* file located in the user-specific *C:\\Skyline DataMiner\\users\\<username>\\* folder.

From now on, the current time zone will be retrieved from the *ClientSettings.json* file located in the *C:\\Skyline DataMiner\\users\\* folder, which applies to all users.

#### Low-Code Apps: The app would incorrectly open in edit mode when you clicked 'Preview draft' [ID_39935]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When clicked *Preview draft* immediately after refreshing the browser window, in some rare cases, the draft version of the app would not be shown. Instead, the app would incorrectly open in edit mode.
