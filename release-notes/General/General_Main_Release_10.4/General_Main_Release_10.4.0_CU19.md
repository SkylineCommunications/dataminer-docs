---
uid: General_Main_Release_10.4.0_CU19
---

# General Main Release 10.4.0 CU19

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU19](xref:Cube_Main_Release_10.4.0_CU19).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU19](xref:Web_apps_Main_Release_10.4.0_CU19).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLNet-managed NATS solution: Credentials of the local agent will now be compared against the credentials of the primary NAS node [ID 43514]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In the *ResetNATSCheck* timer of the SLNet-managed NATS solution, the credentials of the local agent will now be compared against the credentials of the primary NAS node. If these do not match, the NATS configuration of the local agent will be reset, and the correct credentials of the primary node will be used instead.

#### DataMiner Object Models: Lazy-loading of dropdown fields [ID 43524]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, when a DOM form visualized a DOM instance that included one or more dropdown fields, all those fields would be populated immediately. On DOM forms with multiple sections, in some cases, this behavior could trigger a large number of requests, some of which for fields the user would never interact with.

In order to minimize the impact of these population requests, from now on, dropdown fields will only be populated when you navigate to them.

#### New BPA test: Cube CRL Freeze [ID 43539]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

From now on, a new BPA test *Cube CRL Freeze* will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

The test, which will run once a day, will return one of the following messages:

| Message | Description |
|---------|-------------|
| No CRL Freezes are detected. | No problems were found. |
| CRL Freezes are detected. | The test has detected one or more client machines and DataMiner Agents that are affected by the startup freeze.<br>The detailed result section will list the specific client machines that are affected. The full list of affected client machines will be included in the `DetailedJsonResult` as `the following client machines are affected.` |
| CRL Freezes are detected on DataMiner Agents only. | The test has detected one or more DataMiner Agents that are affected by the startup freeze.<br>The detailed result section will list the specific DataMiner Agents that are affected. The full list of affected DataMiner Agents will be included in the `DetailedJsonResult` as `the following DataMiner Agents are affected.` |
| Could not execute test ([message]). | The test has failed to execute for unexpected reasons.<br>The test result details will contain the full exception text, if available. |

##### When issues are detected

When an internet connection is not available on the client machine, the DataMiner Cube application freezes for about 20 seconds during the session. This happens because Windows and .NET try to verify the application's digital signatures by checking an online Certificate Revocation List (CRL). The system times out during this process, causing the delay and impacting user productivity.

To prevent these freezes, please consult your IT administrator. For detailed solutions and workarounds, see [DataMiner Cube freeze on startup](xref:KI_DataMiner_Cube_freeze_on_startup).

### Fixes

#### SLDataMiner issue after connection type of element changed [ID 43249]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a problem could occur in SLDataMiner when the connection type of an element changed. To prevent this, the validation of SNMPv3 usernames has now been improved.

#### SLDataGateway: Problem when NULL values were written to indexed logger tables [ID 43456]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, a `NullReference` exception would be thrown in SLDataGateway when NULL values were written to indexed logger tables.

#### Failed upgrade action because of duplicate keys for SNMPv3 elements [ID 43477]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, it could occur that the SyncInfo file contained duplicate keys for SNMPv3 elements, which would cause upgrade actions to fail with the following error message: `UpgradeAction failed:System.ArgumentException: An item with the same key has already been added.`

#### SLNet-managed NATS solution: Problem when multiple calls accessed the NATS credentials simultaneously [ID 43504]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, when multiple NATSCustodian calls tried to retrieve the NATS credentials simultaneously, in some cases, those credentials could get corrupted.

#### Local IP port configured for a UDP connection would incorrectly be disregarded [ID 43531]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When an element had a UDP connection that had been configured to use a local IP port, up to now, a random port would incorrectly be used instead of the port that had been configured.

#### Problem with gRPC connections [ID 43542]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a deadlock could occur in the `Grpc.Net.Client` library, causing active gRPC connections to get stuck.

#### DataMiner Connectivity Framework: ConnectivityChangedEvent would incorrectly be sent every second [ID 43547]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When an element with DCF connections had correlation rules configured, up to now, a `ConnectivityChangedEvent` would be sent every second, even when nothing had changed.

#### SLNet would interpret the messages incorrectly when matrix crosspoints were loaded or saved over a gRPC connection in DataMiner Cube [ID 43551]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When, in DataMiner Cube, matrix crosspoints were loaded or saved over a gRPC connection, in some cases, SLNet would interpret the messages incorrectly.

#### Problem when processing deserialization exceptions thrown as a result of messages received via gRPC [ID 43758]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 [CU0] -->

When a client application (e.g., DataMiner Cube) sends unsupported messages to a DataMiner Agent, deserialization exceptions are thrown in SLNet.

Up to now, those exceptions would not get processed correctly when the unsupported messages were sent over a gRPC connection, causing the client application to get stuck while waiting for a response that would never arrive.

#### Problem with SLDataGateway after it had removed a storage type in Elasticsearch or OpenSearch [ID 43761]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 [CU0] -->

In some cases, a fatal error could occur in SLDataGateway after it had removed a storage type in an Elasticsearch or OpenSearch database.

Also, in some cases, a fatal error could occur in SLDataGateway when it was shut down.
