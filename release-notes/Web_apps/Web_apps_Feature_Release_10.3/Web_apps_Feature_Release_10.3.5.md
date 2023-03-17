---
uid: Web_apps_Feature_Release_10.3.5
---

# DataMiner web apps Feature Release 10.3.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.4](xref:General_Feature_Release_10.3.5).

## Highlights

#### BREAKING CHANGE: One single authentication app for all web apps [ID_35772]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, every web app had its own login screen and its own way of authenticating users. When using external authentication via SAML, this meant that, for every web app, a separate `AssertionConsumerService` element had to be added to the `spMetadata.xml` file.

A new dedicated authentication app has now been created. This app will be used by all current and future DataMiner web apps.

When using external authentication via SAML, this means that all existing `AssertionConsumerService` elements specified in the `spMetadata.xml` file can now be replaced by one single element. See the example below.

```xml
<md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/API/" index="1" isDefault="false"/>
```

`https://dataminer.example.com` has to be replaced with the IP address or the DNS name of your DataMiner System. Make sure the endpoint address in the `Location` attribute match the DataMiner application endpoint you specified when you registered DataMiner with the identity provider. The way you configure this will depend on the identity provider you are using.

Also, when using external authentication via SAML, the `<system.webServer>` element of the `C:\Skyline DataMiner\Webpages\API\Web.config` file has to contain the following:

```xml
<defaultDocument>
   <files>
      <add value="default.aspx" />
   </files>
</defaultDocument>
```

> [!NOTE]
> When using external authentication via SAML, DataMiner should be configured to use HTTPS.

## Other new features

#### Monitoring app - Histograms: Time range buttons [ID_35733]

<!-- MR 10.4.0 - FR 10.3.5 -->

In the *Monitoring* app, histograms now have a number of time range buttons that allow you to quickly select one of the following preset time ranges:

- 1d (last 24 hours)
- 1w (last 7 days)
- 1m (last 30 days)
- 1y (last year)
- 5y (last 5 years)

#### Dashboards app & Low-code apps: New 'Text' feed [ID_35902]

<!-- MR 10.4.0 - FR 10.3.5 -->

The new *Text* feed is a text box that exposes the entered text as a string feed that can currently be consumed by GQI queries and script parameters in low-code app actions.

When configuring this new *Text* feed, you can optionally specify a label, an icon and a placeholder. You can also indicate whether the text box should allow multiple lines of texts and whether it should feed its value when triggered by the following events:

- On Enter
- On Focus lost
- On Value change

Currently, the *On Focus lost* event will also be triggered when you press the ENTER key.

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

#### Web apps - Query builder: Query node options with only a single value will no longer be displayed in a selection box [ID_35865]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In the query builder, from now on, when a query node option only has a single value, that option will no longer be displayed in a selection box.

For example, up to now, when you selected the *Get elements* data source, followed by the *Aggregate* operator, the method selection box would display "Get the". This will no longer be the case.

### Fixes

#### Web apps: Problem with external authentication [ID_33405]

<!-- MR 10.4.0 - FR 10.3.5 -->

In some cases, it would not be possible to log in to a web app (e.g. Dashboards, Monitoring, Jobs, etc.) using external authentication.

#### Dashboards app & Low-code apps - GQI components: Problem when executing an empty query [ID_35803]

<!-- MR 10.4.0 - FR 10.3.5 -->

When GQI components tried to execute an empty query, up to now, they would keep on showing a "loading" indicator. From now on, an appropriate message will be displayed instead.

#### Dashboards app & Low-code apps: Duplicated component would not have the size as the original [ID_35804]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When you duplicated a component, the size of the duplicate would incorrectly be limited to 30 rows. From now on, when you duplicate a component, the duplicate will have the same size as the original.

#### Dashboards app & Low-code apps: Problem when feeding data from a GQI component to a query used in the same component [ID_35806]

<!-- MR 10.4.0 - FR 10.3.5 -->

An error could occur when feeding data from a GQI component to a query that was used in the same component.

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

#### Dashboards app & Low-code apps: Text boxes in the Layout tab would not update when you selected another component [ID_35851]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in the *Layout* tab, a text box (e.g. the box containing the title of the selected component) had the focus, and you selected another component, the text box in the *Layout* tab would incorrectly still contain the value of the previously selected component.

#### Dashboards app & Low-code apps - Table component: A collapsed group would incorrectly expand when new data was loaded into the table [ID_35856]

<!-- MR 10.4.0 - FR 10.3.5 -->

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
