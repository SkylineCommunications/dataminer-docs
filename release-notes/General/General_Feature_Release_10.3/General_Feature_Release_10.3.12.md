---
uid: General_Feature_Release_10.3.12
---

# General Feature Release 10.3.12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.12](xref:Cube_Feature_Release_10.3.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.12](xref:Web_apps_Feature_Release_10.3.12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

#### Configuration of behavioral anomaly alarms [ID_36857] [ID_36976] [ID_37124] [ID_37246] [ID_37250] [ID_37334] [37434]

<!-- MR 10.4.0 - FR 10.3.12 -->

The DataMiner software now supports a more extensive configuration of behavioral anomaly alarms.

From now on, you will be able to choose between the following types of anomaly monitoring:

- Smart anomaly monitoring (i.e. anomaly monitoring as it existed before)
- Customized anomaly monitoring

Customized anomaly monitoring will enable you to do the following:

- Set absolute or relative thresholds on the jump sizes of the change points of type *Level Shift* or *Outlier*.
- Enable or disable monitoring for each of the two possible directions of a behavioral change for level shifts, trend changes, variance changes and outliers. This will allow you, for example, to configure different alarm monitoring behaviors for downward level shifts and upward level shifts.

For more information on how to configure anomaly monitoring in DataMiner Cube, see [Alarm templates: Configuration of behavioral anomaly alarms [ID_37148] [ID_37171] [ID_37670]](xref:Cube_Feature_Release_10.3.12#alarm-templates-configuration-of-behavioral-anomaly-alarms-id_37148-id_37171-id_37670).

Summary of server-side changes:

- The behavioral anomaly configuration can be requested by sending a *GetAlarmTemplateMessage*. The *GetAlarmTemplateResponseMessage* will then return the behavioral anomaly configuration in a new *AnomalyConfiguration* field.

  If you enable behavioral anomaly monitoring, the *AnomalyConfiguration* field will contain information on which change point types are being monitored and how. If no behavioral anomaly monitoring has been configured, this field will remain empty.

  The legacy anomaly monitoring fields *LevelShiftMonitor*, *TrendMonitor*, *VarianceMonitor* and *FlatlineMonitor* in the *GetAlarmTemplateResponseMessage* have been marked as obsolete. If, in existing alarm templates, at least one of those legacy fields was enabled, the *AnomalyConfiguration* field will be filled with values consistent with the old settings.  

- The  anomaly configuration information for a parameter is no longer available in the *ParameterAlarmInfo* of each parameter. This means that the anomaly monitoring information can no longer be retrieved by means of a *GetElementProtocolMessage*.

  The legacy anomaly monitoring fields *LevelShiftMonitor*, *TrendMonitor*, *VarianceMonitor* and *FlatlineMonitor* in the *ParameterAlarmInfo* have been marked as obsolete and will no longer be taken into account by SLAnalytics.

- When upgrading to this DataMiner version, existing alarm template XML files will not be changed.

  When you update an existing alarm template or creating a new one, a new `<AnomalyConfig>` element will be added into the body of the `<Alarm>` element if, and only if, behavioral anomaly monitoring is enabled and an extended anomaly configuration has been set via the *AnomalyConfiguration* field of the *GetAlarmTemplateResponse* or the template parameters.

  The existing attributes of the `<Monitored>` element (i.e. *varianceMonitor*, *trendMonitor*, *levelShiftMonitor* and *flatLineMonitor*) have not been changed or removed to ensure compatibility of the new alarm template XML files with older DataMiner versions.

- When you set up a customized behavioral anomaly monitoring containing relative or absolute thresholds, this setup will be lost when you downgrade to an older server version that does not support this extended anomaly configuration (i.e. DataMiner version 10.3.11 or older). A fallback to the legacy "smart anomaly monitoring" will happen for all the change point types that had some kind of anomaly monitoring enabled.

- The internal SLAnalytics alarm template monitoring mechanism now also takes into account alarm template group information. As a result, SLAnalytics modules making use of this mechanism will get notified about changes to group entries and can react to these changes.

- A behavioral change point of type "flatline" shown in the trend graph will now always receive the correct alarm color when an anomaly alarm was created for it. In other words, if a critical behavioral anomaly alarm was created for the behavioral change of type "flatline", the change point bar shown in the trend graph will receive the red color.

## Changes

### Enhancements

#### Service & Resource Management: Enhanced performance when editing/deleting profile parameters [ID_37097]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased when editing or deleting profile parameters of type *Capability* or *Capacity*, especially on systems with a large number of future bookings.

#### Legacy Reporter is now fully compatible with Cassandra Cluster [ID_37185]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

The legacy Reporter has now been made fully compatible with Cassandra Cluster.

Also, an issue has been fixed for all types of databases. Up to now, when an SLA was created on top of an enhanced service, in some cases, the SLA report would not include all affected alarms.

#### Enhanced performance when offloading data in case the database is down [ID_37365]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased when offloading data in case the database is down.

#### SLAnalytics - Proactive cap detection: Enhanced verification of forecasted alarms [ID_37368]

<!-- MR 10.4.0 - FR 10.3.12 -->

A number of enhancements have been made with regard to the verification of forecasted alarms generated by the proactive cap detection feature.

#### DataMiner Object Models: Enhanced checks when removing field descriptors from a section definition [ID_37395]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, when a field descriptor was removed from a section definition that was being used by any DOM instances, the update of the section would fail and a `SectionDefinitionError` with reason `SectionDefinitionInUseByDomInstances` would be added to the trace data.

To allow certain field descriptors to be removed, this behavior has now been changed. From now on, the update of a section will only fail if the removed field descriptors are still being used.

A `SectionDefinitionError` with reason `SectionDefinitionFieldsInUse` will be added to the trace data in the following cases:

- If any of the removed field descriptors is being used in the DOM manager settings of the DOM module (either in the name definition or in one of the field aliases). When a field descriptor is detected in those settings, `UsedInDomManagerSettings` will be set to true in the `SectionDefinitionError`.

- If any of the removed field descriptors is being used in the name definition defined on a DOM definition. The IDs of those DOM definitions will be specified in `DomDefinitionIds` of the `SectionDefinitionError`.

- If any of the removed field descriptors is being used in any of the status section definition links on a DOM behavior definition. The IDs of the DOM behavior definitions will be specified in `DomBehaviorDefinitionIds` of the `SectionDefinitionError`.

- If any of the removed field descriptors is assigned a value in any DOM instance. The IDs of the DOM instances (limited to 100) will be specified in `DomInstanceIds` of the `SectionDefinitionError`. If a large number of field descriptors were removed, only the first 100 field descriptors that match will be taken into account.

Also, the `SectionDefinitionError` will have `SectionDefinitionID` set to the ID of the SectionDefinition that could not be updated. `FieldDescriptorIds` will contain the IDs of the FieldDescriptors that were found to be in use.

Other changes to a section definition that fail when the section is being used by any DOM instance will still fail with reason `SectionDefinitionInUseByDomInstances`. Up to now, all DOM instance IDs would be included in the error data. From now on, only the first 100 IDs will be included.

> [!NOTE]
> Currently, on systems using STaaS, the validation of DOM instances might not detect if a field descriptor is in use when there are more then 100 DOM instances. In that case, the removal of the field descriptor in question will be allowed.

#### SLAnalytics - Trend predictions: Flatline periods will no longer be included in the prediction model training data [ID_37432]

<!-- MR 10.4.0 - FR 10.3.12 -->

When a parameter has anomalous flatline periods in its trend data history that are breaking the normal trend data patterns, from now on, those flatline periods will no longer be included into the training data of the prediction model. As a result, a more accurate prediction can be expected on this kind of behavior.

#### SLAnalytics: Not all occurrences of multivariate patterns containing subpatterns hosted on different DMAs would be detected [ID_37451]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, when you had created a multivariate pattern containing subpatterns hosted on different DMAs, in some cases, not all occurrences would get detected internally. From now on, all occurrences of multivariate patterns containing subpatterns hosted on different DMAs will be correctly detected.

#### Storage as a Service: Enhanced performance of DOM and SRM queries [ID_37495]

<!-- MR 10.4.0 - FR 10.3.12 -->

Because of a number of enhancements, overall performance of DOM and SRM queries has increased.

#### Service & Resource Management: Initialization of ResourceManager and SRMServiceStateManager will be retried up to 5 times [ID_37507]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When *ResourceManager* and *SRMServiceStateManager* fail to get initialized at DataMiner startup, the system will now retry up to 5 times to get those managers up and running.

#### SLAnalytics - Automatic incident tracking: Enhanced error handling [ID_37530]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, when the table index of an alarm update had a casing that was not identical to that of previous alarm events in the same alarm tree, SLAnalytics would log errors similar to the following ones:

`Updating alarm in tree X/X , but old alarm could not be found in the loose alarms or in the groups`

`Alarm X/X was in state but neither in loose alarms, in an automatic group or in a manual group`

Because of a number of enhancements made to the automatic incident tracking feature, SLAnalytics will no longer throw errors like the ones above.

#### Security enhancements [ID_37540]

<!-- 37540: MR 10.4.0 - FR 10.3.12 -->

A number of security enhancements have been made.

#### DataMiner Object Models: GQI sort operations will now be executed by the database [ID_37541]

<!-- MR 10.4.0 - FR 10.3.12 -->

Previously, when you added a sort node to a GQI query against the DOM data source, all DOM instances matching any filter node needed to be retrieved before the sorting could occur. Sorting a data set with a large amount of DOM instances was practically impossible.

From now on, the sort nodes (e.g. By X, Then By Y, etc.) will be forwarded to the database. This will considerably increase overall performance when sorting DOM instances, especially when the data set includes a large amount of items.

> [!NOTE]
>
> - Fields that have multiple values (i.e. list fields) cannot be sorted.
> - All string sorting occurs in a non-natural way.
> - TimeSpan fields are evaluated as strings. As a result, similar to strings, they will also be ordered in a non-natural way.
> - Multiple sorts are supported using the `Sort by, Then sort by, etc.` node concatenation. If a new *Sort by* node is added to the query, the previous will be ignored.
> - When sorting by DOM status or by an enum field, the sorting is will occur on the underlying value stored in the DOM instance and not on the display value.
> - When the DOM GQI query is combined in a join operation, any sort node added after the join node will not be forwarded to the database. This will also be the case when the sorting uses the header of the table and the DOM query is part of a join.

#### Storage as a Service: Enhanced error handling [ID_37554]

<!-- MR 10.4.0 - FR 10.3.12 -->

A number of enhancements have been made with regard to error handling.

#### SLAnalytics - Behavioral anomaly detection: Enhanced trend change detection [ID_37571]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

If, upon detection of a new trend, the trend returns to the old trend (i.e. the trend before the behavioral change) within the hour, the behavioral change will be labeled a level shift rather than a trend change.

#### New downgrade action that adapts the SLAnalytics configuration file when downgrading to version 10.3.0 or older [ID_37582]

<!-- MR 10.4.0 - FR 10.3.12 -->

When you downgrade a DataMiner Agent from version 10.3.1 or later to version 10.3.0 or older, a downgrade action will now remove the section related to relation grouping from the SLAnalytics configuration file.

#### SLAnalytics: Enhanced error handling [ID_37607]

<!-- MR 10.4.0 - FR 10.3.12 -->

Because of a number of enhancements with regard to error handling, the following error message will no longer be generated when the SLAnalytics process is restarted on one of the DataMiner Agents in the DataMiner System:

`Unexpected number of responses returned on GetInfoMessage...`

#### SLAnalytics: Lost session with SLDataGateway will now automatically be restored [ID_37614]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

From now on, when SLAnalytics loses the session with SLDataGateway, it will now automatically restore the session.

#### SLAnalytics - Alarm focus: A notice will now be generated when the AlarmFocusRecords cache reaches its maximum size [ID_37624]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the *AlarmFocusRecords* cache reached its maximal size, up to now, an error message would be added to the *SLAnalytics.txt* log file. From now on, a notice will be generated instead.

#### ManagerStore: Exceptions thrown during actions of high importance will now be logged as errors [ID_37631]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, when managers under the control of the ManagerStore framework in SLNet (DOM, Profiles, User-Defined APIs) threw exceptions during a de-initialization, a failover switch or a midnight synchronization, those exceptions would be logged as level-5 log entries of type *Info*. From now on, they will be logged as level-0 log entries of type *Error*.

#### Storage as a Service: Enhanced performance when restarting elements or performing certain DOM and SRM operations [ID_37638]

<!-- MR 10.4.0 - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased, especially when restarting elements or performing certain DOM and SRM operations.

#### DataMiner Objects Models: Fields used in multiple sections will no longer be returned for GQI queries [ID_37644]

<!-- MR 10.4.0 - FR 10.3.12 -->

Up to now, a GQI query starting from a DOM node would return columns that contained multiple values due to being linked to SectionDefinitions that allowed multiple sections in one DOM instance. However, when displayed in a table, those columns would only show the first value found in the DOM instance. Also, when you sorted the data by one of those columns, in some cases, the order would seem random as the database would pick either the lowest or highest value available for a field when sorting.

From now on, when GQI detects that having multiple sections is allowed for a particular SectionDefinition, all fields part of that SectionDefinition will no longer be returned as columns.

> [!IMPORTANT]
> This change will break any existing query that references columns containing multiple values due to being linked to SectionDefinitions that allowed multiple sections in one DOM instance.

#### Page size when retrieving element data from Cassandra has been set to 5000 [ID_37673]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

For performance reasons, the page size when retrieving element data from a Cassandra database has been changed from 50000 to 5000.

> [!NOTE]
> When retrieving element data from a MySQL or Microsoft SQL Server database, the page size remains set to 50000.

#### Storage as a Service: Enhanced performance when migrating data from Cassandra to the cloud [ID_37740]

<!-- MR 10.4.0 - FR 10.3.12 [CU0] -->

Because of a number of enhancements, overall performance has increased when migrating data from a Cassandra database to the cloud.

#### DxMs upgraded [ID_37895]

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.5.2
- DataMiner FieldControl: version 2.9.1
- DataMiner Orchestrator: version 1.4.1
- DataMiner SupportAssistant: version 1.5.3

For detailed information about the changes included in those versions, refer to the [dataminer.services change log](xref:DCP_change_log).

### Fixes

#### NATSCustodian could incorrectly pick an offline DMA as NAS candidate [ID_37312]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when NATSCustodian had to pick a NAS candidate, in some cases, it could pick a DataMiner Agent that was offline, causing an error to occur when trying to copy the credentials.

From now on, it will only be possible to trigger a NATS configuration reset when all DataMiner Agents in the cluster are online/running.

#### Problem when requesting alarm monitoring information for an exported parameter [ID_37424]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, incorrect data would be returned when requesting alarm monitoring information for a parameter exported as a standalone parameter to a DVE child element, especially when dynamic thresholds had been configured in the alarm template.

#### Updated dynamic IP address would incorrectly be applied to all connections of an element [ID_37445]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a parameter that was used to store the dynamic IP address of an element connection was updated, the dynamic IP address would incorrectly be applied to all connections of that element when the element was restarted.

#### Problem with ExistsCustomDataTypeRequest message when using a database other than Cassandra [ID_37470]

<!-- MR 10.4.0 - FR 10.3.12 -->

On systems using a database other than Cassandra, up to now, an `ExistsCustomDataTypeRequest` message would always return false and cause an error to be logged in the *SLDBConnection.txt* and *SLErrors.txt* files.

#### Element connections would not work with destination tables that had naming configured [ID_37478]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

Element connections would not work with destination tables that had naming configured.

#### Duplicate PropertyChangeEvent objects would be created in the event cache [ID_37485]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, incorrect duplicate PropertyChangeEvent objects would be created in the event cache.

The properties were correctly updated on the respective elements, but the DMAs that forwarded the requests would incorrectly generate additional, incorrect PropertyChangedEvents, which could lead to, for example, outdated property values being displayed in user interfaces.

#### Cassandra: Problem with health monitor after reconnecting [ID_37494]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the Cassandra health monitor reconnected to a remote Cassandra or Cassandra Cluster database, in some cases, an error could occur.

#### SLAnalytics: Problem when simultaneously stopping the 'Alarm Focus' and 'Automatic Incident Tracking' features [ID_37496]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when you stopped both *Alarm Focus* and *Automatic Incident Tracking* at the same time (e.g. via *System Center > System settings > analytics config* in DataMiner Cube), only *Alarm Focus* would actually be stopped. *Automatic Incident Tracking* would still be active, but in an incorrect state.

#### Service & Resource Management: Problem with resource capability exposers [ID_37503]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a resource did not have both a minimum and maximum value for a particular range point, the resource capability exposers would not work correctly for that range point.

#### Cassandra Cluster Migrator tool would stop migrating certain tables after 1000 rows [ID_37513]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*) was migrating tables from MySQL to Cassandra Cluster, in some cases, it would incorrectly stop after 1000 rows.

#### Storage as a Service: Row limits were disregarded when a post filter was applied to a query result [ID_37515]

<!-- MR 10.4.0 - FR 10.3.12 -->

In cases where SLDataGateway retrieved an entire table and then applied a filter afterwards, any row limits defined for the query in question would incorrectly be disregarded.

#### Storage as a Service: Paged data retrieval operations would be cut off prematurely [ID_37533]

<!-- MR 10.4.0 - FR 10.3.12 -->

When reading data from the database page by page, in some cases, the operation would be cut off prematurely.

#### Elasticsearch/OpenSearch: Problem when a repository failed to initialize [ID_37550]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a repository failed to initialize, all subsequent initialization attempts would throw a `NullReferenceException`.

#### DELT export of an element from a Cassandra Cluster would incorrectly not include any data [ID_37557]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a DELT export of an element was performed on a DataMiner Agent running a Cassandra Cluster database, the import package would incorrectly not contain a database folder. As a result, no data from the element in question would be exported.

Also, DELT exports would incorrectly not include the mask status of elements or alarms.

#### Newly created element could get assigned the same DmaId/ElementId key as another, already existing element [ID_37560]

<!-- MR 10.4.0 - FR 10.3.12 -->

In some cases, a newly created element could get assigned the same DmaId/ElementId key as another, already existing element on another DataMiner Agent in the cluster. From now on, this will be prevented as long as the DataMiner Agents in questions can communicate with each other.

#### PropertyChangeEvents would not be removed from the SLNet event cache when an element was deleted [ID_37576]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When an element was deleted, `PropertyChangeEvent` instances for that element would incorrectly not get removed from the SLNet event cache.

#### Alerter: Problem when connecting to a DataMiner Agent using gRPC [ID_37580]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When Alerter connected to a DataMiner Agent using gRPC, on each subsequent startup, it would display a message box showing the following error:

`There is no connection available, please add one.`

#### SLAnalytics: Problem after losing connection with SLDataGateway [ID_37603]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When SLAnalytics lost connection with SLDataGateway, an exception would be thrown, causing SLAnalytics to become unresponsive.

#### DataMiner Object Models: DomManager would not initialize when it received its first call [ID_37604]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the first call to a DomManager after a DMA (re)start was a call to create, update or delete a HistoryChange object, the call would fail and the DomManager would not initialize.

#### Service & Resource Management: Problem when updating a booking using resources that had been used by other bookings in the past [ID_37647]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When you updated a booking using resources that had also been used earlier by other bookings in the past, a concurrency error could incorrectly be thrown.

#### SLAnalytics - Behavioral Anomaly Detection: Change in trend would incorrectly cause two change points to be created [ID_37703]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, for a trended parameter, a change in trend was detected, in some cases, two change points of type "trend change" would incorrectly be created.

#### SLAnalytics - Alarm focus: Problem when alarm focus cache got full [ID_37710]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the alarm focus cache got full, an error could occur in SLAnalytics.

#### Storage as a Service: Every agent in the DMS would send the average trend data to the cloud during a migration [ID_37717]

<!-- MR 10.4.0 - FR 10.3.12 -->

When data was being migrated from a Cassandra Cluster database to a STaaS database, every DataMiner Agent in the DMS would incorrectly send the average trend data to the cloud. From now on, only one of the agents will send this data.

#### Protocol VDX files imported via a DELT package would not be displayed until a DataMiner restart [ID_37781]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 [CU0] -->

When you imported a DELT package that contained protocol VDX files linked to elements in the package, in some rare cases, those VDX files would incorrectly not be displayed until after a DataMiner restart.

#### SLNetClientTest tool would not indicate that a profile migration to Elasticsearch/OpenSearch had failed due to a profile object with an invalid name [ID_37808]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 [CU0] -->

When, in the SLNetClientTest tool, you went to *Advanced > Migration*, the migration overview would not indicate that a migration of profiles towards Elasticsearch/OpenSearch had failed due to a profile object with a name longer than 32,766 characters.

#### Cassandra Cluster & STaaS: Correlation matchinfo and slidingwindow records could be overwritten [ID_37813]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 [CU0] -->

On systems using a Cassandra Cluster database or STaaS, in some cases, DataMiner Agents could overwrite each other's correlation matchinfo and slidingwindow records.

#### Profile migrations to Elasticsearch/OpenSearch will now fail when the profiles.xml file is corrupt [ID_37818]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 [CU0] -->

When you started a profile migration to an Elasticsearch/OpenSearch database while the *profiles.xml* file was corrupt, up to now, a new empty *profiles.xml* file would be created and the migration would continue. From now on, no new *profiles.xml* file will be created anymore and the migration will go into an error status.

> [!NOTE]
> When, in the SLNetClientTest tool, you go to *Advanced > Migration*, all migrations in an error status will now have a red background.
