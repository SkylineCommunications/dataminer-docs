---
uid: Cube_Feature_Release_10.3.11
---

# DataMiner Cube Feature Release 10.3.11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.3.11](xref:General_Feature_Release_10.3.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.11](xref:Web_apps_Feature_Release_10.3.11).

## New features

#### Spectrum analysis: Panning horizontally inside a spectrum window [ID 37284]

<!-- MR 10.4.0 - FR 10.3.11 -->

It is now possible to pan horizontally inside a spectrum window by clicking and dragging.

When, after clicking the left mouse button, you start dragging, the following will happen:

- The spectrum trace will move to the left or the right while being refreshed at a rate equal to the original rate.
- The start, stop and center frequency labels on the X axis will continuously update to reflect the ongoing change.
- The unknown part of the trace (i.e. the frequency range located outside of the original span) will be visualized as a grey area with a grid in the background.

When you stop dragging and release the left mouse button, the panning dimensions will be set on the spectrum analyzer device and the screen will be updated with the new data.

Only upon releasing the left mouse button will the unknown part of the trace be requested from the spectrum analyzer. The newly received trace points will then replace the grey area and a new, uniform spectrum trace will be displayed based on the new center frequency.

> [!IMPORTANT]
> This feature is only available if the spectrum protocol includes the *Start Frequency*, *Center Frequency* and *Stop Frequency* parameters.

#### Credentials Library now supports username and password credentials [ID 37416]

<!-- MR 10.4.0 - FR 10.3.11 -->

In the Credentials Library in DataMiner Cube (available via *System Center* > *System Settings* > *Credentials Library*), you can now configure a new type of credentials, i.e. username and password credentials. To do so, in the *Type* dropdown, select *Username and password credentials*, and then specify the username and password.

#### Spectrum analysis: Panning vertically inside a spectrum window [ID 37461]

<!-- MR 10.4.0 - FR 10.3.11 -->

It is now possible to pan vertically inside a spectrum window by Ctrl+clicking and dragging.

When, after pressing the Ctrl key and clicking the left mouse button, you start dragging, the following will happen:

- The spectrum trace will move up or down while being refreshed at a rate equal to the original rate.
- The amplitude labels on the Y axis will continuously update to reflect the ongoing change.
- The unknown part of the trace (i.e. the amplitude range located outside of the original span) will be visualized as a grey area with a grid in the background.

When you stop dragging and release the left mouse button, the panning dimensions will be set on the spectrum analyzer device and the screen will be updated with the new data.

Only upon releasing the left mouse button will the unknown part of the trace be requested from the spectrum analyzer. The newly received trace points will then replace the grey area and a new, uniform spectrum trace will be displayed based on the new reference level.

> [!IMPORTANT]
> This feature is only available if the spectrum protocol includes the *Reference level* parameter.

## Changes

### Enhancements

#### Opening element card for DVE alarm from Alarm Console did not work correctly [ID 37297]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When you opened the element card for an alarm on a parameter of a DVE element from the Alarm Console, this did not have the same behavior as for regular alarms. Now this action will open the trend graph of the parameter if the parameter is trended, or otherwise it will show the parameter details.

#### CefSharp package download enhancements [ID 37319]

<!-- MR 10.4.0 - FR 10.3.11 -->

From now on, when DataMiner Cube has to download the CefSharp package from a DataMiner Agent, it will first try to download it via HTTPS, and if HTTPS is not configured, it will try again via HTTP.

#### System Center: Length of Cassandra database name restricted to max. 20 characters [ID 37340]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When you configure a Cassandra database in the *Database* section of *System Center*, from now on, the database name will no longer be allowed to be longer than 20 characters.

### Fixes

#### Trending: Problem when editing a trend pattern on a graph other than the one on which the pattern was created [ID 37191]

<!-- MR 10.4.0 - FR 10.3.11 -->

When you edited a trend pattern on a trend graph, up to now, the trend data on the graph on which the pattern was created would incorrectly be used instead. From now on, the trend data in the selected part of the graph will be used.

#### Alarm Console : Problem when a correlation/incident alarm got cleared [ID 37231]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

On a system with a large number of correlation/incident alarms, in some cases, an error could occur when one of those alarms was cleared. That alarm would then incorrectly remain visible in the Alarm Console.

#### System Center - Database: No longer possible to create and delete database configurations in the Offload and Other tabs when Type was set to 'Database per cluster' [ID 37254]

<!-- MR 10.4.0 - FR 10.3.11 -->

In the *Database* section of *System Center*, when *Type* was set to "Database per cluster" in the *General* tab, creating and deleting database configurations in the *Offload* and *Other* tabs would no longer work.

#### Trend templates: Offload settings would be lost when you disabled to 'Allow Offload Database Configuration' option [ID 37268]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In a trend template, you can configure the data offload settings for a particular parameter by clicking the cogwheel, enabling the *Allow Offload Database Configuration* option and configuring the settings in two dedicated columns.

Up to now, when you disabled the *Allow Offload Database Configuration* option, the two dedicated columns would disappear and the offload settings would be lost. From now on, when you disable the *Allow Offload Database Configuration* option, the offload settings that were specified will be kept and will re-appear when you enable the *Allow Offload Database Configuration* option again.

Also, when you open a trend template in which offload settings have been specified, from now on, the two dedicated columns will be visible by default.

#### Trending: Problem with Y axis labels on trend graphs showing data from string and non-string parameters [ID 37281]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you opened a trend graph showing trend data of a parameter of type string, and you added another, non-string parameter to that same graph, the Y axis of the newly added parameter would not be rendered correctly. The labels would be placed too close to each other, making them unreadable.

#### Alarm Console: Problem when creating a linked alarm tab while connected to a system with a large number of correlated/incident alarms [ID 37332]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When, in the Alarm Console, you created a linked alarm tab while connected to a system with a large number of correlated/incident alarms, in some cases, Cube could become unresponsive for a while until the tab was loaded.

#### No breadcrumbs would be displayed when you opened a service card [ID 37384]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you opened a service card, in some rare cases, no breadcrumbs would be displayed.

#### Visual Overview: No longer possible to return to the initially selected page when the VdxPage property was linked to a session variable [ID 37419]

<!-- MR 10.4.0 - FR 10.3.11 -->

In a visual overview containing multiple pages, it would no longer be possible to return to the initially selected page when the shape used to switch pages had its `VdxPage` property updated using a session variable.

#### DataMiner Cube: Parameter value with decimals would be displayed incorrectly in context menus [ID 37420]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

Up to now, when you opened a context menu with a text box that contained a parameter value with decimals, and the default value of the parameter also contained decimals, the decimal point in the value in the text box would be displayed incorrectly. For example, 44.2 would incorrectly be displayed as 442.0.

The issue was due to Cube trying to parse the default value with the current culture in the Windows machine.

#### Trending: Problem when trying to edit a multivariate pattern [ID 37433]

<!-- MR 10.4.0 - FR 10.3.11 -->

Due to a cache synchronization issue, problems could occur when trying to edit a multivariate pattern of which one of the elements is located on another DataMiner Agent.

#### DataMiner Cube could become unresponsive during startup when the Alarm Console did not contain any alarm tabs [ID 37436]

<!-- MR 10.4.0 - FR 10.3.11 -->

When starting up, DataMiner Cube could become unresponsive during the *Connected!* step When the Alarm Console did not contain any alarm tabs.

#### Automation app: Problems with scripts using user-defined APIs [ID 37442]

<!-- MR 10.4.0 - FR 10.3.11 -->

When you opened the Automation app, an exception could be thrown in the background when verifying if scripts used user-defined APIs.

Also, when you clicked *Configure API* for a particular automation script, the *New token* button would incorrectly be disabled.

#### DataMiner Cube - Alarm Console: Tooltip of suggestion counter would incorrectly show 'suggestion' in capitals [ID 37454]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In the Alarm Console footer, you can find counters that display the number of alarms in the current tab per severity. When you hover over one of those counters, a tooltip appears with the text "[nr of alarms] [severity]" (e.g. 31 Major).

Up to now, when you hovered over the suggestions counter, the tooltip would incorrectly show the word "SUGGESTION" in capitals. From now on, it will be shown as "Suggestion" (with capital S).

#### Alarm Console: Light bulb would not show suggestions related to the current tab when Cube was started with only one alarm tab [ID 37458]

<!-- MR 10.4.0 - FR 10.3.11 -->
<!-- Not added to MR 10.4.0 -->

When DataMiner Cube was started with only one alarm tab, the Alarm Console lightbulb would incorrectly not show any suggestions related to the current alarm tab.

#### Problem when loading elements [ID 37539]

<!-- MR 10.4.0 - FR 10.3.11 [CU0] -->
<!-- Not added to MR 10.4.0 -->

Due to an exception being thrown when requesting database information, DataMiner Cube would fail to load elements.
