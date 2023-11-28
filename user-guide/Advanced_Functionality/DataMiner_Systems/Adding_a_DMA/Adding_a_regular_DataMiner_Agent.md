---
uid: Adding_a_regular_DataMiner_Agent
---

# Adding a regular DataMiner Agent

> [!TIP]
> See also:
> [Agents – Adding a DMA to a cluster](https://community.dataminer.services/video/agents-adding-a-dma-to-a-cluster/) ![Video](~/user-guide/images/video_Duo.png)

> [!IMPORTANT]
> Before you add a DataMiner Agent, make sure the IP network ports are configured correctly. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

1. On the DMA you intend to add to the cluster, go to the *System Center* module and select the *Agents* page.

1. On the *Manage* tab, select the DataMiner Agent to which you are connected.

1. In the pane on the right, next to *Cluster*, enter the name of the DMS, and then click *Add Cluster* (prior to DataMiner 10.0.13) or *Join cluster* (from DataMiner 10.0.13 onwards).

1. On a DMA that is currently already in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the *Manage* tab, below the list of DMAs in the cluster, click *Add*.

1. Enter the IP address or the hostname of the DMA you want to add and click *Add*.

   > [!NOTE]
   > To avoid a mix of different environments, enter the IP address instead of the hostname if the DataMiner System already contains a Failover pair configured with virtual IP addresses. From DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards, adding a hostname in such a case will be impossible.<!--RN 37075-->

> [!NOTE]
> To add a Failover pair to a DataMiner System, first add the primary DMA as a regular DataMiner Agent, and then configure Failover. See [Preparing the two DataMiner Agents](xref:Preparing_the_two_DataMiner_Agents).

> [!TIP]
> To verify if your DataMiner cluster is working correctly, you can run the [Check Cluster SLNet Connections BPA test](xref:BPA_Check_Cluster_SLNet_Connections).
