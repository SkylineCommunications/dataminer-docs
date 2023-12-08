---
uid: Removing_a_DataMiner_Agent_from_a_DataMiner_System
---

# Removing a DataMiner Agent from a DataMiner System

Depending on whether the DataMiner Agent is part of a Failover pair or not, a different procedure must be used:

## Removing a DMA that is not part of a Failover pair

1. On a DMA in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the list of DMAs in the *Manage* section, select the DMA you want to remove.

1. Click the *Remove* button.

1. In the confirmation box, click *Yes*.

1. On the DMA you have removed, go to the *System Center* module and select the *Agents* tab.

1. In the *Manage* section, select the DMA in the list.

1. In the pane on the right, click *Delete cluster* (prior to DataMiner 10.0.13) or *Leave cluster* (from DataMiner 10.0.13 onwards).

1. If you want to keep using the removed DMA as a standalone Agent, restart the DMA.

## Removing a Failover DMA

1. On a DMA in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the list of DMAs in the *Manage* section, select the DMA you want to remove.

1. Click the *Remove* button.

1. In the confirmation box, click *Yes*.

1. Stop both Agents of the Failover pair.

1. Open the [DMS.xml](xref:DMS_xml) file on both DMAs.

1. Remove all `<DMA />` and `<Redirect />` tags in *DMS.xml* that contain IP addresses from the previous cluster, and save the file.

1. If you want to keep using the removed DMA as a standalone Agent, restart the DMA.
