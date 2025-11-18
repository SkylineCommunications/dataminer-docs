---
uid: Web_apps_Feature_Release_10.6.1
---

# DataMiner web apps Feature Release 10.6.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU22] and 10.5.0 [CU10].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.1](xref:General_Feature_Release_10.6.1).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.1](xref:Cube_Feature_Release_10.6.1).

## Highlights

*No highlights have been selected yet.*

## New features

#### Dashboard reports can now be generated in PDF, HTML, and/or CSV format [ID 43888]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, a report of a dashboard could only be generated in PDF format (.pdf). Now, it is possible to generate a report in PDF, archived HTML format (.mhtml) and/or CSV format.

MHTML files include all necessary information to allow the report to be rendered in a web browser: HTML code, images, CSS stylesheets, etc.

Also, the default file name has been changed from `Report.pdf` to `<dashboard name>.pdf`, `<dashboard name>.mhtml`, or `<dashboard name>.csv.zip`.

> [!IMPORTANT]
> This feature will only work in conjunction with DataMiner server version 10.6.0/10.6.1 or newer.

#### Dashboards app: Private dashboards can now also be shared via cloud share [ID 44067]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, it was only possible to share public dashboards via cloud share. From now on, it will also be possible to share private dashboards via cloud share.

## Changes

### Enhancements

#### Dashboards/Low-Code Apps - Line & area chart component: Exporting trend data of aggregation parameters is now supported [ID 43939]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a Line & area chart component was displaying trend data of aggregation parameters, up to now, it was not possible to export that trend data to a CSV file. Exporting that data is now supported.

#### Low-Code Apps - Form component: Clearer error will now appear when a DOM instance contains an incorrect value for a DomInstanceFieldDescriptor or DomInstanceValueFieldDescriptor [ID 44017]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When, in a low-code app, a DOM instance contained an invalid value for a DomInstanceFieldDescriptor or DomInstanceValueFieldDescriptor, up to now, a `The item no longer exists` error message would appear on top of the field in question. This error message has now been changed to `Instance was not found`.

When relevant, this error message will also mention that one or more DOM definition IDs are invalid.

#### Dashboards app: Enhanced error handling when generating PDF reports [ID 44019]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Because of a number of enhancements, error handling has improved when generating PDF reports.

#### Dashboards/Low-Code Apps: DataMiner Copilot renamed to DataMiner Assistant [ID 44028]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In the Dashboards app and all low-code apps, the name *DataMiner Copilot* has now been replaced by *DataMiner Assistant*.

#### Dashboards/Low-Code Apps - Form component: Datetime values displayed in the same way as in the Table Component [ID 44039]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

On *Form* components, datetime values will now be displayed in the same way as in *Table* components.

The datetime format is based on the regional settings of the web browser. If a browser is set to e.g. "English (US)", datetime values will be displayed as "12/31/2029 8:00 PM".

#### Low-Code Apps - Templates: Preset table component template [ID 44040]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When, in a low-code app, you click the *Browse templates* button while editing a component that uses templates, a preset table component template will now appear in the list of templates.

When you apply that preset template in a component that uses templates, you can then configure it further using the template editor.

> [!NOTE]
> This preset template will only be available in low-code apps, not in dashboards.

#### Dashboards/Low-Code Apps: Enhanced visibility of query buttons in the edit pane [ID 44048]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when you selected a query in the edit pane, the color of the query button would not get properly adapted to the color of the background, causing visibility issues.

From now on, these query buttons will clearly be visible, whatever the color of the background.

#### Jobs app is End of Life [ID 44052]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

The Jobs app has been declared End of Life. On systems running DataMiner main server version 10.6.0 or higher as well as on all systems using STaaS, it will no longer appear on the DataMiner landing page.

#### DataMiner web applications will now by default use GQI DxM for GQI-related operations [ID 44058]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, by default, DataMiner web applications used the SLHelper process for GQI-related operations. From now on, they will by default use the GQI DxM instead.

If you want the web applications to continue to use the SLHelper process for GQI-related operations, you will have to set the `gqi:useDxM` key to false in the `C:\Skyline DataMiner\Webpages\API\Web.config` file. See the following example.

```xml
<appSettings>
    <add key="gqi:useDxM" value="false" />
</appSettings>
```

#### Interactive Automation scripts: UI version will now be set to WebUIVersion.V2 by default [ID 44059]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When connected to a DataMiner Agent with main release version 10.6.0 or feature release 10.5.12 (or above), from now on, interactive Automation scripts executed in a web app will use the new UI version (V2) by default.

This also means that, when you set `engine.WebUIVersion` to `WebUIVersion.Default` in a script, the UI version will now be set to the new UI version (V2).

Note that, if you still want to use UI version V1 instead, you can set `engine.WebUIVersion` to `WebUIVersion.V1`. See the example below.

```csharp
engine.WebUIVersion = WebUIVersion.V1
```

#### Web apps: Apps menu item 'dataminer.services' will only appear when the DMA is connected to the cloud [ID 44104]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when you opened the Apps menu of a web app (e.g. the Monitoring app), the top-most item would be a link to dataminer.services.

From now on, that link will only appear in the Apps menu of a web app when the DataMiner Agent is connected to the cloud.

#### Low-Code Apps: Enhanced performance [ID 44114]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Because of a number of enhancements, overall performance of low-code apps has increased.

### Fixes

#### Visual Overview in web apps: Children shapes would incorrectly be displayed on top of a clickable group of shapes [ID 43465]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] - FR 10.6.1 -->

In DataMiner Cube, when a visual overview contains a clickable group of shapes that is linked to e.g. an element, that clickable group will always be displayed on top of other shapes (e.g. *Children* shapes).

Up to now, a visual overview in a web app would behave differently. *Children* shapes would incorrectly be displayed on top of the clickable group, causing that group to not be clickable.

From now on, a visual overview in a web app will behave in the same way as a visual overview in DataMiner Cube.

#### Dashboards/Low-Code Apps - Alarm table component: Fetching alarm table data could time out [ID 43986]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In some cases, fetching the data to be displayed in an Alarm table component could time out.

From now on, the table data will be fetched asynchronously using a WebSocket.

#### Dashboards/Low-Code Apps - Node edge graph component: Selected edges would not be selected again after the graph had been refreshed [ID 43992]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When you had selected one of several edges that went in the same direction between two nodes, up to now, that edge would incorrectly not be selected again after the graph had been refreshed.

#### Dashboards/Low-Code Apps - Table component: Current selection would not immediately become visible when the browser was refreshed [ID 44003]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

After you had refreshed your browser, a Table component would correctly re-apply the current selection, but that selection would incorrectly only become visible when you hovered the mouse pointer over the dashboard or low-code app. From now on, when you refresh your browser, the current selection will immediately be visible.

#### Dashboards/Low-Code Apps - Alarm table component: Not possible to filter by the service.propertyname column [ID 44020]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In an *Alarm table* component, up to now, it would incorrectly not be possible to filter by the Alarm Console column service.*propertyname* (*propertyname* being the name of the service property). This has now been made possible.

> [!NOTE]
> Note that the following Web Services API methods, which allow filtering by service, have all been modified. Up to now, services were checked by ID. From now on, services will be checked by name:
>
> - GetAlarmPages
> - GetAlarmPagesV2
> - GetAlarmPageUpdates
> - GetAlarmPageUpdatesV2
> - GetAlarmPageWithAlarms
> - GetAlarmPageWithAlarmsV2
> - GetAlarms
> - GetAlarmsV2

#### DataMiner landing page: Problem when 'Show draft applications' option was enabled [ID 44027]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When, on the DataMiner landing page (by default accessible via `https://<DMA IP or hostname>/root`), the *Show draft applications* option was enabled, up to now, you would always be directed to the draft version of an app (if a draft version existed), even when you did not have permission to edit the app. When you did not have edit permission, an HTTP 403 error would appear.

From now on, when you do not have edit permission, the "Draft" label will be hidden, and you will be directed to the last published version of the app.

#### Dashboards/Low-Code Apps - Form component: Error messages would unexpectedly disappear [ID 44029]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when an error message appeared in a Form component, that message would unexpectedly disappear.

From now on, when an error message appears, it will stay visible until an action is performed in the Form component or until a button is clicked.

#### Interactive Automation scripts: Numeric values containing leading zeros would not update correctly [ID 44037]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In interactive Automation scripts launched from a web app, up to now, numeric values containing leading zeros would not update correctly.

#### DataMiner web apps authentication page: Problem logging in when using a Firefox browser [ID 44043]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When you had opened the DataMiner web apps authentication page in a Firefox web browser, in some cases, an error could occur when you tried to log in to a web app.

#### Dashboards/Low-Code Apps: An export to CSV could incorrect be started before the data had been loaded [ID 44064]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, in a *Line & area chart* component, it would incorrectly be possible to start an export to CSV before the data had been loaded.

From now on, an export to CSV will always be performed synchronously. In other words, even when you click *Export to CSV* before the data has been loaded, the export operation will only start when all data has been loaded.
