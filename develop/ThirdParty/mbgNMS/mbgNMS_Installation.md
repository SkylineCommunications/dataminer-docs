---
uid: mbgNMS_Installation
---

# Installing mbgNMS using a pre-installed DataMiner Virtual Hard Disk

This is the recommended way to install the Meinberg Network Management System. It uses a virtual hard disk with DataMiner pre-installed, so you can get started quickly.

## Hardware requirements (host)

| Hardware | Requirements |
|--|--|
| Processor | 8 cores (16 vCPUs), passmark > 10K |
| Memory | 32 GB |
| Hard disk | 300 GB |
| Network | Throughput: 100 Mbps, Latency: < 50 ms |

## Create the VM

Download a virtual hard disk with DataMiner pre-installed for your virtualization platform:

- Hyper-V: [VHDX File](https://community.dataminer.services/download/mbgnms-vhdx/)
- Nutanix: [QCOW File](https://community.dataminer.services/download/mbgnms-qcow/)
- VMware ESXi: [VMDK File](https://community.dataminer.services/download/mbgnms-vmdk-esxi/)
- VMware Workstation: [VMDK File](https://community.dataminer.services/download/mbgnms-vmdk-workstation/)

This guide focuses on a Hyper-V setup while providing recommendations for other hypervisors. To create the VM, you have two options:

- **Automatic installation:** Download the [Meinberg NMS VM Installer](https://community.dataminer.services/download/mbgnms-vm-installer/) tool and run the *Install_Meinberg_NMS_VM.bat* file by double-clicking it.

- **Manual installation:** Follow the steps described below.

### Manual installation steps

1. **Optional: Create a custom virtual switch**

   > [!IMPORTANT]
   > The DataMiner software requires the VM to have a static IPv4 address configured. For this reason, it is recommended to create the VM using a custom virtual switch with a predefined IPv4 range, rather than using the default switch.

   Here is an example of how to create such a switch using PowerShell commands. Make sure to run them with administrator rights:

   ```powershell
   New-VMSwitch -Name "InternalNATSwitch" -SwitchType Internal
   New-NetIPAddress -IPAddress 172.16.0.1 -PrefixLength 24 -InterfaceAlias "vEthernet (InternalNATSwitch)"
   New-NetNat -Name "InternalNAT" -InternalIPInterfaceAddressPrefix 172.16.0.0/24
   ```

1. Start creating your VM by following the [official Hyper-V guide](https://learn.microsoft.com/en-us/windows-server/virtualization/hyper-v/get-started/create-a-virtual-machine-in-hyper-v):

   1. Specify a name for your VM and store the machine in a location of your own choice.
   1. Choose Virtual Machine Generation 2. Note: Generation 1 is not supported.
   1. Assign (at least) 12288 MB startup memory. Optionally, choose to use dynamic memory.
   1. Select a virtual switch (see step 1).
   1. Choose the VHDX file you have downloaded as virtual hard disk.
   1. Click *Finish*.

1. Ensure the VM has at least 4 vCPUs (minimum) allocated, 8 vCPUs recommended.

1. **Before starting the VM**, enable nested virtualization on your host for the VM you created. To do so, run the following command on your host in an elevated PowerShell prompt:

   ```powershell
   Set-VMProcessor -VMName <VMName> -ExposeVirtualizationExtensions $true
   ```

   > [!IMPORTANT]
   > Replace `<VMName>` with the name of your VM.

## Connect to and start the VM

1. When you have created the VM, double-click the entry and then click *Start* to boot the VM. You will see that the VM will boot in the OOBE setup screen.

1. Choose the region and keyboard settings and select a strong password for the built-in Administrator account. When you have set the password, the VM will restart. Log in to the VM.

1. Verify in the network configuration that the network interface uses a **static IPv4 address** instead of DHCP, because DataMiner requires a static IP. For more details, refer to *Change TCP/IP Settings* under [Essential Network Settings and Tasks in Windows](https://support.microsoft.com/en-us/windows/change-tcp-ip-settings-bd0a07af-15f5-cd6a-363f-ca2b6f391ace).

## Configure the VM

As soon as you log in to the VM, a window will be shown where you can configure your DataMiner System.

> [!NOTE]
> If you accidentally close the configuration window, you can run it again manually from the desktop.

1. Click *Next* to get started.

1. **Perpetual License:** Enter the DataMiner ID provided by Meinberg and click next. If you do not have a DataMiner ID yet, contact [mbgnms@meinberg.de](mailto:mbgnms@meinberg.de).

1. **Configuration Overview:** To start, click *Next*. The configuration progress will now be displayed. DataMiner Cube will automatically be installed, so you can connect to DataMiner locally.

   > [!NOTE]
   > A pop-up will ask for your credentials during this step.

1. Click *Find request.lic* to browse to the file *Request.lic*. Send a mail with the *Request.lic* file attached to [mbgnms@meinberg.de](mailto:mbgnms@meinberg.de).

1. A license file, *dataminer.lic* or *response.lic*, will be sent to you. Click *Upload License* and select the received license file.

   > [!IMPORTANT]
   > Do not rename the license file.

1. Click *Install Meinberg* to install the Meinberg Element Manager app on DataMiner.

1. Click *Finish* to exit the configuration window.

1. Log in to DataMiner Cube using the previously configured Administrator account. DataMiner Cube will have started automatically during the installation process. If not, a shortcut is available on your Desktop.

## Upgrade the Meinberg Element Manager

> [!NOTE]
> This section is not required during the initial installation. However, it is needed if you plan to upgrade your mbgNMS.

1. Download the latest Meinberg Element Manager package from the [community page](https://community.dataminer.services/downloads/).

1. Put the package (.dmapp) on the virtual machine and double-click it.

1. In the pop-up window, click *Install*. The upgrade progress will be displayed.

1. When the upgrade is ready, click *Finish*.
