---
uid: Web_apps_Feature_Release_10.4.10
---

# DataMiner web apps Feature Release 10.4.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.10](xref:General_Feature_Release_10.4.10).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards/Low-Code Apps: Queries with ad hoc data source with missing argument no longer executed [ID_40361]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When one or more required arguments for an ad hoc data source are missing because of an empty feed, the query using the data source will now no longer be executed and an empty visual will be shown. Previously, an error about the missing argument was thrown instead in this situation.

#### Sharing pop-up loader background adjusted [ID_40408]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you share a dashboard in the cloud, the loader that is shown while a new tab opens where you can configure the cloud share will now have the same background as the pop-up window containing the loader. Previously, there was a slight color difference between the loader background and the rest of the pop-up window.

### Fixes

#### Dashboards/Low-Code Apps: Intellisense no longer working when feed is configured with special character [ID_40340] [ID_40446]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When special characters such as "(" were used when configuring a feed, Intellisense no longer worked correctly.

#### Dashboards: Dashboard PDF set to A0 format generated as A4 instead [ID_40398]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you created a PDF of a dashboard, and you set the *Paper format* to A0, the dashboard was incorrectly generated in A4 format instead.

#### Low-Code Apps: Empty header bar menu shown for users without necessary rights to execute actions [ID_40403]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In some cases, it could occur that the "..." button to open a menu with actions was shown in the header bar of a low-code app even when a user did not have the rights to execute any actions, so that an empty menu was shown when the user clicked the button.

#### Low-Code Apps: 'New draft available' pop-up message shown twice [ID_40406]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When the "New draft available" pop-up message for a low-code app was closed immediately after it appeared, it could occur that it was incorrectly shown a second time.

#### Dashboards/Low-Code Apps: DOM instances not updated in form component [ID_40412]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In some cases, it could occur that DOM instances in a form component within a dashboard or low-code app were no longer updated when they transitioned to a different state.

#### Dashboards/Low-Code Apps: Column in table component showing incorrect values after being moved [ID_40425]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

If a template was applied to a column in a table component and that column was dragged to a different location, it could occur that it then showed the values of a different column.

#### Dashboards/Low-Code Apps: GQI real-time updates not correctly applied in timeline component when grouping was applied [ID_40474]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In a timeline component of a dashboard or low-code app, it could occur that real-time updates from GQI were not applied correctly when the timeline was grouped by a column. Deleted rows were not correctly reflected in the component, and an update could result in a duplicate entry getting added.
