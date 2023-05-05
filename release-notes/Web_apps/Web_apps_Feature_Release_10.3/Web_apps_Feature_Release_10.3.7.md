---
uid: Web_apps_Feature_Release_10.3.7
---

# DataMiner web apps Feature Release 10.3.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.7](xref:General_Feature_Release_10.3.7).

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No other features yet*

## Changes

### Enhancements

*No enhancements yet*

### Fixes

#### Dashboards app & Low-Code Apps - Line chart: X and Y axis labels would not show the correct text [ID_35943]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The X and Y axis labels of a line chart would not show the correct text when the data was grouped.

#### Dashboards app & Low-Code Apps - Query builder: Select nodes would incorrectly not show the selected columns [ID_36251]

<!-- MR 10.4.0 - FR 10.3.7 -->

In the query builder, when a *Select* node was not in edit mode, its description would incorrectly not show the selected columns.

#### Dashboards app & Low-Code Apps: State component would incorrectly not be cleared when its input feed was cleared [ID_36261]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, a *State* component would incorrectly not be cleared when its input feed was cleared.

#### Low-Code Apps: Table actions would incorrectly be executed before the rows were fed [ID_36263]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, table actions would be executed before the rows were fed. As a result, the feed would get lost when you navigated away from the page via an action. From now on, a row will always be fed before row actions are executed.

#### Dashboards app: Height of 'DATA USED IN DASHBOARD' section would incorrectly change after collapsing and expanding it [ID_36282]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you collapsed and expanded the *DATA USED IN DASHBOARD* section of the *DATA* tab, in some cases, the height of that section would incorrectly change.
