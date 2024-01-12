---
uid: Web_apps_Feature_Release_10.4.3
---

# DataMiner web apps Feature Release 10.4.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.3](xref:General_Feature_Release_10.4.3).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Dashboards app & Low-Code Apps - GQI: Queries would be fetched twice [ID_38335]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, a query would be fetched twice: once with old feed values filled in and once with new feed values filled in.

As the component was still in a loading state, users would only notice that it took longer for the data to appear.

#### Dashboards app & Low-Code Apps - GQI: Problem when multiple column manipulations had been configured on the same column [ID_38338]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, a query would throw an error when multiple column manipulations had been configured on the same column.

#### Dashboards app & Low-Code Apps - Generic map component: No longer possible to select a map configuration file [ID_38394]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When configuring a *Generic map* component, it would incorrectly no longer be possible to select a map configuration file.
