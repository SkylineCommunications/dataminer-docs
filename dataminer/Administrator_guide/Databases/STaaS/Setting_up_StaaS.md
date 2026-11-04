---
uid: Setting_up_StaaS
description: "To set up STaaS on a self-managed DMS, connect the system to dataminer.services, register, edit DB.xml on each DMA, and restart DataMiner."
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

## Prerequisites

- DataMiner 10.4.0 [CU0]/10.4.1 or higher (preferably the latest available version). See [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

  > [!TIP]
  > We recommend always upgrading DataMiner to the latest available version to get the latest features and performance updates. To be able to use non-indexed logger tables, the minimum supported version is DataMiner 10.4.0 [CU5]/10.4.8. <!-- RN 40066 -->

- Your system must be connected to dataminer.services. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- All Agents in your DataMiner System must have internet access, either directly or through a proxy.

  If a firewall restricts outbound traffic, you can whitelist STaaS based on hostnames or based on IP addresses. See [Hostnames and IP addresses to whitelist](#hostnames-and-ip-addresses-to-whitelist).

  > [!NOTE]
  > All communication for STaaS happens through HTTPS. The DataMiner System initiates all outbound connections.

- DataMiner CloudGateway version 2.8.0 or higher. See [Upgrading nodes to the latest DxM versions](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

## Hostnames and IP addresses to whitelist

If a firewall restricts outbound traffic from your DataMiner Agents, make sure STaaS traffic is allowed. You can whitelist this traffic either [based on hostnames](#whitelisting-based-on-hostnames) or [based on IP addresses](#whitelisting-based-on-ip-addresses). In both cases, what you need to whitelist depends on your DataMiner version.

> [!TIP]
> From DataMiner 10.6.12/10.7.0 onwards<!-- RN 46570 -->, the whitelisting configuration is much simpler, as no additional hostnames or Microsoft Azure IP addresses need to be requested from support. We therefore recommend [upgrading DataMiner](xref:Upgrading_a_DataMiner_Agent) to version 10.6.12/10.7.0 or higher.

### Whitelisting based on hostnames

The hostnames to whitelist depend on your DataMiner version:

| DataMiner version | Hostnames to whitelist |
|--|--|
| DataMiner 10.6.12/10.7.0 or higher<!-- RN 46570 --> | Only `https://*.dataminer.services/`. No other hostnames are needed. |
| Earlier DataMiner versions | `https://*.dataminer.services/`, **and in addition** some extra hostnames, which depend on the region your system is registered for (and, for a geo-replicated (GRS) setup, its geo-redundancy pair region). These additional hostnames are not listed in this documentation. To get them, contact <support@dataminer.services>. |

> [!NOTE]
> `https://*.dataminer.services/` is also required to [connect your system to dataminer.services](xref:Connect_to_cloud_requirements), so you may already have whitelisted it.

### Whitelisting based on IP addresses

The IP addresses to whitelist depend on your DataMiner version:

| DataMiner version | IP addresses to whitelist |
|--|--|
| DataMiner 10.6.12/10.7.0 or higher<!-- RN 46570 --> | Only the region IP address(es) listed below. No other IP addresses are needed. |
| Earlier DataMiner versions | The region IP address(es) listed below, **and in addition** the Microsoft Azure IP addresses for your region (and, for a GRS setup, its geo-redundancy pair region). These Microsoft Azure IP addresses are not listed in this documentation. To get them, contact <support@dataminer.services>. |

The region IP address is determined by the region your system is registered for. For a **geo-replicated (GRS)** setup, you must whitelist **two region IP addresses**: the IP address of the primary region and the IP address of its geo-redundancy pair region.

In the table below, you can find the region IP address corresponding with each region:

| Region         | Region IP address |
|----------------|-------------------|
| West Europe    | 20.76.71.123      |
| UK South       | 20.162.131.128    |
| Central US     | 64.236.64.187     |
| Southeast Asia | 20.247.192.226    |
| Australia East | 4.147.198.192     |

If the IP address for your region or geo-redundancy pair region is not listed above, contact <support@dataminer.services>.

## Configuring STaaS

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
