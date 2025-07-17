---
uid: Cube_Feature_Release_10.5.8
---

# DataMiner Cube Feature Release 10.5.8

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU17] and 10.5.0 [CU5].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.8](xref:General_Feature_Release_10.5.8).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.8](xref:Web_apps_Feature_Release_10.5.8).

## New features

#### New setting: Enable 'Multiple set' [ID 43135]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In the *Settings* window, a new *Enable 'Multiple set'* setting has been added to the *User > Cube* section.

When this setting is disabled, it will not be possible to open the *Multiple set* window by performing one of the following actions:

- Clicking the *Multiple set* command in one of the following context menus:

  - the context menu of an element in the Surveyor
  - the context menu of an element in the element list of a view
  - the context menu of an element shape in a visual overview

- Clicking a shape linked to a multiple set command in a visual overview.

Default value: Enabled

## Changes

### Enhancements

#### Trending: Enhanced performance when loading trend graphs [ID 42647]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Because of a number of enhancements, overall performance has increased when loading trend graphs.

#### Current host of an element or service is now shown in Properties window [ID 42807]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When you right-click an element or a service, and select *Properties*, the *General* tab of the *Properties* window will now also display the current host, i.e. the DataMiner Agent that is currently hosting that element or service.

#### Scheduler: Support for memory files in scheduler templates [ID 42904]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When you add an event to the Scheduler timeline, from now on, you will be able to configure memory files.

If a scheduler template includes a preset comment (e.g. `Preset="MyProfile"`) that defines a memory file entry named "Memory1" using the format `Memory1="MemoryFileName"`, from now on, the corresponding memory file name (`MemoryFileName`) will be correctly assigned when the event is created in the Scheduler.

Example:

`Preset="MyProfile" Parameter1="Value1" Dummy1="34/2" Memory1="MemoryFileName"`

To display the value of a memory file in an event block, you can use the following syntax:

`Display="{m:Memory1}"`

> [!NOTE]
> When events are moved within the Scheduler timeline, the memory file configuration is preserved. This will ensure consistent behavior, even when events are rescheduled.

#### Alarm Console: Enhanced performance when processing alarm focus information [ID 42938]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Because of a number of enhancements, overall performance has increased when processing alarm focus information.

#### Automation/Scheduler - Email action: Restricted use of placeholders in Subject and Message text [ID 42985]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in the *Automation* module or the *Scheduler* module, you right-clicked in the *Subject* or *Message* box while configuring an *Email* action, up to now, you would incorrectly be allowed to insert every possible placeholder in the text.

As most of these placeholders can only be inserted when configuring an *Email* action in the *Correlation* module, from now on, no placeholders will be listed anymore when you right-click in the *Subject* or *Message* box while configuring an *Email* action in the *Automation* module or the *Scheduler* module.

> [!NOTE]
> When you are configuring an *Email* action in the *Automation* module or the *Scheduler* module, only the following placeholders are allowed in the *Subject* or *Message* text:
>
> - [dummyX]: This will be replaced with the name of the specific element you want to display. X is the dummy ID.
> - [user]: This will be replaced with the name of the user executing the automation script.

#### Automation: An error message will now be displayed when an error occurs while importing an Automation script [ID 43069]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in the Automation module, you imported an Automation script by clicking *More > Import* or by right-clicking and selecting *Import*, errors that occurred during the import operation would not be displayed in the UI.

From now on, whenever an error occurs while importing an Automation script, a pop-up window will appear, displaying the associated error message.

#### Services: Enhanced performance when editing services [ID 43122]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Because of a number of enhancements, overall performance has increased when editing services.

#### About box: Updated company information [ID 43167]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

By default, the *About* box will now show the following updated company information:

- *Skyline Communications N.V.* will now link to <https://www.skyline.be>.
- *DataMiner Technical Support* will now link to [Contacting DataMiner Support](https://aka.dataminer.services/contacting-tech-support).
- *Contact us* will now link to <support@dataminer.services>.

#### Trending: Enhanced loading of trend graph data [ID 43193]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In order to reduce flickering, a number of enhancements have been made to the way in which trend graph data is loaded.

#### Alarm Console: Enhanced performance when opening alarms [ID 43207]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Because of a number of enhancements, overall performance has increased when opening alarms in the Alarm Console.

### Fixes

#### Trending: Trend data between two gaps would incorrectly not be displayed [ID 42909]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In trend graphs showing gaps in the trend data, in some rare cases, the data between two gaps would incorrectly not be displayed.

#### Cube would incorrectly try to display certain message boxes when running as a service [ID 43048]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, Cube would incorrectly try to display certain message boxes when running as a service (e.g. within SLHelper).

#### Problem when trying to open a view card in an EPM environment [ID 43049]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In EPM environments, in some rare cases, a view card could get stuck when you tried to open it.

#### Correlation: History of correlation and incident alarms would incorrectly always show the base alarms of the last update [ID 43072]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in the alarm card of a correlation alarm or an incident alarm, you selected a particular update, the data in the right pane would change but the data below *Correlation sources of the previous alarms* would incorrectly not change.

This issue has now been fixed. Also, the caption *Correlation sources of the previous alarms* has now been renamed to *Correlation sources* or *Incident sources* (depending on the type of alarm shown in the alarm card), and the side panel of the Alarm Console will no longer display correlation sources when you open a history tab.

#### Service templates: Conditions to dynamically include or exclude child element would be interpreted incorrectly [ID 43119]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, while configuring a service template, you had specified conditional triggers to dynamically include or exclude child element, in some cases, DataMiner Cube would interpret the conditions incorrectly.

#### Trending: Problem when loading trend graphs [ID 43156]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In some rare cases, an error could occur when loading trend graphs.

#### Alarm Console: Drag-and-drop editing button would incorrectly not be visible when you selected an incident alarm [ID 43328]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 [CU0] -->

When, in the Alarm Console, you had selected the *Show side panel* option, the *Drag-and-drop editing* button would incorrectly not be visible when you selected an incident alarm.

#### Alarm card showing the details of an alarm storm alarm would incorrectly not list the source alarms [ID 43352]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 [CU0] -->

When you opened an alarm card showing the details of an alarm storm alarm, the source alarms would incorrectly not be listed.
