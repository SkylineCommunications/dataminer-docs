---
uid: Web_apps_Feature_Release_10.7.2
description: "Release notes for DataMiner web apps Feature Release 10.7.2, with new features, enhancements, and fixes planned for this release."
---

# DataMiner web apps Feature Release 10.7.2 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU11].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.7.2](xref:General_Feature_Release_10.7.2).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.7.2](xref:Cube_Feature_Release_10.7.2).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Web API: Error logged when reading settings for apps saved in an older format [ID 47193]

<!-- MR 10.6.0 [CU11] - FR 10.7.2 -->

When the Web API read settings for an app saved in an older format, for example when you opened the apps list, DataMiner could log a parsing error.

These settings will now be read without logging this error.

#### DataMiner apps: Duplicate backup errors during upgrades [ID 47216]

<!-- MR 10.8.0 - FR 10.7.2 -->

During a DataMiner upgrade, the web backup tool could log an "already exists" error when an app's published and draft versions pointed to the same folder. The tool would try to copy that folder twice. This could affect older apps that retained these settings after an upgrade.

From now on, when the published and draft versions point to the same folder, that folder will be backed up only once. Apps with a separate draft will still have both versions backed up.
