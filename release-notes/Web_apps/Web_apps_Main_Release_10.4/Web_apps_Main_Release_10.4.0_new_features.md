---
uid: Web_apps_Main_Release_10.4.0_new_features
---

# DataMiner web apps Main Release 10.4.0 – New features – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

#### Dashboards app & Low-Code Apps: Icon component [ID_34867]

<!-- MR 10.4.0 - FR 10.3.1 -->

The new icon component allows you to display an icon on a dashboard or a low-code app.

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

#### Dashboards app - GQI: New data sources [ID_34747] [ID_35027] [ID_34965] [ID_35058]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the Generic Query Interface, the following new data sources are now available:

| Data source                   | Contents                                                   |
|-------------------------------|------------------------------------------------------------|
| Get trend data patterns       | All pattern matching tags created in the DataMiner System. |
| Get trend data pattern events | All pattern occurrences detected in the DataMiner System.  |
| Get behavioral change events  | All behavioral anomalies detected in the DataMiner System. |

The *Get trend data pattern events* and *Get behavioral change events* data sources contain time range metadata on each row. Each time range holds the start and end time of the event in question. When a table row is selected, the time range will be exposed as a feed.

#### Dashboards app & Low-Code Apps - GQI: 'Row by row' option [ID_35057] [ID_35565]

<!-- MR 10.4.0 - FR 10.3.3 -->

When configuring a Join operator, you can now select the *Row by row* option.

- When you do not select the *Row by row* option, the join will execute both the left and the right queries once, and directly combine their results (default behavior).

- When you select the *Row by row* option, the join will execute the left query first, and then execute the right query for each row  with a filter derived from the Join condition.

> [!NOTE]
>
> - The *Row by row* option will only be visible and configurable when you opened the dashboard or app with `showAdvancedSettings=true` added to the URL.
> - Currently, the *Row by row" option is only supported for inner and left joins. If you use it for an outer or right join, an exception will be thrown.

#### Monitoring app: Element name added to breadcrumbs of trend card [ID_35270]

<!-- MR 10.4.0 - FR 10.3.3 -->

As of now, the header of a trend card shows a breadcrumb trail with the element name of a parameter as a clickable item. Clicking this element name allows you to quickly navigate back to the element card.

#### GQI: 'State' column added to 'Get views' data source [ID_35333]

<!-- MR 10.4.0 - FR 10.3.3 -->

A `State` column has been added to the *Get views* data source. This column shows the alarm state of the view.

#### GQI: Multiple groupBy operations can now be applied after an aggregation operation [ID_35355]

<!-- MR 10.4.0 - FR 10.3.3 -->

After an aggregation operation, you can now apply multiple groupBy operations.

#### Dashboards app - GQI: New 'Get parameter relations' data source [ID_35443]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the Generic Query Interface, the *Get parameter relations* data source is now available.

It can be used to retrieve the parameter relationships that are stored in a model managed by a DataMiner Extension Module named *ModelHost*.

> [!NOTE]
> This data source will only be available when *ModelHost* is running.

#### Dashboards app & Low-code apps: 'Lazy load components' setting [ID_35469] [ID_35486]

<!-- MR 10.4.0 - FR 10.3.4 -->

In the configuration settings of a dashboard or a page/panel of a low-code app, you can now find the *Lazy load components* setting.

When this setting is enabled, the components on the dashboard or the page/panel of the low-code app will only be initialized the first time they appear on the screen. This will considerably shorten the initial load time and enhance overall performance of large dashboards and large pages/panels of low-code apps.

> [!NOTE]
>
> - This setting, which is enabled by default for all new dashboards and all new pages/panels of low-code apps, is only available if you add the `showAdvancedSettings=true` option to the dashboard URL.
> - Even when this setting is enabled, components will not be lazy loaded in edit mode.

#### Monitoring app - Trending: Switching between trend graph and histogram [ID_35501]

<!-- MR 10.4.0 - FR 10.3.4 -->

When viewing a trend graph in the Monitoring app, you can now easily switch between trend graph and histogram by clicking either the trend graph or histogram icon in the top-right corner.

#### Monitoring app & Dashboards app - Line & area chart: Time range buttons [ID_35595]

<!-- MR 10.4.0 - FR 10.3.4 -->

A line & area chart component now has a number of time range buttons that allow you to quickly select one of the following preset time ranges:

- 1d (last 24 hours)
- 1w (last 7 days)
- 1m (last 30 days)
- 1y (last year)
- 5y (last 5 years)

> [!NOTE]
> In the *Dashboards* app, these time range buttons are disabled by default. When configuring the component, you can enable them by selecting the *Show time range buttons* option in the *Component > Layout > Styling and Information* tab.

#### Low-code apps: New action 'Open monitoring card' [ID_35661] [ID_35986]

<!-- RN 35661: MR 10.4.0 - FR 10.3.4 -->
<!-- RN 35986: MR 10.4.0 - FR 10.3.5 -->

In a low-code app, you can now configure a new type of action: *Open monitoring card*. When triggered, this action will open the card of a specific element, service or view in the *Monitoring* app.

This element, service or view can either be provided as a static value or by a feed linked to the action.

> [!NOTE]
> When a low-code app is embedded in Cube (e.g. in a visual overview), an *Open monitoring card* action will open the specified card in Cube.

#### GQI - Ad hoc data source: Sending and receiving DMS messages [ID_35701]

<!-- MR 10.4.0 - FR 10.3.4 -->

Ad hoc data sources can now retrieve data by means of DMS messages.

To do so, the `IGQIDataSource` must implement the `IGQIOnInit` interface, of which the `OnInit` method can also be used to initialize a data source:

```csharp
OnInitOutputArgs OnInit(OnInitInputArgs args)
```

When passed to the `OnInit` method, `OnInitInputArgs` can now contain the following new property:

```csharp
GQIDMS DMS
```

The `GQIDMS` class contains the following methods, which can be used to request information in the form of `DMSMessage` objects:

| Method | Function |
|--------|----------|
| `DMSMessage SendMessage(DMSMessage message)` | Sends a request that expects a single response. |
| `DMSMessage[] SendMessages(params DMSMessage[] messages)` | Sends multiple requests at once, or sends a request that expects multiple responses. |

The `GQIDMS` object is only generated when the property is used.

Generally, an ad hoc data source implementation will want to add a private field where it can store the `GQIDMS` object to be used later in other callbacks when columns and rows are created.

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the DataMiner UI or the automation options provided in DataMiner Automation, we highly recommend that you do so instead.

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

#### Dashboards app & Low-code apps: New 'Text input' feed [ID_35902]

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

#### Dashboards app & Low-code apps: New 'Numeric input' feed [ID_35911]

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

#### Low-code apps - Line & area chart component: New 'Set timespan' action [ID_35933]

<!-- MR 10.4.0 - FR 10.3.5 -->

A 'Set timespan' action can now be configured for a line & area chart component. On execution, this action will apply a specific timespan to the component.

This action has two numeric arguments: 'To' and 'From'. These can be either set to a static value or linked to a numeric value feed.

#### Dashboards app: Shared dashboards can now be edited [ID_35940]

<!-- MR 10.4.0 - FR 10.3.5 -->

From now on, it is possible to edit a shared dashboard.

Also, a *Shared* button will now be displayed in the header bar of a shared dashboard. Clicking this button will open the same pop-up box that opens when you click *Share > Manage share*.

> [!NOTE]
> It is not possible to rename or to move a shared dashboard.

#### Dashboards app & Low-code apps - Table and State components: New 'Initial selection' setting [ID_35984]

<!-- MR 10.4.0 - FR 10.3.6 -->

The *Table* and *State* components now have a new *Initial selection* setting.

When you enable this setting, the first entry of the GQI result set will automatically be selected when the dashboard or app is opened or refreshed.

> [!NOTE]
> This new setting has also been added to the *Grid* component, which is only available if you activate the *ReportsAndDashboardsDynamicVisuals* soft-launch option.

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

#### Dashboards app & Low-code apps: Clearing a State component by means of CTRL+Click [ID_36056]

<!-- MR 10.4.0 - FR 10.3.5 -->

You can now clear a *State* component by clicking it while holding down the CTRL key.
