---
uid: General_Main_Release_10.4.0_CU11
---

# General Main Release 10.4.0 CU11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU11](xref:Cube_Main_Release_10.4.0_CU11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU11](xref:Web_apps_Main_Release_10.4.0_CU11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security Advisory BPA test: Enhancements [ID 41385]

<!-- MR 10.5.0 / 10.4.0 [CU11] - FR 10.5.2 -->

A number of minor enhancements have been made to the *Security Advisory* BPA test.

#### History Manager: A clearer exception will now be thrown when the History Manager API is used after the History Manager has been stopped [ID 41500]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When the History Manager API was used to perform create, update or delete operations after the History Manager had been stopped, up to now, a `NullReferenceException` would be thrown.

From now on, when the History Manager API is used after the History Manager has been stopped, the following `DataMinerException` will be thrown and logged:

`There is no known manager that can process objects for Manager X. Check if the manager has been initialized, the agent is licensed and is using the required database.`

#### SLLogCollector packages now also contain information about the NATS connections that were closed [ID 41504]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

SLLogCollector packages now also include the *ClosedConnections.json* file, which contains information about the NATS connections that were closed.

#### Storage as a Service: Enhanced performance when updating alarm information [ID 41581]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Because of a number of enhancements, overall performance has increased when updating alarm information on STaaS systems.

#### DataMiner Cube server-side search engine: Enhanced performance [ID 41643]

<!-- MR 10.4.0 [CU11]/10.5.0 - FR 10.5.2 -->

Because of a number of enhancements, overall performance of the DataMiner Cube server-side search engine has increased.

#### Clearer error message when generating a PDF report based on a dashboard fails [ID 41661]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In the *Automation*, *Correlation* and *Scheduler* modules, you can generate a PDF report based on a dashboard.

When an error occurred while generating the PDF file, up to now, the following error message would be logged in the log file of *Automation*, *Correlation* or *Scheduler*:

```txt
2024/12/09 08:45:02.635|SLScheduler.exe 10.5.2449.76|27128|26140|CRequest::Request|ERR|5|Remote Request for -SLNet- on -VT_EMPTY- failed.  (hr = 0x8013150C)
Type 126/0/0
MESSAGE: Type 'Skyline.DataMiner.Net.ReportsAndDashboards.ReportsAndDashboardsException' in Assembly 'SLNetTypes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9789b1eac4cb1b12' is not marked as serializable.
```

A clearer error message will now be logged. The `ReportsAndDashboardsException` has been marked as serializable.

#### SLLogCollector packages can now include a memory dump of the w3wp process in case of web API issues [ID 41664]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

From now on, SLLogCollector packages can also include a memory dump of the *w3wp* process in case of web API issues.

#### EPM systems: Enhanced performance when aggregating large datasets [ID 41685]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Because of a number of enhancements, on EPM systems, overall performance has increased when aggregating large datasets.

### Fixes

#### SLNet could stop working due to NATS throwing an exception [ID 41396]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some rare cases, SLNet could stop working due to NATS throwing an exception.

#### Parameter values that were never updated would incorrectly not be sent to a client application [ID 41414]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some rare cases, parameter values would incorrectly not be sent to a client application, especially when those values were never updated.

#### NT_FILL_ARRAY_WITH_COLUMN call would silently fail when providing a string[] instead of an object[] for the keys and values [ID 41511]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When an NT_FILL_ARRAY_WITH_COLUMN call was performed in a QAction, up to now, it would silently fail when providing a string[] (or any other type of object that is allowed in an object[]) instead of an object[] for the keys and values. This would also affect all wrapper methods that accept an object[] argument.

A cast and type check has now been added to the following calls in order to prevent this type mismatch issue from going unnoticed:

- `protocol.FillArrayWithColumn(...)`
- `protocol.FillArray(...)`
- `protocol.FillArrayNoDelete(...)`
- `protocol.NotifyProtocol(220, ...)`

From now on, when an invalid type is passed to one of these methods, the error that is thrown will automatically be logged in the element's log file.

#### Problem with SLDataMiner when deleting a connector [ID 41520]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some rare cases, SLDataMiner could stop working when a connector was deleted immediately after an element using that connector had been deleted.

#### Cassandra compaction settings would incorrectly be overwritten at DataMiner startup [ID 41551]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Up to now, all Cassandra compaction settings would incorrectly be overwritten at DataMiner startup.

For example, if you had manually configured a compaction setting (e.g. *unsafe_aggressive_sstable_expiration*), this change would get overwritten by the default setting.

#### DataMiner Maps: Markers that did not match the alarm level filter would become visible for a split second [ID 41555]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you zoomed to a different layer while an alarm level filter was active, in some cases, markers that did not match the filter would become visible for a split second before disappearing again.

#### NATS: A large number of "duplicate route" and "created route" entries would get added to the NATS server logging [ID 41616]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When a large DataMiner System included agents in a Failover setup, the more agents were present in this DMS, the more "duplicate route" and "created route" entries would get added to the NATS server logging.
