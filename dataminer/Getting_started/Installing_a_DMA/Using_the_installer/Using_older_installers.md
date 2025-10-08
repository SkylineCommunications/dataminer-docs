---
uid: Using_older_installers
---

# Older DataMiner installers (deprecated)

If you are using an older installer, follow the steps below to install DataMiner. However, keep in mind that installers prior to the 10.4 installer are considered deprecated, so unless there is a specific reason why you need to use an older installer, we highly recommend using the [DataMiner Installer v10.4](xref:Installing_DM_using_the_DM_installer) instead.

## Default DataMiner installation

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

   The progress of the installation will be displayed. A *cancel* button in the lower-right corner allows you to cancel the installation process if necessary.

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
> - If you closed the DataMiner installer before uploading the license files, copy the license files to the `C:\Skyline DataMiner` folder and restart DataMiner.
> - After the installation, if you have [configured security](xref:Managing_users) so that there is at least one other user with full administrator rights, you can safely remove the account you used for the installation if necessary.

## Custom DataMiner installation

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

   - If you are using an older DataMiner installer, you can select to install *MySQL Server*, and optionally [*MySQL Workbench*](xref:MySQL_Workbench). However, as MySQL support is [scheduled to end soon](xref:Software_support_life_cycles#third-party-software-support-lifecycle), this option is **not recommended**.

     > [!NOTE]
     >
     > - MySQL is no longer included in the 10.2.0 DataMiner installer.
     > - If a MySQL database is used, certain DataMiner features (e.g. trend predictions, ticketing, jobs, service & resource manager) will **not be available**.

   - If you are using the DataMiner 10.0 installer, on systems intended for DataMiner Failover based on virtual IP, install WinPcap by clicking *Install WinPcap*. The Setup Wizard of WinPcap will be launched. Follow the wizard, select *Automatically start the WinPcap driver at boot time*, and click *Next* when necessary.

     > [!NOTE]
     > The DataMiner 10.2 installer no longer supports WinPcap as it is deprecated. If you intend to configure a [Failover setup based on hostname](xref:Failover_configuration_in_Cube), this software will not be needed. However, if you intend to configure a [Failover setup based on virtual IP](xref:Failover_configuration_in_Cube), you will need to install [Npcap](https://nmap.org/npcap/) instead.

   - If the built-in Administrator account is not enabled, select *Create administrator account for current user* to create a Windows user account.

1. Click *Next*.

   The progress of the installation will be displayed. A *cancel* button in the lower-right corner allows you to cancel the installation process if necessary.

1. Once the installation is complete, click *next*.

1. Click *go to Request.lic* to browse to *Request.lic*.

1. Send the *Request.lic* file to <dataminer.licensing@skyline.be>, and wait until you receive the reply.

1. Once you have received the license files, save these somewhere on the computer; however, not in the "Skyline DataMiner" folder.

1. In the *License* tab of the DataMiner Installer, click *browse and upload*, and navigate to the license files.

   > [!NOTE]
   > If you closed the DataMiner installer before uploading the license files, copy the license files to the `C:\Skyline DataMiner` folder and restart DataMiner.

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
