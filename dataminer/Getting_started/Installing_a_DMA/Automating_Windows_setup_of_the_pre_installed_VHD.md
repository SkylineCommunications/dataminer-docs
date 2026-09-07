---
uid: Automating_Windows_setup_of_the_pre_installed_VHD
description: Learn how to use a Windows unattend.xml answer file to automate the initial Windows setup of the pre-installed DataMiner Virtual Hard Disk.
---

# Automating the initial Windows setup of the pre-installed VHD

When you [deploy the pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk), the VM boots into the Windows out-of-box experience (OOBE), where you interactively select the region and keyboard layout and set a password for the built-in Administrator account.

For a one-off deployment, following these interactive steps is the simplest and most secure option. However, if you need to provision the VM without any manual interaction, for example when repeatedly creating test VMs from a pipeline or a script, you can inject a Windows answer file (*unattend.xml*) into the virtual hard disk before the first boot. Windows Setup then uses this file to complete the OOBE automatically.

> [!IMPORTANT]
> This procedure is intended for automated or repeated deployments. For a single production deployment, use the interactive steps under [Connecting and starting the VM](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk#connecting-and-starting-the-vm) instead.

## Security considerations

> [!WARNING]
> An *unattend.xml* file stores the administrator password in a recoverable form (Base64-encoded, not encrypted). If someone has access to the file or to the virtual hard disk it is injected into, they will be able to retrieve that password. Take the following precautions:
>
> - Never store an *unattend.xml* file that contains a real password in source control or another shared location.
> - Use a temporary password, and change it as soon as the VM has been provisioned.
> - After provisioning, delete the answer file from the VM, including any copies Windows cached under `C:\Windows\Panther`.

## Preparing the answer file

Create an answer file named *unattend.xml*, based on the [Windows unattended installation reference](https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/windows-setup-automation-overview), which configures at least the following settings for the built-in Administrator account and computer name:

- In the `specialize` configuration pass, `Microsoft-Windows-Shell-Setup\ComputerName`.
- In the `oobeSystem` configuration pass, `Microsoft-Windows-Shell-Setup\UserAccounts\AdministratorPassword` and the `OOBE` settings needed to skip the interactive screens.

Below is a minimal example:

```xml
<?xml version="1.0" encoding="utf-8"?>
<unattend xmlns="urn:schemas-microsoft-com:unattend">
  <settings pass="specialize">
    <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="amd64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
      <ComputerName>MyVmName</ComputerName>
    </component>
  </settings>
  <settings pass="oobeSystem">
    <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="amd64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
      <UserAccounts>
        <AdministratorPassword>
          <Value>MyTemporaryPassword</Value>
          <PlainText>true</PlainText>
        </AdministratorPassword>
      </UserAccounts>
      <OOBE>
        <HideEULAPage>true</HideEULAPage>
        <SkipMachineOOBE>true</SkipMachineOOBE>
        <SkipUserOOBE>true</SkipUserOOBE>
      </OOBE>
    </component>
  </settings>
</unattend>
```

> [!NOTE]
> Replace `MyVmName` and `MyTemporaryPassword` for every VM you provision. Each computer name must be unique on the network.

## Injecting the answer file into the virtual hard disk

Follow the steps below on the Hyper-V host, before the VM is started for the first time:

1. Make a copy of the downloaded virtual hard disk, so the original download stays untouched.

1. Mount the copied VHDX offline, without starting a VM:

   ```powershell
   Mount-VHD -Path <path to the VHDX copy> -Passthru | Get-Disk | Get-Partition | Get-Volume
   ```

   Note the drive letter assigned to the partition that contains the `Windows` folder.

1. Create the *Unattend* folder and copy the answer file into it:

   ```powershell
   New-Item -ItemType Directory -Force -Path "<drive letter>:\Windows\Panther\Unattend"
   Copy-Item -Path <path to unattend.xml> -Destination "<drive letter>:\Windows\Panther\Unattend\unattend.xml"
   ```

1. Dismount the virtual hard disk:

   ```powershell
   Dismount-VHD -Path <path to the VHDX copy>
   ```

1. Attach the modified virtual hard disk to a new VM, as described under [Creating the VM](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk#creating-the-vm), and start it.

   Windows Setup will automatically pick up `Windows\Panther\Unattend\unattend.xml` and use it to complete the OOBE without any manual interaction.

1. Continue with [Configuring DataMiner](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk#configuring-dataminer).

1. Once DataMiner has been configured, connect to the VM and delete the answer file, together with any copies Windows cached under `C:\Windows\Panther`, and change the Administrator password if you used a temporary one.
