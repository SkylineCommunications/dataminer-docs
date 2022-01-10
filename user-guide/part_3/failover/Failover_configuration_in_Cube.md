## Failover configuration in Cube

> [!TIP]
> See also:
> <https://community.dataminer.services/video/agents-configuring-dma-failover/>

To enable Failover using DataMiner version **10.1.8 or higher**:

1. Make sure both DMAs are prepared and you have the necessary prerequisites. See [Preparing the two DataMiner Agents](Preparing_the_two_DataMiner_Agents.md).

2. If you intend to configure Failover with a **shared hostname** instead of virtual IP addresses, make sure the IIS extension “Application Request Routing” is installed on both DMAs. See
<https://www.iis.net/downloads/microsoft/application-request-routing>.

3. On the primary DMA, open DataMiner Cube.

4. Go to *Apps* > *System Center* > *Agents.*

5. On the *Manage* tab, select the primary DMA in the list of DataMiner Agents.

6. Click the *Failover* button in the lower right corner.

7. Select the type of Failover you want to configure: *Failover (Virtual IP)* or *Failover (Hostname)*.

8. If you selected *Failover (Virtual IP)*:

    1. On the left, specify the virtual IP addresses that are to be used to access the Failover Agent.

    2. In the box indicating the primary DMA, click the *x.x.x.x* placeholders, and specify the current IP addresses of the corporate and the acquisition network interfaces of the primary DMA.

    3. In the box indicating the backup DMA, click the *x.x.x.x* placeholder, and specify the current IP addresses of the corporate and the acquisition network interfaces of the backup DMA.

    4. If necessary, click *Advanced*, and specify a number of advanced settings. See [Advanced Failover options](Advanced_Failover_options.md).

    5. Click *OK* to save the configuration.

        Once you have completed the configuration, the IP addresses will be changed. Because of this, it could take a while before you can reconnect to the system.

9. If you selected *Failover (Hostname)*:

    1. On the left, specify the shared hostname that is to be used to access the Failover Agent.

    2. In the box indicating the primary DMA, specify the hostname of the primary DMA.

    3. In the box indicating the backup DMA, specify the hostname of the backup DMA.

    4. If necessary, click *Advanced*, and specify a number of advanced settings. See [Advanced Failover options](Advanced_Failover_options.md).

    5. Click *OK* to save the configuration.

To enable Failover using DataMiner version **10.1.7 or lower**:

1. Make sure both DMAs are prepared and you have a pair of IP addresses available that are not currently used. See [Preparing the two DataMiner Agents](Preparing_the_two_DataMiner_Agents.md).

2. On the primary DMA, open DataMiner Cube.

3. Go to *Apps* > *System Center* > *Agents.*

4. On the *Manage* tab, select the primary DMA in the list of DataMiner Agents.

5. Click the *Failover* button in the lower right corner.

6. In the *Failover* window, select the *Failover* checkbox.

7. On the left, specify the virtual IP addresses that are to be used to access the Failover Agent.

8. In the box indicating the primary DMA, click the *x.x.x.x* placeholders, and specify the current IP addresses of the corporate and the acquisition network interfaces of the primary DMA.

9. In the box indicating the backup DMA, click the *x.x.x.x* placeholder, and specify the current IP addresses of the corporate and the acquisition network interfaces of the backup DMA.

10. If necessary, click *Advanced*, and specify a number of advanced settings. See [Advanced Failover options](Advanced_Failover_options.md).

11. Click *OK* to save the configuration.

    Once you have completed the configuration, the IP addresses will be changed. Because of this, it could take a while before you can reconnect to the system.

> [!NOTE]
> - Both DMAs store the full Failover configuration in their *DMS.xml* file. Each time the Failover configuration is changed, a copy of the old *DMS.xml* file will be moved to the folder *C:\\Skyline DataMiner\\Recycle Bin*.
> - If the configuration is changed on only one of the DMAs because the other was unreachable, the newest configuration will be synchronized as soon as the DMAs can make contact again.
> - To avoid possible issues in case a NIC is unplugged, you can specify the order of the network adapters used by a DMA (the first being used for the corporate network, the second for the acquisition network). To do so, configure the *NetworkAdapters* tag in the file *DataMiner.xml* (see [Alphabetical overview of settings](../../part_7/SkylineDataminerFolder/DataMiner_xml.md#alphabetical-overview-of-settings)). However, note that to do so, you will need to stop both Failover Agents and then restart them once the file has been modified. If you do this for an existing Failover setup, you will also need to make sure that the changes you make match the IP configuration in DMS.xml.
> - For Failover logging information, refer to the files *SLNet.txt* and *SLFailover.txt*.
>
