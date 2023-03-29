---
uid: Web_apps_Feature_Release_10.3.5
---

# DataMiner web apps Feature Release 10.3.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.4](xref:General_Feature_Release_10.3.5).

## Highlights

#### BREAKING CHANGE: One single authentication app for all web apps [ID_35772] [ID_35896]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, every web app had its own login screen and its own way of authenticating users. When using external authentication via SAML, this meant that, for every web app, a separate `AssertionConsumerService` element had to be added to the `spMetadata.xml` file.

A new dedicated authentication app has now been created. This app will be used by all current and future DataMiner web apps.

When using external authentication via SAML, this means that all existing `AssertionConsumerService` elements specified in the `spMetadata.xml` file can now be replaced by one single element. See the example below.

```xml
<md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/API/" index="1" isDefault="true"/>
```

> [!NOTE]
> In this element, `https://dataminer.example.com` has to be replaced with the IP address or the DNS name of your DataMiner System. Make sure the endpoint address in the `Location` attribute matches the address you specified when you registered DataMiner with the identity provider. The way you configure this will depend on the identity provider you are using (for example, in the case of Azure AD, this address has to be entered in the *Entity ID* field).

Also, when using external authentication via SAML, the `<system.webServer>` element of the `C:\Skyline DataMiner\Webpages\API\Web.config` file has to contain the following:

```xml
<defaultDocument>
   <files>
      <add value="default.aspx" />
   </files>
</defaultDocument>
```

> [!NOTE]
>
> - When using external authentication via SAML, DataMiner should be configured to use HTTPS.
> - This new authentication app will also be used by DataMiner Cube, but only to authenticate users who want to access a web page stored on a DataMiner Agent, not to authenticate users who log in to Cube itself.

[](#breaking-change-one-single-authentication-app-for-all-web-apps-id_35772-id_35896)

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

#### Web apps: New action 'Pan to view' [ID_35847]

<!-- MR 10.4.0 - FR 10.3.5 -->

In a low-code app, you can now configure a new type of action: *Pan to view*.

When triggered, this action will center the map shown in a specified *Generic map* component on a specified location (defined by a latitude and a longitude).

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

## Changes

### Enhancements

#### Monitoring app: Elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab [ID_35781]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In the *Monitoring* app, from now on, elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab.

#### Monitoring app - Histogram: Sidebar enhancements [ID_35797]

<!-- MR 10.4.0 - FR 10.3.5 -->

In the *Monitoring* app, a number of enhancements have been made to the sidebar of the *Histogram* page of a parameter:

- The icons that allow you to switch between trend graph and histogram have been updated.
- The *Time span* selection box has been removed.
- The width of the sidebar has been reduced.

#### Web Services API: Performance enhancements [ID_35805]

<!-- MR 10.4.0 - FR 10.3.5 -->

A web API event queue will now automatically be removed after 5 minutes if a client did not request the events in that queue during those 5 minutes. As a result, overall web API memory consumption will decrease considerably.

Also, it is now possible for one web API connection to have multiple event queues. As a result, clients will be able to have multiple open websocket connections using the same connection ID.

#### Dashboards app & Low-code apps: New way to link components to feeds [ID_35837]

<!-- MR 10.4.0 - FR 10.3.5 -->

The way in which components are linked to feeds has been improved. Instead of using a *Use feed* or *Link x to feed* checkbox, you will now be able to configure a feed link by means of a picker window.

> [!CAUTION]
> BREAKING CHANGE: Up to now, when you linked a script parameter to the *From* or *Till* box of a time range feed, the feed would pass a datetime value in string format to the script. That string value was not in an ISO format and did not contain any information about the time zone. From now on, the feed will send a UTC timestamp in milliseconds instead. Scripts that expect to receive a string value will need to be modified.

#### Web apps - Query builder: Query node options with only a single value will no longer be displayed in a selection box [ID_35865]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In the query builder, from now on, when a query node option only has a single value, that option will no longer be displayed in a selection box.

For example, up to now, when you selected the *Get elements* data source, followed by the *Aggregate* operator, the method selection box would display "Get the". This will no longer be the case.

#### Web apps: Enhanced error handling when executing an interactive Automation script by clicking a DOM button [ID_35909]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Overall error handling has been improved when executing an interactive Automation script by clicking a DOM button in a web app.

#### Low-code apps - Line & area chart component: New 'Set timespan' action [ID_35933]

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

#### Dashboards app & Low-code apps - GQI components: Problem when executing an empty query [ID_35803]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When GQI components tried to execute an empty query, up to now, they would keep on showing a "loading" indicator. From now on, an appropriate message will be displayed instead.

#### Dashboards app & Low-code apps: Duplicated component would not have the size as the original [ID_35804]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When you duplicated a component, the size of the duplicate would incorrectly be limited to 30 rows. From now on, when you duplicate a component, the duplicate will have the same size as the original.

#### Dashboards app & Low-code apps: Problem when feeding data from a GQI component to a query used in the same component [ID_35806]

<!-- MR 10.4.0 - FR 10.3.5 -->

An error could occur when feeding data from a GQI component to a query that was used in the same component.

#### Dashboards app & Low-code apps - GQI components: Open sessions would not be closed when a new query was triggered [ID_35824]

<!-- MR 10.4.0 - FR 10.3.5 -->

When a GQI component still had a session open when a new query was triggered, in some cases, the open session would incorrectly not be closed.

#### Dashboards app: Problem when using the search box on a mobile device [ID_35825]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When the *Dashboards* app was opened on a mobile device, an error could occur when you entered something in the search box.

#### Dashboards app & Low-code apps - Form component: Problems with multiple-selection drop-down boxes [ID_35829]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When a form component contained multiple-selection drop-down boxes, it would load too slowly due to the drop-down box change detection being triggered over and over again. From now on, form components containing multiple-selection drop-down boxes will load considerably quicker.

Also, when a multiple-selection drop-down field of a DOM instance was added to a form component, the current values preloaded into the field as placeholders would incorrectly not get removed once the data was loaded, causing the drop-down field to contain duplicate values.

#### Dashboards app: A table component could appear to be empty when you rapidly switched between visualizations [ID_35831]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, a table component could appear to be empty when you rapidly switched between visualizations.

Also, an error could be thrown when you tried to add an invalid query to a component.

#### Web apps: Problem when opening a visual overview [ID_35841]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

When you opened a visual overview in a web app, in some cases, the web app could become unresponsive.

#### Dashboards app: Problem when an extra GetParameterTable call without ValueFilters was sent after sharing a dashboard with a state, ring or gauge component [ID_35844]

<!-- MR 10.4.0 - FR 10.3.5 -->

When a dashboard with a state, ring or gauge component was shared, in some cases, an error could be thrown when an extra `GetParameterTable` call without `ValueFilters` was sent.

#### Dashboards app & Low-code apps: Text boxes in the Layout tab would not update when you selected another component [ID_35851]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in the *Layout* tab, a text box (e.g. the box containing the title of the selected component) had the focus, and you selected another component, the text box in the *Layout* tab would incorrectly still contain the value of the previously selected component.

#### Dashboards app & Low-code apps - Table component: A collapsed group would incorrectly expand when new data was loaded into the table [ID_35856]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in a table component, the data was grouped by two different parameters, in some cases, a collapsed group would incorrectly expand when new data was loaded into the table.

#### Dashboards app: Problem when selecting a parameter in a parameter feed component of a shared dashboard [ID_35863]

<!-- MR 10.4.0 - FR 10.3.5 -->

When you selected a parameter in a parameter feed component of a shared dashboard, in some cases, an error could occur.

#### Dashboards app: Multiple parameter feeds would incorrectly have their 'group by' reset when a PDF was generated [ID_35866]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

When you generated a PDF of a dashboard that contained multiple parameter feeds, a multiple parameter feed with a "group by" applied would incorrectly have that "group by" reset to the value that was configured in its settings.

#### Web apps: Certain icons would incorrectly not be displayed [ID_35877]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In web apps, certain icons would incorrectly not be displayed.

#### Dashboards app & Low-code apps - Table component: Initial grouping would incorrectly be considered a modification [ID_35882]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

In a table component, the initial grouping would incorrectly be considered a modification. As a result, the *Restore initial view* button would appear in the component header. When you then clicked that button, the grouping would be removed.

From now on, the initial grouping will no longer be considered a modification. When you modify the table by sorting, filtering, grouping or re-ordering data and then click the *Restore initial view* button, the initial grouping will now be restored.

#### Dashboards app & Low-code apps - Table component: Issues with 'Loading' indicator [ID_35894]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

A number of issues with regard to the "Loading" indicator have been fixed.

#### Dashboards app & Low-code apps - GQI components: Problems when a GQI request failed [ID_35904]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a GQI request failed, some GQI components would show either an unrelated error or no error at all, while other GQI components would show a correct error but incorrect data.

#### Web apps: Login button would incorrectly be disabled on Edge and Chrome [ID_35906]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, in some cases, the login button would incorrectly be disabled when you opened a web app in Microsoft Edge or Google Chrome.

#### Dashboards app & Low-code apps - Clock components: Clock time would not update when set to server time [ID_35912]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a clock component (analog or digital) was set to use server time, the clock time would not update.

#### Low-code apps: Problem when selecting an action with multiple components after having selected an action with a single component [ID_35947]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When you first selected an action with a single component, which was selected automatically, and then selected an action with multiple components, up to now, both the action selection box and the component selection box would incorrectly be cleared.

#### Low-code apps: Page names and panel names could incorrectly be empty [ID_35960]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Up to now, page names and panel names could incorrectly be empty. From now on, this will no longer be allowed.
