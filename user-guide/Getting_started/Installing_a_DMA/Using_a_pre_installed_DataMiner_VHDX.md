---
uid: Using_a_pre_installed_DataMiner_VHDX
---

# Using a pre-installed DataMiner Virtual Hard Disk

You can download a Virtual Hard Disk (VHDX) with DataMiner pre-installed to immediately get started.

## Creating the VM

When you have dowloaded the VHDX, you can start to create a VM in your chosen virtualization environment, this will show you the steps to follow in Hyper-V.

1. Start creating your VM by following [the official Hyper-V guide](https://learn.microsoft.com/en-us/windows-server/virtualization/hyper-v/get-started/create-a-virtual-machine-in-hyper-v)
  1. Specify a name for your VM and store the machine in a location of your own choice, make sure your disk has enough space
  1. Specify Generation 2
  1. Assign (at least) 8192 MB startup memory, you can choose to use dynamic memory
  1. Connect it to a virtual switch that has internet access
  1. Connect the Virtual Hard Disk that you just downloaded

If you intend to use the WSL database, make sure to enable [nested virtualization](https://learn.microsoft.com/en-us/virtualization/hyper-v-on-windows/user-guide/nested-virtualization) for the VM you created. You can do this by running Powershell as administrator and running the following command: `Set-VMProcessor -VMName <VMName> -ExposeVirtualizationExtensions $true`

> [!NOTE]
> Running DataMiner with a [locally hosted Cassandra Cluster and OpenSearch, running on Windows Subsystem for Linux (WSL)](xref:Local_database_on_WSL) should only be used for develop and test environments. When sufficient resources have been given to the Virtual Machine, consider migrating to [Storage as a Service (STaaS)](xref:STaaS) or [configure dedicated clustered storage](xref:Configuring_dedicated_clustered_storage) if you intend to use it in production.

## Connect and start the VM
After creating the VM with the VHDX connected, you can connect to your VM by double clicking on it. You will see it still is powered off, click on start.

You will see the VM will boot in the OOBE setup screen, choose region and keyboard settings and also fill in your secure password for the built-in Administrator user.
> [!NOTE]
> The VM will restart after setting the password, please wait until you get to the login screen.

## Log in to the VM and start using DataMiner

Now you can log in, a configuration script will start to choose which storage you want, and it will create a cloud connection for the system.

> [!NOTE]
> Do not close the configuration window, if you accidently did, you can run it manually at `C:\Skyline DataMiner\Tools\FirstStartupChoice\FirstStartupChoice.ps1`.

After you filled in everything and click the 'configure' button. This will configure dataminer according to your chosen storage option.
DataMiner will start automatically and do the cloud registration, get an ID and license.

Furthermore it will install DataMiner Cube to locally connect to DataMiner.

> [!IMPORTANT]
> For security reasons, it is strongly advised to create a second user and disable the built-in administrator account.

<!-- ### Request and set the DataMiner ID

The DataMiner ID uniquely identifies your DataMiner Agent.
To get a DataMiner ID, contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be).
Once you received your unique ID, do the following:

1. Open the *C:\Skyline DataMiner\\* folder.
1. Open the *DataMiner.xml* file.
1. Find the *&lt;DataMiner&gt;* tag and locate the *id* attribute.
1. In the *id* attribute, fill in the DataMiner ID you received.
1. Save and close the file.

### Request and configure a DataMiner license

To start DataMiner, a license is required.
To request a license:

1. Open the *C:\Skyline DataMiner\\* folder.
1. Remove all *\*.lic* files, if any.
1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).
1. After a short while, a *Request.lic* file should appear in the *C:\Skyline DataMiner\* folder.
1. [Obtain your DataMiner license](xref:DataminerLicenses).
1. Once you received the *dataminer.lic* and *clientapps.lic* files from Skyline, copy them to the *C:\Skyline DataMiner\\* folder.
1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility). -->

### Login to your DataMiner agent

At this point you should be able to login with the Administrator account.

For more information, see: [Logging on to DataMiner Cube](xref:Logging_on_to_DataMiner_Cube).
