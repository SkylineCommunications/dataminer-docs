---
uid: General_Main_Release_10.5.0_CU7
---

# General Main Release 10.5.0 CU7 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU7](xref:Cube_Main_Release_10.5.0_CU7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU7](xref:Web_apps_Main_Release_10.5.0_CU7).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

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

#### Swarming: Problem when redundancy groups contained DVE child elements acting as primary or backup elements [ID 43286] [ID 43492]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

When Swarming was enabled, in some rare cases, SLDMS and SLDataMiner could get into a deadlock when the system contained redundancy groups in which DVE child elements acted as primary or backup elements.

#### SLDataGateway: Problem when NULL values were written to indexed logger tables [ID 43456]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, a `NullReference` exception would be thrown in SLDataGateway when NULL values were written to indexed logger tables.

#### Failed upgrade action because of duplicate keys for SNMPv3 elements [ID 43477]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.9 -->

In some cases, it could occur that the SyncInfo file contained duplicate keys for SNMPv3 elements, which would cause upgrade actions to fail with the following error message: `UpgradeAction failed:System.ArgumentException: An item with the same key has already been added.`

#### SLNet-managed NATS solution: Problem when multiple calls accessed the NATS credentials simultaneously [ID 43504]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, when multiple NATSCustodian calls tried to retrieve the NATS credentials simultaneously, in some cases, those credentials could get corrupted.

#### Problem with gRPC connections [ID 43542]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a deadlock could occur in the `Grpc.Net.Client` library, causing active gRPC connections to get stuck.

#### DataMiner Connectivity Framework: ConnectivityChangedEvent would incorrectly be sent every second [ID 43547]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When an element with DCF connections had correlation rules configured, up to now, a `ConnectivityChangedEvent` would be sent every second, even when nothing had changed.

#### SLNet would interpret the messages incorrectly when matrix crosspoints were loaded or saved over a gRPC connection in DataMiner Cube [ID 43551]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When, in DataMiner Cube, matrix crosspoints were loaded or saved over a gRPC connection, in some cases, SLNet would interpret the messages incorrectly.
