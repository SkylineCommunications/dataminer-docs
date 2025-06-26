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

#### Security: User permission 'General > View > Add/remove elements' renamed to 'Add/remove items (elements, services, etc.)' [ID 43215]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

As the *Add/remove elements* user permission in *General > Views* allows users to also add or remove other items, including services, measurement points, service templates, redundancy groups, redundancy templates, etc., this user permission has now been renamed to *Add/remove items (elements, services, etc.)*.

#### Edge/WebView2 browser engine now supports CTRL+F search functionality [ID 43241]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In DataMiner Cube, up to now, when the Microsoft Edge (WebView2) browser engine was used to display embedded webpages, it was not possible to enter CTRL+F in order to search for a particular text string. This has now been made possible.

### Fixes

#### System Center - SNMP forwarding: 'Resend all active alarms every' option would incorrectly be set to 0 [ID 43206]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, in the *SNMP forwarding* section of *System Center*, you had created a new SNMP manager, up to now, the *Resend all active alarms every* option in the *Resend* tab would by default incorrectly be set to 0. From now on, this option will by default be set to 30 seconds.

Also, up to now, users would incorrectly be allowed to manually set this option to 0 seconds. From now on, the minimum allowed value will be 1 second.

In order to prevent any issues from occurring because of a *Resend all active alarms every* option having been set to 0, DataMiner Agents will now automatically interpret a value set to 0 as being a value set to 30 seconds.

#### Problem when loading apps in the Apps pane [ID 43208]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, when an error occurred while loading apps in the *Apps* pane, in some cases, Cube could stop working.

#### Trending: Problem when clicking a pattern in a trend graph [ID 43228]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When you clicked a pattern in a trend graph, an exception would be thrown, and the following error would be logged:

`An item with the same key has already been added.`
