---
uid: Web_apps_Feature_Release_10.5.4
---

# DataMiner web apps Feature Release 10.5.4

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU13] and 10.5.0 [CU1].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.4](xref:General_Feature_Release_10.5.4).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.4](xref:Cube_Feature_Release_10.5.4).

## Highlights

- [Low-Code Apps: Enhanced URL data support [ID 42031]](#low-code-apps-enhanced-url-data-support-id-42031)
- [Dashboards/Low-Code Apps - Query builder: Dragging and dropping operators [ID 42127]](#dashboardslow-code-apps---query-builder-dragging-and-dropping-operators-id-42127)
- [Dashboards app: Default Skyline dashboard themes updated [ID 42179]](#dashboards-app-default-skyline-dashboard-themes-updated-id-42179)
- [Dashboards/Low-Code Apps: Maps component is now fully released [ID 42309]](#dashboardslow-code-apps-maps-component-is-now-fully-released-id-42309)

## New features

#### Interactive Automation scripts: UI components 'Calendar' and 'Time' can now retrieve the time zone and date/time settings of the web session [ID 42097]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When UI components of type *Calendar* or *Time* are used in interactive Automation scripts, up to now, entered date and time would be formatted depending on the platform and the configured settings. In case of a web app, the entered date and time would always be returned in UTC. From now on, when an interactive Automation script is being run within a web app, the UI components of type *Calendar* and *Time* will be able to return the time zone of the client and the time and date as entered by the user.

When a default time zone is defined for DataMiner web apps, that default time zone will be used instead of the time zone of the client. See also [Setting the default time zone for DataMiner web apps](xref:ClientSettings_json#setting-the-default-time-zone-for-dataminer-web-apps).

For more information, see [Interactive Automation scripts: UI components 'Calendar' and 'Time' can now retrieve the time zone and date/time settings of the client [ID 42064]](xref:General_Feature_Release_10.5.4#interactive-automation-scripts-ui-components-calendar-and-time-can-now-retrieve-the-time-zone-and-datetime-settings-of-the-client-id-42064)

#### Dashboards/Low-Code Apps - Query builder: Dragging and dropping operators [ID 42127]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you want to rearrange the operators in a query, you can now do so by dragging and dropping operators from one location in the query to another, making this much easier than before. This will only be possible within the same level, not from e.g. a joined query to the parent query or vice versa.

If an operator shows a red error state after you have dragged it to a new location, this means that the operator in question cannot be used at that location and that the query has become invalid as a result.

In addition, you can now also insert new operators in between existing ones by clicking a "+" button.

#### Dashboards/Low-Code Apps: Maps component is now fully released [ID 42309]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

If you have a valid Maps license, from now on, you can use the *Maps* component without having to enable the *ReportsAndDashboardsGQIMaps* soft-launch option.

The *Maps* component is used to display markers and/or lines on a map. It uses one or more GQI queries as data input.

For all information about this component, see [Maps](xref:DashboardMaps).

> [!NOTE]
>
> - To use the Maps component, the host servers for DataMiner Maps have to be configured in the file `C:\Skyline DataMiner\Maps\ServerConfig.xml`. If this file does not exist, it will be created automatically when you use a Maps component for the first time. To change the configuration, see [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers).
> - This component currently only supports **Google Maps** ("gmaps") as the [Maps provider](xref:Configuring_the_DataMiner_Maps_host_servers).

## Changes

### Enhancements

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'Dropdown' [ID 41838]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The UI component `UIBlockType.Dropdown` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'CheckBox' [ID 41891]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The UI component `UIBlockType.CheckBox` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'PasswordBox' [ID 42007]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The UI component `UIBlockType.PasswordBox` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive Automation scripts: Read-only and/or disabled legacy UI components will be disabled when using URL argument '?useNewIASInputComponents=true' [ID 42009]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you add the following argument to the URL of a low-code app, all UI components that have not yet been redesigned will be disabled when they are set to read-only and/or disabled:

`?useNewIASInputComponents=true`

#### Low-Code Apps: Enhanced URL data support [ID 42031]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, low-code apps would only support using URL data to pass default values to components. For example, to select a particular default value in a dropdown box. From now on, low-code apps will also be able to consume data passed via their URL using either the JSON syntax or the legacy syntax. For example, you will now be able to use an element specified in the URL to filter a GQI query.

For more information regarding the above-mentioned JSON syntax and legacy syntax, see [Specifying data input in a dashboard or app URL](xref:Specifying_data_input_in_a_URL).

> [!NOTE]
> Contrary to dashboards, low-code apps will not push data to the URL. In other words, the URL will not change when data is selected in a component.

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'RadioButtonList' [ID 42032]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The UI component `UIBlockType.RadioButtonList` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Dashboards/Low-Code Apps - Column & bar chart component: Settings now have new default values [ID 42106]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The following settings of a *Column & bar chart* component now have new default values:

| Setting | Old default | New default |
|---------|-------------|-------------|
| Chart layout      | Relative per variable | Absolute      |
| Chart orientation | Left to right         | Bottom to top |

Existing components will not be affected.

#### Dashboards/Low-Code Apps: Reordering the columns in a Select operator by dragging and dropping [ID 42122]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In a *Select* operator of a GQI query, you can now reorder the columns by dragging and dropping them.

#### Dashboards/Low-Code Apps - Grid component: Using browser menu commands [ID 42128]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

From now on, the *Grid* component will allow you to use browser menu commands. It will now be possible to e.g. select text in a *Grid* component and copy it to another application by means of the *Copy* command of your browser.

#### Dashboards/Low-Code Apps - Time range component: Enhanced readability of Apply button [ID 42155]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In the *Time range* component, up to now, the color of the *Apply* button would, in some cases, be too close to the color of the component background. As a result, the text on the button would be barely readable.

#### Dashboards/Low-Code Apps: Selected items will be passed from one component to another in the order in which they were selected [ID 42163]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Items selected in *Node edge graph*, *Grid*, *Maps*, *Timeline*, or *Table* components will now be passed to other components in the order in which they have been selected.

#### Dashboards app: Default Skyline dashboard themes updated [ID 42179]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In the following default Skyline dashboards themes, the colors have been updated:

- Skyline Light - White
- Skyline Light - Gray
- Skyline Dark

These new colors will be applied to all existing and new dashboards, as well as to all pages and panels of low-code apps that are using one of the above-mentioned themes.

#### Web Services API: Enhanced performance of the GetRegionalSettings method [ID 42202]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, each time the *GetRegionalSettings* method was called, it would retrieve the time zone and the list separator from the *ClientSettings.json* file. From now on, it will only retrieve the time zone and list separator the first time it is called after an API connection was set up, and will cache that data for as long as the API connection is up and running.

> [!NOTE]
> As a result of this change, any changes made to the time zone and/or list separator in *ClientSettings.json* will no longer be applied when you refresh the web app. From now on, changes made to the time zone and/or list separator will require an IIS reset.

#### Low-Code Apps: Names of apps, pages, and panels now limited to 150 characters [ID 42220]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, the length of app, page and panel names was not limited. As this could cause issues with very long URLs, those names have now been limited to 150 characters.

#### Dashboards/Low-Code Apps: 'Reuse template' button renamed to 'Browse template' [ID 42226]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In the following components, the *Reuse template* button has now been renamed to *Browse template*:

- Grid
- Maps
- Table
- Timeline

As soon as at least two templates are being used on the dashboard or low-code app, this button will allow you to open a window in which you will be able to import a template from another component to override the template of the component you are configuring.

#### Dashboards/Low-Code Apps - Query builder: Shorter node descriptions [ID 42229]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The node descriptions in the query builder have been rewritten. They are now more concise.

Also, the *Then sort by* operator will now be a child node of the *Sort by* operator. This means that, when you drag a *Sort by* node to another location, all its *Then sort by* child nodes will be taken along.

#### Dashboards/Low-Code Apps - Maps component: Redesigned icon [ID 42239]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The *Maps* component now has a redesigned icon.

#### Dashboards app: Updated component data colors [ID 42272]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The default data colors have been updated. These are the colors that are used for e.g. the lines in a line & area chart, the bars in a column & bar chart, the slices in a pie & donut chart, etc.

These updated colors will automatically be applied to all existing dashboards and low-code apps that use one of the default Skyline themes (i.e. Skyline Light - White, Skyline Light - Gray, and Skyline Dark).

Also, the icon of the *Column & bar chart* component has been redesigned.

#### Dashboards/Low-Code Apps - Dropdown component: Enhanced behavior [ID 42298]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 [CU0] -->

Up to now, a *Dropdown* component would open upwards as soon as it was positioned in the bottom half of the screen, even when there was enough room to open downwards. From now on, a *Dropdown* component will only open upwards if there is not enough room below it to open downwards.

#### Dashboards/Low-Code Apps - Maps, Timeline & Grid components: Templates have been updated [ID 42322]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The default templates of the *Maps*, *Timeline* and *Grid* components have been updated.

### Fixes

#### Low-Code Apps: Certain actions would incorrectly not use the event information passed to them [ID 41979]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When the following actions were executed, up to now, they would incorrectly not use the event information that was passed to them.

- *Set viewport* action on a *Line & area chart* component with parameter data
- *Set value* action on a *Time range* component
- *Set value* action on a *Numeric input* component

#### Dashboards/Low-Code Apps - Table component: Problem when loading data from a partial table [ID 42107]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, when new data from a partial table was being loaded into a *Table* component, the loading would get stuck.

#### Dashboards/Low-Code Apps - Grid component: Scroll bars would appear even though all items could be displayed [ID 42108]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, scrollbars would appear on a *Grid* component, even though there was sufficient screen real estate to display all items.

#### Low-Code Apps - Form component: Problem when saving a form due to boolean fields not having a default value [ID 42111]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When the data in a *Form* component was saved, an error would be thrown when mandatory boolean fields without default value had not been explicitly set to either true or false.

From now on, all boolean fields will have a default value (either true or false).

#### Dashboards/Low-Code Apps: Letter descenders would incorrectly be cut off in Components dataset [ID 42118]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When, while configuring a component, you opened the *Components* dataset on the *Data* pane, all portions of letters that extended below the font's baseline (i.e. the descenders of letters like e.g. g, j, q, p, and y) would incorrectly be cut off.

#### Dashboards/Low-Code Apps - Parameter table component: Clicking the info icon of the 'Parameter table filters' section would not open the correct help page [ID 42123]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When, while configuring a *Parameter table* component, you opened the *Parameter table filters*\* section on the *Data* pane and clicked the information icon on the right, the main page of [docs.dataminer.services](xref:docs_dataminer_services) would incorrectly be opened. From now on, the correct page, i.e. [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax), will be opened instead.

\**The *Parameter table filters* section is only available if you add the `showAdvancedSettings=true` option to the URL of the dashboard or the low-code app.*

#### Dashboards/Low-Code Apps: Problem when deleting an operator from a flow [ID 42125]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you wanted to delete an operator in the flow editor, up to now, you incorrectly had to delete it twice before it got removed from the flow.

#### Low-Code Apps: Variables in a flow would not correctly push the latest value through the flow [ID 42133]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, variables merged with components inside a flow would not correctly push the latest value through the flow.

#### Dashboards/Low-Code Apps - Time range component: Changing the 'Granularity' setting could produce an invalid time range [ID 42145]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you changed the *Granularity* setting of a *Time range* component from *Date & time* to *Date* or vice versa, in some cases, the specified time range would become invalid.

#### Web apps: About box would incorrectly no longer show any OEM information [ID 42190]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The *About* box of the DataMiner web apps would incorrectly no longer show any OEM information. This information has now been added again.

#### Dashboards/Low-Code Apps: Components would stop responding after trying to fetch non-existing objects [ID 42192]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When a component had tried to fetch a number of non-existing objects (e.g. elements, parameter, etc.), in some cases, it would stop responding.

#### Dashboards app: 'Link to data' popup would not contain any data when the query had a filter node linked to a variable or a flow [ID 42201]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When, after you had refreshed a dashboard, you opened a *Link to data* popup of an existing data link while configuring a query in which a filter node was linked to a variable or a flow, that popup would not contain any data.

#### Dashboards/Low-Code Apps: Removing component data would incorrectly remove all data from the 'Components' section [ID 42216]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you removed the most recently added component data from a component, all data would be removed from the *Components* section of the *Data* pane, including the predefined component data.

#### Low-Code Apps: 'Open an app' action would open an incorrect version of the specified app [ID 42224]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, an *Open an app* action would open an incorrect version of the app that was specified. From now on, an *Open an app* action will always open the most recently published version of the app.

When the app that is specified in the action has never been published yet, an error message will appear.

#### Low-Code Apps: The description would not get updated when an app was published [ID 42257]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When a low-code app was published, its description would incorrectly not get updated.

#### Low-Code Apps: Problem when saving an app with an empty name [ID 42259]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you saved a low-code app with an empty name, an exception could be thrown.

#### Low-Code Apps: Icon of newly created low-code app would only be visible after refreshing the root page [ID 42264]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you created a new low-code app, the icon of that app would incorrectly only be visible on the root page (i.e. `https://myDMA/root/`) after you had refreshed that page.

#### Low-Code Apps: No tooltip showing the full name would appear when hovering over an ellipsed name of a low-code app [ID 42269]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

If, on the root page (i.e. `https://myDMA/root/`), a low-code app has a long name, that name will by default be ellipsed (i.e. only the first part of the name will be displayed, followed by "..."), and hovering over the name should make a tooltip appear, showing the full name. However, up to now, no tooltip showing the full name would appear when you hovered over an ellipsed name.

From now on, a tooltip showing the full name will appear when you hover either over the name of the app or the icon of the app.

#### Dashboards/Low-Code Apps - Timeline component: Groups would incorrectly disappear when the data was refreshed [ID 42289]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When, in a *Timeline* component, items had been grouped, in some cases, all groups would disappear when the data was refreshed and would reappear when you scrolled inside the timeline. From now on, all groups will remain visible when the data is refreshed.

#### Dashboards/Low-Code Apps: Problems with duration input boxes [ID 42293]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

A number of issues regarding duration input boxes have been fixed:

- The current value would not be validated after you had changed the minimum and/or maximum value.
- When a positive value was replaced by an invalid negative value, the input fields as well as the sign button would not be updated properly.
- When the day field contained a value with more than three digits, the value would not be entirely readable. Also, when the day field contained a number smaller than 10, there would be too much space the input field and the sign button.
- When the granularity was changed, hidden fields would be taken into account when calculating the current value.

#### Dashboards/Low-Code Apps - Query filter component: Problem after being retriggered by a linked Trigger component [ID 42367]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When a *Query filter* component was linked to a *Trigger* component as well as to one or more columns as a filter, the following error would be thrown after it was retriggered via the *Trigger* component:

`Cannot read properties of null (Reading 'Discreets')`

#### Dashboards/Low-Code Apps: Problem with buttons and dropdown boxes [ID 42375]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, buttons would no longer correctly show their loading state.

Also, dropdown boxes would no longer ellipse long values, causing a horizontal scrollbar to appear in the dropdown box.

#### Dashboards/Low-Code Apps - Timeline component: Selected time range would incorrectly not get passed to other components [ID 42380]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you had selected a time range in a *Timeline* component, in some cases, that time range would incorrectly not get passed to other components.

#### Low-Code Apps: Problem when entering edit mode when the app contained a component without visualization [ID 42382]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you entered the edit mode of a low-code app, in some cases, a runtime error could occur when the app contained a component to which no visualization had been assigned.

#### Dashboards/Low-Code Apps - Query filter component: Problem when changing a query that contained boolean columns [ID 42442]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 [CU0] -->

In some cases, a *Query filter* component could throw an error whenever you made a change to a query that contained boolean columns.

#### Low-Code Apps: Loops in component data could cause an app to become unresponsive [ID 42531]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 [CU0] -->

In some cases, a low-code app could become unresponsive due to loops in component data.
