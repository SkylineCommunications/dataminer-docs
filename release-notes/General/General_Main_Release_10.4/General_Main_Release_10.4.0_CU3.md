---
uid: General_Main_Release_10.4.0_CU3
---

# General Main Release 10.4.0 CU3 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### 'Database Security' BPA test has been replaced by the 'Security Advisory' BPA test [ID_38632]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.5 -->

The *Database Security* BPA test has been replaced by the *Security Advisory* BPA test, which will run a collection of checks to see if the system is configured as securely as possible.

For more information on this new BPA test, see [Security Advisory](xref:BPA_Security_Advisory).

#### Simple alarm filters can now be translated to Elasticsearch/OpenSearch queries [ID_38898]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Simple alarm filters (without operators and/or brackets) can now be translated to Elasticsearch/OpenSearch queries. This will increase overall performance of Elasticsearch/OpenSearch queries containing alarm filters as alarm filtering will now be performed by the database itself. Post-filtering query results will no longer be needed.

#### Enhanced performance when processing changes made to service properties [ID_39011]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when processing changes made to service properties.

#### NATS configuration files will now use plain JSON syntax [ID_39078]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

All NATS configuration files will now use plain JSON syntax.

#### GQI: The IGQIOnInit and IGQIOnDestroy interfaces can now also be used in custom operators [ID_39088]

<!-- MR 10.4.0 [CU3] - FR 10.4.5 -->

From now on, the `IGQIOnInit` and `IGQIOnDestroy` interfaces can also be used in custom operators.

For more information on these interfaces, see:

- [IGQIOnInit interface](xref:GQI_IGQIOnInit)
- [IGQIOnDestroy interface](xref:GQI_IGQIOnDestroy)

#### GQI: Metrics for requests, first session pages and all session pages [ID_39098]

<!-- MR 10.4.0 [CU3] - FR 10.4.5 -->

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

#### Enhanced performance when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client [ID_39211]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Performance has increased when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client.

#### Enhanced performance when starting up a DataMiner Agent [ID_39331]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner Agent.

#### No longer possible to create new elements as long as SLDataMiner has not finished loading all element information [ID_39392]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

From now on, it will no longer be possible to create new elements as long as SLDataMiner has not finished loading all element information. If an attempt is made to create an element while SLDataMiner is still loading element information, an `Agent is starting up` error will now be returned.

### Fixes

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID_38441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### Protocols: Parsing problem could lead to string values being processed incorrectly [ID_39314]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

When string parameters are parsed, both an ASCII version and a Unicode version of the string value should be returned. However, up to now, when a string parameter was a table column parameter, the `Interprete` type of the table would be used. As a result, string values would be processed incorrectly.

From now on, when a table cell is saved, the `Interprete` type of the column will be used to determine whether or not it has to be processed as a string.

#### SLProtocol would return an error when it encountered the parameter type 'matrix' [ID_39398]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Up to now, SLProtocol would add the following line in the log file of an element when it encountered the [parameter type "matrix"](xref:UIComponentsTableMatrix).

`CParameter::ReadSettings|CRU|-1|!! Unknown <Type> MATRIX for parameter`

#### SLAutomation: Problem when clearing the internal parameter cache [ID_39441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

In some cases, an error could occur in SLAutomation when its internal parameter cache was being cleared.
