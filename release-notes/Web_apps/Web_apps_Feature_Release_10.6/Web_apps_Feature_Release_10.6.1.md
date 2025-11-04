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

## Changes

### Enhancements

#### Dashboards/Low-Code Apps - Line & area chart component: Exporting trend data of aggregation parameters is now supported [ID 43939]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a Line & area chart component was displaying trend data of aggregation parameters, up to now, it was not possible to export that trend data to a CSV file. Exporting that data is now supported.

#### Dashboards app: Enhanced error handling when generating PDF reports [ID 44019]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Because of a number of enhancements, error handling has improved when generating PDF reports.

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

#### DataMiner landing page: Problem when 'Show draft applications' option was enabled [ID 44027]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When, on the DataMiner landing page (by default accessible via `https://<DMA IP or hostname>/root`), the *Show draft applications* option was enabled, up to now, you would always be directed to the draft version of an app (if a draft version existed), even when you did not have permission to edit the app. When you did not have edit permission, an HTTP 403 error would appear.

From now on, when you do not have edit permission, the "Draft" label will be hidden, and you will be directed to the last published version of the app.

#### Dashboards/Low-Code Apps - Form component: Error messages would unexpectedly disappear [ID 44029]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when an error message appeared in a Form component, that message would unexpectedly disappear.

From now on, when an error message appears, it will stay visible until an action is performed in the Form component or until a button is clicked.
