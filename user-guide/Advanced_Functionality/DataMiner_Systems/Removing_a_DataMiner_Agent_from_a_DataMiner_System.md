---
uid: Removing_a_DataMiner_Agent_from_a_DataMiner_System
---

# Removing a DataMiner Agent from a DataMiner System

Depending on whether the DataMiner Agent is part of a Failover pair or not, a different procedure must be used.

> [!NOTE]
> If a [manual configuration was forced for NATS](xref:SLNetClientTest_disabling_automatic_nats_config) with the *NATSForceManualConfig* option in *MaintenanceSettings.xml*, you will need to manually adjust your NATS configuration with the removed DMA.

## Removing a DMA that is not part of a Failover pair

1. On a DMA in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the list of DMAs in the *Manage* section, select the DMA you want to remove.

1. Click the *Remove* button.

1. In the confirmation box, click *Yes*.

1. Stop the Agent you have removed and decommission it.

1. In case your system is cloud connected, go to [Admin.Dataminer.Services](https://admin.dataminer.services/) and navigate further to the DxMs page. Here you see an overview of all the agents with an option to remove a node from the Cloud system. Click the remove button next to the agent you have just removed and confirm.

1. Restart your Cube to have a correct overview on all places.


## Removing a Failover DMA

1. On a DMA in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the list of DMAs in the *Manage* section, select the DMA you want to remove.

1. Click the *Remove* button.

1. In the confirmation box, click *Yes*.

1. Stop both Agents of the Failover pair.

1. Open the [DMS.xml](xref:DMS_xml) file on both DMAs.

1. Remove all `<DMA />` and `<Redirect />` tags in *DMS.xml* that contain IP addresses from the previous cluster, and save the file.

1. Start the DMA you want to keep and decommission the removed DMA.

1. In case your system is cloud connected, go to [Admin.Dataminer.Services](https://admin.dataminer.services/) and navigate further to the DxMs page. Here you see an overview of all the agents with an option to remove a node from the Cloud system. Click the remove button next to the agent you have just removed and confirm.

1. Restart your Cube to have a correct overview on all places.
   
