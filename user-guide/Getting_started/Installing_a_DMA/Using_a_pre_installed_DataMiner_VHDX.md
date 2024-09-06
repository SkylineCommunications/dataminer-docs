---
uid: Using_a_pre_installed_DataMiner_VHDX
---

# Using a pre-installed DataMiner Virtual Hard Disk

You can download a Virtual Hard Disk (VHDX) with DataMiner pre-installed to immediately get started.

## Creating the VM

When you have dowloaded the VHDX, you can start to create a VM in your chosen virtualization environment. Below you can find the steps to follow in Hyper-V:

1. Start creating your VM by following [the official Hyper-V guide](https://learn.microsoft.com/en-us/windows-server/virtualization/hyper-v/get-started/create-a-virtual-machine-in-hyper-v)
    1. Specify a name for your VM and store the machine in a location of your own choice, make sure your disk has enough space
    1. Specify Generation 2
    1. Assign (at least) 8192 MB startup memory, you can choose to use dynamic memory
    1. Connect it to a virtual switch that has internet access
    1. Connect the Virtual Hard Disk that you just downloaded

If you intend to use the [WSL database](xref:Local_database_on_WSL), make sure to enable [nested virtualization](https://learn.microsoft.com/en-us/virtualization/hyper-v-on-windows/user-guide/nested-virtualization) for the VM you created.
Run the following command in an elevated Powershell prompt:

```powershell
Set-VMProcessor -VMName <VMName> -ExposeVirtualizationExtensions $true
```

> [!NOTE]
> Running DataMiner with a [locally hosted Cassandra Cluster and OpenSearch, running on Windows Subsystem for Linux (WSL)](xref:Local_database_on_WSL) should only be used for develop and test environments. When sufficient resources have been given to the Virtual Machine, consider migrating to [Storage as a Service (STaaS)](xref:STaaS) or [configure dedicated clustered storage](xref:Configuring_dedicated_clustered_storage) if you intend to use it in production.

## Connect and start the VM

After creating the VM with the VHDX connected, you can connect to your VM by double clicking on it. You will see it still is powered off, click on start.

You will see the VM will boot in the OOBE setup screen, choose region and keyboard settings and select a strong password for the built-in Administrator account.

> [!NOTE]
> The VM will restart after setting the password, please wait until you get to the login screen.

## Log in to the VM and start using DataMiner

After logging in, a window will be shown to configure your DataMiner system.

> [!IMPORTANT]
> If you intend to restore a backup coming from another machine because of e.g. a hardware migration or during disaster recovery, skip the configuration and follow the steps to [obtain a DataMiner license](xref:DataminerLicenses).

> [!TIP]
> If you accidentally closed the configuration screen, you can run it manually from `C:\Skyline DataMiner\Tools\FirstStartupChoice\FirstStartupChoice.ps1`.

Follow the below steps to configure your DataMiner Agent:

- Click *Start* to get started
- Select the desired database type, either [STaaS](xref:STaaS), [Self-hosted](xref:Configuring_dedicated_clustered_storage) or [WSL](xref:Local_database_on_WSL) and click *Next*
- When selecting [Self-hosted](xref:Configuring_dedicated_clustered_storage) database, fill in connection details for both Cassandra and OpenSearch and click *Next*
- Fill in required details to cloud connect your agent and click *Next*
    - Organization API Key:
    - System name: This name will be used to identify the DataMiner System in various DataMiner Cloud Platform applications
    - System URL: This URL will grant you remote access to your DataMiner System web applications. You can choose to either disable or enable this remote access feature at any time.
    - Admin Email: This email is associated with the DataMiner Services account which is an administrator in the organization
    - STaaS Region: If you selected to use [STaaS](xref:STaaS) as your database, select the region in which to host your data
- Verify the selected configuration and click *Configure*
- Once configuration completes, click *Finish*

After configuration finished, DataMiner will automatically startup, get licensed and perform cloud registration.

Furthermore it will install DataMiner Cube to locally connect to DataMiner.

> [!IMPORTANT]
> For security reasons, it is strongly advised to create a second user and disable the built-in administrator account once setup completed.

### Login to your DataMiner agent

At this point you should be able to login with the Administrator account.

For more information, see: [Logging on to DataMiner Cube](xref:Logging_on_to_DataMiner_Cube).

## Converting Subscription to Perpetual License

When deploying your agent using the pre-installed DataMiner Virtual Hard Disk, your system runs in subscription mode and gets licensed automatically.
Part of this process involves getting a DataMiner ID, which uniquely identifies your DataMiner Agent.

If you purchased a [permanent license](xref:Permanent_license) follow the below steps to convert your subscription installation to a perpetual one:

1. [Stop the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).
1. Open the *C:\Skyline DataMiner\\* folder.
1. Remove all *\*.lic* files, if any.
1. Open the *DataMiner.xml* file.
1. Find the *&lt;DataMiner&gt;* tag and locate the *id* attribute.
1. Note down the value in the *id* attribute.
1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).
1. After a short while, a *Request.lic* file should appear in the *C:\Skyline DataMiner\* folder.
1. Contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be) and provide them with the id and *Request.lic* file. Clearly state it concerns a conversion from a subscription to a perpetual license.
1. You will receive a *dataminer.lic* file from Skyline, which you need to copy to the *C:\Skyline DataMiner\\* folder.
1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).
