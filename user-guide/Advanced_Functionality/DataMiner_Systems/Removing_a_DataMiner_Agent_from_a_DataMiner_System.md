---
uid: Removing_a_DataMiner_Agent_from_a_DataMiner_System
---

# Removing a DataMiner Agent from a DataMiner System

To remove a DataMiner Agent from a DataMiner System:

1. On a DMA in the cluster, go to the *System Center* module and select the *Agents* page.

2. In the list of DMAs in the *Manage* section, select the DMA you want to remove.

3. Click the *Remove* button.

4. In the confirmation box, click *Yes*.

### If the DMA was a single agent...

5. On the DMA you have removed, go to the *System Center* module and select the *Agents* tab.

6. In the *Manage* section, select the DMA in the list.

7. In the pane on the right, click *Delete cluster* (prior to DataMiner 10.0.13) or *Leave cluster* (from DataMiner 10.0.13 onwards).

8. Restart the DMA you have removed.

### If the DMA was a failover pair...

5. Stop both agents of the failover pair.

6. Manually edit their [DMS.xml](xref:DMS_xml) and remove all `<DMA />` and `<Redirect />` tags that contain IP addresses from the previous cluster.
