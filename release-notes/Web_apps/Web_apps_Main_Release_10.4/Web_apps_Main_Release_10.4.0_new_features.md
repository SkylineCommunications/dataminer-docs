---
uid: Web_apps_Main_Release_10.4.0_new_features
---

# DataMiner web apps Main Release 10.4.0 – New features – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

#### DOM features now available in Dashboards and Low-Code Apps [ID_29732] [ID_31804] [ID_32236] [ID_36124]

<!-- MR 10.4.0 - FR 10.3.6 -->

In DataMiner Dashboards and Low-Code Apps, several new features related to DOM are now available.

##### New data input options

In the data pane, you will now find the following new data feeds:

- Object Manager Definitions
- Object Manager Instances

In addition, you can now use object manager instances as a query (GQI) data source, and it is possible to specify the following objects in URL feeds:

- object manager definitions
- object manager instances
- object manager modules

##### New Form component

A new "Form" component is now also available. It takes an object manager instance or object manager definition as data input and displays it as a form:

- In a dashboard, only an object manager instance can be used as input.
- In a low-code app, you can use either an object manager instance or a object manager definition, or both. If you use a definition, the fields of the definition are displayed, which the user can fill in to create an instance. Using both definition and instance input at the same time can for example be useful in case you use a dynamic feed for the instance. In that case, as long as a value is being fed, the data of the instance is displayed; otherwise the empty fields of the definition are displayed.

If you use this component with object manager instance input in a low-code app, you can use the *Read mode* layout setting to determine whether it should be an editable form or not. In a dashboard, a form can only be displayed in read-only mode.

In a low-code app, this component will also make a number of component actions available, which you can for instance use with a button:

- *Create a new instance*: This will create an empty form for the configured DOM definition even if a DOM instance is configured as data. This allows you to link a DOM instance feed to the component and at the same time make it possible to create a new DOM instance.
- *Cancel current changes*: If you execute this action after you executed the action to create a new instance, the previously shown form will be displayed again.
- *Delete instance*
- *Save current changes*
- *Set form to edit mode*
- *Set form to read mode*

#### Dashboards app & Low-Code Apps: Query filter component now officially released [ID_33530] [ID_33547] [ID_34037] [ID_36822] [ID_36832]

<!-- MR 10.4.0 - FR 10.3.9 -->

The *Query filter* component has now officially been released. When linked to a *Table* component or a *Node edge graph* component, this component will allow you to filter the table or the node edge graph on the fly.

There are two ways in which you can link a query filter. See the following examples.

- **Feeding queries as data**

  1. Place a new *Query filter* component on the dashboard.

  1. Create a query (e.g. a query named *Elements* based on the *Get elements* data source) and drag it on top of the query filter component.
  
     Note that a feed name will appear in the bottom-right corner of the query filter component (e.g. "Query filter 1").

  1. Place a new *Table* component on the dashboard.

  1. In the *Data* tab, go to *All available data* > *Feeds*, expand the feed associated with the query filter (e.g. "Query filter 1"), and drag *Queries* on top of the table component.

  Result: Each time you change the query filter, a new query will be fed to the table. The latter will only show the rows that match the filter set in the query filter component.

- **Feeding query columns as filter**

  1. Place a new *Query filter* component on the dashboard.

  1. Create a query (e.g. a query named *Elements* based on the *Get elements* data source) and drag it on top of the query filter component.
  
     Note that a feed name will appear in the bottom-right corner of the query filter component (e.g. "Query filter 1").

  1. Place a new *Table* component on the dashboard.

  1. In the *Data* tab, go to *All available data* > *Queries*, and drag the query you created earlier (e.g. *Elements*) on top of the table component.

  1. In the *Data* tab, go to *All available data* > *Feeds*, expand the feed associated with the query filter (e.g. "Query filter 1"), and drag *Query columns* on top of the yellow filter drop area of the table component.

  Result: Each time you change the query filter, the data inside the table will be filtered according to the filter settings in the query filter. No new query will be fed to the table. The latter will keep on showing all rows, but those that do not match the filter will turn gray.

Settings:

- **Filter assistance**: If you activate this setting, the choices the query filter offers will already be filtered according to the data that is available.

  For example, if the table contains a *State* column, and the table only contains rows of which that column contains "Active" or "Stopped", you will not be able to filter on other state values. Moreover, next to each filter option the number of matching rows will be displayed. For example, when there are 20 rows of which the *State* column contains "Active", then the filter will show the Active state option as "Active (20)".

- **Allow color mode**: If this setting is activated (which it is by default), in the top-right corner of the filter query component, you will be able to click a color marker icon. When you do so, a color legend will appear on the right of the filter options, and for each of those options you will be able to configure a color (default color: green).

  > [!NOTE]
  > When you deactivate the *Allow color mode* setting, the colors you configured will stay visible and applied.

> [!NOTE]
>
> - At the top of a *Query filter* component, you have an *Active (x)* toggle button. If you enable this button, the component will display only the active filter options and the button itself will indicate the number of active options.
> - In a *Query filter* component, next to each column that contains discrete values of type string or number, you will find a button that allows you to change how the possible values are displayed:
>
>   - Click *Toggle checklist* to have all possible values listed in the form of a checklist.
>   - Click *Toggle free form* to display a text box in which users can type a value.
>
> - when you only filter a node edge graph by node, edges will be highlighted only when both source and destination are highlighted. When you only filter a node edge graph by edge, the source and/or destination attached to the highlighted edge segments will be highlighted.

#### Dashboards app & Low-Code Apps: Icon component [ID_34867]

<!-- MR 10.4.0 - FR 10.3.1 -->

The new icon component allows you to display an icon on a dashboard or a low-code app.

#### Interactive Automation scripts: New button style 'CallToAction' [ID_34904]

<!-- MR 10.4.0 - FR 10.3.1 -->

In an interactive Automation script launched from a dashboard or a low-code app, you can now apply the *CallToAction* style to a button.

When you apply this style to a button

- the background color of the button will be the color of the app,
- the color of the text on the button will be white, and
- the button will have a shadow.

To set the style of a button in an interactive Automation script, set the *Style* property of the button's *UIBlockDefinition* to the name of the style. All supported styles are available via `Style.Button`.

Alternatively, you can also pass a button style directly to the `AppendButton` method on an `UIBuilder` object.

> [!NOTE]
>
> - Up to now, `StaticText` blocks already supported a number of styles. Those styles are now also available via `Style.Text`: *Title1*, *Title2* and *Title3*.
> - The *CallToAction* style will only be applied in interactive Automation scripts launched from a web app. It will not be applied in interactive Automation scripts launched from Cube.

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

#### Interactive Automation scripts: New DownloadButton component [ID_35869]

<!-- MR 10.4.0 - FR 10.3.7 -->

In an interactive Automation script launched from a dashboard or a low-code app, you can now use *DownloadButton* components. These components allow you to add download buttons that will enable users to download a specified file from the server.

To add a *DownloadButton* component to an interactive Automation script, create a *UIBlockDefinition* and set its *Type* property to "UIBlockType.DownloadButton". The button can be configured and styled in same way as a regular button component. For example, you can set the *Style* property to "Style.Button.CallToAction" and the *Text* property to "Download".

To configure the download properties, assign `AutomationDownloadButtonOptions` to the *ConfigOptions* property of the *UIBlockDefinition*.

These are the supported download properties:

- **Url**: The URL of the file. This URL can be either an absolute or a relative path.

  - An absolute path must refer to a file that is publicly accessible on the internet.
  - A relative path is relative to the DMA hostname and must start with `/`, `./` or `../`.

  Examples:

  - Example of an absolute path: To download the latest Cube version from DataMiner Services, set *Url* to `https://dataminer.services/install/DataMinerCube.exe`.
  - Example of a relative path: To download the file hosted on URL `http(s)://yourDma/Documents/MyElement/MyDocument.txt` (i.e. the file *MyDocument.txt* located in the folder `C:\Skyline DataMiner\Documents\MyElement\` of the DMA), set *Url* to `/Documents/MyElement/MyDocument.txt`.

- **FileNameToSave**: The name that will be given to the file once it has been downloaded. By default, this name is identical to that of the file at the remote location.

  > [!NOTE]
  > Some browsers block overriding the file name when the file to be downloaded is not located on the DataMiner Agent. In this case, the original file name will be used.

- **StartDownloadImmediately**: If set to true (default setting is false), the download will start as soon as the component is displayed. The button will stay visible and can be clicked to download the file again.

- **ReturnWhenDownloadIsStarted**: If set to true (default default is false), the `engine.ShowUI()` method will return as soon as the download is started (either immediately or when the user clicks the button, depending on *StartDownloadImmediately*). When both *StartDownloadImmediately* and *ReturnWhenDownloadIsStarted* are set to true, the script will start the download and exit immediately (unless a new `engine.ShowUI()` call is made).

  > [!NOTE]
  > The script's UI will be visible for about half a second.

The `UIResult` now also supports the following function method, which returns true when a download button with *ReturnWhenDownloadIsStarted* set to true has started a download.

```csharp
bool WasOnDownloadStarted(string key)
```

> [!NOTE]
>
> - Modern browsers block downloads from a `file:///` URL to an HTTP(s) address. In other words, they don't allow you to download a file located on a network share. As a workaround, you can copy the file from the network share to *Documents* (or any other HTTP-reachable location), and then let the client download it from that URL.
> - The current IIS configuration does not allow all file types to be downloaded.

#### Dashboards app & Low-Code Apps - Column & bar chart / Pie & donut chart: Automatically select columns based on type [ID_36229]

<!-- MR 10.4.0 - FR 10.3.7 -->

When you add a query to a *Column & bar chart* component or a *Pie & donut chart* component, the label, segment size and bars will now automatically be configured.

To do so, the system will proceed as follows:

1. Search for a column that contains label values (i.e. a column with heading "label", "name", etc.).
1. Search for a column that contains segment size or bar size values (i.e. a column with heading "amount", "value", "quantity", etc.).
1. If nothing could be found in steps 1 and 2, take the first string value as label and the first numeric value as segment size or bar size value.

> [!NOTE]
> Existing *Column & bar chart* components and *Pie & donut chart* components will be migrated automatically.

#### Dashboards app & Low-Code Apps: Button panel visualization now officially released [ID_36775]

<!-- MR 10.4.0 - FR 10.3.9 -->

The button panel visualization has now officially been released. This component will display a button panel with buttons representing the rows of a table parameter. Using an element with a custom button panel protocol, you can configure what kind of buttons are displayed and how the buttons are displayed.

The following types of buttons can be configured:

- Simple buttons used only to set parameters.
- HTML buttons.
- Rotate buttons, resembling a control dial, used to decrement or increment the value of a particular parameter. The buttons can be used by dragging and dropping with the mouse, by using the arrow keys on the keyboard, or by sliding on a mobile device.

For more information, see [Button panel](xref:DashboardButtonPanel).

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

#### Dashboards app & Low-Code Apps: 'Lazy load components' setting [ID_35469] [ID_35486]

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

#### Low-Code Apps: New action 'Open monitoring card' [ID_35661] [ID_35986]

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

#### Dashboards app & Low-Code Apps: New 'Text input' feed [ID_35902] [ID_36983]

<!-- RN 35902: MR 10.4.0 - FR 10.3.5 -->
<!-- RN 36983: MR 10.4.0 - FR 10.3.9 -->

The new *Text input* feed is a text box that exposes the entered text as a string feed that can currently be consumed by GQI queries and script parameters in low-code app actions.

When configuring this new *Text input* feed, you can optionally specify a label (and its position), an icon and a placeholder. You can also indicate whether the text box should allow multiple lines of texts and whether it should feed its value when triggered by the following events:

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

#### Dashboards app & Low-Code Apps: New 'Numeric input' feed [ID_35911] [ID_36983]

<!-- RN 35902: MR 10.4.0 - FR 10.3.5 -->
<!-- RN 36983: MR 10.4.0 - FR 10.3.9 -->

The new *Numeric input* feed is a text box that exposes the entered numbers as a number feed that can currently be consumed by GQI queries and script parameters in low-code app actions.

When configuring this new *Numeric input* feed, you can optionally specify a label (and its position), an icon, a placeholder, a unit, a step size, a number of decimals, a minimum value and a maximum value. You can also indicate whether the text box should feed its value when triggered by the following events:

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

#### Low-Code Apps - Line & area chart component: New 'Set timespan' action [ID_35933]

<!-- MR 10.4.0 - FR 10.3.5 -->

A 'Set timespan' action can now be configured for a line & area chart component. On execution, this action will apply a specific timespan to the component.

This action has two numeric arguments: 'To' and 'From'. These can be either set to a static value or linked to a numeric value feed.

#### Dashboards app: Shared dashboards can now be edited [ID_35940]

<!-- MR 10.4.0 - FR 10.3.5 -->

From now on, it is possible to edit a shared dashboard.

Also, a *Shared* button will now be displayed in the header bar of a shared dashboard. Clicking this button will open the same pop-up box that opens when you click *Share > Manage share*.

> [!NOTE]
> It is not possible to rename or to move a shared dashboard.

#### Low-Code Apps: Making an app execute actions by adding action configurations to the app's URL [ID_35979]

<!-- MR 10.4.0 - FR 10.3.6 -->

It is now possible to make an app execute one or more actions by adding action configurations to the app's URL.

To do so, proceed as follows:

1. Configure the action(s) in the action editor.
1. Click the *Copy actions* button to copy the action configuration to the clipboard as a JSON object.
1. Add `#{"actions": }` to the URL, and paste the JSON object between the colon (`:`) and the closing bracket (`}`).

When you add an action configuration to a URL of an app, the action(s) will immediately be executed. The app does not need to be reloaded. This way, even apps that are embedded in a visual overview can easily be forced to execute actions.

As soon as the actions have been executed, the action configuration will be removed from the URL to prevent them from being executed multiple times.

Example of an *Open a panel* action added to the URL of an app:

```txt
https://myDMA/APP_ID/PAGE_NAME#{"actions":[{"Type":6,"__type":"Skyline.DataMiner.Web.Common.v1.DMAApplicationPagePanelAction","Panel":"4507edc7-fcee-47bd-985c-f40d844e72cb","Position":"Center","Width":30,"AsOverlay":true}]}
```

> [!NOTE]
>
> - Making an app execute actions by adding a configuration to its URL does not work while that app is in edit mode.
> - Currently, the following actions cannot be executed this way for security reasons:
>
>   - *Launch a script*
>   - *Execute component action: delete current instance/save current changes*
>   - *Navigate to a URL*

#### Dashboards app & Low-Code Apps - Table and State components: New 'Initial selection' setting [ID_35984]

<!-- MR 10.4.0 - FR 10.3.6 -->

The *Table* and *State* components now have a new *Initial selection* setting.

When you enable this setting, the first entry of the GQI result set will automatically be selected when the dashboard or app is opened or refreshed.

> [!NOTE]
>
> - This new setting has also been added to the *Grid* component, which is only available if you activate the *ReportsAndDashboardsDynamicVisuals* soft-launch option.
> - For reasons of consistency, in the Drop-down feed, List feed, Parameter feed and Tree feed, the *Feed defaults* setting has now also been renamed to *Initial selection*

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

#### Dashboards app & Low-Code Apps: Clearing a State component by means of CTRL+Click [ID_36056]

<!-- MR 10.4.0 - FR 10.3.6 -->

You can now clear a *State* component by clicking it while holding down the CTRL key.

#### Low-Code Apps: Duplicating pages and panels is now possible via new context menu [ID_36097]

<!-- MR 10.4.0 - FR 10.3.6 -->

When editing a low-code app, it is now possible to duplicate an entire page or panel via the new context menu, accessible by clicking the ellipsis icon next to the page name in the pane on the left or the panel name in the page configuration pane. This context menu also allows you to delete a page or panel, as well as hide a page from the sidebar.

#### Dashboards app & Low-Code Apps - Table component: Selecting whether to export raw values or display values to CSV [ID_36467]

<!-- MR 10.4.0 - FR 10.3.8 -->

You can export the data displayed by a table component by clicking the ... button in the top-right corner of the component and selecting *Export to CSV*. From now on, a pop-up window will open where you can select whether the raw values or the display values from the table should be exported.

Exporting the display values will result in a CSV file that contains all the values as they are seen in the table, formatted and with units. If you export the raw values, no formatting will be applied to them. The only exception are discrete values, for which the corresponding display values will always be exported.

If no rows are selected in the table, the entire table will be exported; otherwise only the selected rows will be exported.

#### GQI: Ad hoc data sources can now include columns of type GQITimeSpanColumn [ID_36717]

<!-- MR 10.4.0 - FR 10.3.9 -->

Ad hoc data sources can now include columns of type `GQITimeSpanColumn`. These columns can contain a time span and can have operators applied to them.

#### Dashboards app & Low-Code Apps - Parameters dataset: Selecting an index/cell of a column parameter [ID_36724]

<!-- MR 10.4.0 - FR 10.3.9 -->

In the *Parameters* section of the edit panel's *DATA* tab, column parameters will now by default list their first 100 indices (i.e. cells). When you drag one of those cells onto a component, element ID, parameter ID as well as index will be passed along.

If the index (i.e. cell) you need is not among the first 100 indices that are listed, you can use the search box above the parameter list to narrow down the list of indices.
