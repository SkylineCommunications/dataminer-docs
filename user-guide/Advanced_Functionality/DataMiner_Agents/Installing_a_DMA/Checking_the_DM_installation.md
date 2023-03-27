---
uid: Checking_the_DM_installation
---

# Checking the DataMiner installation

After installation, we recommend that you do the following checks in order to be sure that everything has been installed properly.

- Check the log in the *C:\ProgramData* folder. As this is a hidden folder, you may first need to enable the *Show hidden files, folders and drives* option in *Folder options*.

- Go to *Control Panel > Uninstall a program* to check if all prerequisites have been installed:

  - Microsoft Visual C++ 2005 Redistributable
  - Microsoft Visual C++ 2005 Redistributable (x64) (if working on a x64 system)
  - Microsoft Visual C++ 2010 x86 Redistributable
  - Microsoft Visual C++ 2010 x64 Redistributable (if working on a x64 system)
  - WinPcap (only needed for Failover systems)
  - MySQL Server (optional)
  - MySQL Workbench (optional)

- Go to *Control Panel > Uninstall a program > Turn Windows Features on or off* to check if all the necessary features have been enabled.

  - Under *Internet Information Services > Web Management Tools*, the following features must be enabled:

    - IIS 6 Management Compatibility
    - IIS 6 Metabase Compatibility
    - IIS 6 WMI Compatibility
    - IIS 6 Scripting Tools
    - IIS 6 Management Console

  - Under *Internet Information Services > World Wide Web Services > Application Development Features*, the following features must be enabled:

    - ASP.NET (3.5)
    - ASP.NET 4.5 (On Windows 8 and Windows 2012 Server)
    - .NET (3.5) Extensibility
    - .NET 4.5 Extensibility (On Windows 8 and Windows 2012 Server)
    - ASP
    - ISAPI Extensions
    - ISAPI Filters

  - Under *Internet Information Services > World Wide Web Services > Common HTTP Features*, the following features must be enabled:

    - Static Content
    - Default Document
    - Directory Browsing
    - HTTP Errors

  - Under *Internet Information Services > World Wide Web Services > Security*, the feature *Windows Authentication* must be enabled.

  - The *Simple Network Management Protocol* feature must be enabled.

  > [!NOTE]
  > These features are all listed in the tab *IIS*, except for *Simple Network Management Protocol*, which can be found under *Local Server Services > SNMP Service*.

- On a x64 system, check if *Enable32bitApplications* is set to true:

  1. Go to *Internet Information Services (IIS) Manager*.
  1. Open the tree in *Connections*.
  1. Click *Application Pools*.
  1. For each application pool, do the following check:

     1. Click *Application Pool*.
     1. In *Actions*, click *Advanced Settings*.
     1. Check if *Enable 32-Bit Applications* is set to true.

- Install DataMiner Cube and connect to the DMA. See [Installing the DataMiner Cube desktop application](xref:Installing_the_DataMiner_Cube_desktop_application).

> [!NOTE]
> Whenever you have installed or configured something new as a result of these checks (with the exception of DataMiner Cube), restart DataMiner and *SLNet.bat* as Administrator.
