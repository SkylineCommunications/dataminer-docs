---
uid: General_Feature_Release_10.3.3
---

# General Feature Release 10.3.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.3](xref:Cube_Feature_Release_10.3.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.3](xref:Web_apps_Feature_Release_10.3.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### DataMiner Object Models: Action buttons can now be configured to launch an interactive Automation script when clicked [ID_35226]

<!-- MR 10.4.0 - FR 10.3.3 -->

An action button can now be configured to launch an interactive Automation script when clicked. To do so, set the *IsInteractive* property of the action to true.

When such a button is clicked in a low-code app, the UI of the interactive Automation script will be displayed in a pop-up window on top of the low-code app.

> [!NOTE]
> One button can only execute one action. So, one button can only execute one interactive Automation script.

#### DataMiner Object Models: New field descriptors [ID_35278]

<!-- MR 10.4.0 - FR 10.3.3 -->

Two new field descriptors have been added to the DataMiner Object Models:

- GroupFieldDescriptor: Can be used to define that a field should contain the name of a DataMiner user group.

- UserFieldDescriptor: Can be used to define that a field should contain the name of a DataMiner user. There is a *GroupNames* property that can be used to define which groups the user can be a part of.

## Changes

### Enhancements

#### Security enhancements [ID_34894] [ID_35331]

<!-- RN 34894: MR 10.2.0 [CU12] - FR 10.3.3 -->
<!-- RN 35331: MR 10.4.0 - FR 10.3.3 -->

A number of security enhancements have been made.

#### Elasticsearch: 'Request Entity Too Large (413)' errors will now be prevented when writing data in bulk [ID_34937]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When data was written to Elasticsearch in bulk, up to now, DataMiner would throw a `Request Entity Too Large (413)` error when the amount of data exceeded the 100 MB limit.

From now on, DataMiner will detect when too much data is being sent in a single request and will split up the data into smaller parts.

#### SLLogCollector: Multiple instances can now be run simultaneously [ID_35204]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Multiple instances of the SLLogCollector tool can now be run simultaneously.

#### SLAnalytics - Pattern matching: Manually created tags will now be saved as pattern occurrences [ID_35299]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when you define a tag for pattern matching, the pattern you selected will be saved as a pattern occurrence in the Elasticsearch database and highlighted in bright orange, similar to so-called "streaming matches", which are detected while tracking for trend patterns whenever a trended parameter is updated.

#### SLAnalytics - Behavioral anomaly detection: Suggestion events and alarm events for a DVE child element will now be generated on that same DVE child element [ID_35332]

<!-- MR 10.4.0 - FR 10.3.3 -->

When a behavioral anomaly was detected on a DVE child element, up to now, the suggestion event or the alarm event would be generated on the parent element. From now on, it will be generated on the child element instead.

#### Maps: Markers will now move more gradual when zooming [ID_35337]

<!-- MR 10.4.0 - FR 10.3.3 -->

Because of a number of enhancements, markers will now move more gradual when zooming.

#### Alarm templates - Smart baseline calculations: NullReferenceException prevented & enhanced exception logging [ID_35348]

<!-- MR 10.4.0 - FR 10.3.3 -->

In some cases, a `Baseline Calculation Failed: System.NullReferenceException: Object reference not set to an instance of an object` error would be added to the *SLSmartBaselineManager.txt* log file. The issue causing that error has now been fixed.

Also, log entries indicating an exception thrown during baseline calculations will now include details regarding the element and parameter associated with the exception.

#### Maps: Enhanced zooming behavior [ID_35351]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when you zoom in or out, the data of the previous zoom level will stay visible until the data of the current zoom level has been loaded.

#### DataMiner upgrade: Installation of Microsoft .NET 6.0 [ID_35363]

<!-- MR 10.4.0 - FR 10.3.3 -->

During a DataMiner upgrade, Microsoft .NET 6.0 will now be installed if not installed already.

### Fixes

#### Problem with SLLog when logging large entries regarding failed Elasticsearch query requests/responses [ID_35037]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Up to now, an error could occur in SLLog when adding large entries regarding failed Elasticsearch query requests/responses.

#### When a direct view table was updated, the wrong columns could be updated in the source element [ID_35075]

<!-- MR 10.3.0 - FR 10.3.3 -->

When a direct view table was updated while one of the source elements was stopped, due to a column translation issue, the wrong columns could be updated in that source element the moment it was started again.

#### SLDataGateway would leak memory when offloading average trend data for DVE elements [ID_35167]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

The SLDataGateway process would leak memory when offloading average trend data for DVE elements.

#### Service & Resource Management: Setting a new function file to active would incorrectly not cause the function DVEs of elements using a production version of the protocol to be updated [ID_35178]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a new function file was set to active, up to now, the function DVEs of elements using a production version of the protocol in question would incorrectly not be updated.

#### SLDataGateway could end up with an excessive number of HealthMonitor.Refresh threads [ID_35286]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In some cases, the SLDataGateway process could end up with an excessive number of *HealthMonitor.Refresh* threads.

#### DataMiner Object Models: Permission checks for DOM modules requiring view permission 'None' were too strict [ID_35305]

<!-- MR 10.3.0 - FR 10.3.3 -->

If a DOM module is created without specifying *SecuritySettings*, the view permission is set to "None".

Up to now, the check to determine whether a user had the view permission set to "None", would only return true for the Administrator or users in the Administrator group. From now on, when the required view permission is "None", permission checks will no longer be performed.

#### Cassandra: TTL setting of spectrum trace data would not be applied correctly [ID_35385]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In a Cassandra database, the "time to live" (TTL) setting of spectrum trace data would not be applied correctly. As a result, this type of data would never be removed.
