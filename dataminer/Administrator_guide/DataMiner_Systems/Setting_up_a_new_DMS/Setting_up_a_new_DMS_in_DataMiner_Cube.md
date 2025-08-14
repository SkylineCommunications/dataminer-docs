---
uid: Setting_up_a_new_DMS_in_DataMiner_Cube
---

# Setting up a new DMS in DataMiner Cube

> [!IMPORTANT]
> The procedure below does not apply to [DataMiner as a Service (DaaS)](xref:Creating_a_DMS_in_the_cloud). DMS setup and configuration are handled automatically by Skyline. From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43110-->, the *Agent cluster* section on the *Agents* page in System Center is no longer available when you are using a DaaS System. Additionally, if there are any DaaS systems in the cluster to which you are connected, the *Add* and *Remove* buttons are disabled.

1. Add the master DMA to the DMS.

   1. Open DataMiner Cube on the primary DMA.

   1. Go to *Apps* > *System Center* > *Agents.*

   1. In the *Manage* tab, select the DataMiner Agent to which you are connected (it is marked by an icon with a small "1").

   1. In the pane on the right, next to *Cluster*, enter the name of the DMS, and then click *Join cluster*.

      > [!IMPORTANT]
      > Avoid starting the name of your DMS with a special character whose Base64 encoding begins with a number to prevent issues with NATS. For more details, see [NATS not starting if DMS name contains special characters](xref:KI_NATS_not_starting_special_chars). You can verify if a special character begins with a number in Base64 format by using an [online encoder](https://www.base64encode.org/). For example, "♣" translates to "4pmj".

1. For each DMA you want to add to the DMS, do the following:

   1. Open DataMiner Cube on the primary DMA, and navigate to the *Agents* > *Manage* tab as before.

   1. In the lower left corner, click *Add*.

   1. Enter the IP of the DMA you want to add and click *Add*.

Now all DataMiner Agents that have been added to the DMS will start the initial data synchronization. Each DMA will sync with the first other DMA it comes across in DMS.xml.

When the DMS has been synchronized, you will be able to consult information about each of the Agents in the *Status* tab of the *Agents* page in *System Center*.

> [!NOTE]
>
> - Only use the *Join cluster* button when you set up the master DMA. When you add other DMAs, the cluster name will be set automatically.
> - It is also possible to migrate elements from one DMA to another within a DMS. For more information, see [Migrating elements in a DataMiner System](xref:Migrating_elements_in_a_DataMiner_System).
