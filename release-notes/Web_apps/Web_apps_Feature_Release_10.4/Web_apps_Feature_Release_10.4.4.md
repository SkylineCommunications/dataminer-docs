---
uid: Web_apps_Feature_Release_10.4.4
---

# DataMiner web apps Feature Release 10.4.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.4](xref:General_Feature_Release_10.4.4).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Low-Code Apps: Delete button would not be disabled when you had clicked the button in order to delete a panel [ID_38663]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When you clicked the *Delete* button in order to delete a panel, that button would incorrectly not be disabled when the delete operation started. As a result, it was possible to click *Delete* again, causing errors to be thrown.

#### Dashboards app & Low-Code Apps - GQI: Regex node values would incorrectly be transformed [ID_38664]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When a query contained a regex node, up to now, the value of that node would incorrectly be transformed to `^(VALUE|VALUE2|VALUE3)$`.

This will no longer be the case. The value of a regex node will now have the format `VALUE1|VALUE2|VALUE3|...`.
