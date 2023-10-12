---
uid: Cube_Feature_Release_10.3.10
---

# DataMiner Cube Feature Release 10.3.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.10](xref:General_Feature_Release_10.3.10).

## Highlights

*No highlights have been added to this release yet.*

## Other new features

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
