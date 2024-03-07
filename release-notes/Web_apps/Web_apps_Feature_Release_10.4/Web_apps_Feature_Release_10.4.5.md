---
uid: Web_apps_Feature_Release_10.4.5
---

# DataMiner web apps Feature Release 10.4.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.5](xref:General_Feature_Release_10.4.5).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards app & Low-Code Apps - Query filter component: Enhanced button coloring [ID_38754]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, the buttons in the *Query filter* component would be barely visible when the color of the app was similar to the background color of the theme. From now on, the buttons in the *Query filter* component will always have the text color of the theme.

#### Web apps: Enhanced performance when starting up [ID_38999]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner web app.

### Fixes

#### Dashboards app & Low-Code Apps - Dropdown component: Filter would no longer be applied after losing the focus [ID_38834]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a *Dropdown* component with a filter applied lost the focus, the moment it had the focus again, the filter would no longer be applied.

#### Dashboards app: Problem with Dropdown components on shared dashboards [ID_38953]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When, on a shared dashboard, a *Dropdown* component had a time range or service definition filter applied, it would not be possible to use that component.
