---
uid: Setting_up_StaaS
description: To set up STaaS on a self-managed DMS, connect the system to dataminer.services, register, edit DB.xml on each DMA, and restart DataMiner.
reviewer: Alexander Verkest
---

# Setting up STaaS

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Don't have an existing DataMiner System yet? Watch <a href="xref:Installing_DM_using_the_DM_installer" style="color: #657AB7;">this short video</a> to see how to install a self-managed DataMiner System with STaaS from scratch.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

<br>

For a self-managed DataMiner System, follow the steps below to set up STaaS.

> [!NOTE]
>
> - This setup is not needed for [DataMiner as a Service (DaaS) systems](xref:Creating_a_DMS_in_the_cloud), as these automatically use STaaS.
> - If you want to add a DMA to an existing DMS that uses STaaS, refer to [Adding a DataMiner Agent to a DMS running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS).

1. [Upgrade your DataMiner System](xref:Upgrading_a_DataMiner_Agent) to use at least DataMiner 10.4.0 [CU0]/10.4.1 or, preferably, the latest available DataMiner version.

   We recommend always upgrading DataMiner to the latest available version to get the latest features and performance updates. To be able to use non-indexed logger tables, the minimum supported version is DataMiner 10.4.0 [CU5]/10.4.8. <!-- RN 40066 -->

1. Make sure your DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. Make sure that all Agents in your DataMiner System have internet access, either directly or through a proxy.

   For specific endpoints or IPs to whitelist, contact <support@dataminer.services>. The configuration depends on the region you will register your system for.

   > [!NOTE]
   > All communication for STaaS happens through HTTPS. The DataMiner System initiates all outbound connections.

1. Make sure you have at least **DataMiner CloudGateway 2.8.0** installed on the system. See [Upgrading nodes to the latest DxM versions](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

1. Register your system to use STaaS:

   1. Go to the [Admin app](https://admin.dataminer.services).

   1. In the sidebar on the left, go to *Organization* > *Overview*.
  
   1. In the *DataMiner Systems* section, click the system you want to register.
  
   1. At the top of the page, in the *Storage as a Service* box, click the button *Get Started with STaaS*.
  
   1. Fill in your preferred region and click *Initialize*.

   > [!NOTE]
   > Only owners of a DataMiner System can register their system.

1. **Optionally**, [migrate your existing data to STaaS](xref:Migrating_existing_data_to_STaaS).

   If you do so, wait until the migration has been completed and verified before continuing with this procedure.

1. On each DataMiner Agent in the cluster, in the `C:\Skyline DataMiner` folder, open *DB.xml* and edit it corresponding to your setup:

   - For setups **without proxy**, use the following configuration:

      ```xml
      <?xml version="1.0"?>
      <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
         <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
      </DataBases>
      ```

   - For setups **with proxy** (this **requires DataMiner 10.4.5 or higher**<!-- RN 39221 -->), use the following configuration, filling in the fields as required:

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

      > [!NOTE]
      > If the proxy does not require authentication, you can leave the *UserName* and *Password* fields blank or remove them.

1. Restart DataMiner to begin using STaaS.

> [!NOTE]
> If you experience any issues during setup or while using Storage as a Service, refer to [Troubleshooting - STaaS](xref:Troubleshooting_STaaS).
