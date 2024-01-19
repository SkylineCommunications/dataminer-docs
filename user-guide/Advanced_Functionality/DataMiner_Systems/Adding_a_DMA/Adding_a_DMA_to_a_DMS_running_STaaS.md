---
uid: Adding_a_DMA_to_a_DMS_running_STaaS
---

# Adding a DataMiner Agent to a DMS running STaaS

Follow these steps below to connect a DMA to an existing DMS running STaaS:

1. **Ensure the DMA is Online and Empty**: The DMA needs to be online and empty before you start the process.

1. **Disconnect from Cloud**: The DMA cannot be cloud-connected during this process. Ensure that it is disconnected from any cloud services by following this procedure: [Permanently disconnecting from dataminer.services](https://docs.dataminer.services/user-guide/Cloud_Platform/AboutCloudPlatform/Disconnecting_from_dataminer.services.html#permanently-disconnecting-from-dataminerservices)

1. **Start the Agent without the STaaS Flag**: Start the DMA, but make sure the active flag is set to **false** in the *DB.xml* file. It should look like this:

   ```xml
   <?xml version="1.0"?>
   <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
      <DataBase active="false" local="true" search="true" cloud="true" type="CloudStorage"/>
   </DataBases>
   ```

1. **Join the Cluster**: Once the agent is running, have the DMA join the desired cluster. You can do so by following the steps described here: [Adding a regular DataMiner Agent](https://docs.dataminer.services/user-guide/Advanced_Functionality/DataMiner_Systems/Adding_a_DMA/Adding_a_regular_DataMiner_Agent.html).

1. **Enable the STaaS Flag**: After the DMA has successfully joined the cluster, go back into the DMA's *DB.xml* file and enable the active flag. It should look like this:

   ```xml
   <?xml version="1.0"?>
   <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
      <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
   </DataBases>
   ```

1. **Restart the DMA**: Finally, restart the DMA for the changes to take effect. The DMA should now be connected to the DMS running STaaS.
