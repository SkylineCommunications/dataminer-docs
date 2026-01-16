---
uid: Adding_a_DMA_to_a_DMS_running_STaaS
---

# Adding a DataMiner Agent to a DMS running STaaS

To add a DataMiner Agent to a DMS running STaaS:

1. Make sure that the DMA you are adding is a clean DMA, meaning that it is a newly installed DMA or a DMA that has been [fully reset](xref:Factory_reset_tool).


   From DataMiner 10.6.2/10.7.0 onwards<!--RN 44171-->, the operation will fail if the DMA is not cloud-connected or if the DMA and DMS do not have the same identity.

1. Install the [DataMiner Cloud Pack](xref:DataMiner_Cloud_Pack) on the new DMA.

1. Stop DataMiner and CloudGateway on the new DMA.

1. From a DMA in the cluster where CloudGateway is running, copy the folder `C:\ProgramData\Skyline Communications\DataMiner CloudGateway\Data\CcaGatewayPersisted` and place it in the same location on the new DMA.

1. Remove the following files from the folder you just copied to the new DMA:

   - DmsAccessToken.data
   - DmsAccessTokenExpiration.data
   - DmsRefreshToken.data
   - DmsRefreshTokenExpiration.data

1. Start CloudGateway on the new DMA.

1. Configure *DB.xml* to use STaaS:

   1. In the `C:\Skyline DataMiner` folder, open *DB.xml*.

   1. Configure the *Database* tag with *type="CloudStorage"* as illustrated below:

      - For setups **without proxy**, use the following configuration:

         ```xml
         <?xml version="1.0"?>
         <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
            <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
         </DataBases>
         ```

      - For setups **with proxy** (this **requires DataMiner 10.4.5/10.5.0 or higher**<!-- RN 39221 -->), use the following configuration, filling in the fields as required:

         ```xml
         <?xml version="1.0"?>
         <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
            <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage">
               <Proxy>
                  <Address>[Enter Address Here]</Address>
                  <Port>[Enter Port Here]</Port>
                  <UserName>[Enter UserName Here]</UserName>
                  <Password>[Enter Password Here]</Password>
               </Proxy>
            </DataBase>
         </DataBases>
         ```

1. Start DataMiner on the new DMA.

1. Join the DMA to the cluster using the steps described under [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent) or [Failover configuration in Cube](xref:Failover_configuration_in_Cube) for a Failover Agent.

   The DMA should now be connected to the DMS running STaaS.

1. Optionally, if the new DMA is not intended to host the CloudGateway DxM, you can safely uninstall it.

   > [!NOTE]
   > In this case, the Admin app will still display connection information indicating that CloudGateway is not running. To remove this invalid state, [contact DataMiner Support](xref:Contacting_tech_support).
