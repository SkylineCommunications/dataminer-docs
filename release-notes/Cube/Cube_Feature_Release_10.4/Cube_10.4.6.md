---
uid: Cube_Feature_Release_10.4.6
---

# DataMiner Cube Feature Release 10.4.6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.6](xref:General_Feature_Release_10.4.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.6](xref:Web_apps_Feature_Release_10.4.6).

## New features

#### SPI logging: An SPI log entry will now be generated when you create a new alarm tab [ID 39382]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When you create a new alarm tab, an SPI log entry will be generated containing the following information:

- the time it took for the alarm tab to load,
- the time it took to retrieve, process, group and sort the alarms,
- the filter that was applied,
- the time range that was set (in case of a history tab), and
- the number of alarms that were loaded.

## Changes

### Enhancements

#### System Center: Certain sections will no longer be visible when connected to a DaaS system [ID 39173]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When DataMiner Cube is connected to a DaaS system, in *System Center*, the following sections will no longer be visible:

- *Database > General*
- *Backup*
- *Search & Indexing > Indexing engine*
- *System settings > Time to live*
- *Tools > Query executer*

Also, when DataMiner Cube is connected to a DaaS system, the *Indexing* app will no longer be visible, even when the *Indexing* soft-launch option is enabled.

#### Alarm Console: Enhanced performance when loading a large number of alarms in an active alarms tab [ID 39235] [ID 39236]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when loading a large number of alarms into an active alarm tab.

#### Visual Overview: Enhanced performance when processing conditions based on view names, service names or element names [ID 39241]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when processing conditions based on view names, service names or element names.

#### Enhanced processing of web API exceptions occurring in DataMiner Cube [ID 39270]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

A number of enhancements have been made with regard to the processing of web API exceptions occurring in DataMiner Cube. After a web API exception has been properly processed, a clear log entry will now also be added to the Cube logging.

#### Alarm Console: Enhanced performance when retrieving the side panel data after selecting an alarm [ID 39284]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

For each alarm tab, you can open a side panel in the Alarm Console showing the real-time value and history of a selected alarm.

Because of a number of enhancements, overall performance has now increased when retrieving this side panel data after selecting an alarm.

#### SPI logging: Loading time of a visual overview will now include the loading times of all embedded visual overviews [ID 39351]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In SPI log entries indicating how long it took to load a visual overview, from now on, the total loading time of a visual overview will include the loading times of all visual overviews embedded in that visual overview.

#### SPI logging: No SPI log entry will be generated when the DMA to which you are connecting is starting, restarting or upgrading [ID 39502]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When you have connected to a DataMiner Agent, an SPI log entry is generated, indicating how long the connection process took.

Up to now, when the DataMiner Agent was starting, restarting or upgrading while you were connecting to it, the startup time of the DataMiner Agent would be included in the connection duration indicated in the above-mentioned SPI log entry.

From now on, when the DataMiner Agent to which you are connecting is starting, restarting or upgrading, no SPI log entry will be generated.

### Fixes

#### Memory leak in Alarm Console [ID 38819]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

In some cases, the Alarm Console could leak memory.

#### Spectrum monitors: Parameter positions would incorrectly be reused [ID 39225]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When, while editing a spectrum monitor, you clicked *Group parameters* to ungroup all parameters, the parameter positions would incorrectly be reused when multiple parameters and multiple measurement points from the same monitor script were being used.

From now on, when you click *Group parameters* to ungroup all parameters, the parameter positions will no longer be reused.

#### Problem when opening a card [ID 39251]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When you opened a card, in some cases, the data on the card would not get loaded. As a result, the card would remain empty.

#### Trend graph would show "no data" due to primary key being replaced by the display key in the trend data request [ID 39258]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some rare cases, a trend graph for a particular parameter would show "no data". This was due to the primary key being replaced by the display key in the message that requested the trend data to be displayed.

#### Visual Overview: Problem with placeholder value update detection [ID 39325]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some cases, the algorithm that had to detect placeholder value updates would work incorrectly. When a placeholder value had been changed, it would incorrectly not report a value change, and when a placeholder value had not been changed, it would incorrectly report a value change.

#### Memory leak in Alarm Console [ID 39366]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

In some cases, the Alarm Console could leak memory.

#### Alarm Console: No longer possible to filter based on focus after having selected 'Statistical view' or 'Reports view' [ID 39388]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When, in the *Alarm Console*, you had selected *Statistical view* or *Reports view*, it would incorrectly no longer be possible to filter alarms based on focus.

#### Visual Overview: Problem when a session variable in a URL of an embedded web browser was updated [ID 39403]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When, in Visual Overview, a session variable in a URL of an embedded web browser was updated, in some cases, an exception could be thrown.

#### Alarm Console: Not possible to open new suggestion event tabs when 'Behavioral Anomaly Detection' was disabled in System Center [ID 39415]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When *Behavioral Anomaly Detection* was disabled in *System Center > System settings > Analytics Config*, up to now, it would incorrectly not be possible to open new suggestion event tabs in the Alarm Console, even though suggestion events are also created by *Pattern Matching* and *Proactive Cap Detection*.

From now on, it will be possible to open new suggestion event tabs in the Alarm Console when at least one of the following Analytics features is enabled: *Proactive Cap Detection*, *Behavioral Anomaly Detection* or *Pattern Matching*.

#### Dialog box controls showing underlined text and opening up a dropdown list when clicked would not open their dropdown list when you pressed ALT+DOWN [ID 39423]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

A dialog box control showing underlined text and opening up a dropdown list when clicked (e.g., the severity selector in a *New alarm* action of a correlation rule) would incorrectly not open its dropdown list when you pressed ALT+DOWN.

#### Visual Overview: Problem when combining static and variable values when dynamically positioning shapes [ID 39459]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When a shape contained *XPos* and *YPos* data fields to allow it to be positioned dynamically, those fields would be resolved incorrectly when one contained a static value while the other contained a [param:] placeholder that retrieved a value from a table.

#### Visual Overview: Conditional shape manipulation actions 'Show' and 'Hide' would not always get performed correctly [ID 39525]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 [CU0] -->

In some cases, the conditional shape manipulation actions *Show* and *Hide* would not get performed correctly.
