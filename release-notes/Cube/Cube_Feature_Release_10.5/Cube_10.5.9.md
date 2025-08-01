---
uid: Cube_Feature_Release_10.5.9
---

# DataMiner Cube Feature Release 10.5.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU18] and 10.5.0 [CU6].

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

#### Relational anomaly detection: Suggestion event values will now include parameter labels [ID 42933]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When a label was assigned to a parameter instance in a relational anomaly detection (RAD) parameter group, from now on, that label will be added to the value of every suggestion event that is generated whenever a relational anomaly is detected for that parameter in question.

- If a label was assigned to the parameter, the value of the suggestion event will have the following syntax: `Relational anomaly: {ParameterGroupName} (ParameterLabel)`.
- If no label was assigned to the parameter, the value of the suggestion event will have the following syntax: `Relational anomaly: {ParameterGroupName}`.

#### System Center - Agents: 'Agent cluster' section no longer visible when selecting a DaaS system [ID 43110]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, in the *Agents* section of *System Center*, you select a DaaS system, from now on, the *Agent cluster* section will no longer be visible. This means that you will not be able the click the *Join cluster* and *Leave cluster* buttons.

Also, when there are any DaaS systems in the cluster to which you are connected, you will no longer be able to click the *Add* and *Remove* buttons.

#### Popup windows containing an embedded Microsoft Edge browser window will now include an additional warning [ID 43131]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When DataMiner Cube is using the Microsoft Edge (WebView2) browser engine to display embedded webpages, popup windows containing an embedded web page will now show a banner saying that embedding a Microsoft Edge browser window within a popup window is not fully supported.

#### Security: User permission 'General > View > Add/remove elements' renamed to 'Add/remove items (elements, services, etc.)' [ID 43215]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

As the *Add/remove elements* user permission in *General > Views* allows users to also add or remove other items, including services, measurement points, service templates, redundancy groups, redundancy templates, etc., this user permission has now been renamed to *Add/remove items (elements, services, etc.)*.

#### Alarm Console: Enhanced performance when loading alarms into a linked alarm tab [ID 43218]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Because of a number of enhancements, overall performance has increased when loading alarms into a linked alarm tab, especially on systems with a large number of correlation alarms or a large number of base alarms.

#### Profiles module: Enhanced performance when loading profiles [ID 43235]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Because of a number of enhancements, overall performance has increased when loading profiles into the *Profiles* module.

#### Edge/WebView2 browser engine now supports CTRL+F search functionality [ID 43241]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In DataMiner Cube, up to now, when the Microsoft Edge (WebView2) browser engine was used to display embedded webpages, it was not possible to enter CTRL+F in order to search for a particular text string. This has now been made possible.

#### Properties: Enhanced visualization of element and service properties [ID 43409]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

A number of enhancements have been made to the way in which element and service properties are displayed in the *Properties* window.

- All datetime values are now displayed in UTC time. They will no longer be converted to client time.
- The *Created* and *Created by* values will now be displayed as one single value.
- The *Modified* and *Modified by* values will now be displayed as one single value.

#### Credentials library: Passwords in credentials of type 'Username and password' will no longer be limited in size [ID 43422]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, credentials of type *Username and password* allowed passwords up to 43 characters.

From now on, passwords in this type of credentials will no longer be limited in size, allowing for stronger and more secure authentication.

> [!NOTE]
> This change only applies to credentials of type *Username and password*. Other credentials that include a password (e.g. credentials of type *SNMPv3*) will still only support passwords up to 43 characters.

#### Default web browser engine will now be Edge instead of Chromium [ID 43429]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

From now on, in DataMiner Cube, the default web browser engine will be Edge instead of Chromium.

- In *System Center > System settings > Plugins*, it will no longer be possible to select Chromium as default web browser engine.
- If, in any visual overview, there are shapes in which the *UseChrome* option is specified, this option will now be disregarded. The shapes in question will use Edge instead.

### Fixes

#### System Center - SNMP forwarding: 'Resend all active alarms every' option would incorrectly be set to 0 [ID 43206]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, in the *SNMP forwarding* section of *System Center*, you had created a new SNMP manager, up to now, the *Resend all active alarms every* option in the *Resend* tab would by default incorrectly be set to 0. From now on, this option will by default be set to 30 seconds.

Also, up to now, users would incorrectly be allowed to manually set this option to 0 seconds. From now on, the minimum allowed value will be 1 second.

In order to prevent any issues from occurring because of a *Resend all active alarms every* option having been set to 0, DataMiner Agents will now automatically interpret a value set to 0 as being a value set to 30 seconds.

#### Problem when loading apps in the Apps pane [ID 43208]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, when an error occurred while loading apps in the *Apps* pane, in some cases, Cube could stop working.

#### Trending: Problem when the row index of a table column parameter contained trailing spaces [ID 43211]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When the trend key of a table column parameter was requested, an error would occur when the row index contained trailing spaces, especially when the key was used in a table filter like `VALUE=DK == xxx`.

In order to prevent issues caused by trailing spaces in row indices, Cube will now use a `FULLFILTER=` filter instead of a `VALUE=` filter. A `FULLFILTER=` filter allows the row index to be passed within single quotes.

#### Trending: Problem when clicking a pattern in a trend graph [ID 43228]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When you clicked a pattern in a trend graph, an exception would be thrown, and the following error would be logged:

`An item with the same key has already been added.`

#### Settings: Problem with card-specific alarm tab settings [ID 43280]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In the *Settings* window, you can configure card-specific alarm tab settings on user level as well as on group level.

Up to now, in some cases, when you checked card-specific alarm tab settings configured on user level, you would incorrectly not see certain settings that had been configured on group level. Also, when you checked settings configured for a particular group, you would incorrectly see settings that had been configured for another group.

Also, when, in the *Settings* window, you went to *Alarm Console > Card-specific*, up to now, the *Card types* list would not show the card types that had been enforced on group level.

#### Logging: Problem with SPI event log entries not getting transmitted to the DataMiner Agent [ID 43344]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, SPI event log entries (e.g. "Cube Connection") would not get transmitted to the DataMiner Agent.

#### Trending: Y-axis labels of histogram charts would incorrectly be displayed in the middle of the Y axis [ID 43348]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In histogram charts, in some cases, the Y-axis label would incorrectly be displayed in the middle of the Y axis instead of at the top.

#### Trending: Problem when loading a trend graph of an EPM KPI [ID 43354]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some rare cases, a trend graph of an EPM KPI would incorrectly not get loaded.

#### Visual Overview: Element, service or view updates would incorrectly cause embedded visual overviews to refresh [ID 43395]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, when a element, service or view was updated, in some cases, visual overviews embedded in the visual overview linked to the element, service or view would incorrectly be fully refreshed.

From now on, embedded visual overviews will only be fully refreshed when the referenced object was changed.

#### Trending: Trend prediction data would incorrectly be requested when 'Trend prediction' setting was disabled [ID 43414]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When the *Trend prediction* setting had been disabled in the *System settings > Analytics config* section of *System Center*, up to now, Cube would incorrectly still request trend prediction data when you opened a trend graph.
