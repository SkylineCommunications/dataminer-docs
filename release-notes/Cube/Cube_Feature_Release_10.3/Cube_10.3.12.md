---
uid: Cube_Feature_Release_10.3.12
---

# DataMiner Cube Feature Release 10.3.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.12](xref:General_Feature_Release_10.3.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Interactive Automation scripts: FileSelector now allows to keep the files that were already uploaded after the UI was shown [ID_37260]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Unlike other UI block types, *FileSelector* does not allow setting an [InitialValue](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_InitialValue). However, from now on, during an interactive Automation script session, it is possible to keep the files that were already uploaded after the UI was shown.

When an interactive Automation script is executed **in Cube**, the UI block needs to keep the same [DestVar](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_DestVar) within the session. If there is no file selector block with the same [DestVar](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_DestVar) when the UI is shown again, the information about the uploaded files is lost.

See also [DataMiner web apps Feature Release 10.3.12](xref:Web_apps_Feature_Release_10.3.12#interactive-automation-scripts-fileselector-now-allows-to-keep-the-files-that-were-already-uploaded-after-the-ui-was-shown-id_37260)

### Fixes

#### Trending: Trend graph would disappear when panning [ID_37453]

<!-- MR 10.4.0 - FR 10.3.12 -->

When you panned a trend graph, in some cases, the graph would suddenly disappear.

> [!NOTE]
> From now on, trending errors will also be logged in the main Cube logging (*System Center > Logging*).

#### DataMiner Cube - Alarm Console: Display issues when a correlation alarm was based on another correlation alarm [ID_37497]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a correlation rule was based on another correlation rule, display issues could occur in the Alarm Console.

When the main correlation alarm got cleared, the base alarm would no longer be shown in the alarm tab, and when the base alarm got updated, it would be shown twice: once as the source of the other correlation alarm and once as a regular alarm.
