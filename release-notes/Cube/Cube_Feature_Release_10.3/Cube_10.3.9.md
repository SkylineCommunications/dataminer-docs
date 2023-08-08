---
uid: Cube_Feature_Release_10.3.9
---

# DataMiner Cube Feature Release 10.3.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.9](xref:General_Feature_Release_10.3.9).

## Highlights

*No highlights have been selected yet.*

## Other new features

#### DataMiner Cube - Alarm Console: Special Elasticsearch search box always visible on systems with a Cassandra Cluster database [ID_36735]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you add a new alarm tab to the Alarm Console, that alarm tab will now always show the Elasticsearch search box when you are connected to a DataMiner System with a Cassandra Cluster database.

> [!NOTE]
> Currently, when you start typing in this search box, no suggestions are displayed yet.

#### Visual Overview: New custom color 'bg.pressededitor' for parameter controls of type 'Lite' [ID_36779]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you turn a shape into a parameter control of type "Lite", you can use the *CustomColors* option to customize the colors of that parameter control.

You can now define a new color called *bg.pressededitor*. This color will be used as background when the left mouse button is pressed within the editor part of the control.

For more information, see [CustomColors](xref:Adding_options_to_a_parameter_control#customcolors).

#### Proportional card layout: Selecting a master card [ID_36912]

<!-- MR 10.4.0 - FR 10.3.9 -->

When the card layout is set to "Proportional", you can now promote one card to master card. To do so, click the card's hamburger menu, and select the *Master card* option.

Once you have turned a card into the master card, each time you open a new card it will replace the master card.

> [!NOTE]
>
> - At any given time, there can be only one master card.
> - This feature cannot be used in conjunction with pinning. When, in a card's hamburger menu, you select the *Master card* option, the *Pin this card* option will be disabled (and vice versa).

#### Proportional card layout: Marking cards as non-closable [ID_36956]

<!-- MR 10.4.0 - FR 10.3.9 -->

When the card layout is set to "Proportional", you can now mark cards to non-closable. To do so, click the card's hamburger menu, and select the *Hide close button* option.

> [!NOTE]
> This feature cannot be used in conjunction with pinning. When, in a card's hamburger menu, you select the *Hide close button* option, the *Pin this card* option will be disabled (and vice versa).

## Changes

### Enhancements

#### Errors or alarms will no longer be generated at startup when the DMS does not include an indexing engine [ID_36590]

<!-- MR 10.4.0 - FR 10.3.9 -->

From now on, when the DataMiner System does not include an indexing engine, no run-time errors or alarms of type "Notice" will be generated for ServiceManager, TicketingManager, ResourceManager and ProfilesManager at startup.

Also, when you open the *Profiles*, *Resources* or *Bookings* app in Cube, a message will now appear, saying that the DataMiner System does not include an indexing engine.

#### Trending - Relation learning: Clearer log information [ID_36760]

<!-- MR 10.4.0 - FR 10.3.9 -->

With the introduction of time-scoped parameter relations, two different light bulb icons can now appear in a trend graph: one in the top-right corner and another one whenever you select a section of the trend graph.

When the requirements of a light bulb are not met, an entry is added to the Cube logging. From now on, these log entries will make a clearer distinction between the "relation light bulb feature" (i.e. the icon appearing in the top-right corner) and the "time-scoped relation feature" (i.e. the icon appearing when you select a trend graph section).

#### Resources: Enhanced logging when function resources failed to initialize [ID_36763]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

A more detailed entry will now be added to the Cube logging when a function resource failed to initialize.

#### Trending - Pattern matching: Enhanced error handling and performance [ID_36772]

<!-- MR 10.4.0 - FR 10.3.9 -->

A number of enhancements have been made to the pattern matching functionality, especially with regard to error handling and overall performance.

#### Visual Overview: Warning message will now appear when you embed a visual overview assigned to a view in that same visual overview [ID_36791]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

Up to now, embedding a visual overview assigned to a view in that same visual overview could cause an infinite loop, leading to the Cube client becoming unresponsive. From now on, when Cube detects that a visual overview assigned to a view in that same visual overview has been embedded, a warning message will be displayed.

#### Services module: Enhanced linking to help pages on docs.dataminer.services [ID_36813]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

A number of enhancements have been made with regard to how help buttons in the *Services* module are linked to pages on <https://docs.dataminer.services/>.

#### Trending - Behavioral anomaly detection: Alarms and suggestion events will now be displayed in the language set as UI language [ID_36828] [ID_36836]

<!-- MR 10.4.0 - FR 10.3.9 -->

All alarms and suggestion events generated following the detection of behavioral anomalies will now appear in the language set as UI language.

#### Trending - Pattern matching: Pattern occurrence values and suggestion events will now be displayed in the language set as UI language [ID_36844]

<!-- MR 10.4.0 - FR 10.3.9 -->

All pattern occurrence values and pattern occurrence suggestion events displayed in the Alarm Console will now appear in the language set as UI language.

#### Alarm Console: Enhanced performance when loading history alarms [ID_36929]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Because of a number of enhancements, overall performance has considerably increased when loading history alarms.

### Fixes

#### DataMiner Cube: Report or dashboard would not be selected after 'Email', 'Upload to FTP' or 'Upload to shared folder' action was initialized [ID_36631]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

In *Automation*, *Correlation* and *Scheduler*, you can select a report of a dashboard in an *Email*, *Upload to FTP* or *Upload to shared folder* action. When such an action was initialized, in some rare cases, the report or dashboard would not be automatically selected.

#### DataMiner Cube - Trending: Panning across the graph would not work [ID_36769]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you opened a trend graph showing trend data of a parameter that only had average trending enabled, in some cases, it would not be possible to pan across the graph.

#### DataMiner Cube - Visual Overview: Problem when opening a service chain shape while element updates were being received [ID_36794] [ID_36966]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

In some rare cases, an error could occur when, In Visual Overview, you opened a service chain shape linked to an SRM service while Resource Manager updates and DCF connection updates for the elements in that SRM service were being received.

#### DataMiner Cube - Visual Overview: Problem with [this EnhancedServiceID] placeholder [ID_36808]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

In some cases, the *[this EnhancedServiceID]* placeholder would not resolve correctly when used inside another placeholder.

For example, when you had specified `[param: [this EnhancedServiceID], 1]`, the parameter of the service element with parameter ID 1 would not be displayed correctly in the shape text.

#### DataMiner Cube - Element cards: DataMiner Connectivity Framework tables did incorrectly not have a filter box [ID_36920]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When, on the *General parameters* page of an element card, you click *Configure* next to *DataMiner Connectivity Framework*, a window with four tables is displayed. Up to now, these tables would incorrectly no longer have a filter box. From now on, they will all have a filter box again.

#### DataMiner Cube: Failing to connect to a DataMiner Agent at startup when using .NET Remoting [37022]

<!-- MR 10.4.0 - FR 10.3.9 -->

When starting up, in some rare cases, Cube could fail to connect to a DataMiner Agent when using .NET Remoting. Moreover, any further connection attempts made within that same Cube session would also fail. Users were required to close Cube and restart it.

Symptoms:

- The login screen would display the following error message: `Start the DataMiner software manually or contact your system administrator.`
- The Cube logging would contain a `Login failed.` entry mentioning `Cannot accept SOAP messages (text/xml)`.

#### Problems when selecting report in Automation or Scheduler module [ID_37052]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

In the Automation or Scheduler module, when you selected a report for the email, FTP, or shared folder action, the following issues could occur:

- In some cases, the "required info" label was not shown.
- When you switched from a different action to the email, FTP, or shared folder action, it could occur that the list of selectable reports and dashboards was not loaded in the dropdown boxes.
