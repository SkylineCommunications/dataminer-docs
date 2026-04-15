---
uid: Web_apps_Feature_Release_10.6.6
---

# DataMiner web apps Feature Release 10.6.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU3].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.6](xref:General_Feature_Release_10.6.6).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.6](xref:Cube_Feature_Release_10.6.6).

## Highlights

*No highlights have been selected yet.*

## New features

#### Dashboards/Low-Code Apps: New 'Rich text input' component [ID 45097] [ID 45180]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

A new basic control named *Rich text input* now allows you to enter rich text that will be exposed as HTML.

Its toolbar offers the following formatting options:

- Headings: Levels 1 to 4
- Lists: Bulleted list and Numbered list
- Blockquote
- Code block
- Font color
- Inline text formatting: Bold (Ctrl+B), Italic (Ctrl+I), Underline (Ctrl+U), and Strikethrough
- Hyperlinks: Insert, Edit, and Remove
- History: Undo (Ctrl+Z) and Redo (Ctrl+Y)

In the *Settings* pane for this component, you can configure the following settings:

| Section | Option | Description |
|--|--|--|
| General | Emit value on | Determine when the value in the box becomes available as data. This can be when the focus is no longer on the box ("Focus lost"), or when the value in the box changes ("Value change").<br>If you select *Focus lost*, the value will also become available when the user presses Enter. |
| General | Default value | Specify the default value that will be entered into the input box when the dashboard or low-code app is opened. |

Similar to all other basic controls, this new control also supports the *Set Value* component action, which sets the current value of the component to either a static or dynamic value.

#### Web apps: A custom time zone can now be specified on user level [ID 45170]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

In all web apps, it is now possible to specify a custom time zone in the user menu (which can be opened by clicking the user icon in the header bar).

If you do so, the custom time zone you specify will override the local time of the client machine on user level.

Note that, when a time zone is enforced for all users, this user-level setting will be disabled.

## Changes

### Enhancements

#### Monitoring app: 'HTTP 404' page replaced by an embedded visual [ID 45027]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

From now on, when you try to open a non-existing page, you wil no longer be redirected to a separate "HTTP 404" page. Instead, a visual will now appear inside the Monitoring app.

Clicking the *Go to overview* button in that visual will redirect you back to the home page of the app.

#### GQI DxM: Custom property columns will now be referenced by their name instead of by their ID [ID 45085] [ID 45287]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Custom property columns will now be referenced by their name instead of by their ID. This will ensure that, if certain objects are moved from one DataMiner System to another (e.g., by means of a DELT export), and a query that references a custom property linked to those objects is also moved to that other system, the query will still work.

Previously these queries would break when moved to another system because, in some cases, the custom properties would be assigned another ID on that other system.

The "by ID" columns will remain on the data sources for backward compatibility to make sure that existing queries are not affected. These columns will now be marked as `IsHidden` and "*(Legacy)*" will be added to their name. Client applications can then use this information to hide these columns and only show them in case they were already selected. On newly created queries, these legacy columns will never be visible.

These changes will affect the following data sources:

- Get alarms
- Get elements
- Get services
- Get views

> [!NOTE]
> The `IsHidden` flag mentioned above is already supported by the query builder.

#### Web apps: All 'HTTP 404' pages have now been replaced by embedded visuals [ID 45152]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

From now on, when you try to open a non-existing page in either of the DataMiner web apps, you will no longer be redirected to a separate "HTTP 404" page. Instead, a visual will now appear inside the app.

Clicking the button in that visual will redirect you to the landing page or to the home page or another valid page of the app.

#### Dashboards/Low-Code Apps: Default theme of basic controls has been changed to 'Transparent' [ID 45198]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

The default theme of the following basic controls has been changed to *Transparent*:

- Button
- Dropdown
- Numeric input
- Rich text editor
- Search input
- Text input
- Time range
- Toggle

### Fixes

#### Dashboards app: Problem when trying to open a dashboard that was not present in the cache [ID 44989]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When you tried to open a dashboard that was not present in the cache, up to now, a `This dashboard does not exist` error would appear.

From now on, when you try to open a dashboard that is not present in the cache, it will be fetched from the file system instead.

#### Dashboards/Low-Code Apps: Problem when themes were being migrated when the DMA was offline [ID 45020]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When themes were being migrated, in some cases, an exception could be thrown when the DataMiner Agent was offline.

#### GQI DxM unavailable because of missing Newtonsoft.Json assembly [ID 45146]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

After an upgrade from DataMiner web 10.5.0 CU0, 10.5.2, or 10.5.3 to a higher version, the GQI DxM would be unavailable in the DataMiner web apps. Also, the GQI logging would contain a message stating `Could not load file or assembly 'Newtonsoft.Json'`.

#### Low-Code Apps: Problem when editing an app [ID 45193]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, in some cases, editing an app could result in a draft being created from an outdated version. If a new version had been published in another tab since the page was loaded, the draft would be based on the stale version visible in the UI, and the newer changes would be silently discarded.

From now on, when you click the *Edit* button, a draft will now always be created based on the latest published version.

This will also apply when duplicating an app. The latest published version will be duplicated.

> [!NOTE]
> Editing a specific version via the version history panel will function as before. In that case, a draft will always be created based on the selected version.

#### Web Services API: Compatibility manager would incorrectly not be initialized [ID 45203]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When a DataMiner Agent restarted, or when IIS restarted, in some cases, the Web Services API compatibility manager would incorrectly not be initialized, causing an error to be thrown.

#### Dashboards app: Grid lines would incorrectly stay visible after you had exited edit mode [ID 45205]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When you had clicked the *Show grid* button in the header bar of a dashboard, up to now, the grid lines would incorrectly also be visible after you had exited edit mode.

#### Monitoring app: Surveyor tree items would not be indented correctly [ID 45219]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

In some cases, Surveyor tree items would not be indented correctly.

#### Dashboards/Low-Code Apps - Time range component: Problem when component was made smaller [ID 45221]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, when a *Time range* component was made smaller, in some cases, the separators would get ellipsed, and the picker button would disappear.

#### Low-Code Apps: Duplicated panels would incorrectly not be available in the action editor [ID 45224]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, when you had duplicated a panel, it would incorrectly not be available in the action editor.

#### Low-Code Apps: Problem when a 'Change variable' action was executed in parallel with an 'Open a page' action in draft preview [ID 45234]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, when a draft version of an app was previewed, in some cases, a *Change variable* action could fail to apply its value when executed in parallel with an *Open a page* action.

#### Dashboards/Low-Code Apps - Alarm table component: Messages appearing on top of the component would take up too much space [ID 45244]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, messages appearing on top of the *Alarm table* component would take up too much space.
