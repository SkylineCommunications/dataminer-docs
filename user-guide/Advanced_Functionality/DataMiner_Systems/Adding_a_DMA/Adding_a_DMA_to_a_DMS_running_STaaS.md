---
uid: Adding_a_DMA_to_a_DMS_running_STaaS
---

# Adding a DataMiner Agent to a DMS running STaaS

Adding a DataMiner agent to a DMS running STaaS is possible by copying the cloud persisted data described by the procedure below.

> [!IMPORTANT]
> Make sure you have at least DataMiner CloudGateway 2.8.0 installed on the system and that the system has internet access. The latest available Cloud Pack which includes CloudGateway can be found on [DataMiner Dojo](https://community.dataminer.services/dataminer-cloud-pack/).

1. Stop the DataMiner Agent you want to add.
1. Configure *DB.xml* with STaaS:
   1. In the `C:\Skyline DataMiner` folder of the DMA, open the file *DB.xml*.
   1. Configure the *Database* tag with *type="CloudStorage"* as follows:

      ```xml
      <?xml version="1.0"?>
      <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
         <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
      </DataBases>
      ```

1. Copy the persisted data folder `C:\ProgramData\Skyline Communications\DataMiner CloudGateway\Data` of an agent that is already in the cluster that has an active CloudGateway.
1. Restart the CloudGateway of the DMA you want to add.
1. Start the DMA.
1. Join the DMA to the cluster using the steps described under [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent) or [Failover configuration in Cube](xref:Failover_configuration_in_Cube) for a Failover Agent.

The DMA should now be connected to the DMS running STaaS.
