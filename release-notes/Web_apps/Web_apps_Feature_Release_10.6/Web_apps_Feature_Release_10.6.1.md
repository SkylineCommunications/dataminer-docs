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

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards/Low-Code Apps - Line & area chart component: Exporting trend data of aggregation parameters is now supported [ID 43939]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a Line & area chart component was displaying trend data of aggregation parameters, up to now, it was not possible to export that trend data to a CSV file. Exporting that data is now supported.

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
