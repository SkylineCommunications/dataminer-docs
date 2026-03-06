---
uid: Web_apps_Feature_Release_10.6.5
---

# DataMiner web apps Feature Release 10.6.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU2].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.5](xref:General_Feature_Release_10.6.5).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.5](xref:Cube_Feature_Release_10.6.5).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

#### GQI DxM: Query version will no longer be linked to the DxM version [ID 44719]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a query was created, the version of that query would be linked to the current version of the GQI DxM. As a result, queries would be migrated each time the minor or major version of the GQI DxM was increased, even when nothing had been changed to the query logic.

From now on, the query version will no longer be linked to the version of the GQI DxM. Queries will only be migrated when they were altered in such a way that it prevents them from being run in their current form.

#### DataMiner web apps updated to Angular 20 [ID 44794]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

The DataMiner web apps that use Angular (e.g., Low-Code Apps, Dashboards, Monitoring, etc.) now use Angular 20.

#### GQI DxM has been upgraded to Microsoft .NET 10 [ID 44800]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

The GQI DxM has been upgraded to Microsoft .NET 10. It no longer requires the .NET 8 runtime.

#### Low-Code Apps: Enhanced performance when entering text in a text box that supports highlighting [ID 44888]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Because of a number of enhancements, overall performance has increased when entering text in a text box that supports highlighting.

Up to now, when you pasted a large piece of formatted text in such a text box, in some cases, the browser could freeze for a while.

> [!NOTE]
> When you set a *Web* component to "Custom HTML", the *HTML* box is limited to 100,000 characters. Up to now, HTML syntax highlighting would be disabled from 15,000 characters onwards. From now on, this 15,000-character limit will no longer apply.

### Fixes

#### GQI DxM: 'Get profile instances' and 'Get trend data' data sources would incorrectly format parameters using invariant culture [ID 44857]

<!-- MR 10.7.0 - FR 10.6.5 -->

Up to now, the *Get profile instances* and *Get trend data* data sources would format the display values of DataMiner parameters using invariant culture and would show inconsistent group separators.

From now on, all data sources will format the display values for DataMiner parameters consistently using the culture of the user and will also use the group separator defined in that culture.

#### Dashboards/Low-Code Apps - Table component: Data fed to another component would not get updated during a refetch [ID 44871]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When the data in a *Table* component was fed to another component, up to now, the data in that other component would incorrectly not get updated while the data in the *Table* component was being refetched.

Also, in the different GQI components (i.e., *Table*, *Grid*, *Node edge graph*, *Timeline*, and *Maps*), a number of inconsistencies have been fixed with regard to selection behavior during a refetch.

#### Dashboards/Low-Code Apps - Query builder: Problem when inserting a node before a Join operator [ID 44883]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, in the query builder, you inserted a node (for example a filter) before a *Join* operator, up to now, some of the node's options (such as column selection, filter method, and value) would incorrectly not appear. As a result, it would not be possible to completely configure the node.

#### Dashboards/Low-Code Apps - Query filter component: Problem when opening the operator selection box [ID 44918]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, in a *Query filter* component, you opened the operator selection box in order to select "equals", "contains", or "match regex", in some cases, part of that selection box would incorrectly not be displayed.

#### Low-Code Apps: 'On open' event would incorrectly not be able to consume data provided by the URL [ID 44923]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In some cases, an *On open* event configured in a low-code app would incorrectly not be able to consume data provided by the URL.

#### Dashboards/Low-Code Apps - GQI components: Problem when data from another component changed rapidly [ID 44934]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, in a GQI component (e.g., *Grid*, *Table*, *Timeline*, etc.), a query was filtered by data from another component, in some cases, the filtering would not be reflected in the UI when the data from the other component changed rapidly.
