---
uid: General_Main_Release_10.4.0_CU13
---

# General Main Release 10.4.0 CU13

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU13](xref:Cube_Main_Release_10.4.0_CU13).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU13](xref:Web_apps_Main_Release_10.4.0_CU13).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLNet: Enhanced performance when sending requests to SLDataGateway [ID 40023]

<!-- MR 10.4.0 [CU13]/10.5.0 - FR 10.4.9 -->

Because of a number of enhancements made to SLNet, overall performance has increased when sending requests to SLDataGateway.

#### Enhanced performance when updating subscriptions and when checking events against the set of active subscriptions [ID 41822]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

Because of a number of enhancements, overall performance has increased when updating subscriptions and when checking events against the set of active subscriptions.

#### Security enhancements [ID 41913] [ID 42343]

<!-- 41913: MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->
<!-- 42343: MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of security enhancements have been made.

#### Service & Resource Management: Enhanced handling of locked files when activating or deactivating functions [ID 41978]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of enhancements have been made to the ProtocolFunctionManager with regard to the handling of locked files when activating or deactivating functions.

#### Connection enhancements [ID 42233]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of enhancements have been made with regard to the connections made among DataMiner Agents as well as the connections made between DataMiner Agents and client applications.

### Fixes

#### Issue in SLNet could cause errors to be thrown in low-code apps [ID 40978]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.2 -->

Because of an issue in SLNet, after a restart of a DataMiner Agent, "not supported by the current server version" errors could get thrown in all low-code apps.

#### DataMiner Object Models: No longer possible to query DOM after initializing a Cassandra Cluster migration [ID 40993]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

After a Cassandra Cluster migration had been initialized, it would no longer be possible to query DOM.

#### Cassandra: Problem with incorrect gc_grace_seconds values [ID 41939]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

On systems with a Cassandra or Cassandra Cluster database, a number of issues have been fixed with regard to the `gc_grace_seconds` setting:

- The `gc_grace_seconds` values will no longer be updated during a DataMiner restart.
- The `gc_grace_seconds` value for trend data will now by default be set to 0.
- The `gc_grace_seconds` value for logger tables will now by default be set to 4 hours (with TTL) or to 1 day (without TTL).

#### Problem when trying to update the protocol version of an element in error [ID 41962]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When you tried to update the protocol version of an element in error via DataMiner Cube, in some rare cases, a message would incorrectly appear, stating that it was not possible to update the element.

#### Problem when deleting elements with logger tables [ID 42029]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When an element with a logger table was deleted, some items would not be removed from Cassandra and from OpenSearch/Elasticsearch:

- SLDataGateway still contained the table definitions.

- When the `databaseName` option was used, the table that had been created in a separate table schema would not be deleted.

- In case of a Cassandra Cluster, the logger table is by default stored in the `sldmadb_elementdata_<dmaid>_<elementid>_<tableid>` keyspace. When an element with a logger table was deleted, the database table would correctly be removed, but the empty keyspace would still exist.

> [!NOTE]
> When an element with a logger table is deleted, the logger table will not be deleted when it has the `customDatabaseName` or `databaseNameProtocol` option.

#### SLAnalytics: Memory leak due to an excessive number of messages being received following an alarm template update [ID 42047]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When an alarm template was updated, in some cases, the alarm focus manager could receive a excessive number of messages, causing SLAnalytics to leak memory.

#### DataMiner Taskbar Utility would incorrectly show a pop-up window when made to perform a DataMiner upgrade using the command prompt [ID 42135]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When you made SLTaskbarUtility perform a DataMiner upgrade using the command prompt, up to now, a pop-up window would appear when the DataMiner Agent was not running. As pop-up windows are only expected to appear when running in interactive mode, from now on, pop-up windows will no longer appear when you make SLTaskbarUtility perform actions using the command prompt.

#### Not possible to simultaneously update multiple TTL settings [ID 42139]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

In some cases, it would not be possible to simultaneously update multiple TTL settings.

#### MessageBroker: Subscriptions that had been disposed of would incorrectly get recreated [ID 42164]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

After a MessageBroker client had disposed of a subscription and had reconnected to NATS, in some cases, the subscription would incorrectly get recreated.

#### No alarm would be generated when an SNMPv3 element did not have its user name filled in [ID 42244]

<!-- MR 10.4.0 [CU13] - FR TBD -->

As from DataMiner version 10.4.0 [CU10]/10.5.1, when an element of type SNMPv3 does not have its user name filled in, it should go into an error state and an alarm should be generated. However, up to now, although the element went into an error state, no alarm would incorrectly be generated.

#### Problem when exporting an element to a .dmimport file [ID 42320]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

In some rare cases, exporting an element to a *.dmimport* file could fail.

#### SLNetClientTest tool: Problem when trying to connect to a DataMiner Agent using external authentication via SAML [ID 42341]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When, in the *SLNetClientTest* tool, you tried to connect to a DataMiner Agent using external authentication via SAML, the following error message would appear:

`Unable to load DLL 'WebView2Loader.dll': The specified module could not be found.`

The *WebView2Loader.dll* file will now been added to the DataMiner upgrade packages.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
