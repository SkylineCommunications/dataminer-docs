---
uid: upgrading_a_dataminer_probe
---

# Upgrading a DataMiner Probe (DMP)

When you run a regular DataMiner upgrade in a DataMiner System (DMS), [DataMiner Probes](xref:DataMinerProbes) will not be included in the upgrade process. This is because a DMP does not function as one of the DataMiner nodes in a DataMiner System, but instead as a standalone gateway or proxy between its devices and the DMS.

However, DMPs also have to be upgraded so that they use the **same version as the rest of the DataMiner System**.

Each DMP in a DMS must be upgraded manually, separately from the rest of the DMS:

1. Create a backup of the DMP.

   > [!TIP]
   > See [Backing up a DataMiner Agent](xref:Backing_up_a_DataMiner_Agent).

1. Make sure all DataMiner Agents in the DMS have been upgraded.

   > [!TIP]
   > See [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

1. Upload the upgrade package to each DMP server.

1. Upgrade each DMP.

   You can do so by double-clicking the upgrade package on the server or by [using the Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility), similar to when you upgrade a DataMiner Agent.

   > [!IMPORTANT]
   > Make sure you install the upgrade on the **localhost only**, instead of on the entire cluster.
