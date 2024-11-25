---
uid: Cube_Feature_Release_10.5.1
---

# DataMiner Cube Feature Release 10.5.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.1](xref:General_Feature_Release_10.5.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.1](xref:Web_apps_Feature_Release_10.5.1).

## Highlights

*No highlights have been selected yet.*

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

#### Visual Overview: Enhanced rendering of embedded visual overviews [ID 41437]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Because of a number of enhancements, embedded visual overviews will now be rendered more quickly.

#### Sidebar: Link to deprecated 'Resources' page removed from 'Community' menu [ID 41445]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Clicking the *Community* button at the bottom of DataMiner Cube's sidebar opens a menu with different links to the [DataMiner Dojo user community](https://community.dataminer.services/). As the *Resources* page no longer exists, the link to that page has now been removed from the menu.

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
