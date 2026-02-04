---
uid: Installing_DM_using_the_DM_installer
description: When all prerequisites are met, download the installer from DataMiner Dojo. Then log in with an admin user account and run the installer.
---

# Installing DataMiner using the DataMiner Installer

With the DataMiner Installer, you can install DataMiner on premises, in a private cloud, or in a hybrid setup.

The core DataMiner software can only be installed on the C: drive. It is currently not possible to select another drive for this. The storage nodes for the DataMiner System can be hosted in the cloud by Skyline (Storage as a Service), or you can host them yourself. You will be able to select your preferred option for this during the installation.

You can follow the steps below or watch this short video, which shows you how to install a self-managed system using the DataMiner Installer v10.4 with the [Storage as a Service](xref:STaaS) storage type:

<div style="width: 100%; max-width: 800px;">
  <video style="width: 100%; aspect-ratio: 16 / 9; height: auto;" controls>
    <source src="~/dataminer/images/Self-managed_with_STaaS.mp4" type="video/mp4">
  </video>
</div>

<p><br></p>

> [!IMPORTANT]
>
> - **Avoid using duplicates of existing VMs** to install a new DataMiner machine. Using cloned VMs can cause certain configurations from the previous DataMiner machine to linger and cause conflicts in the system.
> - If you do not want to do a default installation, but you want to restore a **backup**, create a **Failover** Agent to pair with an existing Agent, or do an **offline** installation, you will need to follow a **different procedure** than shown in the video above. Please read the instructions below carefully to make sure you follow the correct procedure.

> [!TIP]
> By default, a DataMiner System is deployed with a **Community Edition license**. For information on pricing and limitations for this license, see [DataMiner Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition).

## Before you run the Installer

1. Check the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements) and make sure your system meets the necessary requirements.

   If you do not intend to use the latest Installer (v10.5), make sure the necessary .NET and .NET Framework versions are installed, as mentioned in the requirements. With the v10.5 Installer, these will be included in the installation.

   > [!NOTE]
   > If the .NET Framework is not installed, the v10.5 Installer will install it and prompt you to reboot the system before continuing the installation.

1. Make sure the server is synced with an NTP server. If you intend to install multiple DataMiner Agents in a cluster, make sure all servers are synced with the same NTP server.

1. Make sure that no anti-virus software will interfere with the DataMiner installation and with the DataMiner software once it is installed. See [Regarding antivirus software](xref:Regarding_antivirus_software).

1. Make sure you have a Windows account with administrator rights.

1. Verify in the network configuration that the network interface uses a static IP instead of DHCP, because DataMiner requires a static IP.

   For more details, refer to *Change TCP/IP Settings* under [Essential Network Settings and Tasks in Windows](https://support.microsoft.com/en-us/windows/essential-network-settings-and-tasks-in-windows-f21a9bbc-c582-55cd-35e0-73431160a1b9).

1. If you do not intend to use the latest Installer (v10.5), download and install the DataMiner Cloud Pack from [DataMiner Dojo](https://community.dataminer.services/dataminer-cloud-pack/).

   With the v10.5 Installer, this will be included in the installation.

1. Download the DataMiner Installer from [DataMiner Dojo](https://community.dataminer.services/dataminer-installer/).

> [!NOTE]
> If you intend to install a DataMiner Agent that will be used in a [Failover setup](xref:About_DMA_Failover) based on virtual IP, you will also need to install [Npcap](https://nmap.org/npcap/) or WinPcap (deprecated) on the system. For a regular DataMiner Agent or a Failover setup based on hostname, this software will not be needed.

## Running the Installer

### [Installer v10.5](#tab/tabid-1)

To install DataMiner using the DataMiner Installer v10.5, follow the steps below:

1. Double-click the setup executable.

   If elevated permissions are required, in case you are logged in with a user account with administrator rights, you will only need to confirm. In case you are logged in with a regular user account, you will need to provide credentials for a user account with administrator rights.

1. Click *Install*.

   The progress of the installation will be displayed. A *cancel* button in the lower-right corner allows you to cancel the installation process if necessary.

   When the installation is complete, do not immediately click the *Run Configuration Tool* button. First read the notes below.

   > [!IMPORTANT]
   > At this point, the DataMiner core software is fully installed. If you continue with the steps below, the Installer will also automatically take care of the license and data storage configuration. However, if you **do not want a default installation**, you may not want to use this automatic configuration:
   >
   > - If you intend to **restore a backup** coming from another machine because of e.g. a hardware migration or during disaster recovery, skip the configuration below and follow the steps under [Restoring a backup onto the new installed DataMiner Agent](xref:Restoring_backup_on_newly_installed_DMA).
   > - If you are installing a **Failover** Agent, skip the configuration below, and follow the steps under [Configuring the new DataMiner Agent as a new Agent in a Failover pair](xref:Configuring_a_new_DMA_in_Failover_pair).

   > [!NOTE]
   > If you have accidentally closed the configuration window, you can run it manually from `C:\Skyline DataMiner\Tools\FirstStartupChoice\FirstStartupChoice.exe`. Make sure to run it with administrator privileges.

1. If you want to proceed with the configuration of your DataMiner Agent, click *Run Configuration Tool* to start the DataMiner Configurator, and then click *Next*.

1. On the *Storage* page, select the desired database type:

   - [STaaS (Storage as a Service)](xref:STaaS) (recommended).

   - *Self Managed - External*: A regular [dedicated clustered storage setup](xref:Configuring_dedicated_clustered_storage). If you select this option, you will also need to fill in the connection details for both Cassandra and OpenSearch.

     > [!NOTE]
     > Make sure these clusters are active and reachable from the machine where you are installing DataMiner. You are responsible for the management of these external database clusters.

1. Click *Next* to proceed to the *Registration* page, and fill in the required details to connect your DataMiner Agent to dataminer.services:

   - *Organization API Key*: Provide an organization key that has the necessary permissions to add DataMiner Systems in your organization. For more information on how you can add a new organization key to your organization on dataminer.services, see [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).
   - *System name*: This name will be used to identify the DataMiner System in various dataminer.services applications.
   - *System URL*: This URL will grant you remote access to your DataMiner System web applications. You can choose to either [disable or enable this remote access feature](xref:Controlling_remote_access) at any time.
   - *Admin Email*: This email address must be associated with a dataminer.services account that is a member of your organization. It will become the owner of the DMS on dataminer.services.
   - *STaaS Region*: If you have selected to use [STaaS](xref:STaaS) for data storage, select the region where your data should be hosted.

   ![Registration details when STaaS was selected](~/dataminer/images/Registration_of_DMA_when_StaaS_is_selected.png)<br>*Example with registration details for a STaaS setup*

   > [!NOTE]
   > By default, if you install DataMiner while connected to the internet, DataMiner is deployed in subscription mode with a [Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition) license. However, if you want to do an offline installation or if you want to install DataMiner with a [perpetual license](xref:Permanent_license), click the link below the registration fields and enter the DataMiner ID provided by Skyline. If you do not have a DataMiner ID yet, contact <dataminer.licensing@skyline.be>.
   >
   > ![Perpetual license configuration](~/dataminer/images/Perpetual_License.png)
   >
   > You can also deploy DataMiner in subscription mode first and [switch to a perpetual license](xref:Switching_from_subscription_mode_to_perpetual_license) later.

1. Click *Next*, and verify the configuration settings you entered.

1. To start the configuration, click *Configure*.

   The configuration progress will now be displayed.

1. When the configuration is complete, click *Finish* to close the installer.

   DataMiner will automatically start up and connect to dataminer.services. DataMiner Cube will also be installed, so you can connect to DataMiner locally.

1. To be able to make full use of all available DataMiner features, [upgrade to the latest feature or main release version](xref:Upgrading_a_DataMiner_Agent).

> [!IMPORTANT]
> During the DataMiner installation, you are automatically added to the Administrator group by the installation wizard, giving you all Administrator rights in DataMiner. To grant others access to the newly installed DMA, log in to Cube using the same Windows account as was used to install DataMiner, and configure user permissions as described in [Basic security configuration](xref:Managing_users).

> [!NOTE]
>
> - To view detailed log information on the installation process, in the last step of the installation, click the *Open logs* button.
> - After the installation, if you have [configured security](xref:Managing_users) so that there is at least one other user with full administrator rights, you can safely remove the account you used for the installation if necessary.

### [Installer v10.4](#tab/tabid-2)

To install DataMiner using the DataMiner Installer v10.4, follow the steps below:

1. Double-click the setup executable.

   If elevated permissions are required, in case you are logged in with a user account with administrator rights, you will only need to confirm. In case you are logged in with a regular user account, you will need to provide credentials for a user account with administrator rights.

1. Click *Install*.

   The progress of the installation will be displayed. A *cancel* button in the lower-right corner allows you to cancel the installation process if necessary.

   Once the installation is complete, the configuration window will be displayed.

   > [!IMPORTANT]
   > At this point, the DataMiner core software is fully installed. If you continue with the steps below, the Installer will also automatically take care of the license and data storage configuration. However, if you **do not want a default installation**, you may not want to use this automatic configuration:
   >
   > - The default installation requires a connection to the internet. For an **offline installation**, skip the configuration below. Instead, the license and data storage configuration will need to be done manually:
   >   - For the license, see [Permanent license](xref:Permanent_license).
   >   - For the data storage configuration, please refer to [Configuring dedicated clustered storage](xref:Configuring_dedicated_clustered_storage).
   > - The procedure below will deploy DataMiner in subscription mode with a [Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition) license. To switch to a [perpetual license](xref:Pricing_Perpetual_Use_Licensing), see [Switching from subscription mode to perpetual license](xref:Switching_from_subscription_mode_to_perpetual_license). To immediately install DataMiner with a **perpetual license**, you will need to configure the license and data storage manually, similar to an offline installation.
   > - If you intend to **restore a backup** coming from another machine because of e.g. a hardware migration or during disaster recovery, skip the configuration below and follow the steps under [Restoring a backup onto the new installed DataMiner Agent](xref:Restoring_backup_on_newly_installed_DMA).
   > - If you are installing a **Failover** Agent, skip the configuration below, and follow the steps under [Configuring the new DataMiner Agent as a new Agent in a Failover pair](xref:Configuring_a_new_DMA_in_Failover_pair).

1. To continue with a default installation, click *Start*.

1. Select the desired database type, and click *Next*.

   These are the available database types:

   - [Storage as a Service (STaaS)](xref:STaaS) (recommended).

   - *Self-hosted - External Storage*: A regular [dedicated clustered storage setup](xref:Configuring_dedicated_clustered_storage). If you select this option, you will also need to fill in the connection details for both Cassandra and OpenSearch.

     > [!NOTE]
     > Make sure these clusters are active and reachable from the machine where you are installing DataMiner. You are responsible for the management of these external database clusters.

1. Fill in the required details to connect your DataMiner Agent to dataminer.services and click *Next*:

   - *Organization API Key*: Provide an organization key that has the necessary permissions to add DataMiner Systems in your organization. For more information on how you can add a new organization key to your organization on dataminer.services, see [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).
   - *System Name*: This name will be used to identify the DataMiner System in various dataminer.services applications.
   - *System URL*: This URL will grant you remote access to your DataMiner System web applications. You can choose to either [disable or enable this remote access feature](xref:Controlling_remote_access) at any time.
   - *Admin Email*: This email address must be associated with a dataminer.services account that is a member of your organization. It will become the owner of the DMS on dataminer.services.
   - *STaaS Region*: If you have selected to use [STaaS](xref:STaaS) for data storage, select the region where your data should be hosted.

1. Verify the selected configuration and click *Configure*.

1. When the configuration is complete, click *Finish* to close the Installer.

   DataMiner will automatically start up, get licensed, and connect to dataminer.services. DataMiner Cube will also be installed, so you can connect to DataMiner locally. At this point, the basic installation is complete.

1. To be able to make full use of all available DataMiner features, [upgrade to the latest feature or main release version](xref:Upgrading_a_DataMiner_Agent).

> [!IMPORTANT]
> During the DataMiner installation, you are automatically added to the Administrator group by the installation wizard, giving you all Administrator rights in DataMiner. To grant others access to the newly installed DMA, log in to Cube using the same Windows account as was used to install DataMiner, and configure user permissions as described in [Basic security configuration](xref:Managing_users).

> [!NOTE]
>
> - To view detailed log information on the installation process, in the last step of the installation, click the *open log files* button.
> - After the installation, if you have [configured security](xref:Managing_users) so that there is at least one other user with full administrator rights, you can safely remove the account you used for the installation if necessary.

***
