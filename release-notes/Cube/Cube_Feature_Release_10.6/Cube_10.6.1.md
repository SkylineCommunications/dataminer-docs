---
uid: Cube_Feature_Release_10.6.1
---

# DataMiner Cube Feature Release 10.6.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU22] and 10.5.0 [CU10].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.1](xref:General_Feature_Release_10.6.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.1](xref:Web_apps_Feature_Release_10.6.1).

## Highlights

*No highlights have been selected yet.*

## New features

#### Trending: Trend graphs will now show relational anomalies [ID 43857]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

When you open a trend graph of a parameter with relational anomalies, from now on, these anomalies will be indicated by tags.

Hovering over a tag button or right-clicking and selecting *Expand tags* will highlight the anomalies in orange.

Additionally, a "+" icon will appear on the right of an anomaly tag in the following cases:

- the tag indicates a multi-variate trend pattern match, or
- not all parameters associated with the anomaly are displayed on the trend graph.

Clicking a "+" icon will load all parameters associated with the multi-variate trend pattern or the anomaly.

> [!IMPORTANT]
> This feature will only work in conjunction with DataMiner server version 10.6.0/10.5.12 or newer.<!-- RN 43720 -->

## Changes

### Enhancements

#### System Center: Enhanced embedding of DOM definition-level security app on cloud-connected systems [ID 43975]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

A number of enhancements have been made to the way in which the DOM definition-level security app is embedded in System Center.

Up to now, when you went to *System Center > DOM* while being connected to a cloud-connected DataMiner Agent, you had to click a hyperlink to open the app in a browser window.

From now on, when you go to *System Center > DOM* while being connected to a cloud-connected DataMiner Agent running at least Main Release version 10.6.0 or Feature Release version 10.5.12, after entering your credentials, you will immediately see the app, fully embedded in System Center. The session will be kept alive until System Center is closed.

Also, up to now, when you made a change in the embedded app and switched to another tab in System Center, that change would not be kept when you had not clicked the *Apply* button. From now on, all changes made in the embedded app will be kept until you close System Center.

#### Trending: Double-clicking the alarm group of a multi-variate trend pattern will now open a trend graph showing all parameters involved in the multi-variate trend pattern [ID 43994]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

When, in the Alarm Console, you double-click the alarm group of a multi-variate trend pattern, from now on, a trend graph will open, showing all parameters involved in the pattern alarm group (up to a maximum of 10).

#### Alarm Console: Alarm count enhancements [ID 44011]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

Up to now, when DataMiner Cube sent an alarm count request to the DataMiner System to which it was connected, it would always send the request to each of the DataMiner Agents in that DMS. As a result, it would receive an incorrect number of alarms when the DataMiner System included a STaaS database, a Cassandra Cluster database, or an indexing engine (Elasticsearch or OpenSearch) with the *Enable indexing on alarms* option enabled.

From now on, when the DMS includes a STaaS database, a Cassandra Cluster database, or an indexing engine (Elasticsearch or OpenSearch) with the *Enable indexing on alarms* option enabled, Cube will only send alarm count requests to the DMA to which it is connected. If the DMS includes a database other than those listed above, it will still send alarm count requests to each of the DMAs in the DMS.

#### SPI log entries containing the duration of an SRM server call will now include either the number of objects or the requested object ID [ID 44014]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

From now on, SPI log entries containing the duration of an SRM server call will now include either the number of objects or the requested object ID.

#### System Center: Query executor and indexing engine settings will no longer be available when the DMS is using STaaS [ID 44018]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

When Cube is connected to a DataMiner System using STaaS:

- In the *Tools* section of *System Center*, the query executor will no longer be available.
- In the *Search & indexing* section of *System Center*, the indexing engine settings will no longer be available.

Also, when an exception is thrown when Cube tries to use the MigrationManagerHelper, an error will now be logged in the Cube logging.

### Fixes

#### Automation: Not possible to save a script after changing the 'Wait for positive result for at most' option of an If condition [ID 44032]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

When, while editing an Automation script, you changed the *Wait for positive result for at most* option of an *If* condition, up to now, the *Save script* button would incorrectly remain disabled, preventing you from saving the script. The *Save script* button would only be enabled after you had made another change to the script.

Also, up to now, it would incorrectly be possible to save a script to which you added an If block without any conditions. From now on, the *Add condition* selection box will have a red border until you add a condition.

#### Visual Overview: Problem with [servicedefinitionfilter] placeholder [ID 44054]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

In a Visio file linked to a service, the [servicedefinitionfilter] placeholder can be used to refer to the row filter of an included table parameter.

Up to now, in some cases, a primary key prefix, which is added to this filter for configuration purposes, would incorrectly not get removed before the filter was applied. From now on, this prefix will always be removed before the filter is applied.

#### Alarm Console: Correlation alarms that had disappeared because the element in question had been stopped, paused, deleted, or restarted, would incorrectly re-appear [ID 44087]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

When, in the Alarm Console, there is a correlation alarm, the moment you stop, pause, delete, or restart the element on which that correlated alarm was triggered, it will automatically disappear from the Alarm Console.

However, up to now, when you created a new alarm tab, any correlation alarm that had disappeared because the element in question had been stopped, paused, deleted, or restarted, would incorrectly re-appear.

#### Service & Resource Management: Service Manager would incorrectly be registered each time you switched to another workspace [ID 44106]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

Up to now, the Service Manager would incorrectly be registered each time you switched to another workspace.

From now on, the Service Manager will only be registered once.
