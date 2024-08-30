---
uid: Adding_a_DMA_to_a_DMS_running_STaaS
---

# Adding a DataMiner Agent to a DMS running STaaS

To add a DataMiner Agent to a DMS running STaaS:

1. Make sure that the DMA you are adding is a clean DMA.

   > [!IMPORTANT]
   > If the CloudGateway DxM is installed on the DMA you are adding, the data folder `C:\ProgramData\Skyline Communications\DataMiner CloudGateway\Data` must be empty.

1. Stop the DMA that will be added.

1. On the DMA that will be added, stop CloudGateway if it is installed.

1. Go to the `C:\Skyline DataMiner\` folder of an existing DMA in the cluster, and follow the steps below:

   1. Copy the `C:\Skyline DataMiner\NATS\nsc` folder and place it in the same location on the new DMA.

   1. Copy the `C:\Skyline DataMiner\SLCloud.xml` file to the same location on the new DMA.

1. Configure the new DMA:

   1. Open `C:\Skyline DataMiner\SLCloud.xml` and modify the `<ClientID>` to match the name of the server.

   1. Open `C:\Skyline DataMiner\MaintenanceSettings.xml` and add the following tag under the `<SLNet>` section:

      ```xml
      <NATSForceManualConfig>true</NATSForceManualConfig>
      ```

   1. Configure *DB.xml* with STaaS:

      1. In the `C:\Skyline DataMiner` folder, open *DB.xml*.

      1. Configure the *Database* tag with *type="CloudStorage"* as illustrated below:

         ```xml
         <?xml version="1.0"?>
         <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
            <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
         </DataBases>
         ```

1. Start the new DMA.

1. Join the DMA to the cluster using the steps described under [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent) or [Failover configuration in Cube](xref:Failover_configuration_in_Cube) for a Failover Agent.

1. Open `C:\Skyline DataMiner\MaintenanceSettings.xml` on the newly added DMA and remove the `<NATSForceManualConfig>` tag.

1. Restart the newly added DMA.

1. Start CloudGateway on the newly added DMA if it is installed.

The DMA should now be connected to the DMS running STaaS.
