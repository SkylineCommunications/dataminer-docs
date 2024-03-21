---
uid: General_Feature_Release_10.4.5
---

# General Feature Release 10.4.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.5](xref:Cube_Feature_Release_10.4.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.5](xref:Web_apps_Feature_Release_10.4.5).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### New SLTimeToLive.txt log file containing all changes made to the TTL settings [ID_38851]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In the `C:\Skyline DataMiner\Logging\SLTimeToLive` folder, you can now find a new *SLTimeToLive.txt* log file, listing all changes made to the TTL settings in Cube's *System Center > System settings > Time to live* page.

> [!NOTE]
> The contents of this folder will not be deleted during either a DataMiner restart or a DataMiner upgrade. However, in the *SLTimeToLive.txt* file, the oldest entries will be removed when the maximum log file size is exceeded.

#### STaaS: SLDataGateway will now periodically check the health of the storage service [ID_39068]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When Storage as a Service (STaaS) is used, SLDataGateway will now periodically check the health of that storage service. If the current status cannot be determined or if the current status is "red", SLDataGateway will switch to file offload mode.

> [!NOTE]
>
> - When the current status is "yellow", SLDataGateway will not switch to file offload mode.
> - Whenever the health of the storage service changes, an alarm mentioning the current health status is generated.

#### GQI: The IGQIOnInit and IGQIOnDestroy interfaces can now also be used in custom operators [ID_39088]

<!-- MR 10.5.0 - FR 10.4.5 -->

From now on, the `IGQIOnInit` and `IGQIOnDestroy` interfaces can also be used in custom operators.

For more information on these interfaces, see:

- [IGQIOnInit interface](xref:GQI_IGQIOnInit)
- [IGQIOnDestroy interface](xref:GQI_IGQIOnDestroy)

#### GQI: Metrics for requests, first session pages and all session pages [ID_39098]

<!-- MR 10.5.0 - FR 10.4.5 -->

GQI will now log the following metrics in the `C:\Skyline DataMiner\Logging\GQI\Metrics` folder:

- Duration of the individual GQI requests:

  - Request type (e.g. GenIfOpenSessionRequest)
  - User ID (e.g. SKYLINE2\FirstName)
  - Duration (in ms)

- Duration of the first page of a session (when `SessionOptions.OptimizeType` is "NextPage"):

  - [Query name](#query-name)
  - User ID
  - Number of rows fetched
  - Duration (in ms)

  > [!NOTE]
  > For queries that retrieve data page by page on demand.

- Total duration of all the pages of a session (when `SessionOptions.OptimizeType` is "AllData"):

  - [Query name](#query-name)
  - User ID
  - Total number of rows fetched across all pages
  - Number of pages
  - Total duration (in ms), i.e. the accumulated time of the individual pages

  > [!NOTE]
  > For queries that retrieve all data at once.

##### Query name

In each GQI request that contains a query, clients can now provide an optional query name. This query name will be used in metrics and logging, and can be used to indicate the origin of the query.

The following requests now have an optional `QueryName` property:

- GenIfCapabilitiesRequest
- GenIfColumnFetchRequest
- GenIfDataFetchRequest
- GenIfMigrateQueryRequest
- GenIfOpenSessionRequest

> [!NOTE]
>
> - When the GQI log level is set to "Debug", the full query will be logged instead of the query name.
> - When an exception is thrown during a request, and the GQI log level is set to at least "Error" (which is the case by default), the query (if any) will also be logged alongside the error.

#### GQI: Implementing a custom sort order for GQI columns using a custom operator [ID_39136]

<!-- MR 10.5.0 - FR 10.4.5 -->

It is now possible to define a custom sort order for GQI columns by implementing a custom operator that "redirects" the sort operation on one column to another.

New features added to allow this include:

- Comparing `IGQIColumn` objects

- Inspecting a sort operator appended to a custom operator via the `IGQISortOperator` interface

  - List of sort fields (of type `IGQISortField`)
  - Each sort field exposes a sort column (`IGQIColumn`) and a sort direction (`GQISortDirection`)

- An `IGQIFactory` property is now exposed on the `OnInitInputArgs`, which provides factory functions to generate

  - a new `IGQISortField`
  - a new `IGQISortOperator`

## Changes

### Breaking changes

#### DOM string fields will now be filtered case-insensitively [ID_38950]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, DOM string fields would be filtered case-sensitively. From now on, those fields will by default be filtered case-insensitively.

> [!NOTE]
> If necessary, this default filter behavior can be overruled in code by using `StringComparison.Ordinal`. See the following snippet.
>
> ```csharp
> var filter = DomInstanceExposers.FieldValues.DomInstanceField(_stringFieldDescriptor.ID).Contains("test", StringComparison.Ordinal)
> ```

### Enhancements

#### Service & Resource Management: Enhanced performance of volume license check [ID_38705]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when performing volume license checks.

#### APIGateway now runs on .NET 8 and allows you to enable kernel response buffering [ID_38710]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

APIGateway has been upgraded. It now runs on Microsoft .NET 8.

This service now allows you to enable kernel response buffering, which should improve throughput and responsiveness over high-latency connections. This setting is disabled by default. To enable it, do the following:

1. In the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder of the DataMiner Agent, create a JSON file named *appsettings.custom.json*.
1. Open this JSON file, and add the following content:

   ```json
   { "HostingOptions": { "EnableKernelResponseBuffering": true } }
   ```

#### Automation: Cassandra Ready check will now only be performed on DataMiner Systems using a MySQL database [ID_38760]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, Automation scripts would always be checked whether they were Cassandra ready, regardless of the type of database used by the DataMiner System.

From now on, this Cassandra ready check will only be performed on DataMiner Systems using a MySQL database. When the DataMiner System is using a type of database other than MySQL, Automation scripts will always be considered Cassandra ready.

#### Enhanced performance when starting up a DataMiner Agent with a large number of virtual elements [ID_38780]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner Agent with a large number of virtual elements.

#### Security enhancements [ID_38904]

<!-- RN 38904: MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

A number of security enhancements have been made.

#### Grouping of GQI event messages [ID_38913]

<!-- MR 10.5.0 - FR 10.4.5 -->

From now on, GQI event messages sent by the same GQI session within a time frame of 100 ms will be grouped into one single message.

#### Protocols: Enhanced performance when filling an array using the QActionTableRow objects in a QAction [ID_39017]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when filling an array using the `QActionTableRow` objects in a QAction.

#### SLAnalytics - Behavioral anomaly detection: Enhancements [ID_39024]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

A number of enhancements have been made with regard to the behavioral anomaly detection feature.

#### SLAnalytics: Enhanced performance when processing database operations [ID_39109]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance of SLAnalytics has increased when processing database operations, especially small insert or update operations.

#### STaaS: Text of storage service health status alarm has been made clearer [ID_39154]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Whenever the health of the storage service changes, an alarm mentioning the current health status is generated. The text of this health status alarm has now been made clearer.

### Fixes

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID_38441]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### Problem when migrating SLAnalytics data, DOM data or SRM data to STaaS [ID_38884]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When being migrated to STaaS, SLAnalytics data, DOM data or SRM data would incorrectly not be replicated. This could cause data created during the migration to be missing after the migration.

#### Not possible to delete a service created via an SRM booking when it had been assigned a name that was already being used [ID_38914]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a service created via an SRM booking got into an error state because it had been assigned a name that was already being used by another object, it would not be possible to delete it as it would be considered invalid.

#### Service & Resource Management: Problem when the function manager was not able to read the functions.xml file in C:\\Skyline DataMiner\\ServiceManager [ID_38925]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, in some cases, a run-time error could occur when the function manager was not able to read the *functions.xml* file in `C:\Skyline DataMiner\ServiceManager`.

From now on, if an error occurs when the function manager was not able to read that file, an entry will be added to the *SLFunctionManager.txt* log file, and if the error occurred because the file was locked by another process, the log entry will include the name of the process.

#### GQI: Problem when loading extensions [ID_38998]

<!-- MR 10.5.0 - FR 10.4.5 -->

When GQI extensions (i.e. ad hoc data sources or custom operators) were being loaded, in some cases, an exception could be thrown when inspecting the assembly of an extension that prevented subsequent extensions from being loaded.

This type of exceptions will be now be properly caught and logged as warnings so that other extensions will no longer be prevented from being loaded.

> [!TIP]
> See also: [GQI: Full logging [ID_38870]](xref:General_Feature_Release_10.4.4#gqi-full-logging-id_38870)

#### Problem while checking whether the DataMiner System was licensed to use the ModelHost DxM [ID_39001]

<!-- MR 10.5.0 - FR 10.4.5 -->

A *ModelHostException* could be thrown while checking whether the DataMiner System was licensed to use the ModelHost DxM.

#### STaaS: Database queries could time out [ID_39081]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When a database query was performed against a STaaS database, in some cases, the query could time out, leading to no results being returned.

#### Protocols: Compliancies element would not get parsed correctly when it contained comments [ID_39085]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, the `<Compliancies>` element of a *protocol.xml* file would not get parsed correctly when it contains HTML comments.

As a result, DataMiner would fail to open the protocol and create elements with it.

#### Visual Overview: 'Connection could not be fully established' error when viewing visual overviews in a web app [ID_39133]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When you opened a visual overview in a web app, in some cases, a `Connection could not be fully established` error would appear.

#### No emails could be sent as long as SLASPConnection was not fully initialized [ID_39137]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, an error would occur when a DataMiner module (e.g. Automation, Scheduler, etc.) tried to send an email while *SLASPConnection* was still initializing. From now on, all DataMiner modules will be able to send emails, even when *SLASPConnection* is still initializing.

#### SNMP: Timeout time of commands would incorrectly be doubled when using SNMP++ [ID_39164]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When SNMP++ was being used to communicate with a device, commands would incorrectly have their configured timeout time doubled.
