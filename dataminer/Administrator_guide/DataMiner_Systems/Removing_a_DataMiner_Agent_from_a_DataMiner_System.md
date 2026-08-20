---
uid: Removing_a_DataMiner_Agent_from_a_DataMiner_System
description: "Learn how to remove a regular node from a DataMiner cluster and how to remove a node that is part of a Failover pair."
---

# Removing a node from a DataMiner cluster

Depending on whether the node is part of a Failover pair or not, a different procedure must be used.

> [!NOTE]
> If a [manual configuration was forced for NATS](xref:Disabling_automatic_NATS_config) with the *NATSForceManualConfig* option in *MaintenanceSettings.xml*, you will need to manually adjust your NATS configuration with the removed node.

## Removing a node that is not part of a Failover pair

1. On a node in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the list of nodes in the *Manage* section, select the node you want to remove.

1. Click the *Remove* button.

1. In the confirmation box, click *Yes*.

1. Stop the DataMiner Agent you have removed.

   This Agent should no longer be used, so you should decommission it.

1. If your system is connected to dataminer.services, remove the corresponding node on dataminer.services:

   1. Open the [Admin app](https://admin.dataminer.services/) and go to the DxMs page.

      This page shows an overview of all nodes, with the option to remove a node from the system.

   1. Click the garbage can icon next to the node you have just removed and confirm.

1. Restart DataMiner Cube to make sure the removed node is no longer displayed anywhere.

## Removing a Failover node

1. [End the Failover configuration](xref:Ending_a_Failover_configuration).

   > [!NOTE]
   > This first step is especially important if you are using Failover based on hostname. For Failover setups based on virtual IP, this step can be skipped.

1. On a node in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the list of nodes in the *Manage* section, select the node you want to remove.

1. Click the *Remove* button.

1. In the confirmation box, click *Yes*.

1. Stop both Agents of the Failover pair.

1. Open the [DMS.xml](xref:DMS_xml) file on both Agents.

1. Remove all `<DMA />` and `<Redirect />` tags in *DMS.xml* that contain IP addresses from the previous cluster, and save the file.

1. Restart the Agent you want to keep as a node in the cluster.

   The other Agent should no longer be used and should be decommissioned.

1. If your system is connected to dataminer.services, remove the corresponding node on dataminer.services:

   1. Open the [Admin app](https://admin.dataminer.services/) and go to the DxMs page.

      This page shows an overview of all nodes, with the option to remove a node from the system.

   1. Click the garbage can icon next to the node you have just removed and confirm.

1. Restart DataMiner Cube to make sure the removed node is no longer displayed anywhere.
