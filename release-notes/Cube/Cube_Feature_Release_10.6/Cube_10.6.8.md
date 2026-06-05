---
uid: Cube_Feature_Release_10.6.8
---

# DataMiner Cube Feature Release 10.6.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU5].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.8](xref:General_Feature_Release_10.6.8).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.8](xref:Web_apps_Feature_Release_10.6.8).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Cube will now use optimized requests to manage service template definitions stored in the new C:\\Skyline DataMiner\\ServiceTemplates folder [ID 45536]

<!-- MR 10.7.0 - FR 10.6.7 -->

Since DataMiner feature version 10.6.7, service template definitions are stored in the `C:\Skyline DataMiner\ServiceTemplates` folder instead of the `C:\Skyline DataMiner\Services` and `C:\Skyline DataMiner\RemoteServices` folders.

DataMiner Cube will now use optimized requests to manage the service template definitions in this new location.

#### Correlation: Grouping method 'By alarm' has been removed [ID 45545]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

While editing a correlation rule, in the *Alarm grouping* section, you can indicate how you want the alarms to be grouped before they are evaluated.

The option "by alarm" has now been removed.

If existing correlation rules have this option configured, a warning will be shown, explaining that this is no longer supported, the *Alarm grouping* section will be empty, and the grouping will be removed the first time the rule is saved again.

### Fixes

#### Data Display: Problem when resetting the layout of a table [ID 45277]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When the layout of a table was reset in Data Display, up to now, the table column widths would incorrectly not be reset to the values specified in the element connector.

#### Visual Overview: No message would appear when the maximum number of child shapes in a Children container shape was reached [ID 45524]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When the number of child shapes in a *Children* container shape reached the limit specified in the *Maximum number of child shapes in a Children container shape* user setting, up to now, the shape and the page would keep loading. No message would appear explaining that the child shape limit was reached.

From now on, users will get a message informing them that the child shape limit was reached and that not all shapes are being displayed.

#### Connection issues caused by culture-specific uppercase conversion of URL arguments [ID 45652]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When you connected to a local DataMiner Agent or a DaaS Agent via the DataMiner Cube desktop app, up to now, the URL arguments would be converted to uppercase using culture-specific rules. In some cases, this could result in incorrect character transformations and connection issues.

From now on, the URL arguments will be converted to uppercase using culture-invariant rules, which will ensure consistent and correct behavior across system cultures.
