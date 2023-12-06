---
uid: Removing_a_DataMiner_Agent_from_a_DataMiner_System
---

# Removing a DataMiner Agent from a DataMiner System

To remove a DataMiner Agent from a DataMiner System:

1. On a DMA in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the list of DMAs in the *Manage* section, select the DMA you want to remove.

1. Click the *Remove* button.

1. In the confirmation box, click *Yes*.

1. On the DMA you have removed, go to the *System Center* module and select the *Agents* tab.

1. In the *Manage* section, select the DMA in the list.

1. In the pane on the right, click *Delete cluster* (prior to DataMiner 10.0.13) or *Leave cluster* (from DataMiner 10.0.13 onwards).

1. Reset the DMA you have removed using the [factory reset tool](xref:Factory_reset_tool).

   > [!NOTE]
   > This step is important to make sure the DMA does not use the same database and keyspace as the DMS you have removed it from, because this could cause a lot of issues.

1. Restart the DMA you have removed.
