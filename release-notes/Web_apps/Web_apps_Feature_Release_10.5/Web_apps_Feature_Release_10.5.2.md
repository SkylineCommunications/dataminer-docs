---
uid: Web_apps_Feature_Release_10.5.2
---

# DataMiner web apps Feature Release 10.5.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.2](xref:General_Feature_Release_10.5.2).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.2](xref:Cube_Feature_Release_10.5.2).

## Highlights

*No highlights have been selected yet.*

## New features

## Changes

### Enhancements

#### Web apps: Angular and other dependencies have been upgraded [ID 41488]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In all web apps (e.g. Low-Code Apps, Dashboards, Monitoring, etc.), Angular and other dependencies have been upgraded.

### Fixes

#### Dashboards/Low-Code Apps - Timeline component: Boundaries of the vertical timeline sections would not be correct [ID 41514]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some cases, the boundaries of the vertical timeline sections would not be correct. For example, one-month sections would not start on the first day of the month.

#### Dashboards app: Dashboard lists would incorrectly not be shown on mobile devices [ID 41548]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you opened the Dashboards app on a mobile device, none of the following dashboard lists would be shown:

- Overview
- Recent
- Private
- Shared
