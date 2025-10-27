---
uid: Cube_Feature_Release_10.5.1
---

# DataMiner Cube Feature Release 10.5.1

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU10].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.1](xref:General_Feature_Release_10.5.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.1](xref:Web_apps_Feature_Release_10.5.1).

## New features

#### New SLHelper option to skip alarm subscriptions when Cube is used as a service [ID 41327]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, when Cube was used as a service (i.e. running inside SLHelper) to e.g. show visual overviews on mobile devices, it would always subscribe to all alarms. However, in many cases, no alarm information is needed when showing these visual overviews.

From now on, in the *SLHelper.exe.config* file, it is possible to indicate that you want alarm subscriptions to be skipped by setting the `helper:load-alarms` option to false. See the example below.

```xml
<configuration>
    ...
    <appSettings>
        ...
        <add key="helper:load-alarms" value="false"/>
        ...
      </appSettings>
    ...
</configuration>
```

> [!NOTE]
> When `helper:load-alarms` is set to false, no alarms will be loaded, even when the visual overview in question needs alarm information to render correctly.

#### Alarm Console - Proactive cap detection: User feedback [ID 41451]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

In the *Suggestion events* and *Predicted alarms* tabs of the Alarm Console, the *Feedback* column now allows you to give feedback on any of the listed suggestion events and alarms created by the proactive cap detection feature.

> [!IMPORTANT]
> This feature will only work when connected to a DataMiner Agent running at least main release 10.6.0 or feature release 10.5.1.

##### Thumbs up or thumbs down

In the *Feedback* column, you can find two buttons to evaluate an alarm or a suggestion event:

- a "thumbs up" button you can click to indicate that you like it, and
- a "thumbs down" button you can click to indicate that you do not like it.

Any feedback users give will be used by the proactive cap detection feature to tailor the detection on system level.

When you click one of the two buttons, it will be pinned in the column as a black icon, and if you change your mind, you can click the other one. Buttons that have not been clicked will stay hidden and will only be visible when you hover over the alarm or suggestion event. Also, you will only see the icons you have clicked yourself. You will not be able to see feedback given by other users.

Feedback given for active alarms will be saved in the user settings and will re-appear after closing Cube and opening it again. Feedback given for history alarms will disappear after restarting Cube. However, it will not be deleted. It will be used by SLAnalytics to improve the accuracy of the proactive cap detection feature.

> [!NOTE]
> Instead of clicking the "thumbs up" or "thumbs down" button, you can also right-click the alarm or suggestion event and select *Like* or *Dislike*.

##### Taking action

When you click either the "thumbs up" or "thumbs down" button, in some cases, a light bulb icon will appear. In the context menu under that icon, you can then find the action you are suggested to take:

| Action | Description |
|--------|-------------|
| Clear event            | When you select this action, the alarm or suggestion event will be cleared immediately. No confirmation box will appear. |
| Improve alarm template | When you select this action, a pop-up window will appear, suggesting a number of alarm template changes.<br>These suggested changes, which will be based on all feedback that was given in the past for the parameter in question, should help you to configure the alarm template in such a way that you get to see the alarms or suggestion events you want to see.<br>At the bottom of the pop-up window, you will also see a list of elements using the same alarm template that will also be affected when you decide to make the suggested template changes.<br>A button will allow you to view the current configuration. |
| Create alarm template | When you select this action, a pop-up window will appear, showing a proposal for a new alarm templates.<br>If you accept this proposal, a new alarm template will be created and applied to the current element. |

When you gave feedback on multiple alarms and/or suggestions related to the same parameter, an action will only be suggested for the last alarm or suggestion you gave feedback on.

> [!NOTE]
>
> - The actions listed above will only appear if you are allowed to perform them. For example, the system will not suggest you update the alarm template if you are not allowed to do so.
> - The *Improve alarm template* and *Create alarm template* actions will not appear if the element in question has an alarm template group assigned.
> - In case of anomaly alarms, the *Create alarm template* action will now behave in a way that is similar to the *Create alarm template* action described above. Up to now, in case of anomaly alarms, the *Create alarm template* action would create a new, empty alarm template.

##### Adding a feedback column to other alarm tabs

The feedback column will only be visible by default in the *Suggestion events*, *Anomalies* and *Predicted alarms* tabs. If you want this column to also be visible in another alarm tab listing either alarms or suggestion events, do the following:

1. Go to the alarm tab to which you want to add a feedback column.
1. Right-click the column headers, and select *Add or remove columns* > *Actions*.

> [!NOTE]
>
> - The "thumbs up" and "thumbs down" buttons will only be shown for alarm or suggestion events generated by either the behavioral anomaly detection feature or the proactive cap detection feature.
> - On systems that do not use either STaaS or dedicated clustered storage, the "thumbs up" and "thumbs down" buttons will not be shown in alarm tabs listing history alarms.

## Changes

### Enhancements

#### System Center - Users/Groups: Tooltip of 'Admin tools' permission has been enhanced [ID 40983]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When you hover over the information icon next to the *Modules > System configuration > Tools > Admin tools* user permission, a tooltip appears, showing more information on this permission. The text of this tooltip has now been enhanced.

#### System Center - Agents: Clustering compatibility checks will now be performed by the DMA to which Cube is connected [ID 41049]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When you try to add a DataMiner Agent to the DataMiner System, a number of checks will be performed to determine whether the new Agent is compatible to be added. Up to now, these compatibility checks would be performed by Cube. From now on, they will be performed by the DataMiner Agent to which Cube is connected.

See also: [Clustering compatibility check enhancements [ID 41046]](xref:General_Feature_Release_10.5.1#clustering-compatibility-check-enhancements-id-41046)

#### DataMiner Cube now support alarm tree IDs when processing correlation and incident alarms [ID 41156]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

DataMiner Cube now supports the newly introduced alarm tree IDs when processing correlation and incident alarms.

#### Cards: Enhancements to prevent view cards from showing a 'Loading' message when opened [ID 41162]

<!-- MR 10.3.0 [CU22] / 10.4.0 [CU10] - FR 10.5.1 -->

A number of enhancements have been made to prevent view cards from showing a "Loading" message when opened.

#### Alarm templates: Text in 'Augmented Operations alarm settings' pop-up window has been made more translation-friendly [ID 41254]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

In the *Augmented Operations alarm settings* pop-up window, the text has been adjusted to allow a more natural translation to other languages.

#### Client compatibility framework: Baseline updated [ID 41276]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

To make sure a Cube client is backwards compatible with all servers it connects to, it is necessary for that client to know which features a server is aware of. Therefore, when a Cube client connects to a particular server, that server will return a list of features it supports.

However, to prevent these feature lists from getting too large, a feature baseline is set on a regular basis. This will allow a server to only return features that have been added or modified since a particular version. Now, the baseline has been updated to DataMiner version 10.4.12.

#### Redundancy groups: Configuration enhancements [ID 41315]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

A number of enhancements have been made with regard to the configuration of redundancy groups and redundancy group templates:

- When a block is loading in the *Switching detection* section, a "Loading" message will now be displayed on top of that block, making it impossible to make changes to the settings in that block until all settings have been loaded.

- The blocks in the *Switching detection* section will now initially be in an error state instead of a valid state. This will prevent users from saving an invalid configuration when data is still being loaded or when certain blocks contain invalid or corrupted data.

- More validation checks will now be done when scanning the changes made to the configuration. The outcome of those checks will determine whether the Apply button get enabled or not.

- When a validation scan detects invalid data, an entry will be added to the SLClient server logging. However, that entry will only be visible in the Logging module when the *Show debug logging* option is enabled. Also, in that case, no update message will be sent to the server. The user will receive a message saying that a problem occurred and that more details can be found in the Logging module.

#### Smart baselines: Cube will now also check whether a table cell is empty when it receives a baseline update for that cell [ID 41320]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When the alarm template editor receives a baseline update for a table cell, Cube checks whether average trending is enabled for the table cell in question. It will now also check whether the table cell is empty or not.

#### Correlation app: No longer possible to add or load Correlation rules that use the deprecated System Display Correlation engine [ID 41363]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, in the *Correlation* app, it was possible to add Correlation rules that used the deprecated System Display Correlation engine. To do so, you had to right-click a folder in the tree view pane (or click the *More...* button at the bottom of the pane) and select *Advanced > Old engine > Add rule*.

From now on, when Cube is connected to a DataMiner Agent running version 10.5.1 or newer, this will no longer be possible, and existing Correlation rules using the deprecated System Display Correlation engine will no longer be loaded.

Also, when you open the *dataminer* tab in the *Logging* section of *System Center* when connected to a DataMiner Agent running version 10.5.1 or newer, the *Correlation (SD)* log file will be removed from the log file list.

#### Correlation & Scheduler apps - 'Send email' action: Attached dashboard will be shown in red when it no longer exists [ID 41364]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When, in the *Correlation* app or the *Scheduler* app, you open an existing *Send email* action to which a dashboard is attached, from now on, that dashboard will be shown in red when it no longer exists.

#### Setting 'Enable search indexing on the client' will now be disregarded when Cube is used as a service [ID 41422]

<!-- MR 10.3.0 [CU22] / 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

In the *Search & Indexing* section of *System Center*, you can indicate whether search indexing has to be enabled on the client.

From now on, when Cube is used as a service (i.e. running inside SLHelper), the *Enable search indexing on the client* setting will be disregarded.

#### Visual Overview - Resource Manager component: Session variable 'ResourcesInSelectedReservation' will be updated automatically when the list of resources assigned to the selected booking changes [ID 41432]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When you select a booking block in a *Resource Manager* component showing a booking timeline, the session variable *ResourcesInSelectedReservation* will contain a comma-separated list of resource GUIDs.

Up to now, when resources would get assigned to or unassigned from the booking in question while it remained selected in the timeline, the *ResourcesInSelectedReservation* variable would not get updated. To force an update of the variable, you had to reselect the booking.

From now on, the comma-separated list of resource GUIDs stored in the *ResourcesInSelectedReservation* variable will be updated automatically while the booking is selected.

#### Data Display in DataMiner Cube now supports dynamic units by default [ID 41436]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

From now on, dynamic units can be used by default in Data Display in DataMiner Cube.

If you want this feature to be disabled system-wide, then explicitly set the *DynamicUnits* option to false in the *SoftLaunchOptions.xml* file.

#### Visual Overview: Enhanced rendering of embedded visual overviews [ID 41437]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Because of a number of enhancements, embedded visual overviews will now be rendered more quickly.

#### Sidebar: Link to deprecated 'Resources' page removed from 'Community' menu [ID 41445]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Clicking the *Community* button at the bottom of DataMiner Cube's sidebar opens a menu with different links to the [DataMiner Dojo user community](https://community.dataminer.services/). As the *Resources* page no longer exists, the link to that page has now been removed from the menu.

#### Visual Overview will again subscribe on all properties associated with the linked object when property placeholders are being used [ID 41479]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When, in a visual overview, a property placeholder was used, up to feature release 10.4.9, the visual overview would always subscribe on all properties associated with the linked object, regardless of the property specified in the property placeholder. As of feature release 10.4.9, the visual overview would only subscribe on the property name that was specified.

This change has now been reverted. When, in a visual overview, a property placeholder is used, the visual overview will again subscribe on all properties associated with the linked object, regardless of the property specified in the property placeholder.

### Fixes

#### Visual Overview: Shape data values starting with '[property:' and ending with ']' would be parsed incorrectly [ID 41047]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When a shape linked to an element or a view contained shape data of which the value started with "[property:" and ended with "]", up to now, the entire value would be interpreted as a property, even when it included other types of placeholders.

#### Connection object would leak memory when you logged out of DataMiner Cube [ID 41103]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When you logged out of DataMiner Cube, the connection object would leak memory.

#### Alarm Console - Hyperlinks: [PROPERTY:] placeholder would incorrectly not get resolved when the alarm did not contain the property in question [ID 41112]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When an alarm hyperlink contained a [PROPERTY:] placeholder, that placeholder would incorrectly not get resolved when the selected alarm did not contain the property in question.

#### Resources app: Quarantine warning would always appear when something went wrong while adding or updating a resource [ID 41201]

<!-- MR 10.3.0 [CU22] / 10.4.0 [CU10] - FR 10.5.1 -->

When, in the *Resources* app, you added or updated a resource, up to now, a pop-up window showing a quarantine warning would appear whenever something went wrong.

From now on, a pop-up window showing a quarantine warning will only appear in cases where quarantine applies.

#### DataMiner Cube desktop app: Argument screen=\\\\.\\DISPLAY2 will now be applied when no screen argument is passed to the DataMiner Agent [ID 41340]

<!-- MR 10.3.0 [CU22] / 10.4.0 [CU10] - FR 10.5.1 -->

If you have multiple monitors and want the DataMiner Cube desktop app to open on a specific monitor, you can open the app using a command with the *screen* argument. For example: *DataMinerCube.exe screen=\\\\.\\DISPLAY2*

Up to now, this *screen* argument would not be applied to the DataMiner Agent when passed to DataMiner Cube, only when it was explicitly passed to the DataMiner Agent.

#### 'Cube search' background thread would not be closed when a Cube session was closed abruptly [ID 41359]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, each time a Cube session was closed abruptly, its *Cube search* background thread would not be cleaned up properly. When a new session was then opened or when the closed session was restored, a new *Cube search* background thread would be created alongside the old one. From now on, when a new *Cube search* background thread is created, any existing *Cube search* background threads will first be closed.

Also, when a *Cube search* background thread was closed, up to now, the memory allocated to that thread would not be freed up.

#### Alarm Console: Base alarms of a correlated alarm would disappear when that alarm did not match the filter and a delay was specified on the alarm tab [ID 41463]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When, in an alarm tab in which an alarm filter and a delay had been specified, a correlation alarm would disappear because it no longer matched the filter, up to now, its base alarms that did match the filter would incorrectly not be added.

Also, when neither a correlation alarm nor its base alarms no longer matched the filter, up to now, the correlation alarm would incorrectly not disappear from the alarm tab.

#### Visual Overview: Dynamic page data would not report their 'pending' state correctly [ID 41483]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When calculating how long it took to load a Visio page, up to now, the processing of the dynamic placeholders specified on that page would incorrectly not be taken into account. As a result, dynamic page data would not report their *pending* state correctly.
