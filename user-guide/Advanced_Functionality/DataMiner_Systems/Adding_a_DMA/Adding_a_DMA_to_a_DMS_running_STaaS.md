---
uid: Adding_a_DMA_to_a_DMS_running_STaaS
---

# Adding a DataMiner Agent to a DMS running STaaS

To add a DataMiner Agent to a DMS running STaaS:

1. Make sure that the DMA you are adding is a clean DMA, meaning that it is a newly installed DMA or a DMA that has been [fully reset](xref:Factory_reset_tool).

1. Install the [DataMiner Cloud Pack](xref:CloudPackages) on the new DataMiner agent.

1. Stop the DMA and CloudGateway on the server that will be added.

1. From a DMA of the cluster where a CloudGateway is running. Copy the `C:\ProgramData\Skyline Communications\DataMiner CloudGateway\Data\CcaGatewayPersisted` folder and place it in the same location on the new DMA.

1. Remove the following files from the folder you just copied to the new agent:
   - DmsAccessToken.data
   - DmsAccessTokenExpiration.data
   - DmsRefreshToken.data
   - DmsRefreshTokenExpiration.data

1. Start CloudGateway on the new agent.

1. Configure *DB.xml* to use STaaS:

   1. In the `C:\Skyline DataMiner` folder, open *DB.xml*.

   1. Configure the *Database* tag with *type="CloudStorage"* as illustrated below:

      ```xml
      <?xml version="1.0"?>
      <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
         <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
      </DataBases>
      ```

1. Start the DataMiner on the new agent.

1. Join the DMA to the cluster using the steps described under [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent) or [Failover configuration in Cube](xref:Failover_configuration_in_Cube) for a Failover Agent.

The DMA should now be connected to the DMS running STaaS.
