---
uid: KI_Problem_after_OS_upgrade_to_win_2022
---

# Problem after upgrading Window OS to Windows Server 2022

## Affected versions

Systems that have just been upgraded to Windows Server 2022.

## Cause

After an upgrade to Windows Server 2022, the following issues can cause problems with DataMiner:

- Netlogon service is not enabled.
- IIS is not enabled and the default website is not set.

## Fix

- For the Netlogon issue, refer to the Microsoft article [Netlogon service does not keep settings](https://learn.microsoft.com/en-us/troubleshoot/windows-server/active-directory/netlogon-service-not-start-automatically)

- For the IIS issue:

  1. On the DMA server, open Server Manager, and make sure that IIS is enabled.

  1. Use the following PowerShell command to configure the necessary IIS features:
  
     ```txt
     Add-WindowsFeature Web-Server, Web-WebServer, Web-Security, Web-Filtering, Web-ASP, Web-Asp-Net45, Web-Mgmt-Compat, Web-Lgcy-Scripting, Web-ISAPI-Filter, Web-WMI, Web-WebSockets
     ```

  1. Go to `C:\Skyline DataMiner\Tools` and run *ConfigureIIS.bat*.

## Description

After the server running a DMA is upgraded to Windows Server 2022, the DMA appears to be disconnected from the DataMiner System. In System Center, its status is indicated as *Disconnected* or *Unknown*.
