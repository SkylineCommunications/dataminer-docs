---
uid: General_Main_Release_10.5.0_CU13
---

# General Main Release 10.5.0 CU13 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU13](xref:Cube_Main_Release_10.5.0_CU13).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU13](xref:Web_apps_Main_Release_10.5.0_CU13).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID 44579]

<!-- 44579: MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

A number of security enhancements have been made.

#### SLDataGateway: StorageTypeNotFoundException will now always mention the StorageType that could not be found [ID 44603]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLDataGateway throws a `StorageTypeNotFoundException`, from now on, the message will always mention the StorageType that could not be found.

#### An updated parameter value will no longer be written to the database if it is equal to the old value [ID 44609]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a user or a QAction updated a parameter value, up to now, the new value would always be written to the database, even when the new value was equal to the old value.

From now on, when the new value is equal to the old value, the value will no longer be written to the database. If any triggers or QActions are configured to be executed following a parameter update, these will still be executed.

Also, write parameters will no longer be saved as this would cause unnecessary load.

#### Enhanced distribution of SNMPv3 traps [ID 44626]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a DMA receives an SNMPv3 trap that it cannot process (e.g. because the SNMPv3 user is unknown), and trap distribution is enabled, from now on, the trap will be distributed to the other DMAs in the cluster in an attempt to have it processed by one of those other DMAs.

Also, in some cases, traps could be forwarded to the wrong elements because the SNMPv3 USM ID was not validated correctly.

### Fixes

#### Problem with SLNet when receiving a subscription with a large filter that contained wildcards [ID 44512]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLNet received a dynamic table subscription with a very large filter that contained wildcards, up to now, it would throw a stack overflow exception and stop working.

From now on, SLNet subscriptions will now be blocked when they contain a filter that exceeds 140,000 characters.

#### SLNetClientTest tool: External authentication would not work when the Microsoft Edge (WebView2) browser engine was installed on a per user basis [ID 44583]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When you connected to a DataMiner Agent, up to now, it would not be possible to use external authentication from a client computer on which the Microsoft Edge (WebView2) browser engine was installed on a per user basis.

> [!NOTE]
> When the Microsoft WebView2 browser engine is installed on a per user basis, it will be automatically updated each time you open Microsoft Edge.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Alarm properties passed along by Correlation or SLAnalytics could get lost when an alarm was created [ID 44669]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some cases, alarm properties passed along by Correlation or SLAnalytics could get lost when an alarm was created.

#### API Gateway would incorrectly add multiple routes with the same basePath when multiple registration requests were received for the same route [ID 44676]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When multiple registration requests were received for the same route, in some cases, instead of updating the route, API Gateway would incorrectly add multiple routes with the same basePath. As a result, the proxy would not be able to route the HTTP request.

#### Failover: Two Agents in a Failover pair could get stuck during startup [ID 44680]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some cases, the two Agents in a Failover pair could get stuck during startup.
