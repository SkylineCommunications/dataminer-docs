---
uid: Adding_a_DMA_to_a_DMS_running_STaaS
---

# Adding a DataMiner Agent to a DMS running STaaS

Follow these steps below to connect a DMA to an existing DMS running STaaS:

1. Ensure the DMA you are adding is online and empty.

1. Disconnect the DMA you are adding from dataminer.services.

   To make sure the DMA is disconnected, follow the procedure on [Permanently disconnecting from dataminer.services](https://docs.dataminer.services/user-guide/Cloud_Platform/AboutCloudPlatform/Disconnecting_from_dataminer.services.html#permanently-disconnecting-from-dataminerservices).

   > [!IMPORTANT]
   > Only disconnect the DMA you are adding, NOT the cluster you are adding it to.

1. Make sure STaaS is not enabled in *DB.xml* for the DMA you are adding:

   1. Stop the DataMiner Agent.

   1. In the `C:\Skyline DataMiner` folder of the DMA, open the file *DB.xml*.

   1. Make sure that the *Database* tag with *type="CloudStorage"* has the *active* attribute set to **false**:

      ```xml
      <?xml version="1.0"?>
      <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
         <DataBase active="false" local="true" search="true" cloud="true" type="CloudStorage"/>
      </DataBases>
      ```

   1. Restart the DMA.

1. Join the DMA to the cluster using the steps described under [Adding a regular DataMiner Agent](https://docs.dataminer.services/user-guide/Advanced_Functionality/DataMiner_Systems/Adding_a_DMA/Adding_a_regular_DataMiner_Agent.html).

1. Once the DMA has successfully joined the cluster, enable STaaS in *DB.xml*:

   1. Stop the DataMiner Agent.

   1. In the `C:\Skyline DataMiner` folder of the DMA, open the file *DB.xml*.

   1. Configure the *Database* tag with *type="CloudStorage"* as follows:

      ```xml
      <?xml version="1.0"?>
      <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
         <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
      </DataBases>
      ```

   1. Restart the DMA.

The DMA should now be connected to the DMS running STaaS.
