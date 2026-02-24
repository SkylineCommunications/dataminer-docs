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

#### Automation: Time zone of the client can now be passed to the automation script that is executed [ID 44788]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When an automation script is executed in a web app, it is now possible to pass the time zone of the client to that script.

In the automation script, the time zone will be available on the `IEngine` input argument:

`engine.ClientInfo.TimeZone`

> [!NOTE]
>
> - If the script was executed from a source other than a web app, or if the time zone information could not be parsed, the `TimeZone` property can be null.
> - In case a subscript is executed, the `ClientInfo` of the parent script will also be available in the subscript.

Also, a `scriptOptions.ClientTimeZone` property can now be passed to both the `ExecuteAutomationScript` and `ExecuteAutomationScriptWithOutput` web methods.

The `ClientTimeZone` (`DMAAutomationScriptOptionClientTimeZone`) data type has the following properties:

- `Type` (`DMAAutomationScriptOptionClientTimeZoneType`):

  | Value | Description |
  |-------|-------------|
  | Iana (1)    | If `Type` is set to 1, then an attempt will be made to pass the time zone information based on the IANA time zone identifier set in the `Info` property.<br>See also: [IANA time zone database](https://www.iana.org/time-zones) |
  | Default (0) | If `Type` is set to 0, then the [default time zone for DataMiner web apps](xref:ClientSettings_json#setting-the-default-time-zone-for-dataminer-web-apps) will be passed. |

- `Info`: If `Type` is set to "Iana" (1), then `Info` should contain the identifier of an IANA time zone.

> [!NOTE]
> Currently, it is not yet possible to pass the time zone of the client to a script that is executed by clicking a DOM action button.

> [!IMPORTANT]
> This feature will only work in conjunction with DataMiner server version 10.7.0/10.6.4 or newer. See [Automation: Time zone of the client can now be passed to the automation script that is executed [ID 44742]](xref:General_Feature_Release_10.6.4#automation-time-zone-of-the-client-can-now-be-passed-to-the-automation-script-that-is-executed-id-44742).

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

#### Low-Code Apps: 'HTTP 404' visual will now appear when you navigate to a non-existing app or an app you are not allowed to open [ID 44681]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

From now on, when you navigate to a non-existing app or an app you are not allowed to open, an "HTTP 404" visual will now appear.

Clicking the *Go to home* button in that visual will redirect you to the root page.

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

#### GQI DxM: Any type of number will now be accepted as filter value for numeric columns [ID 44712]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Up to now, when filtering on a column containing numbers of type int, double, etc., the filter values all had to be of the same type. However, in some cases, this would cause issues when those values were combined with component data from the client.

From now on, GQI will accept any type of number (int, double, and long) as filter value for columns of type int, double, long, and decimal.

#### Dashboards/Low-Code Apps - GQI: Enhanced filtering when using the GQI DxM [ID 44714]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

From now on, when dashboards or low-code app use the GQI DxM to process GQI queries, queries with regex filters that are linked to data will no longer combine multiple values inside a single regular expression to simulate OR filtering. Instead, whatever the filter method (contains, equals, regex, greater than, etc.), they will create a real OR filter with all the raw data values.

As a result, when linking data to filter nodes, dashboards and low-code apps using the GQI DxM to process GQI queries will now behave differently to dashboards and low-code apps using SLHelper to process GQI queries.

##### When using SLHelper: no functional changes

- In regex filters, the different regex values are escaped and combined into a single regular expression.
- When using any other filter method, only the first value is passed to the filter. All other values are ignored.

Limitations:

- As the regex values need to be escaped to support OR filtering, it is impossible to create a dynamic regular expression to filter with.
- You cannot use an OR filter to filter values other than string values. Only string values allow regex filtering.

##### When using the GQI DxM: functional change

- In regex filters, the regex values will no longer be escaped.
- When using any other filter method, all values will now be passed to the filter.

Benefits:

- No limitations similar to those when using SLHelper.
- Filters can be optimized and forwarded to the server, instead of having to use a post filter.

> [!IMPORTANT]
> In some cases, no longer escaping regex values in regex filters could represent a breaking change:
>
> - The query could become invalid if some of the regex values contain invalid regular expressions.
> - Even when all regex values are valid regular expressions, in some cases, the filter may not yield the expected result because some of the values unintentionally contain regex syntax.
>
> If a regex filter would yield unexpected results, it is safe to replace the regular expression by a contains or equals condition.

#### User authentication enhancements [ID 44734]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

A number of enhancements have been made with regard to user authentication when accessing, for example, video thumbnails.

#### Web apps: Going to the root page of the app by clicking the app name in the header [ID 44753]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In a web app, from now on, you can go to the root page of the app by clicking the name of the app in the header.

- If you click the left mouse button, the root page will open in the same browser tab.
- If you click the left mouse button while holding the CTRL key pressed, or if you click the middle mouse button, the root page will open in a new browser tab.
- If you click the left mouse button while holding the SHIFT key pressed, the root page will open in a new browser window.

#### Dashboards/Low-Code Apps - Node edge graph component: Viewport will no longer be reset with every update [ID 44786]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Up to now, each time a *Node edge graph* component with the *Filtering & Highlighting > Highlight* option disabled received a real-time update, its viewport would be reset.

From now on, the viewport of a *Node edge graph* component will mostly be reset when you have made changes to its settings, although it can still be reset in certain other scenarios. For example, when the node edge graph is not linked to data, a reset will occur when the entire topology has changed after an update.

Also, when the node positions are linked to data, from now on, a *Node edge graph* component will allow you to zoom out beyond the initial viewport.

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

#### Dashboards app: Problem when quickly switching from one tab to another in the navigation pane [ID 44750]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When you quickly switched from one tab to another in the navigation pane while viewing the Dashboards app on a mobile device, in some cases, an error could be thrown.

#### Dashboards/Low-Code Apps - Node edge graph component: Node actions inherited from the base type would no longer be displayed when the base type was overridden [ID 44770]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a node changed from its base type to an override due to a real-time update, up to now, the actions inherited from the base type would incorrectly no longer displayed in the tooltip.

From now on, a node will correctly update its actions by combining the actions from the override with those from the base type, ensuring all applicable actions remain visible.

#### Dashboards/Low-Code Apps - Flows: Problems when using the URL data source [ID 44782]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When you had added a URL data source to a flow, up to now, the label of that data source would incorrectly be set to "Unknown source". From now, the label will show the data type instead.

Also, the `DMAIP` data object would not be usable when added to a flow created in a DataMiner version older than version 10.6.3.

#### Visual Overview in web apps: Problem when opening a visual overview containing a trend component [ID 44784]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When, in a web app, you opened a visual overview that contained a trend component, in some cases, an error message would incorrectly appear, stating that the start time was invalid.

#### Dashboards/Low-Code Apps - Web component: URLs of DataMiner web apps would only be registered as trusted when they ended with a trailing slash [ID 44796]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

If, in a *Web* component, you specified the URL of a DataMiner web app, it would incorrectly only be registered as trusted when it ended with a forward slash (`/`). For example, `<dmaURL>/dashboards/` would be registered as trusted, but `<dmaURL>/dashboards` would not.

As a result, when a URL of a DataMiner web app did not end with a forward slash, it would get sandboxed.

From now on, URLs of DataMiner web apps will always be registered as trusted, whether they end with a forward slash or not.

#### Dashboards/Low-Code Apps - Time range & Query filter components: Problems when dashboard or low-code app was embedded [ID 44802]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When the dashboard or low-code app was embedded by means of the URL argument `embed=true` or when the dashboard was shared, up to now,

- in a *Time range* component, it would incorrectly not be possible to pin quick picks, and
- in a *Query filter* component, it would incorrectly not be possible to enable the *Alarm color mode* setting.

#### Low-Code Apps - Node edge graph component: Changing the interaction mode via an action would incorrectly change the default interaction mode [ID 44807]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When, in a low-code app, the interaction mode of a *Node edge graph* component was changed by an action, in some cases, the component's default interaction mode would incorrectly also be changed.

#### Dashboards/Low-Code Apps - Node edge graph component: Edges could get drawn incorrectly when bidirectional configuration was enabled [ID 44814]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a Node edge graph component with bidirectional configuration enabled for the edges received a real-time update, in some cases, the edges could get drawn incorrectly. For example, multiple edges could get drawn on top of each other, or have their arrows rendered at an incorrect location.

#### Dashboards/Low-Code Apps - Node edge graph component: No tooltip would appear when hovering over an edge with a weight of 1 [ID 44818]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When positioning was set to "Linked to data", and the viewport was set to "Auto", up to now, no tooltip would appear when you hovered over edges with a weight of 1.
