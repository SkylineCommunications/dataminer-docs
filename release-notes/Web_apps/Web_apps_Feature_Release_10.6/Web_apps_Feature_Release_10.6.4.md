---
uid: Web_apps_Feature_Release_10.6.4
---

# DataMiner web apps Feature Release 10.6.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.5.0 [CU13].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.4](xref:General_Feature_Release_10.6.4).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.4](xref:Cube_Feature_Release_10.6.4).

## Highlights

*No highlights have been selected yet.*

## New features

#### Dashboards/Low-Code Apps: Anchor buttons in breadcrumbs and in the HTTP 404 visual [ID 44679]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In the Dashboards app, a new type of anchor button will now be used in breadcrumbs and in the HTTP 404 visual.

These buttons will let you navigate to a fixed location when clicked. Also, clicking such a button while holding the CTRL key pressed will open a new tab, and hovering over such a button will reveal the link associated with that button.

## Changes

### Enhancements

#### Dashboards app: 'HTTP 404' page replaced by an embedded visual [ID 44569]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

From now on, when you try to open an invalid dashboard or dashboard folder, you wil no longer be redirected to a separate "HTTP 404" page. Instead, a visual will now appear inside the Dashboards app.

Clicking the *Go to overview* button in that visual will redirect you to either the closest valid parent folder or the root folder.

#### GQI DxM: 'Get object manager instances' and 'Get profile instances' data sources now support post filtering on Guid columns [ID 44672]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Up to now, when post filtering the *Get object manager instances* and *Get profile instances* data sources, it would not be possible to filter Guid columns like DomInstanceId or DomDefinitionId.

From now, when post filtering the *Get object manager instances* and *Get profile instances* data sources, the `equals` and `not equals` filter operators will work correctly when used to filter on the following Guid columns:

- DomDefinitionId
- DomInstanceId
- ProfileDefinitionID
- ProfileInstanceID
- ReservationInstanceID
- ResourceID
- ServiceDefinitionID
- ServiceProfileInstanceID

#### Dashboards/Low-Code Apps - Templates: Text in default template would not get replaced when the default template was selected [ID 44677]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When, in the Browse templates window, you selected the default template of e.g., the Grid component, up to now, the text in that default template would incorrectly not get replaced by the text in the Grid component.

From now on, the default template text will get replaced correctly.

#### Dashboards/Low-Code Apps: Updated side panel sections [ID 44687]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When you are editing a dashboard or a low-code app, in the side panel, the top two sections of the *Data* tab are *Data used in page/panel* and *Data used in component*. These two sections have now been updated.

##### Data used in page/panel

This section, which lists all data used in the dashboard or panel, will now also indicate how this data is being used.

For example, if a data entry is used both as a data source and as a filter, two icons will now be displayed to make this clear.

The data in this section will be sorted by type and then by name.

##### Data used in component

This section, which lists all data used within the selected component, will now also include all filters and groups.

If, in the selected component, a data entry is used in multiple ways, then this will be indicated on separate lines.

The data in this section will be sorted by type (data, filter, group) and then by name. Users will be allowed to reorder the data entries, but only within their type.

#### User authentication enhancements [ID 44734]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

A number of enhancements have been made with regard to user authentication when accessing, for example, video thumbnails.

### Fixes

#### Dashboards/Low-Code Apps - Alarm table component: Problems when scrolling [ID 44662]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In the *Alarm table* component, a number of minor issues have been fixed:

- In edit mode, the component name in the footer would shift along when the component was scrolled horizontally or vertically.

- The header containing the total number of alarms and the filter box would shift out of view when you scrolled vertically.

- In some cases, the *Load next ... alarms* button, which was centered horizontally, would not be visible until you scrolled to the side.

#### Interactive Automation scripts in web apps: Redesigned Date component would incorrectly get a double update when the UI was set to V2 [ID 44665]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When the interactive Automation script UI was set to version V2, in some cases, the redesigned Date component would get a double update, causing the component to flicker.

#### Dashboards/Low-Code Apps - Column & bar chart component: Problem when changing 'Legend > Show' or 'Tooltips > Show' [ID 44667]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When, in the *Layout* tab of a *Column & bar chart* component, you changed the *Show* setting under *Legend*, up to now, the *Show* setting under *Tooltips* would incorrectly also change (and vice versa).

From now on, when you change one of these settings, the other setting will no longer change.

> [!NOTE]
> An identical issue could occur in the *Parameter groups* section of the *Parameter picker* component.

#### Low-Code Apps - Template editor & flow editor: Tabbed pane on the left would shrink when the editor area contained a large number of items [ID 44671]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In both the template editor and the flow editor, the tabbed pane on the left would incorrectly shrink when the main editor area in the middle contained a large number of items.

#### Dashboards app: State components would be clipped in PDF reports when the 'Stack components' option was not selected [ID 44695]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When you had not selected the *Stack components* option when generating a PDF report, in some cases, any *State* components on the dashboard would be clipped.

In order to prevent this from happening, the minimum width of a *State* component has now been reduced from 200px to 150px.

> [!NOTE]
> In certain situations, especially when using a narrow layout or when the available space is insufficient, *State* components can still be clipped when a PDF report is generated.

#### Low-Code Apps: Certain component actions would incorrectly not be available when using flows or variables [ID 44697]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When flows or variables were used in certain components, up to now, the available component actions would not correctly reflect the actions that would have been available if the data of the same output type had been applied directly. Some valid actions would be missing or incorrect.
