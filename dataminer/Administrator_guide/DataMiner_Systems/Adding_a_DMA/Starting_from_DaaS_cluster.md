---
uid: Starting_from_DaaS_cluster
description: Learn how to extend a DaaS-only DataMiner System into a hybrid cluster by adding self-managed nodes.
---

# Creating a hybrid cluster starting from a DaaS cluster

## Prerequisites

- A DataMiner cluster consisting of DaaS nodes only, which meet the following requirements:

  - Deployed in a region close to where your self-managed nodes are deployed to minimize latency.
  - Using DataMiner 10.5.0 [CU2]/10.5.5 or higher.

- One or more on-premises servers ready to host DataMiner Agents (see [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements)).

- An established site-to-site VPN connection between DaaS and the on-premises network (see [About the site-to-site VPN connection](xref:Connecting_to_private_data_sources#about-the-site-to-site-vpn-connection)).

- Network address ranges that do not overlap. If the on-premises network overlaps with the default DaaS address space (172.23.0.0/16), first contact <daas@dataminer.services> to change the DaaS address space.

- A user account with the Admin or Owner role in the dataminer.services organization that owns the DaaS nodes.

- A dataminer.services organization key that has the *Create DataMiner System* permissions. For more information on how you can add a new organization key to your organization on dataminer.services, see [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).

## Step-by-step procedure

1. Install DataMiner on the on-premises servers, using either the [DataMiner Installer](xref:Installing_DM_using_the_DM_installer) or the [pre-installed DataMiner VHD](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk), but **do not run the configuration tool**.

1. On the newly installed Agents, set the following content in `C:\Skyline DataMiner\DB.xml`:

   ```xml
   <?xml version="1.0"?>
   <DataBases xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.skyline.be/config/db">
       <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
   </DataBases>
   ```

1. On each of the newly installed Agents, create a file `userInfo.json` in the `C:\Skyline DataMiner` root folder with the following contents:

   ```json
   {
      "organizationApiKey": "ORGANIZATION_API_KEY",
      "dmsName": "DMS_NAME",
      "dmsUrl": "DMS_URL",
      "dmsOwnerEmail": "DMS_OWNER_EMAIL",
      "dmsExists": true
   }
   ```

1. Replace the placeholders with the appropriate values:

   - *ORGANIZATION_API_KEY*: An organization key that has the necessary permissions to add DataMiner Systems in your organization.
   - *DMS_NAME*: The DMS name of the current DaaS system you want to add the on-premises Agent to. You can find the name on <https://dataminer.services> or <https://admin.dataminer.services>. For example, `hybrid-dms`.
   - *DMS_URL*: The first part of the URL, i.e., the part before the dash, of your DaaS system. You can find the URL on <https://dataminer.services> or <https://admin.dataminer.services>. For example, if the DMS URL is `https://hybriddms-myorg.on.dataminer.services`, fill in the URL value `hybriddms`.
   - *DMS_OWNER_EMAIL*: The email address of the current owner of the DaaS system.

1. Start up DataMiner.

1. [Upgrade the new Agents](xref:Upgrading_a_DataMiner_Agent) to the same DataMiner version as the DaaS nodes.

   > [!NOTE]
   > If the DaaS cluster is running a version lower than 10.6.0/10.6.1, and you used an installer that does not include BrokerGateway (i.e. the v10.4 or v10.5 installer), you will also need to [migrate to BrokerGateway](xref:BrokerGateway_Migration) because DaaS uses BrokerGateway by default.

1. [Enable Swarming](xref:EnableSwarming) on the new Agents.

1. In DataMiner, create a new user account `HybridAdmin` and configure it as follows:

   - Assign it to the built-in *Administrators* group.

   - Make sure *Password never expires* is selected.

   - Make sure the password meets the complexity requirements of DaaS nodes:

     - It does not contain the user's account name or parts of the user's full name that exceed two consecutive characters

     - It is at least six characters in length

     - It contains characters from three of the following four categories:

        - English uppercase characters (A through Z)

        - English lowercase characters (a through z)

        - Base 10 digits (0 through 9)

        - Non-alphabetic characters (for example, !, $, #, %)

   > [!NOTE]
   > The `HybridAdmin` user account will be used for cluster syncing, which means it needs to have the same password on all Agents in the cluster.

1. Add the connection string URI towards the DaaS node, using the `HybridAdmin` user account:

   1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   1. In the *Advanced* menu, select *Edit Connection Uris*.

   1. Right-click in the pop-up window and select *Add New Destination*.

   1. Configure the following fields and click *OK*:

      - *From*: Select the newly installed on-prem agent

      - *To*: Provide the IP address of the DaaS node. If you do not know the IP address, contact <daas@dataminer.services> to request this information.

      - *Username*: `HybridAdmin`

      - *Password*: The password you have created.

   1. Click *Done*

   > [!TIP]
   > See also: [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string).

1. Contact <daas@dataminer.services> with a request to add the on-premises system to the DaaS DMS.

   Make sure your email includes the following information:

   - The IP address of the DMA.

   - The password of the `HybridAdmin` user account.

   Skyline's DaaS team will perform the following steps on the DaaS Agents to add the connection string URI towards the on-prem nodes and add the new self-managed nodes to the cluster using SLNetClientTest tool:

   > [!NOTE]
   > The steps below **can only be executed by Skyline** and are included here for reference.

   1. On a DaaS node, create a new user account `HybridAdmin`, and configure it as follows:

      - Assign it to the built-in *Administrators* group.
      - Make sure *Password never expires* is selected.
      - Use the password received from the owner of the on-premises node.

   1. [Connect to the DaaS node using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   1. Go to the *Advanced* menu and select *Edit Connection Uris*.

   1. Right-click and select *Add New Destination*.

   1. Configure the following fields and click *OK*:

      - *To*: Provide the IP of the on-prem node.

      - *Update All Connections To This Agent*: Make sure this is selected.

      - *Username*: `HybridAdmin`

      - *Password*: Specify the password you received.

   1. Click *Done*

   1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

   1. In the *Message Type* dropdown list, select *SetDmsClusterMessage*.

   1. If the cluster currently consists of a single DaaS node, set *ClusterName* to your desired cluster name, and click *Send Message*.

      Skip this step if the DaaS node is already part of a cluster with several nodes.

   1. In the *Message Type* dropdown list, select *AddIPToClusterMessage*.

   1. Set *IP* to the IP address of the self-managed node you want to add, and click *Send Message*.

   1. Once the setup is fully functional, to improve security, update the connection string so it uses the `DataMinerAdmin` account instead of the `HybridAdmin` account, and then either remove the `HybridAdmin` user account or change its password.
