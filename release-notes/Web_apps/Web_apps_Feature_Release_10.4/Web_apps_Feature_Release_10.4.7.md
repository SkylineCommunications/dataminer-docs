---
uid: Web_apps_Feature_Release_10.4.7
---

# DataMiner web apps Feature Release 10.4.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.7](xref:General_Feature_Release_10.4.7).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Web apps - Visual Overview: Enhanced performance when updating a visual overview [ID_39038]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, overall performance has increased when updating a visual overview in a web app.

#### Dashboards app & Low-Code Apps: 'New' label removed from Grid and Timeline components [ID_39490]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Both the *Grid* and the *Timeline* component no longer have a "New" label.

#### Low-Code Apps: Duplicate page name check will now be case insensitive [ID_39511]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Up to now, the duplicate page name check would be case sensitive. From now on, it will be case insensitive.

Also, a case-insensitive duplicate panel name check has now been added, and leading and trailing whitespace characters in page or panel names will now be trimmed.

### Fixes

#### Dashboards app & Low-Code Apps - Maps component: 'Map type not supported' error would not be displayed [ID_39506]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When you tried to use a *Maps* component with an unsupported provider, in some cases, the `Map type not supported` error would incorrectly not be displayed. Instead, the component would stay empty.
