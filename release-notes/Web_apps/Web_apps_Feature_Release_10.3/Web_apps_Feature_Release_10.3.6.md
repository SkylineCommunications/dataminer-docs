---
uid: Web_apps_Feature_Release_10.3.6
---

# DataMiner web apps Feature Release 10.3.6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.6](xref:General_Feature_Release_10.3.6).

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

## Other features

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

#### Low-Code Apps: Duplicating pages and panels is now possible via new context menu [ID_36097]

<!-- MR 10.4.0 - FR 10.3.6 -->

When editing a low-code app, it is now possible to duplicate an entire page or panel via the new context menu, accessible by clicking the ellipsis icon next to the page name in the pane on the left or the panel name in the page configuration pane. This context menu also allows you to delete a page or panel, as well as hide a page from the sidebar.

## Changes

### Enhancements

#### Legacy reports and dashboards will no longer be prefetched if the soft-launch option 'LegacyReportsAndDashboards' is set to false [ID_35881]

<!-- MR 10.3.0 [CU4] - FR 10.3.6 -->

From now on, legacy reports and dashboards will no longer be prefetched if the soft-launch option *LegacyReportsAndDashboards* is set to false.

#### Clearer error will be thrown when an inter-element query failed to retrieve a parameter value of a specific element [ID_35972]

<!-- MR 10.4.0 - FR 10.3.6 -->

When an inter-element query failed to retrieve a parameter value of a specific element, up to now, a generic `Unknown element` error would be thrown. From now on, a clearer error mentioning the element that caused the issue will be thrown instead.

#### DataMiner web apps: Angular and other dependencies have been upgraded [ID_36100]

<!-- MR 10.4.0 - FR 10.3.6 -->

In all web apps (e.g. Low-Code Apps, Dashboards, Monitoring, Jobs, Ticketing, etc.), Angular and other dependencies have been upgraded.

#### Dashboards app - GQI: Clearer error message will now appear when ModelHost is not running [ID_36155]

<!-- MR 10.4.0 - FR 10.3.6 -->

When the *Get parameter relations* data source is queried while the *ModelHost* DxM is not running, an error message will appear. That error message has now been made clearer.

#### Dashboards app & Low-Code Apps: Web component now supports hyperlinks with a target attribute [ID_36159]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

A web component now supports hyperlinks with a target attribute.

Example: `<a href="http://www.skyline.be" target="_blank">Skyline Communications</a>`

#### Web services API: Multi-value DOM fields will now list all their values [ID_36190]

<!-- MR 10.4.0 - FR 10.3.6 -->

Up to now, in e.g. low-code apps, multi-value DOM fields would only show a summary of the values they contained. From now on, they will list all values instead.

> [!NOTE]
> When a multi-value DOM field contains invalid values, it will no longer list them. Instead, they will be added to the error message.

### Fixes

#### Interactive Automation scripts: Problems with datetime component [ID_35682]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When an interactive Automation script was launched from a web app, the following issues could occur. These were all related to the datetime web component (*UIBlockType.Time*):

- When you clicked a date in the datetime picker, a changed value would already be returned to the script. From now on, the selected datetime value will not be returned to the script until you close the picker (either by double-clicking or by clicking *Done*).

- The datetime value that was returned to the script when the component lost focus could be incorrect.

- The focus loss detection would not always be accurate.

#### Dashboards app & Low-Code Apps - Table component: Selection issues [ID_35968]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When a GQI table was configured to feed the selected rows to another component, the following issues could occur:

- When you selected a row above a row that had been selected earlier, that row would not get fed.

- When you tried to select multiple rows using SHIFT+Click, this would not work when you selected the rows bottom to top.

- When you selected a single row that was already selected as part of a multiple select, the feed would not be updated.

- When you exported the selected rows to a CSV file, the CSV file would incorrectly contain all rows instead of only the ones you had selected.

#### Dashboards app & Low-Code Apps - Table component: Minimum pagesize would be used when exporting to a CSV file [ID_36012]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When exporting data from a table component to a CSV file, the minimum pagesize would be used. From now, the largest possible pagesize is used when exporting data from a table component to a CSV file.

#### Dashboards app & Low-Code Apps: Component title could be made too large [ID_36021]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In a custom component theme, for some fonts, the font size of the title could be set to a value higher than 36px, causing the component title to be larger than its container. Also, in some cases, the font size could incorrectly be set to 0px.

From now on, font sizes will have to be set to a value between 1px and 36px.

#### Dashboards app: Error when opening a shared dashboard containing a 'Line & area chart' component, a 'State' component, a 'Gauge' component or a 'Ring' component [ID_36022]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

An error could occur when you opened a shared dashboard that contained a *Line & area chart* component, a *State* component, a *Gauge* component or a *Ring* component.

#### Dashboards app: Retry button of table component would incorrectly be displayed in PDF file [ID_36026]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When you generated a PDF of a dashboard that contained a table component showing a *Retry* button (because of an error in the table), then that *Retry* button would incorrectly also be displayed in the PDF file.

#### Dashboards app: Invalid nodes could get added to a GQI query [ID_36045]

<!-- MR 10.4.0 - FR 10.3.6 -->

In some cases, invalid nodes could get added to a GQI query, causing run-time errors to be thrown.

#### Dashboards app & Low-Code Apps: Clearing a State component by means of CTRL+Click [ID_36056]

<!-- MR 10.4.0 - FR 10.3.6 -->

You can now clear a *State* component by clicking it while holding down the CTRL key.

#### Dashboards app & Low-Code Apps: GQI query nodes without options would incorrectly be expanded [ID_36064]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In some cases, GQI query nodes without options would incorrectly be expanded.

#### Dashboards app: Problem when a 'State' component was fed a parameter value by a drop-down component in a shared dashboard [ID_36075]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In a shared dashboard, an error could occur when a *State* component was fed a parameter value by a drop-down component.

#### Dashboards app & Low-Code Apps: GQI table component could throw 'Paged table session not found' error [ID_36101]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In some cases, a GQI table component could thrown the following error:

```txt
Error trapped: Paged table session not found
```

From now on, a table session will immediately be closed after the last page has been fetched. This will prevent the above-mentioned error from being thrown.

#### Dashboards app: Error when opening a shared dashboard containing a 'Parameter Page' component [ID_36103]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

An error could occur when you opened a shared dashboard that contained a *Parameter Page* component.

#### Low-Code Apps: Problem when updating header titles [ID_36116]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When, while editing a low-code app with more than one header bar option, you selected another header bar option, the label of the previously selected header bar option would incorrectly still be displayed in the side panel.

#### Dashboards app & Low-Code Apps: Problem when searching elements of which the name contained special characters [ID_36128]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When, while editing a dashboard, you opened the *ELEMENTS* section in the *DATA* tab, and entered an element name containing special characters in the search box, the result set would always be empty, even if elements with that name existed.

#### Dashboards app & Low-Code Apps: Popup panel showing a PDF preview would incorrectly have a scroll bar [ID_36131]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, the popup panel showing the PDF preview of a dashboard would incorrectly have a scroll bar.

From now on, a popup panel showing a PDF preview will take the full screen height and will only allow its contents to scroll.

#### Dashboards app & Low-Code Apps - 'Numeric input' feed: Setting renamed [ID_36166]

<!-- MR 10.4.0 - FR 10.3.6 -->
<!-- Not added to MR 10.4.0 -->

The *Numeric input* feed, which was introduced in DataMiner feature release 10.3.5, had a setting named *Amount of decimals*.

This setting has now been renamed to *Number of decimals*.

#### Dashboards app: Problem when sharing a dashboard that contained an alarm table component [ID_36178]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When you shared a dashboard that contained an alarm table component, in some cases, a `Not Authorized` error could be thrown.

#### Dashboards app: Order of parameters in State component of shared dashboard was incorrect [ID_36206]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When you viewed a shared dashboard that contained a *State* component, in some cases, the order of the parameters in that *State* component would be incorrectly.

#### Low-Code Apps: Action buttons could have an incorrect background color [ID_36258]

<!-- MR 10.3.0 [CU4] - FR 10.3.6 -->

In some cases, action buttons could have an incorrect background color.

#### Dashboards app & Monitoring app: Spectrum components would get stuck when loading [ID_36364]

<!-- MR 10.4.0 - FR 10.3.6 [CU0] -->

In the Dashboards app and the Monitoring app, spectrum components would get stuck when loading due to a WebSocket communication problem.
