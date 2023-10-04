---
uid: Cube_Feature_Release_10.3.10
---

# DataMiner Cube Feature Release 10.3.10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.10](xref:General_Feature_Release_10.3.10).

## Highlights

- [Alarm Console: Light bulb [ID_36777] [ID_36871] [ID_36918] [ID_37057] [ID_37136] [ID_37145] [ID_37167] [ID_37184]](#alarm-console-light-bulb-id_36777-id_36871-id_36918-id_37057-id_37136-id_37145-id_37167-id_37184)

- [Protocols & Templates app: Editing, deleting and duplicating elements [ID_36971]](#protocols--templates-app-editing-deleting-and-duplicating-elements-id_36971)

## New features

#### Alarm Console: Light bulb [ID_36777] [ID_36871] [ID_36918] [ID_37057] [ID_37136] [ID_37145] [ID_37167] [ID_37184]

<!-- RNs 36777/36871/36918: MR 10.4.0 - FR 10.3.9 -->
<!-- RNs 37057/37136/37145/37167/37184: MR 10.4.0 - FR 10.3.10 -->

In the top-right corner of the Alarm Console, you can now find a light bulb icon that will light up when there are alarms or suggestion events related to an SLAnalytics feature. When you click this light bulb, a menu will open, possibly showing you the following notifications:

| Notification | Action when clicked |
|--------------|---------------------|
| X alarms require your focus in the current tab | Applies a filter that makes the current tab only list the focused alarms. |
| Also show alarms not requiring focus      | Clears the above-mentioned filter and makes the current tab list all alarms. |
| X incidents are present on the system     | Opens a new tab listing all active incidents. |
| X anomalies were found in your trend data | Opens a new tab listing all anomaly suggestions/alarms. |
| X alarms are predicted in the near future | Opens a new tab listing all prediction suggestions/alarms. |
| X recent pattern occurrence detected      | Opens a new tab listing all trend pattern suggestions. |

> [!NOTE]
>
> - Each of the above-mentioned notifications will only appear in the menu when there is at least one alarm, incident, anomaly or pattern occurrence.
> - When at least one SLAnalytics feature (alarm focus, automatic incident tracking, behavioral anomaly detection, proactive cap detection or pattern matching) is disabled or not available, a link to [Advanced analytics features in the Alarm Console](xref:Advanced_analytics_features_in_the_Alarm_Console) will appear below the light bulb icon.
> - If the DataMiner System does not include a Cassandra database, the menu will only show a notification saying the Cassandra is required.

#### Trending - Pattern matching: Pattern highlighted when mouse pointer hovers over label [ID_36863]

<!-- MR 10.4.0 - FR 10.3.10 -->
<!-- For fix included in same RN, see Fixes. -->

When you hover the mouse pointer over the pattern labels for a trend graph, now the corresponding pattern occurrences (both univariate and multivariate) are highlighted in the graph.

#### Protocols & Templates app: Editing, deleting and duplicating elements [ID_36971]

<!-- MR 10.4.0 - FR 10.3.10 -->

When, in the *Protocols & Templates* tab of the *Protocols & Templates* app, you right-click an element in the *Elements* column, the shortcut menu will now contain the following additional commands if you have been granted the necessary user permissions:

- *Edit*: Opens a card that allows you to edit the selected element.
- *Delete*: Deletes the selected element after you have clicked *Yes* in the confirmation box.
- *Duplicate*: Opens a card that allows you to create a new element based on the configuration of the selected element.

> [!NOTE]
>
> - DVE elements cannot be deleted or duplicated in the way described above. The parent element is responsible for creating or deleting such elements.
> - It is no longer possible to create elements using a *Mediation Layer* protocol from within the *Protocols & Templates* app. Also, it is no longer possible to create new alarm templates or trend templates for *Mediation Layer* protocols.

#### Alarm Console: No 'Include masked alarms' option anymore when creating a history tab [ID_37020]

<!-- MR 10.4.0 - FR 10.3.10 -->

When you added a new history tab in the *Alarm Console*, up to now, you could select the *Include masked alarms* option. This option has now been removed.

From now on, when you select the *Include alarms* option, the masked alarms will automatically be included as well. When you select the *Include information events* option or the *Include suggestion events* option, the masked alarms will not be included.

> [!NOTE]
> When you add a new tab of type "sliding window", you will still be able to select the *Include masked alarms* option.

#### Trending - Pattern matching: Pattern occurrences will now be added to a trend graph in real time [ID_37153]

<!-- MR 10.4.0 - FR 10.3.10 -->

DataMiner Cube now supports pattern occurrence events. This means that occurrences of patterns that are already displayed on a trend graph will be added in real time.

## Changes

### Enhancements

#### Trending - Pattern matching: Loading indication around light bulb icon while loading time-scoped related parameters [ID_36831]

<!-- MR 10.4.0 - FR 10.3.10 -->

When time-scoped related parameters are being loaded in a trend graph, now the light bulb icon will be shown with rotating ring dots to indicate the ongoing loading process. Previously, the light bulb was only shown when a response had been received from the server.

#### Tooltip added for 'Edit Visio drawing' user permission [ID_37095]

<!-- MR 10.4.0 - FR 10.3.10 -->

On the Users/Groups page in System Center, a tooltip has been added to the *Edit Visio drawing* user permission with the information that the *Config* right also has to be enabled for views, elements, or services for the user to be able to edit the respective assigned Visio drawing.

#### Alarm templates: Style of toggle buttons has been made consistent with the styles used in the Cube themes [ID_37158]

<!-- MR 10.4.0 - FR 10.3.10 -->

The style of the toggle buttons in the *Included* and *Anomalies* columns of the alarm template editor as well as in the *Templates* tab of parameter drill-down pages was not consistent with the styles used in the Cube themes. This has now been rectified.

### Fixes

#### Problems when viewing a trend graph of a parameter of type string [ID_36848]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

When you viewed a trend graph of a parameter of type string, the following issues could occur:

- When the trend data switched from real-time trending to average trending while you were panning, in some cases, the graph could flip.
- The Y axis could show empty values.

#### Trending - Pattern matching: Problem when loading multivariate pattern [ID_36863]

<!-- MR 10.4.0 - FR 10.3.10 -->
<!-- For new feature included in same RN, refer to Other new features -->

When you opened a trend graph for a parameter on which a specific multivariate pattern had not been created, and the subpatterns of the pattern were all for the same protocol, a problem could occur when loading all parameters for the multivariate pattern.

#### Spectrum monitoring element no longer showed all spectrum monitor parameters [ID_37009]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you create a spectrum monitor, you can configure custom parameters. These parameters are in fact variables from the spectrum scripts, that are given more user-friendly names.

Normally, when you open a spectrum monitor element, you should be able to view all custom spectrum monitor parameters that have their *Displayed on element card* setting enabled. However, due to an issue, those parameters would no longer all be listed.

#### Visual Overview: Viewport variable also set in code when set by user [ID_37011]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when a user set the *Viewport* variable on a Resource Manager timeline component in Visual Overview, DataMiner set the variable again in the code, which caused the value to change to serialized format. While this did not cause functional changes, it could potentially cause unpredictable behavior, for example in case a condition was configured based on the value of the variable. This will now be prevented.

#### Spectrum Analysis: Preset tab loading indefinitely if no presets defined [ID_37043]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

If no preset was available for a particular spectrum element, it could occur that the *Preset* tab for the spectrum element kept loading indefinitely.

#### Trending - Pattern matching: Problem when adding and highlighting curves [ID_37174]

<!-- MR 10.4.0 - FR 10.3.10 -->

When, in a trend graph, you hovered over a pattern of which the instance of the curve was not equal to the instance of the pattern (which had its instancePartOfIdentity property set to false), the curve would incorrectly not be highlighted.

Also, incorrect curves would be added when you clicked to load the linked patterns, and incorrect curves were highlighted when you hovered over a pattern that consisted of two subpatterns from different elements.

#### DataMiner Cube v10.3.9 would receive incorrect EPM data when connected to a DataMiner Agent v10.3.8 or older [ID_37391]

<!-- MR 10.4.0 - FR 10.3.10 [CU0] -->
<!-- Not added to MR 10.4.0 -->

A DataMiner Cube version 10.3.9 would receive incorrect EPM data when connected to a DataMiner Agent version 10.3.8 or older.
