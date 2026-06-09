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

## Step-by-step procedure

1. Install DataMiner on the on-premises servers, using either the [DataMiner Installer](xref:Installing_DM_using_the_DM_installer) or the [pre-installed DataMiner VHD](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk), but **do not run the configuration tool**.

1. On the newly installed Agents, set the following content in `C:\Skyline DataMiner\DB.xml`:

   ```xml
   <?xml version="1.0"?>
   <DataBases xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.skyline.be/config/db">
       <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
   </DataBases>
   ```

1. Contact <daas@dataminer.services> to provide a file named `userInfo.json` identifying your current DaaS cluster.

1. When you have received the `userInfo.json` file, place it in the `C:\Skyline DataMiner\` folder of each newly installed Agent.

1. Start up DataMiner.

1. [Upgrade](xref:Upgrading_a_DataMiner_Agent) the new Agents to the same DataMiner version as the DaaS nodes.

   > [!NOTE]
   > If the DaaS cluster is running a version lower than 10.6.0/10.6.1, and you used an installer that does not include BrokerGateway (i.e. the v10.4 or v10.5 installer), you will also need to [migrate to BrokerGateway](xref:BrokerGateway_Migration) because DaaS uses BrokerGateway by default.

1. [Enable Swarming](xref:EnableSwarming) on the new Agents.

1. In DataMiner, create a new user account `DataMinerAdmin` with the password defined on the DaaS nodes, and give it administrator permissions.

1. Make sure self-signed certificates are trusted between DaaS and self-managed nodes. Your DaaS nodes must trust the certificate from the self-managed nodes and vice versa.

   To export the certificate, run the following PowerShell commands:

   ```powershell
   $cert = Get-ChildItem -Path Cert:\LocalMachine\MY | where{$_.FriendlyName -eq "Auto-Created Certificate by DataMiner APIGateway"}
   Export-Certificate -Cert $cert -FilePath "C:\ProgramData\Skyline Communications\DataMiner APIGateway\APIGateway.cer"
   ```

   Copy the exported file to the other machine and run the following PowerShell commands to import it:

   ```powershell
   $import = (Get-ChildItem -Path "<download location>\APIGateway.cer")
   $import | Import-Certificate -CertStoreLocation Cert:\LocalMachine\Root
   ```

1. Add the connection string URI of the other machine. See [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string).

1. In the DaaS DMS, add the new self-managed nodes to the cluster using SLNetClientTest tool:

   1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

   1. In the *Message Type* dropdown list, select *SetDmsClusterMessage*

   1. Set *ClusterName* set to your desired cluster name, and click *Send Message*.

   1. In the *Message Type* dropdown list, select *AddIPToClusterMessage*

   1. Set *IP* set to the IP address of the self-managed node you want to add, and click *Send Message*.
