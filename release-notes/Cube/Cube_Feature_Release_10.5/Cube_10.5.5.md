---
uid: Cube_Feature_Release_10.5.5
---

# DataMiner Cube Feature Release 10.5.5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.5](xref:General_Feature_Release_10.5.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.5](xref:Web_apps_Feature_Release_10.5.5).

## Highlights

- [System Center - SNMP forwarding: New option to prevent an SNMP manager from resending SNMP inform messages [ID 41885]](#system-center---snmp-forwarding-new-option-to-prevent-an-snmp-manager-from-resending-snmp-inform-messages-id-41885)
- [EPM functionality is now fully integrated in DataMiner Cube [ID 42221]](#epm-functionality-is-now-fully-integrated-in-dataminer-cube-id-42221)

## New features

#### System Center - SNMP forwarding: New option to prevent an SNMP manager from resending SNMP inform messages [ID 41885]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Up to now, when you stopped and restarted an SNMP manager, all open alarms would be resent. From now on, when you configure an SNMP manager, you will be able to prevent this by selecting the *Enable tracking to avoid duplicate inform acknowledgments (ACKs)* option. If you select this option, DataMiner will track which inform messages have been sent, and will not resend those that have already been acknowledged.

> [!NOTE]
> This new *Enable tracking to avoid duplicate inform acknowledgments (ACKs)* option is not selected by default and is not compatible with the existing *Resend all active alarms every:* option. It is also not compatible with the *Resend...* command, which can be selected after right-clicking an SNMP manager in the *SNMP forwarding* section of System Center.

#### EPM functionality is now fully integrated in DataMiner Cube [ID 42221]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

All EPM functionality is now fully integrated in the UI of DataMiner Cube. Up to now, this required the *CPEIntegration* soft-launch option to be enabled.

In the sidebar, you can now open the *Topology* pane, which allows you to select a topology chain, drill down to any of the topology level in that chain. On top of that, all EPM-related data can now also be accessed via the Surveyor or the Alarm Console.

##### Configuration

1. Make sure the DMS contains at least one EPM frontend manager element.

   For DataMiner Cube to detect these elements, they should be active, the *type* attribute of the *Display* tag in their connector should be set to "element manager", and they should contain a parameter named *ElementManagerType* set to 1. Also, their name should preferably start with "FE".

   Each EPM frontend manager element will describe a topology chain and its associated filters.

1. Go to *System Center > System settings > EPM config*, and add all EPM frontend manager element(s) to the list.

   In the *Topology* pane, the *Topology chain* selector will now contain all topology chains configured in each of the EPM frontend manager elements you added to the list.

Up to now, it was only allowed to have one single EPM frontend manager element per DataMiner System. From now on, one DataMiner System can have multiple EPM frontend manager elements.

> [!IMPORTANT]
>
> - Each of the frontend manager connectors must have a different *SystemType*.
> - All frontend manager elements must use the same version of the same connector.
> - All backend manager elements must use the same version of the same connector.
> - All EPM objects must be linked using both *SystemName* and *SystemType*. For example, in Visual Overview, you can link a shape to an EPM object by means of the *SystemName* and *SystemType* data fields.

#### Sharing the link to the current Cube session with other users [ID 42389] [ID 42524]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

If you want to share your current Cube session with another user, you can now copy the link to that session and send it to that user, who will then be able to paste it in the address box of a browser.

To copy the link to the current Cube session, do the following:

1. Open the user menu by clicking the user icon in the top-right corner of the screen.
1. Click the *Copy* button next to the name of the DataMiner System.

When you hover over this *Copy* button, a tooltip will appear, saying that clicking this button will copy the link to the current session to the Windows clipboard.

## Changes

### Enhancements

#### DataMiner Cube desktop app: Enhanced configuration file management and revised drag-and-drop functionality [ID 41203]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In the DataMiner Cube desktop app, a number of enhancements have been made with regard to configuration file management.

Also, the drag-and-drop functionality has been revised. For example, it is now possible to reorder tile groups and to remove tiles by dragging them onto the recycle bin.

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

#### Trending: Enhanced selection of change points areas [ID 42488]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a trend graph contained multiple overlapping change point areas, up to now, smaller areas could get covered by larger areas, making it impossible to select them. From now on, when you click a group of overlapping change point areas, the change point with the smallest time range will be selected.

#### Elements: New 'Block Swarming' option to indicate that an element is not allowed to swarm [ID 42536]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When you create or update an element, you will now be able to indicate that the element is not allowed to swarm to another host.

To do so, go to the *Advanced* section, and enable the *Block Swarming* option. By default, this option will be set to false.

If you try to swarm an element of which the *Block Swarming* option is set to true, then the error message *Element is not allowed to swarm (blocked)* will be displayed.

> [!NOTE]
> In DataMiner Cube, this *Block Swarming* option will only be visible if Swarming is enabled in the DataMiner System.

#### Data Display: Enhanced performance when opening view cards [ID 42576]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Because of a number of enhancements, overall performance has increased when opening view cards.

#### Spectrum analysis: Auto-scale button at the top of a spectrum trace graph [ID 42597]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 [CU0] -->

In the *Spectrum Analyzer* page of a spectrum analyzer card, you can now find an auto-scale button at the top of the spectrum trace graph.

Clicking this button will maximize and center the current trace based on minimum and maximum values.

This feature will only work if the spectrum element connector contains the following parameters:

- *Reference Level* (both read and write parameters)
- *Amplitude Scale* (both read and write parameters)

### Fixes

#### Visual Overview: Placeholders would incorrectly broadcast the same value twice [ID 42252]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Up to now, in some cases, placeholder would incorrectly broadcast the same value twice.

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

#### System Center - Database: Offload configuration for real-time trending data displayed incorrectly [ID 42469]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When, while configuring trend data offloads, you selected *Trend data* and *Enable data offload* in the *Offloads* section, and then set the offload frequency to "permanently", this would be saved correctly, but displayed incorrectly in DataMiner Cube.

#### Alarm Console: Correlation alarms and incident alarms could appear twice in a newly created alarm tab [ID 42501]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When you created a new alarm tab, in some rare cases, correlation alarms or incident alarms would incorrectly appear twice in that tab: once with the correct base alarms and once without any base alarms.

#### Correlation : Correlation alarm triggered by another correlation alarm would not be shown as base alarm [ID 42541]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a correlation rule created a correlated alarm that would trigger another correlation alarm that used the first correlated alarm as a base alarm, in some cases, the alarms would incorrectly not be shown as main alarm and base alarm, but as two separate correlated alarms.

#### Not possible to open parameter cards from the Search pane [ID 42552]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When, in the *Search* pane, you right-clicked a parameter in the search results and selected e.g. *Open in new card*, the parameter card would refuse to open.
