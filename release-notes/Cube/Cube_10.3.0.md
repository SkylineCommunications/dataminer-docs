---
uid: Cube_Main_Release_10.3.0
---

# DataMiner Cube Main Release 10.3.0

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

## Other new features

#### Automation app: Casing of a script name can now be changed [ID_33988]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

In the Automation app, it is now possible to change the casing of a script name.

Also, if you change the casing of a script name that was selected, it will remain selected.

#### Visual Overview - Conditional shape manipulation: Using statistics in the condition when the shape is linked to an EPM object [ID_34026]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When applying conditional shape manipulation actions to a shape, up to now, it was only possible to use statistics in the condition if the shape was linked to an element, a service or a view. From now on, you can also use statistics in the condition when the shape is linked to an EPM object.

Example in which both the SystemName and the SystemType are linked:

```txt
<A>-A|SystemType= Cable;SystemName=SF Cable1|#TotalAlarms|>0
```

Supported statistics:

- #TotalAlarms
- #CriticalAlarms
- #MajorAlarms
- #MinorAlarms
- #WarningAlarms
- #NormalAlarms
- #TimeoutAlarms
- #NoticeAlarms
- #ErrorAlarms

Supported operators:

- =
- !=
- \>
- \>=
- \<
- \<=

## Changes

### Enhancements

#### Desktop app: Enhanced host detection \[ID_31829\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

In the DataMiner Cube desktop app, a number of enhancements have been made with regard to host detection.

#### Desktop app start window now has a look and feel that is identical to that of the other Cube apps \[ID_32161\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

The start window of the DataMiner Cube desktop app has now been adapted so that its overall look and feel is identical to that of the other Cube apps.

#### Desktop app - Start window: Performance enhancements \[ID_33384\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Because of a number of enhancements, overall performance has increased when opening the start window of the DataMiner Cube desktop app from the system tray icon.

#### Alarm Console: Pencil icon now identical to that used in Data Display tables \[ID_33442\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

The pencil icon used in the Alarm Console is now identical to that used in Data Display tables.

#### Alarm Console: “Add to incident” menu option no longer available when right-clicking alarms that cannot be added to an incident \[ID_33591\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

From now on, the “Add to incident” menu option will no longer be available when you right-click an alarm that cannot be added to an incident:

- Active alarms with severity “normal” (i.e. clearable alarms that have not been cleared yet)
- Alarms with a source other “DataMiner System” (e.g. correlation alarms)
- Alarms associated with DataMiner itself
- Notices, errors, information events and suggestion events

#### Profiles app: Selected list items not visible on the UI would incorrectly not be validated after being edited \[ID_33753\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When, in the Profiles app, you edited a profile definition, a profile instance, a profile parameter or a service definition, the change would incorrectly not be validated if the item in question was not visible in the list.

#### Start window enhancements [ID_34033]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

A number of enhancements have been made to the DataMiner Cube start window:

- When you hover over a cluster tile, a tooltip will now appear, showing the cluster name, the cluster alias, the hostname of the agent and the last-known server version (if any). The latter will be updated when you connect to the cluster in question and when an update occurs in the background.

    > [!NOTE]
    > Cluster tiles will no longer display the hostname of the agent if it is identical to the cluster alias.

- When using the search box to filter the tiles, the last-known server version will now also be checked. This will allow users to search for clusters with a specific server version.

- When you check for updates (by clicking the cogwheel icon in the bottom-right corner and selecting *Check for updates*), the last-known server version will now be taken into account to avoid having to contact every configured cluster. If a DataMiner Agent has been upgraded since the last background update, the new client version will be downloaded from the agent the first time you connect to it or from the cloud during the next background update (if that version is newer that the current version).

    > [!NOTE]
    >
    > - If you hold the SHIFT key when clicking *Check for updates*, a full update will start. Depending on the number of clusters in your configuration, this can take some time.
    > - An update triggered by the *Update DataMiner Cube_ [userID]* task in Windows Task Scheduler will always be a full update.

- When the start window application is downloaded from a DataMiner Agent, the cluster is automatically configured. Up to now, if it was possible to reach the agent via HTTPS within 2 seconds, the cluster was configured as "HTTPS only". However, in some cases, 2 seconds was too short, resulting in HTTPS agents being configured as "HTTP or HTTPS". From now on, the start window application will wait up to 5 seconds.

- When you add a new cluster, it will now always be added to the group containing the currently selected cluster.

- The maximum size of the daily log file has been increased from 1 MB to 100 MB.

### Fixes

#### Visual Overview: Problem when navigating inside EPM cards \[ID_32288\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

When working inside an EPM card, in some cases, it would no longer be possible to navigate to a data page or a subpage.

#### Visual Overview: Card buttons in an EPM card would no longer work when the Topology sidebar was selected \[ID_32372\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

When an EPM card was opened from a visual overview, and the Topology tab was selected in the sidebar, a number of buttons inside that EPM card would no longer work.

#### Properties not shown in the Surveyor \[ID_32429\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

In some cases, properties with the “Display this property in the Surveyor” option enabled would incorrectly not be displayed in the Surveyor.

From now on, when you create a new property and enable its “Display this property in the Surveyor” option, it will immediately show up in the Surveyor, and when you enable that option for an existing property, the property will show up in the Surveyor the first time its value is updated or the next time the user logs in.

When users enable the option for an existing property, a tooltip will now inform them that the value will only appear after logging off and logging in again.

#### Alarm templates: Anomaly detection alarms would incorrectly disappear after a DataMiner restart \[ID_33278\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

From DataMiner 10.0.3 onwards, you can configure an alarm template so that alarms are generated instead of suggestion events when anomalies are detected for specific parameters.

Up to now, these anomaly detection alarms would incorrectly disappear from the Alarm Console after a DataMiner restart.

#### Desktop app: Problem when creating a new group in the start window \[ID_33300\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

In some rare cases, an error could occur when you created a new group in the start window of the DataMiner Cube desktop app.

Also, the name of a group could get lost when you deleted the first agent/cluster in that group.

#### Visual Overview: Session variables of Resource Manager component would incorrectly be set to NULL when cleared \[ID_33527\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When the following session variables of an embedded Resource Manager component were cleared, up to now, they would incorrectly be set to NULL. From now on, they will be set to an empty value instead.

- ResourcesInSelectedReservation
- SelectedOccurrence
- SelectedPool
- SelectedReservation
- SelectedReservationDefinition
- SelectedResource
- SelectedSession
- TimerangeOfSelectedReservation

#### Resources app: Empty Occupancy tab \[ID_33540\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

The first time you clicked the *Occupancy* tab after opening the *Resources* app, in some rare cases, that tab would incorrectly be empty.

#### Profiles app: No validation errors were displayed when no discrete values had been added yet for a profile parameter of type discrete \[ID_33756\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When an error occurred while configuring a profile parameter of type “discrete”, up to now, that error would not be displayed on the UI when no discrete values had been added yet.

#### Resources app: Warning messages were incorrectly shown in the footer when resource manager configuration requests returned error trace data \[ID_33780\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When you open the *Resources* app, a warning will be shown in the footer when error trace data was found when fetching resource manager data from the server. Up to now, such a warning would incorrectly also be shown when resource manager configuration requests returned error trace data.

#### Resources app: Updating a session variable in a Resource Manager component would incorrectly cause that same session variable to be updated in the Occupancy tab of the Resources app \[ID_33800\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When a session variable (e.g. YAxisResources) was updated in an embedded Resource Manager component, in some cases, that same session variable would also incorrectly be updated in the *Occupancy* tab of the Resources app.
