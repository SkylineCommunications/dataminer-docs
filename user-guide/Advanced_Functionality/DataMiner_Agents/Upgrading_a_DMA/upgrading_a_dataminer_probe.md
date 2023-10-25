---
uid: upgrading_a_dataminer_probe
---

# Upgrading a DataMiner Probe

Upgrading a DataMiner Probe differs from upgrading a regular DataMiner Agent.
A DMP is not part of the DMS, it functions as a standalone gateway or proxy between its devices and the DMS.
Because of this, when upgrading the cluster, DMPs are not included in the upgrade process.

Nonetheless, a DataMiner Probe should also use the same version as the version found on the entire cluster.

> [!TIP]
> See also: [DataMiner Probes](xref:DataMinerProbes).

## Procedure
The procedure is similar to a regular upgrade, except that you need to manually upgrade each DataMiner Probe separately.

1. Make sure the DMS is upgraded already before upgrading the DMP(s).
2. Upload the upgrade package to the DataMiner Probe server(s).
> [!NOTE]
> Be sure to create a backup as indicated in the regular upgrade [preparation](xref:Preparing_to_upgrade_a_DataMiner_Agent)

3. Upgrade the DataMiner Probe, by double-clicking the upgrade package or by using the Taskbar Utility method.
The upgrade should be installed on the localhost only, instead of the cluster.
> [!NOTE]
> More information on it can be found [here](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility)
