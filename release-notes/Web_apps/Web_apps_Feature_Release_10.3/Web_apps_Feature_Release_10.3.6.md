---
uid: Web_apps_Feature_Release_10.3.6
---

# DataMiner web apps Feature Release 10.3.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.6](xref:General_Feature_Release_10.3.6).

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No other features have been added to this release yet.*

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Dashboards app & Low-code apps - Table component: Minimum pagesize would be used when exporting to a CSV file [ID_36012]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When exporting data from a table component to a CSV file, the minimum pagesize would be used. From now, the largest possible pagesize is used when exporting data from a table component to a CSV file.

#### Dashboards app & Low-code apps: Component title could be made too large [ID_36021]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In a custom component theme, for some fonts, the font size of the title could be set to a value higher than 36px, causing the component title to be larger than its container. Also, in some cases, the font size could incorrectly be set to 0px.

From now on, font sizes will have to be set to a value between 1px and 36px.
