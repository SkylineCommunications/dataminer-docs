---
uid: Failover_configuration_in_Cube
---

# Failover configuration in Cube

> [!TIP]
> See also: [Agents – Configuring DMA Failover](https://community.dataminer.services/video/agents-configuring-dma-failover/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## [From DataMiner 10.1.8 onwards](#tab/tabid-1)

To enable Failover using DataMiner version **10.1.8 or higher**:

1. Make sure both DMAs are prepared, and you have the necessary prerequisites. See [Preparing the two DataMiner Agents](xref:Preparing_the_two_DataMiner_Agents).

1. If you intend to configure Failover with a **shared hostname** instead of virtual IP addresses, make sure the IIS extension “Application Request Routing” is installed on both DMAs. See [Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing) (external link).

1. On the primary DMA, open DataMiner Cube.

1. Go to *Apps* > *System Center* > *Agents.*

1. On the *Manage* tab, select the primary DMA in the list of DataMiner Agents.

1. Click the *Failover* button in the lower right corner.

1. Select the type of Failover you want to configure: *Failover (Virtual IP)* or *Failover (Hostname)*.

1. If you selected *Failover (Virtual IP)*:

   1. On the left, specify the virtual IP addresses that are to be used to access the Failover Agent.

   1. In the box indicating the primary DMA, click the *x.x.x.x* placeholders, and specify the current IP addresses of the corporate and the acquisition network interfaces of the primary DMA.

   1. In the box indicating the backup DMA, click the *x.x.x.x* placeholder, and specify the current IP addresses of the corporate and the acquisition network interfaces of the backup DMA.

   1. If necessary, click *Advanced*, and specify a number of advanced settings. See [Advanced Failover options](xref:Advanced_Failover_options).

   1. Click *Apply* or *OK* to save the configuration (depending on your DataMiner version).

      Once you have completed the configuration, the IP addresses will be changed. Because of this, it could take a while before you can reconnect to the system.

1. If you selected *Failover (Hostname)*:

   1. On the left, specify the shared hostname that is to be used to access the Failover Agent.

   1. In the box indicating the primary DMA, specify the IP address of the primary DMA. At this point, a hostname can only used for the shared hostname.

   1. In the box indicating the backup DMA, specify the IP address of the backup DMA. At this point, a hostname can only used for the shared hostname.

   1. If necessary, click *Advanced*, and specify a number of advanced settings. See [Advanced Failover options](xref:Advanced_Failover_options).

   1. Click *Apply* or *OK* to save the configuration (depending on your DataMiner version).

## [Earlier DataMiner versions](#tab/tabid-2)

To enable Failover using DataMiner version **10.1.7 or lower**:

1. Make sure both DMAs are prepared, and you have a pair of IP addresses available that are not currently used. See [Preparing the two DataMiner Agents](xref:Preparing_the_two_DataMiner_Agents).

1. On the primary DMA, open DataMiner Cube.

1. Go to *Apps* > *System Center* > *Agents.*

1. On the *Manage* tab, select the primary DMA in the list of DataMiner Agents.

1. Click the *Failover* button in the lower right corner.

1. In the *Failover* window, select the *Failover* checkbox.

1. On the left, specify the virtual IP addresses that are to be used to access the Failover Agent.

1. In the box indicating the primary DMA, click the *x.x.x.x* placeholders, and specify the current IP addresses of the corporate and the acquisition network interfaces of the primary DMA.

1. In the box indicating the backup DMA, click the *x.x.x.x* placeholder, and specify the current IP addresses of the corporate and the acquisition network interfaces of the backup DMA.

1. If necessary, click *Advanced*, and specify a number of advanced settings. See [Advanced Failover options](xref:Advanced_Failover_options).

1. Click *OK* to save the configuration.

   Once you have completed the configuration, the IP addresses will be changed. Because of this, it could take a while before you can reconnect to the system.

***

> [!NOTE]
>
> - Both DMAs store the full Failover configuration in their *DMS.xml* file. Each time the Failover configuration is changed, a copy of the old *DMS.xml* file will be moved to the folder *C:\\Skyline DataMiner\\Recycle Bin*.
> - If the configuration is changed on only one of the DMAs because the other was unreachable, the newest configuration will be synchronized as soon as the DMAs can make contact again.
> - To avoid possible issues in case a NIC is unplugged, you can specify the order of the network adapters used by a DMA (the first being used for the corporate network, the second for the acquisition network). To do so, configure the *NetworkAdapters* tag in the file *DataMiner.xml* (see [DataMiner.NetworkAdapters](xref:DataMiner_xml#dataminernetworkadapters)). However, note that to do so, you will need to stop both Failover Agents and then restart them once the file has been modified. If you do this for an existing Failover setup, you will also need to make sure that the changes you make match the IP configuration in DMS.xml.
> - For Failover logging information, refer to the files *SLNet.txt* and *SLFailover.txt*.
