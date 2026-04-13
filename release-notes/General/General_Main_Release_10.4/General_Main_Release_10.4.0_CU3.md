---
uid: General_Main_Release_10.4.0_CU3
---

# General Main Release 10.4.0 CU3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU3](xref:Cube_Main_Release_10.4.0_CU3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU3](xref:Web_apps_Main_Release_10.4.0_CU3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### 'Database Security' BPA test has been replaced by the 'Security Advisory' BPA test [ID 38632]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.5 -->

The *Database Security* BPA test has been replaced by the *Security Advisory* BPA test, which will run a collection of checks to see if the system is configured as securely as possible.

For more information on this new BPA test, see [Security Advisory](xref:BPA_Security_Advisory).

#### Simple alarm filters can now be translated to Elasticsearch/OpenSearch queries [ID 38898]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Simple alarm filters (without operators and/or brackets) can now be translated to Elasticsearch/OpenSearch queries. This will increase overall performance of Elasticsearch/OpenSearch queries containing alarm filters as alarm filtering will now be performed by the database itself. Post-filtering query results will no longer be needed.

#### Enhanced performance when processing changes made to service properties [ID 39011]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when processing changes made to service properties.

#### NATS configuration files will now use plain JSON syntax [ID 39078]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

All NATS configuration files will now use plain JSON syntax.

#### GQI: The IGQIOnInit and IGQIOnDestroy interfaces can now also be used in custom operators [ID 39088]

<!-- MR 10.4.0 [CU3] - FR 10.4.5 -->

From now on, the `IGQIOnInit` and `IGQIOnDestroy` interfaces can also be used in custom operators.

For more information on these interfaces, see:

- [IGQIOnInit interface](xref:GQI_IGQIOnInit)
- [IGQIOnDestroy interface](xref:GQI_IGQIOnDestroy)

#### GQI: Metrics for requests, first session pages and all session pages [ID 39098]

<!-- MR 10.4.0 [CU3] - FR 10.4.5 -->

GQI will now log the following metrics in the `C:\Skyline DataMiner\Logging\GQI\Metrics` folder:

- Duration of the individual GQI requests:

  - Request type (e.g., GenIfOpenSessionRequest)
  - User ID (e.g., SKYLINE2\FirstName)
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
  - Total duration (in ms), i.e., the accumulated time of the individual pages

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

#### Enhanced performance when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client [ID 39211]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Performance has increased when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client.

#### DataMiner Cube clients using a gRPC connection are now able to better detect a disconnection [ID 39308]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, Cube clients connected to a DataMiner Agent via a gRPC connection will now be able to better detect when they have been disconnected.

#### Enhanced performance when starting up a DataMiner Agent [ID 39331]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner Agent.

#### GQI - Get parameters for element: Enhanced performance when querying sorted tables [ID 39376]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance of GQI queries using a *Get parameters for element* data source has been increased, especially when querying sorted tables.

#### No longer possible to create new elements as long as SLDataMiner has not finished loading all element information [ID 39392]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

From now on, it will no longer be possible to create new elements as long as SLDataMiner has not finished loading all element information. If an attempt is made to create an element while SLDataMiner is still loading element information, an `Agent is starting up` error will now be returned.

#### GQI - Get parameters for element: Enhanced performance when querying single-value parameters [ID 39457]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance of GQI queries using a *Get parameters for element* data source has been increased, especially when querying single-value parameters.

### Fixes

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID 38441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### Protocols: Parsing problem could lead to string values being processed incorrectly [ID 39314]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

When string parameters are parsed, both an ASCII version and a Unicode version of the string value should be returned. However, up to now, when a string parameter was a table column parameter, the `Interprete` type of the table would be used. As a result, string values would be processed incorrectly.

From now on, when a table cell is saved, the `Interprete` type of the column will be used to determine whether or not it has to be processed as a string.

#### SLProtocol would return an error when it encountered the parameter type 'matrix' [ID 39398]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Up to now, SLProtocol would add the following line in the log file of an element when it encountered the [parameter type "matrix"](xref:UIComponentsTableMatrix).

`CParameter::ReadSettings|CRU|-1|!! Unknown <Type> MATRIX for parameter`

#### Redundancy group and derived element no longer visible in UI after deleting a protocol used by elements in that redundancy group [ID 39411]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

When a protocol that was being used by elements in a redundancy group was deleted, the redundancy group and the derived element would no longer be visible in the UI after a DataMiner restart, even if their definitions existed on disk. As a result, it would not be possible to delete the redundancy group in a DataMiner client application (e.g., DataMiner Cube).

#### Service & Resource Management: Problems caused by a failed midnight synchronization of the Resource Manager [ID 39420]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

If the midnight synchronization of the Resource Manager fails, it is retried up to 5 times. Up to now, when a synchronization retry was triggered, the internal caches of the Resource Manager would incorrectly be loaded twice. This could lead to, for example, bookings not being starting.

#### SLAutomation: Problem when clearing the internal parameter cache [ID 39441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

In some cases, an error could occur in SLAutomation when its internal parameter cache was being cleared.

#### Security: Problem when granting a user group access to multiple elements in the same view [ID 39449]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

When you tried to grant a user group access to multiple elements in the same view, only the first of the elements you selected would be added.

#### Caches would not get disposed correctly when the Resource Manager was reinitialized [ID 39493]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 [CU0] -->

When the Resource Manager was reinitialized, the caches would not be disposed correctly, causing SLNet to leak memory.
