---
uid: General_Main_Release_10.5.0_changes
---

# General Main Release 10.5.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

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

### Fixes

#### Databases: Problem when starting a migration from MySQL to Cassandra [ID_37589]

<!-- MR 10.5.0 - FR 10.4.1 -->

When you started a migrating from a MySQL database to a Cassandra database, an error could occur when the connection to the MySQL database took a long time to get established.

#### Security: Users would incorrectly not be allowed to update the Visio file linked to a service [ID_37866]

<!-- MR 10.5.0 - FR 10.4.1 -->

Up to now, when users had the following permissions, they would not be allowed to update the Visio file associated with a service by using the  *Upload new visio file* or *Set new blank visio file* commands:

- *General > Visual Overview > Access Visual Overviews*
- *General > Visual Overview > Edit Visio drawings*
- *General > Services > Edit*
- *Write* and *Config* permission for the service in question

From now on, when users have the permission to link a Visio file to a specific service, they will always be allowed to update the Visio file linked to that service.
