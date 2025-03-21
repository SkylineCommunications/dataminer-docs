---
uid: Cube_Feature_Release_10.5.5
---

# DataMiner Cube Feature Release 10.5.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.5](xref:General_Feature_Release_10.5.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.5](xref:Web_apps_Feature_Release_10.5.5).

## Highlights

*No highlights have been selected yet.*

## New features

#### Sharing the link to the current Cube session with other users [ID 42389]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

If you want to share your current Cube session with another user, you can now copy the link to that session and send it to that user, who will then be able to paste it in the address box of a browser.

To copy the link to the current Cube session, do the following:

1. Open the user menu by clicking the user icon in the top-right corner of the screen.
1. Click the *Copy* button next to the name of the DataMiner System.

## Changes

### Enhancements

#### DataMiner Cube desktop app: Enhanced configuration file management and revised drag-and-drop functionality [ID 41203]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In the DataMiner Cube desktop app, a number of enhancements have been made with regard to configuration file management.

Also, the drag-and-drop functionality has been revised. For example, it is now possible to re-order tile groups and to remove tiles by dragging them onto the recycle bin.

#### Profiles app will now show an error message when a create, update or delete operation fails [ID 41902]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When you used the *Profiles* module to create, update or delete a profile definition, a profile instance, a profile parameter, or a mediation snippet, up to now, you would not get notified when the operation failed. To find out why the operation failed, you had to consult the Cube logging.

From now on, whenever an error occurs while a create, update or delete operation is being performed, the *Profiles* module will open a dialog box showing an error message.

#### Alarm Console: Recursive loop detection in alarm trees [ID 42188]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

From now on, when you right-click an alarm in the Alarm Console and select *Show side panel*, DataMiner Cube will check whether there are loops in the alarm tree, i.e. whether the alarm tree contains any alarms that refer to themselves.

#### Alarm Console: Multivariate pattern suggestion events will now be grouped into a single incident [ID 42287]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a multivariate pattern is detected in new trend data, suggestion events are generated for every parameter in the linked pattern.

From now on, those suggestion events will be grouped into a single incident, which will be shown as a single line in both the *Suggestion events* tab and the *Patterns* tab of the Alarm Console.

#### Alarm templates: Warning message will now appear when you try to enable smart baselines for a history set parameter [ID 42326]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When you enable smart baselines for a parameter that has its `historySet` option set to true in the connector in question, from now on, a warning message will appear, saying that historySet functionality is incompatible with smart baselines.

> [!NOTE]
> Although, in the UI, the smart baseline option will be enabled for the parameter in question, the option will have no effect as long as the parameter has its `historySet` option set to true in the connector.

#### System Center - System settings: 'Time to live' section will no longer be available when Cube is connected to a DMS using STaaS [ID 42333]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In *System Center > System settings*, the *Time to live* section will no longer be available when Cube is connected to a DMS using STaaS.

#### Trending: Miscellaneous enhancements [ID 42461]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

A number of enhancements have been made with regard to trending.

The visibility of Y-axis curves in trend graph legends has been improved, and error and lock handling has been enhanced.

### Fixes

#### Trending: Problem when loading trend data when the trend graph contained both regular average trend data and trend data related to SLAnalytics [ID 42357]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a trend graph contained both regular average trend data and trend data related to SLAnalytics, in some rare cases, the trend graph could get stuck while loading that data.

#### Trending: Problem when you drilled down to a parameter from a Data Display subpage [ID 42373]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When you drilled down to a parameter by clicking a button on a Data Display subpage, in some cases, the trend graph would incorrectly be empty and the name of the parameter in both the title and the body of the window would be incorrect.

#### DataMiner Cube desktop app: Problem when pressing certain keys while entering a search string in the start window [ID 42437]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When, in the start window of the DataMiner Cube desktop app, you entered a search string in the search box and then pressed e.g. the left arrow key to position the cursor in the text you entered, up to now, the cursor would incorrectly not stay in the filter box. Instead, the key press would cause a different tile to be selected.

Also, when a certain group did no longer contain any tiles due to the filter you had entered, up to now, the empty group would incorrectly stay visible.

#### DMA selection box of duplicate element to be created would not be set to the correct DataMiner Agent [ID 42438]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When, in the Surveyor, you right-clicked a migrated or swarmed element, and selecting *Duplicate*, in the element card of the duplicate element to be created, the *DMA* selection box would not be set to the correct DataMiner Agent.

#### Protocols & Templates module: Problem when trying to open an information template using the right-click menu [ID 42462]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In the Protocols & Templates module, you can open an information template by either double-clicking it or right-clicking it and selecting *Open*.

Up to now, when you right-clicked and selected Open, Cube would incorrectly open the most recently selected alarm template or trend template instead.
