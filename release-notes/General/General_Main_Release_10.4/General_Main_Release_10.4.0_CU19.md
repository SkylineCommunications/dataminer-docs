---
uid: General_Main_Release_10.4.0_CU19
---

# General Main Release 10.4.0 CU19 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU19](xref:Cube_Main_Release_10.4.0_CU19).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU19](xref:Web_apps_Main_Release_10.4.0_CU19).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added yet.*

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

#### Problem with gRPC connections [ID 43542]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a deadlock could occur in the `Grpc.Net.Client` library, causing active gRPC connections to get stuck.

#### DataMiner Connectivity Framework: ConnectivityChangedEvent would incorrectly be sent every second [ID 43547]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When an element with DCF connections had correlation rules configured, up to now, a `ConnectivityChangedEvent` would be sent every second, even when nothing had changed.

#### SLNet would interpret the messages incorrectly when matrix crosspoints were loaded or saved over a gRPC connection in DataMiner Cube [ID 43551]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When, in DataMiner Cube, matrix crosspoints were loaded or saved over a gRPC connection, in some cases, SLNet would interpret the messages incorrectly.
