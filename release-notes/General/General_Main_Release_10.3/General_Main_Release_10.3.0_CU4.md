---
uid: General_Main_Release_10.3.0_CU4
---

# General Main Release 10.3.0 CU4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Enhanced performance when retrieving resources [ID_36129]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

Because of a number of enhancements, overall performance has increased when retrieving resources.

#### Failover: Obsolete CheckVIPs thread has been removed [ID_36253]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In Failover setups using virtual IP addresses, once every minute the CheckVIPs thread would check whether the online Agent holds the correct IP addresses. However, due to the many locks it claimed to verify the current state of the IP addresses, it would delay other actions being executed in the system.

This obsolete thread has now been removed.

### Fixes

#### Service & Resource Management: Contributing resources of which the contributing booking had ended would not be marked available [ID_35757]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When updating an ongoing main booking that made use of a contributing resource of which the contributing booking had already ended, the ResourceManager would incorrectly mark the contributing resource as unavailable. As a result, the update would fail and the main booking would go into quarantine with reason "ContributingResourceNotAvailable".

Also, a *GetEligibleResources* call would not return the contributing resource.

#### Business Intelligence: Secondary index of certain SLA logger tables would not be created correctly [ID_36245]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

The secondary index of certain SLA logger tables would not be created correctly. As a result, certain rows in those tables would not get cleaned up and exceptions like the following would be added to the *SLDBConnection.txt* log file:

```txt
SLDataGateway.Types.DBGatewayException: CassandraConnection ExecuteQuery - exception while executing query: SELECT "array_active_service_alarms_id","array_active_service_alarms_time" FROM ELEMENTDATA_7102_1334_750 WHERE "array_active_service_alarms_rootid" = '0/0'; - Cannot execute this query as it might involve data filtering and thus may have unpredictable performance. If you want to execute this query despite the performance unpredictability, use ALLOW FILTERING
```

When SLAs were stored in a Cassandra cluster, none of their rows would get cleaned up.

#### Service & Resource Management: Problem when updating a booking while actions were being performed [ID_36268]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When a booking was updated while actions were being performed, in some cases, it could become corrupted.

For example, when a booking was rescheduled while it was being started, it could end up in an *Ongoing* status with a start time somewhere in the future.

#### Protocols: QAction syntax errors did not refer to the correct lines [ID_36301]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, before a QAction was compiled, three compiler directives were added to its source code. As a result, all compilation errors would refer to incorrect line numbers.

From now on, the compiler directives will no longer be added to the source code. Instead, they will be passed to the compiler directly.
