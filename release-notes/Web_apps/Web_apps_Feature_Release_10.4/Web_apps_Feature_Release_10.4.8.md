---
uid: Web_apps_Feature_Release_10.4.8
---

# DataMiner web apps Feature Release 10.4.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.8](xref:General_Feature_Release_10.4.8).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards app: Enhanced input validation when updating theme colors [ID_39749]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made with regard to the validation of theme color updates.

When you specify invalid colors or invalid regex patterns, you will not be able to click *Save* until all invalid values have been corrected.

### Fixes

#### Dashboards app & Low-Code Apps: Interactive Automation scripts launched from a node edge graph or a context menu action would not inherit the theme of the dashboard or low-code app [ID_39664]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

When an interactive Automation script was launched from a node edge graph or a context menu action, the script would incorrectly not inherit the theme of the dashboard or low-code app.

#### Dashboards app & Low-Code Apps: Problems with feed links after migrating a dashboard or app [ID_39744]

<!-- MR 10.3.0 [CU17] / 10.4.0 [CU5] - FR 10.4.8 -->

After a dashboard or a low-code app had been migrated from DataMiner server version 10.3.8 to DataMiner server version 10.3.9 or later,feed links defined in the *Web* component, the *Text* component or the *Navigate to a URL* action would no longer work.
