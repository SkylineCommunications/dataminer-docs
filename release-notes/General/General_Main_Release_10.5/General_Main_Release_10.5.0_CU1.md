---
uid: General_Main_Release_10.5.0_CU1
---

# General Main Release 10.5.0 CU1 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Web visual overviews: Load balancing [ID 41434] [ID 41728]

<!-- MR 10.5.0 [CU1]/10.6.0 [CU0] - FR 10.5.2 -->

It is now possible to implement load balancing among DataMiner Agents in a DMS for visual overviews shown in web apps.

Up to now, the DataMiner Agent to which you were connected would handle all requests and updates with regard to web visual overviews.

##### Configuration

In the *C:\\Skyline DataMiner\\Webpages\\API\\Web.config* file of a particular DataMiner Agent, add the following keys in the `<appSettings>` section:

- `<add key="visualOverviewLoadBalancer" value="true" />`

  Enables or disables load balancing on the DataMiner Agent in question.

  - When this key is set to **true**, for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will by default be handled in a balanced manner by all the DataMiner Agents in the cluster.

    However, if you also add the `dmasForLoadBalancer` key (see below), these requests and updates will only be handled by the DataMiner Agents specified in that `dmasForLoadBalancer` key.

  - When this key is set to **false**, for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will be handled by the local SLHelper process.

- `<add key="dmasForLoadBalancer" value="1;2;15" />`

  If you enabled load balancing by setting the `visualOverviewLoadBalancer` key to true, you can use this key to restrict the number of DataMiner Agents that will be used for visual overview load balancing.

  The key's value must be set to a semicolon-separated list of DMA IDs. For example, if the value is set to "1;2;15", the DataMiner Agents with ID 1, 2, and 15 will be used to handle all requests and updates with regard to web visual overviews.

  If you only specify one ID (without trailing semicolon), only that specific DataMiner Agent will be used to handle all requests and updates with regard to web visual overviews.

> [!NOTE]
> These settings are not synchronized among the Agents in the cluster.

##### New server messages

The following new messages can now be used to  which you can target to be sent to other DMAs in the cluster:

- `TargetedGetVisualOverviewDataMessage` allows you to retrieve a Visual Overview data message containing the image and the content of a visual overview.

- `TargetedSetVisualOverviewDataMessage` allows you to execute actions on a visual overview that is rendered on a specific DataMiner Agent.

> [!NOTE]
> DataMiner Agents will now automatically detect that a visual overview they are rendering has been updated. This means that other agents in the cluster will now be able to correctly process update events and request new images for their clients.

##### Logging

Additional logging with regard to visual overview load balancing will be available in the web logs located in the *C:\\Skyline DataMiner\\Logging\\Web* folder.

#### Enhanced performance when updating subscriptions and when checking events against the set of active subscriptions [ID 41822]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

Because of a number of enhancements, overall performance has increased when updating subscriptions and when checking events against the set of active subscriptions.

#### Security enhancements [ID 41913] [ID 42104] [ID 42343]

<!-- 41913: MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->
<!-- 42104: MR 10.5.0 [CU1] - FR 10.5.4 -->
<!-- 42343: MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of security enhancements have been made.

#### Service & Resource Management: Enhanced handling of locked files when activating or deactivating functions [ID 41978]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of enhancements have been made to the ProtocolFunctionManager with regard to the handling of locked files when activating or deactivating functions.

#### NATS: NatsCustodianResetNatsRequest will now be blocked when the NATSForceManualConfig option is enabled [ID 42074]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

When the `NATSForceManualConfig` option is enabled in the *MaintenanceSettings.xml* file, the `NatsCustodianResetNatsRequest` message will now be blocked. Instead of performing a NATS reset, it will now return an error with the following message:

`Resetting NATS is blocked while the system is running a Manual Config. See https://docs.dataminer.services/user-guide/Reference/DataMiner_Tools/SLNetClientTest_tool/SLNetClientTest_tool_advanced_procedures/SLNetClientTest_disabling_automatic_nats_config.html for more information.`

> [!NOTE]
> The `NatsCustodianResetNatsRequest` message will also be blocked when BrokerGateway is being used.

#### GQI DxM: Enhanced performance when executing multiple queries simultaneously [ID 42191]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

Because of a number of enhancements, overall performance has increased when executing multiple queries simultaneously.

#### Connection enhancements [ID 42233]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of enhancements have been made with regard to the connections made among DataMiner Agents as well as the connections made between DataMiner Agents and client applications.

#### GQI DxM: Logging can now be viewed in DataMiner Cube [ID 42352]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

From now on, you can view the logging of the GQI DxM in DataMiner Cube.

Also, a new log file will now be started as soon as the size of the existing file reaches 5 MB. Up to now, a new log file would be started every day.

> [!NOTE]
> Currently, DataMiner Cube only allows you to view the logging of the parent process. It does not yet allow you to view the logging of the child processes (i.e. the logging of the ad hoc data sources and the operators).

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

#### Problems with SNMP managers [ID 42014]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

In the following cases, an SNMP manager configured to send SNMPv3 Inform messages would get stuck in a timeout:

- When multiple SNMP managers were sending information to the same IP address and port.
- When "time window" errors were thrown after the SNMP manager (configured with *authnopriv* or *authpriv*) had been restarted.

Also, "out of time window" errors could be thrown when an SNMP manager received SNMPv3 traps. From now on, in SNMPv3 mode, the first alarm sent by DataMiner to the SNMP manager will always be a PING alarm. This will allow an SNMP manager to clean up time table information, which will prevent "out of time window" errors from being thrown when receiving subsequent alarms.

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

#### SLAnalytics - Behavioral anomaly detection: Problem when trying to retrieve incorrect INF values from the database [ID 42069]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, INF (infinity) values would incorrectly get stored in the database. Attempts to retrieve those values would then result in the *Behavioral anomaly detection* feature not starting up.

#### DataMiner Taskbar Utility would incorrectly show a pop-up window when made to perform a DataMiner upgrade using the command prompt [ID 42135]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When you made SLTaskbarUtility perform a DataMiner upgrade using the command prompt, up to now, a pop-up window would appear when the DataMiner Agent was not running. As pop-up windows are only expected to appear when running in interactive mode, from now on, pop-up windows will no longer appear when you make SLTaskbarUtility perform actions using the command prompt.

#### Not possible to simultaneously update multiple TTL settings [ID 42139]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

In some cases, it would not be possible to simultaneously update multiple TTL settings.

#### MessageBroker: Subscriptions that had been disposed of would incorrectly get recreated [ID 42164]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

After a MessageBroker client had disposed of a subscription and had reconnected to NATS, in some cases, the subscription would incorrectly get recreated.

#### GQI DxM: Problem when executing a query using ad hoc data sources with real-time updates enabled [ID 42310]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When a query using ad hoc data sources was executed with real-time updates enabled, up to now, the following message could incorrectly appear:

```txt
Operations that change non-concurrent collections must have exclusive access. A concurrent update was performed on this collection and corrupted its state. The collection's state is no longer correct.
```

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
