---
uid: General_Feature_Release_10.2.9
---

# General Feature Release 10.2.9 – preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.9](xref:Cube_Feature_Release_10.2.9).

## Highlights

##### BREAKING CHANGE: Removing a Resource or ResourcePool object will now always require a valid ID [ID_33836]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, it was possible to delete Resource and ResourcePool objects in a filtered way by passing an "incomplete" object to the associated remove method of the ResourceManagerHelper. Moreover, passing an empty list or NULL would remove all resources on the system. This will no longer be possible.

From now on, it will only be possible to remove Resource objects by ID or name (case sensitive) and ResourcePool objects by ID.

When DataMiner detects a remove request that contains an object with an empty ID (and an empty name in case of a request to remove a Resource object, one of the following messages will be added to the *ResourceManager.txt* log file (type: info):

- In case of a request to remove a Resource object:

    ```txt
    Detected a resource delete request that contained at least one object without an ID. Deleting resources with resource object filters is not supported anymore.
    ```

- In case of a request to remove a ResourcePool object:

    ```txt
    Detected a resource pool delete request that contained at least one object without an ID. Deleting resource pools with object filters is not supported anymore.
    ```

> [!NOTE]
> From now on, the log entries added when creating or deleting resources or resource pools will no longer contain the IDs of all objects that were created or deleted. Instead, they will only contain the IDs of the first 10 objects that were created or deleted.

## Other new features

#### Dashboards app / Low-Code Apps - Service Definition component: Text displayed on process automation service definition node will now be the value of that node's Label property [ID_33754]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, when a Service Definition component displayed a service definition of type "Skyline Process Automation" or "Custom Process Automation", the name of the associated function definition would be displayed on the nodes. From now on, the text displayed on a particular node will be the value of that node's *Label* property. Only when no *Label* property could be found will the name of the associated function definition be displayed instead.

#### Web apps now also support parameter comments configured in Param.Message elements [ID_33784]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When configuring a parameter in a protocol, you can add a `<Message>` element containing a comment to be displayed in a confirmation box when users change that parameter on the user interface. Up to now, this `<Message>` element was only supported by DataMiner Cube. It is now also supported by web applications like Monitoring and Dashboards.

#### SLPort: Order of parameters in an HTTP session request will be identical to that in the protocol [ID_33796]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In an HTTP session request, the order of the parameters will now always be identical to that in the protocol.

#### DVE function protocol version of active functions will now be deleted when the main DVE protocol version is deleted [ID_33834]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a version of a DVE protocol with function DVE protocols is deleted from the system while functions are active, from now on, the function DVE protocol versions associated with those active functions will also be removed from the system.

#### Dashboards app: Parameter tables can now expose index values & Edit panel now allows selecting a specific protocol version [ID_33841]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, a parameter table was only able to expose indices as part of a parameter value. From now on, a parameter table will also be able to expose indices as separate values.

Also, the edit panel will now allow users to select a specific protocol version.

#### DataMiner web apps updated to Angular 13 [ID_33869]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The DataMiner mobile apps that use Angular (e.g. low code apps, Dashboards, Monitoring, Ticketing, Jobs and Automation) now use Angular 13 instead of Angular 12.

#### Dashboards app - GQI: 'Line & area chart' component is now able to visualize GQI query results as a single line [ID_33879]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The *Line & area chart* component is now able to visualize GQI query results as a single line.

1. Add GQI query data to the chart component.

1. In the component settings tab:

    1. Select the query.
    1. Select the X axis column.
    1. Select the Y axis column.

1. In the component layout, adapt the style of the chart.

> [!NOTE]
> If you want the component to show a classic trend chart, make sure the query result is sorted by the X axis column.

#### Azure Active Directory: Secret expiry notices/errors [ID_33916]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When Azure Active Directory is used as an identity provider, DataMiner Cube will now show:

- a notice when the secret will expire in less than a week, and
- an error when the secret has expired.

Also, more detailed entries will now be added to the logs when setup errors have been detected (missing permissions, missing configurations, expired secrets, etc.).

> [!IMPORTANT]
> Note that, for this enhancement to work, the following changes have to be made to the Azure configuration and the *DataMiner.xml* file.
>
> 1. In Azure, add the API permission *Application.Read.All*.
> 1. Copy the Azure app object ID (*Azure AD > App registrations > [your application] > Object ID*) and, in *DataMiner.xml*, add it to the *objectId* attribute of the *AzureAD* element.

#### GQI: Table columns of type 'decimal' can now also be used when filtering or aggregating data [ID_33927]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Table columns of type "decimal" can now also be used when filtering or aggregating data.

#### GQI: When all data is requested, the page size will now be calculated based on the amount of columns that are retrieved [ID_33935]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, when all GQI data was requested, the page size would always be set to 50. From now on, the page size will be set to a number between 50 and 1000, based on the amount of columns that are retrieved (max. 3000 cells).

## Changes

### Enhancements

#### Cassandra Cluster Migrator: Enhanced resilience of the migration process [ID_33467] [ID_33621] [ID_33727]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

The migration process will now be executed partition by partition. This greatly enhances the overall resilience of that process.

When the source database is a Cassandra database, at the end of a migration process, the Migrator tool will now automatically retry to migrate the partitions that could not be migrated the first time. Moreover, when you manually restart a migration with failed partitions, only those failed partitions will be included in the new migration attempt. The migration will no longer have to be redone from scratch.

Also, additional fail-safes have been built in to cope with situations where the target Cassandra database cannot be reached.

#### Serial connections: Hostname resolution enhancements [ID_33702]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a serial connection was configured with a hostname instead of an IP address, up to now, the hostname would be resolved when the port was initialized. When the hostname suddenly pointed to a different IP address, an element restart or a dynamic IP address change was needed for the serial connection to be aware of that change.

This has now been changed:

- In case of a TCP-oriented serial connection (serial SSL/TLS, SSH and serial TCP), the hostname will be resolved upon every connect.

- In case of a UDP-oriented serial connection (serial UDP), the hostname will be resolved prior to every send.

#### QA Device Simulator: Enhanced performance [ID_33761]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance of the QA Device Simulator tool has improved.

#### Failover: Enhanced performance of SLNet when communicating via NATS [ID_33807]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

On Failover systems, because of a number of enhancements, overall performance of SLNet has increased when communicating via NATS.

#### SLLogCollector: Enhanced processing of SLProtocol memory dumps [ID_33932]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, SLLogCollector is now better able to collect SLProtocol memory dumps, especially in cases where there is no reference to an element.

#### SLSNMPManager: Enhanced performance [ID_33940]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance of the SLSNMPManager process has improved.

#### Service & Resource Management: Enhancements made to ResourceManagerHelper [ID_33993]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

A number of enhancements have been made to the ResourceManagerHelper class.

For example, from now on, an ArgumentNullException will be thrown when a NULL argument is provided. Also, when a collection with one or more NULL objects is provided, those objects will be ignored.

#### Enhanced error handling in case QActions fail due to a problem with SLScripting [ID_34010]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an error occurs in SLScripting, from now on, a new SLScripting instance will be started and all QActions will be reloaded.

#### Behavioral anomaly detection: Enhancements [ID_34045]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

A number of enhancements have been made to the algorithm that is used to determine whether a change point is an anomaly.

#### Parameter changes will now only be pushed from SLProtocol to SLElement when needed [ID_34047]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, parameter changes would always be pushed from SLProtocol to SLElement. From now, those changes will only be pushed from SLProtocol to SLElement when needed.

#### GQI: Properties marked as 'read only' will now also be available [ID_34052]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When creating GQI queries, custom view, element, service and alarm properties that are marked as "read only" will now also be available.

#### Web apps: Enhanced performance when retrieving booking information [ID_34072]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance has increased when retrieving booking information in the Dashboards app and in low-code apps.

#### Dashboards app: Enhanced performance when editing a dashboard containing GQI queries [ID_34096]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in the Dashboards app, you switched to edit mode, all columns of all GQI queries on the dashboard in question would be retrieved. From now, only when you open a specific query on the dashboard you are editing will the columns of that specific query be retrieved.

### Fixes

#### SLLogCollector would become unresponsive when the name of the process or the path where the files had to be stored contained spaces [ID_33493]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

While collecting log information, SLLogCollector would become unresponsive when the name of the process or the path where the collected files had to be stored contained spaces.

#### SLProtocol would leak memory leak each time a parameter of a replicated element was updated [ID_33745]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

SLProtocol would leak memory each time a parameter of a replicated element was updated.

#### Web services API would incorrectly no longer clear a number of its caches when the connection was lost [ID_33764]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When the connection was lost, the web services API would incorrectly no longer clear a number of its caches.

#### Service & Resource Management: Child DVE element would not get activated when the main DVE element was in an error state [ID_33787]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you tried to create a booking with a child DVE element linked to a main DVE element in an error state, the child DVE element would not automatically be activated, causing the booking to fail. Moreover, SLNet would not try to activate this child DVE element, causing subsequent bookings needing that same child DVE element to also fail, even if the main element had already recovered from the error state in the meantime.

#### Problem with SLAnalytics when an element or a parameter was deleted [ID_33788]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When an element or a parameter was deleted, in some rare cases, an error could occur in the SLAnalytics process.

#### GQI: Columns of type 'decimal' would incorrectly not be treated as columns of type 'numeric' [ID_33792]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Columns of type "decimal" would incorrectly be treated as columns of type "string" instead of columns of type "numeric".

#### Dynamic virtual elements: Problem when processing table columns containing foreign keys [ID_33810]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a table contained multiple foreign keys, invalid foreign key values referring to non-existing rows could prevent those rows from being exported to DVE child elements. This would cause alarms, trend information, subscriptions, etc. to not get updated for specific DVE elements and/or virtual functions.

#### Web apps: Visio files would not get rendered correctly [ID_33812]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, Visio files would not get rendered correctly in web apps (e.g. Dashboards).

#### SLAnalytics: Error messages could get added to the log file due to a problem with the automatic incident tracking algorithm [ID_33820]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Due to a problem with the automatic incident tracking algorithm, error messages similar to the following one could incorrectly get added to the SLAnalytics log file:

```txt
2022/06/08 23:54:36.684|SLAnalytics|Counter.h(61): containers::Counter<ServiceInfo>::decrease)|ERR|0|Decreasing counter for key that is not in the map
```

#### Problem with SLElement when resolving foreign keys took a long time and the the element debug log level was equal to or higher than 1 [ID_33826]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When the element debug log level was equal to or higher than 1, an error could occur in SLElement when resolving foreign keys took a long time.

#### Dashboards app - Service definition component: Function nodes not displaying number of Process Automation tokens in queue or in progress [ID_33848]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a Process Automation definition was added to a *Service definition* component, the function nodes would not display the number of tokens currently in queue or in progress.

#### Web apps: No group row would appear when you selected a single item in a list view [ID_33858]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When you selected a single item in a list view, in some cases, no group row would appear.

#### SNMPv3 credentials would incorrectly be checked when replicating an element with SNMPv3 connections [ID_33859]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you replicated an element with SNMPv3 connections, the SNMPv3 credentials of that element would incorrectly be checked. As a result, alarms like the following one would appear in the Alarm Console:

```txt
Load Element Failed: Error parsing SNMPv3 password for element: <element name>
```

#### SLProtocol could leak memory when the NT_UPDATE_PORTS_XML command was sent [ID_33891]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, the SLProtocol process could leak memory when the NT_UPDATE_PORTS_XML command was sent.

#### Certain types of alarms could affect and degrade an SLA [ID_33899]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an alarm of one the following types was generated, in some cases, that alarm could affect and degrade an SLA or be added to the list of active alarms for that SLA (i.e. enhanced service):

- Information Event
- Suggestion Event
- Error Alarm
- Notice Alarm

#### SLSNMPManager: StackOverflow exception while trying to resolve the next Request ID [ID_33901]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, SLSNMPManager could throw a StackOverflow exception while trying to resolve the next Request ID.

#### Azure Active Directory: Domain users who were only a member of a domain group could be deleted during an LDAP synchronization [ID_33916]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When using Azure Active Directory as an identity provider, up to now, during an LDAP synchronization, all domain users who were only a member of a domain group would incorrectly be deleted when the Azure AD client secret had expired.

#### SLDataMiner would incorrectly no longer accept 'protocol' as a valid scriptingProcesses option [ID_33970]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

In *DataMiner.xml*, the `scriptingProcesses` option can be set to an integer value, to "[service]" or to "protocol". However, SLDataMiner would incorrectly no longer accept the latter as a valid option.

#### DataMiner Object Model: FieldValues would not get concatenated correctly [ID_33989]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When a name concatenation for a DomInstance had been defined in either the ModuleSettings or the DomDefinition, in some cases, the FieldValues would not get concatenated correctly.

#### Dashboards app: Dashboards with components containing a time-related setting would no longer load [ID_34017]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When a dashboard created in a DataMiner version prior to v10.2.9 had at least one of the following components that contained a time-related setting it would no longer load.

- Alarm list
- Bar chart
- Pivot table
- Resource capacity (line chart)
- Time range feed
- Trend graph
- Trend statistics
- Scheduler

#### Elasticsearch: Closed alarms were incorrectly not migrated to the dms-alarms index when the associated element had been migrated from another DMS [ID_34020]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When, on a system with an Elasticsearch database, an alarm was closed, that alarm would incorrectly not get moved from the dms-Activealarms index to the dms-alarms index when the associated element had been migrated from another DMS.

#### DataMiner upgrade: Upgrade action 'DeletePreRN28047CustomDataTemplates' would fail when Elasticsearch required authentication [ID_34029]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

During a DataMiner upgrade, the upgrade action *DeletePreRN28047CustomDataTemplates* would fail when Elasticsearch required authentication.

#### Web apps - Data table component: Filter specified in search box would incorrectly not be re-applied after a data refresh [ID_33385]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When you hover over a data table component (e.g. a GQI table), a search box will appear in the bottom-right corner. In some cases, the filter specified in that search box would incorrectly not be re-applied after a data refresh.

#### An alarm property with a name identical to that of an element, service of view property would incorrectly get duplicated when the element with that alarm property was restarted [ID_34021]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you created an alarm property with a name identical to an existing property of an element, service or view, that alarm property would incorrectly be duplicated each time the element with that alarm property was restarted.

> [!NOTE]
> When upgrading to v10.2.0 [CU6] or v10.2.9, an upgrade action will check the *PropertyConfiguration.xml* file for any issues with duplicate properties and correct them.

#### Problem with SLSNMPManager when an SNMP Get or Set was put on the queue while the element in question was being stopped [ID_34038]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, an error could occur in the SLSNMPManager process due to an SNMP Get or Set having been put on the queue while the element in question was being stopped.

#### GQI: No longer possible to select another row after collapsing a group containing a selected row [ID_34042]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in a GQI table, you collapsed a group that contained a selected row, it was no longer possible to select another row.

#### Jobs app: Corrected start time would be saved incorrectly [ID_34043]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When, after receiving a message that it was not possible to save a job because of an invalid start time, you had corrected the start time and tried to save the job again, that start time would get saved incorrectly.

#### GQI: Problem when filtering or aggregating data by custom properties [ID_34058]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, it would no longer be possible to build a GQI query that filtered or aggregated data by custom properties.

#### Logger tables not deleted when stopped element was deleted [ID_34067]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a stopped element was deleted, logger tables associated with that element would incorrectly not be deleted if created with `options="database"`.

#### Low-code apps: No new draft version could be created when trying to edit an app [ID_34075]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When you tried to edit a published low-code app, in some cases, no new draft version could be created.

#### Web apps: Not possible to copy table data when working in Mozilla Firefox [ID_34075]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When using the Dashboards app or a low-code app in Mozilla Firefox, it would incorrectly not be possible to copy table data by means of a right-click menu command.

#### DataMiner upgrade: AnalyticsDropUnusedCassandraTables upgrade action would fail [ID_34091]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

During a DataMiner upgrade, in some cases, the *AnalyticsDropUnusedCassandraTables* upgrade action would fail.

#### GQI queries: Problem when removing a query used as 'start from' query [ID_34093]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an exception could be thrown when removing a query that was used as "start from" query by another query.

From now on, when you try to remove a query that is used as "start from" query, a confirmation box will appear, asking you to confirm the removal of that query.
