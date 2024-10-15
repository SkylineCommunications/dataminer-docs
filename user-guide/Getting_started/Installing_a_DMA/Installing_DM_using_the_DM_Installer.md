---
uid: Installing_DM_using_the_DM_installer
description: When all prerequisites are met, download the installer from DataMiner Dojo. Then log in with an admin user account and run the installer.
---

# Installing DataMiner using the DataMiner Installer

The DataMiner installer allows you to run a DataMiner installation and to perform initial configuration.

> [!NOTE]
> The DataMiner software can only be installed on the C: drive. It is currently not possible to select another drive for the installation of DataMiner.

> [!IMPORTANT]
> Avoid using duplicates of existing VMs to install a new DataMiner machine. Using cloned VMs can cause certain configurations from the previous DataMiner machine to linger and cause conflicts in the system.

## Before you run the installer

1. Make sure the necessary .NET and .NET Framework versions are installed. See [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

   > [!TIP]
   >
   > - For information on how to determine which versions you have installed. See <https://learn.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed>.
   > - For installation information, see [Installation guide](https://docs.microsoft.com/en-us/dotnet/framework/install/).

1. Make sure the Windows setting "fast startup" is not activated.

1. Make sure the server is synced with an NTP server. If you intend to install multiple DataMiner Agents in a cluster, make sure all servers are synced with the same NTP server.

1. Make sure that no anti-virus software will interfere with the DataMiner installer and with the DataMiner software once it is installed. See [Regarding antivirus software](xref:Regarding_antivirus_software).

1. Make sure you have a Windows account with administrator rights. If you intend to use a DataMiner installer older than version 10.2, this must be the server's local Administrator account. For later installers, any account with administrator rights will suffice.

1. Download the DataMiner installer from [DataMiner Dojo](https://community.dataminer.services/download/dataminer-installer-v10-2).

> [!NOTE]
> The default installation requires that [Npcap](https://nmap.org/npcap/) or WinPcap (deprecated) is installed for systems intended for DataMiner Failover based on virtual IP. If you intend to configure a [Failover setup based on hostname](xref:Failover_configuration_in_Cube), this software will not be needed. WinPcap can be installed with a custom installation using the DataMiner 10.0 installer; however, note that WinPcap is considered obsolete since 2018. For now, NPCap is not included in the DataMiner Installer.

### Default DataMiner installation

1. Make sure you are logged into Windows with the server's local Administrator account. Do not use a regular user account with administrative rights.

1. Double-click the setup executable.

1. Click *Install*.

   The progress of the installation will be displayed. A *cancel* button in the lower right corner allows you to cancel the installation process if necessary.

1. Once the installation is complete, the configuration screen will show.

1. Click *Start*.

1. Select database type.

   - If you selected Self-hosted - External Storage please check [configure the databases](xref:Configuring_dedicated_clustered_storage).

1. Please enter the DataMiner Info

   - The Organization API Key can be found in [dataminer.services] (https://dataminer.services/) under the Admin app in the Keys page. The selected key needs to have the Add DataMiner nodes permission.

1. Check the selected configuration and click *Configure*

1. When DataMiner has successfully started you can close the installer.

At this point, the basic installation is complete. 

> [!IMPORTANT]
> During the DataMiner installation, you are automatically added to the Administrator group by the installation wizard, giving you all Administrator rights in DataMiner. To grant others access to the newly installed DMA, log in to Cube using the same Windows account as was used to install DataMiner, and configure user permissions as described in [Basic security configuration](xref:Managing_users).

> [!NOTE]
>
> - To view detailed log information on the installation process, in the last step of the installer, click the *open log files* button.
> - After the installation, if you have [configured security](xref:Managing_users) so that there is at least one other user with full administrator rights, you can safely remove the account you used for the installation if necessary.

