---
uid: Cube_Feature_Release_10.6.5
---

# DataMiner Cube Feature Release 10.6.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU2].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.5](xref:General_Feature_Release_10.6.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.5](xref:Web_apps_Feature_Release_10.6.5).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Automation: Problem when discarding changes made to dummy, parameter, or memory files [ID 44853]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When you modified a dummy, parameter, or memory file in an automation script, and then discarded the changes you made, up to now, the original script configuration would not get restored correctly. DataMiner Cube would incorrectly continue to display the updated dummy, parameter, or memory file after you had discarded the changes, even in other modules like Scheduler.

For example, when you had discarded a change to a dummy, parameter, or memory file in an automation script, and then edited a scheduled task that used that same script, the configuration inputs would appear empty, even though the changes to the script had not been saved.
