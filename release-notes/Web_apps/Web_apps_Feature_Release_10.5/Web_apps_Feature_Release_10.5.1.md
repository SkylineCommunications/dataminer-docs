---
uid: Web_apps_Feature_Release_10.5.1
---

# DataMiner web apps Feature Release 10.5.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.5.1](xref:General_Feature_Release_10.5.1).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Dashboards/Low-Code Apps - Web component: Default margin would incorrectly no longer be 0px when showing custom HTML [ID 41241]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU1] - FR 10.5.1 -->

The default margin of a *Web* component in which *Type* was set to "Custom HTML" would incorrectly no longer be 0px. This would cause scrollbars to appear.

#### Dashboards/Low-Code Apps - Alarm table component: Time filter would be disregarded when fetching history alarms [ID 41249]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU1] - FR 10.5.1 -->

When an *Alarm table* component was configured to retrieve history alarms, it would incorrectly always retrieve all history alarms from the database, regardless of what was specified in the time filter.
