---
uid: Cube_Feature_Release_10.5.9
---

# DataMiner Cube Feature Release 10.5.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.9](xref:General_Feature_Release_10.5.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.9](xref:Web_apps_Feature_Release_10.5.9).

## Highlights

*No highlights have been selected yet.*

## New features

#### System Center: New Automation tab in Logging section [ID 42737] [ID 43144]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In DataMiner feature version 10.5.6, Automation script log files were introduced. These log files can now be consulted in DataMiner Cube. To do so, in Cube, open *System Center*, and go to *Logging > Automation*.

On the left, you will find a list of all Automation scripts available on the system, grouped per DataMiner Agent.

- Right-clicking a script in the list will open a shortcut menu with two options: *Open* and *Open previous*. If there is no previous log file, the latter option will not be available.
- To set the log levels for one or more Automation scripts on a particular DataMiner Agent, open the *Log settings* pane at the top of the *Automation* tab, select the files\*, set the log levels, and click *Apply levels*.

\**To select more than one script, click one, and then click another while holding down the Ctrl key, etc. To select a list of consecutive scripts, click the first one in the list and then click the last one while holding down the Shift key.*

> [!NOTE]
> When you open an Automation script in the *Automation* module, you can access the script's log file by clicking the *View Log* button or by right-clicking inside the script's contents and selecting *View log* from the shortcut menu. Note that this will only be possible if you have permission to view log files.

#### Automation: Cube now supports Automation scripts with an Interactivity tag [ID 43149]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

DataMiner Cube now supports Automation scripts in which an `<Interactivity>` tag is specified.

Up to now, Automation scripts using the IAS Interactive Toolkit required a special comment or code snippet in order to be recognized as interactive. From now on, you will be able to define the interactive behavior of an Automation script by adding an `<Interactivity>` tag in the header of the script.

For more information on the `<Interactivity>` tag, see [Automation scripts: New Interactivity tag [ID 42954]](xref:General_Feature_Release_10.5.9#automation-scripts-new-interactivity-tag-id-42954).

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Problem when loading apps in the Apps pane [ID 43208]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, when an error occurred while loading apps in the *Apps* pane, in some cases, Cube could stop working.
