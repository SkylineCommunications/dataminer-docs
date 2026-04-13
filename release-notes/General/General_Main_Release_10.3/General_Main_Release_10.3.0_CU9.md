---
uid: General_Main_Release_10.3.0_CU9
---

# General Main Release 10.3.0 CU9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.3.0 CU9](xref:Cube_Main_Release_10.3.0_CU9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.3.0 CU9](xref:Web_apps_Main_Release_10.3.0_CU9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Service & Resource Management: Enhanced performance when editing/deleting profile parameters [ID 37097]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased when editing or deleting profile parameters of type *Capability* or *Capacity*, especially on systems with a large number of future bookings.

#### Legacy Reporter is now fully compatible with Cassandra Cluster [ID 37185]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

The legacy Reporter has now been made fully compatible with Cassandra Cluster.

Also, an issue has been fixed for all types of databases. Up to now, when an SLA was created on top of an enhanced service, in some cases, the SLA report would not include all affected alarms.

#### Security enhancements [ID 37267]

<!-- RN 37267: MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.11 -->

A number of security enhancements have been made.

#### Enhanced performance when offloading data in case the database is down [ID 37365]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased when offloading data in case the database is down.

#### Service & Resource Management: Initialization of ResourceManager and SRMServiceStateManager will be retried up to 5 times [ID 37507]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When *ResourceManager* and *SRMServiceStateManager* fail to get initialized at DataMiner startup, the system will now retry up to 5 times to get those managers up and running.

#### SLAnalytics - Behavioral anomaly detection: Enhanced trend change detection [ID 37571]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

If, upon detection of a new trend, the trend returns to the old trend (i.e., the trend before the behavioral change) within the hour, the behavioral change will be labeled a level shift rather than a trend change.

#### SLAnalytics: Lost session with SLDataGateway will now automatically be restored [ID 37614]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

From now on, when SLAnalytics loses the session with SLDataGateway, it will now automatically restore the session.

#### SLAnalytics - Alarm focus: A notice will now be generated when the AlarmFocusRecords cache reaches its maximum size [ID 37624]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the *AlarmFocusRecords* cache reached its maximal size, up to now, an error message would be added to the *SLAnalytics.txt* log file. From now on, a notice will be generated instead.

#### Page size when retrieving element data from Cassandra has been set to 5000 [ID 37673]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

For performance reasons, the page size when retrieving element data from a Cassandra database has been changed from 50000 to 5000.

> [!NOTE]
> When retrieving element data from a MySQL or Microsoft SQL Server database, the page size remains set to 50000.

### Fixes

#### Problem in different native processes when interacting with message broker calls [ID 37150]

<!-- MR 10.3.0 [CU9] - FR 10.3.11 -->

In some cases, an error could occur in different native processes when interacting with message broker calls.

#### NATSCustodian could incorrectly pick an offline DMA as NAS candidate [ID 37312]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when NATSCustodian had to pick a NAS candidate, in some cases, it could pick a DataMiner Agent that was offline, causing an error to occur when trying to copy the credentials.

From now on, it will only be possible to trigger a NATS configuration reset when all DataMiner Agents in the cluster are online/running.

#### Problem when requesting alarm monitoring information for an exported parameter [ID 37424]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, incorrect data would be returned when requesting alarm monitoring information for a parameter exported as a standalone parameter to a DVE child element, especially when dynamic thresholds had been configured in the alarm template.

#### Updated dynamic IP address would incorrectly be applied to all connections of an element [ID 37445]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a parameter that was used to store the dynamic IP address of an element connection was updated, the dynamic IP address would incorrectly be applied to all connections of that element when the element was restarted.

#### Element connections would not work with destination tables that had naming configured [ID 37478]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

Element connections would not work with destination tables that had naming configured.

#### Duplicate PropertyChangeEvent objects would be created in the event cache [ID 37485]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, incorrect duplicate PropertyChangeEvent objects would be created in the event cache.

The properties were correctly updated on the respective elements, but the DMAs that forwarded the requests would incorrectly generate additional, incorrect PropertyChangedEvents, which could lead to, for example, outdated property values being displayed in user interfaces.

#### Cassandra: Problem with health monitor after reconnecting [ID 37494]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the Cassandra health monitor reconnected to a remote Cassandra or Cassandra Cluster database, in some cases, an error could occur.

#### SLAnalytics: Problem when simultaneously stopping the 'Alarm Focus' and 'Automatic Incident Tracking' features [ID 37496]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when you stopped both *Alarm Focus* and *Automatic Incident Tracking* at the same time (e.g., via *System Center > System settings > analytics config* in DataMiner Cube), only *Alarm Focus* would actually be stopped. *Automatic Incident Tracking* would still be active, but in an incorrect state.

#### Service & Resource Management: Problem with resource capability exposers [ID 37503]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a resource did not have both a minimum and maximum value for a particular range point, the resource capability exposers would not work correctly for that range point.

#### Elasticsearch/OpenSearch: Problem when a repository failed to initialize [ID 37550]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a repository failed to initialize, all subsequent initialization attempts would throw a `NullReferenceException`.

#### DELT export of an element from a Cassandra Cluster would incorrectly not include any data [ID 37557]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a DELT export of an element was performed on a DataMiner Agent running a Cassandra Cluster database, the import package would incorrectly not contain a database folder. As a result, no data from the element in question would be exported.

Also, DELT exports would incorrectly not include the mask status of elements or alarms.

#### PropertyChangeEvents would not be removed from the SLNet event cache when an element was deleted [ID 37576]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When an element was deleted, `PropertyChangeEvent` instances for that element would incorrectly not get removed from the SLNet event cache.

#### Alerter: Problem when connecting to a DataMiner Agent using gRPC [ID 37580]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When Alerter connected to a DataMiner Agent using gRPC, on each subsequent startup, it would display a message box showing the following error:

`There is no connection available, please add one.`

#### SLAnalytics: Problem after losing connection with SLDataGateway [ID 37603]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When SLAnalytics lost connection with SLDataGateway, an exception would be thrown, causing SLAnalytics to become unresponsive.

#### DataMiner Object Models: DomManager would not initialize when it received its first call [ID 37604]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the first call to a DomManager after a DMA (re)start was a call to create, update or delete a HistoryChange object, the call would fail and the DomManager would not initialize.

#### Service & Resource Management: Problem when updating a booking using resources that had been used by other bookings in the past [ID 37647]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When you updated a booking using resources that had also been used earlier by other bookings in the past, a concurrency error could incorrectly be thrown.

#### SLAnalytics - Behavioral Anomaly Detection: Change in trend would incorrectly cause two change points to be created [ID 37703]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, for a trended parameter, a change in trend was detected, in some cases, two change points of type "trend change" would incorrectly be created.

#### SLAnalytics - Alarm focus: Problem when alarm focus cache got full [ID 37710]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the alarm focus cache got full, an error could occur in SLAnalytics.

#### Protocol VDX files imported via a DELT package would not be displayed until a DataMiner restart [ID 37781]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 [CU0] -->

When you imported a DELT package that contained protocol VDX files linked to elements in the package, in some rare cases, those VDX files would incorrectly not be displayed until after a DataMiner restart.

#### SLNetClientTest tool would not indicate that a profile migration to Elasticsearch/OpenSearch had failed due to a profile object with an invalid name [ID 37808]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 [CU0] -->

When, in the SLNetClientTest tool, you went to *Advanced > Migration*, the migration overview would not indicate that a migration of profiles towards Elasticsearch/OpenSearch had failed due to a profile object with a name longer than 32,766 characters.

#### Cassandra Cluster & STaaS: Correlation matchinfo and slidingwindow records could be overwritten [ID 37813]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 [CU0] -->

On systems using a Cassandra Cluster database or STaaS, in some cases, DataMiner Agents could overwrite each other's correlation matchinfo and slidingwindow records.

#### Profile migrations to Elasticsearch/OpenSearch will now fail when the profiles.xml file is corrupt [ID 37818]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 [CU0] -->

When you started a profile migration to an Elasticsearch/OpenSearch database while the *profiles.xml* file was corrupt, up to now, a new empty *profiles.xml* file would be created and the migration would continue. From now on, no new *profiles.xml* file will be created anymore and the migration will go into an error status.

> [!NOTE]
> When, in the SLNetClientTest tool, you go to *Advanced > Migration*, all migrations in an error status will now have a red background.
