---
uid: Adding_a_regular_DataMiner_Agent
---

# Adding a regular DataMiner Agent

## Prerequisites

- Before you add a DataMiner Agent, make sure the [IP network ports](xref:Configuring_the_IP_network_ports) are configured correctly and [connection strings](xref:Connection_strings) are configured if necessary.

- If you are running a DataMiner version lower than 10.4.0 [CU16]/10.5.0 [CU4]/10.4.7, also make sure the machine where you are running Cube can access the new Agent over the IP that is used for adding it, even when connection strings are used.

- If the DataMiner System uses [Dedicated clustered storage](xref:Dedicated_clustered_storage), make sure the new DMA is configured to use the same clustered storage as the DMS you are about to add it to (by modifying the general database settings in its [DB.xml](xref:DB_xml) file to match those of the other DMAs and then restarting the DMA).

- If the DataMiner System uses [Swarming](xref:Swarming), make sure Swarming is enabled on the new DMA before you add it to the cluster.

- If the DataMiner System uses STaaS, additional steps are required. See [Adding a DataMiner Agent to a DMS running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS).

## Procedure

1. On a DMA that is currently already in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the *Manage* tab, below the list of DMAs in the cluster, click *Add*.

1. Enter the IP address of the DMA you want to add and click *Add*.

> [!NOTE]
>
> - Do not use the *Join cluster* button to add a DMA to an existing DMS. This button should only be used during the [initial setup of a DMS](xref:Setting_up_a_new_DMS_in_DataMiner_Cube).
> - To add a Failover pair to a DataMiner System, first add the primary DMA as a regular DataMiner Agent, and then configure Failover. See [Preparing the two DataMiner Agents](xref:Preparing_the_two_DataMiner_Agents).

> [!TIP]
> To verify if your DataMiner cluster is working correctly, you can run the [*SLNet connections between the DataMiner Agents* BPA test](xref:BPA_Check_Cluster_SLNet_Connections).
