---
uid: Preparing_to_upgrade_a_DataMiner_Agent
---

# Preparing to upgrade a DataMiner Agent

## Prerequisites

> [!IMPORTANT]
> We highly recommend that you upload the DataMiner upgrade packages well in advance of the actual upgrade. For more information, see [Uploading upgrade packages before the upgrade](#uploading-upgrade-packages-before-the-upgrade).
> Furthermore, please follow the [best practices](#best-practices).

- [VerifyClusterPorts.dmupgrade](xref:VerifyClusterPortsdmupgrade)

- [Verify NATS is Running](xref:VerifyNatsIsRunning)

- [Verify Cloud DxM Version](xref:BPA_Verify_Cloud_DxM_Version)

- [Service Automatic Properties]()

## Best practices

### Uploading upgrade packages before the upgrade

Please upload the package before the actual maintenance. Uploading a DataMiner package before the maintenance is low risk as it does not restart your system, however, it will already indicate whether the prerequisites for upgrading your DMS are met.
Uploading the packages in advance prevents surprises during the upgrade maintenance itself.

> [!TIP]
> Upload the package at least a week before the upgrade.

### Having a backup at the ready

We recommend taking a VM snapshot of the upgraded machines.
This will allow a speedy rollback of the DataMiner system.
Alternatively, a DataMiner backup as found in [Backing up a DataMiner Agent](xref:Backing_up_a_DataMiner_Agent) should also be sufficient.

> [!TIP]
> Taking a VM snapshot can take a while.
> Ensure that the snapshot is taken when the maintenance window for the upgrade starts.
