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

### Fixes

#### Dashboards/Low-Code Apps: Intellisense no longer working when feed is configured with special character [ID_40340] [ID_40446]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When special characters such as "(" were used when configuring a feed, Intellisense no longer worked correctly.
