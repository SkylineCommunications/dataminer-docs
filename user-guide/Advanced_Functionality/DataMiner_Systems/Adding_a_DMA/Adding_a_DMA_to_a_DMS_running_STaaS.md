---
uid: Adding_a_DMA_to_a_DMS_running_STaaS
---

# Adding a DataMiner Agent to a DMS running STaaS

Adding a DataMiner agent to a DMS running STaaS is possible by following the steps described below.

> [!NOTE]
> Following prerequisites have to be met:
>
> - The agent that will be added should be a clean agent.
> - If CloudGateway is installed on that agent, the persisted data folder `C:\ProgramData\Skyline Communications\DataMiner CloudGateway\Data` should be empty.
> - Stop the DataMiner agent that will be added.
> - Stop CloudGateway if it is installed.

1. Go to an existing agent in the cluster
    1. Copy the `C:\Skyline DataMiner\NATS\nsc` folder and place it in the same location on the new agent.
    1. Copy the `C:\Skyline DataMiner\SLCloud.xml` file to the same location on the new agent.
1. Configure the new agent
    1. Open `C:\Skyline DataMiner\SLCloud.xml` and modify the `<ClientID>` to match the name of the server.
    1. Open `C:\Skyline DataMiner\MaintenanceSettings.xml` and add the following tag under the `<SLNet>` section:

       ```xml
       <NATSForceManualConfig>true</NATSForceManualConfig>
       ```

    1. Configure *DB.xml* with STaaS:
       1. In the `C:\Skyline DataMiner` folder, open *DB.xml*.
       1. Configure the *Database* tag with *type="CloudStorage"* as shown:

          ```xml
          <?xml version="1.0"?>
          <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
             <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
          </DataBases>
          ```

1. Start the new agent
1. Join the DMA to the cluster using the steps described under [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent) or [Failover configuration in Cube](xref:Failover_configuration_in_Cube) for a failover agent.
1. Open `C:\Skyline DataMiner\MaintenanceSettings.xml` on the newly added agent and remove the `<NATSForceManualConfig>` tag.
1. Restart the newly added agent.
1. Start CloudGateway if it is installed.

The DMA should now be connected to the DMS running STaaS.
