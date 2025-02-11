---
uid: Installing_DM_using_the_DM_installer
description: When all prerequisites are met, download the installer from DataMiner Dojo. Then log in with an admin user account and run the installer.
---

# Installing DataMiner using the DataMiner Installer

The DataMiner installer allows you to run a DataMiner installation and perform the initial configuration.

> [!NOTE]
> The DataMiner software can only be installed on the C: drive. It is currently not possible to select another drive for the installation of DataMiner.

> [!IMPORTANT]
> Avoid using duplicates of existing VMs to install a new DataMiner machine. Using cloned VMs can cause certain configurations from the previous DataMiner machine to linger and cause conflicts in the system.

## Before you run the installer

1. Make sure the necessary .NET and .NET Framework versions are installed. See [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

   <div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
     <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
       <b>💡 TIPS TO TAKE FLIGHT</b><br>Are you not sure which versions you have installed? Take a look at <a href="https://learn.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed" style="color: #657AB7;">Microsoft's guide</a> on this topic. You can also consult their <a href="https://learn.microsoft.com/en-us/dotnet/framework/install/" style="color: #657AB7;">.NET Framework installation guide</a>.
     </div>
     <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
   </div>
   <br>

1. Make sure the server is synced with an NTP server. If you intend to install multiple DataMiner Agents in a cluster, make sure all servers are synced with the same NTP server.

1. Make sure that no anti-virus software will interfere with the DataMiner installer and with the DataMiner software once it is installed. See [Regarding antivirus software](xref:Regarding_antivirus_software).

1. Make sure you have a Windows account with administrator rights. If you intend to use a DataMiner installer older than version 10.2, this must be the server's local Administrator account. For later installers, any account with administrator rights will suffice.

1. Download the DataMiner installer from [DataMiner Dojo](https://community.dataminer.services/dataminer-installer/).

> [!NOTE]
> The installation requires that [Npcap](https://nmap.org/npcap/) or WinPcap (deprecated) is installed for systems intended for DataMiner Failover based on virtual IP. If you intend to configure a [Failover setup based on hostname](xref:Failover_configuration_in_Cube), this software will not be needed.

## DataMiner Installer v10.4

If you are using DataMiner Installer v10.4, follow the steps below to install DataMiner:

1. Double-click the setup executable.

   If elevated permissions are required, in case you are logged in with a user account with administrator rights, you will only need to confirm. In case you are logged in with a regular user account, you will need to provide credentials for a user account with administrator rights.

1. Click *Install*.

   The progress of the installation will be displayed. A *cancel* button in the lower right corner allows you to cancel the installation process if necessary.

   Once the installation is complete, the configuration window will be displayed.

   > [!IMPORTANT]
   > At this point, DataMiner itself is fully installed, but the license and data storage still need to be configured.
   >
   > - The procedure below takes care of the automatic license and data storage configuration; however, this requires a connection to the internet. If you need to install DataMiner **offline**, **skip the configuration below**. Instead, the license and data storage configuration will need to be done manually:
   >   - For the license, see [Permanent license](xref:Permanent_license).
   >   - For the data storage configuration, please [contact tech support](xref:Contacting_tech_support).
   > - The procedure below will deploy DataMiner in subscription mode with a [Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition) license. To switch to a [perpetual license](xref:Pricing_Perpetual_Use_Licensing), see [Switching from subscription mode to perpetual license](#switching-from-subscription-mode-to-perpetual-license). To immediately install DataMiner with a perpetual license, you will need to configure the license and data storage manually, similar to an offline installation.
   > - If you intend to **restore a backup** coming from another machine because of e.g. a hardware migration or during disaster recovery, **skip the configuration below** and follow the steps under [Restoring a backup onto the new installed DataMiner Agent](#restoring-a-backup-onto-the-new-installed-dataminer-agent).

1. Click *Start*.

1. Select the desired database type, and click *Next*.

   These are the available database types:

   - [Storage as a Service (STaaS)](xref:STaaS) (recommended).

   - *Self-hosted - External Storage*: A regular [dedicated clustered storage setup](xref:Configuring_dedicated_clustered_storage). If you select this option, you will also need to fill in the connection details for both Cassandra and OpenSearch.

     > [!NOTE]
     > Make sure these clusters are active and reachable from the machine where you are installing DataMiner. You are responsible for the management of these external database clusters.

1. Fill in the required details to connect your DataMiner Agent to dataminer.services and click *Next*:

   - *Organization API Key*: Provide an organization key that has the necessary permissions to add DataMiner nodes in your organization. For more information on how you can add a new organization key to your organization on dataminer.services, see [Managing dataminer.services keys](xref:Managing_DCP_keys).
   - *System Name*: This name will be used to identify the DataMiner System in various dataminer.services applications.
   - *System URL*: This URL will grant you remote access to your DataMiner System web applications. You can choose to either [disable or enable this remote access feature](xref:Controlling_remote_access) at any time.
   - *Admin Email*: This email address must be associated with a dataminer.services account that is a member of your organization. It will become the owner of the DMS on dataminer.services.
   - *STaaS Region*: If you have selected to use [STaaS](xref:STaaS) for data storage, select the region where your data should be hosted.

1. Verify the selected configuration and click *Configure*

1. When the configuration is complete, click *Finish* to close the installer.

   DataMiner will automatically start up, get licensed, and connect to dataminer.services. DataMiner Cube will also be installed, so you can connect to DataMiner locally. At this point, the basic installation is complete.

1. To be able to make full use of all available DataMiner features, [upgrade to the latest feature or main release version](xref:Upgrading_a_DataMiner_Agent).

> [!IMPORTANT]
> During the DataMiner installation, you are automatically added to the Administrator group by the installation wizard, giving you all Administrator rights in DataMiner. To grant others access to the newly installed DMA, log in to Cube using the same Windows account as was used to install DataMiner, and configure user permissions as described in [Basic security configuration](xref:Managing_users).

> [!NOTE]
>
> - To view detailed log information on the installation process, in the last step of the installer, click the *open log files* button.
> - After the installation, if you have [configured security](xref:Managing_users) so that there is at least one other user with full administrator rights, you can safely remove the account you used for the installation if necessary.

### Restoring a backup onto the new installed DataMiner Agent

If you are using the DataMiner Installer v10.4 to restore a backup coming from another machine because of e.g. a hardware migration or during disaster recovery, after you have installed DataMiner, instead of clicking *Start* to configure the DataMiner Agent, follow the steps below:

1. Restore the backup in the same way as for a regular DataMiner Agent. See [Restoring a DataMiner Agent using the DataMiner Taskbar Utility](xref:Restoring_a_DMA_using_the_DataMiner_Taskbar_Utility).

1. [Stop the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. Open the *C:\Skyline DataMiner\\* folder.

1. Remove all *\*.lic* files, if any.

1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. After a short while, a *Request.lic* file should appear in the `C:\Skyline DataMiner\` folder.

1. Contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be) and provide them with the *Request.lic* file.

1. Wait until you receive a *dataminer.lic* file from Skyline.

1. When you have the *dataminer.lic* file, copy it to the `C:\Skyline DataMiner\` folder.

1. [Restart the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

### Switching from subscription mode to perpetual license

When you deploy a DataMiner Agent using the installer, your system will run in subscription mode and get licensed automatically. Part of this process involves getting a DataMiner ID, which uniquely identifies your DataMiner Agent.

If you have purchased a [permanent license](xref:Pricing_Perpetual_Use_Licensing), follow the steps below to convert your subscription installation to a perpetual-license one:

1. [Stop the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. Open the *C:\Skyline DataMiner\\* folder.

1. Remove all *\*.lic* files, if any.

1. Open the *DataMiner.xml* file.

1. Find the *&lt;DataMiner&gt;* tag and locate the *id* attribute.

1. Note down the value in the *id* attribute.

1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. After a short while, a *Request.lic* file should appear in the `C:\Skyline DataMiner\` folder.

1. Contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be) and provide them with the ID and the *Request.lic* file.

   In your email, mention that it concerns a conversion from a subscription to a perpetual license.

1. Wait until you receive a *dataminer.lic* file from Skyline.

1. When you have the *dataminer.lic* file, copy it to the `C:\Skyline DataMiner\` folder.

1. [Restart the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

## Older DataMiner installers (deprecated)

If you are using an older installer, follow the steps below to install DataMiner. However, keep in mind that installers prior to the 10.4 installer are considered deprecated.

### Default DataMiner installation

1. Make sure you are logged into Windows with the correct user account:

   - If you are using the DataMiner 10.2 installer or newer, use an account with administrator rights. During the installation, the user account will automatically be added to a local DataMiner user group named *Administrator (installer)*.
   - If you are using a DataMiner installer older than version 10.2, use the server's local Administrator account. Do not use a regular user account with administrative rights.

1. Double-click the setup executable.

1. Click *Install*.

1. Enter the DataMiner ID.

   > [!IMPORTANT]
   > To get this DataMiner ID, contact <dataminer.licensing@skyline.be>. The DataMiner ID will uniquely identify the DataMiner Agent you are installing.
   >
   > If you are a Skyline employee, use the procedure from the [Skyline internal documentation](https://internaldocs.skyline.be/Corporate/OperatingProcedures/OP_RequestDecommissionMaintainInternalServer/Requesting_a_DMA_ID_or_a_DataMiner_license_for_an_internal_DataMiner_Agent.html) instead.

1. Click next.

   The progress of the installation will be displayed. A *cancel* button in the lower right corner allows you to cancel the installation process if necessary.

1. Once the installation is complete, click *next*.

1. Click *go to Request.lic* to browse to *Request.lic*.

1. Send the *Request.lic* file to <dataminer.licensing@skyline.be>, and wait until you receive the reply.

   <div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
     <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
       <b>💡 TIPS TO TAKE FLIGHT</b><br>For more information, see <a href="xref:DataminerLicenses" style="color: #657AB7;">Obtaining a DataMiner license</a>.
     </div>
     <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
   </div>
   <br>

   > [!NOTE]
   > If you are a Skyline employee, use the procedure from the [Skyline internal documentation](https://internaldocs.skyline.be/Corporate/OperatingProcedures/OP_RequestDecommissionMaintainInternalServer/Requesting_a_DMA_ID_or_a_DataMiner_license_for_an_internal_DataMiner_Agent.html) instead.

1. Once you have received the license files, save these somewhere on the computer; however, not in the "Skyline DataMiner" folder.

1. In the *License* tab of the DataMiner Installer, click *browse and upload*, and navigate to the license files.

1. Once all files have been uploaded successfully, click *restart DataMiner*.

1. When DataMiner has successfully restarted, click *Close*.

At this point, the basic installation is complete. However, to be able to make full use of all available DataMiner features, you will also need to:

- [Upgrade to the latest feature or main release version](xref:Upgrading_a_DataMiner_Agent)
- [Connect your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)
- Either deploy [Storage as a Service](xref:STaaS) to make use of cloud-native storage hosted by Skyline or, if you wish to host the DataMiner storage yourself, [configure the databases](xref:Configuring_dedicated_clustered_storage).

> [!IMPORTANT]
> During the DataMiner installation, you are automatically added to the Administrator group by the installation wizard, giving you all Administrator rights in DataMiner. To grant others access to the newly installed DMA, log in to Cube using the same Windows account as was used to install DataMiner, and configure user permissions as described in [Basic security configuration](xref:Managing_users).

> [!NOTE]
>
> - To view detailed log information on the installation process, in the last step of the installer, click the *open log files* button.
> - If you closed the DataMiner installer before uploading the license files, copy the license files to the *C:\Skyline DataMiner* folder and restart DataMiner.
> - After the installation, if you have [configured security](xref:Managing_users) so that there is at least one other user with full administrator rights, you can safely remove the account you used for the installation if necessary.

### Custom DataMiner installation

If you are using an older, deprecated DataMiner installer, follow the steps below for a custom DataMiner installation.

1. Make sure you are logged into Windows as a user account with administrative rights.

1. Double-click the setup executable.

1. Click *Customize*.

1. Enter the DataMiner ID.

   > [!IMPORTANT]
   > To get this DataMiner ID, you must contact Skyline. The DataMiner ID will uniquely identify the DataMiner Agent you are installing.

1. Customize the installation to match the setup you want:

   - Ideally Cassandra should be installed on a different drive than the C drive. To specify the drive, click *select data drive*, select the drive, and click *OK*.

     > [!NOTE]
     > By default, a DataMiner Agent installed with the deprecated DataMiner installer uses a single Cassandra node that is hosted on the same physical or virtual server. However, different architectures are also possible. For more information, see [Storage options overview](xref:Supported_system_data_storage_architectures), or check with your Technical Account Manager.

   - If you are using an older DataMiner installer, you can select to install *MySQL Server*, and optionally [*MySQL Workbench*](xref:MySQL_Workbench). However, as MySQL support is **End of Life** as of DataMiner version 10.4.X (Q4 2023), this option is **not recommended**.

     > [!NOTE]
     >
     > - MySQL is no longer included in the 10.2.0 DataMiner installer.
     > - If a MySQL database is used, certain DataMiner features (e.g. trend predictions, ticketing, jobs, service & resource manager) will **not be available**.

   - If you are using the DataMiner 10.0 installer, on systems intended for DataMiner Failover based on virtual IP, install WinPcap by clicking *Install WinPcap*. The Setup Wizard of WinPcap will be launched. Follow the wizard, select *Automatically start the WinPcap driver at boot time*, and click *Next* when necessary.

     > [!NOTE]
     > The DataMiner 10.2 installer no longer supports WinPcap as it is deprecated. If you intend to configure a [Failover setup based on hostname](xref:Failover_configuration_in_Cube), this software will not be needed. However, if you intend to configure a [Failover setup based on virtual IP](xref:Failover_configuration_in_Cube), you will need to install [Npcap](https://nmap.org/npcap/) instead.

   - If the built-in Administrator account is not enabled, select *Create administrator account for current user* to create a Windows user account.

1. Click *Next*.

   The progress of the installation will be displayed. A *cancel* button in the lower right corner allows you to cancel the installation process if necessary.

1. Once the installation is complete, click *next*.

1. Click *go to Request.lic* to browse to *Request.lic*.

1. Send the *Request.lic* file to <dataminer.licensing@skyline.be>, and wait until you receive the reply.

1. Once you have received the license files, save these somewhere on the computer; however, not in the "Skyline DataMiner" folder.

1. In the *License* tab of the DataMiner Installer, click *browse and upload*, and navigate to the license files.

   > [!NOTE]
   > If you closed the DataMiner installer before uploading the license files, copy the license files to the *C:\Skyline DataMiner* folder and restart DataMiner.

1. Once all files have been uploaded successfully, click *restart DataMiner*.

1. When DataMiner has successfully restarted, click *Close*.

At this point, the basic installation is complete. However, to be able to make full use of all available DataMiner features, you will also need to:

- [Upgrade to the latest feature or main release version](xref:Upgrading_a_DataMiner_Agent)
- [Connect your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)
- Either deploy [Storage as a Service](xref:STaaS) to make use of storage nodes that are fully hosted by Skyline or, if you wish to host the storage nodes yourself, [configure the databases](xref:Configuring_dedicated_clustered_storage).

> [!IMPORTANT]
> During the DataMiner installation, you are automatically added to the Administrator group by the installation wizard, giving you all Administrator rights. To grant others access to your DMA, log in to Cube using the same username and password as during the installation process, and configure user permissions as described in [Basic security configuration](xref:Managing_users).

> [!NOTE]
>
> - To view detailed log information on the installation process, in the last step of the installer, click the *open log files* button.
> - After the installation, if you have [configured security](xref:Managing_users) so that there is at least one other user with full administrator rights, you can safely remove the account you used for the installation if necessary.
