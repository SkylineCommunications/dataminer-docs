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

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards app: 'HTTP 404' page replaced by an embedded visual [ID 44569]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

From now on, when you try to open an invalid dashboard or dashboard folder, you wil no longer be redirected to a separate "HTTP 404" page. Instead, a visual will now appear inside the Dashboards app.

Clicking the *Go to overview* button in that visual will redirect you to either the closest valid parent folder or the root folder.

### Fixes

#### Dashboards/Low-Code Apps - Alarm table component: Problems when scrolling [ID 44662]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In the alarm table component, a number of minor issues have been fixed:

- In edit mode, the component name in the footer would shift along when the component was scrolled horizontally or vertically.

- The header containing the total number of alarms and the filter box would shift out of view when you scrolled vertically.

- In some cases, the *Load next ... alarms* button, which was centered horizontally, would not be visible until you scrolled to the side.

#### Low-Code Apps - Template editor & flow editor: Tabbed pane on the left would shrink when the editor area contained a large number of items [ID 44671]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In both the template editor and the flow editor, the tabbed pane on the left would incorrectly shrink when the main editor area in the middle contained a large number of items.
