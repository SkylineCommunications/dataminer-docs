---
uid: Web_apps_Feature_Release_10.3.5
---

# DataMiner web apps Feature Release 10.3.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.4](xref:General_Feature_Release_10.3.5).

## Highlights

*No highlights have been selected for this release yet*

## Other new features

#### Monitoring app - Histograms: Time range buttons [ID_35733]

<!-- MR 10.4.0 - FR 10.3.5 -->

In the *Monitoring* app, histograms now have a number of time range buttons that allow you to quickly select one of the following preset time ranges:

- 1d (last 24 hours)
- 1w (last 7 days)
- 1m (last 30 days)
- 1y (last year)
- 5y (last 5 years)

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

### Fixes

#### Dashboards app & Low-code apps: Duplicated component would not have the size as the original [ID_35804]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When you duplicated a component, the size of the duplicate would incorrectly be limited to 30 rows. From now on, when you duplicate a component, the duplicate will have the same size as the original.

#### Dashboards app & Low-code apps: Problem when feeding data from a GQI component to a query used in the same component [ID_35806]

<!-- MR 10.4.0 - FR 10.3.5 -->

An error could occur when feeding data from a GQI component to a query that was used in the same component.

#### Dashboards app & Low-code apps - Form component: Problems with multiple-selection drop-down boxes [ID_35829]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When a form component contained multiple-selection drop-down boxes, it would load too slowly due to the drop-down box change detection being triggered over and over again. From now on, form components containing multiple-selection drop-down boxes will load considerably quicker.

Also, when a multiple-selection drop-down field of a DOM instance was added to a form component, the current values preloaded into the field as placeholders would incorrectly not get removed once the data was loaded, causing the drop-down field to contain duplicate values.

#### Dashboards app: A table component could appear to be empty when you rapidly switched between visualizations [ID_35831]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

In some cases, a table component could appear to be empty when you rapidly switched between visualizations.

Also, an error could be thrown when you tried to add an invalid query to a component.

#### Dashboards app & Low-code apps: Text boxes in the Layout tab would not update when you selected another component [ID_35851]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in the *Layout* tab, a text box (e.g. the box containing the title of the selected component) had the focus, and you selected another component, the text box in the *Layout* tab would incorrectly still contain the value of the previously selected component.
