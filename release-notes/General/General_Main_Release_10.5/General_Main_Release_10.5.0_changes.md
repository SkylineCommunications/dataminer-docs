---
uid: General_Main_Release_10.5.0_changes
---

# General Main Release 10.5.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### Security enhancements [ID_37349] [ID_37637] [ID_38052] [ID_38263]

<!-- 37349: MR 10.5.0 - FR 10.4.2 -->
<!-- 37637 (part of 37734): MR 10.5.0 - FR 10.4.2 -->
<!-- 38052: MR 10.5.0 - FR 10.4.2 -->
<!-- 38263: MR 10.5.0 - FR 10.4.3 -->

A number of security enhancements have been made.

#### Deprecated NotifyDataMiner type 'NT_CONNECTIONS_TO_REMOVE' can no longer be used [ID_37595]

<!-- MR 10.5.0 - FR 10.4.1 -->

From now on, the deprecated NotifyDataMiner type *NT_CONNECTIONS_TO_REMOVE* can no longer be used.

#### SLAnalytics - Proactive cap detection: Enhanced detection of possible future alarm threshold breaches [ID_37681]

<!-- MR 10.5.0 - FR 10.4.1 -->

When an increasing or decreasing trend is detected on a highly aggregated level (i.e. a trend that persists for more than 24 hours), from now on, a proactive cap detection suggestion event will be generated when there is a probability that the trend change in question could lead to a breach of a critical alarm limit at some point in the future, even when the breach has not yet been confirmed by the full prediction model built on the historic trend data.

#### Service & Resource Management: Enhanced performance of ResourceManagerHelper.GetResources when using the ResourceExposers.ID.Equal filter [ID_37720]

<!-- MR 10.5.0 - FR 10.4.1 -->

Because of a number of enhancements, overall performance of the `ResourceManagerHelper.GetResources` method has increased when using a `ResourceExposers.ID.Equal` filter.

Also, the performance of `TrueFilterElement<Resource>` has been improved.

#### SLAnalytics - Behavioral anomaly detection: Enhanced coloring of trend graph change point indicators [ID_37827]

<!-- MR 10.5.0 - FR 10.4.1 -->

In a trend graph, the occurrence of change points is indicated by colored rectangular regions below the graph.

Up to now, these regions had a dark color when an alarm event would have been triggered for the change point in question if alarm monitoring had been activated for that type of change point.

From now on, a rectangular region will have a dark color when the change point in question actually triggered an event:

- a suggestion event (if alarm monitoring was not activated for that type of change point), or
- an alarm event (if alarm monitoring was activated for that type of change point).

#### SLAnalytics: Enhanced error logging when retrieving trend data [ID_37931]

<!-- MR 10.5.0 - FR 10.4.1 -->

More extensive information will now be logged when errors occur while retrieving trend data.

#### Service & Resource Management: Migrating profiles and resources from XML to Elasticsearch/OpenSearch is no longer supported [ID_37979]

<!-- MR 10.5.0 - FR 10.4.2 -->

As storing profiles and resources in XML files is no longer supported as from DataMiner 10.4.0/10.4.1, migrating profiles and resources from XML to Elasticsearch/OpenSearch is now no longer supported as well. If you need to migrate profiles and resources, do so before you upgrade to version 10.4.0.

Also, the *NotAllClusterAgentsReachable* error in ResourceManager is now considered obsolete and will no longer be returned.

#### DataMiner Object Models: Reading DOM objects and ModuleSettings in parallel [ID_38023]

<!-- MR 10.5.0 - FR 10.4.2 -->

It is now possible to read DOM objects and ModuleSettings in parallel. This will considerably improve overall performance.

#### SLAnalytics - Behavioral anomaly detection: Reduction of memory used for trend icon calculation [ID_38041]

<!-- MR 10.5.0 - FR 10.4.2 -->

Up to now, SLAnalytics would always keep average trend data for all trended parameters on the system for a configurable time frame in order to determine which trend icon to display in the absence of change points. From now on, it will only keep trend data and calculate state icons for 250,000 trended parameters at the most, reducing memory usage.

#### GQI: Sort operator will now be forwarded to the correct query of a Join operator [ID_38150]

<!-- MR 10.5.0 - FR 10.4.2 -->

When you add a Sort operator after adding a Join operator, that Sort operator will now automatically be forwarded to the correct query in the Join operator. This will considerably enhance performance, especially when sorting on a joined column.

When you sort on a joined column, the Sort operator will be forwarded in the following situations:

- In case of an inner join
- In case of a left join, but only if all sorts are descending
- In case of a right join

#### DataMiner Object Models: Required list fields can no longer be set to an empty list [ID_38238]

<!-- MR 10.5.0 - FR 10.4.3 -->

From now on, when the value of a required list field is set to an empty list, one of the following errors will be thrown:

- `DomInstanceHasMissingRequiredFieldsForCurrentStatus` (when using the DOM status system)
- `DomInstanceDoesNotContainAllRequiredFieldsForSectionDefinition` (when not using the DOM status system)

### Fixes

#### Databases: Problem when starting a migration from MySQL to Cassandra [ID_37589]

<!-- MR 10.5.0 - FR 10.4.1 -->

When you started a migrating from a MySQL database to a Cassandra database, an error could occur when the connection to the MySQL database took a long time to get established.

#### Storage as a Service: Resources would not always be released correctly [ID_38058]

<!-- MR 10.5.0 - FR 10.4.2 -->

Resources would not always be released correctly, causing some resources to be used for longer than strictly necessary.

#### SLReset: Problem when cleaning a Cassandra database [ID_38332]

<!-- MR 10.5.0 - FR 10.4.2 -->

When cleaning (i.e. resetting) a Cassandra database, in some cases, a `TypeInitializationException` could be thrown.
