---
uid: General_Main_Release_10.2.0_CU15
---

# General Main Release 10.2.0 CU15

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Dashboards app & Low-Code Apps - Table component: Enhanced visibility of rows that are selected or hovered over in dark mode [ID_35993]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.5 -->

When a dashboard or a low-code app is in dark mode, from now on, there will be a higher color contrast between rows that are selected or hovered over and rows that are not.

#### SLLogCollector now also collects SyncInfo files [ID_35995]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

SLLogCollector packages will now also include all files found in `C:\Skyline DataMiner\Files\SyncInfo` relevant for troubleshooting.

#### DataMiner Cube - System Center: Enhancements made to Database > Offload section [ID_36037]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In *System Center*, a few enhancements have been made to the *Database > Offload* section:

- When you set *Type* to "Database", select *Trend data* in the *Offloads* section, and set the frequency under *Enable data offload* to "permanently", the time indication (e.g "starting every day at") will no longer be shown.

- When you set *Type* to "Database" and select *Parameter value* in the *Offloads* section, from now on, you will no longer be able to set the frequency under *Enable snapshot offload* to "permanently".

  > [!IMPORTANT]
  > If, before upgrading to this DataMiner version, *Parameter value* was selected and the frequency was set to "permanently", *Parameter value* will no longer be selected after upgrading. As a result, no snapshot will be offloaded until you reconfigure the snapshot offload settings.

#### Dashboards app & Low-Code Apps: Web component now supports hyperlinks with a target attribute [ID_36159]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

A web component now supports hyperlinks with a target attribute.

Example: `<a href="http://www.skyline.be" target="_blank">Skyline Communications</a>`

### Fixes

#### Cassandra Cluster Migrator tool would incorrectly not migrate the state-changes table from a single-node Cassandra to a Cassandra Cluster [ID_35699]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.4 -->

When you used the Cassandra Cluster Migrator tool to migrate a single-node Cassandra database to a Cassandra Cluster setup, up to now, the `state-changes` table would incorrectly not be migrated.

#### Dashboards app & Low-Code Apps - GQI components: Open sessions would not be closed when a new query was triggered [ID_35824]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU2] - FR 10.3.5 -->

When a GQI component still had a session open when a new query was triggered, in some cases, the open session would incorrectly not be closed.

#### Improved error handling when elements go into an error state [ID_35944] [ID_36198]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When an element goes into an error state after an attempt to activate it failed, from now on, no more calls to SLProtocol, SLElement or SLSpectrum will be made for that element.

Also, when an element that generates DVE child elements or virtual functions goes into an error state, from now on, the generated DVE child elements or virtual functions will also go into an error state. However, in order to avoid too many alarms to be generated, only one alarm (for the main element) will be generated.

The following issues have also been fixed:

- When a DVE parent element in an error state on DataMiner startup was activated, its DVE child elements or virtual functions would not be properly loaded.

- When a DVE parent element was started, the method that has to make sure that ElementInfo and ElementData are in sync would incorrectly not check all child elements.

#### Creating or updating a function resource while its parent element was in an error state would incorrectly be allowed [ID_35963]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you created or updated a function resource while its parent element was in an error state, up to now, the state of that parent element would not be checked correctly. As a result, adding or updating the function resource would incorrectly be allowed.

From now on, when you create or update a function resource while its parent element is in an error state, an error will be thrown.

#### Dashboards app & Low-Code Apps - Table component: Selection issues [ID_35968]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When a GQI table was configured to feed the selected rows to another component, the following issues could occur:

- When you selected a row above a row that had been selected earlier, that row would not get fed.

- When you tried to select multiple rows using SHIFT+Click, this would not work when you selected the rows bottom to top.

- When you selected a single row that was already selected as part of a multiple select, the feed would not be updated.

- When you exported the selected rows to a CSV file, the CSV file would incorrectly contain all rows instead of only the ones you had selected.

#### Business Intelligence: Problem when a replicated SLA was stopped or deleted [ID_35973]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, an error could occur when a replicated SLA was stopped or deleted.

#### Cassandra: Cleared alarms would incorrectly be added to the activealarms table and never removed [ID_36002]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

Cleared alarms would incorrectly be added to the activealarms table and never removed.

#### DataMiner Cube - EPM: KPI histogram would incorrectly not be shown [ID_36004]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When, in a topology chain, you opened a KPI window and clicked the histogram icon, in some cases, the histogram window would be empty.

#### Spectrum analysis: Measurement points would not be set correctly [ID_36005]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, measurement points would not be set correctly when a trace was being displayed.

#### Dashboards app & Low-Code Apps: Component title could be made too large [ID_36021]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In a custom component theme, for some fonts, the font size of the title could be set to a value higher than 36px, causing the component title to be larger than its container. Also, in some cases, the font size could incorrectly be set to 0px.

From now on, font sizes will have to be set to a value between 1px and 36px.

#### Virtual functions linked to a parameter with a hysteresis timer could be assigned an incorrect alarm severity [ID_36024]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When a virtual function was linked to a parameter that had a hysteresis timer running, in some cases, that virtual function would be assigned an incorrect alarm severity.

#### NT Notify type NT_GET_BITRATE_DELTA would return incorrect values [ID_36025]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, NT Notify type NT_GET_BITRATE_DELTA (269) would return incorrect bitrate counter values when an SNMPv3 element was going into or coming out of a timeout state.

#### SLReset.exe would not clean an Elasticsearch database when no <DB> element was specified in DB.xml [ID_36040]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When, in the *DB.xml* file, no `<DB>` element was specified for an Elasticsearch database, the factory reset tool *SLReset.exe* would not clean that database when the `cleanclustereddatabases` option had been used.

From now on, when no `<DB>` element is specified for a Elasticsearch database, *SLReset.exe* will use the default database name "dms".

#### Business Intelligence: Alarms that had to be replayed would incorrectly have their weight recalculated [ID_36051]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When an SLA has to process alarms generated due to history sets or alarms generated with hysteresis enabled, those alarms are replayed to ensure that the outages contain the correct information.

Up to now, when an alarm was fetched from a logger table in order to be replayed, the system would incorrectly recalculate its weight instead of taking into account its previously calculated weight stored in the logger table.

> [!NOTE]
> When you change an SLA's violation settings, offline windows, etc., we recommend resetting that SLA as the alarm weights of previously processed alarms will not be recalculated retroactively.

#### DataMiner Cube - EPM: Navigation issues [ID_36089]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you opened an EPM card by clicking an alarm in the Alarm Console or switched between two EPM cards while the *Topology* pane was open in the sidebar, the topology filters would incorrectly not be updated.

Also, when, on a system where the *Topology* pane was open when you connected to it, you opened a new card or selected an open card, the topology filters would incorrectly not be updated until you navigated away from the *Topology* pane and back.

#### DataMiner Cube - Alarm Console: Filtered history tab would incorrectly not show information events [ID_36105]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you added a filtered history tab that had to show active alarms, masked alarms and information events, no information events would be shown.

#### Low-Code Apps: Problem when updating header titles [ID_36116]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When, while editing a low-code app with more than one header bar option, you selected another header bar option, the label of the previously selected header bar option would incorrectly still be displayed in the side panel.

#### Dashboards app & Low-Code Apps: Popup panel showing a PDF preview would incorrectly have a scroll bar [ID_36131]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, the popup panel showing the PDF preview of a dashboard would incorrectly have a scroll bar.

From now on, a popup panel showing a PDF preview will take the full screen height and will only allow its contents to scroll.

#### Dashboards app: Problem when pressing an arrow key in the 'Create dashboard' window [ID_36146]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In the *Create dashboard* window, pressing an arrow key while one of the text boxes had the focus would incorrectly cause the *OK* or *Cancel* button to become selected.

#### Problem when multiple clients had subscribed to a cell of a partial table [ID_36148]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When multiple clients had subscribed to a cell of a partial table, in some cases, deleting the row or renaming the row via a display key would not trigger a deletion of the cell in the subscription.

#### GQI: Web services API would not be able to correctly translate a server query to a web query [ID_36173]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.5 [CU0] -->

In some cases, the web services API would not be able to correctly translate a server query to a web query.

#### Visual Overview - DataMiner Connectivity Framework: Active path would incorrectly not be highlighted [ID_36204]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When a visual overview had been configured to highlight the active path, in some rare cases, the active path would incorrectly not be highlighted.

#### DataMiner Cube - Visual Overview: Problem when using placeholders in shape data fields of type 'ChildrenFilter' [ID_36227]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

Up to now, using placeholders in shape data fields of type *ChildrenFilter* could, in some cases, cause incorrect filtering behavior. From now on, when placeholders are used in shape data fields of type *ChildrenFilter*, filtering will be applied correctly.

#### DataMiner Cube - Alarm Console: First underscore would incorrectly be omitted from element, service and view names in 'Open' submenu [ID_36266]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you right-click an alarm and hover over *Open*, the submenu that appears will list the names of the elements, the services and the views associated with that alarm. Up to now, when those names contained underscores, the first underscore would incorrectly be omitted.

#### Protocols: QAction syntax errors did not refer to the correct lines [ID_36301]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, before a QAction was compiled, three compiler directives were added to its source code. As a result, all compilation errors would refer to incorrect line numbers.

From now on, the compiler directives will no longer be added to the source code. Instead, they will be passed to the compiler directly.
