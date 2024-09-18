---
uid: Adding_a_regular_DataMiner_Agent
---

# Adding a regular DataMiner Agent

> [!TIP]
> See also:
> [Agents – Adding a DMA to a cluster](https://community.dataminer.services/video/agents-adding-a-dma-to-a-cluster/) ![Video](~/user-guide/images/video_Duo.png)

> [!IMPORTANT]
>
> - Before you add a DataMiner Agent, make sure the IP network ports are configured correctly. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).
> - If the DataMiner System uses [Dedicated clustered storage](xref:Dedicated_clustered_storage), make sure the new DMA is configured to use the same clustered storage as the DMS you are about to add it to (by modifying the general database settings in its [DB.xml](xref:DB_xml) file to match those of the other DMAs and then restarting the DMA).
> - If the DataMiner System uses STaaS, additional steps are required. See [Adding a DataMiner Agent to a DMS running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS).

1. On a DMA that is currently already in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the *Manage* tab, below the list of DMAs in the cluster, click *Add*.

1. Enter the IP address of the DMA you want to add and click *Add*.

> [!NOTE]
>
> - You should not set the cluster name for each DMA. This will be done automatically upon adding the DMA to the DMS.
> - To add a Failover pair to a DataMiner System, first add the primary DMA as a regular DataMiner Agent, and then configure Failover. See [Preparing the two DataMiner Agents](xref:Preparing_the_two_DataMiner_Agents).

> [!TIP]
> To verify if your DataMiner cluster is working correctly, you can run the [Check Cluster SLNet Connections BPA test](xref:BPA_Check_Cluster_SLNet_Connections).
