---
uid: General_Main_Release_10.2.0_CU12
---

# General Main Release 10.2.0 CU12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLElement: Enhanced alarm locking [ID_34561]

<!-- MR 10.2.0 [CU12] - FR 10.2.12 -->

Alarm locking in the SLElement process has been enhanced.

#### Enhanced parameter locking in SLElement [ID_34688]

<!-- MR 10.2.0 [CU12] - FR 10.3.1 [CU0] -->

In SLElement, a number of enhancements have been made with regard to parameter locking.

#### Security enhancements [ID_34894]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

A number of security enhancements have been made.

#### SLLogCollector: Multiple instances can now be run simultaneously [ID_35204]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Multiple instances of the SLLogCollector tool can now be run simultaneously.

#### Exporting and importing DELT packages containing element and alarm data is now supported on DataMiner Systems with a clustered database [ID_35213]

<!-- MR 10.2.0 [CU12] - FR 10.3.2 [CU0] -->

From now on, exporting and importing DELT packages containing element and alarm data is also supported on DataMiner Systems with a clustered database.

> [!NOTE]
> Exporting and importing DELT packages containing trend data is not yet supported on DataMiner Systems with a clustered database.

### Fixes

#### Problem with SLElement when a trend template was being assigned [ID_34824]

<!-- MR 10.2.0 [CU12] - FR 10.3.1 -->

In some cases, an error could occur in SLElement when a trend template was being assigned.

#### Problem with SLLog when logging large entries regarding failed Elasticsearch query requests/responses [ID_35037]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Up to now, an error could occur in SLLog when adding large entries regarding failed Elasticsearch query requests/responses.

#### SLDataGateway would leak memory when offloading average trend data for DVE elements [ID_35167]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

The SLDataGateway process would leak memory when offloading average trend data for DVE elements.

#### DataMiner Cube - Alarm Console: Multiple values in property columns would incorrectly not be separated by any separator [ID_35239]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

If, in the Alarm Console, property columns are added for service or view properties, and an alarm affects more than one service or view, this can result in property columns containing multiple property values.

In the *PropertyConfiguration.xml* file, for each relevant property you can configure a *contentSeparator* tag. The separator specified in that tag will then be used to separate the values of that property.

Up to now, when a *contentSeparator* tag was left empty, the values of the property in question would incorrect not be separated by any separator. From now on, when that tag is empty, the values of the property in question will by default be separated by commas.

#### SLDataGateway could end up with an excessive number of HealthMonitor.Refresh threads [ID_35286]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In some cases, the SLDataGateway process could end up with an excessive number of *HealthMonitor.Refresh* threads.

#### DataMiner Cube - ListView component: Column filter boxes incorrectly had autocomplete enabled [ID_35296]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In a *ListView* component, you can click the filter icon of a particular column and enter a filter in the box below the column header.

Up to now, those column filter boxes incorrectly had *autocomplete* enabled.

#### Dashboards app / Low-Code Apps - Node edge component: Edge overrides would incorrectly no longer be applied [ID_35298]

<!-- MR 10.2.0 [CU12] - FR 10.3.2 -->

When, in the settings of a node edge graph, you had configured edge overrides, these would incorrectly no longer be applied.

#### DataMiner Cube - Visual Overview: Problem after filtering bookings using a custom time range in ListView component or Resource Manager component [ID_35328]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a ListView component or a Resource Manager component showing a bookings timeline, you had filtered the bookings using a custom time range, performance issues could start to occur after a period of time.

#### DataMiner Cube - Visual Overview: Problem when editing a discrete parameter with a 'Sequence' tag displayed in a lite parameter control [ID_35356]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a discrete parameter with a `<Sequence>` tag was displayed in a lite parameter control, its current value would neither be displayed nor selected while being edited.
