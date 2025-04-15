---
uid: Using_a_pre_installed_DataMiner_Virtual_Hard_Disk
---

# Using a pre-installed DataMiner Virtual Hard Disk

You can [download a virtual hard disk](https://community.dataminer.services/dataminer-virtual-hard-disk/) with DataMiner pre-installed to immediately get started. The virtual hard disk is available in **VHD**, **VHDX**, and **VMDK** format. The pre-installed DataMiner VM is [hardened](xref:DataMiner_hardening_guide) out-of-the box for improved security.

When you configure this setup, you will be able to choose between different data storage setups:

- [STaaS](xref:STaaS), i.e. the recommended setup.

- [Self-managed dedicated clustered storage](xref:Configuring_dedicated_clustered_storage): A setup where you host and manage the Cassandra and OpenSearch clusters required by DataMiner yourself on dedicated servers (not recommended). If you choose this setup, you will need to make sure these database clusters are fully installed before you run the procedures below, so that DataMiner will be able to connect to them.

- A **staging setup** where both Cassandra and OpenSearch run **locally** on Windows Subsystem for Linux (WSL). Such a setup should only be used for **testing and staging environments**, and this will also require additional resources on the local machine. To switch such a setup to production, you will need to either migrate to [Storage as a Service (STaaS)](xref:STaaS) or switch to using Cassandra and OpenSearch clusters on separate servers (not recommended), and then [decommission WSL](xref:Decommissioning_WSL).

Once you have downloaded the [pre-installed virtual hard disk](https://community.dataminer.services/dataminer-virtual-hard-disk/) from DataMiner Dojo, you will need to follow the steps below to use it:

1. [Create the VM](#creating-the-vm).
1. [Connect and start the VM](#connecting-and-starting-the-vm).
1. [Configure DataMiner](#configuring-dataminer).
1. Optionally, [switch from subscription mode to a perpetual-license setup](#switching-from-subscription-mode-to-perpetual-license).

> [!NOTE]
>
> - If you are not familiar with virtualization, we suggest [installing DataMiner using the DataMiner Installer](xref:Installing_DM_using_the_DM_installer) instead.
> - The **VMDK** hard disk is compatible with desktop hypervisors such as VMWare Workstation. If you use the hard disk in a VMware vSphere ESXi environment, an error mentioning *Unsupported and/or invalid disk type* can be shown. For information on how to resolve this issue, refer to [A virtual machine fails to power on with the error: Unsupported and/or invalid disk type](https://knowledge.broadcom.com/external/article/310567/a-virtual-machine-fails-to-power-on-with.html).

## Creating the VM

When you have downloaded the virtual hard disk, you can start to create a VM in your chosen virtualization environment. Below you can find the steps to follow in Hyper-V:

1. Start creating your VM by following [the official Hyper-V guide](https://learn.microsoft.com/en-us/windows-server/virtualization/hyper-v/get-started/create-a-virtual-machine-in-hyper-v).

1. Specify a name for your VM and store the machine in a location of your own choice, making sure your disk has enough space.

1. Choose Virtual Machine Generation 2.

1. Assign (at least) 8192 MB startup memory.

   Optionally, you can choose to use dynamic memory.

   > [!IMPORTANT]
   > If you intend to run the databases locally on the same server using WSL, assign at least 12288 MB RAM, as the WSL storage container will take about 4 GB to run.

1. Connect to a virtual switch that has internet access (either the default switch or a custom one).

   > [!NOTE]
   > If you choose the default virtual switch, you will only be able to use [remote access](xref:Cloud_Remote_Access) through dataminer.services to access the system outside of the virtual machine environment.

1. Connect the virtual hard disk that you have just downloaded.

> [!IMPORTANT]
> If you intend to use the locally hosted Cassandra and OpenSearch clusters running on WSL, make sure to enable [nested virtualization](https://learn.microsoft.com/en-us/virtualization/hyper-v-on-windows/user-guide/nested-virtualization) on your host PC for the VM you created before starting the VM. To do so, run the following command on your host PC in an elevated Powershell prompt:
>
> ```powershell
> Set-VMProcessor -VMName <VMName> -ExposeVirtualizationExtensions $true
> ```

## Connecting and starting the VM

1. When you have created the VM, double-click the entry and then click *Start* to boot the VM.

   You will see that the VM will boot in the OOBE setup screen.

1. Choose the region and keyboard settings and select a strong password for the built-in Administrator account.

   When you have set the password, the VM will restart.

1. When the login screen is shown, log in to the VM.

## Configuring DataMiner

As soon as you log in to the VM, a window will be shown where you can configure your DataMiner System.

![Configuring DataMiner Agent Screen](~/user-guide/images/install-first-startup-choice-script.png)

> [!IMPORTANT]
>
> - The configuration wizard takes care of the automatic license and data storage configuration; however, this requires a connection to the internet. If you need to install DataMiner **offline**, you will not be able to use this wizard. Instead, the license and data storage configuration will need to be done manually:
>   - For the license, see [Permanent license](xref:Permanent_license).
>   - For the data storage configuration, please refer to [Configuring dedicated clustered storage](xref:Configuring_dedicated_clustered_storage).
> - If you intend to restore a **backup** coming from another machine because of e.g. a hardware migration or during disaster recovery, **skip** the configuration below and follow the steps under [Restoring a backup onto the virtual hard disk](#restoring-a-backup-onto-the-virtual-hard-disk).
> - DataMiner requires a **static IP** to be configured. Make sure to do this before continuing with the below steps. If you have to change the IP afterwards, you can do so by following the steps described in [Changing the IP of a DMA](xref:Changing_the_IP_of_a_DMA).

> [!NOTE]
> If you have accidentally closed the configuration window, you can run it manually from `C:\Skyline DataMiner\Tools\FirstStartupChoice\FirstStartupChoice.ps1`. Make sure to run it with administrator privileges.

Follow the below steps to configure your DataMiner Agent:

1. Click *Start* to get started.

1. Select the desired database type, and click *Next*.

   These are the available database types:

   - [Storage as a Service (STaaS)](xref:STaaS) (recommended).

   - *Self-hosted - External Storage*: A regular [dedicated clustered storage setup](xref:Configuring_dedicated_clustered_storage). If you select this option, you will also need to fill in the connection details for both Cassandra and OpenSearch.

     > [!NOTE]
     > Make sure these clusters are active and reachable from the VM you are setting up. You are responsible for the management of these external database clusters.

   - *Self-hosted - Local storage*: A clustered storage setup where both Cassandra and OpenSearch run locally on WSL.

     > [!IMPORTANT]
     > Do not select this option for production systems. This option should only be used for testing and staging environments, and only if you have made sure the necessary resources will be available for the WSL storage container. See [Creating the VM](#creating-the-vm).

1. Fill in the required details to connect your DataMiner Agent to dataminer.services and click *Next*:

   - *Organization API Key*: Provide an organization key that has the necessary permissions to add DataMiner nodes in your organization. For more information on how you can add a new organization key to your organization on dataminer.services, see [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).
   - *System Name*: This name will be used to identify the DataMiner System in various dataminer.services applications.
   - *System URL*: This URL will grant you remote access to your DataMiner System web applications. You can choose to either [disable or enable this remote access feature](xref:Controlling_remote_access) at any time.
   - *Admin Email*: This email address must be associated with a dataminer.services account that is a member of your organization. It will become the owner of the DMS on dataminer.services.
   - *STaaS Region*: If you have selected to use [STaaS](xref:STaaS) for data storage, select the region where your data should be hosted.

1. Verify the selected configuration and click *Configure*

1. When the configuration is complete, click *Finish*

   DataMiner will automatically start up, get licensed, and connect to dataminer.services. DataMiner Cube will also be installed, so you can connect to DataMiner locally.

1. [Log in to DataMiner Cube](xref:Logging_on_to_DataMiner_Cube) using the previously configured Administrator account.

   Logging in automatically with the built-in Administrator account is not possible, so you will need to fill in the username and password.

> [!IMPORTANT]
> For security reasons, we strongly recommend creating a second user and disabling the built-in administrator account once the setup is complete. See [Managing users](xref:Managing_users).

## Restoring a backup onto the virtual hard disk

If you want to restore a backup coming from another machine because of e.g. a hardware migration or during disaster recovery, after you have created and connected the VM, instead of the configuration steps detailed above, follow the steps below:

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

## Switching from subscription mode to perpetual license

When you deploy a DataMiner Agent using the pre-installed DataMiner Virtual Hard Disk, your system will run in subscription mode and get licensed automatically. Part of this process involves getting a DataMiner ID, which uniquely identifies your DataMiner Agent.

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

## Switching from subscription mode to an offline demo license

When you deploy a DataMiner Agent using the pre-installed DataMiner Virtual Hard Disk, your system will automatically be licensed and run in subscription mode. A DataMiner Agent running in subscription mode **has to remain connected** to [dataminer.services](xref:about_dataminer_services) to keep it licensed. If for some reason you cannot keep your Agent connected to [dataminer.services](xref:about_dataminer_services), it will automatically shut down after 1 month.

If after this period you want to extend the usage of the system, you can convert your subscription installation to an offline demo installation:

1. [Stop the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. Open the *C:\Skyline DataMiner\\* folder.

1. Remove all *\*.lic* files, if any.

1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. After a short while, a *Request.lic* file should appear in the `C:\Skyline DataMiner\` folder.

1. Contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be) and provide them with the *Request.lic* file.

   In your email, mention that it concerns a conversion from a subscription to a demo license.

1. Wait until you receive a *Response.lic* file from Skyline.

1. When you have the *Response.lic* file, copy it to the `C:\Skyline DataMiner\` folder.

1. [Restart the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).
