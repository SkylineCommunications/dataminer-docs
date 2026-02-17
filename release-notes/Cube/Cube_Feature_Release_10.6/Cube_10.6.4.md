---
uid: Cube_Feature_Release_10.6.4
---

# DataMiner Cube Feature Release 10.6.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.5.0 [CU13].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.4](xref:General_Feature_Release_10.6.4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.4](xref:Web_apps_Feature_Release_10.6.4).

## Highlights

*No highlights have been selected yet.*

## New features

#### System Center - Analytics config: New 'Suggestion limit' setting added to 'Behavioral Anomaly Detection' section [ID 44709]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

On the *Analytics config* page, located in the *System settings* section of *System Center*, a new *Suggestion limit* setting has been added to the *Behavioral Anomaly Detection* section.

This setting will allow administrators to cap the number of active suggestion events per behavioral change type.

## Changes

### Enhancements

#### Enhanced performance when loading aggregation trending [ID 44589]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Because of a number of enhancements, overall performance has increased when loading aggregation trending.

#### Enhanced search box consistency throughout DataMiner Cube [ID 44658]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

Certain search boxes in used in the ListView component as well as the Automation, Correlation, and Spectrum Analysis modules would not behave like other search boxes in DataMiner Cube. The list with suggestions and the filtered list would incorrectly be generated simultaneously.

From now on, the search boxes in the above-mentioned modules will act in a way that is similar to other search boxes in DataMiner Cube. The list with suggestions will be displayed first, and the filtered list will be displayed a second after you stopped typing in the search box.

#### Sidebar: Labels of 'Catalog', 'Cloud Admin', and 'Data Sources' modules will now also be translated [ID 44733]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

If you view the Cube UI in one of the supported languages other than English, in the sidebar, the labels of the following modules will now also be translated to the selected language:

- Catalog
- Cloud Admin
- Data Sources

#### System Center - Agents: 'Element Migration' window will now also filter out elements that are part of a redundancy group [ID 44773]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When, in the *Agents* section of *System Center*, you clicked *Migrate*, up to now, the *Element Migration* window would incorrectly not check whether an element was part of a redundancy group. From now on, all elements that are part of a redundancy group as either a primary element, backup element, or state element will automatically be filtered out.

### Fixes

#### Problem with icons of apps pinned to the sidebar [ID 44693]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some cases, when an app was pinned to the sidebar, two instances of that app's icon would incorrectly be displayed one on top of the other.
