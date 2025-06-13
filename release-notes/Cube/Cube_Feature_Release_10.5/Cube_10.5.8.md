---
uid: Cube_Feature_Release_10.5.8
---

# DataMiner Cube Feature Release 10.5.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.8](xref:General_Feature_Release_10.5.8).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.8](xref:Web_apps_Feature_Release_10.5.8).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Trending: Enhanced performance when loading trend graphs [ID 42647]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Because of a number of enhancements, overall performance has increased when loading trend graphs.

#### Current host of an element or service is now shown in Properties window [ID 42807]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When you right-click an element or a service, and select *Properties*, the *General* tab of the *Properties* window will now also display the current host, i.e. the DataMiner Agent that is currently hosting that element or service.

#### Alarm Console: Enhanced performance when processing alarm focus information [ID 42938]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Because of a number of enhancements, overall performance has increased when processing alarm focus information.

#### Automation: An error message will now be displayed when an error occurs while importing an Automation script [ID 43069]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in the Automation module, you imported an Automation script by clicking *More > Import* or by right-clicking and selecting *Import*, errors that occurred during the import operation would not be displayed in the UI.

From now on, whenever an error occurs while importing an Automation script, a pop-up window will appear, displaying the associated error message.

### Fixes

#### Trending: Trend data between two gaps would incorrectly not be displayed [ID 42909]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In trend graphs showing gaps in the trend data, in some rare cases, the data between two gaps would incorrectly not be displayed.

#### Problem when trying to open a view card in an EPM environment [ID 43049]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In EPM environments, in some rare cases, a view card could get stuck when you tried to open it.
