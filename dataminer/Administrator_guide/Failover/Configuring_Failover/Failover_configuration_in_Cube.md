---
uid: Failover_configuration_in_Cube
---

# Failover configuration in Cube

> [!NOTE]
> If you are using a [DaaS system](xref:Creating_a_DMS_in_the_cloud), your DMS is fully hosted and maintained by Skyline Communications. Therefore, a Failover configuration is, by default, not available for DaaS<!--RN 40013-->.

1. Make sure both DMAs are prepared and you have the necessary prerequisites. See [Preparing the two DataMiner Agents](xref:Preparing_the_two_DataMiner_Agents).

1. If you intend to configure Failover with a **shared hostname** instead of virtual IP addresses, make sure the IIS extension “Application Request Routing” is installed on both DMAs. See [Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing) (external link).

1. On the primary DMA, open DataMiner Cube.

1. Go to *Apps* > *System Center* > *Agents.*

1. On the *Manage* tab, select the primary DMA in the list of DataMiner Agents.

1. Click the *Failover* button in the lower-right corner.

1. Select the type of Failover you want to configure: *Failover (Virtual IP)* or *Failover (Hostname)*.

   > [!IMPORTANT]
   > In DataMiner Systems that already contain a Failover pair configured with a shared hostname or that contain a DataMiner Agent that was added by hostname, always select *Failover (Hostname)*. In DataMiner Systems that already contain a Failover pair configured with virtual IP addresses, always select *Failover (Virtual IP)*.

1. If you selected *Failover (Virtual IP)*:

   1. On the left, specify the virtual IP addresses that are to be used to access the Failover Agent.

   1. In the box indicating the primary DMA, click the *x.x.x.x* placeholders, and specify the current IP addresses of the corporate and the acquisition network interfaces of the primary DMA.

   1. In the box indicating the backup DMA, click the *x.x.x.x* placeholder, and specify the current IP addresses of the corporate and the acquisition network interfaces of the backup DMA.

   1. If necessary, click *Advanced*, and specify a number of advanced settings. See [Advanced Failover options](xref:Advanced_Failover_options).

   1. Click *Apply* or *OK* to save the configuration (depending on your DataMiner version).

      Once you have completed the configuration, the IP addresses will be changed, which may take a while.

   1. If you are using DataMiner 10.6.0/10.6.1 or higher, or if your system has been [migrated to BrokerGateway](xref:BrokerGateway_Migration), run NATSRepair to update your NATS credentials with the virtual IP.

   > [!NOTE]
   > - Each of the two DMAs should have two network cards, connected to two different networks. Make sure to respect the order of the connections in the *Network Connections* list.
   >   - The first connection in the list represents the corporate network, which is used for heartbeats and synchronization.
   >   - The second connection represents the acquisition network, which is mainly used for communication with data sources managed by DataMiner.
   > - To avoid possible issues in case an NIC is unplugged, you can specify the order of the network adapters used by a DMA (the first being used for the corporate network, the second for the acquisition network). To do so, configure the *NetworkAdapters* tag in the file *DataMiner.xml* (see [DataMiner.NetworkAdapters](xref:DataMiner.NetworkAdapters)). However, note that to do so, you will need to stop both Failover Agents and then restart them once the file has been modified. If you do this for an existing Failover setup, you will also need to make sure that the changes you make match the IP configuration in *DMS.xml*.

1. If you selected *Failover (Hostname)*:

   1. On the left, specify the shared hostname that is to be used to access the Failover Agent.

   1. In the box indicating the primary DMA, specify the IP address of the primary DMA. At this point, a hostname can only be used for the shared hostname.

   1. In the box indicating the backup DMA, specify the IP address of the backup DMA. At this point, a hostname can only be used for the shared hostname.

   1. If necessary, click *Advanced*, and specify a number of advanced settings. See [Advanced Failover options](xref:Advanced_Failover_options).

   1. Click *Apply* or *OK* to save the configuration (depending on your DataMiner version).

   1. If you are using DataMiner 10.6.0/10.6.1 or higher, or if your system has been [migrated to BrokerGateway](xref:BrokerGateway_Migration), run [NATSRepair](xref:BrokerGateway_Migration#natsrepairexe) to update your NATS credentials with the new hostname.

1. Configure the [heartbeats](xref:Advanced_Failover_options#heartbeats):

   1. Click the cogwheel button to open the advanced options.

   1. Make sure four heartbeats are configured, and click *OK*:

      | Heartbeat | Type               | From  | Towards                                     |
      |-----------|--------------------|-------|---------------------------------------------|
      | 1         | Normal heartbeat   | DMA 1 | DMA 2                                       |
      | 2         | Normal heartbeat   | DMA 2 | DMA 1                                       |
      | 3         | Inverted heartbeat | DMA 1 | e.g., a Domain Controller or a local switch |
      | 4         | Inverted heartbeat | DMA 2 | e.g., a Domain Controller or a local switch |

> [!NOTE]
>
> - Both DMAs store the full Failover configuration in their *DMS.xml* file. Each time the Failover configuration is changed, a copy of the old *DMS.xml* file will be moved to the folder `C:\Skyline DataMiner\Recycle Bin`.
> - If the configuration is changed on only one of the DMAs because the other was unreachable, the newest configuration will be synchronized as soon as the DMAs can make contact again.
> - For Failover logging information, refer to the files *SLNet.txt* and *SLFailover.txt*.
