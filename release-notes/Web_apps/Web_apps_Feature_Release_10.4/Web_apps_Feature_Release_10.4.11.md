---
uid: Web_apps_Feature_Release_10.4.11
---

# DataMiner web apps Feature Release 10.4.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.11](xref:General_Feature_Release_10.4.11).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Dashboards app: Folders of which the name contained a slash ('/') or a backslash ('\\') character would stay hidden [ID_40532]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you created a dashboard folder of which the name contained a slash ("/") or a backslash ("\\") character, up to now, the folder would be created, but would stay hidden. It would not appear in the folder structure.

From now on, when you enter a folder name containing a slash ("/") or a backslash ("\\") character, an `Invalid folder name message` will appear.
