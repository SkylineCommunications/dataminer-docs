---
uid: Cube_Main_Release_10.3.0_CU6
---

# DataMiner Cube Main Release 10.3.0 CU6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU6](xref:General_Main_Release_10.3.0_CU6).

### Enhancements

#### Resources: Enhanced logging when function resources failed to initialize [ID_36763]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

A more detailed entry will now be added to the Cube logging when a function resource failed to initialize.

#### Visual Overview: Warning message will now appear when you embed a visual overview assigned to a view in that same visual overview [ID_36791]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

Up to now, embedding a visual overview assigned to a view in that same visual overview could cause an infinite loop, leading to the Cube client becoming unresponsive. From now on, when Cube detects that a visual overview assigned to a view in that same visual overview has been embedded, a warning message will be displayed.

#### Services module: Enhanced linking to help pages on docs.dataminer.services [ID_36813]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

A number of enhancements have been made with regard to how help buttons in the *Services* module are linked to pages on <https://docs.dataminer.services/>.

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

#### Problems when selecting report in Automation or Scheduler module [ID_37052]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

In the Automation or Scheduler module, when you selected a report for the email, FTP, or shared folder action, the following issues could occur:

- In some cases, the "required info" label was not shown.
- When you switched from a different action to the email, FTP, or shared folder action, it could occur that the list of selectable reports and dashboards was not loaded in the dropdown boxes.
