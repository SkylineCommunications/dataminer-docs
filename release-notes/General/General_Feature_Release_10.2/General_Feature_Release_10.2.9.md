---
uid: General_Feature_Release_10.2.9
---

# General Feature Release 10.2.9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.9](xref:Cube_Feature_Release_10.2.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

#### Direct view tables using columns from different protocols [ID_33253]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

It is now possible to build a direct view table using multiple columns from multiple different protocols. This can be done using the new *CrossDriverOptions* element.

For example:

```xml
<Protocol>
...
   <Params>
   ...
      <Parameter id="50000">
       ...
          <ArrayOptions index="0" options=";view=1;directView=105">
          ...
          </ArrayOptions>
          <CrossDriverOptions>
             <CrossDriverOption protocol="Protocol1" remoteTablePID="30000">
                 <PIDTranslation local="50002" remote="30002"/>
                 <PIDTranslation local="50004" remote="30005"/>
             </CrossDriverOption>
             <CrossDriverOption protocol="Protocol2" remoteTablePID="20000">
                 <PIDTranslation local="50003" remote="20002"/>
                 <PIDTranslation local="50005" remote="20003"/>
              </CrossDriverOption>
          </CrossDriverOptions>
      </Parameter>
      ...
   </Params>
   ...
</Protocol>
```

#### GQI: Improved performance when retrieving data [ID_33873] [ID_33890] [ID_33935]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Several improvements have been implemented to increase performance when GQI data is requested. At present, the most noticeable change this results in is an increase of the page size when all GQI data is requested. Up to now, when all GQI data was requested, the page size was always set to 50. From now on, the page size will be set to a number between 50 and 1000 based on the number of columns that are retrieved (max. 3000 cells).

#### Dashboards app - GQI: Line & area chart component is now able to visualize GQI query results as a single line [ID_33879]

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

#### GQI: Table columns of type decimal can now also be used when filtering or aggregating data [ID_33927]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Table columns of type "decimal" can now also be used when filtering or aggregating data.

#### GQI: Improved performance of column filter [ID_34014]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Instead of a client-side filter, a more efficient server-side filter is now used to filter columns of a table component showing GQI data in a dashboard or low-code app. This will greatly improve the filter performance. However, because this server-side filter does not support "OR" filters, it will no longer be possible to combine multiple conditions within the same filter.

#### EPM: Relation contextuality taken into account for user selections [ID_34083]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When multiple selections are made in the EPM topology tree, the possible many-to-many relations between the fields are now taken into account to load further possible selections for other fields. Previously, only the last selected field was taken into account.

For example, if a topology contains a CCAP Core field and a Node Leaf field lower in the topology, and a value is selected for both, previously only the Node Leaf selection was taken into account for the possible selections in the RPD field further down in the topology, whereas now the CCAP Core selection will also be taken into account if the RPD field is related to both fields.

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

#### BREAKING CHANGE: Removing a Resource or ResourcePool object will now always require a valid ID [ID_33836]

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

#### Dashboards app: Parameter tables can now expose index values & Edit panel now allows selecting a specific protocol version [ID_33841]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, a parameter table was only able to expose indices as part of a parameter value. From now on, a parameter table will also be able to expose indices as separate values.

Also, the edit panel will now allow users to select a specific protocol version.

#### DataMiner web apps updated to Angular 13 [ID_33869]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The DataMiner mobile apps that use Angular (e.g. Low-Code Apps, Dashboards, Monitoring, Ticketing, Jobs, and Automation) now use Angular 13 instead of Angular 12.

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

#### QActions are now IDisposable and the SLProtocol object remains available outside of the run scope [ID_33965]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The SLProtocol(Ext) object in QActions will now retain all of its data members outside of the run scope. This means that, while Notifies were already available out of scope earlier, members such as the QActionID will now also remain available when a QAction run ends. In addition, the SLNet connection can now be set up at any time.

If the QAction class is not static and implements the IDisposable interface, the Dispose() function will be called when the QAction instance is released (i.e. when the element is stopped). The same goes for any other class the entrypoint may be in. This coincides with the IsActive property of the SLProtocol object being set to false, which prevents further function calls to the object from being executed.

The Dispose is called by a separate thread than the one stopping the element. Its purpose is to release lingering resources and connections when the element is stopped.

In addition, up to now only one instance was retained per QAction, so when entrypoints pointed to different classes, the instances were not kept. Now these separate instances will also be stored correctly.

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

#### Dashboards app / Low-Code Apps: Support for feed categories in components [ID_33719]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, components could only produce one feed for each data type. Now support has been added for different categories within a data type, so that components will be able to produce several feeds for the same data type. This will for example make it possible for a component to produce a query row feed with the categories "timeline item" and "timeline band".

#### QA Device Simulator: Enhanced performance [ID_33761]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance of the QA Device Simulator tool has improved.

#### Failover: Enhanced performance of SLNet when communicating via NATS [ID_33807]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

On Failover systems, because of a number of enhancements, overall performance of SLNet has increased when communicating via NATS.

#### Maximum for element timeout setting increased to 24 hours [ID_33862] [ID_33951]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The maximum value for the element setting "*The element goes into timeout state when it is not responding for (sec)*" has now been increased from 120 seconds to 24 hours (i.e. 86400 seconds).

#### DataMiner Analytics: Improved handling of clearable alarms [ID_33910]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, DataMiner Analytics handled clearable alarms with severity "Normal" in the same way as cleared alarms. This meant that these were automatically removed from alarm groups (also known as incidents).

From now on, clearable alarms will keep the alarm focus from the last alarm in the alarm tree that had a non-normal severity. They will also stay in the same alarm group they were in before their severity became "Normal".

#### SLLogCollector: Enhanced processing of SLProtocol memory dumps [ID_33932]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, SLLogCollector is now better able to collect SLProtocol memory dumps, especially in cases where there is no reference to an element.

#### SLSNMPManager: Enhanced performance [ID_33940]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance of the SLSNMPManager process has improved.

#### Service & Resource Management: Enhancements made to ResourceManagerHelper [ID_33993]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

A number of enhancements have been made to the ResourceManagerHelper class.

For example, from now on, an ArgumentNullException will be thrown when a NULL argument is provided. Also, when a collection with one or more NULL objects is provided, those objects will be ignored.

#### Enhanced error handling in case QActions fail due to a problem with SLScripting [ID_34010]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an error occurs in SLScripting, from now on, a new SLScripting instance will be started and all QActions will be reloaded.

#### Dashboards / Low-Code Apps: Table filter improvements [ID_34022]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

If you used the search box below a table displaying GQI data to filter this data, up to now, this could cause a serious load on the server in case a large number of rows had to be retrieved. To prevent this, the following conditions will now be applied to determine if more data should be retrieved:

- If the table already has enough rows to fill the next page, no further data will be retrieved.
- If the condition above is not met, at least 250 rows will retrieved initially.
- If at least one record is found that matches the search filter, no more rows will be retrieved. You will then need to click a "Load more" button to retrieve more data.
- If 2000 additional records have been retrieved after you click "Load more", no more data will be retrieved until you click the button again.
- If you scroll through the results, additional data will be fetched until there are enough rows to fill the next page.

#### Improved SPI logging for Automation [ID_34025]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The log levels of some of the log lines related to SPIs in the *SLAutomation* log file have been changed, so that the log file does not get flooded with potentially irrelevant data. In addition, these log lines will now contain the SPI node ID and definition ID. The log line mentioning the SPI definition ID when this definition is created will no longer be added.

#### Dashboards app / Low-Code Apps: No more statistics and suggestions for conditional coloring of Table and Node edge component [ID_34037]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

To improve performance, in the *Layout* pane for a Table or Node edge component, no more statistics and suggestions will be shown for conditional coloring.

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

#### GQI: Initial support for nested tables [ID_34144]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Initial support has been added for GQI results with cells containing nested records. However, at present this is only used for the *Resources* data source, which still requires the *GenericInterface* [soft-launch option](xref:SoftLaunchOptions).

The following functionality is now available for nested tables:

- Checking the number of records in nested tables. If a column with nested tables is retrieved, you cannot inspect the nested tables themselves yet, but a display value will show the number of records they contain.
- Aggregation on a single nested table column. There is no support for grouping yet. The aggregated value of the nested cell will be shown in the parent record as an ordinary cell.
- Filtering of nested tables.
- Selecting columns from nested tables. These will be shown in the same list box as regular columns, but their name will be prefixed by the parent column name. For example, if the parent column is named "Capabilities" and the nested table column is named "Name", the column will be listed as "Capabilities.Name".

#### DataMiner upgrade: On two-node setups, the VerifyClusterPorts prerequisite will only check the ports of the NATS node that is being used by DataMiner [ID_34240]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 [CU0] -->

During an upgrade of a two-node setup (e.g. 2 single DMAs or one Failover pair), from now on, the *VerifyClusterPorts* prerequisite will only check the ports of the NATS node that is being used by DataMiner.

### Fixes

#### Web apps - Data table component: Filter specified in search box would incorrectly not be re-applied after a data refresh [ID_33385]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When you hover over a data table component (e.g. a GQI table), a search box will appear in the bottom-right corner. In some cases, the filter specified in that search box would incorrectly not be re-applied after a data refresh.

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

#### Element card - REPORTS page: Masking and unmasking not shown correctly in the different graphs [ID_33832]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

On the REPORTS page of an element card, masking and unmasking (i.e. state changes to "masked" and "unmasked") would not be shown correctly in the different graphs.

#### Dashboards app - Service definition component: Function nodes not displaying number of Process Automation tokens in queue or in progress [ID_33848]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a Process Automation definition was added to a *Service definition* component, the function nodes would not display the number of tokens currently in queue or in progress.

#### Problem with SLAnalytics [ID_33850]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.9 -->

In some cases, a problem could occur with the SLAnalytics process, causing the process to restart. This happened when the alarm repository was retrieved while the connection was being dropped.

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

#### DataMiner Analytics: 'Unknown alarm update relevance' errors in logging [ID_34016]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

In some cases, DataMiner Analytics could cause "Unknown alarm update relevance" errors to be added in the logging.

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

#### An alarm property with a name identical to that of an element, service of view property would incorrectly get duplicated when the element with that alarm property was restarted [ID_34021]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you created an alarm property with a name identical to an existing property of an element, service or view, that alarm property would incorrectly be duplicated each time the element with that alarm property was restarted.

> [!NOTE]
> When upgrading to v10.2.0 [CU6] or v10.2.9, an upgrade action will check the *PropertyConfiguration.xml* file for any issues with duplicate properties and correct them.

#### DataMiner upgrade: Upgrade action 'DeletePreRN28047CustomDataTemplates' would fail when Elasticsearch required authentication [ID_34029]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

During a DataMiner upgrade, the upgrade action *DeletePreRN28047CustomDataTemplates* would fail when Elasticsearch required authentication.

#### Problem with SLSNMPManager when an SNMP Get or Set was put on the queue while the element in question was being stopped [ID_34038]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, an error could occur in the SLSNMPManager process due to an SNMP Get or Set having been put on the queue while the element in question was being stopped.

#### GQI: No longer possible to select another row after collapsing a group containing a selected row [ID_34042]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in a GQI table, you collapsed a group that contained a selected row, it was no longer possible to select another row.

#### Jobs app: Corrected start time saved incorrectly \[ID_34043]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.9 -->

When, after receiving a message that it was not possible to save a job because of an invalid start time, you corrected the start time and tried to save the job again, that start time would get saved incorrectly.

#### DOM: FieldAlias properties not saved to database [ID_34054]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

In some cases, it could occur that properties of a FieldAlias DOM object could not be saved to the database.

#### GQI: Problem when filtering or aggregating data by custom properties [ID_34058]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, it would no longer be possible to build a GQI query that filtered or aggregated data by custom properties.

#### Incorrect instance alarm level after restart and for view tables [ID_34063]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Since DataMiner 10.1.8 (RN [30044](xref:General_Feature_Release_10.1.8#instancealarmlevel-would-not-fall-back-to-cellactualalarmlevel-when-there-was-bubble-up-information-but-no-instance-information-id_30044)), it could occur that the instance alarm level for a table row did not bubble up correctly, causing alarms for view tables to be displayed incorrectly (e.g. in an EPM environment). This could also occur for tables with an alarm where no saved data was present.

#### Potential minor memory leak in SLProtocol if fixed parameter had length of zero [ID_34064]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If a fixed parameter had a length of zero, a minor memory leak could potentially occur in SLProtocol. Though it is unlikely that this could ever happen, as a fixed parameter usually contains data, this issue will now be prevented.

#### Logger tables not deleted when stopped element was deleted [ID_34067]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a stopped element was deleted, logger tables associated with that element would incorrectly not be deleted if created with `options="database"`.

#### Low-Code Apps: No new draft version could be created when trying to edit an app [ID_34075]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When you tried to edit a published low-code app, in some cases, no new draft version could be created.

#### Web apps: Not possible to copy table data when working in Mozilla Firefox [ID_34075]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When using the Dashboards app or a low-code app in Mozilla Firefox, it would incorrectly not be possible to copy table data by means of a right-click menu command.

#### GQI: Regex filter on empty cell not working correctly [ID_34088]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a filter with a regular expression was applied to an empty cell of a GQI query, it could occur that this did not work correctly. This issue only occurred for custom columns of a DOM instance and for custom data sources.

#### DataMiner upgrade: AnalyticsDropUnusedCassandraTables upgrade action would fail [ID_34091]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

During a DataMiner upgrade, in some cases, the *AnalyticsDropUnusedCassandraTables* upgrade action would fail.

#### GQI queries: Problem when removing a query used as 'start from' query [ID_34093]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an exception could be thrown when removing a query that was used as "start from" query by another query.

From now on, when you try to remove a query that is used as "start from" query, a confirmation box will appear, asking you to confirm the removal of that query.

#### Visual overview in dashboard or low-code app showed error while fetching its initial data [ID_34100]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a visual overview was embedded in a dashboard or low-code app, it could occur that it showed the error "Could not retrieve Visual Overview information." while fetching its initial data.

#### DataMiner web apps / Visual Overview: Trending not displayed or displayed with incorrect coloring [ID_34101]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.9 -->

If a visual overview was viewed in the web apps (e.g. the Monitoring or Dashboards app), it could occur that trend graphs in that visual overview were not displayed.
In addition, the coloring of the trend lines could be incorrect. Instead of the colors defined in the themes, the lines were shown in black.

#### GQI queries: Problem in web APIs when opening session for query with node requiring soft-launch feature [ID_34109]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In the Dashboards app or in a low-code app, when you tried to open a session for a GQI query containing a node that required a soft-launch feature, a problem could occur in the web APIs. Now an error will be shown in such a case instead.

#### GQI queries: Component data not displayed correctly [ID_34118]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a component in a dashboard or low-code app showed a GQI query, it could occur that queries and query keys were not in sync, and that data was still being fetched even though the component seemed to be fully loaded. This could for example cause connections to be missing in a node-edge graph.

#### GQI queries: Unhandled exception kept other errors from being displayed [ID_34137]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an unhandled exception in the GQI visualization could keep other errors from being displayed in the UI.

#### SLScripting instances mismatched with SLProtocol instances [ID_34167]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When the *ProcessOptions* tag in *DataMiner.xml* was configured with the attribute *protocolProcesses* set to "protocol" and the attribute *scriptingProcesses* set to "protocol" or to a number larger than one, it could occur that elements ran their QActions in the wrong SLScripting instance, which could cause compilation or load balancing issues.

This issue will now be prevented. In addition, the element's instance GUID will now be added to the element log file for easier investigations.

#### Parameter changes would not get passed from SLElement to SLNet [ID_34247]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 [CU0] -->
<!-- Not added to 10.3.0 -->

On systems with multiple network cards, in some cases, parameter changes would not get passed from SLElement to SLNet.

#### GQI: Requesting property values would incorrectly only return values cached on the local DataMiner Agent [ID_34253]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 [CU0] -->

When a GQI query requested property values by means of a GetPropertyValueMessage, some values could be missing as SLNet would only return values that were cached on the local DataMiner Agent. From now on, when a GQI query requests property values, the request will be sent to all running agents in the cluster.

#### SPI framework: Run-time errors could occur in SLDataMiner when tracking user actions [ID_34259]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 [CU0] -->

Due to a problem with the SPI framework, in some cases, run-time errors could occur in SLDataMiner when tracking user actions.
