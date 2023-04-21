---
uid: Installing_DM_using_the_DM_installer
---

# Installing DataMiner using the DataMiner Installer

The DataMiner installer allows you to run a default DataMiner installation, which includes a Cassandra database on the C drive, or to run a custom installation. A custom installation can for instance be used to install a MySQL database instead of a Cassandra database.

## Before you run the installer

1. Make sure the necessary .NET and .NET Framework versions are installed. See [DataMiner Compute Requirements](https://community.dataminer.services/dataminer-compute-requirements/).

   > [!TIP]
   >
   > - For information on how to determine which versions you have installed. See <https://learn.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed>.
   > - For installation information, see [Installation guide](https://docs.microsoft.com/en-us/dotnet/framework/install/).

1. Make sure the Windows setting "fast startup" is not activated.

1. Make sure the server is synced with an NTP server. If you intend to install multiple DataMiner Agents in a cluster, make sure all servers are synced with the same NTP server.

1. Make sure that no anti-virus software will interfere with the DataMiner installer and with the DataMiner software once it is installed. See [Regarding antivirus software](xref:Regarding_antivirus_software).

1. Download the DataMiner installer from [DataMiner Dojo](https://community.dataminer.services/download/dataminer-installer-v10-2).

> [!NOTE]
> The default installation requires that WinPcap is installed for systems intended for DataMiner Failover. In a custom DataMiner installation, WinPcap can be included in the DataMiner installation.

### Default DataMiner installation

1. Make sure you are logged into Windows with the Administrator account. (Do not use a regular user account with administrative rights.)

1. Double-click *Setup_20220622092235919.exe*.

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

   > [!NOTE]
   > If you are a Skyline employee, use the procedure from the [Skyline internal documentation](https://internaldocs.skyline.be/Corporate/OperatingProcedures/OP_RequestDecommissionMaintainInternalServer/Requesting_a_DMA_ID_or_a_DataMiner_license_for_an_internal_DataMiner_Agent.html) instead.

1. Once you have received the license files, save these somewhere on the computer; however, not in the "Skyline DataMiner" folder.

1. In the *License* tab of the DataMiner Installer, click *browse and upload*, and navigate to the license files.

1. Once all files have been uploaded successfully, click *restart DataMiner*.

1. When DataMiner has successfully restarted, click *Close*.

At this point, the basic installation is complete. However, to be able to make full use of all available DataMiner features, you will also need to:

- [Upgrade to the latest feature or main release version](xref:Upgrading_a_DataMiner_Agent)
- [Install Elasticsearch](xref:Installing_Elasticsearch_via_DataMiner)
- [Connect your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

> [!NOTE]
>
> - To view detailed log information on the installation process, in the last step of the installer, click the *open log files* button.
> - If you closed the DataMiner installer before uploading the license files, copy the license files to the *C:\Skyline DataMiner* folder and restart DataMiner.

### Custom DataMiner installation

1. Make sure you are logged into Windows as a user account with administrative rights.

1. Double-click *Setup_20220622092235919.exe*.

1. Click *Customize*.

1. Enter the DataMiner ID.

   > [!IMPORTANT]
   > To get this DataMiner ID, you must contact Skyline. The DataMiner ID will uniquely identify the DataMiner Agent you are installing.

1. Customize the installation to match the setup you want:

   - Ideally Cassandra should be installed on a different drive than the C drive. To specify the drive, click *select data drive*, select the drive, and click *OK*.

     > [!NOTE]
     > By default, a DataMiner Agent uses a single Cassandra node that is hosted on the same physical or virtual server. However, different architectures are also possible. For more information, see [Supported system data storage architectures](xref:Supported_system_data_storage_architectures), or check with your Technical Account Manager.

   - To install a MySQL database instead of a Cassandra database, select *MySQL Server*, and optionally *MySQL Workbench*.

     > [!NOTE]
     > As MySQL support will go **End of Life** as of DataMiner version 10.3.X (Q4 2022), we recommend the **Cassandra database** for all new installations. MySQL is no longer included in the 10.2.0 DataMiner installer.
     > If a MySQL database is used, certain DataMiner features (e.g. trend predictions, ticketing, jobs, service & resource manager) will **not be available**.

   - On systems intended for DataMiner Failover, install WinPcap by clicking *Install WinPcap*. The Setup Wizard of WinPcap is launched. Follow the wizard, select *Automatically start the WinPcap driver at boot time*, and click *Next* when necessary.

     On Windows 8 and Windows Server 2012, click *Run without getting online help*. Follow the WinPcap setup. When an error occurs, click *OK*.

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
- [Install Elasticsearch](xref:Installing_Elasticsearch_via_DataMiner)
- [Connect your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

> [!NOTE]
> To view detailed log information on the installation process, in the last step of the installer, click the *open log files* button.
