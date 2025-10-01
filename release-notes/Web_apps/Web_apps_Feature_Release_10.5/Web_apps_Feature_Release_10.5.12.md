---
uid: Web_apps_Feature_Release_10.5.12
---

# DataMiner web apps Feature Release 10.5.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU21] and 10.5.0 [CU9].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.12](xref:General_Feature_Release_10.5.12).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.12](xref:Cube_Feature_Release_10.5.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Dashboards/Low-Code Apps - Maps component: Clicking 'Save current view' would set the latitude to an invalid value [ID 43812]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When, in the *Layout* pane of a *Maps* component, you clicked *Save current view* after the map had been panned horizontally, in some cases, the longitude would be set to an invalid value outside the [-180,180] range.
