---
uid: General_Main_Release_10.4.0_changes
---

# General Main Release 10.4.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### Security enhancements [ID_35331]

<!-- RN 35331: MR 10.4.0 - FR 10.3.3 -->

A number of security enhancements have been made.

#### More detailed logging when the certificate chain is invalid while connecting to Cassandra [ID_34822]

<!-- MR 10.4.0 - FR 10.3.2 -->

More detailed information will now be added to the `SLDBConnection.txt` log file when the certificate chain is invalid while connecting to Cassandra.

Log entry syntax: `Certificate chain error: {chainStatus.Status}, details: {chainStatus.StatusInformation}`

#### SLAnalytics: Number of 'GetParameterMessages' requests has been optimized [ID_34936]

<!-- MR 10.4.0 - FR 10.3.1 -->

The number of *GetParameterMessages* sent by SLAnalytics in order to check whether a trended table parameter is still active has been optimized.

#### SLAnalytics - Proactive cap detection: Enhanced accuracy when generating alarm predictions [ID_35080]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall accuracy has increased when generating alarm predictions.

#### SLAnalytics - Behavioral anomaly detection : More accurate change point time ranges [ID_35121]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, behavioral changes of the type "level shift", "trend change" and "variance change" will now have a more accurate time range when the change in behavior is sufficiently clear.

#### DataMiner Object Models: DomInstanceButtonDefinitions can only reference a single action [ID_35156]

<!-- MR 10.4.0 - FR 10.3.2 -->

From now on, DomInstanceButtonDefinitions can only reference a single action. If multiple actions are defined, a `DomBehaviorDefinitionError` with reason `InvalidButtonActionCombination` will be returned.

Also, when using the DomBehaviorDefinition inheritance system, the server-side logic will now make sure that there are no buttons or actions with identical IDs on both the parent and child definition.

- If a duplicate action is found, a `DomBehaviorDefinitionError` with reason `DuplicateActionDefinitionIds` will be returned.
- If a duplicate button is found, a `DomBehaviorDefinitionError` with reason `DuplicateButtonDefinitionIds` will be returned.

#### SLLogCollector: Custom CollectorConfig XML files will now be synchronized across the DataMiner cluster [ID_35180]

<!-- MR 10.4.0 - FR 10.3.2 -->

From now on, all custom CollectorConfig XML files will be synchronized across the DataMiner cluster.

#### SLAnalytics - Pattern matching: When a pattern is detected on a DVE child element the suggestion event will now be generated on that same DVE child element [ID_35264]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a trend pattern was detected on a DVE child element, up to now, the suggestion event would be generated on the parent element. From now on, it will be generated on the child element instead.

#### SLAnalytics - Pattern matching: Manually created tags will now be saved as pattern occurrences [ID_35299]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when you define a tag for pattern matching, the pattern you selected will be saved as a pattern occurrence in the Elasticsearch database and highlighted in bright orange, similar to so-called "streaming matches", which are detected while tracking for trend patterns whenever a trended parameter is updated.

#### SLDataGateway: Memory enhancements with regard to average trending [ID_35312]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the SLDataGateway process, a number of memory enhancements have been made with regard to the management of average trend data.

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

#### Maps: Zoom range can now be set by means of a slider [ID_35381]

<!-- MR 10.4.0 - FR 10.3.3 -->

The zoom range of a map can now be set by means of a slider.

### Fixes

#### Problem with Resource Manager when ResourceStorageType was not specified in Resource Manager settings [ID_34981]

<!-- MR 10.4.0 - FR 10.3.1 -->

In some cases, Resource Manager could throw a NullReferenceException when *ResourceStorageType* was not specified in the `C:\Skyline DataMiner\ResourceManager\Config.xml` file.

#### External authentication via SAML: Issues fixed when using Okta as identity provider [ID_35374]

<!-- MR 10.4.0 - FR 10.3.3 -->

Using Okta as identity provider, it would incorrectly no longer be possible to read out signed assertions. Also, when the group claim setting is enabled in the *DataMiner.xml* file, the user will now be added to the correct groups.

Up to now, in case of a claim mismatch, an exception would be thrown. From now on, an entry containing a clear message will be added to the *SLNet.txt* log file instead.
