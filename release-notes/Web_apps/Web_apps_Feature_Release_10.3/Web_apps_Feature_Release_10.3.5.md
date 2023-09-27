---
uid: Web_apps_Feature_Release_10.3.5
---

# DataMiner web apps Feature Release 10.3.5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.5](xref:General_Feature_Release_10.3.5).

## Highlights

#### BREAKING CHANGE: One single authentication app for all web apps [ID_35772] [ID_35896]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, every web app had its own login screen and its own way of authenticating users. When using external authentication via SAML, this meant that, for every web app, a separate `AssertionConsumerService` element had to be added to the `spMetadata.xml` file.

A new dedicated authentication app has now been created. This app will be used by all current and future DataMiner web apps.

When using external authentication via SAML, this means that all existing `AssertionConsumerService` elements specified in the `spMetadata.xml` file can now be replaced by one single element. See the example below.

```xml
<md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/API/" index="1" isDefault="true"/>
```

In this element, `https://dataminer.example.com` has to be replaced with the IP address or the DNS name of your DataMiner System. Make sure the endpoint address in the `Location` attribute matches the address you specified when you registered DataMiner with the identity provider. The way you configure this will depend on the identity provider you are using (for example, in the case of Azure AD, this address has to be entered in the *Entity ID* field).

> [!NOTE]
>
> - When using external authentication via SAML, DataMiner should be configured to use HTTPS.
> - This new authentication app will also be used by DataMiner Cube, but only to authenticate users who want to access a web page stored on a DataMiner Agent, not to authenticate users who log in to Cube itself.

## Other new features

#### Monitoring app - Histograms: Time range buttons [ID_35733]

<!-- MR 10.4.0 - FR 10.3.5 -->

In the *Monitoring* app, histograms now have a number of time range buttons that allow you to quickly select one of the following preset time ranges:

- 1d (last 24 hours)
- 1w (last 7 days)
- 1m (last 30 days)
- 1y (last year)
- 5y (last 5 years)

#### Dashboards app - Line & area chart component: New 'Interval' option [ID_35774]

<!-- MR 10.4.0 - FR 10.3.5 -->

When configuring a line & area chart component, you can now use the *Interval* option to set the interval between the average trend data points shown in a trend graph to one of the following values:

- Auto (i.e. an interval relative to the specified trend span)
- Five minutes
- One hour
- One day

Up to now, a trend graph with *Trend span* set to "Last 7 days" would always show one-hour trend data. From now on, a trend graph with *Trend span* set to "Last 7 days" will show one-hour trend data when *Interval* is set to "Auto". However, if you set *Interval* to "Five minutes", that same trend graph will now show five-minute trend data instead.

> [!NOTE]
> The *Interval* option is only available when *Trend points* is set to "Average (changes only)" or "Average (fixed interval)".

#### GQI: New 'Then sort by' query node allows sorting by multiple columns [ID_35807] [ID_35834]

<!-- MR 10.4.0 - FR 10.3.5 -->

To make sorting more intuitive, the new *Then sort by* node can now be used in combination with the *Sort* node, which has now been renamed to *Sort by*.

Up to now, all sorting had to be configured by means of *Sort* nodes. For example, if you wanted to first sort by column A and then by column B, you had to create a query in the following counter-intuitive way:

1. Data source
1. Sort by B
1. Sort by A

or

1. Query X (i.e. Data Source, sorted by B)
1. Sort by A

From now on, you can create a query in a much more intuitive way. For example, if you want to first sort by column A and then by column B, you can now create a query in the following way:

1. Data source
1. Sort by A
1. Then sort by B

Note that, from now on, every *Sort by* node will nullify any preceding *Sort by* node. For example, in the following query, the *Sort by B* node will be nullified by the *Sort by A* node, meaning that the result set will only be sorted by column A.

1. Data source
1. Sort by B
1. Sort by A

> [!NOTE]
> The behavior of existing queries (using e.g. *Sort by B* followed by *Sort by A*) will not be altered in any way. Their syntax will automatically be adapted when they are migrated to the most recent GQI version.
> For example, an existing query using *Sort by B* followed by *Sort by A* will use *Sort by A* followed by *Then sort by B* after being migrated.

#### Dashboards app & Low-Code Apps: New 'Text input' feed [ID_35902]

<!-- MR 10.4.0 - FR 10.3.5 -->

The new *Text input* feed is a text box that exposes the entered text as a string feed that can currently be consumed by GQI queries and script parameters in low-code app actions.

When configuring this new *Text input* feed, you can optionally specify a label, an icon and a placeholder. You can also indicate whether the text box should allow multiple lines of texts and whether it should feed its value when triggered by the following events:

- On Enter
- On Focus lost
- On Value change

Currently, the *On Focus lost* event will also be triggered when you press the ENTER key.

A default value can be set by means of a URL option:

- In a dashboard URL, you can specify a default value in two ways:

  - `?strings=my text value`
  - `?data=<URL-encoded JSON object>`

- In a URL of a low-code app, you can specify a default value only in the following way:

  - `?data=<URL-encoded JSON object>`

For more information on how to pass data using a JSON object, see [Specifying data input in an app URL](xref:Specifying_data_input_in_URL).

#### Dashboards app & Low-Code Apps: New 'Numeric input' feed [ID_35911]

<!-- MR 10.4.0 - FR 10.3.5 -->

The new *Numeric input* feed is a text box that exposes the entered numbers as a number feed that can currently be consumed by GQI queries and script parameters in low-code app actions.

When configuring this new *Numeric input* feed, you can optionally specify a label, an icon, a placeholder, a unit, a step size, a number of decimals, a minimum value and a maximum value. You can also indicate whether the text box should feed its value when triggered by the following events:

- On Enter
- On Focus lost
- On Value change

A default value can be set by means of a URL option:

- In a dashboard URL, you can specify a default value in two ways:

  - `?numbers=123`
  - `?data=<URL-encoded JSON object>`

- In a URL of a low-code app, you can specify a default value only in the following way:

  - `?data=<URL-encoded JSON object>`

For more information on how to pass data using a JSON object, see [Specifying data input in an app URL](xref:Specifying_data_input_in_URL).

#### Low-Code Apps: 'Open monitoring card' action can now also be linked to a feed [ID_35986]

<!-- MR 10.4.0 - FR 10.3.5 -->

Since DataMiner feature release version 10.3.4, in a low-code app, you can configure an *Open monitoring card* action. When triggered, this action will open the card of a specific element, service or view in the *Monitoring* app. From now on, instead of specifying a specific element, service or view, it is also possible to link this action to a feed.

Also, up to now, when an *Open monitoring card* action was configured in the header bar or in page events, an `Operation is not valid due to the current state of the object` error could be thrown. This issue has now been fixed.

#### Dashboards app & Low-Code Apps - Table component: Enhanced visibility of rows that are selected or hovered over in dark mode [ID_35993]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.5 -->

When a dashboard or a low-code app is in dark mode, from now on, there will be a higher color contrast between rows that are selected or hovered over and rows that are not.

#### GQI: Data source rows now have a unique key [ID_35999]

<!-- MR 10.4.0 - FR 10.3.5 -->

GQI data source rows now have an internal key. This key is unique (per data source) and cannot be null or empty.

> [!NOTE]
> At present, you can only interact with these keys in [ad hoc data sources](#ad-hoc-data-source-keys) and [custom GQI operators](#custom-gqi-operator-keys).

##### Ad hoc data source keys

The `GQIRow` class has a new string property named `Key`. The key of a newly created row in an ad hoc data source can be specified using the following constructor:

```csharp
GQIRow(string key, GQICell[] cells)
```

> [!NOTE]
>
> - Although this constructor will throw an exception when a key is null or empty, the author of the data source is responsible for making sure that keys are unique.
> - If you don't pass the `key` argument when creating a row, the row index will be used as key.

##### Custom GQI operator keys

The `GQIEditableRow` class has a new string property named `Key`.

At present, this property can only be used to access the row key of an existing row. Keys of custom GQI operators cannot be modified yet.

##### Built-in data source keys

All rows of built-in data sources will automatically be assigned a unique key based on the row index.

##### Join operator keys

When two rows are joined, the key of the joined row will be a concatenation of the left row key and the right row key, separated by a forward slash:

```txt
<left-key>/<right-key>
```

In case of a left, right or outer join, when there is no match, either the left or right key will be an empty string. This is the reason why row keys cannot be empty. By allowing empty row keys we would risk creating duplicate keys each time rows are joined.

> [!NOTE]
> In keys of joined rows, any forward slashes and backward slashes will be escaped:
>
> - Any forward slash within the left or right key will be escaped by a backslash: `/` will become `\/`
> - Any backslash within the left or right key will be escaped by a second backslash: `\` will become `\\`

##### Aggregation operator keys

When no grouping is involved, the single row resulting from an aggregation operation will have a static row key equal to "0".

When grouping is involved, the single row resulting from an aggregation operation will have a key that is the concatenation of all the group values, separated by forward slashes.

For example, in case of the following query ...

`Data source -> Aggregate -> Group by A -> Group by B -> Group by C`

... the resulting row keys will look like this ...

```txt
<group-value-a>/<group-value-b>/<group-value-c>
```

In order to avoid duplicate group keys when there is only a single *Group By* operation, any empty values will be replaced by a single forward slash.

Also, any slashes in the group values will be escaped before they are joined. For more information about escaping slashes, see [Join operator keys](#join-operator-keys).

## Changes

### Enhancements

#### Monitoring app: Elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab [ID_35781]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In the *Monitoring* app, from now on, elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab.

#### GQI: Raw datetime values retrieved from Elasticsearch will now be converted to UTC [ID_35784]

<!-- MR 10.4.0 - FR 10.3.5 -->
<!-- Not added to MR 10.4.0 -->

Up to now, after each step in a GQI query, raw datetime values were always converted to the time zone that was specified in the query options. From now on, raw datetime values retrieved from Elasticsearch will be converted to UTC instead. The time zone specified in the query options will now only be used when converting a raw datetime value to a display value.

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

#### Web apps - Query builder: Query node options with only a single value will no longer be displayed in a selection box [ID_35865]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In the query builder, from now on, when a query node option only has a single value, that option will no longer be displayed in a selection box.

For example, up to now, when you selected the *Get elements* data source, followed by the *Aggregate* operator, the method selection box would display "Get the". This will no longer be the case.

#### GQI data sources that require an Elasticsearch database will now use GetInfoMessage(InfoType.Database) to check whether Elasticsearch is available [ID_35907]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, GQI data sources that require an Elasticsearch database used the `DatabaseStateRequest<ElasticsearchState>` message to check whether Elasticsearch was available. From now on, they will use the `GetInfoMessage(InfoType.Database)` message instead.

#### Web apps: Enhanced error handling when executing an interactive Automation script by clicking a DOM button [ID_35909]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Overall error handling has been improved when executing an interactive Automation script by clicking a DOM button in a web app.

#### Low-Code Apps - Line & area chart component: New 'Set timespan' action [ID_35933]

<!-- MR 10.4.0 - FR 10.3.5 -->

A 'Set timespan' action can now be configured for a line & area chart component. On execution, this action will apply a specific timespan to the component.

This action has two numeric arguments: 'To' and 'From'. These can be either set to a static value or linked to a numeric value feed.

#### Security enhancements [ID_35965]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

A number of security enhancements have been made.

### Fixes

#### Web apps: Problem with external authentication [ID_33405]

<!-- MR 10.4.0 - FR 10.3.5 -->

In some cases, it would not be possible to log in to a web app (e.g. Dashboards, Monitoring, Jobs, etc.) using external authentication.

#### GQI: GetArgumentValue method would throw an exception when used to access the value of an optional argument [ID_35783]

<!-- MR 10.4.0 - FR 10.3.5 -->

When the `GetArgumentValue<T>(string name)` method was used in an ad hoc data source or a custom operator script to access the value of an optional argument that had not been passed, the following exception would be thrown:

```txt
Could not find argument with name '{argument.Name}'.
```

#### Dashboards app & Low-Code Apps - GQI components: Problem when executing an empty query [ID_35803]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When GQI components tried to execute an empty query, up to now, they would keep on showing a "loading" indicator. From now on, an appropriate message will be displayed instead.

#### Dashboards app & Low-Code Apps: Duplicated component would not have the size as the original [ID_35804]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When you duplicated a component, the size of the duplicate would incorrectly be limited to 30 rows. From now on, when you duplicate a component, the duplicate will have the same size as the original.

#### Dashboards app & Low-Code Apps: Problem when feeding data from a GQI component to a query used in the same component [ID_35806]

<!-- MR 10.4.0 - FR 10.3.5 -->

An error could occur when feeding data from a GQI component to a query that was used in the same component.

#### Dashboards app & Low-Code Apps - GQI components: Open sessions would not be closed when a new query was triggered [ID_35824]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU2] - FR 10.3.5 -->

When a GQI component still had a session open when a new query was triggered, in some cases, the open session would incorrectly not be closed.

#### Dashboards app: Problem when using the search box on a mobile device [ID_35825]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When the *Dashboards* app was opened on a mobile device, an error could occur when you entered something in the search box.

#### Dashboards app & Low-Code Apps - Form component: Problems with multiple-selection drop-down boxes [ID_35829]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When a form component contained multiple-selection drop-down boxes, it would load too slowly due to the drop-down box change detection being triggered over and over again. From now on, form components containing multiple-selection drop-down boxes will load considerably quicker.

Also, when a multiple-selection drop-down field of a DOM instance was added to a form component, the current values preloaded into the field as placeholders would incorrectly not get removed once the data was loaded, causing the drop-down field to contain duplicate values.

#### Dashboards app: A table component could appear to be empty when you rapidly switched between visualizations [ID_35831]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, a table component could appear to be empty when you rapidly switched between visualizations.

Also, an error could be thrown when you tried to add an invalid query to a component.

#### Dashboards app & Low-Code Apps: Problem with 'Share' button and subheader items on mobile devices [ID_35839]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When you opened a dashboard or a low-code app on a mobile device, the *Share* button would not be available and the subheader items would not be hidden correctly.

#### Web apps: Problem when opening a visual overview [ID_35841]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

When you opened a visual overview in a web app, in some cases, the web app could become unresponsive.

#### Dashboards app: Problem when an extra GetParameterTable call without ValueFilters was sent after sharing a dashboard with a state, ring or gauge component [ID_35844]

<!-- MR 10.3.0 [CU3] - FR 10.3.5 -->

When a dashboard with a state, ring or gauge component was shared, in some cases, an error could be thrown when an extra `GetParameterTable` call without `ValueFilters` was sent.

#### Dashboards app & Low-Code Apps: Text boxes in the Layout tab would not update when you selected another component [ID_35851]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in the *Layout* tab, a text box (e.g. the box containing the title of the selected component) had the focus, and you selected another component, the text box in the *Layout* tab would incorrectly still contain the value of the previously selected component.

#### Dashboards app & Low-Code Apps - Table component: A collapsed group would incorrectly expand when new data was loaded into the table [ID_35856]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in a table component, the data was grouped by two different parameters, in some cases, a collapsed group would incorrectly expand when new data was loaded into the table.

#### Dashboards app: Problem when selecting a parameter in a parameter feed component of a shared dashboard [ID_35863]

<!-- MR 10.3.0 [CU3] - FR 10.3.5 -->

When you selected a parameter in a parameter feed component of a shared dashboard, in some cases, an error could occur.

#### Dashboards app: Multiple parameter feeds would incorrectly have their 'group by' reset when a PDF was generated [ID_35866]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

When you generated a PDF of a dashboard that contained multiple parameter feeds, a multiple parameter feed with a "group by" applied would incorrectly have that "group by" reset to the value that was configured in its settings.

#### Web apps: Certain icons would incorrectly not be displayed [ID_35877]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In web apps, certain icons would incorrectly not be displayed.

#### Dashboards app & Low-Code Apps - Table component: Initial grouping would incorrectly be considered a modification [ID_35882]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

In a table component, the initial grouping would incorrectly be considered a modification. As a result, the *Restore initial view* button would appear in the component header. When you then clicked that button, the grouping would be removed.

From now on, the initial grouping will no longer be considered a modification. When you modify the table by sorting, filtering, grouping or re-ordering data and then click the *Restore initial view* button, the initial grouping will now be restored.

#### Dashboards app & Low-Code Apps - Table component: Issues with 'Loading' indicator [ID_35894]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

A number of issues with regard to the "Loading" indicator have been fixed.

#### Dashboards app & Low-Code Apps - GQI components: Problems when a GQI request failed [ID_35904]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a GQI request failed, some GQI components would show either an unrelated error or no error at all, while other GQI components would show a correct error but incorrect data.

#### Dashboards app & Low-Code Apps: Performance could decrease when State components had their Design option set to 'Auto size' [ID_35905]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, overall performance of a dashboard or a low-code app could decrease when it contained *State* components of which the *Design* option was set to "Auto size". A number of enhancements have now been made to prevent performance from decreasing in this case.

#### Web apps: Login button would incorrectly be disabled on Edge and Chrome [ID_35906]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, in some cases, the login button would incorrectly be disabled when you opened a web app in Microsoft Edge or Google Chrome.

#### Monitoring app - Visual Overview: Clicking a region that opened an element, service or view card would incorrectly cause the Monitoring app to reload [ID_35908]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When, in the Monitoring app, you clicked a region in a visual overview that opened an element, service or view card, up to now, the entire Monitoring app would reload. From now on, when you click a region in a visual overview that opens an element, service or view card, the card in question will open but the Monitoring app will no longer be reloaded.

#### Dashboards app & Low-Code Apps - Clock components: Clock time would not update when set to server time [ID_35912]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a clock component (analog or digital) was set to use server time, the clock time would not update.

#### Dashboards app: Shared dashboards can now be edited [ID_35940]

<!-- MR 10.4.0 - FR 10.3.5 -->

From now on, it is possible to edit a shared dashboard.

Also, a *Shared* button will now be displayed in the header bar of a shared dashboard. Clicking this button will open the same pop-up box that opens when you click *Share > Manage share*.

> [!NOTE]
> It is not possible to rename or to move a shared dashboard.

#### Low-Code Apps: Problem when selecting an action with multiple components after having selected an action with a single component [ID_35947]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When you first selected an action with a single component, which was selected automatically, and then selected an action with multiple components, up to now, both the action selection box and the component selection box would incorrectly be cleared.

#### Low-Code Apps: Page names and panel names could incorrectly be empty [ID_35960]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, page names and panel names could incorrectly be empty. From now on, this will no longer be allowed.

#### Dashboards app - Line & area chart: Legend would show an incorrect number of disabled parameters [ID_35970]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When configuring a line & area chart, you can use the *Chart limit* setting to specify the maximum number of parameters that can be displayed in the chart. The excess parameters will then be disabled but remain available in the chart legend, so that they can be enabled again manually.

In some cases, the number of disabled parameters shown in the legend would be incorrect.

#### Dashboards app & Low-Code Apps: Filter box of visualizations panel would not reset [ID_36000]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When you reloaded the editor, by clicking the *Refresh* button while editing a dashboard or by switching pages while editing a low-code app, or when you switched to edit mode after previewing or publishing a low-code app, the filter box of the visualizations panel would incorrectly not be reset.

#### Dashboards app - GQI: No element feed available after selecting a relation between two standalone parameters [ID_36003]

<!-- MR 10.4.0 - FR 10.3.5 -->

When, in a table with a *Get parameter relations* query, you selected a relation between two standalone parameters, no element feed would be available.

#### Dashboards apps & Low-Code Apps: Components would incorrectly make their own data available as feeds [ID_36008]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Up to now, components would incorrectly make their own data available as feeds.

#### Dashboards app & Low-Code Apps - Table component: 'Restore initial view' button would incorrectly remain visible when switching to an empty query [ID_36010]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in a table component, you switched from a non-empty query to an empty query, the *Restore initial view* button would incorrectly remain visible in the component header.

#### Web apps: Problem with single sign-on when embedded in Cube [ID_36049]

<!-- MR 10.4.0 - FR 10.3.5 [CU0] -->

When the *Dashboards*, *Jobs*, or *Ticketing* app was embedded in DataMiner Cube, in some cases, users would incorrectly be prompted to log in to the app.

#### Dashboards app & Low-Code Apps: Incorrect error could appear when editing a dashboard or low-code app [ID_36132]

<!-- MR 10.4.0 - FR 10.3.5 [CU0] -->

When editing a dashboard or a low-code app, in some cases, the following error could incorrectly appear:

```txt
The dashboard has not been saved: Invalid revision sequence, the dashboard might have been edited by another user.
```

#### Dashboards app: Problem when pressing an arrow key in the 'Create dashboard' window [ID_36146]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In the *Create dashboard* window, pressing an arrow key while one of the text boxes had the focus would incorrectly cause the *OK* or *Cancel* button to become selected.

#### GQI: Web services API would not be able to correctly translate a server query to a web query [ID_36173]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.5 [CU0] -->

In some cases, the web services API would not be able to correctly translate a server query to a web query.
