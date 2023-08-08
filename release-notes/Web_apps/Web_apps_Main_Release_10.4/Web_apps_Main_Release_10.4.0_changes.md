---
uid: Web_apps_Main_Release_10.4.0_changes
---

# DataMiner web apps Main Release 10.4.0 – Changes – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### Web apps - Interactive Automation scrips: Fields containing invalid values will now be indicated more clearly [ID_34962]

<!-- MR 10.4.0 - FR 10.3.2 -->

When, in an Automation script launched from a web app, an input field contains an invalid value, the border of that field will turn red. This red border will now be wider in order to be more visible.

#### GQI: Enhanced performance of GQI queries [ID_34977]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance of GQI queries has increased, especially when those queries contain join operations.

#### GQI: Enhanced performance of GQI queries using the 'Get parameters for elements where' data source [ID_35005]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance of GQI queries using the *Get parameters for elements where* data source has increased.

#### Dashboards app - Line & area chart: Multiple timespans will now be converted to one single time range [ID_35008]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a line & area chart component is fed a collection of timespans, it will now convert those timespans to one single time range.

For example, when a line & area chart component is fed the following timespans...

- *01/01/2022 9:00:00 > 01/01/2022 10:00:00*
- *01/01/2022 9:30:00 > 01/01/2022 10:30:00*

... it will convert those timespans into the following time range:

- *01/01/2022 9:00:00 > 01/01/2022 10:30:00*

#### GQI: Enhanced performance when using Sort operators in conjunction with alarm, change point, trend pattern and trend pattern occurrence data sources [ID_35031]

<!-- MR 10.4.0 - FR 10.3.3 -->

Because of a number of enhancements, overall query performance has increased when using Sort operators in conjunction with the following data sources:

- Get alarms
- Get behavioral change events
- Get trend data patterns
- Get trend data pattern events

#### Web apps: Button styles used in interactive Automation script components have been aligned with those used in low-code app components [ID_35076]

<!-- MR 10.4.0 - FR 10.3.2 -->

In the web apps, the button styles used in interactive Automation script components have now been fully aligned with those used in low-code app components.

#### Web app: More detailed version information in About box [ID_35090]

<!-- MR 10.4.0 - FR 10.3.2 -->

In the *About* box of a web application, you can now find more detailed version information.

| Old name | New name | Description |
|----------|----------|-------------|
| - | Server version | Server version and build number of the DataMiner Agent |
| Client build | Web version | Build number of the web app |
| Client version | App | Version number of the web app |
| Server API version | API | Version number of the Web Services API |

#### GQI: Enhanced query performance when aggregation operations are followed by a filter [ID_35110]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall query performance has increased, especially in cases where aggregation operations are followed by a filter.

#### Dashboards - GQI components: Enhanced behavior when loading data [ID_35148]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, a loading skeleton would be displayed each time data was being loaded into a GQI component (e.g. a node edge graph). From now on, only when the component was empty will a loading skeleton be displayed. When existing data in the component is being refreshed, a loader bar will now be displayed instead.

#### Web apps: Enhanced performance when retrieving a list of users [ID_35150]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a web app requests a list of users, the Web Services API will now cache the result set it receives from the server. This will increase overall performance, especially in situations where, up to now, the same list of users had to be retrieved frequently.

This user cache will be cleared each time a change occurs that has security implications (e.g. new users added, user permissions updated, etc.).

#### Dashboards app - Line & area chart component: 'Group by' setting will now by default be set to 'All together' [ID_35160]

<!-- MR 10.4.0 - FR 10.3.2 -->

In case a *Line & area chart* component displays trending for multiple parameters, the *Group by* setting allows you to specify how the graphs should be grouped. From now on, this *Group by* setting will by default be set to "All together".

#### Web apps: Enhanced color picker [ID_35276]

<!-- MR 10.4.0 - FR 10.3.3 -->

A number of enhancements have been made to the color picker.

#### Dashboards - Line & area chart component: 'Show average', 'Show minimum' and 'Show maximum' options will now be taken into account when exporting trend data to CSV [ID_35311]

<!-- MR 10.4.0 - FR 10.3.3 -->
<!-- Timestamp format fix added to Fixes -->

When exporting trend data to CSV, from now on, the *Show average*, *Show minimum* and *Show maximum* options will be taken into account.

> [!NOTE]
>
> - When the *Show min/max shading* option is enabled (which it is by default), minimum and maximum values will always be included when you export trend data.
> - As the *Show min/max shading* option and the *Show average* option are both enabled by default, a CSV export of trend data will by default contain all trend data values.

#### Errors received from the web API after sending a GetConnection call will now be logged in SLNet.txt [ID_35313]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when SLNet receives an error from the web API after sending a *GetConnection* call, it will log the request and the response in the *SLNet.txt* log file.

#### GQI: data sources 'Get elements' and 'Get services' will now also return alarm states [ID_35464]

<!-- MR 10.4.0 - FR 10.3.3 -->

The GQI data sources *Get elements* and *Get services* will now also return alarm states.

#### Support for GQI queries from Data Aggregator with ad hoc data sources [ID_35526]

<!-- MR 10.4.0 - FR 10.3.3 -->

GQI now supports queries from [Data Aggregator](xref:Data_Aggregator_DxM) that use ad hoc data sources.

#### GQI: 'State' column in data sources 'Get services' and 'Get views' renamed to 'Alarm state' [ID_35557]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the GQI data sources *Get services* and *Get views*, the *State* column has now been renamed to *Alarm state*.

#### Dashboards app: Feeds listing parameters of EPM objects will now also list the parameters of the enhanced elements linked to those EPM objects [ID_35562]

<!-- MR 10.4.0 - FR 10.3.4 -->

When an EPM feed is used to feed EPM identifiers to a parameter feed, it will now also list the parameters of the enhanced elements that are linked to the EPM objects.

#### GQI: Raw datetime values will now be converted to UTC [ID_35640]

<!-- MR 10.4.0 - FR 10.3.4 -->

Up to now, after each step in a GQI query, raw datetime values were always converted to the time zone that was specified in the query options. From now on, raw datetime values will be converted to UTC instead. The time zone specified in the query options will now only be used when converting a raw datetime value to a display value.

> [!IMPORTANT]
> **BREAKING CHANGE**: When, in an ad hoc data source or a query operation, a datetime value is not in UTC format, an exception will now be thrown.

#### Monitoring app: Trending page of a parameter no longer has a sidebar [ID_35705]

<!-- MR 10.4.0 - FR 10.3.4 -->

In the *Monitoring* app, the *Trending* page of a parameter no longer has a sidebar.

#### Monitoring app - Histogram: Sidebar enhancements [ID_35797]

<!-- MR 10.4.0 - FR 10.3.5 -->

In the *Monitoring* app, a number of enhancements have been made to the sidebar of the *Histogram* page of a parameter:

- The icons that allow you to switch between trend graph and histogram have been updated.
- The *Time span* selection box has been removed.
- The width of the sidebar has been reduced.

#### Web Services API: Performance enhancements [ID_35805]

<!-- MR 10.4.0 - FR 10.3.5 -->

The following enhancements have been made with regard to the Web Services API:

- A web API event queue will now automatically be removed after 5 minutes if a client did not request the events in that queue during those 5 minutes. As a result, overall web API memory consumption will decrease considerably.

- It is now possible for one web API connection to have multiple event queues. As a result, clients will be able to have multiple open WebSocket connections using the same connection ID.

- Up to now, when the *remember me* auto-login cookie could not be generated (e.g. because the user entered an unusually long user name), an error would be thrown. From now on, no error will be thrown anymore. The cookie will not be generated and the user will have to manually log back in again when starting a new session.

> [!IMPORTANT]
> BREAKING CHANGE: Due to the changes made with respect to WebSocket communication, it will no longer be possible to use the following web methods:
>
>- LoadSpectrumPreset
>- SaveSpectrumPreset
>- SetMeasurementPoints
>- SetSpectrumParameter

#### Dashboards app & Low-Code Apps: New way to link components to feeds [ID_35837]

<!-- MR 10.4.0 - FR 10.3.5 -->

The way in which components are linked to feeds has been improved. Instead of using a *Use feed* or *Link x to feed* checkbox, you will now be able to configure a feed link by means of a picker window.

> [!CAUTION]
> BREAKING CHANGE: Up to now, when you linked a script parameter to the *From* or *Till* box of a time range feed, the feed would pass a datetime value in string format to the script. That string value was not in an ISO format and did not contain any information about the time zone. From now on, the feed will send a UTC timestamp in milliseconds instead. Scripts that expect to receive a string value will need to be modified.

#### Clearer error will be thrown when an inter-element query failed to retrieve a parameter value of a specific element [ID_35972]

<!-- MR 10.4.0 - FR 10.3.6 -->

When an inter-element query failed to retrieve a parameter value of a specific element, up to now, a generic `Unknown element` error would be thrown. From now on, a clearer error mentioning the element that caused the issue will be thrown instead.

#### DataMiner web apps: Angular and other dependencies have been upgraded [ID_36100]

<!-- MR 10.4.0 - FR 10.3.6 -->

In all web apps (e.g. Low-Code Apps, Dashboards, Monitoring, Jobs, Ticketing, etc.), Angular and other dependencies have been upgraded.

#### Dashboards app - GQI: Clearer error message will now appear when ModelHost is not running [ID_36155]

<!-- MR 10.4.0 - FR 10.3.6 -->

When the *Get parameter relations* data source is queried while the *ModelHost* DxM is not running, an error message will appear. That error message has now been made clearer.

#### Web services API: Multi-value DOM fields will now list all their values [ID_36190]

<!-- MR 10.4.0 - FR 10.3.6 -->

Up to now, in e.g. low-code apps, multi-value DOM fields would only show a summary of the values they contained. From now on, they will list all values instead.

> [!NOTE]
> When a multi-value DOM field contains invalid values, it will no longer list them. Instead, they will be added to the error message.

#### External authentication using SAML: Enhanced error handling [ID_36274]

<!-- MR 10.4.0 - FR 10.3.7 -->

Instead of a generic error message, a more meaningful error message will now appear when something goes wrong while authenticating a user via SAML.

#### Monitoring app: Enhanced parameter controls [ID_36275]

<!-- MR 10.4.0 - FR 10.3.7 -->

In the *Monitoring* app, the parameter controls have been enhanced. You will now be able to edit a parameter by clicking a pencil icon.

#### Dashboards app & Monitoring app: Parameter page component now supports WebSockets [ID_36314]

<!-- MR 10.4.0 - FR 10.3.7 -->

The *Parameter page* component now supports the WebSocket protocol. As a result, parameter updates will now be received immediately.

#### Monitoring app: Enhanced performance when editing a parameter on a parameter page component [ID_36348]

<!-- MR 10.4.0 - FR 10.3.7 -->

Because of a number of enhancements, overall performance has increased when editing a parameter on a parameter page component.

#### Monitoring app - Parameter control: Clicking the trending icon of a parameter will immediately open the trending page [ID_36352]

<!-- MR 10.4.0 - FR 10.3.7 -->

Up to now, when you clicked the trending icon of a parameter, the parameter edit pane would expand, showing additional information about that parameter. From now on, when you click the trending icon of a parameter, the trending page will open instead.

#### Dashboards app & Low-Code Apps - Table component: Selected rows will again be selected after refetching the data [ID_36372]

<!-- MR 10.4.0 - FR 10.3.7 -->

From now on, when table data is refetched with a trigger or an action, the rows that were selected before the refetch will automatically be selected again.

#### Monitoring app: Parameter values that are URLs will now be rendered as clickable hyperlinks [ID_36423]

<!-- MR 10.4.0 - FR 10.3.8 -->

From now on, when a parameter value is a URL starting with one of the following prefixes it will be rendered as a clickable hyperlink:

- file://
- ftp://
- http://
- https://
- mailto://

#### Dashboards app & Low-Code Apps: Enhanced migration message [ID_36435]

<!-- MR 10.4.0 - FR 10.3.7 -->

When a dashboard or a low-code app page is being migrated, a message will appear to notify the user.

From now on, when the user has edit permission, the message will only appear when the migration takes longer than 15 seconds. When the user does not have edit permission, the message will appear immediately at the start of the migration, notifying the user that the migration will not be saved and that it will be repeated every time the dashboard or low-code app page is loaded.

#### Dashboards app: Enhanced PDF generation [ID_36461]

<!-- MR 10.4.0 - FR 10.3.9 -->

A number of enhancements have been made to the way in which PDF files are generated from dashboards. For example, up to now, items selected on a dashboard would no longer be selected after a PDF file had been generated.

#### Dashboards app & Low-Code Apps - Clock components: Custom time zone [ID_36534]

<!-- MR 10.4.0 - FR 10.3.8 -->

When configuring an analog or digital *Clock* component, you can now make the clock display the date and time in a specific time zone.

To do so, select the *Custom time zone* option, and select a time zone from the *Time zone* selection box.

#### DataMiner Comparison tool: Enhancements [ID_36570]

<!-- MR 10.4.0 - FR 10.3.8 -->

A number of enhancements have been made to the DataMiner Comparison tool. This web application allows you to compare the values of two string parameters on a character-by-character basis and to immediately spot the differences (additions, modifications, and deletions).

#### Monitoring app, Dashboards app & Low-Code Apps: Asynchronous operations now also supported when using WebSockets [ID_36583] [ID_36884] [ID_36885] [ID_36886] [ID_36887] [ID_36896] [ID_36904] [ID_37029] [ID_37031]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, the following asynchronous operations were only supported over HTTP(s). From now on, these asynchronous operations will also be supported when using WebSockets.

- Retrieving trend data
- Retrieving alarm details
- Retrieving alarm history
- Retrieving visual overviews of elements, services and views
- Retrieving parameter status information (serving as input for pivot table components)
- Generating PDF reports
- Sending emails containing PDF reports
- Sharing a dashboard

#### Dashboards app: Enhanced mechanism to update the list of dashboards in the navigation pane [ID_36604]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, the list of dashboards displayed in the navigation pane on the left would be updated every 5 seconds via a polling mechanism. From now on, whenever that list is changed, all connected clients will receive an event that will update the list.

#### Monitoring app: A new type of datetime boxes will now be used on parameter pages [ID_36606]

<!-- MR 10.4.0 - FR 10.3.8 -->

In the *Monitoring* app, a new type of datetime boxes will now be used on parameter pages.

**BREAKING CHANGE**: When the value of a date or datetime parameter is set using one of the following API methods, that value must now be passed as a Unix timestamp in milliseconds instead of an OLE Automation date.

- SetParameter
- SetParameterRow

**BREAKING CHANGE**: When values of date or datetime parameters are retrieved using one of the following API methods, those values will now be Unix timestamps in milliseconds instead of OLE Automation dates.

- GetEditParameter
- GetEditParameterTable
- GetMonitoredParametersForElement
- GetMonitoredParametersForService
- GetParameter
- GetParameterByName
- GetParameterForService
- GetParameterForServiceWithDynamicUnits
- GetParameters
- GetParametersByPageForElement
- GetParametersByPageForElementCached
- GetParametersByPageForElementSorted
- GetParametersByPageForServiceElement
- GetParametersForElement
- GetParametersForElementFiltered
- GetParametersForElementSorted
- GetParametersForService
- GetParametersForServiceSorted
- GetParametersSorted
- GetParameterWithDynamicUnits
- ObserveParameter

#### BREAKING CHANGE: GQI - 'Get alarms' data source: Format of alarm IDs has changed [ID_36621]

<!-- MR 10.4.0 - FR 10.3.9 -->

The format of the alarm IDs listed in the *AlarmID* column of the *Get alarms* data source has been changed:

- Old format: *DmaId/RootId/AlarmId*
- New format: *HostingDmaId/AlarmId*

#### Dashboards app - GQI: Change detection in 'Start from' queries [ID_36690]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, queries that were built upon another query that was linked to feeds would not get updated when one of those feeds changed its value. Neither would queries built upon a base query be updated when the base query was changed.

From now on, when a base query is changed in any way, all queries that use that base query will automatically be updated as well.

#### Monitoring app: A new type of text area boxes will now be used on parameter pages [ID_36693]

<!-- MR 10.4.0 - FR 10.3.9 -->

In the *Monitoring* app, a new type of text area boxes will now be used on parameter pages.

#### Security enhancements [ID_36695] [ID_37051]

<!-- MR 10.4.0 - FR 10.3.9/10.3.10 -->

A number of security enhancements have been made.

#### Monitoring app: A new type of duration boxes will now be used on parameter pages [ID_36713]

<!-- MR 10.4.0 - FR 10.3.9 -->

In the *Monitoring* app, a new type of duration boxes will now be used on parameter pages.

#### Dashboards app: Tooltips will be displayed when hovering over a visualization in a component menu [ID_36737] [ID_36778]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you want to change the visualization of a component, you can hover over the component, click the *Visualizations* icon, and then select a visualization from the overview.

From now on, when you hover over each of the possible visualizations in the overview, a tooltip will appear, giving more information about that visualization.

Also, the component will no longer change instantly when you hover over a visualization in the overview. A visualization preview will be shown when the mouse pointer has been hovering over a particular visualization icon for more than 400ms and will disappear when the mouse pointer leaves the visualizations overview. The component will change its visualization only when you click a certain visualization in the overview.

#### DataMiner Comparison tool: Redesigned header and sidebar [ID_36747]

<!-- MR 10.4.0 - FR 10.3.9 -->

The header and sidebar of the DataMiner Comparison tool have been redesigned.

#### Monitoring app: A new type of buttons and toggle buttons will now be used on parameter pages [ID_36773]

<!-- MR 10.4.0 - FR 10.3.9 -->

In the *Monitoring* app, a new type of buttons and toggle buttons will now be used on parameter pages.

#### Dashboards app - Line chart component: Enhanced performance [ID_36869]

<!-- MR 10.4.0 - FR 10.3.9 -->

When a line chart component used element table column parameters as data and indices as filter, up to now, it would cross-match indices across the unique elements associated with the table column parameters. This will now be prevented when the *Hide non-trended parameters* option is disabled.

> [!NOTE]
> The *Hide non-trended parameters* setting is now disabled by default.

> [!IMPORTANT]
> Because of the enhancements that have been made, in some cases, a line chart will no longer show any data when the indices are not available in the specified table. If so, you can opt to work with cell parameters instead (see [release note 36724](xref:Web_apps_Main_Release_10.4.0_new_features#dashboards-app--low-code-apps---parameters-dataset-selecting-an-indexcell-of-a-column-parameter-id_36724)) or to enable the *Hide non-trended parameters* option.

#### Monitoring app: Parameter control now supports dynamic units [ID_36892]

<!-- MR 10.4.0 - FR 10.3.9 -->

The parameter control used in the *Monitoring* app now supports dynamic units.

#### Dashboards app & Low-Code Apps: 'ReportsAndDashboardsAlpha' soft-launch option is now deprecated [ID_36894]

<!-- MR 10.4.0 - FR 10.3.9 -->

The *ReportsAndDashboardsAlpha* soft-launch option is now deprecated.

#### Dashboards app/Low-Code Apps: Removed unused legacy components [ID_36907]

<!-- MR 10.4.0 - FR 10.3.9 -->

In order to reduce the package size for the Dashboards app and Low-Code Apps, a number of legacy components, which were not used and were unavailable in the UI, have now been removed.

### Fixes

#### Web apps: Problem with external authentication [ID_33405]

<!-- MR 10.4.0 - FR 10.3.5 -->

In some cases, it would not be possible to log in to a web app (e.g. Dashboards, Monitoring, Jobs, etc.) using external authentication.

#### GQI: Problem when retrieving DCF interfaces [ID_34820]

<!-- MR 10.4.0 - FR 10.3.1 -->

When a GQI query returned all DCF interfaces from all agents in the DataMiner System, the NATS message broker would throw a *MaxPayloadException* when *MaxPayload* exceeded the value configured in `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config`.

From now on, when a GQI query has to retrieve DCF interfaces, it will do so by querying one agent at a time.

#### GQI: Problem when a column select or a column manipulation operator was applied before an aggregation operator [ID_35009]

<!-- MR 10.4.0 - FR 10.3.1 [CU0] -->

When a column select or a column manipulation operator was applied before an aggregation operator, the column select or column manipulation operator would incorrectly be ignored. As a result, all columns would be visible in the *group by node* or columns created by the column manipulation would not be added to the options of the *group by node*.

#### Dashboards app & Low-Code Apps - Parameter feed: Problem when more than 10,000 elements had to be retrieved from the server [ID_35186]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, the parameter feed used the element cache of the web client to populate its element list. As this cache can only hold up to 10,000 elements, this prevented the parameter feed from retrieving all elements when the cluster contained more than 10,000 elements.

From now on, when the parameter feed has a protocol or view filter, it will fetch all elements matching the filter page by page, even when the total number of elements exceeds 10,000.

#### Dashboards app & Low-Code Apps: Issues with regard to data highlighting [ID_35250]

<!-- MR 10.4.0 - FR 10.3.2 -->

A number of issues with regard to data highlighting have been fixed.

#### Dashboards - Line & area chart component: Timestamps could be formatted incorrectly when exporting trend data to CSV [ID_35311]

<!-- MR 10.4.0 - FR 10.3.3 -->
<!-- See Enhancements for rest of 35311 -->

When trend data was exported to a CSV file, up to now, timestamps could be formatted incorrectly.

#### Dashboards app & Low-Code Apps - GQI table component: 'Cannot read properties of undefined (reading 'Guid')' error [ID_35316]

<!-- MR 10.4.0 - FR 10.3.2 [CU0] -->

In some cases, a GQI table component could show a `Cannot read properties of undefined (reading 'Guid')` error.

#### Web apps: Problems with Visual Overview components [ID_35399]

<!-- MR 10.4.0 - FR 10.3.3 -->

A number of issues regarding the Visual Overview component have been fixed.

- In some cases, the Visual Overview component would send an excessive amount of polling requests.
- When a page was selected in the Visual Overview component, in some cases, an incorrect page would be displayed.
- In some cases, the dimensions of pop-up windows would be incorrect.
- When a pop-up window was shown using a *VdxShape* property, in some cases, the default page would be shown instead of the page that was specified.

#### Dashboards app: Visualization picker would incorrectly resize when you hovered over it [ID_35516]

<!-- MR 10.4.0 - FR 10.3.4 -->

When you tried to select a visualization for a newly added component that did not yet have one, the visualization picker would incorrectly resize the first time you hovered over it.

#### Web apps: Color picker would not be positioned correctly [ID_35649]

<!-- MR 10.4.0 - FR 10.3.4 -->

The color picker would not be positioned correctly.

#### Low-Code Apps: Problem when opening a low-code app on a mobile device or when resizing the screen to a mobile size [ID_35683]

<!-- MR 10.4.0 - FR 10.3.4 -->

When you opened a low-code app on a mobile device or when you resized the screen to a mobile size, a console error would be thrown.

#### GQI: "Loading" indicator of a table would not disappear when that table was fed data from another table  [ID_35698]

<!-- MR 10.4.0 - FR 10.3.4 -->

When data from one table was fed to another table, in some cases, the "loading" indicator of the table to which data was fed would incorrectly not disappear.

#### GQI: GetArgumentValue method would throw an exception when used to access the value of an optional argument [ID_35783]

<!-- MR 10.4.0 - FR 10.3.5 -->

When the `GetArgumentValue<T>(string name)` method was used in an ad hoc data source or a custom operator script to access the value of an optional argument that had not been passed, the following exception would be thrown:

```txt
Could not find argument with name '{argument.Name}'.
```

#### Dashboards app & Low-Code Apps: Problem when feeding data from a GQI component to a query used in the same component [ID_35806]

<!-- MR 10.4.0 - FR 10.3.5 -->

An error could occur when feeding data from a GQI component to a query that was used in the same component.

#### Dashboards app - GQI: No element feed available after selecting a relation between two standalone parameters [ID_36003]

<!-- MR 10.4.0 - FR 10.3.5 -->

When, in a table with a *Get parameter relations* query, you selected a relation between two standalone parameters, no element feed would be available.

#### Dashboards app: Invalid nodes could get added to a GQI query [ID_36045]

<!-- MR 10.4.0 - FR 10.3.6 -->

In some cases, invalid nodes could get added to a GQI query, causing run-time errors to be thrown.

#### Web apps: Problem with single sign-on when embedded in Cube [ID_36049]

<!-- MR 10.4.0 - FR 10.3.5 [CU0] -->

When the *Dashboards*, *Jobs*, or *Ticketing* app was embedded in DataMiner Cube, in some cases, users would incorrectly be prompted to log in to the app.

#### Dashboards app & Low-Code Apps: Incorrect error could appear when editing a dashboard or low-code app [ID_36132]

<!-- MR 10.4.0 - FR 10.3.5 [CU0] -->

When editing a dashboard or a low-code app, in some cases, the following error could incorrectly appear:

```txt
The dashboard has not been saved: Invalid revision sequence, the dashboard might have been edited by another user.
```

#### Dashboards app & Low-Code Apps: Only one of the tables sharing an empty query would show a visual replacement [ID_36233]

<!-- MR 10.4.0 - FR 10.3.8 -->

When an empty query was used by more than one table component, in some rare cases, only one of those components would display a visual replacement.

#### Dashboards app & Low-Code Apps - Query builder: Select nodes would incorrectly not show the selected columns [ID_36251]

<!-- MR 10.4.0 - FR 10.3.7 -->

In the query builder, when a *Select* node was not in edit mode, its description would incorrectly not show the selected columns.

#### Low-Code Apps: Not possible to save empty DOM fields [ID_36276]

<!-- MR 10.4.0 - FR 10.3.8 -->

When a DOM instance was created or edited in a low-code app, empty fields would incorrectly not be sent to the server. This meant that it was not possible to clear a non-empty field.

#### Dashboards app & Monitoring app: Spectrum components would get stuck when loading [ID_36364]

<!-- MR 10.4.0 - FR 10.3.6 [CU0] -->

In the Dashboards app and the Monitoring app, spectrum components would get stuck when loading due to a WebSocket communication problem.

#### Dashboards app & Low-Code Apps: Table components sharing the same GQI query could end up containing duplicate rows [ID_36416]

<!-- MR 10.4.0 - FR 10.3.7 -->

When multiple table components used the same GQI query, in some rare cases, those components could end up containing duplicate rows.

#### Low-Code Apps: A blank screen would appear when users without permission to access a low-code app tried to log on [ID_36422]

<!-- MR 10.4.0 - FR 10.3.8 -->

When users without permission to access a low-code app tried to log on to that app, an error would be thrown and a blank screen would appear. From now on, when users without permission to access a low-code app try to log on to that app, an appropriate message will appear instead.

#### Dashboards app & Low-Code Apps: An error would appear when two GQI visualizations used the same query [ID_36465]

<!-- MR 10.4.0 - FR 10.3.7 -->

When the same query was used in two different GQI visualizations, one of those visualizations would display the following error:

```txt
Cannot read properties of null ('reading delete')
```

#### GQI: IsChecked property would not be filled in for list and drop-down options in SLAnalyticsTypes.dll [ID_36491]

<!-- MR 10.4.0 - FR 10.3.7 -->

When you installed a DataMiner web upgrade for version 10.3.5 or newer on a server running a DataMiner version older than 10.3.5, the value of the `IsChecked` property would not be filled in for list and drop-down options in *SLAnalyticsTypes.dll*. As a result, list and drop-down options that should be selected by default, would not be selected by default.

#### Dashboards app & Low-Code Apps - Table component: Problem when trying to display null values returned by the query [ID_36669]

<!-- MR 10.4.0 - FR 10.3.8 -->

When a query linked to a table component returned null values, errors would be thrown when the table component tried to display those null values.

#### Dashboards app: An empty menu would open when users with only 'View dashboards' permission clicked the '...' button [ID_36671]

<!-- MR 10.4.0 - FR 10.3.8 -->

When users who only had permission to view dashboards clicked the *...* button in the top-right corner of the navigation pane, an empty menu would open.

From now on, users who only have permission to view dashboards will not see any *...* button in the top-right corner of the navigation pane.

#### Dashboards app: Problem when making changes to a dashboard when having that same dashboard open in two separate windows [ID_36718]

<!-- MR 10.4.0 - FR 10.3.8 -->

When you had opened the same dashboard in edit mode in two separate windows, the moment you made a change in one of the windows, a number of popup windows displaying "New version is available" would appear on top of the other window.

#### GQI: Not all DCF interface properties would be returned [ID_36840]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, when DCF interface properties were fetched, only the properties found on the DataMiner Agent to which you were connected would be returned. From now on, all DCF interface properties in the entire DataMiner System will be returned instead.

#### Dashboards app & Low-Code Apps: Query row feed would send a selected row twice when the table used two identical queries [ID_36952]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, when you selected a row of a table that used two identical queries, the query row feed would send the row twice. From now on, it will only send the row once.

#### Dashboards app & Low-Code Apps - GQI: Link to feed not saved when the feed value is identical [ID_36990]

<!-- MR 10.4.0 - FR 10.3.9 -->

In some cases, query nodes that were linked to a feed would incorrectly not save their link when a new feed was linked with the exact same value.

From now on, queries will always be updated when the source (dashboard/page), selector (component), type (datatype) or property of the link changes.

#### Low-Code Apps: Problem after removing a query used by a component [ID_36998]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you removed a query that was used by a component on the page you were viewing, the *UpdateDashboard* call and all subsequent calls would fail.

#### Dashboards app/Low-Code Apps: Changing query column while it was loading made it stop loading [ID_37006]

<!-- MR 10.4.0 - FR 10.3.10 -->

Up to now, if a column of a query was edited while the query was loading in a table component of a dashboard or low-code app, it would stop loading, and an empty table would temporarily be shown.

#### Dashboards app: Problem when adding or configuring a node edge graph component [ID_37039]

<!-- MR 10.4.0 - FR 10.3.9 -->

In some cases, it would no longer be possible to add a new node edge graph component to a dashboard. Also, an error could occur when trying to configure a node edge graph that had already been added.
