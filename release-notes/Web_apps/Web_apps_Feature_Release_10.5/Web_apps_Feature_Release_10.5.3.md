---
uid: Web_apps_Feature_Release_10.5.3
---

# DataMiner web apps Feature Release 10.5.3

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU12].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.3](xref:General_Feature_Release_10.5.3).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.3](xref:Cube_Feature_Release_10.5.3).

## Highlights

- [Dashboards/Low-Code Apps: New Toggle component [ID 41903] [ID 41911] [ID 41915]](#dashboardslow-code-apps-new-toggle-component-id-41903-id-41911-id-41915)
- [Dashboards/Low-Code Apps: Updated Time range component [ID 42082]](#dashboardslow-code-apps-updated-time-range-component-id-42082)

## New features

#### Dashboards/Low-Code Apps: Support for variables of type Boolean [ID 41845]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When editing a dashboard or a low-code app, you can now also create variables of type Boolean.

Also, boolean values can now be passed in the URL of a dashboard. See the following example of a query parameter:

`?data={"components": [{"cid":1, "select": {"booleans": ["true"]}}]}`

#### Dashboards/Low-Code Apps: Component themes now allow you to specify an accent color [ID 41859]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When customizing a component theme, you can now also specify an accent color.

By default, this accent color will be identical to the app color. For example, in the *Dashboards* app, the accent color will by default be green.

#### Dashboards/Low-Code Apps: New Toggle component [ID 41903] [ID 41911] [ID 41915]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When creating or updating a dashboard or a low-code app, you can now add *Toggle* components, which are visualized as switches.

When configuring a *Toggle* component, you can link it to a variable of type Boolean, set its default value, and specify a label and an icon. The font color, background color and accent color of the component will automatically be adapted to those specified in the theme of the dashboard or app.

When you add a *Toggle* component to a low-code app, you can also configure a *Set value* action for it. This action will allow users to either set the current value of the component in question to either a static value (True, False, or Empty) or link the component to a variable of type Boolean.

#### Dashboards/Low-Code Apps: Updated Time range component [ID 42082]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

The *Time range* component has been updated. It now has a calendar display that allows you to enter one or two date or datetime values without having to open the picker. The latter will now include a filterable list of all presets configured in the layout settings. Selecting a preset will cause a value to be updated instantly, while the selected date and time from the calendar will only be applied when you click the *Apply* button. Also, the component now follows the colors defined in the theme (font, background and accent color).

*Time range* components that were already added to a dashboard or low-code app will by default be in *Calendar* mode, showing the configured time as text, and will open the new picker when clicked. This way, the former behavior is mimicked. To change the mode, use the new *Edit using* setting explained below. New *Time range* components added as from now will automatically have the new layout (i.e. calendar and keyboard).

From now on, the *Time range* component will no longer output relative time spans. It will now always output absolute time spans. For example, selecting "last 5 minutes" will no longer output "last 5 minutes" but "DD/MM/YYYY HH:MM - DD/MM/YYYY HH:MM".

As to layout, the following has changed:

- *Horizontal alignment* has been renamed to *Quick pick alignment* and *Align current time position* has been renamed to *Input alignment*.
- *Input alignment* now has a new *Justify* option. Selecting this option will make the input of the component take the full width.

New settings:

- *Granularity*, with the following possible values:

  | Option | Description |
  |--------|-------------|
  | Date & time | Component and picker will expect you to input values that include both a date and a time. |
  | Date        | Component and picker will expect you to input values that only include a date. |

  > [!NOTE]
  > When *Granularity* is set to "Date":
  >
  > - Specifying an input like e.g. "20/01/2025 - 20/01/2025" will be considered valid. A time span like this will include the entire 24 hours, midnight to midnight.
  > - Specifying an input like e.g. "20/01/2025 00:00 - 20/01/2025 00:00" will be considered invalid as the start time is equal to the end time.

- *Edit using*, with the following possible values:

  | Option | Description |
  |--------|-------------|
  | Keyboard & Calendar | The component will allow you to specify a time range using multiple number boxes and a picker. |
  | Calendar            | The component will mimic the former behavior. The time range will be represented as text, and a picker will allow you to change the value. |

## Changes

### Enhancements

#### Low-Code Apps - Interactive automation scripts: Redesigned UI components 'Calendar' and 'Time' [ID 41529]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

The UI components `UIBlockType.Calendar` and `UIBlockType.Time` have been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Dashboards/Low-Code Apps: Node edge graph component now supports real-time updates [ID 41545]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

The *Node edge graph* component now supports real-time updates.

#### DataMiner Object Models: A confirmation box will now appear when you remove a section from a DOM form [ID 41792]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Up to now, When you removed a section from a DOM instance form with multiple sections, that section would be removed immediately, without any notification. From now on, a confirmation box will appear, prompting the user to either confirm or cancel the action.

#### Dashboards/Low-Code Apps: Linking a Trigger component to a Query filter component now allows you to refetch the columns and column statistics [ID 41799]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

By linking a *Trigger* component to a *Query filter* component, it is now possible to have the columns and column statistics refetched.

#### DataMiner root page: Links to deprecated DataMiner XBAP and legacy Reports & Dashboards app have now been removed [ID 41844]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When, on the root page of a DataMiner Agent (i.e. `https://myDMA/root/`), you click the user icon and then select *Tools*, a *Tools* page will open.

Up to now, this page would still contain links to the XBAP version of DataMiner Cube and to the legacy *Reports & Dashboards* app. As both are now deprecated, the links to both those apps as well as the *Clean DataMiner Cube XBAP Cache* link have now been removed.

#### Dashboards/Low-Code Apps - Time range component: Automatic refresh now has to be implemented via a linked Trigger component [ID 41931]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Up to now, when you wanted a *Time range* component to automatically refresh its data at regular intervals, you had to enable the *Allow refresh* option. This would then cause a refresh timer to appear (by default set to 10 seconds).

The *Allow refresh* option has now been removed. In order to have *Time range* component refresh its data at regular intervals, you now have to link a *Trigger* component to it as a filter.

#### Dashboards/Low-Code Apps - Time range component: Moved from the 'General' category to the 'Basic controls' category  [ID 41934]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

The *Time range* component has been moved from the *General* category to the *Basic controls* category. Also, its icon has now been updated to better represent a range.

#### GQI DxM improvements [ID 41949] [ID 42010]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

If the GQI DxM is installed and enabled on the local DataMiner Agent, the DataMiner web applications will now always use the GQI DxM running on the same node as the web API when building and running GQI queries. This accounts for custom logic that could be present in ad hoc data sources, requiring a configuration that is only available on a specific DMA.

#### Low-Code Apps: Default set of icon files will be created when you create a new low-code app [ID 42004]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When you create a new low-code app on the root page of a DataMiner Agent (e.g. `https://myDMA/root/`), from now on, a default set of icon files will automatically be created for that app.

#### Dashboards/Low-Code Apps - Node edge graph component: Zoom factor for arrows and KPI labels on edges is now capped [ID 42011]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

From now on, the zoom factor for arrows and KPI labels on edges will be capped. This means that, when you keep zooming in on a node edge graph, at some point, the magnification factor of the arrows and the KPI labels on edges will no longer change.

#### Low-Code Apps: 'On open' events will now be triggered without delay [ID 42039]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Up to now, *On open* events would only be triggered after all components on a page or panel were loaded. This meant that, in some cases, events would be delayed until all lazy-loaded components had been rendered, potentially requiring users to scroll down to force events to get triggered.

From now on, *On open* events will be triggered as expected, without delay.

#### Dashboards/Low-Code Apps - Grid component: Scroll position will now be retained when new data is received [ID 42071]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a *Grid* component without a fixed page size received new data, in some cases, the current scroll position would not be retained. From now on, the scroll position will be left untouched when new data is received.

### Fixes

#### Dashboards/Low-Code Apps - Table component: Refetching data would cause the data in the table to shift across the different pages [ID 41638]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a *Table* component refetched its data, in some cases, the data would incorrectly shift across the different pages.

#### Dashboards/Low-Code Apps - Timeline component: Problem with custom timezones [ID 41839]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When using a custom timezone, in some cases, that timezone would not be applied correctly in action configurations or when linking to certain components.

#### Dashboards/Low-Code Apps - State component: Scale of text would not be updated when the value of the linked parameter changed [ID 41843]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a *State* component was linked to a parameter, and the size of that component was set to "Auto", up to now, the scale of the text would not be updated when the value of the parameter changed. In some cases, this would render the text unreadable.

#### Low-Code Apps - Timeline component: Post actions after 'Set viewport' or 'Highlight time range' actions would incorrectly not be executed [ID 41862]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a post action was configured to get triggered after a *Set viewport* or a *Highlight time range* action, up to now, the post action would incorrectly not be executed.

#### Authentication screen would not redirect users to the correct app [ID 41900]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When you tried to log on to a DataMiner web app, in some cases, the authentication screen would not redirect you to the correct app.

#### Low-Code Apps: Problem when using queries in flows [ID 41955]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a low-code app used queries in some of its flows, in some cases, it could become unresponsive.

#### Dashboards app: Users would not be allowed to see any of the alarms listed in an Alarm table component of a shared dashboard [ID 41965]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When users consulted a shared dashboard containing an *Alarm table* component on which an element filter or a view filter was applied, in some cases, they would incorrectly not be allowed to see any of the alarms listed in that *Alarm table* component.

#### Dashboards/Low-Code Apps - Grid component: Problem when a linked Trigger component is triggered while viewing the last page [ID 41991]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a *Trigger* component linked to a *Grid* component was triggered while you were viewing the last page of grid data, a skeleton loading animation would incorrectly be shown. From now on, the last values will remain on the screen until the new data has been fetched.

#### Low-Code Apps: 'Change variable' action would not always apply the correct value when linked to dynamic data [ID 42027]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, the *Change variable* action would not apply the correct value, especially when it was linked to dynamic data.

#### Monitoring app: Problem when consulting alarm details when using external authentication via SAML [ID 42037]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When you logged in to the *Monitoring* app using external authentication via SAML, and then opened an alarm, the user name of the alarm owner would be incorrect.

#### Low-Code Apps: Not possible to execute a 'Change variable' action via the URL of the app [ID 42038]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Up to now, it would incorrectly not be possible to execute a *Change variable* action via the URL of the app.

#### Dashboards/Low-Code Apps - Flows: Long page names would incorrectly not be ellipsed in the flow editor [ID 42089]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In the *Data* pane of the flow editor, up to now, long page names would incorrectly not be ellipsed.

Also, from now on, when you hover over ellipsed text strings in the flow editor, a tooltip will now appear, show the entire string.

#### Low-Code Apps: Not possible to transfer data from a table to a form on a panel [ID 42092]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, it would not be possible to transfer data from a table to a form on a panel.

#### Dashboards app: GQI components on a shared dashboard would not show any data [ID 42130]

<!-- MR 10.4.0 [CU12]/10.5.0 [CU0] - FR 10.5.3 [CU0] -->

When you opened a shared dashboards, any GQI component on that dashboard would not get loaded and would as a result not show any data.

#### Dashboards/Low-Code Apps - Alarm table component: Problem when showing alarms in a sliding window [ID 42273]

<!-- MR 10.4.0 [CU12]/10.5.0 [CU0] - FR 10.5.3 [CU0] -->

When an *Alarm table* component was configured to show alarms in a sliding window, it would incorrectly not show any alarms.

Also, when you applied a view filter, a parameter index filter or a saved filter, an exception would be thrown and no alarms would be shown.
